using UltrakULL.json;
using TMPro;
using UnityEngine;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{
    private static void PatchNavigation(GameObject optionsMenu)
    {
        optionsMenu.Localize<TextMeshProUGUI>("--{0}--".FormatWith(LanguageManager.CurrentLanguage.options.options_title), path: ["Text"]);

        GameObject navigationRail = FindDescendant(optionsMenu, "Navigation Rail");

        navigationRail.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.category_general), path: ["Text (7)"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_general, path: ["General", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_controls, path: ["Controls", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_graphics, path: ["Video", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_audio, path: ["Audio", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_assists, path: ["Assist", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_saves, path: ["Saves", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.category_customization), path: ["Text (8)"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_hud, path: ["HUD", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_colors, path: ["Colors", "Text"]);

        navigationRail.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.options_back, path: ["Back", "Text"]);

        optionsMenu.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, path: ["Palette Selector", "Close", "Text"]);
    }
}
