using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(Sandbox.SandboxAlterMenu))]
public static class SandboxAlterMenuPatch
{
    [HarmonyPatch(nameof(Sandbox.SandboxAlterMenu.Awake))] [HarmonyPostfix]
    public static void LocalizeSandboxAlterMenu(Sandbox.SandboxAlterMenu __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        SandboxLocalizer.PatchAlterMenu(__instance.gameObject);
    }
}
