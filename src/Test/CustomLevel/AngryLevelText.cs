using System.Collections.Generic;
using UltrakULL.json;

namespace UltrakULL;

public static class AngryLevelText
{
    public static string BundleGuid { get; private set; }
    public static string LevelId { get; private set; }

    public static void SetCurrent(string bundleGuid, string levelId)
    {
        BundleGuid = bundleGuid;
        LevelId = levelId;
    }

    public static string Name() => Current()?.levelName;

    /// <summary>
    /// Title line of the title drop
    /// </summary>
    public static string Title() => Current()?.levelTitle;

    /// <summary>
    /// Layer line of the title drop e.g. ("Layer /// Number").
    /// </summary>
    public static string Layer() => Current()?.levelLayer;

    /// <summary>
    /// Shop's tip of the day.
    /// </summary>
    public static string Tip() => Current()?.tipOfTheDay;

    /// <summary>
    /// Challenge text shown on the result screen
    /// </summary>
    public static string Challenge() => Current()?.challenge;

    public static AngryLevel Current()
    {
        if (string.IsNullOrEmpty(BundleGuid) || string.IsNullOrEmpty(LevelId))
            return null;

        var bundles = LanguageManager.Current?.angry?.angryBundles?.bundles;
        if (bundles == null)
            return null;

        if (!bundles.TryGetValue(BundleGuid, out AngryBundle bundle) || bundle?.levels == null)
            return null;

        return bundle.levels.TryGetValue(LevelId, out AngryLevel level) ? level : null;
    }
}
