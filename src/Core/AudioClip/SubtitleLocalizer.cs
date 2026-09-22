using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;


namespace UltrakULL;

// Shared English -> current-language subtitle table. Each boss subtitle swap keeps patching its own
// methods, but instead of per-method key logic they all inject a single `call Localize` on the caption
// right before SubtitleController.DisplaySubtitle. Localize looks the English caption up in the table
// at runtime (so it follows language switches); only non-empty translations are stored, so an
// untranslated line keeps its original English text.
public static class SubtitleLocalizer
{
    private static readonly Dictionary<string, string> map = new Dictionary<string, string>(StringComparer.Ordinal);

    private static readonly MethodInfo DisplaySubtitle = AccessTools.Method(
        typeof(SubtitleController), "DisplaySubtitle", new[] { typeof(string), typeof(AudioSource), typeof(bool) });

    private static readonly MethodInfo DisplaySubtitleOverride = AccessTools.Method(
        typeof(SubtitleController), "DisplaySubtitle", new[] { typeof(string), typeof(float), typeof(GameObject) });

    private static readonly MethodInfo LocalizeMethod = AccessTools.Method(typeof(SubtitleLocalizer), nameof(Localize));

    // Make sure this func is called before LanguageManager.InitializeManager
    public static void Initialize()
    {
        LanguageManager.OnLanguageChanged += _ => Rebuild();
    }

    private static void Rebuild()
    {
        map.Clear();

        Lang english = LanguageManager.allLanguages.Values.FirstOrDefault(l => l.IsEnglish);

        json.Subtitles source = english?.Json?.subtitles;
        json.Subtitles current = LanguageManager.Current?.Json?.subtitles;
        if (source == null || current == null)
            return;

        foreach (FieldInfo field in typeof(json.Subtitles).GetFields())
        {
            string original = field.GetValue(source) as string;
            string translated = field.GetValue(current) as string;
            if (!string.IsNullOrEmpty(original) && !string.IsNullOrEmpty(translated) && original != translated)
                map[original] = translated;
        }
    }

    // Called at runtime from the patched boss methods. Empty/untranslated -> keep the English caption.
    public static string Localize(string caption)
    {
        if (string.IsNullOrEmpty(caption) || LanguageManager.IsEnglish)
            return caption;
        return map.TryGetValue(caption, out string translated) ? translated : caption;
    }

    // Transpiler used by every boss subtitle swap: inserts `call Localize` on the caption of each
    // DisplaySubtitle(string, AudioSource, bool) call (the string is loaded 3 instructions before it).
    public static IEnumerable<CodeInstruction> InjectLocalize(IEnumerable<CodeInstruction> instructions)
    {
        List<CodeInstruction> list = instructions.ToList();
        List<CodeInstruction> result = new List<CodeInstruction>(list.Count + 4);

        for (int i = 0; i < list.Count; i++)
        {
            result.Add(list[i]);
            if (i + 3 < list.Count && IsDisplaySubtitleCall(list[i + 3]))
                result.Add(new CodeInstruction(OpCodes.Call, LocalizeMethod));
        }
        return result;
    }

    public static IEnumerable<CodeInstruction> InjectLocalize2(IEnumerable<CodeInstruction> instructions, MethodInfo localize, OpCode? anchorOpcode)
    {
        // new Pos = (callPos + 2 - m.Pos) - 1 = callPos + 1
        // Since function localize itself are count as a line
        return new CodeMatcher(instructions)
            .MatchForward(false, 
                new CodeMatch(i => i.Calls(DisplaySubtitle) || i.Calls(DisplaySubtitleOverride))
            )
            .Repeat(m =>
            {
                int callPos = m.Pos;

                m.SearchBack(i => i.opcode == (anchorOpcode ?? OpCodes.Ldstr));
                if (m.IsInvalid || callPos - m.Pos > 8)            // holy magic number
                {
                    Logging.Warn("InjectLocalize: no nearby ldstr before DisplaySubtitle, skipped.");
                    m.Advance(1);
                    return;
                }

                m.Advance(1)
                .Insert(new CodeInstruction(OpCodes.Call, localize))
                .Advance(callPos + 2 - m.Pos);
            })
            .InstructionEnumeration();
    }

    private static bool IsDisplaySubtitleCall(CodeInstruction instruction)
        => instruction.opcode == OpCodes.Callvirt && CodeInstructionExtensions.OperandIs(instruction, DisplaySubtitle);
}
