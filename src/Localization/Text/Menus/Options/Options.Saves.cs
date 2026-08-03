using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.TextReplacer;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{

    static public void PatchSavesOptions(GameObject optionMenu)
    {
        //Save options
        GameObject saveReloadPanel = FindDescendant(optionMenu, "Reload Consent Blocker", "Consent", "Panel");
        
        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("<color=red>{0}</color>\n\n{1}",
            LanguageManager.CurrentLanguage.options.save_warning1,
            LanguageManager.CurrentLanguage.options.save_warning2), saveReloadPanel, "Text");
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_reloadYes, saveReloadPanel, "Yes", "Text");
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_reloadNo, saveReloadPanel, "No", "Text");
        
        GameObject saveDeletePanel = FindDescendant(optionMenu, "Wipe Consent Blocker", "Consent", "Panel");
        
        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("<color=red>{0}</color>", LanguageManager.CurrentLanguage.options.save_deleteYes), saveDeletePanel, "Yes", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_deleteNo, saveDeletePanel, "No", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, optionMenu, "Close", "Text");
    }
    //general end
}
