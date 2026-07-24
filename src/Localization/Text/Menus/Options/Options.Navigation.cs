using UltrakULL.json;
using UnityEngine;
using static UltrakULL.TextReplacer;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{
    private static void PatchNavigation(GameObject optionsMenu)
    {
        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(optionsMenu, "Text")), 
            new[] { LanguageManager.CurrentLanguage.options.options_title }, 
            "--" + LanguageManager.CurrentLanguage.options.options_title + "--");

        GameObject navigationRail = FindDescendant(optionsMenu, "Navigation Rail");

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Text (7)")),
            new[] { LanguageManager.CurrentLanguage.options.category_general },
            "-- " + LanguageManager.CurrentLanguage.options.category_general + " --");

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "General", "Text")),
            LanguageManager.CurrentLanguage.options.category_general);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Controls", "Text")),
            LanguageManager.CurrentLanguage.options.category_controls);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Video", "Text")),
            LanguageManager.CurrentLanguage.options.category_graphics);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Audio", "Text")),
            LanguageManager.CurrentLanguage.options.category_audio);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Assist", "Text")),
            LanguageManager.CurrentLanguage.options.category_assists);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Saves", "Text")),
            LanguageManager.CurrentLanguage.options.category_saves);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Text (8)")),
            new[] { LanguageManager.CurrentLanguage.options.category_customization },
            "-- " + LanguageManager.CurrentLanguage.options.category_customization + " --");

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "HUD", "Text")),
            LanguageManager.CurrentLanguage.options.category_hud);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Colors", "Text")),
            LanguageManager.CurrentLanguage.options.category_colors);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(navigationRail, "Back", "Text")),
            LanguageManager.CurrentLanguage.options.options_back);

        TryToReplaceText(
            GetTextMeshProUGUI(FindDescendant(optionsMenu, "Palette Selector", "Close", "Text")), 
            LanguageManager.CurrentLanguage.options.save_close);
    }
}
