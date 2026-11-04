using HarmonyLib;

namespace UltrakULL;

[HarmonyPatch(typeof(OptionsMenuToManager))]
public static class OptionsToMenuManagerPatch
{
    [HarmonyPatch(nameof(OptionsMenuToManager.SetPauseMenu))] [HarmonyPostfix]
    public static void LocalizePauseMenu(OptionsMenuToManager __instance)
    {
        PauseMenuLocalizer.LocalizeAll(__instance);
    }
}
