using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(Mandalore))]
public static class MandaloreSubtitlesSwap
{
    private const string MandaloreColor = "FFC49E";
    private const string OwlColor = "9EE6FF";
    private const string WhiteColor = "FFFFFF";

    private readonly struct Dialog
    {
        public readonly string Color;
        public readonly Func<json.Subtitles, string> GetTranslation;

        public Dialog(string color, Func<json.Subtitles, string> getTranslation)
        {
            Color = color;
            GetTranslation = getTranslation;
        }
    }

    private static readonly Dictionary<string, Dialog> Dialogs = new()
    {
        // Start
        ["<color=#FFC49E>You cannot imagine what you'll face here</color>"] =
            new(MandaloreColor, subtitles => subtitles.subtitles_mandalore_taunt3),
        ["<color=#9EE6FF>I'm gonna shoot em with a gun</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_taunt2),
        ["<color=#9EE6FF>Why are we in the past</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_taunt5),
        ["<color=#9EE6FF>I'm going to fucking poison you</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_taunt1),
        ["<color=#FFC49E>What</color>"] =
            new(MandaloreColor, subtitles => subtitles.subtitles_mandalore_intro2),
        ["<color=#FFC49E>Hold still</color>"] =
            new(MandaloreColor, subtitles => subtitles.subtitles_mandalore_taunt4),

        // Update
        ["<color=#9EE6FF>Oh great, now we lost the fight, fantastic</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_defeated),
        ["Full auto"] =
            new(WhiteColor, subtitles => subtitles.subtitles_mandalore_attack1),
        ["Fuller auto"] =
            new(WhiteColor, subtitles => subtitles.subtitles_mandalore_attack2),
        ["<color=#9EE6FF>Use the salt!</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_phaseChangeThird1),
        ["<color=#FFC49E>I'm reaching!</color>"] =
            new(MandaloreColor, subtitles => subtitles.subtitles_mandalore_phaseChangeThird2),
        ["<color=#FFC49E>Feel my maximum speed!</color>"] =
            new(MandaloreColor, subtitles => subtitles.subtitles_mandalore_phaseChangeSecond1),
        ["<color=#9EE6FF>Slow down</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_phaseChangeSecond2),
        ["<color=#FFC49E>Through the magic of the Druids, I increase my speed!</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_phaseChangeFirst1),
        ["<color=#9EE6FF>Just fucking hit em</color>"] =
            new(OwlColor, subtitles => subtitles.subtitles_mandalore_phaseChangeFirst2)
    };

    private static readonly MethodInfo LocalizeDialogMethod =
        AccessTools.Method(typeof(MandaloreSubtitlesSwap), nameof(LocalizeDialog));

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Mandalore.Start))]
    [HarmonyPatch(nameof(Mandalore.Update))]
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var dialog = new CodeMatch(IsDialogInstruction);
        var matcher = new CodeMatcher(instructions, generator)
            .MatchForward(false, dialog);

        return matcher
            .Repeat(match => match
                .Advance(1)
                .InsertAndAdvance(new CodeInstruction(OpCodes.Call, LocalizeDialogMethod)))
            .InstructionEnumeration();
    }

    private static bool IsDialogInstruction(CodeInstruction instruction)
    {
        return instruction.opcode == OpCodes.Ldstr &&
               instruction.operand is string original &&
               Dialogs.ContainsKey(original);
    }

    private static string LocalizeDialog(string original)
    {
        if (LanguageManager.IsEnglish || !Dialogs.TryGetValue(original, out Dialog dialog))
            return original;

        string translation = dialog.GetTranslation(LanguageManager.CurrentLanguage.subtitles);
        return string.IsNullOrEmpty(translation)
            ? original
            : $"<color=#{dialog.Color}>{translation}</color>";
    }
}
