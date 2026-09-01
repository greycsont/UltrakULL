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

    static public void PatchGeneralOptions(GameObject generalOptions)
    {
        //General options
        GameObject generalContent = FindDescendant(generalOptions, "Scroll Rect", "Contents");
        //-- WEAPONS -- 
        generalContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.controls_weapons), path: ["-- Weapons --", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_rememberWeapon, path: ["Remember Last Used Weapon Variation", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_weaponPosition, path: ["Weapon Position", "Text"]);

        //Have to patch directly from the Dropdown.OptionData list.
        GameObject weaponPosList = FindDescendant(generalContent, "Weapon Position", "Dropdown(Clone)");
        TMP_Dropdown weaponPosDropdown = weaponPosList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
        weaponPosListText[0].Localize(LanguageManager.CurrentLanguage.options.general_weaponPositionRight);
        weaponPosListText[1].Localize(LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle);
        weaponPosListText[2].Localize(LanguageManager.CurrentLanguage.options.general_weaponPositionLeft);

        //-- SCREEN -- goes here
        generalContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.general_screen), path: ["-- Screen --", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_screenShake, path: ["Screenshake", "Text"]);

        SliderValueToText screenshakeSlider = FindDescendant(generalContent, "Screenshake", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
        screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_parryFlash, path: ["Parry Screen Flash", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_cameraTilt, path: ["Camera Tilt", "Text"]);

        //-- MISC --
        generalContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.general_misc), path: ["-- Misc --", "Text"]);
        
        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_seasonalEvent, path: ["Seasonal Events", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_levelLeaderboards, path: ["Level Leaderboards", "Text"]);

        generalContent.transform.GetChild(10).gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_restartWarning, path: ["Text"]);

        GameObject restartWarningList = FindDescendant(generalContent.transform.GetChild(10).gameObject, "Dropdown(Clone)");
        TMP_Dropdown restartWarningDropdown = restartWarningList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> restartWarningListText = restartWarningDropdown.options;
        restartWarningListText[0].Localize(LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOn);
        restartWarningListText[1].Localize(LanguageManager.CurrentLanguage.options.general_restartWarningOnlyCG);
        restartWarningListText[2].Localize(LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOff);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_sandboxOverwrite, path: ["Sandbox Save Overwrite Warning", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_discordRpc, path: ["Discord Integration", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_advancedOptions, path: ["Advanced Options", "Text"]);

        generalContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.general_advancedOptionsCustomize, path: ["Advanced Options", "Action Button(Clone)", "Text"]);
    }
}
