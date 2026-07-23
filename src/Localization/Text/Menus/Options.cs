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

public static class Options
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
    static public void PatchControlOptions(GameObject optionsMenu)
    {   
        //Control options
        GameObject controlContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //-- GENERAL --
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "-- General --", "Text")), new[] { LanguageManager.CurrentLanguage.options.category_general }, "-- " + LanguageManager.CurrentLanguage.options.category_general + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Look Sensitivity", "Text")), LanguageManager.CurrentLanguage.options.controls_mouseSensitivity);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Invert X Axis", "Text")), LanguageManager.CurrentLanguage.options.controls_xInversion);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Invert Y Axis", "Text")), LanguageManager.CurrentLanguage.options.controls_yInversion);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Controller Rumble", "Text")), LanguageManager.CurrentLanguage.options.controls_controllerRumble);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Controller Rumble", "Action Button(Clone)", "Text")), LanguageManager.CurrentLanguage.options.controls_controllerRumbleCustomize);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent.transform.GetChild(5).gameObject, "Text")), new[] { LanguageManager.CurrentLanguage.options.controls_weapons }, "-- " + LanguageManager.CurrentLanguage.options.controls_weapons + " --");

        GameObject mouseWheelContent = FindDescendant(controlContent, "Scroll Weapons with Mouse Wheel");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(mouseWheelContent, "Text")), LanguageManager.CurrentLanguage.options.controls_mouseWheelToChangeWeapon);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Weapon Scroll Type", "Text")), LanguageManager.CurrentLanguage.options.controls_scrollType);

        //Dropdown here
        GameObject scrollTypeList = FindDescendant(controlContent, "Weapon Scroll Type", "Dropdown(Clone)");

        TMP_Dropdown scrollTypeDropdown = scrollTypeList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> scrollTypeDropdownText = scrollTypeDropdown.options;
        TryToReplaceText(scrollTypeDropdownText[0], LanguageManager.CurrentLanguage.options.controls_scrollTypeWeapons);
        TryToReplaceText(scrollTypeDropdownText[1], LanguageManager.CurrentLanguage.options.controls_scrollTypeVariations);
        TryToReplaceText(scrollTypeDropdownText[2], LanguageManager.CurrentLanguage.options.controls_scrollTypeAll);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Reverse Scroll Direction", "Text")), LanguageManager.CurrentLanguage.options.controls_reverseScroll);

        GameObject redrawBehaviour = FindDescendant(controlContent, "On Swap To Already Drawn Weapon");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(redrawBehaviour, "Text")), LanguageManager.CurrentLanguage.options.controls_redrawBehaviour);

        TMP_Dropdown redrawBehaviourDropdown = FindDescendant(redrawBehaviour, "Dropdown(Clone)").GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> redrawBehaviourDropdownText = redrawBehaviourDropdown.options;
        TryToReplaceText(redrawBehaviourDropdownText[0], LanguageManager.CurrentLanguage.options.controls_redrawNext);
        TryToReplaceText(redrawBehaviourDropdownText[1], LanguageManager.CurrentLanguage.options.controls_redrawFirst);
        TryToReplaceText(redrawBehaviourDropdownText[2], LanguageManager.CurrentLanguage.options.controls_redrawSame);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(controlContent, "Invert Rocket Controls", "Text")), LanguageManager.CurrentLanguage.options.controls_invertRocketControls);

        //unused after patch 16
        //TextMeshProUGUI bindsTitle = GetTextMeshProUGUI(FindDescendant(controlContent.transform.GetChild(10).gameObject, "Text"));
        //bindsTitle.text = "-- " + LanguageManager.CurrentLanguage.options.controls_bindings + " --";


        //Tried to use a foreach loop but it just wouldn't work, that'll do for now, just have to add things manually once they get added
        //Commented this out for now due to it causing out of bound issues. Will investigate later

        /*TextMeshProUGUI bindMove = GetTextMeshProUGUI(controlContent.transform.GetChild(8).gameObject);
        TextMeshProUGUI bindDodge = GetTextMeshProUGUI(controlContent.transform.GetChild(9).gameObject);
        TextMeshProUGUI bindSlide = GetTextMeshProUGUI(controlContent.transform.GetChild(10).gameObject);
        TextMeshProUGUI bindJump = GetTextMeshProUGUI(controlContent.transform.GetChild(11).gameObject);

        TextMeshProUGUI bindPrimary = GetTextMeshProUGUI(controlContent.transform.GetChild(13).gameObject);
        TextMeshProUGUI bindSecondary = GetTextMeshProUGUI(controlContent.transform.GetChild(14).gameObject);
        TextMeshProUGUI bindChangeVariation = GetTextMeshProUGUI(controlContent.transform.GetChild(15).gameObject);
        TextMeshProUGUI bindSlot0 = GetTextMeshProUGUI(controlContent.transform.GetChild(16).gameObject);
        TextMeshProUGUI bindSlot1 = GetTextMeshProUGUI(controlContent.transform.GetChild(17).gameObject);
        TextMeshProUGUI bindSlot2 = GetTextMeshProUGUI(controlContent.transform.GetChild(18).gameObject);
        TextMeshProUGUI bindSlot3 = GetTextMeshProUGUI(controlContent.transform.GetChild(19).gameObject);
        TextMeshProUGUI bindSlot4 = GetTextMeshProUGUI(controlContent.transform.GetChild(20).gameObject);
        TextMeshProUGUI bindSlot5 = GetTextMeshProUGUI(controlContent.transform.GetChild(21).gameObject);
        TextMeshProUGUI bindSlot6 = GetTextMeshProUGUI(controlContent.transform.GetChild(22).gameObject);
        TextMeshProUGUI bindSlot7 = GetTextMeshProUGUI(controlContent.transform.GetChild(23).gameObject);
        TextMeshProUGUI bindSlot8 = GetTextMeshProUGUI(controlContent.transform.GetChild(24).gameObject);
        TextMeshProUGUI bindSlot9 = GetTextMeshProUGUI(controlContent.transform.GetChild(25).gameObject);
        TextMeshProUGUI bindNext = GetTextMeshProUGUI(controlContent.transform.GetChild(26).gameObject);
        TextMeshProUGUI bindPrevious = GetTextMeshProUGUI(controlContent.transform.GetChild(27).gameObject);
        TextMeshProUGUI bindLast = GetTextMeshProUGUI(controlContent.transform.GetChild(28).gameObject);

        TextMeshProUGUI bindChangeFist = GetTextMeshProUGUI(controlContent.transform.GetChild(30).gameObject);
        TextMeshProUGUI bindPunch = GetTextMeshProUGUI(controlContent.transform.GetChild(31).gameObject);
        TextMeshProUGUI bindHook = GetTextMeshProUGUI(controlContent.transform.GetChild(32).gameObject);

        bindMove.text = LanguageManager.CurrentLanguage.options.controls_move;
        bindDodge.text = LanguageManager.CurrentLanguage.options.controls_dash;
        bindSlide.text = LanguageManager.CurrentLanguage.options.controls_slide;
        bindJump.text = LanguageManager.CurrentLanguage.options.controls_jump;

        bindPrimary.text = LanguageManager.CurrentLanguage.options.controls_primaryFire;
        bindSecondary.text = LanguageManager.CurrentLanguage.options.controls_secondaryFire;
        bindChangeVariation.text = LanguageManager.CurrentLanguage.options.controls_changeVariation;
        bindSlot0.text = LanguageManager.CurrentLanguage.options.controls_slot0;
        bindSlot1.text = LanguageManager.CurrentLanguage.options.controls_slot1;
        bindSlot2.text = LanguageManager.CurrentLanguage.options.controls_slot2;
        bindSlot3.text = LanguageManager.CurrentLanguage.options.controls_slot3;
        bindSlot4.text = LanguageManager.CurrentLanguage.options.controls_slot4;
        bindSlot5.text = LanguageManager.CurrentLanguage.options.controls_slot5;
        bindSlot6.text = LanguageManager.CurrentLanguage.options.controls_slot6;
        bindSlot7.text = LanguageManager.CurrentLanguage.options.controls_slot7;
        bindSlot8.text = LanguageManager.CurrentLanguage.options.controls_slot8;
        bindSlot9.text = LanguageManager.CurrentLanguage.options.controls_slot9;
        bindNext.text = LanguageManager.CurrentLanguage.options.controls_nextWeapon;
        bindPrevious.text = LanguageManager.CurrentLanguage.options.controls_previousWeapon;
        bindLast.text = LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon;

        bindChangeFist.text = LanguageManager.CurrentLanguage.options.controls_changeArm;
        bindPunch.text = LanguageManager.CurrentLanguage.options.controls_punch;
        bindHook.text = LanguageManager.CurrentLanguage.options.controls_whiplash;*/
    }
    static public void PatchGraphicsOptions(GameObject optionsMenu)
    {
        //Graphics options
        GameObject graphicsContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //--GENERAL--
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "-- General --", "Text")), new[] { LanguageManager.CurrentLanguage.options.category_general }, "--" + LanguageManager.CurrentLanguage.options.category_general + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Resolution", "Text")), LanguageManager.CurrentLanguage.options.graphics_resolution);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Fullscreen", "Text")), LanguageManager.CurrentLanguage.options.graphics_fullscreen);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Target Framerate", "Text")), LanguageManager.CurrentLanguage.options.graphics_maxFps);

        GameObject fpsObject = FindDescendant(graphicsContent, "Target Framerate", "Dropdown(Clone)");
        TMP_Dropdown fpsDropdown = fpsObject.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
        TryToReplaceText(fpsDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_maxFpsNone);
        TryToReplaceText(fpsDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_maxFps2x);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "VSync", "Text")), LanguageManager.CurrentLanguage.options.graphics_vsync);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Field of View", "Text")), LanguageManager.CurrentLanguage.options.graphics_fieldOfVision);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Gamma (Brightness)", "Text")), LanguageManager.CurrentLanguage.options.graphics_gamma);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Use Fallback Shaders (Requires Reload)", "Text")), LanguageManager.CurrentLanguage.options.graphics_useFallbackShaders);

        //--PSX--
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "-- PSX --", "Text")),
            new[] { LanguageManager.CurrentLanguage.options.graphics_filters, LanguageManager.CurrentLanguage.options.graphics_filtersDescription },
            "--" + LanguageManager.CurrentLanguage.options.graphics_filters + "--\n<size=16>" + LanguageManager.CurrentLanguage.options.graphics_filtersDescription + "</size>");


        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Downscaling", "Text")), LanguageManager.CurrentLanguage.options.graphics_pixelisation);

        GameObject resolution = FindDescendant(graphicsContent, "Downscaling", "Dropdown(Clone)");
        TMP_Dropdown resolutionDropdown = resolution.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

        TryToReplaceText(resolutionDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_pixelisationNone);
        TryToReplaceText(resolutionDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_pixelisation720p);
        TryToReplaceText(resolutionDropdownListText[2], LanguageManager.CurrentLanguage.options.graphics_pixelisation480p);
        TryToReplaceText(resolutionDropdownListText[3], LanguageManager.CurrentLanguage.options.graphics_pixelisation360p);
        TryToReplaceText(resolutionDropdownListText[4], LanguageManager.CurrentLanguage.options.graphics_pixelisation240p);
        TryToReplaceText(resolutionDropdownListText[5], LanguageManager.CurrentLanguage.options.graphics_pixelisation144p);
        TryToReplaceText(resolutionDropdownListText[6], LanguageManager.CurrentLanguage.options.graphics_pixelisation36p);


        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Dithering", "Text")), LanguageManager.CurrentLanguage.options.graphics_dithering);

        SliderValueToText ditheringSlider = FindDescendant(graphicsContent, "Dithering", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        ditheringSlider.ifMin = LanguageManager.CurrentLanguage.options.graphics_ditheringMinimum;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Texture Warping", "Text")), LanguageManager.CurrentLanguage.options.graphics_textureWarping);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Vertex Warping", "Text")), LanguageManager.CurrentLanguage.options.graphics_vertexWarping);

        GameObject vertexWarping = FindDescendant(graphicsContent, "Vertex Warping", "Dropdown(Clone)");
        TMP_Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

        TryToReplaceText(vertexWarpingDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingNone);
        TryToReplaceText(vertexWarpingDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingLight);
        TryToReplaceText(vertexWarpingDropdownListText[2], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingMedium);
        TryToReplaceText(vertexWarpingDropdownListText[3], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingStrong);
        TryToReplaceText(vertexWarpingDropdownListText[4], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingVeryStrong);
        TryToReplaceText(vertexWarpingDropdownListText[5], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingAbsurd);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Custom Color Palette", "Text")), LanguageManager.CurrentLanguage.options.graphics_customColorPalette);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Color Palette Texture", "Text")), LanguageManager.CurrentLanguage.options.graphics_customPaletteTexture);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Color Palette Texture", "Action Button(Clone)", "Text")), LanguageManager.CurrentLanguage.options.graphics_customColorPaletteSelect);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Color Compression", "Text")), LanguageManager.CurrentLanguage.options.graphics_colorCompression);

        GameObject colorCompression = FindDescendant(graphicsContent, "Color Compression", "Dropdown(Clone)");
        TMP_Dropdown colorCompressionDropdown = colorCompression.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

        TryToReplaceText(colorCompressionDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_colorCompressionNone);
        TryToReplaceText(colorCompressionDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_colorCompressionLight);
        TryToReplaceText(colorCompressionDropdownListText[2], LanguageManager.CurrentLanguage.options.graphics_colorCompressionMedium);
        TryToReplaceText(colorCompressionDropdownListText[3], LanguageManager.CurrentLanguage.options.graphics_colorCompressionStrong);
        TryToReplaceText(colorCompressionDropdownListText[4], LanguageManager.CurrentLanguage.options.graphics_colorCompressionVeryStrong);
        TryToReplaceText(colorCompressionDropdownListText[5], LanguageManager.CurrentLanguage.options.graphics_colorCompressionAbsurd);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "-- Performance --", "Text")), new[] { LanguageManager.CurrentLanguage.options.graphics_performance }, "--" + LanguageManager.CurrentLanguage.options.graphics_performance + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Simpler Explosions", "Text")), LanguageManager.CurrentLanguage.options.graphics_performanceSimpleExplosions);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Simpler Fire", "Text")), LanguageManager.CurrentLanguage.options.graphics_performanceSimpleFire);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Simpler Spawn Effects", "Text")), LanguageManager.CurrentLanguage.options.graphics_performanceSimpleSpawn);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Disable Environmental Particle Effects", "Text")), LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviParticles);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Disable Environmental Hit Particles", "Text")), LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviHitParticles);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Disable Heat Waves", "Text")), LanguageManager.CurrentLanguage.options.graphics_performanceDisableHeatWaves);

        //--GORE--
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "-- Gore --", "Text")),
            new[] { LanguageManager.CurrentLanguage.options.graphics_gore, LanguageManager.CurrentLanguage.options.graphics_goreNote },
            "--" + LanguageManager.CurrentLanguage.options.graphics_gore + "--\n<size=16>" + LanguageManager.CurrentLanguage.options.graphics_goreNote + "</size>");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Enable Blood & Gore", "Text")), LanguageManager.CurrentLanguage.options.graphics_goreEnable);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Freeze Gore Physics", "Text")), LanguageManager.CurrentLanguage.options.graphics_goreDisablePhysics);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Max Bloodstains", "Text")), LanguageManager.CurrentLanguage.options.graphics_goreMaxBloodStains);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Bloodstain Chance", "Text")), LanguageManager.CurrentLanguage.options.graphics_goreBloodChance);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(graphicsContent, "Max Gore Per Room", "Text")), LanguageManager.CurrentLanguage.options.graphics_goreMaxGore);
    }
    static public void PatchAudioOptions(GameObject optionsMenu)
    {
        //Audio options
        GameObject audioContent = FindDescendant(optionsMenu, "Container");

        //-- Volume --
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "-- Volume --", "Text")), new[] { LanguageManager.CurrentLanguage.options.audio_volume }, "-- " + LanguageManager.CurrentLanguage.options.audio_volume + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Master", "Text")), LanguageManager.CurrentLanguage.options.audio_globalVolume);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Sound Effects", "Text")), LanguageManager.CurrentLanguage.options.audio_soundEffectsVolume);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Music", "Text")), LanguageManager.CurrentLanguage.options.audio_musicVolume);

        //-- MISC --
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "-- Misc --", "Text")), new[] { LanguageManager.CurrentLanguage.options.general_misc }, "-- " + LanguageManager.CurrentLanguage.options.general_misc + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Subtitles", "Text")), LanguageManager.CurrentLanguage.options.audio_subtitles);
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Muffle Music While Underwater", "Text")), LanguageManager.CurrentLanguage.options.audio_muffleMusic);

    }
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
    static public void PatchSavesOptions(GameObject optionMenu)
    {
        //Save options
        GameObject saveReloadPanel = FindDescendant(optionMenu, "Reload Consent Blocker", "Consent", "Panel");
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveReloadPanel, "Text")),
            new[] { LanguageManager.CurrentLanguage.options.save_warning1, LanguageManager.CurrentLanguage.options.save_warning2 },
            "<color=red>" + LanguageManager.CurrentLanguage.options.save_warning1 + "</color>\n\n" + LanguageManager.CurrentLanguage.options.save_warning2);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveReloadPanel, "Yes", "Text")), LanguageManager.CurrentLanguage.options.save_reloadYes);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveReloadPanel, "No", "Text")), LanguageManager.CurrentLanguage.options.save_reloadNo);
        
        GameObject saveDeletePanel = FindDescendant(optionMenu, "Wipe Consent Blocker", "Consent", "Panel");
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveDeletePanel, "Yes", "Text")), new[] { LanguageManager.CurrentLanguage.options.save_deleteYes }, "<color=red>" + LanguageManager.CurrentLanguage.options.save_deleteYes + "</color>");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(saveDeletePanel, "No", "Text")), LanguageManager.CurrentLanguage.options.save_deleteNo);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Close", "Text")), LanguageManager.CurrentLanguage.options.save_close);
    }
    //general end
    //customization starts here
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
    
    private static void PatchColorsOptions(GameObject optionsMenu)
    {
        //Colors options
        //TextMeshProUGUI colorsPanel = GetTextMeshProUGUI(FindDescendant(optionsMenu, "Text (1)"));
        //colorsPanel.text = "--" + LanguageManager.CurrentLanguage.options.colors_title + "--";

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Default", "Text")), LanguageManager.CurrentLanguage.options.colors_reset);

        //HUD Text
        GameObject colorsHudObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "HUD");

        TryToReplaceText(GetTextMeshProUGUI(colorsHudObject), new[] { LanguageManager.CurrentLanguage.options.colors_hud }, "--" + LanguageManager.CurrentLanguage.options.colors_hud + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Health", "Text")), LanguageManager.CurrentLanguage.options.colors_hudHealth);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "HpText", "Text")), LanguageManager.CurrentLanguage.options.colors_hudHealthNumber);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "AfterImage", "Text")), LanguageManager.CurrentLanguage.options.colors_hudDamage);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "AntiHp", "Text")), LanguageManager.CurrentLanguage.options.colors_hudHardDamage);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Overheal", "Text")), LanguageManager.CurrentLanguage.options.colors_hudOverheal);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Stamina", "Text")), LanguageManager.CurrentLanguage.options.colors_hudEnergyFull);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "StaminaCharging", "Text")), LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "StaminaEmpty", "Text")), LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "RailcannonFull", "Text")), LanguageManager.CurrentLanguage.options.colors_railcannonFull);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "RailcannonCharging", "Text")), LanguageManager.CurrentLanguage.options.colors_railcannonPartial);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Blue Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationBlue);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Green Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationGreen);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Red Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationRed);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsHudObject, "Gold Variation", "Text")), LanguageManager.CurrentLanguage.options.colors_variationGold);

        //Enemy names text
        //Later down the line, could be better to get the names from EnemyBios.
        GameObject colorsEnemiesObject = FindDescendant(optionsMenu, "Scroll Rect", "Contents", "Enemies");

        TryToReplaceText(GetTextMeshProUGUI(colorsEnemiesObject), new[] { LanguageManager.CurrentLanguage.options.colors_enemies }, "--" + LanguageManager.CurrentLanguage.options.colors_enemies + "--");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Filth", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_filth);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Stray", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_stray);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Malicious Face", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Schism", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_schism);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Swordsmachine", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Cerberus", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Drone", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_drone);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Streetcleaner", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Shotgunner", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "V2", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_v2);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Mindflayer", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Virtue", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Stalker", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Sisyphus", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Sentry", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Idol", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_idol);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Ferryman", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Mannequin", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_mannequin);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Gutterman", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_gutterman);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(colorsEnemiesObject, "Guttertank", "Text")), LanguageManager.CurrentLanguage.enemyNames.enemyname_guttertank);

    }
    

    //Does not work for some reason, nothing gets translated
    private static void PatchRumbleOptions(GameObject optionMenu)
    {
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Text (1)")), LanguageManager.CurrentLanguage.options.rumble_title);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Total", "Text")), LanguageManager.CurrentLanguage.options.rumble_finalMultiplier);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Close", "Text")), LanguageManager.CurrentLanguage.options.save_close);

        //Loop through each entry
        GameObject rumbleEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < 21; x++) //Hardcoded, amount may increase in future updates
            {
                GameObject entry = rumbleEntryList.transform.GetChild(x).gameObject;
                //Throws an out of bounds error, but still swaps the text correctly...
                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Button", "Text (1)")), LanguageManager.CurrentLanguage.options.rumble_intensity);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Default Button (1)", "Text")), LanguageManager.CurrentLanguage.options.rumble_reset);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "End Delay Container", "Text (2)")), LanguageManager.CurrentLanguage.options.rumble_endDelay);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "End Delay Container", "Default Button", "Text")), LanguageManager.CurrentLanguage.options.rumble_reset);
            }
        }
        catch (Exception)
        {
            Logging.Warn("Rumble options exception, should be harmless unless if console is spammed with this");
        }

    }
    
    private static void PatchAdvancedOptions(GameObject optionMenu)
    {
        var opt = LanguageManager.CurrentLanguage.options;
        GameObject advancedOptions = optionMenu;

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptions, "Title")),
            new[] { opt.advanced_title }, "--" + opt.advanced_title + "--");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptions, "Close", "Text")), opt.steamLeaderboard_returnButton);

        //Cybergrind Reset Confirm
        GameObject cybergrindResetPanel = FindDescendant(advancedOptions, "Reset Cyber Grind Dialog", "Panel");
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Text (2)")), opt.advanced_cybergrindResetText1);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Text (1)")), opt.advanced_cybergrindResetText2);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Cancel", "Text")), opt.advanced_cybergrindResetCancel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(cybergrindResetPanel, "Confirm", "Text")), opt.advanced_cybergrindResetConfirm);

        //The Actual Options
        GameObject advancedOptionsSub = FindDescendant(advancedOptions, "Scroll View", "Viewport", "Content");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Cyber Grind Category")), LanguageManager.CurrentLanguage.levelNames.levelName_cybergrind);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Cyber Grind Options", "Local High Scores", "Text")), opt.advanced_cybergrindLocalHighScore);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Cyber Grind Options", "Local High Scores", "Reset", "Text")), opt.advanced_cybergrindResetButton);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Steam Category")), opt.advanced_steam);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Leaderboards", "Leaderboards", "Text")), opt.advanced_steamLeaderboardManage);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "Leaderboards", "Leaderboards", "Manage Button", "Text")), opt.advanced_steamLeaderboardManageButton);

        //"Current" indicator and the level titles
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Level 5-2 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Level 5-2 Category")), opt.advanced_level52);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-1 Options", "Level 7-1 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-1 Options", "Level 7-1 Category")), opt.advanced_level71);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-3 Options", "Level 7-3 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-3 Options", "Level 7-3 Category")), opt.advanced_level73);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Level 8-4 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Level 8-4 Category")), opt.advanced_level84);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-S Options", "Level 7-S Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-S Options", "Level 7-S Category")), opt.advanced_level7S);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "P-2 Options", "Level P-2 Category", "Current Level Indicator")), opt.advanced_currentLevel);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "P-2 Options", "Level P-2 Category")), opt.advanced_levelP2);

        //Levels
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Disable Water Scrolling", "Text")), opt.advanced_52WaterScrolling);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "5-2 Options", "Disable Water Waves", "Text")), opt.advanced_52WaterWaves);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-1 Options", "Local High Scores", "Text")), opt.advanced_71Dark);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-3 Options", "Local High Scores", "Text")), opt.advanced_73Grass);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Local High Scores (1)", "Text")), opt.advanced_84DisableArenaScrolling);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "8-4 Options", "Local High Scores", "Text")), opt.advanced_84DisableArenaRotation);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "7-S Options", "Local High Scores", "Text")), opt.advanced_7SHard);
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(advancedOptionsSub, "P-2 Options", "Local High Scores", "Text")), opt.advanced_P2DisableTunnelScrolling);
        
    }
    
    private static void PatchOptions(GameObject optionsMenu)
    {
        if (optionsMenu != null)
        {
            //Main buttons and text
            if (FindDescendant(optionsMenu, "Text") != null)
            {
                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionsMenu, "Text")), new[] { LanguageManager.CurrentLanguage.options.options_title }, "--" + LanguageManager.CurrentLanguage.options.options_title + "--");
            }

            GameObject leftColumn = FindDescendant(optionsMenu, "Navigation Rail");

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Text (7)")), new[] { LanguageManager.CurrentLanguage.options.category_general }, "-- " + LanguageManager.CurrentLanguage.options.category_general + " --");

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "General", "Text")), LanguageManager.CurrentLanguage.options.category_general);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Controls", "Text")), LanguageManager.CurrentLanguage.options.category_controls);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Video", "Text")), LanguageManager.CurrentLanguage.options.category_graphics);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Audio", "Text")), LanguageManager.CurrentLanguage.options.category_audio);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Assist", "Text")), LanguageManager.CurrentLanguage.options.category_assists);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Saves", "Text")), LanguageManager.CurrentLanguage.options.category_saves);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Text (8)")), new[] { LanguageManager.CurrentLanguage.options.category_customization }, "-- " + LanguageManager.CurrentLanguage.options.category_customization + " --");

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "HUD", "Text")), LanguageManager.CurrentLanguage.options.category_hud);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Colors", "Text")), LanguageManager.CurrentLanguage.options.category_colors);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(leftColumn, "Back", "Text")), LanguageManager.CurrentLanguage.options.options_back);

            TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionsMenu, "Palette Selector", "Close", "Text")), LanguageManager.CurrentLanguage.options.save_close);

            try
            {
                GameObject savesOptions = FindDescendant(optionsMenu, "Save Slots");
                try { PatchSavesOptions(savesOptions); } catch (Exception e) { Logging.Error("Failed to patch save options."); Logging.Error(e.ToString()); }
                GameObject colorblindOptions = FindDescendant(optionsMenu, "Pages", "ColorBlindness Options");
                try { PatchColorsOptions(colorblindOptions); } catch (Exception e) { Logging.Error("Failed to patch color options."); Logging.Error(e.ToString()); }
                GameObject rumbleOptions = FindDescendant(optionsMenu, "Rumble Settings");
                try { PatchRumbleOptions(rumbleOptions); } catch (Exception e) { Logging.Error("Failed to patch rumble options."); Logging.Error(e.ToString()); }
                GameObject advancedOptions = FindDescendant(optionsMenu, "Advanced Options");
                try { PatchAdvancedOptions(advancedOptions); } catch (Exception e) { Logging.Error("Failed to patch advanced options."); Logging.Error(e.ToString()); }
                GameObject steamOptions = FindDescendant(optionsMenu, "Leaderboard Manager");
                try { PatchSteamLeaderboard(steamOptions); } catch (Exception e) { Logging.Error("Failed to patch steam leaderboard."); Logging.Error(e.ToString()); }
            }
            catch (Exception e)
            {
                Logging.Error("Something went wrong while patching options.");
                Logging.Error(e.ToString());
            }

        }
        else
        {
            Logging.Error("An error occured while patching options menu");
        }

    }

    private static void PatchSteamLeaderboard(GameObject optionMenu)
    {
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Title")), LanguageManager.CurrentLanguage.options.steamLeaderboard_title);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Refresh Button", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_refreshButton);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(optionMenu, "Close", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_returnButton);

        //Loop through each entry
        GameObject SteamEntryList = FindDescendant(optionMenu, "Scroll View", "Viewport", "Content");
        try
        {
            for (int x = 0; x < SteamEntryList.transform.childCount; x++) //Hardcoded, amount may increase in future updates
            {
                GameObject entry = SteamEntryList.transform.GetChild(x).gameObject;

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Any Label")), LanguageManager.CurrentLanguage.options.steamLeaderboard_anyLabel);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "P Label")), LanguageManager.CurrentLanguage.options.steamLeaderboard_pLabel);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "Any Reset", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_reset);

                TryToReplaceText(GetTextMeshProUGUI(FindDescendant(entry, "P Reset Button", "Text")), LanguageManager.CurrentLanguage.options.steamLeaderboard_reset);
            }
        }
        catch (Exception e)
        {
            Logging.Error("Something went wrong while patching Steam Leaderboard.");
            Logging.Error(e.ToString());
        }

    }

    public static void Patch(ref GameObject game)
    {
        //Options are in two different locations.
        //On the main menu, it's root/Canvas/OptionsMenu.
        //In-game it's root/Canvas/OptionsMenu.
        GameObject optionsMenu;
        if (GetCurrentSceneName() == "Main Menu")
        {
            optionsMenu = FindDescendant(game, "OptionsMenu");
        }
        else
        {
            List<GameObject> rootObjects = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
            GameObject pauseObject = null;
            foreach (GameObject a in rootObjects)
            {
                if (a.gameObject.name == "Canvas")
                {
                    pauseObject = a.gameObject;
                    break;
                }
            }
            optionsMenu = FindDescendant(pauseObject, "OptionsMenu");
        }
        PatchOptions(optionsMenu);
    }
}
