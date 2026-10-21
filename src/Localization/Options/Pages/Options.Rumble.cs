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

    private static void PatchRumbleOptions(GameObject optionMenu)
    {
        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_title, path: ["Text (1)"]);

        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_finalMultiplier, path: ["Total", "Text"]);

        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, path: ["Close", "Text"]);

        //Loop through each entry
        GameObject rumbleEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < rumbleEntryList.transform.childCount; x++)
            {
                GameObject entry = rumbleEntryList.transform.GetChild(x).gameObject;
                //Throws an out of bounds error, but still swaps the text correctly...
                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_intensity, path: ["Button", "Text (1)"]);

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_reset, path: ["Default Button (1)", "Text"])
                    .ApplyLayout(UILayoutKeys.RumbleReset);

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_endDelay, path: ["End Delay Container", "Text (2)"]);

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.rumble_reset, path: ["End Delay Container", "Default Button", "Text"])
                    .ApplyLayout(UILayoutKeys.RumbleReset);
            }
        }
        catch (Exception)
        {
            Logging.Warn("Rumble options exception, should be harmless unless if console is spammed with this");
        }

    }
}
