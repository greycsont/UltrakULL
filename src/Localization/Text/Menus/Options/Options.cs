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

    private static void PatchOptions(GameObject optionsMenu)
    {
        PatchNavigation(optionsMenu);

        SafeRun.Run(
            "Options: Saves",
            () => PatchSavesOptions(
                FindDescendant(optionsMenu, "Save Slots")));

        SafeRun.Run(
            "Options: Colors",
            () => PatchColorsOptions(
                FindDescendant(optionsMenu, "Pages", "ColorBlindness Options")));

        SafeRun.Run(
            "Options: Rumble",
            () => PatchRumbleOptions(
                FindDescendant(optionsMenu, "Rumble Settings")));

        SafeRun.Run(
            "Options: Advanced",
            () => PatchAdvancedOptions(
                FindDescendant(optionsMenu, "Advanced Options")));

        SafeRun.Run(
            "Options: Steam leaderboard",
            () => PatchSteamLeaderboard(
                FindDescendant(optionsMenu, "Leaderboard Manager")));
    }

    public static void Patch(GameObject game)
    {
        //Options are in two different locations.
        //On the main menu, it's root/Canvas/OptionsMenu.
        //In-game it's root/Canvas/OptionsMenu.
        GameObject optionsMenu;
        if (GetCurrentSceneName() == "Main Menu")
        {
            optionsMenu = FindDescendant(game, "OptionsMenu");
        }
        else
        {
            List<GameObject> rootObjects = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
            GameObject pauseObject = null;
            foreach (GameObject a in rootObjects)
            {
                if (a.gameObject.name == "Canvas")
                {
                    pauseObject = a.gameObject;
                    break;
                }
            }
            optionsMenu = FindDescendant(pauseObject, "OptionsMenu");
        }
        PatchOptions(optionsMenu);
    }
}
