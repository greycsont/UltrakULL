using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx.Logging;
using Newtonsoft.Json;
using UltrakULL.Harmony_Patches;

using static UltrakULL.SceneObjects;

namespace UltrakULL.json;

/// <summary>
/// Loads every installed language from disk, selects the active one, and
/// notifies all subsystems (font, TMP, subtitle, texture, layout) when it changes.
///
/// Load pipeline:
///
///     InitializeManager(modVersion)
///      ├─ LoadSubtitledSourcesConfig()      embedded SubtitledSources.json -> audio replacer
///      ├─ LoadLanguages(modVersion)         fill allLanguages from disk
///      │     ├─ languages/*/language.json   (package layout, recursive; optional layout.json alongside)
///      │     └─ <legacy>.json in root      (pre-package releases, TopDirectoryOnly)
///      └─ SelectLastLanguage()              restore last-used language
///            └─ SetCurrentLanguage(...)
///                  └─ OnLanguageChanged ──► FontManager / TextMeshProFontSwap
///                                             / SubtitleLocalizer / TextureSwapper / UILayoutOverride
///
/// Order matters: allLanguages fills before SelectLastLanguage, or the last
/// language silently falls back to en-GB.
/// Fonts aren't loaded here; FontManager fills TMP_FontAsset on demand.
/// </summary>
public static class LanguageManager
{
    public static Dictionary<string, Lang> allLanguages = new Dictionary<string, Lang>();
    public static JsonFormat CurrentLanguage => Current.Json;
    public static Lang Current { get; private set; }
    private static ManualLogSource jsonLogger = Logger.CreateLogSource("LanguageManager");

    public static event Action<ValueChangedEvent<Lang>> OnLanguageChanged;

	#region Helper Properties
		public static bool IsEnglish => Current?.IsEnglish ?? true;
		public static bool IsRightToLeft => Current.IsRightToLeft;
	#endregion

	public static void InitializeManager(string modVersion)
    {
        LoadSubtitledSourcesConfig();
        LoadLanguages(modVersion);
        SelectLastLanguage();

        void SelectLastLanguage()
        {
            if (allLanguages.ContainsKey(Settings.lastLanguage.Value))
            {
                jsonLogger.Log(LogLevel.Message, "Setting language to " + Settings.lastLanguage.Value);
                SetCurrentLanguage(Settings.lastLanguage.Value);
            }
            else
            {
                jsonLogger.Log(LogLevel.Message, "Previous lang file is missing from disk: " + Settings.lastLanguage.Value);
                Logging.Warn("Setting language back to en-GB to avoid problems");
                Core.wasLanguageReset = true;
                SetCurrentLanguage("en-GB");
            }
        }   
    }

    public static void LoadLanguagesInDirectory(string modVersion, string path)
    {
        if (!Directory.Exists(path))
            return;

        Logging.Info($"Loading language packages from \"{path}\"");
        foreach (string file in Directory.EnumerateFiles(
                     path,
                     "language.json",
                     SearchOption.AllDirectories))
            LoadLanguageFile(modVersion, file, Path.GetDirectoryName(file));
    }

    public static void LoadLanguages(string modVersion)
    {
        Logging.Message("Loading language files stored locally on disk...");

        LoadLanguagesInDirectory(modVersion, ConfigPaths.LanguagesDirectory);

        // Compatibility with releases that stored <language>.json directly in config/ultrakull.
        if (!Directory.Exists(ConfigPaths.RootDirectory))
            return;
        foreach (string file in Directory.EnumerateFiles(
                     ConfigPaths.RootDirectory,
                     "*.json",
                     SearchOption.TopDirectoryOnly))
            LoadLanguageFile(modVersion, file, packageFolder: null);
    }

    private static void LoadLanguageFile(string modVersion, string file, string packageFolder)
    {
        Logging.Info($"Trying to load \"{file}\"");
        if (!TryLoad(file, out JsonFormat lang)
            || lang?.metadata == null
            || string.IsNullOrWhiteSpace(lang.metadata.langName))
        {
            Logging.Warn($"Skipping \"{file}\" because it is not a language file.");
            return;
        }

        string languageId = lang.metadata.langName;
        if (languageId == "te-mp")
            return;
        if (allLanguages.ContainsKey(languageId))
        {
            Logging.Warn($"Skipping duplicate language \"{languageId}\" from \"{file}\".");
            return;
        }

        UILayoutProfile layout = null;
        string layoutPath = ConfigPaths.GetUIOverridePath(languageId);
        if (layoutPath != null && File.Exists(layoutPath))
            TryLoad(layoutPath, out layout);

        allLanguages.Add(languageId, new Lang(lang, packageFolder, layout));
        if (Version.Parse(lang.metadata.langVersion) < Version.Parse(MainPatch.GetVersion()))
        {
            Logging.Warn($"The language file \"{file}\" maybe outdated. It was made for version {lang.metadata.langVersion} of UltrakULL, but the current version is {modVersion}. This may cause problems.");
            Logging.Warn($"From what I see is that ClearWater trying to make this mod as a centerized translation mod and you could download translation in a cloud server\n"
                         + $"But... I just add a short warning anyway");
        }
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
            Logging.Error($"An error occured while loading a JSON file.\n"
                + "Please use https://jsonlint.com/ to make sure your .json file is correctly formatted!\n"
                + "File: " + pathName 
                + "\nError: " + e.ToString());
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

        Settings.lastLanguage.Value = langName;

        OnLanguageChanged?.Invoke(new ValueChangedEvent<Lang>(previous, lang));
        return true;
    }

    /// <summary>
    /// This is the API of changning language
    /// </summary>
    /// <param name="langName"></param>
    public static void TrySwitchLanguage(string langName)
    {
        if (GetCurrentSceneName() != "Main Menu")
            MonoSingleton<HudMessageReceiver>.Instance?.SendHudMessage("<color=orange>Language changes will not fully take effect until the current mission is quit or restarted.</color>");
            
        if (SetCurrentLanguage(langName))
            RefreshLiveUI();
    }

    /// <summary>Refreshes the UI objects that already exist in the active scene.</summary>
    private static void RefreshLiveUI()
    {
        MainPatch.Instance.RefreshCurrentScene();

        LanguageOptions.RefreshText();
        LoadingTextPatch.UpdateLoadingText();
    }

    public static bool ReloadLanguages()
    {
        var previewsLang = Current;

        return false;
    }
}
