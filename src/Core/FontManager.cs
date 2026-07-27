using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UltrakULL.json;
using System.Text;

namespace UltrakULL;

/// <summary>Loads shared font assets and manages per-language TMP fallbacks.</summary>
public static class FontManager
{
    // This part will add in the fucking future
    public static Sprite[] CustomRankImages;
    public static Sprite ArabicUltrakillLogo;

    public static bool TMPFontReady;

    // These two mf is the game's font
    // No relationship with Languages
    public static TMP_FontAsset MeseumFontAsset; // Garaldus (museum), loaded from basegameasset.bundle
    public static TMP_FontAsset TwinFont;        // VCR (default), cached from the game's loaded fonts

    // Default FontAsset
    // Load from fontpack.bundle
    // Currently it's chinese's fontpack
    // In the future I'll replace it all to unifont
    private static TMP_FontAsset defaultMainFont;
    private static TMP_FontAsset defaultMuseumFont;
    private static TMP_FontAsset defaultTerminalFont;
    private static TMP_FontAsset defaultSecretFont;

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
        TMPFontReady = true;

        //LoadDefaultPack();

        void LoadDefaultPack()
        {
            var fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "fontpack.bundle"));
            if (fontBundle == null)
            {
                Logging.Error("Failed to load fontPack.bundle");
                return;
            }

            defaultMainFont = fontBundle.LoadAsset<TMP_FontAsset>("MainFont");
            defaultMuseumFont = fontBundle.LoadAsset<TMP_FontAsset>("MuseumFont");
            defaultTerminalFont = fontBundle.LoadAsset<TMP_FontAsset>("TerminalFont");
            defaultSecretFont = fontBundle.LoadAsset<TMP_FontAsset>("SecretFont");

            TMPFontReady = defaultMainFont != null;
            if (!TMPFontReady)
                Logging.Error("fontPack.bundle is missing the 'MainFont' TMP_FontAsset");
        }
    }

    public static void LoadLangFonts(Lang lang)
    {
        if (lang.FontBundle != null)
            return;

        var fontBundle = AssetBundle.LoadFromFile(lang.FontBundlePath);
        if (fontBundle == null)
        {
            Logging.Warn($"Failed to load language font bundle: {lang.FontBundlePath}");
            return;
        }

        var stringbuilder = new StringBuilder();

        foreach (var fontAsset in fontBundle.LoadAllAssets<TMP_FontAsset>())
        {
            stringbuilder.AppendLine(fontAsset.name);
        }

        Logging.Info($"{stringbuilder.ToString()}");

        lang.FontBundle = fontBundle;

        var fontNames = lang.Json.metadata.fonts;
        lang.MainFontAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontNames.MainFont);
        lang.MuseumAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontNames.MuseumFont);
        lang.TerminalAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontNames.TerminalFont);
        lang.SecretTerminalAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontNames.SecretTerminalFont);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lang"></param>
    private static void ResolveFonts(Lang lang)
    {
        lang.MainFontAsset ??= defaultMainFont;
        lang.MuseumAsset ??= defaultMuseumFont;
        lang.TerminalAsset ??= defaultTerminalFont;
        lang.SecretTerminalAsset ??= defaultSecretFont;
    }

    /// <summary>
    /// Some Unicode characters are shared between multiple languages but have language-specific
    /// glyphs (especially in CJK fonts). Remove the previous language's fallbacks before adding the
    /// new ones so the correct glyphs are used.
    /// </summary>
    /// <param name="change"></param>
    private static void ApplyLanguageFonts(ValueChangedEvent<Lang> change)
    {
        if (!TMPFontReady)
            return;

        RemoveFallbacksOf(change.OldValue);

        Lang lang = change.NewValue;
        if (lang == null || lang.IsEnglish)
            return;

        LoadLangFonts(lang);
        ResolveFonts(lang);

        if (lang.UseFontFallback)
            RegisterFallbacksForLoadedFonts(lang);
    }

    /// <summary>
    /// Call when sceneloaded
    /// </summary>
    public static void RefreshFallback()
    {
        Lang lang = LanguageManager.Current;
        if (TMPFontReady && lang != null && !lang.IsEnglish && lang.UseFontFallback)
            RegisterFallbacksForLoadedFonts(lang);
    }

    private static void RegisterFallbacksForLoadedFonts(Lang lang)
    {
        foreach (TMP_FontAsset primary in Resources.FindObjectsOfTypeAll<TMP_FontAsset>())
        {
            if (primary == null)
                continue;

            string name = primary.name?.ToLowerInvariant();
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

            if (name.Contains("vcr_osd_mono_ui"))
                TwinFont = primary;

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
