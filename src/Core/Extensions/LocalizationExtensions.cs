using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UltrakULL;

public static class LocalizationExtensions
{
    internal static bool DebugMode;

    // Localizes a TMP_Text / Text / OptionData target
    //   or returns it untouched when it (or the translation) is null/empty.
    public static T Localize<T>(this T target, string translation, bool uppercase = false) where T : Component
    {
        if (target == null)
            return target;

        switch (target)
        {
            case TMP_Text tmp:
                tmp.text = translation.Or(tmp.text).ToUpperIf(uppercase);
                break;
            case Text text:
                text.text = translation.Or(text.text).ToUpperIf(uppercase);
                break;
        }

        return target;
    }

    public static TMP_Dropdown.OptionData Localize(this TMP_Dropdown.OptionData option, string translation, bool uppercase = false)
    {
        if (option == null)
            return option;

        option.text = translation.Or(option.text).ToUpperIf(uppercase);
        return option;
    }

    // Finds a T component below parent by path, then localizes it.
    public static T Localize<T>(this GameObject parent, string translation, string[] path, bool uppercase = false) where T : Component
        => SceneObjects.FindComponent<T>(parent, path).Localize(translation, uppercase);

    public static string Or(this string translation, string original)
        => StringHelper.IsEmpty(translation) ? original : Penis(original, translation);

    public static string ToUpperIf(this string text, bool uppercase)
        => uppercase ? text.ToUpper() : text;

    // I have no idea how to name it
    private static string Penis(string original, string replacement)
    {
        if (DebugMode)
            original += "/" + replacement;
        else
            original = replacement;
        return original;
    }

    /// <summary>
    /// Formats a template; empty/tag-only template or parts return null, FormatException is swallowed.
    /// </summary>
    public static string Format(string format, params object[] parts)
    {
        if (string.IsNullOrEmpty(format) || parts == null || parts.Length == 0)
            return null;

        foreach (object part in parts)
            if (part is null || part is string text && StringHelper.IsEmpty(text))
                return null;

        try
        {
            return string.Format(format, parts);
        }
        catch (FormatException)
        {
            Logging.Warn("Format failed for template: '" + format + "'", true);
            return null;
        }
    }

    // Syntactic sugar over Format: string.FormatWith(args)
    public static string FormatWith(this string format, params object[] parts)
        => Format(format, parts);

}
