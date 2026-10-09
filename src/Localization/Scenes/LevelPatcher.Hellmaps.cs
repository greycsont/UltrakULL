using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;
using static UltrakULL.json.LanguageManager;
namespace UltrakULL;

public static partial class LevelPatcher
{
    // ===== Hellmaps (one per act) =====

    private static void PatchHellmapAct1()
    {
        var hellMapObject = GetObject("Canvas", "Hellmap", "Hellmap Act 1");
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_limbo,
            path: ["Text"]);
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_lust,
            path: ["Text (1)"]);
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_gluttony,
            path: ["Text (2)"]);
    }

    private static void PatchHellmapAct2()
    {
        var hellMapObject = GetObject("Canvas", "Hellmap", "Hellmap Act 2");
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_greed,
            path: ["Text"]);
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_wrath,
            path: ["Text (1)"]);
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_heresy,
            path: ["Text (2)"]);
    }

    private static void PatchHellmapAct3()
    {
        var hellMapObject = GetObject("Canvas", "Hellmap", "Hellmap Act 3");
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_violence,
            path: ["Text"]);
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_fraud,
            path: ["Text (1)"]);
        hellMapObject.Localize<TextMeshProUGUI>(CurrentLanguage.misc.hellmap_treachery,
            path: ["Text (2)"]);;
    }
}
