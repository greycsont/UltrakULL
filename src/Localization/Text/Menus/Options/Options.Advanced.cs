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

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptions, "Title")),
            new[] { opt.advanced_title }, "--" + opt.advanced_title + "--");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptions, "Close", "Text")), opt.steamLeaderboard_returnButton);

        //Cybergrind Reset Confirm
        GameObject cybergrindResetPanel = FindDescendant(advancedOptions, "Reset Cyber Grind Dialog", "Panel");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Text (2)")), opt.advanced_cybergrindResetText1);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Text (1)")), opt.advanced_cybergrindResetText2);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Cancel", "Text")), opt.advanced_cybergrindResetCancel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Confirm", "Text")), opt.advanced_cybergrindResetConfirm);

        //The Actual Options
        GameObject advancedOptionsSub = FindDescendant(advancedOptions, "Scroll View", "Viewport", "Content");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Cyber Grind Category")), LanguageManager.CurrentLanguage.levelNames.levelName_cybergrind);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Cyber Grind Options", "Local High Scores", "Text")), opt.advanced_cybergrindLocalHighScore);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Cyber Grind Options", "Local High Scores", "Reset", "Text")), opt.advanced_cybergrindResetButton);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Steam Category")), opt.advanced_steam);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Leaderboards", "Leaderboards", "Text")), opt.advanced_steamLeaderboardManage);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Leaderboards", "Leaderboards", "Manage Button", "Text")), opt.advanced_steamLeaderboardManageButton);

        //"Current" indicator and the level titles
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Level 5-2 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Level 5-2 Category")), opt.advanced_level52);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-1 Options", "Level 7-1 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-1 Options", "Level 7-1 Category")), opt.advanced_level71);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-3 Options", "Level 7-3 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-3 Options", "Level 7-3 Category")), opt.advanced_level73);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Level 8-4 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Level 8-4 Category")), opt.advanced_level84);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-S Options", "Level 7-S Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-S Options", "Level 7-S Category")), opt.advanced_level7S);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "P-2 Options", "Level P-2 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "P-2 Options", "Level P-2 Category")), opt.advanced_levelP2);

        //Levels
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Disable Water Scrolling", "Text")), opt.advanced_52WaterScrolling);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Disable Water Waves", "Text")), opt.advanced_52WaterWaves);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-1 Options", "Local High Scores", "Text")), opt.advanced_71Dark);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-3 Options", "Local High Scores", "Text")), opt.advanced_73Grass);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Local High Scores (1)", "Text")), opt.advanced_84DisableArenaScrolling);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Local High Scores", "Text")), opt.advanced_84DisableArenaRotation);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-S Options", "Local High Scores", "Text")), opt.advanced_7SHard);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "P-2 Options", "Local High Scores", "Text")), opt.advanced_P2DisableTunnelScrolling);
        
    }
}
