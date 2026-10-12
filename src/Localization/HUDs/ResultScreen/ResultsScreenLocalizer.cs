using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UltrakULL.json.LanguageManager;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

// See FinalRank.cs for more detail
// And DifficultTitle.cs
public static class ResultsScreenLocalizer
{
    /// <summary>
    /// YES, ALL GODDAMN LEVEL NEED IT FUCK
    /// May change to patch each sceneload for customlevel stuff?
    /// </summary>
    /// <param name="levelName">Display name, e.g. "0-1: INTO THE FIRE"</param>
    /// <param name="challenge">Challenge text for the current level</param>
    /// <param name="isSecret">Is current level are secret level e.g. Level 0-S etc</param>
    public static void PatchResultsScreen(string levelName, string challenge, bool isSecret)
    {
        var panel = FinalRank.Instance?.gameObject;

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_time, 
            path: ["ff", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_kills, 
            path: ["Kills - Info", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_style, 
            path: ["Style - Info", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_secrets, 
            path: ["Secrets -  Title", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_challenge, 
            path: ["Challenge - Title", "Text"]);

        panel.Localize<TextMeshProUGUI>(challenge, 
            path: ["Challenge", "ChallengeText"]);

        panel.Localize<TextMeshProUGUI>("{0}:".FormatWith(CurrentLanguage.cyberGrind.cybergrind_total), 
            path: ["Total Points", "Text (1)"]);

        panel.Localize<TextMeshProUGUI>("+0<color=orange>{0}</color>".FormatWith(CurrentLanguage.shop.shop_moneyCount), 
            path: ["Total Points", "Text"]);

        FindComponent<TextMeshProUGUI>(panel, "Title", "Text").RemoveWordWrap();

        // Secret levels use their own results panel: its title plus the completion labels.
        if (!isSecret)
            return;

        panel.Localize<TextMeshProUGUI>(levelName,
            path: ["Title", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.secretLevels.secretLevels_complete1,
            path: ["Time - Info", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.secretLevels.secretLevels_complete2,
            path: ["Time - Rank", "Text"]);
    }
}
