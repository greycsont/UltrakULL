public class AngryLevelSettingTranslation
{
    public RootPanel rootPanel;
    public SettingPanel settingPanel;
    public Category category;
    public SortingOption sortingOption;
    public BundleStatus bundleStatus;
    public LevelPanel levelPanel;
    public OnlineLevel onlineLevel;
    public string onlineSearchInfo; // "Showing {0} of {1} bundles"
}

// config.rootPanel
public class RootPanel
{
    public string onlineLevels;        // "Online Levels"
    public string onlineLevelsHeader;  // "--Online Levels--"
    public string open;                // "Open"
    public string leaderboardBannedMods; // "Leaderboard banned mods"
    public string pendingRecords;      // "Pending records"
    public string sendPendingRecords;  // "Send Pending Records"
    public string gamemode;  // "GAMEMODE"
    public string difficultyOverrideWarning; // "Difficulty is overridden by gamemode\nWarning: ..."
    public string settings;            // "Settings"
    public string scanForLevels;       // "Scan For Levels"
    public string viewReports;         // "View Reports"
    public string levelBundles;        // "Level Bundles"
    public string newLevelNotifier;    // "New level: {0}"
    public string newUpdateNotifier;   // "Update Available for {0}"
}

// p_settings
public class SettingPanel
{    
    public string settingsHeader;          // "--Settings--"
    public string changelog;           // "Changelog"
    public string openLevelsFolder;      // "Open Levels Folder"
    public string openScriptsFolder;     // "Open Scripts Folder"
    public string reloadFile;            // "Reload File"
    public string reloadScript;          // "Reload Script"
    public string unityLogLevel;         // "Unity log level"
    public string userInterface;           // "User Interface"
    public string customLevelButtonPosition; // "Custom level button position"
    public string customLevelButtonFrameColor; // "Custom level button frame color"
    public string customLevelButtonTextColor;  // "Custom level button text color"
    public string customLevelButtonColors;     // panel "Custom level button colors"
    public string leaderboards;            // "Leaderboards"
    public string postRecordsToLeaderboards;      // "Post records to leaderboards"
    public string showLeaderboardOnLevelEnd;   // "Show leaderboard on level end"
    public string showLeaderboardOnSecretLevelEnd; // "Show leaderboard on secret level end"
    public string defaultLeaderboardCategory;  // "Default leaderboard category"
    public string defaultLeaderboardDifficulty; // "Default leaderboard difficulty"
    public string defaultLeaderboardFilter;    // "Default leaderboard filter"
    public string online;                  // "Online"
    public string refreshCatalogOnBoot;   // "Refresh online catalog on boot"
    public string useDevelopmentBranch;   // "Use development chanel"
    public string useLocalServer;         // "Use local server"
    public string levelUpdateNotifier;    // "Notify on level updates"
    public string levelUpdateIgnoreCustomBuilds; // "Ignore updates for custom build"
    public string newLevelNotifierToggle; // "Notify on new level release"
    
    public string scripts;                 // "Scripts"
    public string updateIgnoreCustomBuilds; // "Ignore updates for custom builds"
    public string certificateIgnore; // "Certificate ignore"
    public string compatibility;           // "Compatibility"
    public string reloadAlwaysGoToMainMenu; // "Quick reload in main menu"
    public string dangerZone;              // "Danger Zone"
    public string dataPath;               // "Data Path"
    public string moveData;               // "Move Data"
    public string deleteOldBundles;       // "Delete Old Bundles"
}

// It's used by two component:
// AngryBundleSortFieldComponent / AngryOnlineSortFieldComponent
public class SortingOption
{
    public string name;
    public string author;
    public string lastUpdate;
    public string lastPlayed;
    public string votes;
}

public class BundleStatus
{
    // OnlineLevelField.cs line 630
    // Occur when download failure and not been canceled by itself
    public string networkError;  // "Network error"

    // OnlineLevelField.cs line 688
    // Occur when MD5 hash of downloaded file are not equal to the catalog's MD5 hash
    public string fileWasModified;  // "File was modified"

    // OnlineLevelField.cs line 661
    // Occur when BundleInfo.guid != AngryBundleData.bundleGuid
    public string validationError;  // "Validation error"
    
    public string locked;  // "Locked"
    public string notInstalled;
    public string installed;
    public string updateAvailable;
}

public class Category
{
    public string none;  // "None"
    public string noMonsters; // "No Monsters"
    public string noMonstersAndWeapons;  // "No Monsters/Weapons"
}

public class OnlineLevel
{
    public string size; // "Size: "
    public string author;  // "Author: "
    public string outdateAndLocked;  // "(OUTDATE/LOCKED)"
    public string install; // INSTALL
    public string changelog; // CHANGELOG
    public string changelog_header;  // "Changelog"
    public string changelog_cancel;  // "Cancel"
    public string changelog_update;  // "Update"
    public string update;  // "UPDATE"
}

public class LevelPanel
{
    public string time;
    public string kills;
    public string style;
    public string secrets;
    public string challenge;
    public string reloadFile;
    public string forceReloadFile;
    public string levels;
}
