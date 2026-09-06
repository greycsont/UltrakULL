using HarmonyLib;
using AngryLevelLoader.Fields;
using UltrakULL.json;

namespace UltrakULL;


[HarmonyPatch(typeof(ConfigPanelForBundles))]
public static class ConfigPanelForBundlesPatch
{
    [HarmonyPatch(nameof(ConfigPanelForBundles.CreateUI))] [HarmonyPostfix]
    public static void LocalizeOpenButton(ConfigPanelForBundles __instance)
    {
        var open = LanguageManager.Current?.angry?.rootPanel?.open;

        __instance.buttonText = open;
    }
}
