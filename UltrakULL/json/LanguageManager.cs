using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Newtonsoft.Json;
using UltrakULL.Harmony_Patches;
using UnityEngine.SceneManagement;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.json;

public static class LanguageManager
{
    public static Dictionary<string, Lang> allLanguages = new Dictionary<string, Lang>();
    public static JsonFormat CurrentLanguage => Current.Json;
    public static Lang Current { get; private set; }
    private static ManualLogSource jsonLogger = Logger.CreateLogSource("LanguageManager");
    public static ConfigFile configFile;

    public static event Action<ValueChangedEvent<Lang>> OnLanguageChanged;

		#region Helper Properties
		public static bool IsRightToLeft { get => Current.IsRightToLeft; }
		public static bool UsingHinduNumbers { get => Current.UsingHinduNumbers; }
		#endregion

	public static void InitializeManager(string modVersion)
    {
        LoadLanguages(modVersion);

        configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "ultrakull", "lastLang.cfg"), true);

        string value = configFile.Bind("General", "LastLanguage", "en-GB").Value;
        string dubValue = configFile.Bind("General","activeDubbing","False").Value;

        if (allLanguages.ContainsKey(value))
        {
            jsonLogger.Log(LogLevel.Message, "Setting language to " + value);
            SetCurrentLanguage(value);
        }
        else
        {
            jsonLogger.Log(LogLevel.Message, "Previous lang file is missing from disk: " + value);
            Logging.Warn("Setting language back to en-GB to avoid problems");
            Core.wasLanguageReset = true;
            SetCurrentLanguage("en-GB");
        }
        
        LoadSubtitledSourcesConfig();
    }

    public static void DumpLastLanguage()
    {
        configFile.Bind("General", "LastLanguage", "en-GB").Value = CurrentLanguage.metadata.langName; // Thank you copilot
    }

    public static void LoadLanguagesInDirectory(string modVersion, string path)
    {
        Logging.Info($"Loading all language files in \"{path}\"");

        string[] files = Directory.GetFiles(path, "*.json");
        string[] subdirectories = Directory.GetDirectories(path);

        foreach (string file in files)
        {
            Logging.Info($"Trying to load \"{file}\"");
            if (TryLoad(file, out JsonFormat lang) && !allLanguages.ContainsKey(lang.metadata.langName) && lang.metadata.langName != "te-mp")
            {
                allLanguages.Add(lang.metadata.langName, new Lang(lang));
                if (!ValidateFile(lang, modVersion))
                    jsonLogger.Log(LogLevel.Debug, "Failed to validate " + lang.metadata.langName);
            }
        }

        foreach (string directory in  subdirectories)
        {
            LoadLanguagesInDirectory(modVersion, directory);
        }
	}

    public static void LoadLanguages(string modVersion)
    {
        Logging.Message("Loading language files stored locally on disk...");

        LoadLanguagesInDirectory(modVersion, Path.Combine(Paths.ConfigPath, "ultrakull"));
    }

    private static void LoadSubtitledSourcesConfig()
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("UltrakULL.SubtitledSources.json");
        SubtitledAudioSourcesReplacer.Config = JsonConvert.DeserializeObject<SubtitledSourcesConfig>(new StreamReader(stream).ReadToEnd());
    }

    private static bool TryLoad<T>(string pathName, out T file)
    {
        file = default;
        try
        {
            string jsonFile = File.ReadAllText(pathName);
            file = JsonConvert.DeserializeObject<T>(jsonFile);
            return true;
        }
        catch (Exception e)
        {
            Logging.Error("Failed to load language file " + pathName + ": " + e.Message);
            return false;
        }
    }

    private static bool ValidateFile(JsonFormat language, string modVersion)
    {
        try
        {
            //Following conditions to validate a file:
            //Must be JSON-deserializable
            //Must have a metadata attribute and a body attribute
            //Version logged in the JSON file must match or be newer than the current mod version
            //Will need to implement further sanity checks.
            //Logging.Message("Checking version...");

            if (!FileMatchesMinimumRequiredVersion(language.metadata.minimumModVersion, modVersion))
            {
                Logging.Warn(language.metadata.langName + " was made for an older game version.");
                return false;
            }

            Logging.Message("Checking contents...");
            if (language.metadata != null && language.body != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Logging.Error("An error occured while validating. It's possible the language file is not correctly formatted in .json.\n"
                + "Please use https://jsonlint.com/ to make sure your .json file is correctly formatted!");
            Logging.Error(e.ToString());
            return false;
        }
    }

    public static bool FileMatchesMinimumRequiredVersion(string requiredModVersion, string actualModVersion)
    {
        if (requiredModVersion == "")
        {
            Logging.Error("Language file has not defined the minimum mod version required!");
            return false;
        }

        Version jsonVersion = new Version(requiredModVersion);
        Version ultrakullVersion = new Version(actualModVersion);
        int isCompatible = jsonVersion.CompareTo(ultrakullVersion);

        //JSON version is greater or matches mod version
        if (jsonVersion == ultrakullVersion || isCompatible > 0)
        {
            return true;
        }
        //JSON version is lower than mod version
        else
        {
            return false;
        }
    }

    private static bool SetCurrentLanguage(string langName)
    {
        if (!allLanguages.TryGetValue(langName, out Lang lang))
        {
            Logging.Warn("No language found with name " + langName);
            return false;
        }
        if (lang == Current)
        {
            Logging.Warn("Tried to switch language to " + langName + " but it was already set as that!");
            return false;
        }

        Lang previous = Current;
        Current = lang;
        Logging.Message("Setting language to " + langName);

        lang.EnsureRtlApplied();
        DumpLastLanguage();

        OnLanguageChanged?.Invoke(new ValueChangedEvent<Lang>(previous, lang));
        return true;
    }

    /// <summary>
    /// This is the API of changning language
    /// </summary>
    /// <param name="langName"></param>
    public static void TrySwitchLanguage(string langName)
    {
        if (SetCurrentLanguage(langName))
            RefreshLiveUI();
    }

    /// <summary>
    /// Reruns the onSceneLoaded and it replaces the current UI
    /// It still have a lot of issues when switch to English
    /// That's why HUDMessage used in here(
    /// </summary>
    private static void RefreshLiveUI()
    {
        MainPatch.Instance.onSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);

        InjectLanguageButton.updateLanguageButtonText();
        LoadingTextPatch.UpdateLoadingText();

        if (GetCurrentSceneName() != "Main Menu")
        {
            MonoSingleton<HudMessageReceiver>.Instance?.SendHudMessage("<color=orange>Language changes will not fully take effect until the current mission is quit or restarted.</color>");
        }
    }
}
