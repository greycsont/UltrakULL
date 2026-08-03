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

    static public void PatchHUDOptions(GameObject optionsMenu)
    {
        //HUD options
        GameObject hudContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("--{0}--", LanguageManager.CurrentLanguage.options.category_general), hudContent.transform.GetChild(0).gameObject, "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_type, hudContent, "HUD Type", "Text");

        GameObject hudType = FindDescendant(hudContent, "HUD Type", "Dropdown(Clone)");
        TMP_Dropdown hudTypeDropdown = hudType.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

        TryReplaceText(hudTypeDropdownListText[0], LanguageManager.CurrentLanguage.options.hud_typeNone);
        TryReplaceText(hudTypeDropdownListText[1], LanguageManager.CurrentLanguage.options.hud_typeStandard);
        TryReplaceText(hudTypeDropdownListText[2], LanguageManager.CurrentLanguage.options.hud_typeClassicColor);
        TryReplaceText(hudTypeDropdownListText[3], LanguageManager.CurrentLanguage.options.hud_typeClassicWhite);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_backgroundOpacity, hudContent, "Background Opacity", "Text");

        SliderValueToText backgroundOpacitySlider = FindDescendant(hudContent, "Background Opacity", "Slider Button(Clone)", "Slider").GetComponentInChildren<SliderValueToText>();

        backgroundOpacitySlider.ifMin = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMinimum;
        backgroundOpacitySlider.ifMax = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMaximum;

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_alwaysOnTop, hudContent, "Always On Top", "Text");

        GameObject iconsObject = FindDescendant(hudContent, "Cheat & Sandbox Icons");
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_icons, iconsObject, "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_reduceHudMotion, hudContent, "REDUCE HUD MOTION", "Text");

        TMP_Dropdown iconsDropdown = iconsObject.GetComponentInChildren<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> iconsDropdownListText = iconsDropdown.options;

        TryReplaceText(iconsDropdownListText[0], LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default);
        TryReplaceText(iconsDropdownListText[1], LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr);

        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("--{0}--", LanguageManager.CurrentLanguage.options.hud_hudElements), hudContent, "-- Elements --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_weaponIcon, hudContent, "Weapon Icon", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_armIcon, hudContent, "Arm Icon", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_railcannonMeter, hudContent, "Railcannon Meter", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_styleMeter, hudContent, "Style Meter", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_styleInfo, hudContent, "Style Info", "Text");

        GameObject speedoMeterDD = FindDescendant(hudContent, "Speedometer");
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.hud_speedoMeterText, speedoMeterDD, "Text");

        TMP_Dropdown speedoMeterTypeDropdown = speedoMeterDD.GetComponentInChildren<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> speedoMeterTypeDropdownListText = speedoMeterTypeDropdown.options;
        TryReplaceText(speedoMeterTypeDropdownListText[0], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeOff);
        TryReplaceText(speedoMeterTypeDropdownListText[1], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeOn);
        TryReplaceText(speedoMeterTypeDropdownListText[2], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeHorizonal);
        TryReplaceText(speedoMeterTypeDropdownListText[3], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeVertical);
        
        //Crosshair settings

        TryReplaceText<TextMeshProUGUI>(TextFormatter.Format("--{0}--", LanguageManager.CurrentLanguage.options.crosshair_title), hudContent, "-- Crosshair --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_type, hudContent, "Type", "Text");

        GameObject crosshairType = FindDescendant(hudContent, "Type", "Dropdown(Clone)");
        TMP_Dropdown crosshairTypeDropdown = crosshairType.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

        TryReplaceText(crosshairTypeDropdownListText[0], LanguageManager.CurrentLanguage.options.crosshair_typeNone);
        TryReplaceText(crosshairTypeDropdownListText[1], LanguageManager.CurrentLanguage.options.crosshair_typeSmall);
        TryReplaceText(crosshairTypeDropdownListText[2], LanguageManager.CurrentLanguage.options.crosshair_typeLarge);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_color, hudContent, "Color", "Text");

        GameObject crosshairColor = FindDescendant(hudContent, "Color", "Dropdown(Clone)");
        TMP_Dropdown crosshairColorDropdown = crosshairColor.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

        TryReplaceText(crosshairColorDropdownListText[0], LanguageManager.CurrentLanguage.options.crosshair_colorInverted);
        TryReplaceText(crosshairColorDropdownListText[1], LanguageManager.CurrentLanguage.options.crosshair_colorWhite);
        TryReplaceText(crosshairColorDropdownListText[2], LanguageManager.CurrentLanguage.options.crosshair_colorGrey);
        TryReplaceText(crosshairColorDropdownListText[3], LanguageManager.CurrentLanguage.options.crosshair_colorBlack);
        TryReplaceText(crosshairColorDropdownListText[4], LanguageManager.CurrentLanguage.options.crosshair_colorRed);
        TryReplaceText(crosshairColorDropdownListText[5], LanguageManager.CurrentLanguage.options.crosshair_colorGreen);
        TryReplaceText(crosshairColorDropdownListText[6], LanguageManager.CurrentLanguage.options.crosshair_colorBlue);
        TryReplaceText(crosshairColorDropdownListText[7], LanguageManager.CurrentLanguage.options.crosshair_colorCyan);
        TryReplaceText(crosshairColorDropdownListText[8], LanguageManager.CurrentLanguage.options.crosshair_colorYellow);
        TryReplaceText(crosshairColorDropdownListText[9], LanguageManager.CurrentLanguage.options.crosshair_colorMagenta);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_size, hudContent, "Crosshair HUD Size", "Text");

        GameObject crosshairSize = FindDescendant(hudContent, "Crosshair HUD Size", "Dropdown(Clone)");
        TMP_Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

        TryReplaceText(crosshairSizeDropdownListText[0], LanguageManager.CurrentLanguage.options.crosshair_sizeNone);
        TryReplaceText(crosshairSizeDropdownListText[1], LanguageManager.CurrentLanguage.options.crosshair_sizeThin);
        TryReplaceText(crosshairSizeDropdownListText[2], LanguageManager.CurrentLanguage.options.crosshair_sizeMedium);
        TryReplaceText(crosshairSizeDropdownListText[3], LanguageManager.CurrentLanguage.options.crosshair_sizeThick);
        TryReplaceText(crosshairSizeDropdownListText[4], LanguageManager.CurrentLanguage.options.crosshair_sizeVeryThick);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_hudFade, hudContent, "Crosshair HUD Fade", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.crosshair_powerupBar, hudContent, "Powerup Meter", "Text");

    }
}
