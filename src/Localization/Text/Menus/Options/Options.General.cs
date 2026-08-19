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
        generalContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.controls_weapons), "-- Weapons --", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_rememberWeapon, "Remember Last Used Weapon Variation", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_weaponPosition, "Weapon Position", "Text");

        //Have to patch directly from the Dropdown.OptionData list.
        GameObject weaponPosList = FindDescendant(generalContent, "Weapon Position", "Dropdown(Clone)");
        TMP_Dropdown weaponPosDropdown = weaponPosList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
        weaponPosListText[0].Localize(LanguageManager.CurrentLanguage.options.general_weaponPositionRight);
        weaponPosListText[1].Localize(LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle);
        weaponPosListText[2].Localize(LanguageManager.CurrentLanguage.options.general_weaponPositionLeft);

        //-- SCREEN -- goes here
        generalContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.general_screen), "-- Screen --", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_screenShake, "Screenshake", "Text");

        SliderValueToText screenshakeSlider = FindDescendant(generalContent, "Screenshake", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
        screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_parryFlash, "Parry Screen Flash", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_cameraTilt, "Camera Tilt", "Text");

        //-- MISC --
        generalContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.general_misc), "-- Misc --", "Text");
        
        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_seasonalEvent, "Seasonal Events", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_levelLeaderboards, "Level Leaderboards", "Text");

        generalContent.transform.GetChild(10).gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_restartWarning, "Text");

        GameObject restartWarningList = FindDescendant(generalContent.transform.GetChild(10).gameObject, "Dropdown(Clone)");
        TMP_Dropdown restartWarningDropdown = restartWarningList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> restartWarningListText = restartWarningDropdown.options;
        restartWarningListText[0].Localize(LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOn);
        restartWarningListText[1].Localize(LanguageManager.CurrentLanguage.options.general_restartWarningOnlyCG);
        restartWarningListText[2].Localize(LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOff);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_sandboxOverwrite, "Sandbox Save Overwrite Warning", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_discordRpc, "Discord Integration", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_advancedOptions, "Advanced Options", "Text");

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_advancedOptionsCustomize, "Advanced Options", "Action Button(Clone)", "Text");
    }
}
