using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace UltrakULL.Harmony_Patches;

[NeedDebugMode]
[HarmonyPatch(typeof(StyleHUD))]
public static class LocalizeStyleHud
{
    [HarmonyPatch(nameof(StyleHUD.GetLocalizedName))] [HarmonyPrefix]
    public static bool GetLocalizedName_MyPatch(string id, StyleHUD __instance, Dictionary<string, string> ___idNameDict, ref string __result)
    {
        if (LanguageManager.IsEnglish)
            return true;

        string result = StyleBonusStrings.GetLocalizedStyle(id, ___idNameDict.ContainsKey(id));
        if (result == null)
            return true;

        __result = result;
        return false;
    }

    [HarmonyPatch(nameof(StyleHUD.UpdateFreshnessSlider))] [HarmonyPrefix]
    public static bool UpdateFreshnessSlider_MyPatch(StyleHUD __instance, GunControl ___gc)
    {
        StyleFreshnessState freshnessState = __instance.GetFreshnessState(___gc.currentWeapon);
        __instance.freshnessSliderText.text = StyleBonusStrings.GetWeaponFreshness(freshnessState);

        return false;
    }
}


/*
	[HarmonyPatch(typeof(StyleHUD), "Awake")]
	public static class StyleHUD_AwakePatch
	{
		static bool patched = false;
    [HarmonyPrefix]
    public static void Prefix(StyleHUD __instance)
    {
			if (!LanguageManager.IsRightToLeft && LanguageManager.CurrentLanguage.metadata.langName != "Arabic") return;

        try
        {
            for (int i = 0; i < 8; i++)
            {
                __instance.ranks[i].sprite = FontManager.CustomRankImages[i];
            }
        }
        catch(Exception e)
			{
				Logging.Message($"Exception thrown in StyleHUD_AwakePatch: {e.Message}");
			}
    }
	}
*/
