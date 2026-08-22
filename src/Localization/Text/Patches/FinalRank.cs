using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

//@Override
//Overrides the SetInfo method from the FinalRank class. This is needed to swap text in the extra into box on the results screen.
// See ResultScreenPatcher.cs for more detail
[NeedRework]
[HarmonyPatch(typeof(FinalRank), "SetInfo")]
public static class LocalizeFinalRankInfo
{
    [HarmonyPrefix]
    public static bool SetInfo_MyPatch(int restarts, bool damage, bool majorUsed, bool cheatsUsed, FinalRank __instance,
        bool ___noRestarts, bool ___majorAssists, bool ___noDamage
    )
    {
        if (LanguageManager.IsEnglish)
        {
            return true;
        }

        __instance.extraInfo.text = "";
        int num = 1;
        if (!damage)
        {
            num++;
        }
        if (majorUsed)
        {
            num++;
        }
        if (cheatsUsed)
        {
            num++;
        }
        if (cheatsUsed)
        {
            TMP_Text text = __instance.extraInfo;
            text.text +=
                "- <color=#44FF45>"
                + LanguageManager.CurrentLanguage.misc.endstats_cheatsUsed
                + "</color>\n";
        }
        if (majorUsed)
        {
            TMP_Text text2 = __instance.extraInfo;
            text2.text +=
                "- <color=#4C99E6>"
                + LanguageManager.CurrentLanguage.misc.endstats_assistsUsed
                + "</color>\n";
            ___majorAssists = true;
        }
        if (restarts == 0)
        {
            if (num >= 3)
            {
                TMP_Text text3 = __instance.extraInfo;
                text3.text +=
                    "+ " + LanguageManager.CurrentLanguage.misc.endstats_noRestarts + "\n";
            }
            else
            {
                TMP_Text text4 = __instance.extraInfo;
                text4.text +=
                    "+ "
                    + LanguageManager.CurrentLanguage.misc.endstats_noRestarts
                    + "\n  (+500<color=orange>"
                    + LanguageManager.CurrentLanguage.shop.shop_moneyCount
                    + "</color>)\n";
            }
            ___noRestarts = true;
        }
        else
        {
            TMP_Text text5 = __instance.extraInfo;
            text5.text =
                "- <color=red>"
                + restarts
                + "</color> "
                + LanguageManager.CurrentLanguage.misc.endstats_restarts
                + "\n";
        }
        if (!damage)
        {
            if (num >= 3)
            {
                TMP_Text text6 = __instance.extraInfo;
                text6.text +=
                    "+ <color=orange>"
                    + LanguageManager.CurrentLanguage.misc.endstats_noDamage
                    + "</color>\n";
            }
            else
            {
                TMP_Text text7 = __instance.extraInfo;
                text7.text +=
                    "+ <color=orange>"
                    + LanguageManager.CurrentLanguage.misc.endstats_noDamage
                    + "\n  (</color>+5,000<color=orange>"
                    + LanguageManager.CurrentLanguage.shop.shop_moneyCount
                    + ")</color>\n";
            }
            ___noDamage = true;
        }
        return false;
    }
}

[HarmonyPatch(typeof(FinalRank))]
public static class FinalRank_PointsShow_Patch
{
    [HarmonyPatch(nameof(FinalRank.PointsShow))] [HarmonyTranspiler]
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var code in instructions)
        {
            if (code.opcode == OpCodes.Ldstr && (string)code.operand == "<color=orange>P</color>")
            {
                code.operand =
                    "<color=orange>"
                    + LanguageManager.CurrentLanguage.shop.shop_moneyCount
                    + "</color>";
            }

            yield return code;
        }
    }
}

[HarmonyPatch(typeof(FinalCyberRank))]
public static class LocalizeFinalCyberRank
{
    private static MethodInfo localizemethod = AccessTools.Method(
        typeof(LocalizeFinalCyberRank),
        nameof(LocalizeFinalCyberRank.LocalizeP)
    );

    [HarmonyPatch(nameof(FinalCyberRank.PointsShow))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> PointShowPatch(IEnumerable<CodeInstruction> instructions)
    {
        var matcher = new CodeMatcher(instructions);

        while (true)
        {
            matcher.MatchForward(false, new CodeMatch(OpCodes.Ldstr, "<color=orange>P</color>"));

            if (matcher.IsInvalid)
                break;

            matcher.Advance(1);
            matcher.Insert(new CodeInstruction(OpCodes.Call, localizemethod));
        }

        return matcher.InstructionEnumeration();
    }

    [HarmonyPatch(nameof(FinalCyberRank.Update))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> UpdatePatch(IEnumerable<CodeInstruction> instructions)
    {
        var matcher = new CodeMatcher(instructions);

        while (true)
        {
            matcher.MatchForward(false, new CodeMatch(OpCodes.Ldstr, "<color=orange>P</color>"));

            if (matcher.IsInvalid)
                break;

            matcher.Advance(1);
            matcher.Insert(new CodeInstruction(OpCodes.Call, localizemethod));
        }

        return matcher.InstructionEnumeration();
    }

    public static string LocalizeP(string P)
    {
        return (
            "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_moneyCount + "</color>"
        ).Or(P);
    }
}
