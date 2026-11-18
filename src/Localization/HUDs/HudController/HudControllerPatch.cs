using HarmonyLib;
using TMPro;

using UltrakULL.json;

namespace UltrakULL;


/// <summary>
/// This patch is for the classic HUD's text elements
/// </summary>
[HarmonyPatch(typeof(HudController))]
public static class HudControllerPatch
{
    [HarmonyPatch(nameof(HudController.CheckSituation))] [HarmonyPrefix]
    public static void CheckSituationPatch(HudController __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        if (__instance.altHud == false)
            return;

        var hudType = PrefsManager.Instance.GetInt("hudType");

        var hudControllerObj = __instance.gameObject;

        if (hudType == 2 && __instance.colorless == false)
        {
            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_health,
                path: ["Filler", "Health", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_stamina,
                path: ["Filler", "Stamina", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_weapon,
                path: ["Filler", "Weapon", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_arm,
                path: ["Filler", "Arm", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter,
                path: ["Filler", "RailcannonMeter (1)", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_speed,
                path: ["Filler", "Speedometer", "Title"]);

        }
        else if (hudType == 3 && __instance.colorless == true)
        {
            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_health,
                path: ["Filler", "Health (1)", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_stamina,
                path: ["Filler", "Stamina (1)", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_weapon,
                path: ["Filler", "Weapon (1)", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_arm,
                path: ["Filler", "Arm (1)", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter,
                path: ["Filler", "RailcannonMeter (2)", "Title"]);

            hudControllerObj.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.classicHud_speed,
                path: ["Filler", "Speedometer", "Title"]);
        }
    }
    
}