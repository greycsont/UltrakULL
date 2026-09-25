using System.Collections.Generic;
using UnityEngine;

namespace UltrakULL.json;

/// <summary>
/// Example layout.json:
///
///     {
///         "values": {
///             "rumble.reset":   { "fontSize": 9 },
///             "levelName.title":  { "localPosition": { "x": 0, "y": 1, "z": 0 } }
///         }
///     }
///
/// A missing layout.json (or missing key) means no override for that entry
/// </summary>
public sealed class UILayoutProfile
{
    public Dictionary<string, UILayoutValue> values = new();
}

public sealed class UILayoutValue
{
    public float? fontSize;
    public Vector3? localPosition;
}
