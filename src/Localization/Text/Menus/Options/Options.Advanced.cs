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

        advancedOptions.Localize<TextMeshProUGUI>("--{0}--".FormatWith(opt.advanced_title), path: ["Title"]);
        advancedOptions.Localize<TextMeshProUGUI>(opt.steamLeaderboard_returnButton, path: ["Close", "Text"]);

        //Cybergrind Reset Confirm
        GameObject cybergrindResetPanel = FindDescendant(advancedOptions, "Reset Cyber Grind Dialog", "Panel");
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetText1, path: ["Text (2)"]);
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetText2, path: ["Text (1)"]);
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetCancel, path: ["Cancel", "Text"]);
        cybergrindResetPanel.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetConfirm, path: ["Confirm", "Text"]);

        //The Actual Options
        GameObject advancedOptionsSub = FindDescendant(advancedOptions, "Scroll View", "Viewport", "Content");

        advancedOptionsSub.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.levelNames.levelName_cybergrind, path: ["Cyber Grind Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_cybergrindLocalHighScore, path: ["Cyber Grind Options", "Local High Scores", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_cybergrindResetButton, path: ["Cyber Grind Options", "Local High Scores", "Reset", "Text"]);

        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_steam, path: ["Steam Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_steamLeaderboardManage, path: ["Leaderboards", "Leaderboards", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_steamLeaderboardManageButton, path: ["Leaderboards", "Leaderboards", "Manage Button", "Text"]);

        //"Current" indicator and the level titles
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, path: ["5-2 Options", "Level 5-2 Category", "Current Level Indicator"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level52, path: ["5-2 Options", "Level 5-2 Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, path: ["7-1 Options", "Level 7-1 Category", "Current Level Indicator"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level71, path: ["7-1 Options", "Level 7-1 Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, path: ["7-3 Options", "Level 7-3 Category", "Current Level Indicator"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level73, path: ["7-3 Options", "Level 7-3 Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, path: ["8-4 Options", "Level 8-4 Category", "Current Level Indicator"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level84, path: ["8-4 Options", "Level 8-4 Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, path: ["7-S Options", "Level 7-S Category", "Current Level Indicator"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_level7S, path: ["7-S Options", "Level 7-S Category"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_currentLevel, path: ["P-2 Options", "Level P-2 Category", "Current Level Indicator"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_levelP2, path: ["P-2 Options", "Level P-2 Category"]);

        //Levels
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_52WaterScrolling, path: ["5-2 Options", "Disable Water Scrolling", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_52WaterWaves, path: ["5-2 Options", "Disable Water Waves", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_71Dark, path: ["7-1 Options", "Local High Scores", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_73Grass, path: ["7-3 Options", "Local High Scores", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_84DisableArenaScrolling, path: ["8-4 Options", "Local High Scores (1)", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_84DisableArenaRotation, path: ["8-4 Options", "Local High Scores", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_7SHard, path: ["7-S Options", "Local High Scores", "Text"]);
        advancedOptionsSub.Localize<TextMeshProUGUI>(opt.advanced_P2DisableTunnelScrolling, path: ["P-2 Options", "Local High Scores", "Text"]);
        
    }
}
