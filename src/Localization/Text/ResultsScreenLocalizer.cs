using TMPro;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.json.LanguageManager;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

// See FinalRank.cs for more detail
public static class ResultsScreenLocalizer
{
    /// <summary>
    /// YES, ALL GODDAMN LEVEL NEED IT FUCK
    /// May change to patch each sceneload for customlevel stuff?
    /// </summary>
    /// <param name="name"></param>
    /// <param name="challenge"></param>
    public static void PatchResultsScreen(string name, string challenge)
    {
        GameObject player = GameObject.Find("Player");
        GameObject panel = FindDescendant(
            player, "Main Camera", "HUD Camera", "HUD", "FinishCanvas", "Panel");

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_time, path: ["ff", "Text"]);
        
        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_kills, path: ["Kills - Info", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_style, path: ["Style - Info", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_secrets, path: ["Secrets -  Title", "Text"]);

        panel.Localize<TextMeshProUGUI>(CurrentLanguage.misc.stats_challenge, path: ["Challenge - Title", "Text"]);

        panel.Localize<TextMeshProUGUI>(challenge, path: ["Challenge", "ChallengeText"]);

        panel.Localize<TextMeshProUGUI>("{0}:".FormatWith(CurrentLanguage.cyberGrind.cybergrind_total), path: ["Total Points", "Text (1)"]);

        panel.Localize<TextMeshProUGUI>("+0<color=orange>{0}</color>".FormatWith(CurrentLanguage.shop.shop_moneyCount), 
            path: ["Total Points", "Text"]);

        FindComponent<TextMeshProUGUI>(panel, "Title", "Text").RemoveWordWrap();
    }
}
