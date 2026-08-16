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

    static public void PatchAssistOptions(GameObject optionsMenu)
    {
        //Assist options

        GameObject assistMajorAssistPanel = FindDescendant(optionsMenu, "Major Assists Consent", "Panel");

        //Major Assist Consent panel
        TextMeshProUGUI assistDisclaimerText = TryReplaceText<TextMeshProUGUI>(StringHelper.Format("{0}\n\n{1}\n\n{2}",
            LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer1,
            LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer2,
            LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer3), assistMajorAssistPanel, "Description Block");
        if (assistDisclaimerText != null) assistDisclaimerText.fontSize = 18;

        TextMeshProUGUI assistDisclaimerConfirmText = TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirm, assistMajorAssistPanel, "Summary");
        if (assistDisclaimerConfirmText != null) assistDisclaimerConfirmText.fontSize = 24;

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmYes, assistMajorAssistPanel, "Yes", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmNo, assistMajorAssistPanel, "No", "Text");

        //Assist Options
        GameObject assistContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //-- MINOR ASSISTS --
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.assists_minor), assistContent, "-- Minor Assists --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_autoAim, assistContent, "Auto Aim", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_autoAimPercent, assistContent, "Auto Aim Amount", "Text");

        SliderValueToText autoAimSlider = FindDescendant(assistContent, "Auto Aim Amount", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
        autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlines, assistContent, "Enemy Silhouettes", "Text");

        GameObject assistEnemySilhouettes = FindDescendant(assistContent, "Enemy Silhouettes"); 

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettes, assistEnemySilhouettes, "Text");

        GameObject silhouetteList = FindDescendant(assistEnemySilhouettes, "Dropdown(Clone)");
        TMP_Dropdown silhouetteDropdown = silhouetteList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> silhouetteListText = silhouetteDropdown.options;
        TryReplaceText(silhouetteListText[0], LanguageManager.CurrentLanguage.options.assists_enemySilhouettesNone);
        TryReplaceText(silhouetteListText[1], LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly);
        TryReplaceText(silhouetteListText[2], LanguageManager.CurrentLanguage.options.assists_enemySilhouettesFull);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistance, assistContent, "Activation Distance", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlineThickness, assistContent, "Outline Thickness", "Text");

        SliderValueToText assistEnemySilhouettesDistanceSlider = FindDescendant(assistContent, "Activation Distance", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        assistEnemySilhouettesDistanceSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistanceMinimum;

        //TextMeshProUGUI assistEnemySilhouettesOutlinesOnlyText = FindComponent<TextMeshProUGUI>(FindDescendant(assistEnemySilhouettesExtra, "Extra"), "Text (2)");
        //assistEnemySilhouettesOutlinesOnlyText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly;

        GameObject assistsMajorTitleObject = FindDescendant(assistContent, "-- Major Assists --");

        //-- MAJOR ASSISTS --
        TextMeshProUGUI assistsMajorTitle = TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.assists_major), assistsMajorTitleObject, "Text");
        if (assistsMajorTitle != null) assistsMajorTitle.fontSize = 20;
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_majorActivate, assistsMajorTitleObject, "Enable Group", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_gameSpeed, assistContent, "Game Speed", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_damageTaken, assistContent, "Damage Taken", "Text");

        GameObject bossOverride = FindDescendant(assistContent, "Boss Fight Difficulty Override");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_bossOverride, assistContent, "Boss Fight Difficulty Override", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_bossRestartRequired, bossOverride, "Side Note");

        TMP_Dropdown bossOverrideDropdown = FindComponent<TMP_Dropdown>(bossOverride, "Dropdown(Clone)");
        List<TMP_Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

        TryReplaceText(bossOverrideDropdownListText[0], LanguageManager.CurrentLanguage.options.assists_bossOverrideNone);
        TryReplaceText(bossOverrideDropdownListText[1], LanguageManager.CurrentLanguage.frontend.difficulty_harmless);
        TryReplaceText(bossOverrideDropdownListText[2], LanguageManager.CurrentLanguage.frontend.difficulty_lenient);
        TryReplaceText(bossOverrideDropdownListText[3], LanguageManager.CurrentLanguage.frontend.difficulty_standard);
        TryReplaceText(bossOverrideDropdownListText[4], LanguageManager.CurrentLanguage.frontend.difficulty_violent);
        TryReplaceText(bossOverrideDropdownListText[5], LanguageManager.CurrentLanguage.frontend.difficulty_brutal);
        //bossOverrideDropdownListText[6].text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_infiniteEnergy, assistContent, "Infinite Stamina", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disableWhiplashHardDamage, assistContent, "Disable Whiplash Hard Damage", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disableHardDamage, assistContent, "Disable All Hard Damage", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disableWeaponFreshness, assistContent, "Disable Weapon Freshness", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.assists_disablePopupHints, assistContent, "Disable Assist Popup", "Text");
    }
}
