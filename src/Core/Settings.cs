using BepInEx.Configuration;

namespace UltrakULL;

public static class Settings
{
    public static ConfigEntry<string> lastLanguage;
    public static ConfigEntry<bool> activeDubbing;
    public static ConfigFile configFile;
    public static void InitializeConfig()
    {
        configFile = new ConfigFile(ConfigPaths.SettingsFile, true);
        lastLanguage = configFile.Bind("General", "LastLanguage", "en-GB");
        activeDubbing = configFile.Bind("General","activeDubbing", false);
    }
}
