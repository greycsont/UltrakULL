using TMPro;

namespace UltrakULL;

[NeedDebugMode]
public static class TextReplacer
{
    public static void TryToReplaceText(TMP_Text text, string translation)
    {
        if (text == null || string.IsNullOrEmpty(translation)) return;
        text.text = translation;
    }

    public static void TryToReplaceText(TMP_Text text, string[] parts, string replacement)
    {
        if (text == null) return;

        foreach (string part in parts)
            if (string.IsNullOrEmpty(part)) return;

        text.text = replacement;
    }

    public static void TryToReplaceText(TMP_Dropdown.OptionData option, string translation)
    {
        if (option == null || string.IsNullOrEmpty(translation)) return;
        option.text = translation;
    }
}
