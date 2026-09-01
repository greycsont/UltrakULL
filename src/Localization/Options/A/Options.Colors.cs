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

        optionsMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_reset, path: ["Scroll Rect", "Contents", "Default", "Text"]);

        //HUD Text
        GameObject colorsHudObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "HUD");

        //-- HUD --
        colorsHudObject.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.colors_hud), path: null);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHealth, path: ["Health", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHealthNumber, path: ["HpText", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudDamage, path: ["AfterImage", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHardDamage, path: ["AntiHp", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudOverheal, path: ["Overheal", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyFull, path: ["Stamina", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial, path: ["StaminaCharging", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty, path: ["StaminaEmpty", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_railcannonFull, path: ["RailcannonFull", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_railcannonPartial, path: ["RailcannonCharging", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationBlue, path: ["Blue Variation", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationGreen, path: ["Green Variation", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationRed, path: ["Red Variation", "Text"]);

        colorsHudObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationGold, path: ["Gold Variation", "Text"]);

        //Enemy names text
        //Later down the line, could be better to get the names from EnemyBios.
        GameObject colorsEnemiesObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Enemies");

        //-- ENEMY SILIHOUETTES --
        colorsEnemiesObject.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.colors_enemies), path: null);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_filth, path: ["Filth", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_stray, path: ["Stray", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace, path: ["Malicious Face", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_schism, path: ["Schism", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine, path: ["Swordsmachine", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus, path: ["Cerberus", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_drone, path: ["Drone", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner, path: ["Streetcleaner", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier, path: ["Shotgunner", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_v2, path: ["V2", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer, path: ["Mindflayer", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue, path: ["Virtue", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker, path: ["Stalker", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist, path: ["Sisyphus", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry, path: ["Sentry", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_idol, path: ["Idol", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman, path: ["Ferryman", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_mannequin, path: ["Mannequin", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_gutterman, path: ["Gutterman", "Text"], uppercase: true);

        colorsEnemiesObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_guttertank, path: ["Guttertank", "Text"], uppercase: true);

    }
}
