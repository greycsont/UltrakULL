using System.IO;
using System.Security.Cryptography;
using GameConsole;
using GameConsole.CommandTree;
using Newtonsoft.Json;
using plog;
using UltrakULL.json;

namespace UltrakULL;

public sealed class CommandToRegister : CommandRoot, IConsoleLogger
{
    public CommandToRegister(Console con) : base(con)
    {
    }

    public override string Name => "ultrakull";
    public override string Description => "tons of setting";

    public override Branch BuildTree(Console con)
    {
        return Branch(Name,
            Leaf("migrate", () =>
            {
                var result = LegacyLanguageMigrator.Migrate();
                Log.Info($"Migrated {result.MigratedLanguages} legacy language package(s).");
                foreach (string warning in result.Warnings)
                    Log.Warning(warning);
                if (result.SkippedLanguages > 0)
                    Log.Warning($"Skipped {result.SkippedLanguages} language package(s). See messages above.");
                if (result.MigratedLanguages > 0)
                    Log.Info($"A copy of every migrated file was kept in \"{result.BackupDirectory}\".");
                Log.Info("Restart the game before editing or removing the backup.");
            }),
            Leaf("dhm", () =>
            {
                Logging.Info("=========================");
                foreach (var root in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    foreach (var hm in root.GetComponentsInChildren<HudMessage>(true))
                    {
                        string key = hm.actionReference == null ? "-" : hm.actionReference.action.id.ToString();
                        Logging.Info($"\n[HudMsgScan] obj='{hm.gameObject.name}' (active={hm.gameObject.activeInHierarchy})" +
                                    $"\n  msg ='{hm.message}'\n  m2  ='{hm.message2}'" +
                                    $"\n  fm = '{GetFullMessage(hm)}'" +
                                    $"\n  advanced={hm.advancedMessage} action={key}" +
                                    $"\n  ------------------------------");
                    }
                }

                static string GetFullMessage(HudMessage hm)
                {
                    if (hm.advancedMessage)
                    {
                        return hm.message;
                    }
                    else if (hm.actionReference == null)
                    {
                        return hm.message;
                    }
                    else
                    {
                        return hm.message + "{0}" + hm.message2;
                    }
                }
            }),
            Branch("gene",
                Leaf("angry", () =>
                {
                        var lang = LanguageManager.Current;
                        string folder = lang.AngryLevelFolder;
                        string path = Path.Combine(folder, "angry.json");

                        try
                        {
                            Directory.CreateDirectory(folder);

                            if (File.Exists(path))
                            {
                                Log.Warning($"Already exists, skipped: {path}");
                                return;
                            }

                            File.WriteAllText(path,
                                JsonConvert.SerializeObject(lang.angry, Formatting.Indented));
                            Log.Info($"Written: {path}");
                        }
                        catch (System.Exception e)
                        {
                            Log.Error($"Failed to export angry ui: {e}");
                        }
                })
            ));
    }

    public Logger Log { get; } = new Logger("ultrakull");
}


