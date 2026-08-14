using HarmonyLib;

using GameSettingsMenu = SettingsMenu.Components.SettingsMenu;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(GameSettingsMenu))]
internal static class LanguageOptionsPatch
{
    [HarmonyPatch(nameof(GameSettingsMenu.Initialize))] [HarmonyPrefix]
    private static void BeforeInitialize(GameSettingsMenu __instance)
    {
        LanguageOptions.Initialize(__instance);
    }
}
