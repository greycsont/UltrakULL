using System;
using System.Collections.Generic;
using System.Linq;
using AngryLevelLoader.Managers;
using AngryLevelLoader.UserInterface;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(OnlineLevelsList))]
public static class CheckNewLevelUpdatePatch
{
    [HarmonyPatch(nameof(OnlineLevelsList.CheckLevelUpdateText))] [HarmonyPostfix]
    public static void LocalizeNewLevelUpdatePanel()
    {
        if (LanguageManager.IsEnglish) return;
        LocalizeUpdateAvailable.LocalizeLevelUpdateLine();
    }
}

public static class LocalizeUpdateAvailable
{
    public static void LocalizeLevelUpdateLine()
    {
        AngryUtil.LocalizeNotifierHeader(ConfigManager.levelUpdateNotifier,
            "<color=#00FFFF>", "Update available for ", LanguageManager.Current.angry.rootPanel.newUpdateNotifier);
    }

}