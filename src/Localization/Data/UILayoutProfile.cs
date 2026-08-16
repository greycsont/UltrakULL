using System.Collections.Generic;

namespace UltrakULL.json;

/// <summary>
/// Example layout.json:
///
///     {
///         "adjustments": [
///             {
///                 "path": "Player/Main Camera/HUD Camera/HUD/FinishCanvas/Panel/Title/Text",
///                 "include": ["Level 2-3"],
///                 "wordWrapping": false,
///                 "overflow": "Overflow"
///             }
///         ]
///     }
///
/// A missing layout.json (or missing adjustments) means no tweaks are applied.
/// </summary>
public sealed class UILayoutProfile
{
    public List<UILayoutAdjustment> adjustments = new();
}

public sealed class UILayoutAdjustment
{
    public string path;
    public string[] include;
    public string[] exclude;
    public bool? wordWrapping;
    public string overflow;
}
