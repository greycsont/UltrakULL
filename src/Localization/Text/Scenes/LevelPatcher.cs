using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

// THE single entry point for level patching. Routes a scene name to:
//   - the level's results screen (name + challenge, via LevelStrings),
//   - its act's hellmap (per-level in the Levels table),
//   - any level-specific patch (7-2's door control panel etc.),
//   - secret-level handling (testament + results panel).
// Split across partial files by concern: Hellmaps, Secrets, LevelSpecials.
// Prime (P-1..P-3) stays independent in PrimeSanctum.
public static partial class LevelPatcher
{
    // Scene names that don't follow the "Level X-x" pattern.
    private static readonly Dictionary<string, Action<GameObject>> SpecialScenes = new()
    {
        ["uk_construct"] = obj => Sandbox.Patch(obj),
        ["Endless"] = _ => CyberGrind.PatchCg(),
        ["CreditsMuseum2"] = _ => DevMuseum.Patch(),
        ["Level P-1"] = _ => PrimeSanctum.Patch(),
        ["Level P-2"] = _ => PrimeSanctum.Patch(),
        ["Level P-3"] = _ => PrimeSanctum.Patch(),
    };

    // Level id -> (act hellmap, level-specific patch)
    private static readonly (string id, Action<GameObject> hellmap, Action<GameObject> special)[] Levels =
    {
        // ===== Prelude (no hellmap) =====
        ("Level 0-1", null, PatchLevel0_1),
        ("Level 0-2", null, null),
        ("Level 0-3", null, null),
        ("Level 0-4", null, null),
        ("Level 0-5", null, null),
        // ===== Act 1 =====
        ("Level 1-1", PatchHellmapAct1, null),
        ("Level 1-2", PatchHellmapAct1, null),
        ("Level 1-3", PatchHellmapAct1, null),
        ("Level 1-4", PatchHellmapAct1, null),
        ("Level 2-1", PatchHellmapAct1, PatchLevel2_1),
        ("Level 2-2", PatchHellmapAct1, null),
        ("Level 2-3", PatchHellmapAct1, null),
        ("Level 2-4", PatchHellmapAct1, null),
        ("Level 3-1", PatchHellmapAct1, null),
        ("Level 3-2", PatchHellmapAct1, null),
        // ===== Act 2 =====
        ("Level 4-1", PatchHellmapAct2, null),
        ("Level 4-2", PatchHellmapAct2, null),
        ("Level 4-3", PatchHellmapAct2, null),
        ("Level 4-4", PatchHellmapAct2, null),
        ("Level 5-1", PatchHellmapAct2, null),
        ("Level 5-2", PatchHellmapAct2, null),
        ("Level 5-3", PatchHellmapAct2, null),
        ("Level 5-4", PatchHellmapAct2, null),
        ("Level 6-1", PatchHellmapAct2, null),
        ("Level 6-2", PatchHellmapAct2, null),
        // ===== Act 3 =====
        ("Level 7-1", PatchHellmapAct3, null),
        ("Level 7-2", PatchHellmapAct3, PatchLevel7_2),
        ("Level 7-3", PatchHellmapAct3, PatchLevel7_3),
        ("Level 7-4", PatchHellmapAct3, PatchLevel7_4),
        ("Level 8-1", PatchHellmapAct3, null),
        ("Level 8-2", PatchHellmapAct3, PatchLevel8_2),
        ("Level 8-3", PatchHellmapAct3, PatchLevel8_3),
        ("Level 8-4", PatchHellmapAct3, PatchLevel8_4),
        ("Level 9-1", PatchHellmapAct3, null),
        ("Level 9-2", PatchHellmapAct3, null),
        // ===== Encores =====
        ("Level 0-E", null, null),
        ("Level 1-E", null, null),
        ("Level 2-E", null, null),
        ("Level 3-E", null, null),
        ("Level 4-E", null, null),
        ("Level 5-E", null, null),
        ("Level 6-E", null, null),
        ("Level 7-E", null, null),
        ("Level 8-E", null, null),
        ("Level 9-E", null, null),
    };

    public static void Patch(string levelName, GameObject canvasObj)
    {
        if (SpecialScenes.TryGetValue(levelName, out Action<GameObject> special))
        {
            special(canvasObj);
            return;
        }

        // Secrets have their own results panel (PatchSecret), not the normal one.
        if (levelName.EndsWith("-S"))
        {
            PatchSecret(levelName, canvasObj);
            return;
        }

        // Intermission (after 3-2, 6-2 and 8-4 at 17d4)
        if (levelName.Contains("Intermission") || levelName.Contains("EarlyAccessEnd"))
        {
            Intermission.Patch(canvasObj);
            return;
        }

        // Normal levels + encores: name/challenge on the results screen, then
        //   the act's hellmap and any level-specific patch.
        // Idk maybe I should add rude levels()
        string name = LevelStrings.GetLevelName();
        string challenge = LevelStrings.GetLevelChallenge(levelName);
        ResultsScreenLocalizer.PatchResultsScreen(name, challenge);

        foreach (var (id, hellmap, levelSpecial) in Levels)
        {
            if (id != levelName)
                continue;

            hellmap?.Invoke(canvasObj);
            levelSpecial?.Invoke(canvasObj);
            return;
        }

        Logging.Warn("No patch defined for scene: " + levelName);
    }
}
