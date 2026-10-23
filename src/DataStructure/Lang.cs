using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace UltrakULL.json;

/// <summary>
/// What a stupid shit that i've ever write
/// </summary>
public sealed class Lang
{
    public JsonFormat Json { get;}

    public AngryTranslation angry = new ();
    public string Name => Json.metadata.langName;
    public string DisplayName => Json.metadata.langDisplayName;
    public bool IsEnglish => Json.metadata.langDisplayName == "English";
    public bool IsAngryTranslationLoaded { get; set; } = false;
    public bool IsRightToLeft => Json.metadata.langRTL;
    public bool UseFontFallback { get; set; } = false;

    public string SpeechFolder { get; }
    public string TextureFolder { get; }
    public string AngryLevelFolder { get; }
    public string VideoFolder { get; }
    public UILayoutProfile Layout { get; }

    internal AssetBundle FontBundle { get; set; }
    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }

    public bool IsFontLoaded = false;

    // Which fallbacks FontManager pushed into which game fonts while this language was active,
    // so switching away can undo exactly what this language added.
    internal readonly List<(TMP_FontAsset font, TMP_FontAsset fallback)> AppliedFallbacks = new();

    public Lang(JsonFormat json, string packageFolder = null, UILayoutProfile layout = null)
    {
        this.Json = json;
        this.Layout = layout;
        this.SpeechFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "audio"),
            ConfigPaths.GetLegacyAudioDirectory(this.Name));
        this.TextureFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "textures"),
            ConfigPaths.GetLegacyTextureDirectory(this.Name));
        this.AngryLevelFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "angry"),
            ConfigPaths.GetLegacyAngryDirectory(this.Name)
        );
        this.VideoFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "video"),
            ConfigPaths.GetLegacyVideoDirectory(this.Name)
        );

        this.IsFontLoaded = LoadFonts();
        LoadAngryTranslation(AngryLevelFolder);

        // End

        static string ResolveDirectory(params string[] candidates)
            => candidates.FirstOrDefault(Directory.Exists)
            ?? candidates.First(path => path != null);
    }

    private bool LoadFonts()
    {
        FontManager.TryLoadFontFromBundle(ConfigPaths.GetFontBundlePath(this.Name),
            out var fontConfig,
            out var fontBundle
        );

        if (fontBundle == null || fontConfig == null)
        {
            Logging.Warn($"Failed to load language font bundle with languageId: {this.Name}");
            return false;
        }

        this.FontBundle = fontBundle;
        this.UseFontFallback = fontConfig.UseFallback;
        this.MainFontAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontConfig.MainFont);
        this.TerminalAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontConfig.TerminalFont);
        this.MuseumAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontConfig.MuseumFont);
        this.SecretTerminalAsset = fontBundle.LoadAsset<TMP_FontAsset>(fontConfig.SecretFont);

        return true;

    }

    private void LoadAngryTranslation(string folder)
    {
        string path = Path.Combine(folder, "angry.json");
        if (File.Exists(path))
        {
            try
            {
                JsonConvert.PopulateObject(File.ReadAllText(path), angry);
                IsAngryTranslationLoaded = true;
                return;
            }
            catch (Exception e)
            {
                Logging.Error($"Failed to load angry ui '{path}': {e}");
            }
        }
        else
        {
            Logging.Info($"Angry translation not found of lang {this.Name}");
        }

    }
}
