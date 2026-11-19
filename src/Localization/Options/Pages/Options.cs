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

    public static void PatchOptions(GameObject optionsMenu)
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
}
