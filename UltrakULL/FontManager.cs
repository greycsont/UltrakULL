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

namespace UltrakULL;

public static class FontManager
{
    public static Font VcrFont;
    public static Font GlobalFont;
    public static Font MuseumFont;
    public static TMP_FontAsset GlobalFontTMP;
    public static TMP_FontAsset MuseumFontTMP;
    public static TMP_FontAsset CJKFontTMP;
    public static TMP_FontAsset jaFontTMP;
    public static TMP_FontAsset ArabicFontTMP;
    public static TMP_FontAsset HebrewFontTMP;
    public static Sprite[] CustomRankImages;
    public static Sprite ArabicUltrakillLogo;

    public static bool GlobalFontReady;
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
        AssetBundle fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "ullfont.resource"));
        AssetBundle extraFontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "arabfonts", "arabfonts"));

        if (extraFontBundle == null)
        {
            Logging.Error("Failed to load Arabic / Hebrew fonts. :( (No extra AssetBundle found!)");
        }
        else
        {
            Logging.Message("Extra Fonts Asset Bundle has been loaded...");

            TMP_FontAsset arabicFontAsset = extraFontBundle.LoadAsset<TMP_FontAsset>("segoeui SDF Arabic");
            TMP_FontAsset hebrewFontAsset = extraFontBundle.LoadAsset<TMP_FontAsset>("segoeui SDF Hebrew");
            Sprite arabicLogo = extraFontBundle.LoadAsset<Sprite>("2023_improved_logo.png");

            CustomRankImages = new Sprite[8];
            CustomRankImages[0] = extraFontBundle.LoadAsset<Sprite>("RankD.png");
            CustomRankImages[1] = extraFontBundle.LoadAsset<Sprite>("RankC.png");
            CustomRankImages[2] = extraFontBundle.LoadAsset<Sprite>("RankB.png");
            CustomRankImages[3] = extraFontBundle.LoadAsset<Sprite>("RankA.png");
            CustomRankImages[4] = extraFontBundle.LoadAsset<Sprite>("RankS.png");
            CustomRankImages[5] = extraFontBundle.LoadAsset<Sprite>("RankSS.png");
            CustomRankImages[6] = extraFontBundle.LoadAsset<Sprite>("RankSSS.png");
            CustomRankImages[7] = extraFontBundle.LoadAsset<Sprite>("RankU.png");

            if (arabicFontAsset == null) Logging.Warn("There is no Arabic font in this AssetBundle!?");
            else { Logging.Message("Arabic Font has been loaded."); ArabicFontTMP = arabicFontAsset; }

            if (arabicLogo == null) Logging.Warn("There is no Arabic logo in this AssetBundle!?");
            else ArabicUltrakillLogo = arabicLogo;

            if (hebrewFontAsset == null) Logging.Warn("There is no Hebrew font in this AssetBundle!?");
            else { Logging.Message("Hebrew Font has been loaded."); HebrewFontTMP = hebrewFontAsset; }
        }

        if (fontBundle == null)
        {
            Logging.Error("FAILED TO LOAD");
            return;
        }

        Logging.Message("Font bundle loaded.");
        Logging.Message("Loading fonts from bundle...");

        Font font1 = fontBundle.LoadAsset<Font>("VCR_OSD_MONO_EXTENDED");
        Font font2 = fontBundle.LoadAsset<Font>("EBGaramond-Regular");
        TMP_FontAsset font1TMP = fontBundle.LoadAsset<TMP_FontAsset>("VCR_OSD_MONO_EXTENDED_TMP");
        TMP_FontAsset font2TMP = fontBundle.LoadAsset<TMP_FontAsset>("EBGaramond-Regular_TMP");
        TMP_FontAsset cjkFontTMP = fontBundle.LoadAsset<TMP_FontAsset>("NotoSans-CJK_TMP");
        TMP_FontAsset jafontTMP = fontBundle.LoadAsset<TMP_FontAsset>("JF-Dot-jiskan16s-2000_TMP");

        if (font1 && font2)
        {
            Logging.Warn("Normal fonts loaded.");
            GlobalFont = font1;
            MuseumFont = font2;
            GlobalFontReady = true;
        }
        else
        {
            Logging.Error("FAILED TO LOAD NORMAL FONTS");
            GlobalFontReady = false;
        }

        if (font1TMP && font2TMP && cjkFontTMP)
        {
            Logging.Warn("Normal TMP fonts loaded.");
            GlobalFontTMP = font1TMP;
            MuseumFontTMP = font2TMP;
            CJKFontTMP = cjkFontTMP;
            jaFontTMP = jafontTMP;
            TMPFontReady = true;
        }
        else
        {
            Logging.Error("FAILED TO LOAD TMP FONTS");
            TMPFontReady = false;
        }
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
        
        mainFallback = LoadCustomFont(meta.fonts?.MainFont) ?? BakedFallbackForLanguage(meta.langName);
        if (mainFallback == null)
            return;

        museumFallback = LoadCustomFont(meta.fonts?.MuseumFont) ?? mainFallback;
        terminalFallback = LoadCustomFont(meta.fonts?.TerminalFont) ?? mainFallback;
        secretFallback = LoadCustomFont(meta.fonts?.SecretTerminalFont) ?? mainFallback;

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
            else
                source = mainFallback;

            AddFallback(primary, AdjustFallback(primary, source));
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

    private static TMP_FontAsset AdjustFallback(TMP_FontAsset primary, TMP_FontAsset source)
    {
        if (primary == null || source == null || primary == source)
            return source;

        string key = primary.name + "__" + source.name;
        if (alignedCache.TryGetValue(key, out TMP_FontAsset cached) && cached != null)
            return cached;

        TMP_FontAsset clone = UnityEngine.Object.Instantiate(source);
        clone.name = source.name + "_ull";

        FaceInfo ff = clone.faceInfo;
        FontsMetadata fonts = LanguageManager.CurrentLanguage?.metadata?.fonts;
        if (fonts != null)
        {
            ff.scale *= fonts.FallbackScale;
            ff.baseline += fonts.FallbackBaselineOffset +6.5f;
            ff.ascentLine += fonts.FallbackBaselineOffset +6.5f;
            ff.descentLine += fonts.FallbackBaselineOffset + 6.5f;
        }
        ff.lineHeight = primary.faceInfo.lineHeight;
        clone.faceInfo = ff;
        clone.ReadFontAssetDefinition();

        alignedCache[key] = clone;
        createdFonts.Add(clone);
        return clone;
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

        mainFallback = museumFallback = terminalFallback = secretFallback = null;
    }

    private static TMP_FontAsset BakedFallbackForLanguage(string langName)
    {
        string code = (langName ?? "").ToLowerInvariant();
        if (code.Length >= 2)
            code = code.Substring(0, 2);
        switch (code)
        {
            case "zh": return CJKFontTMP;
            case "ja": return jaFontTMP;
            case "ar": case "fa": case "ur": return ArabicFontTMP;
            case "he": case "yi": case "la": case "ro": case "jr": return HebrewFontTMP;
            default: return null;
        }
    }

    private static TMP_FontAsset LoadCustomFont(string fontName)
    {
        if (string.IsNullOrEmpty(fontName) || LanguageManager.CurrentLanguage?.metadata == null)
            return null;

        string dir = Path.Combine(Paths.ConfigPath, "ultrakull", "fonts", LanguageManager.CurrentLanguage.metadata.langName);
        string path = FindFontFile(dir, fontName);
        if (path == null)
        {
            Logging.Warn($"[Font] Custom font not found: {fontName} (in {dir})");
            return null;
        }

        TMP_FontAsset tmp = CreateTMPFontFromFile(path);
        if (tmp != null)
            createdFonts.Add(tmp);
        return tmp;
    }

    private static string FindFontFile(string directory, string baseName)
    {
        if (string.IsNullOrEmpty(baseName) || !Directory.Exists(directory))
            return null;

        string exact = Path.Combine(directory, baseName);
        if (File.Exists(exact))
            return exact;

        foreach (string ext in new[] { ".ttf", ".otf", ".ttc", ".woff", ".woff2" })
        {
            string path = Path.Combine(directory, baseName + ext);
            if (File.Exists(path))
                return path;
        }
        return null;
    }

    private static TMP_FontAsset CreateTMPFontFromFile(string fontPath)
    {
        try
        {
            Font unityFont = new Font(fontPath);
            TMP_FontAsset tmpFont = TMP_FontAsset.CreateFontAsset(unityFont);
            tmpFont.isMultiAtlasTexturesEnabled = true;
            if (tmpFont == null)
                Logging.Error($"[Font] CreateFontAsset returned null for {fontPath}");
            else
                Logging.Message($"[Font] Created custom TMP font '{tmpFont.name}' from {Path.GetFileName(fontPath)}");
            return tmpFont;
        }
        catch (Exception e)
        {
            Logging.Error($"[Font] Failed to create TMP font from {fontPath}: {e.Message}");
            return null;
        }
    }
}
