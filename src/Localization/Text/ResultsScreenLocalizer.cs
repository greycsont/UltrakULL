using TMPro;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

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

        GetTextMeshProUGUI(
            FindDescendant(panel, "ff", "Text")).text =
            LanguageManager.CurrentLanguage.misc.stats_time;

        GetTextMeshProUGUI(
            FindDescendant(panel, "Kills - Info", "Text")).text =
            LanguageManager.CurrentLanguage.misc.stats_kills;

        GetTextMeshProUGUI(
            FindDescendant(panel, "Style - Info", "Text")).text =
            LanguageManager.CurrentLanguage.misc.stats_style;

        GetTextMeshProUGUI(
            FindDescendant(panel, "Secrets -  Title", "Text")).text =
            LanguageManager.CurrentLanguage.misc.stats_secrets;

        GetTextMeshProUGUI(
            FindDescendant(panel, "Challenge - Title", "Text")).text =
            LanguageManager.CurrentLanguage.misc.stats_challenge;

        GetTextMeshProUGUI(
            FindDescendant(panel, "Challenge", "ChallengeText")).text =
            challenge;

        GetTextMeshProUGUI(
            FindDescendant(panel, "Total Points", "Text (1)")).text =
            LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total + ":";
    }
}
