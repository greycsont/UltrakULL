using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UltrakULL.json;

/// <summary>
/// In the LanguageManager.cs
/// The json should be the only one in the lang
/// For the FontAsset, when switching the currentlanguage to it's own
/// load the FontAsset
/// </summary>
public sealed class Lang
{
    public JsonFormat Json { get;}
    public string Name => Json.metadata.langName;
    public string DisplayName => Json.metadata.langDisplayName;
    public bool IsEnglish => Json.metadata.langDisplayName == "English";
    public bool IsRightToLeft => Json.metadata.langRTL;
    public bool UseFontFallback => Json.metadata.fonts?.UseFallback ?? false;

    public string SpeechFolder { get; }
    public string TextureFolder { get; }
    public UILayoutProfile Layout { get; }

    internal AssetBundle FontBundle { get; set; }
    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }

    // Which fallbacks FontManager pushed into which game fonts while this language was active,
    // so switching away can undo exactly what this language added.
    internal readonly List<(TMP_FontAsset font, TMP_FontAsset fallback)> AppliedFallbacks = new();

    public Lang(JsonFormat json, string packageFolder = null, UILayoutProfile layout = null)
    {
        Json = json;
        Layout = layout;
        SpeechFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "audio"),
            ConfigPaths.GetLegacyAudioDirectory(Name));
        TextureFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "textures"),
            ConfigPaths.GetLegacyTextureDirectory(Name));
    }

    private static string ResolveDirectory(params string[] candidates)
        => candidates.FirstOrDefault(Directory.Exists)
        ?? candidates.First(path => path != null);

}
