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
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_title, optionMenu, "Title");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_refreshButton, optionMenu, "Refresh Button", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_returnButton, optionMenu, "Close", "Text");

        //Loop through each entry
        GameObject SteamEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < SteamEntryList.transform.childCount; x++) //Hardcoded, amount may increase in future updates
            {
                GameObject entry = SteamEntryList.transform.GetChild(x).gameObject;

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_anyLabel, entry, "Any Label");

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_pLabel, entry, "P Label");

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_reset, entry, "Any Reset", "Text");

                TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.steamLeaderboard_reset, entry, "P Reset Button", "Text");
            }
        }
        catch (Exception e)
        {
            Logging.Error("Something went wrong while patching Steam Leaderboard.");
            Logging.Error(e.ToString());
        }

    }
}
