using System.Text.RegularExpressions;

namespace UltrakULL;

/// <summary>
/// Safe translation lookup: empty/tag-only translations fall back to the
/// original. "No match" is null, never a sentinel string.
/// </summary>
public static class StringHelper
{
    /// <summary>
    /// True when text is null, whitespace, or only rich-text tags.
    /// </summary>
    public static bool IsEmpty(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return true;

        return string.IsNullOrWhiteSpace(Regex.Replace(text, "<.*?>", ""));
    }

    /// <summary>
    /// Makes Line Vertical: "abc" -> "a\nb\nc". Returns null/empty as-is.
    /// </summary>
    public static string MakeVertical(string input)
    {
        return string.IsNullOrEmpty(input) ? input : string.Join("\n", input.ToCharArray());
    }
}
