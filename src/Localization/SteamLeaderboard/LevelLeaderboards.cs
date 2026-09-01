using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

// Main menu
[HarmonyPatch(typeof(LevelSelectLeaderboard))]
public class LocalizeLevelSelectLeaderboard
{
    [HarmonyPatch(nameof(LevelSelectLeaderboard.OnEnable))] [HarmonyPostfix]
    public static void LevelLeaderboardPatch_Postfix(LevelSelectLeaderboard __instance)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }
        LeaderboardProperties.Difficulties[0] = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
        LeaderboardProperties.Difficulties[1] =  LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
        LeaderboardProperties.Difficulties[2] =  LanguageManager.CurrentLanguage.frontend.difficulty_standard;
        LeaderboardProperties.Difficulties[3] =  LanguageManager.CurrentLanguage.frontend.difficulty_violent;
        LeaderboardProperties.Difficulties[4] =  LanguageManager.CurrentLanguage.frontend.difficulty_brutal;
        //not yet
        //LeaderboardProperties.Difficulties[5] = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

        __instance.anyPercentLabel.text = LanguageManager.CurrentLanguage.frontend.leaderboard_anyPercent;
        __instance.pRankLabel.text = LanguageManager.CurrentLanguage.frontend.leaderboard_pPercent;

        Text noItems = GetTextfromGameObject(FindDescendant(__instance.noItemsPanel,"Text"));
        noItems.text = LanguageManager.CurrentLanguage.frontend.leaderboard_noEntries;

    }
}

// End menu
[HarmonyPatch(typeof(LevelEndLeaderboard))]
public static class LocalizeLevelEndLeaderboard
{
        
    [HarmonyPatch(nameof(LevelEndLeaderboard.Update))] [HarmonyPostfix]
    public static void LevelLeaderboardEndPatch_Postfix(LevelEndLeaderboard __instance)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }
        __instance.leaderboardType.text = __instance.displayPRank ? LanguageManager.CurrentLanguage.frontend.leaderboard_pPercent : LanguageManager.CurrentLanguage.frontend.leaderboard_anyPercent;
        
        TextMeshProUGUI connecting = GetTextMeshProUGUI(__instance.loadingPanel);
        connecting.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;

        TextMeshProUGUI reminder = GetTextMeshProUGUI(FindDescendant(__instance.loadingPanel.transform.parent.gameObject, "SettingsReminder"));
        reminder.text = LanguageManager.CurrentLanguage.frontend.leaderboard_reminder;
    }
}