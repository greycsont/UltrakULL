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

    static public void PatchAssistOptions(GameObject optionsMenu)
    {
        //Assist options

        GameObject assistMajorAssistPanel = FindDescendant(optionsMenu, "Major Assists Consent", "Panel");

        //Major Assist Consent panel
        TextMeshProUGUI assistDisclaimerText = assistMajorAssistPanel.Localize<TextMeshProUGUI>("{0}\n\n{1}\n\n{2}".FormatWith(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer1,
            LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer2,
            LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer3), path: ["Description Block"]);
        if (assistDisclaimerText != null) assistDisclaimerText.fontSize = 18;

        TextMeshProUGUI assistDisclaimerConfirmText = assistMajorAssistPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirm, path: ["Summary"]);
        if (assistDisclaimerConfirmText != null) assistDisclaimerConfirmText.fontSize = 24;

        assistMajorAssistPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmYes, path: ["Yes", "Text"]);

        assistMajorAssistPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmNo, path: ["No", "Text"]);

        //Assist Options
        GameObject assistContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //-- MINOR ASSISTS --
        assistContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.assists_minor), path: ["-- Minor Assists --", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_autoAim, path: ["Auto Aim", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_autoAimPercent, path: ["Auto Aim Amount", "Text"]);

        SliderValueToText autoAimSlider = FindDescendant(assistContent, "Auto Aim Amount", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
        autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlines, path: ["Enemy Silhouettes", "Text"]);

        GameObject assistEnemySilhouettes = FindDescendant(assistContent, "Enemy Silhouettes"); 

        assistEnemySilhouettes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettes, path: ["Text"]);

        GameObject silhouetteList = FindDescendant(assistEnemySilhouettes, "Dropdown(Clone)");
        TMP_Dropdown silhouetteDropdown = silhouetteList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> silhouetteListText = silhouetteDropdown.options;
        silhouetteListText[0].Localize(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesNone);
        silhouetteListText[1].Localize(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly);
        silhouetteListText[2].Localize(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesFull);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistance, path: ["Activation Distance", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlineThickness, path: ["Outline Thickness", "Text"]);

        SliderValueToText assistEnemySilhouettesDistanceSlider = FindDescendant(assistContent, "Activation Distance", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        assistEnemySilhouettesDistanceSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistanceMinimum;

        //TextMeshProUGUI assistEnemySilhouettesOutlinesOnlyText = FindComponent<TextMeshProUGUI>(FindDescendant(assistEnemySilhouettesExtra, "Extra"), "Text (2)");
        //assistEnemySilhouettesOutlinesOnlyText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly;

        GameObject assistsMajorTitleObject = FindDescendant(assistContent, "-- Major Assists --");

        //-- MAJOR ASSISTS --
        TextMeshProUGUI assistsMajorTitle = assistsMajorTitleObject.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.assists_major), path: ["Text"]);
        if (assistsMajorTitle != null) assistsMajorTitle.fontSize = 20;
        assistsMajorTitleObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorActivate, path: ["Enable Group", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_gameSpeed, path: ["Game Speed", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_damageTaken, path: ["Damage Taken", "Text"]);

        GameObject bossOverride = FindDescendant(assistContent, "Boss Fight Difficulty Override");

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_bossOverride, path: ["Boss Fight Difficulty Override", "Text"]);

        bossOverride.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_bossRestartRequired, path: ["Side Note"]);

        TMP_Dropdown bossOverrideDropdown = FindComponent<TMP_Dropdown>(bossOverride, "Dropdown(Clone)");
        List<TMP_Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

        bossOverrideDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.assists_bossOverrideNone);
        bossOverrideDropdownListText[1].Localize(LanguageManager.CurrentLanguage.frontend.difficulty_harmless);
        bossOverrideDropdownListText[2].Localize(LanguageManager.CurrentLanguage.frontend.difficulty_lenient);
        bossOverrideDropdownListText[3].Localize(LanguageManager.CurrentLanguage.frontend.difficulty_standard);
        bossOverrideDropdownListText[4].Localize(LanguageManager.CurrentLanguage.frontend.difficulty_violent);
        bossOverrideDropdownListText[5].Localize(LanguageManager.CurrentLanguage.frontend.difficulty_brutal);
        //bossOverrideDropdownListText[6].text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_infiniteEnergy, path: ["Infinite Stamina", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disableWhiplashHardDamage, path: ["Disable Whiplash Hard Damage", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disableHardDamage, path: ["Disable All Hard Damage", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disableWeaponFreshness, path: ["Disable Weapon Freshness", "Text"]);

        assistContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disablePopupHints, path: ["Disable Assist Popup", "Text"]);
    }
}
