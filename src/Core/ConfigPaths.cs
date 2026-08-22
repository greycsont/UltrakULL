using System.IO;
using BepInEx;

namespace UltrakULL;

/// <summary>
/// Central location for every filesystem path UltrakULL uses. Almost everything
/// lives under BepInEx/config/ultrakull (user data); the one exception is
/// GetFontBundlePath, which points at the mod's own folder.
/// </summary>
public static class ConfigPaths
{
    public static string RootDirectory => Path.Combine(Paths.ConfigPath, "ultrakull");
    public static string LanguagesDirectory => Path.Combine(RootDirectory, "languages");
    public static string TemplatesDirectory => Path.Combine(RootDirectory, "templates");
    public static string LegacyBackupDirectory => Path.Combine(RootDirectory, "legacy-backup");
    public static string SettingsFile => Path.Combine(RootDirectory, "lastLang.cfg");

    public static string GetLegacyAudioDirectory(string languageId) =>
        Path.Combine(RootDirectory, "audio", languageId);

    public static string GetLegacyTextureDirectory(string languageId) =>
        Path.Combine(RootDirectory, "textures", languageId);

    /// <summary>
    /// Font bundles ship with the mod itself (BepInEx/plugins/UltrakULL/fonts),
    /// unlike languages/audio/textures which are user data under config/ultrakull.
    /// since I want the fonts fit the game itself as perfect as possible
    /// </summary>
    public static string GetFontBundlePath(string languageId) =>
        Path.Combine(MainPatch.ModFolder, "fonts", languageId);

    public static string GetUIOverridePath(string languageId) =>
        Path.Combine(MainPatch.ModFolder, "fonts", languageId, "layout.json");

}
