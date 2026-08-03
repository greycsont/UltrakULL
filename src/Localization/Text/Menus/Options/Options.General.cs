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

    static public void PatchGeneralOptions(GameObject generalOptions)
    {
        //General options
        GameObject generalContent = FindDescendant(generalOptions, "Scroll Rect", "Contents");
        //-- WEAPONS -- 
        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("-- {0} --", LanguageManager.CurrentLanguage.options.controls_weapons), generalContent, "-- Weapons --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_rememberWeapon, generalContent, "Remember Last Used Weapon Variation", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_weaponPosition, generalContent, "Weapon Position", "Text");

        //Have to patch directly from the Dropdown.OptionData list.
        GameObject weaponPosList = FindDescendant(generalContent, "Weapon Position", "Dropdown(Clone)");
        TMP_Dropdown weaponPosDropdown = weaponPosList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
        TryReplaceText(weaponPosListText[0], LanguageManager.CurrentLanguage.options.general_weaponPositionRight);
        TryReplaceText(weaponPosListText[1], LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle);
        TryReplaceText(weaponPosListText[2], LanguageManager.CurrentLanguage.options.general_weaponPositionLeft);

        //-- SCREEN -- goes here
        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("-- {0} --", LanguageManager.CurrentLanguage.options.general_screen), generalContent, "-- Screen --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_screenShake, generalContent, "Screenshake", "Text");

        SliderValueToText screenshakeSlider = FindDescendant(generalContent, "Screenshake", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
        screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_parryFlash, generalContent, "Parry Screen Flash", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_cameraTilt, generalContent, "Camera Tilt", "Text");

        //-- MISC --
        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("-- {0} --", LanguageManager.CurrentLanguage.options.general_misc), generalContent, "-- Misc --", "Text");
        
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_seasonalEvent, generalContent, "Seasonal Events", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_levelLeaderboards, generalContent, "Level Leaderboards", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_restartWarning, generalContent.transform.GetChild(10).gameObject, "Text");

        GameObject restartWarningList = FindDescendant(generalContent.transform.GetChild(10).gameObject, "Dropdown(Clone)");
        TMP_Dropdown restartWarningDropdown = restartWarningList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> restartWarningListText = restartWarningDropdown.options;
        TryReplaceText(restartWarningListText[0], LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOn);
        TryReplaceText(restartWarningListText[1], LanguageManager.CurrentLanguage.options.general_restartWarningOnlyCG);
        TryReplaceText(restartWarningListText[2], LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOff);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_sandboxOverwrite, generalContent, "Sandbox Save Overwrite Warning", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_discordRpc, generalContent, "Discord Integration", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_advancedOptions, generalContent, "Advanced Options", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_advancedOptionsCustomize, generalContent, "Advanced Options", "Action Button(Clone)", "Text");
    }
}
