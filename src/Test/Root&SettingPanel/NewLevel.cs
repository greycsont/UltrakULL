using System;
using System.Collections.Generic;
using System.Linq;
using AngryLevelLoader.Managers;
using AngryLevelLoader.UserInterface;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL;


[HarmonyPatch(typeof(OnlineLevelsList))]
public static class CheckNewLevelTextPatch
{
    [HarmonyPatch(nameof(OnlineLevelsList.CheckNewLevelText))] [HarmonyPostfix]
    public static void LocalizeNewLevelTextPanel()
    {
        if (LanguageManager.IsEnglish) return;
        LocalizeNewLevel.LocalizeNewLevelLine();
    }
}

public static class LocalizeNewLevel
{
    public static void LocalizeNewLevelLine()
    {
        AngryUtil.LocalizeNotifierHeader(ConfigManager.newLevelNotifier,
            "<color=#00FF00>", "New level: ", LanguageManager.Current.angry.rootPanel.newLevelNotifier);
    }
}
