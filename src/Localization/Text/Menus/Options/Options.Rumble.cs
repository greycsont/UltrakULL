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

    private static void PatchRumbleOptions(GameObject optionMenu)
    {
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_title, optionMenu, "Text (1)");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_finalMultiplier, optionMenu, "Total", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, optionMenu, "Close", "Text");

        //Loop through each entry
        GameObject rumbleEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < rumbleEntryList.transform.childCount; x++)
            {
                GameObject entry = rumbleEntryList.transform.GetChild(x).gameObject;
                //Throws an out of bounds error, but still swaps the text correctly...
                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_intensity, entry, "Button", "Text (1)");

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_reset, entry, "Default Button (1)", "Text");

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_endDelay, entry, "End Delay Container", "Text (2)");

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_reset, entry, "End Delay Container", "Default Button", "Text");
            }
        }
        catch (Exception)
        {
            Logging.Warn("Rumble options exception, should be harmless unless if console is spammed with this");
        }

    }
}
