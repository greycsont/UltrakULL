using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;

/*
 * Current Game Version : 17d4
 * Update time: 26/7/2026
 * 
 * Currently, there's
 *
 * vcr-osd-replayed
 * VCR_OSD_MONO_1
 * VCR_OSD_MONO_UI
 * VCR_OSD_MONO_1 and VCR_OSD_MONO_UI uses vcr-osd-replayed as fallback font
 *
 * fs-tahoma-8px SDF
 * fs-tahoma-8px SDF v2 -> terminal FontAsset
 * btw there's properties looks the same
 *
 *
 * Bittypix Monospace SDF -> secret terminal FontAsset
 *
 * MuseumFont -> I have no idea where it fk used
 * From what I see everything in Museum uses text
 *
 *
 */

namespace UltrakULL;

[HarmonyPatch(typeof(TextMeshProUGUI))]
public static class TextMeshProFontSwap
{
    private sealed class OriginalFont
    {
        public TMP_FontAsset Font;
        public Material Material;
    }

    private static readonly Dictionary<TMP_Text, OriginalFont> originalFonts = new();

    public static void Initialize()
    {
        LanguageManager.OnLanguageChanged += OnLanguageChanged;
    }

    [HarmonyPatch(nameof(TextMeshProUGUI.OnEnable))] [HarmonyPostfix]
    private static void OnEnable_Postfix(TextMeshProUGUI __instance)
    {
        Apply(__instance);
    }

    public static void Apply(TMP_Text text)
    {
        Lang lang = LanguageManager.Current;
        if (!FontManager.TMPFontReady
            || LanguageManager.IsEnglish
            || lang == null
            || lang.UseFontFallback)
            return;

        if (text.font == lang.MainFontAsset
            || text.font == lang.TerminalAsset
            || text.font == lang.MuseumAsset
            || text.font == lang.SecretTerminalAsset)
            return;

        var font = GetReplacementFont(text);
        if (font == null || font == text.font)
            return;

        Material sourceMaterial = text.fontSharedMaterial ?? text.font.material;
        if (sourceMaterial == null || font.material == null)
            return;

        originalFonts.TryAdd(text, new OriginalFont
        {
            Font = text.font,
            Material = text.fontSharedMaterial
        });

        text.font = font;
        text.fontSharedMaterial = TMP_MaterialManager.GetFallbackMaterial(sourceMaterial, font.material);
    }

    private static void OnLanguageChanged(ValueChangedEvent<Lang> change)
    {
        foreach (var pair in originalFonts)
        {
            if (pair.Key == null)
                continue;

            pair.Key.font = pair.Value.Font;
            pair.Key.fontSharedMaterial = pair.Value.Material;
        }

        originalFonts.Clear();

        foreach (var text in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>())
            Apply(text);
    }

    public static TMP_FontAsset GetReplacementFont(TMP_Text text)
    {
        string fontName = text.font.name;
        
        return fontName switch
        {
            "VCR_OSD_MONO_1" or "VCR_OSD_MONO_UI" or "vcr-osd-replayed"
                => LanguageManager.Current?.MainFontAsset,
            "fs-tahoma-8px SDF" or "fs-tahoma-8px SDF v2"
                => LanguageManager.Current?.TerminalAsset,
            "MeseumFont" => LanguageManager.Current?.MuseumAsset,
            "Bittypix Monospace SDF" => LanguageManager.Current?.SecretTerminalAsset,
            _ => LanguageManager.Current.MainFontAsset
        };
    }
}
