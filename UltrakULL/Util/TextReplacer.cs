using TMPro;

namespace UltrakULL;

public static class TextReplacer
{
    public static void TryToReplaceText(TMP_Text text, string[] translatedArgs, string replacement)
    {
        if (text == null) return;
        if (text.text == null) return;

        var shouldReplace = true;

        foreach (string arg in translatedArgs)
            if (arg == null) shouldReplace = false;
        
        if (!shouldReplace) return;
        
        text.text = replacement;
    }
}