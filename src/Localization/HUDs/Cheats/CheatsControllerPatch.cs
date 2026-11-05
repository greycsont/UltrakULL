using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(CheatsController))]
public static class CheatsControllerPatch
{
    [HarmonyPatch(nameof(CheatsController.Start))] [HarmonyPostfix]
    public static void LocalizeCheatsConsent(CheatsController __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        Cheats.LocalizeCheatConsentPanel(__instance.consentScreen);
        Cheats.LocalizeCheatEnabledPanel(__instance.cheatsEnabledPanel);
    }
}
