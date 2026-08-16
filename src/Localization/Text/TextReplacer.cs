using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

[NeedDebugMode]
public static class TextReplacer
{
    public static bool DebugMode = false;

    public static T TryReplaceText<T>(T target, string translation)
    {
        if ((target is null || string.IsNullOrEmpty(translation)) && !DebugMode) return target;

        switch (target)
        {
            case TMP_Text text:
                text.text = Penis(text.text, translation);
                break;
            case Text text:
                text.text = Penis(text.text, translation);
                break;
            case TMP_Dropdown.OptionData option:
                option.text = Penis(option.text, translation);
                break;
        }

        return target;
    }

    public static T TryReplaceText<T>(
        string translation,
        GameObject parent,
        params string[] path) where T : Component
    {
        return TryReplaceText(SceneObjects.FindComponent<T>(parent, path), translation);
    }

    // fuck you rich text
    public static string ReplaceOrKeep(string original, string replacement)
    {
        return StringHelper.IsEmpty(replacement) ? original : Penis(original, replacement);
    }

    /// <summary>
    /// I need a better name for that
    /// </summary>
    /// <param name="original"></param>
    /// <param name="replacement"></param>
    /// <returns></returns>
    private static string Penis(string original, string replacement)
    {
        if (DebugMode)
        {
            original += "/" + replacement;
        }
        else
        {
            original = replacement;
        }

        return original;
    }
}
