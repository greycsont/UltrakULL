using System.IO;
using BepInEx.Configuration;

namespace UltrakULL;

public static class Setting
{
    public static ConfigEntry<string> lastLanguage;
    public static ConfigEntry<string> activeDubbing;
    public static ConfigFile configFile;
    public static void InitializeConfig()
    {
        configFile = new ConfigFile(Path.Combine(BepInEx.Paths.ConfigPath, "ultrakull", "lastLang.cfg"), true);
        lastLanguage = configFile.Bind("General", "LastLanguage", "en-GB");
        activeDubbing = configFile.Bind("General","activeDubbing","False");
    }
}