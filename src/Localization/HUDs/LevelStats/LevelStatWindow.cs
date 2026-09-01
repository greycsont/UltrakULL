using TMPro;
using UnityEngine;

using UltrakULL.json;

using static UltrakULL.SceneObjects;

using static UltrakULL.json.LanguageManager;

namespace UltrakULL;

public static class LevelStatWindow
{
    public static void PatchStats(GameObject canvasObj)
    {
        GameObject levelStatsWindow = FindDescendant(canvasObj, "Level Stats Controller", "Level Stats (1)");

        FindComponent<TextMeshProUGUI>(levelStatsWindow, "Title").ApplyLayout(UILayoutKeys.LevelStatsTitle);

        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_time, path: ["Time Title"]);

        levelStatsWindow.Localize<TextMeshProUGUI>(
            GetCurrentSceneName() != "Endless" 
            ? CurrentLanguage.misc.levelstats_kills : CurrentLanguage.cyberGrind.cybergrind_wave, 
            path: ["Kills Title"]);
        levelStatsWindow.Localize<TextMeshProUGUI>(
            GetCurrentSceneName() != "Endless" 
            ? CurrentLanguage.misc.levelstats_style : CurrentLanguage.cyberGrind.cybergrind_enemiesRemaining, 
            path: ["Style Title"]);
            
        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_secrets, path: ["Secrets Title"]);

        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_challenge, path: ["Challenge Title"]);
        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_majorAssists, path: ["Assists Title"]);

        if (GetCurrentSceneName() == "Level 4-S")
        {
            levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_boxes, path: ["Crates Counter"]);
        }
    }
}
