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

    static public void PatchGraphicsOptions(GameObject optionsMenu)
    {
        //Graphics options
        GameObject graphicsContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //--GENERAL--
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("--{0}--", LanguageManager.CurrentLanguage.options.category_general), graphicsContent, "-- General --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_resolution, graphicsContent, "Resolution", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_fullscreen, graphicsContent, "Fullscreen", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_maxFps, graphicsContent, "Target Framerate", "Text");

        GameObject fpsObject = FindDescendant(graphicsContent, "Target Framerate", "Dropdown(Clone)");
        TMP_Dropdown fpsDropdown = fpsObject.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
        TryReplaceText(fpsDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_maxFpsNone);
        TryReplaceText(fpsDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_maxFps2x);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_vsync, graphicsContent, "VSync", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_fieldOfVision, graphicsContent, "Field of View", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_gamma, graphicsContent, "Gamma (Brightness)", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_useFallbackShaders, graphicsContent, "Use Fallback Shaders (Requires Reload)", "Text");

        //-- PSX --
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --\n<size=16>{1}</size>",
            LanguageManager.CurrentLanguage.options.graphics_filters,
            LanguageManager.CurrentLanguage.options.graphics_filtersDescription), graphicsContent, "-- PSX --", "Text");


        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_pixelisation, graphicsContent, "Downscaling", "Text");

        GameObject resolution = FindDescendant(graphicsContent, "Downscaling", "Dropdown(Clone)");
        TMP_Dropdown resolutionDropdown = resolution.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

        TryReplaceText(resolutionDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_pixelisationNone);
        TryReplaceText(resolutionDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_pixelisation720p);
        TryReplaceText(resolutionDropdownListText[2], LanguageManager.CurrentLanguage.options.graphics_pixelisation480p);
        TryReplaceText(resolutionDropdownListText[3], LanguageManager.CurrentLanguage.options.graphics_pixelisation360p);
        TryReplaceText(resolutionDropdownListText[4], LanguageManager.CurrentLanguage.options.graphics_pixelisation240p);
        TryReplaceText(resolutionDropdownListText[5], LanguageManager.CurrentLanguage.options.graphics_pixelisation144p);
        TryReplaceText(resolutionDropdownListText[6], LanguageManager.CurrentLanguage.options.graphics_pixelisation36p);


        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_dithering, graphicsContent, "Dithering", "Text");

        SliderValueToText ditheringSlider = FindDescendant(graphicsContent, "Dithering", "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
        ditheringSlider.ifMin = LanguageManager.CurrentLanguage.options.graphics_ditheringMinimum;

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_textureWarping, graphicsContent, "Texture Warping", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_vertexWarping, graphicsContent, "Vertex Warping", "Text");

        GameObject vertexWarping = FindDescendant(graphicsContent, "Vertex Warping", "Dropdown(Clone)");
        TMP_Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

        TryReplaceText(vertexWarpingDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingNone);
        TryReplaceText(vertexWarpingDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingLight);
        TryReplaceText(vertexWarpingDropdownListText[2], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingMedium);
        TryReplaceText(vertexWarpingDropdownListText[3], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingStrong);
        TryReplaceText(vertexWarpingDropdownListText[4], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingVeryStrong);
        TryReplaceText(vertexWarpingDropdownListText[5], LanguageManager.CurrentLanguage.options.graphics_vertexWarpingAbsurd);

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_customColorPalette, graphicsContent, "Custom Color Palette", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_customPaletteTexture, graphicsContent, "Color Palette Texture", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_customColorPaletteSelect, graphicsContent, "Color Palette Texture", "Action Button(Clone)", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_colorCompression, graphicsContent, "Color Compression", "Text");

        GameObject colorCompression = FindDescendant(graphicsContent, "Color Compression", "Dropdown(Clone)");
        TMP_Dropdown colorCompressionDropdown = colorCompression.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

        TryReplaceText(colorCompressionDropdownListText[0], LanguageManager.CurrentLanguage.options.graphics_colorCompressionNone);
        TryReplaceText(colorCompressionDropdownListText[1], LanguageManager.CurrentLanguage.options.graphics_colorCompressionLight);
        TryReplaceText(colorCompressionDropdownListText[2], LanguageManager.CurrentLanguage.options.graphics_colorCompressionMedium);
        TryReplaceText(colorCompressionDropdownListText[3], LanguageManager.CurrentLanguage.options.graphics_colorCompressionStrong);
        TryReplaceText(colorCompressionDropdownListText[4], LanguageManager.CurrentLanguage.options.graphics_colorCompressionVeryStrong);
        TryReplaceText(colorCompressionDropdownListText[5], LanguageManager.CurrentLanguage.options.graphics_colorCompressionAbsurd);
        
        //-- PERFORMANCE --
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.graphics_performance), graphicsContent, "-- Performance --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceSimpleExplosions, graphicsContent, "Simpler Explosions", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceSimpleFire, graphicsContent, "Simpler Fire", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceSimpleSpawn, graphicsContent, "Simpler Spawn Effects", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviParticles, graphicsContent, "Disable Environmental Particle Effects", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviHitParticles, graphicsContent, "Disable Environmental Hit Particles", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_performanceDisableHeatWaves, graphicsContent, "Disable Heat Waves", "Text");

        //-- GORE --
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --\n<size=16>{1}</size>",
            LanguageManager.CurrentLanguage.options.graphics_gore,
            LanguageManager.CurrentLanguage.options.graphics_goreNote), graphicsContent, "-- Gore --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreEnable, graphicsContent, "Enable Blood & Gore", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreDisablePhysics, graphicsContent, "Freeze Gore Physics", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreMaxBloodStains, graphicsContent, "Max Bloodstains", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreBloodChance, graphicsContent, "Bloodstain Chance", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.graphics_goreMaxGore, graphicsContent, "Max Gore Per Room", "Text");
    }
}
