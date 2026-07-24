using UltrakULL.json;

namespace UltrakULL;

public static class InputNames
{
    public static string Localize(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input.Length == 1 && char.IsLetter(input[0]))
            return input;

        string key = input.Replace(" ", "").ToLowerInvariant();
        var inputs = LanguageManager.CurrentLanguage.inputStrings;

        string localized = key switch
        {
            "space" => inputs.input_space,
            "enter" => inputs.input_enter,
            "tab" => inputs.input_tab,
            "escape" => inputs.input_esc,
            "leftshift" => inputs.input_leftShift,
            "rightshift" => inputs.input_rightShift,
            "leftcontrol" => inputs.input_leftControl,
            "leftctrl" => inputs.input_leftCtrl,
            "rightcontrol" => inputs.input_rightControl,
            "rightctrl" => inputs.input_rightCtrl,
            "leftalt" => inputs.input_leftAlt,
            "rightalt" => inputs.input_rightAlt,
            "leftmeta" => inputs.input_leftMeta,
            "rightmeta" => inputs.input_rightMeta,
            "leftbracket" => inputs.input_leftBracket,
            "rightbracket" => inputs.input_rightBracket,
            "lmb" => inputs.input_LMB,
            "rmb" => inputs.input_RMB,
            "mmb" => inputs.input_MMB,
            "uparrow" => inputs.input_arrowUp,
            "downarrow" => inputs.input_arrowDown,
            "leftarrow" => inputs.input_arrowLeft,
            "rightarrow" => inputs.input_arrowRight,
            "forward" => inputs.input_forward,
            "back" => inputs.input_back,
            "comma" => inputs.input_comma,
            "capslock" => inputs.input_capsLock,
            "slash" => inputs.input_slash,
            "backslash" => inputs.input_backslash,
            "backspace" => inputs.input_backspace,
            "equals" => inputs.input_equals,
            "minus" => inputs.input_minus,
            "numlock" => inputs.input_numLock,
            "delete" => inputs.input_delete,
            "period" => inputs.input_period,
            "semicolon" => inputs.input_semicolon,
            "quote" => inputs.input_quote,
            "insert" => inputs.input_insert,
            "pageup" => inputs.input_pageUp,
            "pagedown" => inputs.input_pageDown,
            "start" => inputs.input_start,
            "end" => inputs.input_end,
            "scrolllock" => inputs.input_scrollLock,
            "pause" => inputs.input_pause,
            "nobinding" => inputs.input_noBinding,
            "numpadperiod" => inputs.input_numpadPeriod,
            "numpaddivide" => inputs.input_numpadDivide,
            "numpadmultiply" => inputs.input_numpadMultiply,
            "numpadminus" => inputs.input_numpadMinus,
            "numpadenter" => inputs.input_numpadEnter,
            "numpadplus" => inputs.input_numpadPlus,
            _ when key.StartsWith("numpad") && !string.IsNullOrEmpty(inputs.input_numpad) =>
                inputs.input_numpad + key.Substring(6),
            _ => null,
        };

        return string.IsNullOrEmpty(localized) ? input : localized;
    }
}
