using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(Coin))]
public static class CoinPatch
{
    [HarmonyPatch(nameof(Coin.RicoshotPointsCheck))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> RicoshotPointsCheckTranspiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var localizeRicoshotText = AccessTools.Method(
            typeof(CoinPatch),
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

        var result = text switch
        {
            "<color=orange>ULTRA</color>" =>
                "<color=orange>{0}</color>".FormatWith(LanguageManager.CurrentLanguage.style.style_ricoshotUltra),
            "<color=red>COUNTER</color>" =>
                "<color=red>{0}</color>".FormatWith(LanguageManager.CurrentLanguage.style.style_ricoshotCounter),
            _ => null
        };

        return result.Or(text);
    }
}
