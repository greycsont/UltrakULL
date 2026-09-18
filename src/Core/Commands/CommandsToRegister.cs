using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using AngryLevelLoader;
using AngryLevelLoader.Containers;
using AngryLevelLoader.DataTypes;
using AngryLevelLoader.Managers;
using GameConsole;
using GameConsole.CommandTree;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            }),
            Branch("gene",
                Leaf("angry", () =>
                {
                    try
                    {
                        // The language's angry.json, or an empty object if the file doesn't exist yet.
                        JObject root = LoadAngryFile(out string path);

                        // Old test version had the UI sections at the root, before AngryTranslation existed.
                        if (root["angryUi"] == null)
                        {
                            var ui = new JObject();

                            // ToArray: root loses properties while we loop over them.
                            foreach (string key in root.Properties().Select(property => property.Name).ToArray())
                            {
                                // ignore the angryBundles stuff
                                if (key == "angryBundles")
                                    continue;
                                
                                ui[key] = root[key];   // assigning clones the value, the original stays in root
                                root.Remove(key);      // ...so it can be dropped from root here
                            }

                            // If the ui have sth add from root (angryUi)
                            //   it'll write it under angryUi object
                            if (ui.HasValues)
                            {
                                root["angryUi"] = ui;
                                Log.Info("Moved the flat UI sections under \"angryUi\".");
                            }
                        }

                        if (root["angryUi"] is JObject uiNode)
                            FillGaps(uiNode, BlankOf(new AngryUi()));   // adds the missing keys only
                        else
                            root["angryUi"] = BlankOf(new AngryUi());   // write a blank one if not an object (or still missing)

                        File.WriteAllText(path, root.ToString(Formatting.Indented));   // write everything back
                        Log.Info($"Written {path} (angry ui).");
                    }
                    catch (System.Exception e)
                    {
                        Log.Error($"Failed to write the angry ui: {e}");
                    }
                })
            ),
            Branch("scan",
                Leaf("angrylevel", () =>
                {
                    try
                    {
                        if (!AngrySceneTracker.InAngryLevel)
                        {
                            Log.Warning("Not in an Angry level. Load a custom level first, then scan it.");
                            return;
                        }

                        var root = LoadAngryFile(out string path);

                        var bundlesNode = root["angryBundles"]?["bundles"] as JObject;
                        if (bundlesNode == null)
                            root["angryBundles"] = new JObject { ["bundles"] = bundlesNode = new JObject() };

                        // Get the current level's Guid and levelId
                        string bundleGuid = AngryLevelText.BundleGuid;
                        string levelId = AngryLevelText.LevelId;

                        if (string.IsNullOrEmpty(bundleGuid) || string.IsNullOrEmpty(levelId))
                        {
                            Log.Error($"In an Angry level but its ids are empty... " +
                                      $"(bundle='{bundleGuid}', level='{levelId}').");
                            return;
                        }

                        var bundleNode = bundlesNode[bundleGuid] as JObject;
                        if (bundleNode == null)
                            bundlesNode[bundleGuid] = bundleNode = new JObject();

                        bundleNode["bundleName"] ??= AngrySceneManager.currentBundleContainer.BundleName;

                        var levelsNode = bundleNode["levels"] as JObject;
                        if (levelsNode == null)
                            bundleNode["levels"] = levelsNode = new JObject();

                        var levelNode = levelsNode[levelId] as JObject;
                        if (levelNode == null)
                            levelsNode[levelId] = levelNode = new JObject();

                        FillGaps(levelNode, BlankOf(new AngryLevel()));

                                                
                        JArray booksJArray = ArrayIn(levelNode, "books");
                        JArray hudMessagesJArray = ArrayIn(levelNode, "hudMessages");

                        foreach (var root2 in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
                        {
                            foreach (var hudMessage in root2.GetComponentsInChildren<HudMessage>(true))
                            {
                                AddMatch(hudMessagesJArray, GetFullMessage(hudMessage), "");
                            }

                            foreach (var book in root2.GetComponentsInChildren<Readable>(true))
                            {
                                AddMatch(booksJArray, book.content, "");
                            }
                        }


                        File.WriteAllText(path, root.ToString(Formatting.Indented));
                        Log.Info($"Written {path}: {AngrySceneManager.currentBundleContainer.BundleName} / {levelId}.");
                    }
                    catch (System.Exception e)
                    {
                        Log.Error($"Failed to scan the angry level: {e}");
                    }
                })
            ));
    }

    
    private static string GetFullMessage(HudMessage hm)
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

    private static JObject LoadAngryFile(out string path)
    {
        string folder = LanguageManager.Current.AngryLevelFolder;
        path = Path.Combine(folder, "angry.json");
        Directory.CreateDirectory(folder);

        return File.Exists(path)
            ? JObject.Parse(File.ReadAllText(path)) ?? new JObject()
            : new JObject();
    }

    private static JObject BlankOf(object target)
    {
        var node = JObject.FromObject(target);
        foreach (JToken token in node.Descendants().Where(t => t.Type == JTokenType.Null).ToList())
            token.Replace("");

        return node;
    }

    private static void FillGaps(JObject node, JObject template)
    {
        foreach (JProperty property in template.Properties())
        {
            if (property.Value is JObject nested)
            {
                if (node[property.Name] is JObject existing)
                    FillGaps(existing, nested);
                else
                    node[property.Name] = nested.DeepClone();

                continue;
            }

            if (node[property.Name] == null)
                node[property.Name] = property.Value.DeepClone();
        }
    }

    private static JArray ArrayIn(JObject parent, string name)
    {
        if (parent[name] is JArray array)
            return array;

        var created = new JArray();
        parent[name] = created;
        return created;
    }

    private static void AddMatch(JArray array, string match, string text)
    {
        if (string.IsNullOrEmpty(match))
            return;

        foreach (JToken item in array)
            if (item is JObject existing && (string)existing["match"] == match)
                return;

        array.Add(new JObject { ["match"] = match, ["text"] = text });
    }

    public Logger Log { get; } = new Logger("ultrakull");
}
