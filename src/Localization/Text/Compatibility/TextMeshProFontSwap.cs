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

        var sourceMaterial = text.fontMaterial;
        text.font = font;
        text.fontSharedMaterial = TMP_MaterialManager.GetFallbackMaterial(sourceMaterial, font.material);
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
