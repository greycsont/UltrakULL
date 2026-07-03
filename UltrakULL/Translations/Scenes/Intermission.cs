using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL;

public class Intermission
{
    private void Act1Int(GameObject intermissionObject)
    {
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

    private void Act2Int(GameObject intermissionObject)
    {
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

    private void EarlyAccessEnd(GameObject intermissionObject)
    {
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

    public Intermission(ref GameObject canvasObj)
    {
        GameObject intermissionObject = FindDescendant(canvasObj, "PowerUpVignette", "Panel");

        switch (GetCurrentSceneName())
        {
            case "Intermission1": { Act1Int(intermissionObject);  break; }
            case "Intermission2": { Act2Int(intermissionObject);  break; }
            case "EarlyAccessEnd": { EarlyAccessEnd(FindDescendant(canvasObj, "UnderwaterOverlay", "Panel")); break; }
        }
    }
}
