using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class Intermission
{
    public static void Act1Int()
    {
        var intermissionObject = GetObject("Canvas", "PowerUpVignette", "Panel");
        //ACT 1
        //Two text elements to patch: Foreground and background shadow.
        Text toBeContinued = GetTextfromGameObject(FindDescendant(intermissionObject, "Panel (1)", "Text", "Text (1)"));
        toBeContinued.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_tobecontinued;

        Text tobeContinuedShadow = GetTextfromGameObject(FindDescendant(intermissionObject, "Panel (1)", "Text"));
        tobeContinuedShadow.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_tobecontinuedshadow;

        GameObject act1EndObject = FindDescendant(intermissionObject, "Act End Message", "Sound 1");

        Text act1EndText = GetTextfromGameObject(FindDescendant(act1EndObject, "Text"));
        act1EndText.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_endof + "\n\n" + LanguageManager.CurrentLanguage.intermission.act1_intermission_insertAct2;
        
        Text act1EndMenu = GetTextfromGameObject(FindDescendant(act1EndObject, "Menu", "Text"));
        act1EndMenu.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_returnToMenu;

        Text act1EndInsert = GetTextfromGameObject(FindDescendant(act1EndObject, "Insert", "Text"));
        act1EndInsert.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_insert;
    }

    public static void Act2Int()
    {
        var intermissionObject = GetObject("Canvas", "PowerUpVignette", "Panel");
        
        Text toBeContinued = GetTextfromGameObject(FindDescendant(intermissionObject, "Panel (1)", "Text", "Text (1)"));
        toBeContinued.text = LanguageManager.CurrentLanguage.intermission.act2_intermission_tobecontinued;

        Text tobeContinuedShadow = GetTextfromGameObject(FindDescendant(intermissionObject, "Panel (1)", "Text"));
        tobeContinuedShadow.text = LanguageManager.CurrentLanguage.intermission.act2_intermission_tobecontinuedshadow;
        
        GameObject act2EndObject = FindDescendant(intermissionObject, "Act End Message", "Sound 1");

        Text act2EndText = GetTextfromGameObject(FindDescendant(act2EndObject, "Text"));
        act2EndText.text = LanguageManager.CurrentLanguage.intermission.act2_intermission_endof + "\n\n\n\n" + LanguageManager.CurrentLanguage.intermission.act2_intermission_insertAct3;
        
        Text act2EndMenu = GetTextfromGameObject(FindDescendant(act2EndObject, "Menu", "Text"));
        act2EndMenu.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_returnToMenu;

        Text act2EndInsert = GetTextfromGameObject(FindDescendant(act2EndObject, "Insert", "Text"));
        act2EndInsert.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_insert;
    }

    public static void EarlyAccessEnd()
    {
        var intermissionObject = GetObject("Canvas", "UnderwaterOverlay", "Panel");
        
        GameObject earlyAccessEnd = FindDescendant(intermissionObject, "Skippables");
        if (earlyAccessEnd != null)
        {
            TextMeshProUGUI earlyAccessEndText = GetTextMeshProUGUI(FindDescendant(earlyAccessEnd, "Text"));

            earlyAccessEndText.text =
                "<size=48><b>" + LanguageManager.CurrentLanguage.misc.earlyAccessEnd1 + "</b></size>" + "\n\n"
                + LanguageManager.CurrentLanguage.misc.earlyAccessEnd2 + "\n\n"
                + LanguageManager.CurrentLanguage.misc.earlyAccessEnd3;

            TextMeshProUGUI earlyAccessQuitToMenu = GetTextMeshProUGUI(FindDescendant(earlyAccessEnd, "Quit Mission", "Text"));
            earlyAccessQuitToMenu.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_returnToMenu;
        }
    }
}
