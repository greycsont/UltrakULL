using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UltrakULL.json;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

/// <summary>
/// Loads key -> value from layout.json; patches read the value they want via Get().
/// </summary>
public static class UILayoutOverride
{
    private static readonly Dictionary<string, UILayoutValue> values = new();

    public static void Initialize()
    {
        LanguageManager.OnLanguageChanged += _ => Load(LanguageManager.Current?.Layout);
    }

    // Called once per scene load to re-populate the table from the active language's layout.json.
    public static void Load(UILayoutProfile profile)
    {
        values.Clear();
        if (profile?.values == null)
            return;

        foreach (var (key, value) in profile.values)
            values[key] = value;
    }

    // Returns the value for key, or null when the language pack didn't define one.
    public static UILayoutValue Get(string key)
        => values.TryGetValue(key, out UILayoutValue value) ? value : null;

    // Applies the layout override for key to a TMP text. fontSize is set (not added);
    // localPosition is added (delta). No-op when the key/value isn't defined.
    public static TMP_Text ApplyLayout(this TMP_Text text, string key)
    {
        var v = Get(key);
        if (v == null)
            return text;

        if (v.fontSize.HasValue)
            text.fontSize = v.fontSize.Value;

        if (v.localPosition.HasValue)
            text.rectTransform.localPosition += v.localPosition.Value;

        return text;
    }

    public static void AdjustOptionTextPosition()
    {
        var canvas = GetInactiveRootObject("Canvas");
        var optionsMenu = FindDescendant(canvas, "OptionsMenu");
        var optionTitle = FindDescendant(optionsMenu, "Text")?.GetComponent<RectTransform>();

        if (!optionTitle)
            return;

        optionTitle.localPosition = new Vector3(optionTitle.localPosition.x, 360f, optionTitle.localPosition.z);
    }

    public static void RemoveWordWrap(this TMP_Text text)
    {
        text.overflowMode = TextOverflowModes.Overflow;
        text.enableWordWrapping = false;
    }

    public static void AddUpperCase(this TMP_Text text)
    {
        // bitwise OR
        text.fontStyle |= FontStyles.UpperCase;
    }
}
