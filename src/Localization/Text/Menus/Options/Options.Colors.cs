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

    private static void PatchColorsOptions(GameObject optionsMenu)
    {
        //Colors options
        //TextMeshProUGUI colorsPanel = GetTextMeshProUGUI(FindDescendant(optionsMenu, "Text (1)"));
        //colorsPanel.text = "--" + LanguageManager.CurrentLanguage.options.colors_title + "--";

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Default", "Text")), LanguageManager.CurrentLanguage.options.colors_reset);

        //HUD Text
        GameObject colorsHudObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "HUD");

        TryToReplaceText(GetTextMeshProUGUI(colorsHudObject), new[] { LanguageManager.CurrentLanguage.options.colors_hud }, "--" + LanguageManager.CurrentLanguage.options.colors_hud + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Health", "Text")), LanguageManager.CurrentLanguage.options.colors_hudHealth);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "HpText", "Text")), LanguageManager.CurrentLanguage.options.colors_hudHealthNumber);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "AfterImage", "Text")), LanguageManager.CurrentLanguage.options.colors_hudDamage);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "AntiHp", "Text")), LanguageManager.CurrentLanguage.options.colors_hudHardDamage);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Overheal", "Text")), LanguageManager.CurrentLanguage.options.colors_hudOverheal);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Stamina", "Text")), LanguageManager.CurrentLanguage.options.colors_hudEnergyFull);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "StaminaCharging", "Text")), LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "StaminaEmpty", "Text")), LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "RailcannonFull", "Text")), LanguageManager.CurrentLanguage.options.colors_railcannonFull);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "RailcannonCharging", "Text")), LanguageManager.CurrentLanguage.options.colors_railcannonPartial);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Blue Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationBlue);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Green Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationGreen);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Red Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationRed);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Gold Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationGold);

        //Enemy names text
        //Later down the line, could be better to get the names from EnemyBios.
        GameObject colorsEnemiesObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Enemies");

        TryToReplaceText(GetTextMeshProUGUI(colorsEnemiesObject), new[] { LanguageManager.CurrentLanguage.options.colors_enemies }, "--" + LanguageManager.CurrentLanguage.options.colors_enemies + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Filth", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_filth);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Stray", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_stray);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Malicious Face", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Schism", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_schism);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Swordsmachine", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Cerberus", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Drone", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_drone);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Streetcleaner", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Shotgunner", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "V2", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_v2);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Mindflayer", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Virtue", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Stalker", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Sisyphus", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Sentry", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Idol", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_idol);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Ferryman", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Mannequin", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_mannequin);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Gutterman", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_gutterman);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Guttertank", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_guttertank);

    }
}
