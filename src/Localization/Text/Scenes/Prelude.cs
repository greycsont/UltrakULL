using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class Prelude
{
    private static void PatchOpeningCredits(ref GameObject canvasObj)
    {
        GameObject openingCredsParent = FindDescendant(canvasObj, "HurtScreen");

        TextMeshProUGUI openingCredsFirst = GetTextMeshProUGUI(FindDescendant(openingCredsParent, "Text 1 Sound", "Text (1)"));
        openingCredsFirst.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits1;

        TextMeshProUGUI openingCredsSecond = GetTextMeshProUGUI(FindDescendant(openingCredsParent, "Text 2 Sound", "Text (2)"));
        openingCredsSecond.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits2;
    }

    public static void Patch(ref GameObject level)
    {
        string currentLevel = GetCurrentSceneName();

        if (currentLevel == "Level 0-1")
        {
            try
            {
                PatchOpeningCredits(ref level);

            }
            catch(Exception e)
            {
                Logging.Warn("Failed to patch opening credits in 0-1");
                Logging.Warn(e.ToString());
            }
        }
        
        string levelName = LevelStrings.GetLevelName();
        string levelChallenge = LevelStrings.GetLevelChallenge(currentLevel);

        ResultsScreenLocalizer.PatchResultsScreen(levelName,levelChallenge);
    }
}