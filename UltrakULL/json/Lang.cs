using TMPro;

namespace UltrakULL.json;

public sealed class Lang
{
    public JsonFormat Json { get; set; }
    public string Name => Json.metadata.langName;
    public string DisplayName => Json.metadata.langDisplayName;
    public bool IsEnglish => Json.metadata.langDisplayName == "English";
    public bool IsRightToLeft => Json.metadata.langRTL;

    // Isn't this Hindi Number?
    public bool UsingHinduNumbers => Json.metadata.langHinduNumbers;

    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }
}