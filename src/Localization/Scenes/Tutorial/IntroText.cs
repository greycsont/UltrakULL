using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.json.LanguageManager;
using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

//@Override
//Overrides the Start function from IntroText. This is needed for patched text to appear on the tutorial.
[HarmonyPatch(typeof(IntroText))]
public static class LocalizeIntroText
{
    public static MethodInfo LocalizeCalibrationStatusTextMethodInfo = AccessTools.Method(
        typeof(LocalizeIntroText),
        nameof(LocalizeIntroText.LocalizeCalibrationStatusText)
    );

    [HarmonyPatch(nameof(IntroText.Start))] [HarmonyPrefix]
    public static bool IntroTextStart_MyPatch(IntroText __instance, TMP_Text ___txt, string ___fullString)
    {
        if (LanguageManager.IsEnglish)
        {
            return true;
        }
        GameObject canvasObj = GetInactiveRootObject("Canvas");
        ___txt = __instance.GetComponent<TMP_Text>();

        TutorialStrings tutStrings = new TutorialStrings(canvasObj);
        ___fullString = ___txt.text;

        if (___fullString[0] == 'B') { ___fullString = tutStrings.IntroFirstPage; }
        else { ___fullString = tutStrings.IntroSecondPage; }
        ___txt.text = ___fullString;

        return true;
    }

    [HarmonyPatch(nameof(IntroText.TextAppear), MethodType.Enumerator)] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> TextAppearTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        var matcher = new CodeMatcher(instructions);
        return matcher.MatchForward(false, 
            new CodeMatch(i => i.opcode == OpCodes.Ldstr 
            && (string)i.operand == "<color=red>ERROR</color>")
        )
        .Advance(1)
        .Insert(new CodeInstruction(OpCodes.Call, LocalizeCalibrationStatusTextMethodInfo))
        .MatchForward(false,
            new CodeMatch(i => i.opcode == OpCodes.Ldstr
            && (string)i.operand == "<color=green>OK</color>")
        )
        .Advance(1)
        .Insert(new CodeInstruction(OpCodes.Call, LocalizeCalibrationStatusTextMethodInfo))
        .InstructionEnumeration();
    }

    public static string LocalizeCalibrationStatusText(string input)
    {
        if (LanguageManager.IsEnglish) return input;
        
        var localizedStatus = input switch
        {
            "<color=red>ERROR</color>" => "<color=red>" + CurrentLanguage.tutorial.tutorial_calibrationError + "</color>",
            "<color=green>OK</color>" => "<color=green>" + CurrentLanguage.tutorial.tutorial_calibrationOk + "</color>",
            _ => input
        };

        return localizedStatus.Or(input);
    }
}
