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
        //TextMeshProUGUI colorsPanel = FindComponent<TextMeshProUGUI>(optionsMenu, "Text (1)");
        //colorsPanel.text = "--" + LanguageManager.CurrentLanguage.options.colors_title + "--";

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_reset, optionsMenu, "Scroll Rect", "Contents", "Default", "Text");

        //HUD Text
        GameObject colorsHudObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "HUD");

        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("--{0}--", LanguageManager.CurrentLanguage.options.colors_hud), colorsHudObject);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHealth, colorsHudObject, "Health", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHealthNumber, colorsHudObject, "HpText", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudDamage, colorsHudObject, "AfterImage", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudHardDamage, colorsHudObject, "AntiHp", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudOverheal, colorsHudObject, "Overheal", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyFull, colorsHudObject, "Stamina", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial, colorsHudObject, "StaminaCharging", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty, colorsHudObject, "StaminaEmpty", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_railcannonFull, colorsHudObject, "RailcannonFull", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_railcannonPartial, colorsHudObject, "RailcannonCharging", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationBlue, colorsHudObject, "Blue Variation", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationGreen, colorsHudObject, "Green Variation", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationRed, colorsHudObject, "Red Variation", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.colors_variationGold, colorsHudObject, "Gold Variation", "Text");

        //Enemy names text
        //Later down the line, could be better to get the names from EnemyBios.
        GameObject colorsEnemiesObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Enemies");

        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("--{0}--", LanguageManager.CurrentLanguage.options.colors_enemies), colorsEnemiesObject);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_filth, colorsEnemiesObject, "Filth", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_stray, colorsEnemiesObject, "Stray", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace, colorsEnemiesObject, "Malicious Face", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_schism, colorsEnemiesObject, "Schism", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine, colorsEnemiesObject, "Swordsmachine", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus, colorsEnemiesObject, "Cerberus", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_drone, colorsEnemiesObject, "Drone", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner, colorsEnemiesObject, "Streetcleaner", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier, colorsEnemiesObject, "Shotgunner", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_v2, colorsEnemiesObject, "V2", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer, colorsEnemiesObject, "Mindflayer", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue, colorsEnemiesObject, "Virtue", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker, colorsEnemiesObject, "Stalker", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist, colorsEnemiesObject, "Sisyphus", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry, colorsEnemiesObject, "Sentry", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_idol, colorsEnemiesObject, "Idol", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman, colorsEnemiesObject, "Ferryman", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_mannequin, colorsEnemiesObject, "Mannequin", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_gutterman, colorsEnemiesObject, "Gutterman", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.enemyNames.enemyname_guttertank, colorsEnemiesObject, "Guttertank", "Text");

    }
}
