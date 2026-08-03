using System.Linq;
using System.Text.RegularExpressions;

namespace UltrakULL;

/// <summary>
/// What if hakita add more text formatting stuff in the future?
/// </summary>
public static class TextFormatter
{
    public static string Format(string format, params string[] parts)
    {
        if (string.IsNullOrEmpty(format) || parts.Any(IsEmpty))
            return null;

        return string.Format(format, parts);
    }

    private static bool IsEmpty(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return true;

        return string.IsNullOrWhiteSpace(Regex.Replace(text, "<.*?>", ""));
    }

    public static string MakeVertical(string input)
    {
        return string.IsNullOrEmpty(input) ? input : string.Join("\n", input);
    }
}
