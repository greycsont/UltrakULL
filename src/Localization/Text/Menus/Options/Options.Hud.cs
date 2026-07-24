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

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent.transform.GetChild(0).gameObject, "Text")), new[] { LanguageManager.CurrentLanguage.options.category_general }, "--" + LanguageManager.CurrentLanguage.options.category_general + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "HUD Type", "Text")), LanguageManager.CurrentLanguage.options.hud_type);

        GameObject hudType = FindDescendant(hudContent, "HUD Type", "Dropdown(Clone)");
        TMP_Dropdown hudTypeDropdown = hudType.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

        TryToReplaceText(hudTypeDropdownListText[0], LanguageManager.CurrentLanguage.options.hud_typeNone);
        TryToReplaceText(hudTypeDropdownListText[1], LanguageManager.CurrentLanguage.options.hud_typeStandard);
        TryToReplaceText(hudTypeDropdownListText[2], LanguageManager.CurrentLanguage.options.hud_typeClassicColor);
        TryToReplaceText(hudTypeDropdownListText[3], LanguageManager.CurrentLanguage.options.hud_typeClassicWhite);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Background Opacity", "Text")), LanguageManager.CurrentLanguage.options.hud_backgroundOpacity);

        SliderValueToText backgroundOpacitySlider = FindDescendant(hudContent, "Background Opacity", "Slider Button(Clone)", "Slider").GetComponentInChildren<SliderValueToText>();

        backgroundOpacitySlider.ifMin = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMinimum;
        backgroundOpacitySlider.ifMax = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMaximum;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Always On Top", "Text")), LanguageManager.CurrentLanguage.options.hud_alwaysOnTop);

        GameObject iconsObject = FindDescendant(hudContent, "Cheat & Sandbox Icons");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(iconsObject, "Text")), LanguageManager.CurrentLanguage.options.hud_icons);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "REDUCE HUD MOTION", "Text")), LanguageManager.CurrentLanguage.options.hud_reduceHudMotion);

        TMP_Dropdown iconsDropdown = iconsObject.GetComponentInChildren<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> iconsDropdownListText = iconsDropdown.options;

        TryToReplaceText(iconsDropdownListText[0], LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default);
        TryToReplaceText(iconsDropdownListText[1], LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "-- Elements --", "Text")), new[] { LanguageManager.CurrentLanguage.options.hud_hudElements }, "--" + LanguageManager.CurrentLanguage.options.hud_hudElements + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Weapon Icon", "Text")), LanguageManager.CurrentLanguage.options.hud_weaponIcon);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Arm Icon", "Text")), LanguageManager.CurrentLanguage.options.hud_armIcon);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Railcannon Meter", "Text")), LanguageManager.CurrentLanguage.options.hud_railcannonMeter);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Style Meter", "Text")), LanguageManager.CurrentLanguage.options.hud_styleMeter);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Style Info", "Text")), LanguageManager.CurrentLanguage.options.hud_styleInfo);

        GameObject speedoMeterDD = FindDescendant(hudContent, "Speedometer");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(speedoMeterDD, "Text")), LanguageManager.CurrentLanguage.options.hud_speedoMeterText);

        TMP_Dropdown speedoMeterTypeDropdown = speedoMeterDD.GetComponentInChildren<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> speedoMeterTypeDropdownListText = speedoMeterTypeDropdown.options;
        TryToReplaceText(speedoMeterTypeDropdownListText[0], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeOff);
        TryToReplaceText(speedoMeterTypeDropdownListText[1], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeOn);
        TryToReplaceText(speedoMeterTypeDropdownListText[2], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeHorizonal);
        TryToReplaceText(speedoMeterTypeDropdownListText[3], LanguageManager.CurrentLanguage.options.hud_speedoMeterTypeVertical);
        
        //Crosshair settings

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "-- Crosshair --","Text")), new[] { LanguageManager.CurrentLanguage.options.crosshair_title }, "--" + LanguageManager.CurrentLanguage.options.crosshair_title + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Type", "Text")), LanguageManager.CurrentLanguage.options.crosshair_type);

        GameObject crosshairType = FindDescendant(hudContent, "Type", "Dropdown(Clone)");
        TMP_Dropdown crosshairTypeDropdown = crosshairType.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

        TryToReplaceText(crosshairTypeDropdownListText[0], LanguageManager.CurrentLanguage.options.crosshair_typeNone);
        TryToReplaceText(crosshairTypeDropdownListText[1], LanguageManager.CurrentLanguage.options.crosshair_typeSmall);
        TryToReplaceText(crosshairTypeDropdownListText[2], LanguageManager.CurrentLanguage.options.crosshair_typeLarge);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Color", "Text")), LanguageManager.CurrentLanguage.options.crosshair_color);

        GameObject crosshairColor = FindDescendant(hudContent, "Color", "Dropdown(Clone)");
        TMP_Dropdown crosshairColorDropdown = crosshairColor.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

        TryToReplaceText(crosshairColorDropdownListText[0], LanguageManager.CurrentLanguage.options.crosshair_colorInverted);
        TryToReplaceText(crosshairColorDropdownListText[1], LanguageManager.CurrentLanguage.options.crosshair_colorWhite);
        TryToReplaceText(crosshairColorDropdownListText[2], LanguageManager.CurrentLanguage.options.crosshair_colorGrey);
        TryToReplaceText(crosshairColorDropdownListText[3], LanguageManager.CurrentLanguage.options.crosshair_colorBlack);
        TryToReplaceText(crosshairColorDropdownListText[4], LanguageManager.CurrentLanguage.options.crosshair_colorRed);
        TryToReplaceText(crosshairColorDropdownListText[5], LanguageManager.CurrentLanguage.options.crosshair_colorGreen);
        TryToReplaceText(crosshairColorDropdownListText[6], LanguageManager.CurrentLanguage.options.crosshair_colorBlue);
        TryToReplaceText(crosshairColorDropdownListText[7], LanguageManager.CurrentLanguage.options.crosshair_colorCyan);
        TryToReplaceText(crosshairColorDropdownListText[8], LanguageManager.CurrentLanguage.options.crosshair_colorYellow);
        TryToReplaceText(crosshairColorDropdownListText[9], LanguageManager.CurrentLanguage.options.crosshair_colorMagenta);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Crosshair HUD Size", "Text")), LanguageManager.CurrentLanguage.options.crosshair_size);

        GameObject crosshairSize = FindDescendant(hudContent, "Crosshair HUD Size", "Dropdown(Clone)");
        TMP_Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

        TryToReplaceText(crosshairSizeDropdownListText[0], LanguageManager.CurrentLanguage.options.crosshair_sizeNone);
        TryToReplaceText(crosshairSizeDropdownListText[1], LanguageManager.CurrentLanguage.options.crosshair_sizeThin);
        TryToReplaceText(crosshairSizeDropdownListText[2], LanguageManager.CurrentLanguage.options.crosshair_sizeMedium);
        TryToReplaceText(crosshairSizeDropdownListText[3], LanguageManager.CurrentLanguage.options.crosshair_sizeThick);
        TryToReplaceText(crosshairSizeDropdownListText[4], LanguageManager.CurrentLanguage.options.crosshair_sizeVeryThick);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Crosshair HUD Fade", "Text")), LanguageManager.CurrentLanguage.options.crosshair_hudFade);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(hudContent, "Powerup Meter", "Text")), LanguageManager.CurrentLanguage.options.crosshair_powerupBar);

    }
}
