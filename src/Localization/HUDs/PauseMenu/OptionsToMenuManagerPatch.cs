using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(OptionsMenuToManager))]
public static class OptionsToMenuManagerPatch
{
    [HarmonyPatch(nameof(OptionsMenuToManager.SetPauseMenu))] [HarmonyPostfix]
    public static void LocalizePauseMenu(OptionsMenuToManager __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        PauseMenuLocalizer.LocalizeAll(__instance);
    }
}
