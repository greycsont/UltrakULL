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

    private static void PatchSteamLeaderboard(GameObject optionMenu)
    {
        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_title, "Title");

        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_refreshButton, "Refresh Button", "Text");

        optionMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_returnButton, "Close", "Text");

        //Loop through each entry
        GameObject SteamEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < SteamEntryList.transform.childCount; x++) //Hardcoded, amount may increase in future updates
            {
                GameObject entry = SteamEntryList.transform.GetChild(x).gameObject;

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_anyLabel, "Any Label");

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_pLabel, "P Label");

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_reset, "Any Reset", "Text");

                entry.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_reset, "P Reset Button", "Text");
            }
        }
        catch (Exception e)
        {
            Logging.Error("Something went wrong while patching Steam Leaderboard.");
            Logging.Error(e.ToString());
        }

    }
}
