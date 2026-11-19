using HarmonyLib;

namespace UltrakULL;

[HarmonyPatch(typeof(SettingsMenu.Components.SettingsMenu))]
public static class SettingsMenuPatch
{
    [HarmonyPatch(nameof(SettingsMenu.Components.SettingsMenu.Initialize))] [HarmonyPostfix]
    public static void InitializePostfix(SettingsMenu.Components.SettingsMenu __instance)
    {
        Options.PatchOptions(__instance.gameObject);
    }
}