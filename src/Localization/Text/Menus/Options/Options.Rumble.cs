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
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Text (1)")), LanguageManager.CurrentLanguage.options.rumble_title);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Total", "Text")), LanguageManager.CurrentLanguage.options.rumble_finalMultiplier);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Close", "Text")), LanguageManager.CurrentLanguage.options.save_close);

        //Loop through each entry
        GameObject rumbleEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < rumbleEntryList.transform.childCount; x++)
            {
                GameObject entry = rumbleEntryList.transform.GetChild(x).gameObject;
                //Throws an out of bounds error, but still swaps the text correctly...
                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Button", "Text (1)")), LanguageManager.CurrentLanguage.options.rumble_intensity);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Default Button (1)", "Text")), LanguageManager.CurrentLanguage.options.rumble_reset);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "End Delay Container", "Text (2)")), LanguageManager.CurrentLanguage.options.rumble_endDelay);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "End Delay Container", "Default Button", "Text")), LanguageManager.CurrentLanguage.options.rumble_reset);
            }
        }
        catch (Exception)
        {
            Logging.Warn("Rumble options exception, should be harmless unless if console is spammed with this");
        }

    }
}
