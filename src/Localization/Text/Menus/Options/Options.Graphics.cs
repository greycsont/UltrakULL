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

    static public void PatchGraphicsOptions(GameObject optionsMenu)
    {
        //Graphics options
        GameObject graphicsContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //--GENERAL--
        graphicsContent.Localize<TextMeshProUGUI>("--{0}--".FormatWith(LanguageManager.CurrentLanguage.options.category_general), "-- General --", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_resolution, "Resolution", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_fullscreen, "Fullscreen", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_maxFps, "Target Framerate", "Text");

        GameObject fpsObject = FindDescendant(graphicsContent, "Target Framerate", "Dropdown(Clone)");
        TMP_Dropdown fpsDropdown = fpsObject.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
        fpsDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.graphics_maxFpsNone);
        fpsDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.graphics_maxFps2x);

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_vsync, "VSync", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_fieldOfVision, "Field of View", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_gamma, "Gamma (Brightness)", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_useFallbackShaders, "Use Fallback Shaders (Requires Reload)", "Text");

        //-- PSX --
        graphicsContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.graphics_filters)
            + "\n" + "<size=16>{0}</size>".FormatWith(LanguageManager.CurrentLanguage.options.graphics_filtersDescription), "-- PSX --", "Text");


        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_pixelisation, "Downscaling", "Text");

        GameObject resolution = FindDescendant(graphicsContent, "Downscaling", "Dropdown(Clone)");
        TMP_Dropdown resolutionDropdown = resolution.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

        resolutionDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisationNone);
        resolutionDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisation720p);
        resolutionDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisation480p);
        resolutionDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisation360p);
        resolutionDropdownListText[4].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisation240p);
        resolutionDropdownListText[5].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisation144p);
        resolutionDropdownListText[6].Localize(LanguageManager.CurrentLanguage.options.graphics_pixelisation36p);


        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_dithering, "Dithering", "Text");

        SliderValueToText ditheringSlider = FindDescendant(graphicsContent, "Dithering", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        ditheringSlider.ifMin = LanguageManager.CurrentLanguage.options.graphics_ditheringMinimum;

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_textureWarping, "Texture Warping", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_vertexWarping, "Vertex Warping", "Text");

        GameObject vertexWarping = FindDescendant(graphicsContent, "Vertex Warping", "Dropdown(Clone)");
        TMP_Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

        vertexWarpingDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.graphics_vertexWarpingNone);
        vertexWarpingDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.graphics_vertexWarpingLight);
        vertexWarpingDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.graphics_vertexWarpingMedium);
        vertexWarpingDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.graphics_vertexWarpingStrong);
        vertexWarpingDropdownListText[4].Localize(LanguageManager.CurrentLanguage.options.graphics_vertexWarpingVeryStrong);
        vertexWarpingDropdownListText[5].Localize(LanguageManager.CurrentLanguage.options.graphics_vertexWarpingAbsurd);

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_customColorPalette, "Custom Color Palette", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_customPaletteTexture, "Color Palette Texture", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_customColorPaletteSelect, "Color Palette Texture", "Action Button(Clone)", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_colorCompression, "Color Compression", "Text");

        GameObject colorCompression = FindDescendant(graphicsContent, "Color Compression", "Dropdown(Clone)");
        TMP_Dropdown colorCompressionDropdown = colorCompression.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

        colorCompressionDropdownListText[0].Localize(LanguageManager.CurrentLanguage.options.graphics_colorCompressionNone);
        colorCompressionDropdownListText[1].Localize(LanguageManager.CurrentLanguage.options.graphics_colorCompressionLight);
        colorCompressionDropdownListText[2].Localize(LanguageManager.CurrentLanguage.options.graphics_colorCompressionMedium);
        colorCompressionDropdownListText[3].Localize(LanguageManager.CurrentLanguage.options.graphics_colorCompressionStrong);
        colorCompressionDropdownListText[4].Localize(LanguageManager.CurrentLanguage.options.graphics_colorCompressionVeryStrong);
        colorCompressionDropdownListText[5].Localize(LanguageManager.CurrentLanguage.options.graphics_colorCompressionAbsurd);
        
        //-- PERFORMANCE --
        graphicsContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.graphics_performance), "-- Performance --", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceSimpleExplosions, "Simpler Explosions", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceSimpleFire, "Simpler Fire", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceSimpleSpawn, "Simpler Spawn Effects", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviParticles, "Disable Environmental Particle Effects", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviHitParticles, "Disable Environmental Hit Particles", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceDisableHeatWaves, "Disable Heat Waves", "Text");

        //-- GORE --
        graphicsContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.graphics_gore) 
            + "\n" + "<size=16>{0}</size>".FormatWith(LanguageManager.CurrentLanguage.options.graphics_goreNote), "-- Gore --", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreEnable, "Enable Blood & Gore", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreDisablePhysics, "Freeze Gore Physics", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreMaxBloodStains, "Max Bloodstains", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreBloodChance, "Bloodstain Chance", "Text");

        graphicsContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreMaxGore, "Max Gore Per Room", "Text");
    }
}
