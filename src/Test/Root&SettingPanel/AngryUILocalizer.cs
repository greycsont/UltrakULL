using System;
using System.Collections.Generic;
using System.Linq;
using AngryLevelLoader.Managers;
using AngryLevelLoader.UserInterface;
using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Functionals;
using HarmonyLib;
using UltrakULL.json;


using cm = AngryLevelLoader.Managers.ConfigManager;

namespace UltrakULL;

[HarmonyPatch(typeof(ConfigManager))]
public static class ConfigManagerPatch
{
    [HarmonyPatch(nameof(ConfigManager.InitializeConfig))] [HarmonyPostfix]
    public static void LocalizeMainAndSettingPanel()
    {
        if (LanguageManager.IsEnglish) return;
        AngryUILocalizer.Localize();
    }
}

public static class AngryUILocalizer
{
    public static AngryLevelSettingTranslation angry => LanguageManager.Current.angry;
    private static (string original, string translation)[] HeaderPairs(AngryLevelSettingTranslation angry)
    {
        var h = angry.headers;
        return new[]
        {
            ("User Interface", h.userInterface),
            ("Leaderboards", h.leaderboards),
            ("Online", h.online),
            ("Scripts", h.scripts),
            ("Compatibility", h.compatibility),
            ("Danger Zone", h.dangerZone),
            ("Difficulty is overridden by gamemode\nWarning: Some levels may not be compatible with gamemodes",
             h.difficultyOverrideWarning),
        };
    }

    public static void Localize()
    {
        var angry = LanguageManager.Current?.angry;
        if (angry == null)
            return;

        LocalizeRootPanel(angry);
        LocalizeSettingPanel(angry);
    }

    public static void LocalizeRootPanel(AngryLevelSettingTranslation angry)
    {
        var root = angry.rootPanel;

        cm.config.rootPanel.onPannelOpenEvent += _ =>
        {
            LocalizeNewLevel.LocalizeNewLevelLine();
        };

        OnlineLevelsList.onlineLevelsPanel.displayName = root.onlineLevels;       // "Online Levels"
        OnlineLevelsList.onlineLevelsPanel.headerText = root.onlineLevelsHeader;
        OnlineLevelsList.onlineLevelsPanel.buttonText = root.open;
        cm.bannedModsPanel.displayName = root.leaderboardBannedMods;              // "Leaderboard banned mods"
        cm.pendingRecords.displayName = root.pendingRecords;                      // "Pending records"
        cm.sendPendingRecords.displayName = root.sendPendingRecords;              // "Send Pending Records"
        cm.changelogButton.displayName = root.changelog;                          // "Changelog"

        (cm.config.rootPanel["settingsAndReload"] as ButtonArrayField)?.SetButtonText(0, root.settings); // "Settings"
        (cm.config.rootPanel["settingsAndReload"] as ButtonArrayField)?.SetButtonText(1, root.scanForLevels); // "Scan For Levels"

        cm.reportsButton.displayName = root.viewReports;                          // "View Reports"

        cm.levelBundlesHeader.displayName = root.levelBundles;
    }

    public static void LocalizeSettingPanel(AngryLevelSettingTranslation angry)
    {
        var s = angry.settingPanel;

        cm.openButtons.SetButtonText(0, s.openLevelsFolder);   // "Open Levels Folder"
        cm.openButtons.SetButtonText(1, s.openScriptsFolder);  // "Open Scripts Folder"
        cm.reloadFileKeybind.displayName = s.reloadFile;       // "Reload File"
        cm.reloadScriptKeybind.displayName = s.reloadScript;   // "Reload Script"
        cm.filterMode.displayName = s.unityLogLevel;           // "Unity log level"

        // When you set it to top, it doesn't work since revamp i think?
        cm.customLevelButtonPosition.displayName = s.customLevelButtonPosition;          // "Custom level button position"
        cm.customLevelButtonFrameColor.displayName = s.customLevelButtonFrameColor;      // "Custom level button frame color"
        cm.customLevelButtonTextColor.displayName = s.customLevelButtonTextColor;        // "Custom level button text color"
        cm.showLeaderboardOnLevelEnd.displayName = s.showLeaderboardOnLevelEnd;          // "Show leaderboard on level end"
        cm.showLeaderboardOnSecretLevelEnd.displayName = s.showLeaderboardOnSecretLevelEnd; // "Show leaderboard on secret level end"
        cm.defaultLeaderboardCategory.displayName = s.defaultLeaderboardCategory;        // "Default leaderboard category"
        cm.defaultLeaderboardDifficulty.displayName = s.defaultLeaderboardDifficulty;    // "Default leaderboard difficulty"
        cm.defaultLeaderboardFilter.displayName = s.defaultLeaderboardFilter;            // "Default leaderboard filter"
        cm.refreshCatalogOnBoot.displayName = s.refreshCatalogOnBoot;                    // "Refresh online catalog on boot"
        cm.useDevelopmentBranch.displayName = s.useDevelopmentBranch;                    // "Use development chanel"
        cm.useLocalServer.displayName = s.useLocalServer;                                // "Use local server"
        cm.levelUpdateNotifierToggle.displayName = s.levelUpdateNotifier;                // "Notify on level updates"
        cm.levelUpdateIgnoreCustomBuilds.displayName = s.levelUpdateIgnoreCustomBuilds;  // "Ignore updates for custom build"
        cm.newLevelNotifierToggle.displayName = s.newLevelNotifierToggle;                // "Notify on new level release"
        cm.scriptUpdateIgnoreCustom.displayName = s.scriptUpdateIgnoreCustomBuilds;      // "Ignore updates for custom builds"
        cm.scriptCertificateIgnoreField.displayName = s.scriptCertificateIgnore;         // "Certificate ignore"
        cm.reloadAlwaysGoToMainMenu.displayName = s.reloadAlwaysGoToMainMenu;            // "Quick reload in main menu"
        cm.bundleFavSort.displayName = s.bundleFavSort;                                  // "Sort by fav"
        cm.bundleSortingMode.displayName = s.bundleSortingMode;                          // "Bundle sorting"
        InternalConfigManager.leaderboardToggle.displayName = s.leaderboardToggle;       // "Post records to leaderboards"

        var settings = InternalConfigManager.internalConfig?.rootPanel?["p_settings"] as ConfigPanel;

        settings.headerText = s.settingsHeader;                                     // "--Settings--"
        settings["customLevelButtonPanel"].displayName = s.customLevelButtonColors; // panel "Custom level button colors"
        settings["s_dataPathInput"].displayName = s.dataPath;                       // "Data Path"
        settings["s_changeDataPath"].displayName = s.moveData;                      // "Move Data"
        settings["s_deleteOldBundles"].displayName = s.deleteOldBundles;            // "Delete Old Bundles"


        AngryUtil.ApplyHeaders(settings, HeaderPairs(angry));
    }
}
