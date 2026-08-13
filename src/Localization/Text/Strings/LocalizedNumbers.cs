using UltrakULL.json;

namespace UltrakULL;

public static class LocalizedNumbers
{
    private const string WesternDigits = "0123456789";
    private const string HinduDigits = "٠١٢٣٤٥٦٧٨٩";

    public static string Format(string value)
    {
        if (!LanguageManager.UsingHinduNumbers || string.IsNullOrEmpty(value))
            return value;

        char[] characters = value.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            int digit = WesternDigits.IndexOf(characters[i]);
            if (digit >= 0)
                characters[i] = HinduDigits[digit];
        }

        return new string(characters);
    }
}
