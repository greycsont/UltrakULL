using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;


//@Override
//Overrides the Toggle function from the CustomPatterns class for the toggle text.
[PrefixRewrite]
[HarmonyPatch(typeof(CustomPatterns))]
public static class LocalizeCustomPatternToggle
{
    [HarmonyPatch(nameof(CustomPatterns.Toggle))] [HarmonyPostfix]
    public static void Toggle_MyPatch(CustomPatterns __instance)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }

        __instance.stateButtonText.text = MonoSingleton<EndlessGrid>.Instance.customPatternMode 
            ? LanguageManager.CurrentLanguage.misc.state_deactivated : LanguageManager.CurrentLanguage.misc.state_activated;

    }
}
