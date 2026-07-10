using TMPro;

namespace UltrakULL.json;

public sealed class Lang
{
    public JsonFormat Json { get; }
    public string Name => Json.metadata.langName;
    public bool IsEnglish => Json.metadata.langDisplayName == "English";

    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }
}