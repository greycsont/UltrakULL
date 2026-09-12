using System.Reflection;
using System.Collections.Generic;
using System.Reflection.Emit;
using AngryLevelLoader.Managers;
using AngryLevelLoader.UserInterface;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER, "AngryLevelLoader.Plugin", "ScanForLevels")]
[HarmonyPatch(typeof(AngryBundleList))]
public static class AngryBundleListPatch
{
    public static MethodInfo fp_LocalizeLevelBundleHeaderAndSearchInfo = AccessTools.Method(
        typeof(AngryBundleListPatch),
        nameof(AngryBundleListPatch.LocalizeLevelBundleHeaderAndSearchInfo)
    );

    [HarmonyPatch(nameof(AngryBundleList.UpdateBundleSearch))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> LocalizeSearchInfoAndLevelBundles(IEnumerable<CodeInstruction> instructions)
    {
        var codeMatcher = new CodeMatcher(instructions);

        return codeMatcher
        .End()
        .MatchEndBackwards(
            new CodeMatch(i => i.opcode == OpCodes.Ret)
        )
        .Insert(
            new CodeInstruction(OpCodes.Ldloc_1),
            new CodeInstruction(OpCodes.Ldloc_2),
            new CodeInstruction(OpCodes.Call, fp_LocalizeLevelBundleHeaderAndSearchInfo))
        .InstructionEnumeration();
    }

    public static void LocalizeLevelBundleHeaderAndSearchInfo(int filterCount, int totalCount)
    {
        var angry = LanguageManager.Current.angry;
        ConfigManager.levelBundlesHeader.text = angry.rootPanel.levelBundles.Or(ConfigManager.levelBundlesHeader.text);
		ConfigManager.searchInfo.text = string.Format(angry.onlineSearchInfo.Or("Showing {0} of {1} bundles"), filterCount, totalCount);
    }


    [HarmonyPatch(nameof(AngryBundleList.DisplayFolder))] [HarmonyPostfix]
    public static void LocalizeDisplayedFolder()
    {
        if (LanguageManager.IsEnglish) return;

        var folder = AngryBundleList.displayedFolder;
        string header = LanguageManager.Current.angry.rootPanel.levelBundles;

        if (folder == AngryBundleList.rootFolder)
            ConfigManager.levelBundlesHeader.text = header;
        else
            ConfigManager.levelBundlesHeader.text = $"{header} <color=grey>{folder.GetRelativeFolderPath()}</color>";
    }
}