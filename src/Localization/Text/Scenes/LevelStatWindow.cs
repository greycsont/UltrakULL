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

        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_time, "Time Title");
        levelStatsWindow.Localize<TextMeshProUGUI>(
            GetCurrentSceneName() != "Endless" 
            ? CurrentLanguage.misc.levelstats_kills : CurrentLanguage.cyberGrind.cybergrind_wave, 
            "Kills Title");

        levelStatsWindow.Localize<TextMeshProUGUI>(
            GetCurrentSceneName() != "Endless" 
            ? CurrentLanguage.misc.levelstats_style : CurrentLanguage.cyberGrind.cybergrind_enemiesRemaining, 
            "Style Title");
        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_secrets, "Secrets Title");

        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_challenge, "Challenge Title");
        levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_majorAssists, "Assists Title");

        if (GetCurrentSceneName() == "Level 4-S")
        {
            levelStatsWindow.Localize<TextMeshProUGUI>(CurrentLanguage.misc.levelstats_boxes, "Crates Counter");
        }
    }
}
