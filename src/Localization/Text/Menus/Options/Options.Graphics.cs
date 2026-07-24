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
}
