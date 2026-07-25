using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(Coin))]
public static class LocalizeCoin
{
    [HarmonyPatch(nameof(Coin.RicoshotPointsCheck))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> RicoshotPointsCheck_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var localizeRicoshotText = AccessTools.Method(
            typeof(LocalizeCoin),
            nameof(LocalizeRicoshotText));

        return new CodeMatcher(instructions, generator)
            .MatchForward(
                false,
                new CodeMatch(OpCodes.Ldstr, "<color=orange>ULTRA</color>"))
            .ThrowIfNotMatch("Could not find the ULTRA ricoshot text")
            .Advance(1)
            .Insert(new CodeInstruction(OpCodes.Call, localizeRicoshotText))
            .MatchForward(
                false,
                new CodeMatch(OpCodes.Ldstr, "<color=red>COUNTER</color>"))
            .ThrowIfNotMatch("Could not find the COUNTER ricoshot text")
            .Advance(1)
            .Insert(new CodeInstruction(OpCodes.Call, localizeRicoshotText))
            .InstructionEnumeration();
    }

    private static string LocalizeRicoshotText(string text)
    {
        if (LanguageManager.IsEnglish)
            return text;

        return text switch
        {
            "<color=orange>ULTRA</color>" =>
                $"<color=orange>{LanguageManager.CurrentLanguage.style.style_ricoshotUltra}</color>",
            "<color=red>COUNTER</color>" =>
                $"<color=red>{LanguageManager.CurrentLanguage.style.style_ricoshotCounter}</color>",
            _ => text
        };
    }
}
