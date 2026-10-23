using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UltrakULL.json;
using System.Text;
using Newtonsoft.Json;

namespace UltrakULL;

public static class FontManager
{
    // These two mf is the game's font
    // No relationship with Languages
    public static TMP_FontAsset MeseumFontAsset; // Garaldus (museum), loaded from basegameasset.bundle
    public static TMP_FontAsset TwinFont;

    // Make sure this func is called before LanguageManager.InitializeManager
    public static void Initialize()
    {
        LanguageManager.OnLanguageChanged += ApplyLanguageFonts;
    }

    public static void LoadFonts()
    {
        Logging.Message("Loading font resource bundle...");
        var baseFontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "basegameasset.bundle"));
        MeseumFontAsset = baseFontBundle.LoadAsset<TMP_FontAsset>("GFSGaraldus SDF");
        TwinFont = baseFontBundle.LoadAsset<TMP_FontAsset>("VCR_OSD_MONO_TWINFONT");

        // I don't think I would make a default pack when the remaster or f remake
        //   ver of vcr-osd-replayed is done
    }

    public static void TryLoadFontFromBundle(string fontBundlePath, out FontConfig fontConfig, out AssetBundle fontBundle)
    {
        try
        {
            fontConfig = JsonConvert.DeserializeObject<FontConfig>(
                File.ReadAllText(Path.Combine(fontBundlePath, "fontconfig.json")
            ));
            fontBundle = AssetBundle.LoadFromFile(Path.Combine(fontBundlePath, fontConfig.FontPackName)); 
        }
        catch (Exception)
        {
            fontConfig = null;
            fontBundle = null;
        }
    }

    /// <summary>
    /// Some Unicode characters are shared between multiple languages but have language-specific
    ///   glyphs (especially in CJK fonts). Remove the previous language's fallbacks before adding the
    ///   new ones so the correct glyphs are used.
    /// </summary>
    /// <param name="change"></param>
    private static void ApplyLanguageFonts(ValueChangedEvent<Lang> change)
    {
        RemoveFallbacksOf(change.OldValue);
        TryRegisterFallback(change.NewValue);
    }

    public static void RefreshFallback()
    {
        TryRegisterFallback(LanguageManager.Current);
    }

    private static void TryRegisterFallback(Lang lang)
    {
        if (lang == null || lang.IsEnglish || !lang.IsFontLoaded || !lang.UseFontFallback)
            return;

        RegisterFallbacksForLoadedFonts(lang);
    }

    private static void RegisterFallbacksForLoadedFonts(Lang lang)
    {
        foreach (var primary in Resources.FindObjectsOfTypeAll<TMP_FontAsset>())
        {
            if (primary == null)
                continue;

            var name = primary.name?.ToLowerInvariant();
            if (string.IsNullOrEmpty(name) || name.Contains("_alignedto_"))
                continue;
            // don't attach a fallback to one of our own fallback fonts
            // Or it'll makes the logics as shit as f
            if (primary == lang.MainFontAsset || primary == lang.MuseumAsset
                || primary == lang.TerminalAsset || primary == lang.SecretTerminalAsset)
                continue;

            TMP_FontAsset source = null;
            if (name.Contains("tahoma"))
                source = lang.TerminalAsset;
            else if (name.Contains("bittypix"))
                source = lang.SecretTerminalAsset;
            else if (name.Contains("garaldus") || name.Contains("garamond") || name.Contains("museum"))
                source = lang.MuseumAsset;
            else if (name.Contains("vcr-osd-replayed"))
                source = lang.MainFontAsset;
            else if (primary == TwinFont)
                source = lang.MainFontAsset;

            AddFallback(lang, primary, source);
        }
    }

    // Chooses the twin primary for a legacy Text based on the font it originally used.
    public static TMP_FontAsset GetTwinFont(string sourceFontName)
    {
        string name = sourceFontName?.ToLowerInvariant();
        bool isMuseum =
            !string.IsNullOrEmpty(name)
            && (name.Contains("garaldus")
                || name.Contains("garamond")
                || name.Contains("museum"));

        var original = isMuseum
            ? MeseumFontAsset ?? TwinFont
            : TwinFont;

        Lang lang = LanguageManager.Current;
        if (lang == null || lang.IsEnglish || lang.UseFontFallback)
            return original;

        return isMuseum
            ? lang.MuseumAsset ?? lang.MainFontAsset ?? original
            : lang.MainFontAsset ?? original;
    }

    private static void AddFallback(Lang lang, TMP_FontAsset primary, TMP_FontAsset fallback)
    {
        if (primary == null || fallback == null || primary == fallback)
            return;
        primary.fallbackFontAssetTable ??= new List<TMP_FontAsset>();
        if (primary.fallbackFontAssetTable.Contains(fallback))
            return;
        primary.fallbackFontAssetTable.Add(fallback);
        lang.AppliedFallbacks.Add((primary, fallback));
    }

    private static void RemoveFallbacksOf(Lang lang)
    {
        if (lang == null)
            return;

        foreach ((TMP_FontAsset font, TMP_FontAsset fallback) in lang.AppliedFallbacks)
            font?.fallbackFontAssetTable?.Remove(fallback);
        lang.AppliedFallbacks.Clear();
    }
}
