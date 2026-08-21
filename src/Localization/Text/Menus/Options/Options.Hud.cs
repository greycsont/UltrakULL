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

    static public void PatchHUDOptions(GameObject optionsMenu)
    {
        //HUD options
        GameObject hudContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //--GENERAL--
        hudContent.transform.GetChild(0).gameObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(LanguageManager.CurrentLanguage.options.category_general), path: ["Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_type, path: ["HUD Type", "Text"]);

        GameObject hudType = FindDescendant(hudContent, "HUD Type", "Dropdown(Clone)");
        TMP_Dropdown hudTypeDropdown = hudType.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

        hudTypeDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.hud_typeNone);
        hudTypeDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.hud_typeStandard);
        hudTypeDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.hud_typeClassicColor);
        hudTypeDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.hud_typeClassicWhite);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_backgroundOpacity, path: ["Background Opacity", "Text"]);

        SliderValueToText backgroundOpacitySlider = FindDescendant(hudContent, "Background Opacity", "Slider Button(Clone)", "Slider").GetComponentInChildren<SliderValueToText>();

        backgroundOpacitySlider.ifMin = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMinimum;
        backgroundOpacitySlider.ifMax = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMaximum;

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_alwaysOnTop, path: ["Always On Top", "Text"]);

        GameObject iconsObject = FindDescendant(hudContent, "Cheat & Sandbox Icons");
        iconsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_icons, path: ["Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_reduceHudMotion, path: ["REDUCE HUD MOTION", "Text"]);

        TMP_Dropdown iconsDropdown = iconsObject.GetComponentInChildren<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> iconsDropdownListText = iconsDropdown.options;

        iconsDropdownListText[0].Localize(LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default);
        iconsDropdownListText[1].Localize(LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr);

        //-- ELEMENTS --
        hudContent.Localize<TextMeshProUGUI>("--{0}--".FormatWith(LanguageManager.CurrentLanguage.options.hud_hudElements), path: ["-- Elements --", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_weaponIcon, path: ["Weapon Icon", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_armIcon, path: ["Arm Icon", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_railcannonMeter, path: ["Railcannon Meter", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_styleMeter, path: ["Style Meter", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_styleInfo, path: ["Style Info", "Text"]);

        GameObject speedoMeterDD = FindDescendant(hudContent, "Speedometer");
        speedoMeterDD.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_speedoMeterText, path: ["Text"]);

        TMP_Dropdown speedoMeterTypeDropdown = speedoMeterDD.GetComponentInChildren<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> speedoMeterTypeDropdownListText = speedoMeterTypeDropdown.options;
        speedoMeterTypeDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeOff);
        speedoMeterTypeDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeOn);
        speedoMeterTypeDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeHorizonal);
        speedoMeterTypeDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeVertical);
        
        //-- CROSSHAIR --
        hudContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.crosshair_title), path: ["-- Crosshair --", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_type, path: ["Type", "Text"]);

        GameObject crosshairType = FindDescendant(hudContent, "Type", "Dropdown(Clone)");
        TMP_Dropdown crosshairTypeDropdown = crosshairType.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

        crosshairTypeDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.crosshair_typeNone);
        crosshairTypeDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.crosshair_typeSmall);
        crosshairTypeDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.crosshair_typeLarge);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_color, path: ["Color", "Text"]);

        GameObject crosshairColor = FindDescendant(hudContent, "Color", "Dropdown(Clone)");
        TMP_Dropdown crosshairColorDropdown = crosshairColor.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

        crosshairColorDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorInverted);
        crosshairColorDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorWhite);
        crosshairColorDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorGrey);
        crosshairColorDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorBlack);
        crosshairColorDropdownListText[4].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorRed);
        crosshairColorDropdownListText[5].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorGreen);
        crosshairColorDropdownListText[6].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorBlue);
        crosshairColorDropdownListText[7].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorCyan);
        crosshairColorDropdownListText[8].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorYellow);
        crosshairColorDropdownListText[9].Localize(LanguageManager.CurrentLanguage.options.crosshair_colorMagenta);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_size, path: ["Crosshair HUD Size", "Text"]);

        GameObject crosshairSize = FindDescendant(hudContent, "Crosshair HUD Size", "Dropdown(Clone)");
        TMP_Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

        crosshairSizeDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.crosshair_sizeNone);
        crosshairSizeDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.crosshair_sizeThin);
        crosshairSizeDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.crosshair_sizeMedium);
        crosshairSizeDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.crosshair_sizeThick);
        crosshairSizeDropdownListText[4].Localize(LanguageManager.CurrentLanguage.options.crosshair_sizeVeryThick);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_hudFade, path: ["Crosshair HUD Fade", "Text"]);

        hudContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_powerupBar, path: ["Powerup Meter", "Text"]);

    }
}
