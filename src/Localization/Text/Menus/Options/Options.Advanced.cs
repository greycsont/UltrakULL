using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{

    private static void PatchAdvancedOptions(GameObject optionMenu)
    {
        var opt = LanguageManager.CurrentLanguage.options;
        GameObject advancedOptions = optionMenu;

        advancedOptions.Localize<TextMeshProUGUI>("--{0}--".FormatWith(opt.advanced_title), "Title");
        advancedOptions.Localize<TextMeshProUGUI>(opt.steamLeaderboard_returnButton, "Close", "Text");

        //Cybergrind Reset Confirm
        GameObject cybergrindResetPanel = FindDescendant(advancedOptions, "Reset Cyber Grind Dialog", "Panel");
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetText1, "Text (2)");
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetText2, "Text (1)");
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetCancel, "Cancel", "Text");
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetConfirm, "Confirm", "Text");

        //The Actual Options
        GameObject advancedOptionsSub = FindDescendant(advancedOptions, "Scroll View", "Viewport", "Content");

        advancedOptionsSub.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.levelNames.levelName_cybergrind, "Cyber Grind Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_cybergrindLocalHighScore, "Cyber Grind Options", "Local High Scores", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetButton, "Cyber Grind Options", "Local High Scores", "Reset", "Text");

        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_steam, "Steam Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_steamLeaderboardManage, "Leaderboards", "Leaderboards", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_steamLeaderboardManageButton, "Leaderboards", "Leaderboards", "Manage Button", "Text");

        //"Current" indicator and the level titles
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, "5-2 Options", "Level 5-2 Category", "Current Level Indicator");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level52, "5-2 Options", "Level 5-2 Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, "7-1 Options", "Level 7-1 Category", "Current Level Indicator");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level71, "7-1 Options", "Level 7-1 Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, "7-3 Options", "Level 7-3 Category", "Current Level Indicator");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level73, "7-3 Options", "Level 7-3 Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, "8-4 Options", "Level 8-4 Category", "Current Level Indicator");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level84, "8-4 Options", "Level 8-4 Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, "7-S Options", "Level 7-S Category", "Current Level Indicator");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level7S, "7-S Options", "Level 7-S Category");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, "P-2 Options", "Level P-2 Category", "Current Level Indicator");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_levelP2, "P-2 Options", "Level P-2 Category");

        //Levels
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_52WaterScrolling, "5-2 Options", "Disable Water Scrolling", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_52WaterWaves, "5-2 Options", "Disable Water Waves", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_71Dark, "7-1 Options", "Local High Scores", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_73Grass, "7-3 Options", "Local High Scores", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_84DisableArenaScrolling, "8-4 Options", "Local High Scores (1)", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_84DisableArenaRotation, "8-4 Options", "Local High Scores", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_7SHard, "7-S Options", "Local High Scores", "Text");
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_P2DisableTunnelScrolling, "P-2 Options", "Local High Scores", "Text");
        
    }
}
