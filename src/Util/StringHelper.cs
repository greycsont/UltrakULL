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
    /// Returns translated, or original when the translation is empty/tag-only.
    /// </summary>
    public static string Get(string translated, string original)
    {
        return IsEmpty(translated) ? original : translated;
    }

    /// <summary>
    /// Joins two parts; falls back to original if any is empty/tag-only.
    /// </summary>
    public static string Get(string part1, string part2, string separator, string original)
    {
        if (IsEmpty(part1) || IsEmpty(part2))
            return original;

        return part1 + separator + part2;
    }

    /// <summary>
    /// Joins three parts; falls back to original if any is empty/tag-only.
    /// </summary>
    public static string Get(
        string part1, string part2, string part3,
        string separator1, string separator2, string original)
    {
        if (IsEmpty(part1) || IsEmpty(part2) || IsEmpty(part3))
            return original;

        return part1 + separator1 + part2 + separator2 + part3;
    }

    /// <summary>
    /// Makes Line Vertical: "abc" -> "a\nb\nc". Returns null/empty as-is.
    /// </summary>
    public static string MakeVertical(string input)
    {
        return string.IsNullOrEmpty(input) ? input : string.Join("\n", input.ToCharArray());
    }
}
