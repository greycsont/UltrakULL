using HarmonyLib;
using AngryLevelLoader.Fields;
using AngryLevelLoader.Containers;
using UltrakULL.json;
using PluginConfig.API.Functionals;
using AngryLevelLoader.DataTypes;

namespace UltrakULL;

[HarmonyPatch(typeof(BundleContainer))]
public static class BundleContainerPatch
{
    [HarmonyPatch(methodType:MethodType.Constructor, new[] {typeof(string), typeof(AngryBundleData)})] [HarmonyPostfix]
    public static void LocalizeBundleContainer(BundleContainer __instance)
    {
        var level = LanguageManager.Current.angry.bundlePanel;
        (__instance.rootPanel[__instance.rootPanel.guid + "_reloadButtons"] as ButtonArrayField)?.SetButtonText(0, level.reloadFile);
        (__instance.rootPanel[__instance.rootPanel.guid + "_reloadButtons"] as ButtonArrayField)?.SetButtonText(1, level.forceReloadFile);

        AngryUtil.ApplyHeaders(__instance.rootPanel, new [] {(original: "Levels", translation: level.levels)});
    }
}
