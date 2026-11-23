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
//This only patches the ERROR and OK in the intro.
[HarmonyPatch(typeof(IntroText))]
public static class IntroTextPatch
{
    public static MethodInfo LocalizeCalibrationStatusTextMethodInfo = AccessTools.Method(
        typeof(IntroTextPatch),
        nameof(IntroTextPatch.LocalizeCalibrationStatusText)
    );

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
