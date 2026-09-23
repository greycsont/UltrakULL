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
    private static readonly MethodInfo DisplaySubtitle = AccessTools.Method(
        typeof(SubtitleController), "DisplaySubtitle", new[] { typeof(string), typeof(AudioSource), typeof(bool) });

    private static readonly MethodInfo DisplaySubtitleOverride = AccessTools.Method(
        typeof(SubtitleController), "DisplaySubtitle", new[] { typeof(string), typeof(float), typeof(GameObject) });

    public static IEnumerable<CodeInstruction> InjectLocalize2(IEnumerable<CodeInstruction> instructions, MethodInfo localize, OpCode? anchorOpcode = null)
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
                    Logging.Warn($"InjectLocalize: no nearby {anchorOpcode ?? OpCodes.Ldstr} before DisplaySubtitle, skipped.");
                    m.Start().Advance(callPos + 1);     // while (Invalid) {Pos += direction} => Pos = -1 
                    return;
                }

                m.Advance(1)
                .Insert(new CodeInstruction(OpCodes.Call, localize))
                .Advance(callPos + 2 - m.Pos);
            })
            .InstructionEnumeration();
    }

    public static IEnumerable<CodeInstruction> InjectLocalize3(IEnumerable<CodeInstruction> instructions, MethodInfo localize, int position = -2)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false,
                new CodeMatch(i => i.Calls(DisplaySubtitle) || i.Calls(DisplaySubtitleOverride))
            )
            .Repeat(m =>
            {
                int callPos = m.Pos;

                m.Advance(position)
                .Insert(new CodeInstruction(OpCodes.Call, localize))
                .Advance(callPos + 2 - m.Pos);
            })
            .InstructionEnumeration();
    }
}
