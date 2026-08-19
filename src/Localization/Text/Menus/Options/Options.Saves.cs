using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{

    static public void PatchSavesOptions(GameObject optionMenu)
    {
        //Save options
        GameObject saveReloadPanel = FindDescendant(optionMenu, "Reload Consent Blocker", "Consent", "Panel");
        
        saveReloadPanel.Localize<TextMeshProUGUI>("<color=red>{0}</color>\n\n{1}".FormatWith(LanguageManager.CurrentLanguage.options.save_warning1,
            LanguageManager.CurrentLanguage.options.save_warning2), "Text");
        saveReloadPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_reloadYes, "Yes", "Text");
        saveReloadPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_reloadNo, "No", "Text");
        
        GameObject saveDeletePanel = FindDescendant(optionMenu, "Wipe Consent Blocker", "Consent", "Panel");
        
        saveDeletePanel.Localize<TextMeshProUGUI>("<color=red>{0}</color>".FormatWith(LanguageManager.CurrentLanguage.options.save_deleteYes), "Yes", "Text");

        saveDeletePanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_deleteNo, "No", "Text");

        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, "Close", "Text");
    }
    //general end
}
