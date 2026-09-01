using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class LevelPatcher
{
    // ===== Hellmaps (one per act) =====

    private static void PatchHellmapAct1(GameObject canvasObj)
    {
        GameObject hellMapObject = FindDescendant(canvasObj, "Hellmap", "Hellmap Act 1");
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text")).text = LanguageManager.CurrentLanguage.misc.hellmap_limbo;
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (1)")).text = LanguageManager.CurrentLanguage.misc.hellmap_lust;
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (2)")).text = LanguageManager.CurrentLanguage.misc.hellmap_gluttony;
    }

    private static void PatchHellmapAct2(GameObject canvasObj)
    {
        GameObject hellMapObject = FindDescendant(canvasObj, "Hellmap", "Hellmap Act 2");
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text")).text = LanguageManager.CurrentLanguage.misc.hellmap_greed;
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (1)")).text = LanguageManager.CurrentLanguage.misc.hellmap_wrath;
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (2)")).text = LanguageManager.CurrentLanguage.misc.hellmap_heresy;
    }

    private static void PatchHellmapAct3(GameObject canvasObj)
    {
        GameObject hellMapObject = FindDescendant(canvasObj, "Hellmap", "Hellmap Act 3");
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text")).text = LanguageManager.CurrentLanguage.misc.hellmap_violence;
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (1)")).text = LanguageManager.CurrentLanguage.misc.hellmap_fraud;
        GetTextMeshProUGUI(FindDescendant(hellMapObject, "Text (2)")).text = LanguageManager.CurrentLanguage.misc.hellmap_treachery;
    }
}
