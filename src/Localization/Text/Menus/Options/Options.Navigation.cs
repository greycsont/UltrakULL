using UltrakULL.json;
using TMPro;
using UnityEngine;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{
    private static void PatchNavigation(GameObject optionsMenu)
    {
        optionsMenu.Localize<TextMeshProUGUI>("--{0}--".FormatWith(LanguageManager.CurrentLanguage.options.options_title), "Text");

        GameObject navigationRail = FindDescendant(optionsMenu, "Navigation Rail");

        navigationRail.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.category_general), "Text (7)");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_general, "General", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_controls, "Controls", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_graphics, "Video", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_audio, "Audio", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_assists, "Assist", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_saves, "Saves", "Text");

        navigationRail.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.category_customization), "Text (8)");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_hud, "HUD", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_colors, "Colors", "Text");

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.options_back, "Back", "Text");

        optionsMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, "Palette Selector", "Close", "Text");
    }
}
