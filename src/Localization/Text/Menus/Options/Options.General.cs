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

    static public void PatchGeneralOptions(GameObject generalOptions)
    {
        //General options
        GameObject generalContent = FindDescendant(generalOptions, "Scroll Rect", "Contents");
        //-- WEAPONS -- 
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "-- Weapons --", "Text")), new[] { LanguageManager.CurrentLanguage.options.controls_weapons }, "-- " + LanguageManager.CurrentLanguage.options.controls_weapons + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Remember Last Used Weapon Variation", "Text")), LanguageManager.CurrentLanguage.options.general_rememberWeapon);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Weapon Position", "Text")), LanguageManager.CurrentLanguage.options.general_weaponPosition);

        //Have to patch directly from the Dropdown.OptionData list.
        GameObject weaponPosList = FindDescendant(generalContent, "Weapon Position", "Dropdown(Clone)");
        TMP_Dropdown weaponPosDropdown = weaponPosList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
        TryToReplaceText(weaponPosListText[0], LanguageManager.CurrentLanguage.options.general_weaponPositionRight);
        TryToReplaceText(weaponPosListText[1], LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle);
        TryToReplaceText(weaponPosListText[2], LanguageManager.CurrentLanguage.options.general_weaponPositionLeft);

        //-- SCREEN -- goes here
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "-- Screen --", "Text")), new[] { LanguageManager.CurrentLanguage.options.general_screen }, "-- " + LanguageManager.CurrentLanguage.options.general_screen + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Screenshake", "Text")), LanguageManager.CurrentLanguage.options.general_screenShake);

        SliderValueToText screenshakeSlider = FindDescendant(generalContent, "Screenshake", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
        screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Parry Screen Flash", "Text")), LanguageManager.CurrentLanguage.options.general_parryFlash);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Camera Tilt", "Text")), LanguageManager.CurrentLanguage.options.general_cameraTilt);

        //-- MISC --
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "-- Misc --", "Text")), new[] { LanguageManager.CurrentLanguage.options.general_misc }, "-- " + LanguageManager.CurrentLanguage.options.general_misc + " --");
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Seasonal Events", "Text")), LanguageManager.CurrentLanguage.options.general_seasonalEvent);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Level Leaderboards", "Text")), LanguageManager.CurrentLanguage.options.general_levelLeaderboards);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent.transform.GetChild(10).gameObject, "Text")), LanguageManager.CurrentLanguage.options.general_restartWarning);

        GameObject restartWarningList = FindDescendant(generalContent.transform.GetChild(10).gameObject, "Dropdown(Clone)");
        TMP_Dropdown restartWarningDropdown = restartWarningList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> restartWarningListText = restartWarningDropdown.options;
        TryToReplaceText(restartWarningListText[0], LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOn);
        TryToReplaceText(restartWarningListText[1], LanguageManager.CurrentLanguage.options.general_restartWarningOnlyCG);
        TryToReplaceText(restartWarningListText[2], LanguageManager.CurrentLanguage.options.general_restartWarningAlwaysOff);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Sandbox Save Overwrite Warning", "Text")), LanguageManager.CurrentLanguage.options.general_sandboxOverwrite);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Discord Integration", "Text")), LanguageManager.CurrentLanguage.options.general_discordRpc);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Advanced Options", "Text")), LanguageManager.CurrentLanguage.options.general_advancedOptions);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(generalContent, "Advanced Options", "Action Button(Clone)", "Text")), LanguageManager.CurrentLanguage.options.general_advancedOptionsCustomize);
    }
}
