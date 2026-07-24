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

    static public void PatchAssistOptions(GameObject optionsMenu)
    {
        //Assist options

        GameObject assistMajorAssistPanel = FindDescendant(optionsMenu, "Major Assists Consent", "Panel");

        //Major Assist Consent panel
        TextMeshProUGUI assistDisclaimerText = GetTextMeshProUGUI(FindDescendant(assistMajorAssistPanel, "Description Block"));
        TryToReplaceText(assistDisclaimerText,
            new[] { LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer1, LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer2, LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer3 },
            LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer1 + "\n\n" + LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer2 + "\n\n" + LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer3);
        if (assistDisclaimerText != null) assistDisclaimerText.fontSize = 18;

        TextMeshProUGUI assistDisclaimerConfirmText = GetTextMeshProUGUI(FindDescendant(assistMajorAssistPanel, "Summary"));
        TryToReplaceText(assistDisclaimerConfirmText, LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirm);
        if (assistDisclaimerConfirmText != null) assistDisclaimerConfirmText.fontSize = 24;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistMajorAssistPanel, "Yes", "Text")), LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmYes);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistMajorAssistPanel, "No", "Text")), LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmNo);

        //Assist Options
        GameObject assistContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "-- Minor Assists --", "Text")), new[] { LanguageManager.CurrentLanguage.options.assists_minor }, "--" + LanguageManager.CurrentLanguage.options.assists_minor + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Auto Aim", "Text")), LanguageManager.CurrentLanguage.options.assists_autoAim);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Auto Aim Amount", "Text")), LanguageManager.CurrentLanguage.options.assists_autoAimPercent);

        SliderValueToText autoAimSlider = FindDescendant(assistContent, "Auto Aim Amount", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
        autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Enemy Silhouettes", "Text")), LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlines);

        GameObject assistEnemySilhouettes = FindDescendant(assistContent, "Enemy Silhouettes"); 

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistEnemySilhouettes, "Text")), LanguageManager.CurrentLanguage.options.assists_enemySilhouettes);

        GameObject silhouetteList = FindDescendant(assistEnemySilhouettes, "Dropdown(Clone)");
        TMP_Dropdown silhouetteDropdown = silhouetteList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> silhouetteListText = silhouetteDropdown.options;
        TryToReplaceText(silhouetteListText[0], LanguageManager.CurrentLanguage.options.assists_enemySilhouettesNone);
        TryToReplaceText(silhouetteListText[1], LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly);
        TryToReplaceText(silhouetteListText[2], LanguageManager.CurrentLanguage.options.assists_enemySilhouettesFull);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Activation Distance", "Text")), LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistance);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Outline Thickness", "Text")), LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlineThickness);

        SliderValueToText assistEnemySilhouettesDistanceSlider = FindDescendant(assistContent, "Activation Distance", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        assistEnemySilhouettesDistanceSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistanceMinimum;

        //TextMeshProUGUI assistEnemySilhouettesOutlinesOnlyText = GetTextMeshProUGUI(FindDescendant(FindDescendant(assistEnemySilhouettesExtra, "Extra"), "Text (2)"));
        //assistEnemySilhouettesOutlinesOnlyText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly;

        GameObject assistsMajorTitleObject = FindDescendant(assistContent, "-- Major Assists --");
        TextMeshProUGUI assistsMajorTitle = GetTextMeshProUGUI(FindDescendant(assistsMajorTitleObject, "Text"));
        TryToReplaceText(assistsMajorTitle, new[] { LanguageManager.CurrentLanguage.options.assists_major }, "--" + LanguageManager.CurrentLanguage.options.assists_major + "--");
        if (assistsMajorTitle != null) assistsMajorTitle.fontSize = 20;
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistsMajorTitleObject, "Enable Group", "Text")), LanguageManager.CurrentLanguage.options.assists_majorActivate);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Game Speed", "Text")), LanguageManager.CurrentLanguage.options.assists_gameSpeed);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Damage Taken", "Text")), LanguageManager.CurrentLanguage.options.assists_damageTaken);

        GameObject bossOverride = FindDescendant(assistContent, "Boss Fight Difficulty Override");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Boss Fight Difficulty Override", "Text")), LanguageManager.CurrentLanguage.options.assists_bossOverride);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(bossOverride, "Side Note")), LanguageManager.CurrentLanguage.options.assists_bossRestartRequired);

        TMP_Dropdown bossOverrideDropdown = FindDescendant(bossOverride, "Dropdown(Clone)").GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

        TryToReplaceText(bossOverrideDropdownListText[0], LanguageManager.CurrentLanguage.options.assists_bossOverrideNone);
        TryToReplaceText(bossOverrideDropdownListText[1], LanguageManager.CurrentLanguage.frontend.difficulty_harmless);
        TryToReplaceText(bossOverrideDropdownListText[2], LanguageManager.CurrentLanguage.frontend.difficulty_lenient);
        TryToReplaceText(bossOverrideDropdownListText[3], LanguageManager.CurrentLanguage.frontend.difficulty_standard);
        TryToReplaceText(bossOverrideDropdownListText[4], LanguageManager.CurrentLanguage.frontend.difficulty_violent);
        TryToReplaceText(bossOverrideDropdownListText[5], LanguageManager.CurrentLanguage.frontend.difficulty_brutal);
        //bossOverrideDropdownListText[6].text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Infinite Stamina", "Text")), LanguageManager.CurrentLanguage.options.assists_infiniteEnergy);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Disable Whiplash Hard Damage", "Text")), LanguageManager.CurrentLanguage.options.assists_disableWhiplashHardDamage);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Disable All Hard Damage", "Text")), LanguageManager.CurrentLanguage.options.assists_disableHardDamage);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Disable Weapon Freshness", "Text")), LanguageManager.CurrentLanguage.options.assists_disableWeaponFreshness);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(assistContent, "Disable Assist Popup", "Text")), LanguageManager.CurrentLanguage.options.assists_disablePopupHints);
    }
}
