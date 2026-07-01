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

    private static TMP_FontAsset mainFallback;
    private static TMP_FontAsset museumFallback;
    private static TMP_FontAsset terminalFallback;  
    private static TMP_FontAsset secretFallback;

    private static readonly List<(TMP_FontAsset font, TMP_FontAsset fallback)> appliedFallbacks = new();
    private static readonly List<TMP_FontAsset> createdFonts = new();
    private static readonly Dictionary<string, TMP_FontAsset> alignedCache = new();
    private static bool sceneHookRegistered;

    public static void LoadFonts()
    {
        Logging.Message("Loading font resource bundle...");
        var fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "fontpack.bundle"));
        if (fontBundle == null)
        {
            Logging.Error("Failed to load fontPack.bundle");
            return;
        }

        mainFallback = fontBundle.LoadAsset<TMP_FontAsset>("MainFont");
        museumFallback = fontBundle.LoadAsset<TMP_FontAsset>("MuseumFont");
        terminalFallback = fontBundle.LoadAsset<TMP_FontAsset>("TerminalFont");
        secretFallback = fontBundle.LoadAsset<TMP_FontAsset>("SecretFont");

        TMPFontReady = mainFallback != null;
        if (!TMPFontReady)
            Logging.Error("fontPack.bundle is missing the 'MainFont' TMP_FontAsset");
    }

    public static void ApplyLanguageFallback()
    {
        if (!TMPFontReady)
            return;

        ClearAppliedFallbacks();

        if (isUsingEnglish())
            return;

        Metadata meta = LanguageManager.CurrentLanguage?.metadata;
        if (meta == null)
            return;

        UseFontFallback = meta.fonts?.UseFallback ?? false;
        
        if (mainFallback == null)
            return;

        if (!sceneHookRegistered)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            sceneHookRegistered = true;
        }

        RegisterFallbacksForLoadedFonts();
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mainFallback != null)
            RegisterFallbacksForLoadedFonts();
    }

    private static void RegisterFallbacksForLoadedFonts()
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

            TMP_FontAsset source;
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

            AddFallback(primary, source);
        }
    }

    private static void AddFallback(TMP_FontAsset primary, TMP_FontAsset fallback)
    {
        if (primary == null || fallback == null || primary == fallback)
            return;
        primary.fallbackFontAssetTable ??= new List<TMP_FontAsset>();
        if (primary.fallbackFontAssetTable.Contains(fallback))
            return;
        primary.fallbackFontAssetTable.Add(fallback);
        appliedFallbacks.Add((primary, fallback));
    }

    private static void ClearAppliedFallbacks()
    {
        foreach ((TMP_FontAsset font, TMP_FontAsset fallback) in appliedFallbacks)
            font?.fallbackFontAssetTable?.Remove(fallback);
        appliedFallbacks.Clear();
        alignedCache.Clear();

        foreach (TMP_FontAsset font in createdFonts)
            if (font != null)
                UnityEngine.Object.Destroy(font);
        createdFonts.Clear();

        // The four fallbacks are loaded once in LoadFonts and reused for every language;
        // don't null them here or ApplyLanguageFallback would bail after the first switch.
    }
}
