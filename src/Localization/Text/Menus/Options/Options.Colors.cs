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

    private static void PatchColorsOptions(GameObject optionsMenu)
    {
        //Colors options
        //TextMeshProUGUI colorsPanel = FindComponent<TextMeshProUGUI>(optionsMenu, "Text (1)");
        //colorsPanel.text = "--" + LanguageManager.CurrentLanguage.options.colors_title + "--";

        optionsMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_reset, "Scroll Rect", "Contents", "Default", "Text");

        //HUD Text
        GameObject colorsHudObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "HUD");

        //-- HUD --
        colorsHudObject.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.colors_hud));

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHealth, "Health", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHealthNumber, "HpText", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudDamage, "AfterImage", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHardDamage, "AntiHp", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudOverheal, "Overheal", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyFull, "Stamina", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial, "StaminaCharging", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty, "StaminaEmpty", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_railcannonFull, "RailcannonFull", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_railcannonPartial, "RailcannonCharging", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationBlue, "Blue Variation", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationGreen, "Green Variation", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationRed, "Red Variation", "Text");

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationGold, "Gold Variation", "Text");

        //Enemy names text
        //Later down the line, could be better to get the names from EnemyBios.
        GameObject colorsEnemiesObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Enemies");

        //-- ENEMY SILIHOUETTES --
        colorsEnemiesObject.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.colors_enemies));

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_filth, "Filth", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_stray, "Stray", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace, "Malicious Face", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_schism, "Schism", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine, "Swordsmachine", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus, "Cerberus", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_drone, "Drone", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner, "Streetcleaner", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier, "Shotgunner", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_v2, "V2", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer, "Mindflayer", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue, "Virtue", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker, "Stalker", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist, "Sisyphus", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry, "Sentry", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_idol, "Idol", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman, "Ferryman", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_mannequin, "Mannequin", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_gutterman, "Gutterman", "Text");

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_guttertank, "Guttertank", "Text");

    }
}
