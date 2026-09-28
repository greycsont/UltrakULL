using System.Collections.Generic;
using UltrakULL.json;

namespace UltrakULL;

public static class AngryLevelText
{
    public static string BundleGuid { get; private set; }
    public static string BundleAuthor { get; private set; }
    public static string BundleName { get; private set; }
    public static string LevelId { get; private set; }
    public static string LevelName { get; private set; }

    public static void SetCurrent(string bundleGuid, string bundleAuthor, string bundleName, string levelId, string levelName)
    {
        BundleGuid = bundleGuid;
        BundleAuthor = bundleAuthor;
        BundleName = bundleName;
        LevelId = levelId;
        LevelName = levelName;
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

    /// <summary>
    /// The hudmessage on that level
    /// </summary>
    public static List<Match> HudMessages() => Current()?.hudMessages ?? new List<Match>();

    /// <summary>
    /// The translated books of current custom level
    /// </summary>
    public static List<Match> Books() => Current()?.books ?? new List<Match>();

    public static AngryLevel Current()
    {
        if (string.IsNullOrEmpty(BundleGuid) || string.IsNullOrEmpty(LevelId))
            return null;

        var bundles = LanguageManager.Current?.angry?.angryBundles?.bundles;
        if (bundles == null)
            return null;

        if (!bundles.TryGetValue(BundleGuid, out AngryBundle bundle) || bundle?.levels == null)
            return null;

        if (!bundle.levels.TryGetValue(LevelId, out AngryLevel level))
            return null;

        return string.IsNullOrEmpty(level.translator) ? null : level;
    }
}
