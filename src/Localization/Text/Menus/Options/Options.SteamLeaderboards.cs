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

    private static void PatchSteamLeaderboard(GameObject optionMenu)
    {
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Title")), LanguageManager.CurrentLanguage.options.steamLeaderboard_title);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Refresh Button", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_refreshButton);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Close", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_returnButton);

        //Loop through each entry
        GameObject SteamEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < SteamEntryList.transform.childCount; x++) //Hardcoded, amount may increase in future updates
            {
                GameObject entry = SteamEntryList.transform.GetChild(x).gameObject;

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Any Label")), LanguageManager.CurrentLanguage.options.steamLeaderboard_anyLabel);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "P Label")), LanguageManager.CurrentLanguage.options.steamLeaderboard_pLabel);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Any Reset", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_reset);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "P Reset Button", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_reset);
            }
        }
        catch (Exception e)
        {
            Logging.Error("Something went wrong while patching Steam Leaderboard.");
            Logging.Error(e.ToString());
        }

    }
}
