using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;


public static partial class LevelPatcher
{
    private static readonly Dictionary<string, (Action hellmap, Action patch)> Scenes = new()
    {
        // ===== Prelude =====
        ["Level 0-1"] = (null, PatchLevel0_1),
        ["Level 0-2"] = (null, null),
        ["Level 0-3"] = (null, null),
        ["Level 0-4"] = (null, null),
        ["Level 0-5"] = (null, null),
        // ===== Act 1 =====
        ["Level 1-1"] = (PatchHellmapAct1, null),
        ["Level 1-2"] = (PatchHellmapAct1, null),
        ["Level 1-3"] = (PatchHellmapAct1, null),
        ["Level 1-4"] = (PatchHellmapAct1, null),
        ["Level 2-1"] = (PatchHellmapAct1, PatchLevel2_1),
        ["Level 2-2"] = (PatchHellmapAct1, null),
        ["Level 2-3"] = (PatchHellmapAct1, null),
        ["Level 2-4"] = (PatchHellmapAct1, null),
        ["Level 3-1"] = (PatchHellmapAct1, null),
        ["Level 3-2"] = (PatchHellmapAct1, null),
        // ===== Act 2 =====
        ["Level 4-1"] = (PatchHellmapAct2, null),
        ["Level 4-2"] = (PatchHellmapAct2, null),
        ["Level 4-3"] = (PatchHellmapAct2, null),
        ["Level 4-4"] = (PatchHellmapAct2, null),
        ["Level 5-1"] = (PatchHellmapAct2, null),
        ["Level 5-2"] = (PatchHellmapAct2, null),
        ["Level 5-3"] = (PatchHellmapAct2, PatchLevel5_3),
        ["Level 5-4"] = (PatchHellmapAct2, null),
        ["Level 6-1"] = (PatchHellmapAct2, null),
        ["Level 6-2"] = (PatchHellmapAct2, null),
        // ===== Act 3 =====
        ["Level 7-1"] = (PatchHellmapAct3, null),
        ["Level 7-2"] = (PatchHellmapAct3, PatchLevel7_2),
        ["Level 7-3"] = (PatchHellmapAct3, PatchLevel7_3),
        ["Level 7-4"] = (PatchHellmapAct3, PatchLevel7_4),
        ["Level 8-1"] = (PatchHellmapAct3, null),
        ["Level 8-2"] = (PatchHellmapAct3, PatchLevel8_2),
        ["Level 8-3"] = (PatchHellmapAct3, PatchLevel8_3),
        ["Level 8-4"] = (PatchHellmapAct3, PatchLevel8_4),
        ["Level 9-1"] = (PatchHellmapAct3, null),
        ["Level 9-2"] = (PatchHellmapAct3, null),
        // ===== Encores =====
        ["Level 0-E"] = (null, PatchLevel0_E),
        ["Level 1-E"] = (null, PatchLevel1_E),
        ["Level 2-E"] = (null, null),
        ["Level 3-E"] = (null, null),
        ["Level 4-E"] = (null, null),
        ["Level 5-E"] = (null, null),
        ["Level 6-E"] = (null, null),
        ["Level 7-E"] = (null, null),
        ["Level 8-E"] = (null, null),
        ["Level 9-E"] = (null, null),
        // ===== Secret Levels =====
        ["Level 0-S"] = (null, PatchLevel0_S),
        ["Level 1-S"] = (null, PatchLevel1_S),
        ["Level 2-S"] = (null, Act1Vn.PatchPrompts),
        ["Level 4-S"] = (null, PatchLevel4_S),
        ["Level 5-S"] = (null, PatchLevel5_S),
        ["Level 7-S"] = (null, PatchLevel7_S),
        // ===== Prime Sanctum =====
        ["Level P-1"] = (null, PrimeSanctum.Patch),
        ["Level P-2"] = (null, PrimeSanctum.Patch),
        ["Level P-3"] = (null, PrimeSanctum.Patch),
        // ===== Intermission =====
        ["Intermission1"] = (null, Intermission.Act1Int),
        ["Intermission2"] = (null, Intermission.Act2Int),
        ["EarlyAccessEnd"] = (null, Intermission.EarlyAccessEnd),
        // ===== Special Scene =====
        ["uk_construct"] = (null, Sandbox.Patch),
        ["Endless"] = (null, CyberGrind.PatchCg),
        ["CreditsMuseum2"] = (null, DevMuseum.Patch),
    };

    public static void Patch(string levelName, GameObject canvasObj)
    {
        string name = LevelStrings.GetLevelName(levelName);
        string challenge = LevelStrings.GetLevelChallenge(levelName);
        ResultsScreenLocalizer.PatchResultsScreen(name, challenge);
        
        if (Scenes.TryGetValue(levelName, out var scene))
        {
            scene.hellmap?.Invoke();
            scene.patch?.Invoke();
            return;
        }

        Logging.Warn("No patch defined for scene: " + levelName);
    }
}
