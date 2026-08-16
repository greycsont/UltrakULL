using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UltrakULL.json;

namespace UltrakULL;

public sealed class LegacyMigrationResult
{
    public int MigratedLanguages { get; internal set; }
    public int SkippedLanguages { get; internal set; }
    public string BackupDirectory { get; internal set; }
    public List<string> Warnings { get; } = new();
}

public static class LegacyLanguageMigrator
{
    public static LegacyMigrationResult Migrate()
    {
        var result = new LegacyMigrationResult();
        if (!Directory.Exists(ConfigPaths.RootDirectory))
            return result;

        result.BackupDirectory = ConfigPaths.LegacyBackupDirectory;

        foreach (string sourceFile in Directory.EnumerateFiles(
                     ConfigPaths.RootDirectory, "*.json", SearchOption.TopDirectoryOnly))
        {
            try
            {
                JsonFormat json = JsonConvert.DeserializeObject<JsonFormat>(File.ReadAllText(sourceFile));
                string languageId = json?.metadata?.langName;

                if (languageId == "te-mp")
                {
                    string templateFile = Path.Combine(ConfigPaths.TemplatesDirectory, "language.json");
                    if (!File.Exists(templateFile))
                    {
                        Directory.CreateDirectory(ConfigPaths.TemplatesDirectory);
                        BackUpFile(sourceFile, languageId, "language.json", result.BackupDirectory);
                        File.Move(sourceFile, templateFile);
                    }
                    continue;
                }

                if (!IsSafeLanguageId(languageId))
                    throw new InvalidDataException("Invalid or missing language id");

                string packageDirectory = Path.Combine(ConfigPaths.LanguagesDirectory, languageId);
                string languageFile = Path.Combine(packageDirectory, "language.json");
                string oldAudio = ConfigPaths.GetLegacyAudioDirectory(languageId);
                string oldTextures = ConfigPaths.GetLegacyTextureDirectory(languageId);
                string newAudio = Path.Combine(packageDirectory, "audio");
                string newTextures = Path.Combine(packageDirectory, "textures");

                if (File.Exists(languageFile)
                    || Directory.Exists(oldAudio) && Directory.Exists(newAudio)
                    || Directory.Exists(oldTextures) && Directory.Exists(newTextures))
                    throw new IOException("The destination package already contains data");

                Directory.CreateDirectory(packageDirectory);

                // Copy everything into the backup before moving, so the legacy
                // layout survives even if a later step fails mid-way.
                BackUpFile(sourceFile, languageId, "language.json", result.BackupDirectory);
                MoveDirectoryWithBackup(oldAudio, newAudio, languageId, "audio", result.BackupDirectory);
                MoveDirectoryWithBackup(oldTextures, newTextures, languageId, "textures", result.BackupDirectory);

                File.Move(sourceFile, languageFile);
                result.MigratedLanguages++;
            }
            catch (Exception error)
            {
                result.SkippedLanguages++;
                result.Warnings.Add($"Skipped '{sourceFile}': {error.Message}");
            }
        }

        return result;
    }

    private static void BackUpFile(string sourceFile, string languageId, string fileName, string backupRoot)
    {
        string backupDirectory = Path.Combine(backupRoot, languageId);
        Directory.CreateDirectory(backupDirectory);
        File.Copy(sourceFile, Path.Combine(backupDirectory, fileName), overwrite: true);
    }

    private static void MoveDirectoryWithBackup(
        string source, string destination, string languageId, string folderName, string backupRoot)
    {
        if (!Directory.Exists(source))
            return;

        CopyDirectory(source, Path.Combine(backupRoot, languageId, folderName));
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

    /// <summary>
    /// Nobody will fucking use this mod for directory traversal payload right?
    /// Just prevent someone add backslash/slash
    /// and invalid character for directory/file name, and empty string, and dot/double-dot
    /// </summary>
    /// <param name="languageId"></param>
    /// <returns></returns>
    private static bool IsSafeLanguageId(string languageId) =>
        !string.IsNullOrWhiteSpace(languageId)
        && languageId != "."
        && languageId != ".."
        && languageId.IndexOfAny(Path.GetInvalidFileNameChars()) < 0
        && languageId.IndexOf(Path.DirectorySeparatorChar) < 0
        && languageId.IndexOf(Path.AltDirectorySeparatorChar) < 0;
}
