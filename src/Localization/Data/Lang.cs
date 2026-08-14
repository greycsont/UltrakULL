using System.Collections.Generic;
using System.IO;
using BepInEx;
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
    public string FontBundlePath { get; }
    public string TextureFolder { get; }

    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }
    internal AssetBundle FontBundle { get; set; }

    // Which fallbacks FontManager pushed into which game fonts while this language was active,
    // so switching away can undo exactly what this language added.
    internal readonly List<(TMP_FontAsset font, TMP_FontAsset fallback)> AppliedFallbacks = new();

    public Lang(JsonFormat json)
    {
        Json = json;
        SpeechFolder = Path.Combine(Paths.ConfigPath, "ultrakull", "audio", json.metadata.langName)
                       + Path.DirectorySeparatorChar;
        FontBundlePath = Path.Combine(MainPatch.ModFolder, "fonts", json.metadata.langName + ".bundle");
        TextureFolder = Path.Combine(Paths.ConfigPath, "ultrakull", "textures", json.metadata.langName);
    }

}
