using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.audio;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class Act2
{
    private static void PatchHellmap(ref GameObject canvasObj)
    {
        GameObject hellMapObject = FindDescendant(canvasObj, "Hellmap", "Hellmap Act 2");
        
        TextMeshProUGUI hellmapGreed = GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text"));
        hellmapGreed.text = LanguageManager.CurrentLanguage.misc.hellmap_greed;

        TextMeshProUGUI hellmapWrath = GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (1)"));
        hellmapWrath.text = LanguageManager.CurrentLanguage.misc.hellmap_wrath;

        TextMeshProUGUI hellmapHeresy = GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (2)"));
        hellmapHeresy.text = LanguageManager.CurrentLanguage.misc.hellmap_heresy;
    }

    public static void PatchAct2(ref GameObject canvasObj)
    {
        string currentLevel = GetCurrentSceneName();
        string levelName = LevelStrings.GetLevelName();
        string levelChallenge = LevelStrings.GetLevelChallenge(currentLevel);
        
        ResultsScreenLocalizer.PatchResultsScreen(levelName, levelChallenge);
        PatchHellmap(ref canvasObj);
    }
}
