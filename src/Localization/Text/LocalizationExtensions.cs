using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

public static class LocalizationExtensions
{
    internal static bool DebugMode;

    // Localizes a TMP_Text / Text / OptionData target
    //   or returns it untouched when it (or the translation) is null/empty.
    public static T Localize<T>(this T target, string translation) where T : Component
    {
        if (target == null || StringHelper.IsEmpty(translation))
            return target;

        switch (target)
        {
            case TMP_Text tmp:
                tmp.text = Penis(tmp.text, translation);
                break;
            case Text text:
                text.text = Penis(text.text, translation);
                break;
        }

        return target;
    }

    public static TMP_Dropdown.OptionData Localize(this TMP_Dropdown.OptionData option, string translation)
    {
        if (option == null || StringHelper.IsEmpty(translation))
            return option;

        option.text = Penis(option.text, translation);
        return option;
    }

    // Finds a T component below parent by path, then localizes it.
    public static T Localize<T>(this GameObject parent, string translation, params string[] path) where T : Component
        => SceneObjects.FindComponent<T>(parent, path).Localize(translation);

    // I have no idea how to name it
    private static string Penis(string original, string replacement)
    {
        if (DebugMode)
            original += "/" + replacement;
        else
            original = replacement;
        return original;
    }
}
