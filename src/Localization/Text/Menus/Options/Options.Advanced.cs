using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.TextReplacer;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{

    private static void PatchAdvancedOptions(GameObject optionMenu)
    {
        var opt = LanguageManager.CurrentLanguage.options;
        GameObject advancedOptions = optionMenu;

        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("--{0}--", opt.advanced_title), advancedOptions, "Title");
        TryReplaceText<TextMeshProUGUI>(opt.steamLeaderboard_returnButton, advancedOptions, "Close", "Text");

        //Cybergrind Reset Confirm
        GameObject cybergrindResetPanel = FindDescendant(advancedOptions, "Reset Cyber Grind Dialog", "Panel");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_cybergrindResetText1, cybergrindResetPanel, "Text (2)");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_cybergrindResetText2, cybergrindResetPanel, "Text (1)");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_cybergrindResetCancel, cybergrindResetPanel, "Cancel", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_cybergrindResetConfirm, cybergrindResetPanel, "Confirm", "Text");

        //The Actual Options
        GameObject advancedOptionsSub = FindDescendant(advancedOptions, "Scroll View", "Viewport", "Content");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.levelNames.levelName_cybergrind, advancedOptionsSub, "Cyber Grind Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_cybergrindLocalHighScore, advancedOptionsSub, "Cyber Grind Options", "Local High Scores", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_cybergrindResetButton, advancedOptionsSub, "Cyber Grind Options", "Local High Scores", "Reset", "Text");

        TryReplaceText<TextMeshProUGUI>(opt.advanced_steam, advancedOptionsSub, "Steam Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_steamLeaderboardManage, advancedOptionsSub, "Leaderboards", "Leaderboards", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_steamLeaderboardManageButton, advancedOptionsSub, "Leaderboards", "Leaderboards", "Manage Button", "Text");

        //"Current" indicator and the level titles
        TryReplaceText<TextMeshProUGUI>(opt.advanced_currentLevel, advancedOptionsSub, "5-2 Options", "Level 5-2 Category", "Current Level Indicator");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_level52, advancedOptionsSub, "5-2 Options", "Level 5-2 Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_currentLevel, advancedOptionsSub, "7-1 Options", "Level 7-1 Category", "Current Level Indicator");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_level71, advancedOptionsSub, "7-1 Options", "Level 7-1 Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_currentLevel, advancedOptionsSub, "7-3 Options", "Level 7-3 Category", "Current Level Indicator");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_level73, advancedOptionsSub, "7-3 Options", "Level 7-3 Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_currentLevel, advancedOptionsSub, "8-4 Options", "Level 8-4 Category", "Current Level Indicator");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_level84, advancedOptionsSub, "8-4 Options", "Level 8-4 Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_currentLevel, advancedOptionsSub, "7-S Options", "Level 7-S Category", "Current Level Indicator");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_level7S, advancedOptionsSub, "7-S Options", "Level 7-S Category");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_currentLevel, advancedOptionsSub, "P-2 Options", "Level P-2 Category", "Current Level Indicator");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_levelP2, advancedOptionsSub, "P-2 Options", "Level P-2 Category");

        //Levels
        TryReplaceText<TextMeshProUGUI>(opt.advanced_52WaterScrolling, advancedOptionsSub, "5-2 Options", "Disable Water Scrolling", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_52WaterWaves, advancedOptionsSub, "5-2 Options", "Disable Water Waves", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_71Dark, advancedOptionsSub, "7-1 Options", "Local High Scores", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_73Grass, advancedOptionsSub, "7-3 Options", "Local High Scores", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_84DisableArenaScrolling, advancedOptionsSub, "8-4 Options", "Local High Scores (1)", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_84DisableArenaRotation, advancedOptionsSub, "8-4 Options", "Local High Scores", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_7SHard, advancedOptionsSub, "7-S Options", "Local High Scores", "Text");
        TryReplaceText<TextMeshProUGUI>(opt.advanced_P2DisableTunnelScrolling, advancedOptionsSub, "P-2 Options", "Local High Scores", "Text");
        
    }
}
