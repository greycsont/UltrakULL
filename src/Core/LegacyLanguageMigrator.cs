using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UltrakULL.json;

namespace UltrakULL;


// Moves the old flat layout (config/ultrakull/<lang>.json + audio/<lang> +
//   textures/<lang>) into per-language packages (languages/<lang>/...).
//
// Two stages:
//   1. Mirror EVERYTHING into legacy-backup, structure unchanged.
//   2. Move each language into its package — no backup logic mixed in.
public static class LegacyLanguageMigrator
{
    // It's used for logging only
    public struct LegacyMigrationResult{
        public int MigratedLanguages;
        public int SkippedLanguages;
        public IReadOnlyList<string> Warnings;
        public string BackupDirectory;

        public LegacyMigrationResult(int migrated, int skipped, IReadOnlyList<string> warnings, string backupDirectory)
        {
            MigratedLanguages = migrated;
            SkippedLanguages = skipped;
            Warnings = warnings;
            BackupDirectory = backupDirectory;
        }
    }

    public static LegacyMigrationResult Migrate()
    {
        int migrated = 0;
        int skipped = 0;
        var warnings = new List<string>();

        // If the root directory doesn't exist, there's nothing to migrate.
        if (!Directory.Exists(ConfigPaths.RootDirectory))
            return new LegacyMigrationResult(0, 0, Array.Empty<string>(), null);

        string backupDirectory = ConfigPaths.LegacyBackupDirectory;

        // Stage 1: mirror the old layout into legacy-backup
        // Just for safety
        MirrorLegacyLayout(backupDirectory);

        // Stage 2: move each language stuff into it's own package
        foreach (string sourceFile in Directory.EnumerateFiles(
                     ConfigPaths.RootDirectory, "*.json", SearchOption.TopDirectoryOnly))
        {
            try
            {
                if (MoveToPackage(sourceFile))
                    migrated++;
            }
            catch (Exception error)
            {
                skipped++;
                warnings.Add($"Skipped '{sourceFile}': {error.Message}");
            }
        }

        return new LegacyMigrationResult(migrated, skipped, warnings, backupDirectory);
    }

    // Copies the whole pre-migration layout into legacy-backup with the same
    //   structure: *.json flat, audio/<lang> and textures/<lang> as subfolders.
    // Restoring the old layout is just copying this back over config/ultrakull.
    private static void MirrorLegacyLayout(string backupRoot)
    {
        Directory.CreateDirectory(backupRoot);

        foreach (string file in Directory.EnumerateFiles(
                     ConfigPaths.RootDirectory, "*.json", SearchOption.TopDirectoryOnly))
            File.Copy(file, Path.Combine(backupRoot, Path.GetFileName(file)), overwrite: true);

        CopyDirectoryIfExists(
            Path.Combine(ConfigPaths.RootDirectory, "audio"),
            Path.Combine(backupRoot, "audio"));
        CopyDirectoryIfExists(
            Path.Combine(ConfigPaths.RootDirectory, "textures"),
            Path.Combine(backupRoot, "textures"));
    }

    // Moves one flat language file (plus its audio/textures) into its package.
    // Returns true when a language was migrated (te-mp -> template doesn't count).
    private static bool MoveToPackage(string sourceFile)
    {
        JsonFormat json = JsonConvert.DeserializeObject<JsonFormat>(File.ReadAllText(sourceFile));
        string languageId = json?.metadata?.langName;

        if (languageId == "te-mp")
        {
            MoveTemplate(sourceFile);
            return false;
        }

        // The id becomes directory names below, so it must be path-safe.
        if (!IsSafeLanguageId(languageId))
            throw new InvalidDataException("Invalid or missing language id");

        var packageDirectory = Path.Combine(ConfigPaths.LanguagesDirectory, languageId);
        var languageFile = Path.Combine(packageDirectory, "language.json");
        var oldAudio = ConfigPaths.GetLegacyAudioDirectory(languageId);
        var oldTextures = ConfigPaths.GetLegacyTextureDirectory(languageId);
        var newAudio = Path.Combine(packageDirectory, "audio");
        var newTextures = Path.Combine(packageDirectory, "textures");

        // Never overwrite an existing package, or a half-migrated one.
        if (File.Exists(languageFile)
            || Directory.Exists(oldAudio) && Directory.Exists(newAudio)
            || Directory.Exists(oldTextures) && Directory.Exists(newTextures))
            throw new IOException("The destination package already contains data");

        Directory.CreateDirectory(packageDirectory);
        MoveDirectoryIfExists(oldAudio, newAudio);
        MoveDirectoryIfExists(oldTextures, newTextures);
        File.Move(sourceFile, languageFile);
        return true;
    }

    // Moves te-mp.json to templates/language.json, unless one already exists
    // (don't overwrite a template the user may have edited).
    private static void MoveTemplate(string sourceFile)
    {
        var templateFile = Path.Combine(ConfigPaths.TemplatesDirectory, "language.json");
        if (File.Exists(templateFile))
            return;

        Directory.CreateDirectory(ConfigPaths.TemplatesDirectory);
        File.Move(sourceFile, templateFile);
    }

    private static void CopyDirectoryIfExists(string source, string destination)
    {
        if (Directory.Exists(source))
            CopyDirectory(source, destination);
    }

    private static void MoveDirectoryIfExists(string source, string destination)
    {
        if (Directory.Exists(source))
            Directory.Move(source, destination);
    }

    private static void CopyDirectory(string source, string destination)
    {
        Directory.CreateDirectory(destination);
        foreach (string file in Directory.EnumerateFiles(source))
            File.Copy(file, Path.Combine(destination, Path.GetFileName(file)), overwrite: true);
        foreach (string directory in Directory.EnumerateDirectories(source))
            CopyDirectory(directory, Path.Combine(destination, Path.GetFileName(directory)));
    }

    // Nobody will fucking use this mod for directory traversal payload right?
    // Just prevent someone add backslash/slash
    //   and invalid character for directory/file name, and empty string, and dot/double-dot
    private static bool IsSafeLanguageId(string languageId) =>
        !string.IsNullOrWhiteSpace(languageId)
        && languageId != "."
        && languageId != ".."
        && languageId.IndexOfAny(Path.GetInvalidFileNameChars()) < 0
        && languageId.IndexOf(Path.DirectorySeparatorChar) < 0
        && languageId.IndexOf(Path.AltDirectorySeparatorChar) < 0;
}
