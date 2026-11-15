using HarmonyLib;
using TMPro;
using UnityEngine;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(StyleCalculator))]
public static class StyleCalculatorPatch
{
    [HarmonyPatch(nameof(StyleCalculator.Start))] [HarmonyPostfix]
    public static void StartPatch(StyleCalculator __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        __instance.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.style.stylemeter_multiplier,
            path: ["Panel (1)", "Panel", "Text (1)", "Text"]);
    }

}