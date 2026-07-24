namespace UltrakULL;

/// <summary>
/// What if hakita add more text formatting stuff in the future?
/// </summary>
public static class TextFormatter
{
    public static string MakeVertical(string input)
    {
        return string.IsNullOrEmpty(input) ? input : string.Join("\n", input);
    }
}
