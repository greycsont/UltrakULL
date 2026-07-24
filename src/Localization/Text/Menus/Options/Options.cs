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

    private static void PatchOptions(GameObject optionsMenu)
    {
        if (optionsMenu != null)
        {
            PatchNavigation(optionsMenu);

            try
            {
                GameObject savesOptions = FindDescendant(optionsMenu, "Save Slots");
                try { PatchSavesOptions(savesOptions); } catch (Exception e) { Logging.Error("Failed to patch save options."); Logging.Error(e.ToString()); }
                GameObject colorblindOptions = FindDescendant(optionsMenu, "Pages", "ColorBlindness Options");
                try { PatchColorsOptions(colorblindOptions); } catch (Exception e) { Logging.Error("Failed to patch color options."); Logging.Error(e.ToString()); }
                GameObject rumbleOptions = FindDescendant(optionsMenu, "Rumble Settings");
                try { PatchRumbleOptions(rumbleOptions); } catch (Exception e) { Logging.Error("Failed to patch rumble options."); Logging.Error(e.ToString()); }
                GameObject advancedOptions = FindDescendant(optionsMenu, "Advanced Options");
                try { PatchAdvancedOptions(advancedOptions); } catch (Exception e) { Logging.Error("Failed to patch advanced options."); Logging.Error(e.ToString()); }
                GameObject steamOptions = FindDescendant(optionsMenu, "Leaderboard Manager");
                try { PatchSteamLeaderboard(steamOptions); } catch (Exception e) { Logging.Error("Failed to patch steam leaderboard."); Logging.Error(e.ToString()); }
            }
            catch (Exception e)
            {
                Logging.Error("Something went wrong while patching options.");
                Logging.Error(e.ToString());
            }

        }
        else
        {
            Logging.Error("An error occured while patching options menu");
        }

    }

    public static void Patch(ref GameObject game)
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
