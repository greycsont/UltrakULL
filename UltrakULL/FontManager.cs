using System;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;
using UnityEngine.TextCore.LowLevel;
using System.Reflection;

namespace UltrakULL;

public static class FontManager
{
    // This part will add in the fucking future
    public static Sprite[] CustomRankImages;
    public static Sprite ArabicUltrakillLogo;

    public static bool TMPFontReady;
    public static bool UseFontFallback;

    // These two mf is the game's font
    public static TMP_FontAsset MeseumFontAsset; // Garaldus (museum), loaded from basegameasset.bundle
    public static TMP_FontAsset TwinFont;        // VCR (default), cached from the game's loaded fonts

    private static TMP_FontAsset mainFallback;
    private static TMP_FontAsset museumFallback;
    private static TMP_FontAsset terminalFallback;  
    private static TMP_FontAsset secretFallback;

    private static readonly List<TMP_FontAsset> createdFonts = new();
    private static readonly Dictionary<string, TMP_FontAsset> alignedCache = new();
    private static bool sceneHookRegistered;

    // Make sure this func is called before LanguageManager.InitializeManager
    public static void Initialize()
    {
        LanguageManager.OnLanguageChanged += ApplyLanguageFallback;
    }

    public static void LoadFonts()
    {
        Logging.Message("Loading font resource bundle...");
        var fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "fontpack.bundle"));
        var baseFontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "basegameasset.bundle"));
        if (fontBundle == null)
        {
            Logging.Error("Failed to load fontPack.bundle");
            return;
        }
        MeseumFontAsset = baseFontBundle.LoadAsset<TMP_FontAsset>("GFSGaraldus SDF");

        mainFallback = fontBundle.LoadAsset<TMP_FontAsset>("MainFont");
        museumFallback = fontBundle.LoadAsset<TMP_FontAsset>("MuseumFont");
        terminalFallback = fontBundle.LoadAsset<TMP_FontAsset>("TerminalFont");
        secretFallback = fontBundle.LoadAsset<TMP_FontAsset>("SecretFont");

        TMPFontReady = mainFallback != null;
        if (!TMPFontReady)
            Logging.Error("fontPack.bundle is missing the 'MainFont' TMP_FontAsset");
    }

    private static void ApplyLanguageFallback(ValueChangedEvent<Lang> change)
    {
        if (!TMPFontReady)
            return;

        // Some Unicode characters are shared between multiple languages but have
        // language-specific glyphs (especially in CJK fonts).
        // Remove the previous language's fallback fonts before adding the new ones
        // to ensure the correct glyphs are used.
        RemoveFallbacksOf(change.OldValue);

        Lang lang = change.NewValue;
        if (lang == null || lang.IsEnglish)
            return;

        UseFontFallback = lang.Json.metadata.fonts?.UseFallback ?? false;

        if (mainFallback == null)
            return;

        if (!sceneHookRegistered)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            sceneHookRegistered = true;
        }

        RegisterFallbacksForLoadedFonts(lang);
    }

    // Scenes bring their own TMP_FontAssets with them, so re-run on every load.
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Lang lang = LanguageManager.Current;
        if (mainFallback != null && lang != null && !lang.IsEnglish)
            RegisterFallbacksForLoadedFonts(lang);
    }

    private static void RegisterFallbacksForLoadedFonts(Lang lang)
    {
        if (mainFallback == null)
            return;

        foreach (TMP_FontAsset primary in Resources.FindObjectsOfTypeAll<TMP_FontAsset>())
        {
            if (primary == null)
                continue;

            string name = primary.name?.ToLowerInvariant();
            if (string.IsNullOrEmpty(name) || name.Contains("_alignedto_") || createdFonts.Contains(primary))
                continue;
            if (primary == mainFallback || primary == museumFallback || primary == terminalFallback || primary == secretFallback)
                continue;

            TMP_FontAsset source = null;
            if (name.Contains("tahoma"))
                source = terminalFallback;
            else if (name.Contains("bittypix"))
                source = secretFallback;
            else if (name.Contains("garaldus") || name.Contains("garamond") || name.Contains("museum"))
                source = museumFallback;
            else if (name.Contains("vcr-osd-replayed"))
                source = mainFallback;
            else
                source = mainFallback;
            
            if (name.Contains("vcr_osd_mono_ui"))
                TwinFont = primary;

            AddFallback(lang, primary, source);
        }
    }

    // Chooses the twin primary for a legacy Text based on the font it originally used.
    public static TMP_FontAsset GetTwinFont(string sourceFontName)
    {
        if (!string.IsNullOrEmpty(sourceFontName))
        {
            string name = sourceFontName.ToLowerInvariant();
            if (name.Contains("garaldus") || name.Contains("garamond") || name.Contains("museum"))
                return MeseumFontAsset != null ? MeseumFontAsset : TwinFont;
        }
        return TwinFont;
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
        alignedCache.Clear();

        foreach (TMP_FontAsset font in createdFonts)
            if (font != null)
                UnityEngine.Object.Destroy(font);
        createdFonts.Clear();

        if (lang == null)
            return;

        foreach ((TMP_FontAsset font, TMP_FontAsset fallback) in lang.AppliedFallbacks)
            font?.fallbackFontAssetTable?.Remove(fallback);
        lang.AppliedFallbacks.Clear();

        // The four fallbacks are loaded once in LoadFonts and reused for every language;
        // don't null them here or ApplyLanguageFallback would bail after the first switch.
    }
}
