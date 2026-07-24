using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using static UltrakULL.TextReplacer;

namespace UltrakULL;

public static partial class Options
{

    static public void PatchSavesOptions(GameObject optionMenu)
    {
        //Save options
        GameObject saveReloadPanel = FindDescendant(optionMenu, "Reload Consent Blocker", "Consent", "Panel");
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveReloadPanel, "Text")),
            new[] { LanguageManager.CurrentLanguage.options.save_warning1, LanguageManager.CurrentLanguage.options.save_warning2 },
            "<color=red>" + LanguageManager.CurrentLanguage.options.save_warning1 + "</color>\n\n" + LanguageManager.CurrentLanguage.options.save_warning2);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveReloadPanel, "Yes", "Text")), LanguageManager.CurrentLanguage.options.save_reloadYes);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveReloadPanel, "No", "Text")), LanguageManager.CurrentLanguage.options.save_reloadNo);
        
        GameObject saveDeletePanel = FindDescendant(optionMenu, "Wipe Consent Blocker", "Consent", "Panel");
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveDeletePanel, "Yes", "Text")), new[] { LanguageManager.CurrentLanguage.options.save_deleteYes }, "<color=red>" + LanguageManager.CurrentLanguage.options.save_deleteYes + "</color>");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveDeletePanel, "No", "Text")), LanguageManager.CurrentLanguage.options.save_deleteNo);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Close", "Text")), LanguageManager.CurrentLanguage.options.save_close);
    }
    //general end
}
