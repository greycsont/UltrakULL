using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

[NeedRework]
public static class LevelStatWindow
{
    public static void PatchStats(GameObject canvasObj)
    {
        GameObject levelStatsWindow = FindDescendant(canvasObj, "Level Stats Controller", "Level Stats (1)");
        
        TextMeshProUGUI levelName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Title"));
        levelName.text = LevelNames.GetDiscordLevelName(GetCurrentSceneName());

        //Secret levels will only have a timer, or something else.
        TextMeshProUGUI timeName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Time Title"));
        timeName.text = LanguageManager.CurrentLanguage.misc.levelstats_time; 

        TextMeshProUGUI killsName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Kills Title"));
        killsName.text = LanguageManager.CurrentLanguage.misc.levelstats_kills;

        TextMeshProUGUI styleName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Style Title"));
        styleName.text = LanguageManager.CurrentLanguage.misc.levelstats_style;

        TextMeshProUGUI secretsName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Secrets Title"));
        secretsName.text = LanguageManager.CurrentLanguage.misc.levelstats_secrets;

        TextMeshProUGUI challengesName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Challenge Title"));
        challengesName.text = LanguageManager.CurrentLanguage.misc.levelstats_challenge;

        TextMeshProUGUI assistsName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Assists Title"));
        assistsName.text = LanguageManager.CurrentLanguage.misc.levelstats_majorAssists;

        if (GetCurrentSceneName() == "Level 4-S")
        {
            TextMeshProUGUI cratesName = GetTextMeshProUGUI(FindDescendant(levelStatsWindow, "Crates Counter"));
            cratesName.text = LanguageManager.CurrentLanguage.misc.levelstats_boxes;
        }
    }
}
