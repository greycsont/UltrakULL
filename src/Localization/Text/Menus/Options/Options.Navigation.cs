using UltrakULL.json;
using TMPro;
using UnityEngine;
using static UltrakULL.TextReplacer;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{
    private static void PatchNavigation(GameObject optionsMenu)
    {
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("--{0}--", LanguageManager.CurrentLanguage.options.options_title), optionsMenu, "Text");

        GameObject navigationRail = FindDescendant(optionsMenu, "Navigation Rail");

        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.category_general), navigationRail, "Text (7)");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_general, navigationRail, "General", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_controls, navigationRail, "Controls", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_graphics, navigationRail, "Video", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_audio, navigationRail, "Audio", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_assists, navigationRail, "Assist", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_saves, navigationRail, "Saves", "Text");

        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.category_customization), navigationRail, "Text (8)");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_hud, navigationRail, "HUD", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.category_colors, navigationRail, "Colors", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.options_back, navigationRail, "Back", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.save_close, optionsMenu, "Palette Selector", "Close", "Text");
    }
}
