using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.UI;

namespace UltrakULL;

[NeedDebugMode]
public static class TextReplacer
{
    public static bool DebugMode = false;
    public static void TryToReplaceText(TMP_Text text, string translation)
    {
        if ((text == null || string.IsNullOrEmpty(translation)) && !DebugMode) return;
        text.text = Penis(text.text, translation);
    }

    public static void TryToReplaceText(TMP_Text text, string[] parts, string replacement)
    {
        if ((text == null || parts.Any(x => string.IsNullOrEmpty(x))) && !DebugMode) return;

        text.text = Penis(text.text, replacement);
    }

    public static void TryToReplaceText(TMP_Dropdown.OptionData option, string translation)
    {
        if ((option == null || string.IsNullOrEmpty(translation)) && !DebugMode) return;
        option.text = Penis(option.text, translation);
    }

    public static void TryToReplaceText(Text text, string translation)
    {
        if ((text == null || string.IsNullOrEmpty(translation)) && !DebugMode) return;
        text.text = Penis(text.text, translation);
    }

    public static void TryToReplaceText(Text text, string[] parts, string replacement)
    {
        if ((text == null || parts.Any(x => string.IsNullOrEmpty(x))) && !DebugMode) return;

        text.text = Penis(text.text, replacement);
    }

    // fuck you rich text
    public static string ReplaceOrKeep(string original, string replacement)
    {
        string stripped = Regex.Replace(replacement, "<.*?>", "").Trim();
        return string.IsNullOrEmpty(stripped) ? original : Penis(original, replacement);
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
