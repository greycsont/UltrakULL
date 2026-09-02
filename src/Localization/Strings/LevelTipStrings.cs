using System;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

/// <summary>
/// Tip of the day
/// Used in each level's shop in first room
/// </summary>
public static class LevelTipStrings
{
    private static JsonFormat T => LanguageManager.CurrentLanguage;

    private static readonly (string prefix, Func<string, string> build)[] LevelTips =
    {
        ("0-2", tip => StringHelper.Get(T.levelTips.leveltips_preludeSecond1, T.levelTips.leveltips_preludeSecond2, "\n\n", tip)),
        ("0-3", tip => StringHelper.Get(T.levelTips.leveltips_preludeThird1, T.levelTips.leveltips_preludeThird2, T.levelTips.leveltips_preludeThird3, "\n\n", "\n\n", tip)),
        ("0-4", tip => StringHelper.Get(T.levelTips.leveltips_preludeFourth1, T.levelTips.leveltips_preludeFourth2, "\n\n", tip)),
        ("0-5", tip => StringHelper.Get(T.levelTips.leveltips_preludeFifth, tip)),
        ("1-1", tip => StringHelper.Get(T.levelTips.leveltips_limboFirst, tip)),
        ("1-2", tip => StringHelper.Get(T.levelTips.leveltips_limboSecond, tip)),
        ("1-3", tip => StringHelper.Get(T.levelTips.leveltips_limboThird1, T.levelTips.leveltips_limboThird2, "\n\n", tip)),
        ("1-4", tip => StringHelper.Get(T.levelTips.leveltips_limboFourth, tip)),
        ("2-1", tip => StringHelper.Get(T.levelTips.leveltips_lustFirst, tip)),
        ("2-2", tip => StringHelper.Get(T.levelTips.leveltips_lustSecond1, T.levelTips.leveltips_lustSecond2, T.levelTips.leveltips_lustSecond3, " ", "\n\n", tip)),
        ("2-3", tip => StringHelper.Get(T.levelTips.leveltips_lustThird, tip)),
        ("2-4", tip => StringHelper.Get(T.levelTips.leveltips_lustFourth1, T.levelTips.leveltips_lustFourth2, "\n\n", tip)),
        ("3-1", tip => StringHelper.Get(T.levelTips.leveltips_gluttonyFirst, tip)),
        ("3-2", tip => StringHelper.Get(T.levelTips.leveltips_gluttonySecond1, T.levelTips.leveltips_gluttonySecond2, "\n\n", tip)),
        ("4-1", tip => StringHelper.Get(T.levelTips.leveltips_greedFirst, tip)),
        ("4-2", tip => StringHelper.Get(T.levelTips.leveltips_greedSecond, tip)),
        ("4-3", tip => StringHelper.Get(T.levelTips.leveltips_greedThird, tip)),
        ("4-4", tip => StringHelper.Get(T.levelTips.leveltips_greedFourth, tip)),
        ("5-1", tip => StringHelper.Get(T.levelTips.leveltips_wrathFirst, tip)),
        ("5-2", tip => StringHelper.Get(T.levelTips.leveltips_wrathSecond, tip)),
        ("5-3", tip =>
        {
            string trimmedTip = tip.Trim();
            string brokenTip = T.levelTips.leveltips_wrathThirdBroken;

            if (trimmedTip == "Ow." || trimmedTip == brokenTip)
                return StringHelper.Get(brokenTip, tip);

            return StringHelper.Get(T.levelTips.leveltips_wrathThird, tip);
        }),
        ("5-4", tip => StringHelper.Get(T.levelTips.leveltips_wrathFourth1, T.levelTips.leveltips_wrathFourth2, "\n", tip)),
        ("6-1", tip => StringHelper.Get(T.levelTips.leveltips_heresyFirst1, T.levelTips.leveltips_heresyFirst2, "\n", tip)),
        ("6-2", tip => StringHelper.Get(T.levelTips.leveltips_heresySecond1, T.levelTips.leveltips_heresySecond2, "\n", tip)),
        ("7-1", tip => StringHelper.Get(T.levelTips.leveltips_violenceFirst, tip)),
        ("7-2", tip => StringHelper.Get(T.levelTips.leveltips_violenceSecond, tip)),
        ("7-3", tip => StringHelper.Get(T.levelTips.leveltips_violenceThird, tip)),
        ("7-4", tip => StringHelper.Get(T.levelTips.leveltips_violenceFourth, tip)),
        ("7-S", tip => StringHelper.Get(T.levelTips.leveltips_violenceSecret, tip)),
        ("8-1", tip => StringHelper.Get(T.levelTips.leveltips_fraudFirst, tip)),
        ("8-2", tip => StringHelper.Get(T.levelTips.leveltips_fraudSecond, tip)),
        ("8-3", tip => StringHelper.Get(T.levelTips.leveltips_fraudThird, tip)),
        ("8-4", tip => StringHelper.Get(T.levelTips.leveltips_fraudFourth, tip)),
        ("9-1", tip => StringHelper.Get(T.levelTips.leveltips_treacheryFirst, tip)),
        ("9-2", tip => StringHelper.Get(T.levelTips.leveltips_treacherySecond, tip)),
        ("uk_construct", tip =>
        {
            string part1 = T.levelTips.leveltips_sandbox1;
            string part2 = T.levelTips.leveltips_sandbox2;
            if (StringHelper.IsEmpty(part1) || StringHelper.IsEmpty(part2))
            {
                Logging.Warn($"[LevelTipStrings] Translation missing or empty for uk_construct, falling back to original: '{tip}'");
                return tip;
            }
            return part1 + $"\n\n<color=#FF4343>{T.levelTips.levelTips_sandboxCheatCode.Or("↑ ↑ ↓ ↓ ← → ← → B A")}</color>\n\n" + part2;
        }),
        ("0-E", tip => StringHelper.Get(T.levelTips.leveltips_encorePrelude1, T.levelTips.leveltips_encorePrelude2, "\n\n", tip)),
        ("1-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreLimbo, tip)),
        ("2-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreLust, tip)),
        ("3-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreGluttony, tip)),
        ("4-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreGreed, tip)),
        ("5-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreWrath, tip)),
        ("6-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreHeresy, tip)),
        ("7-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreViolence, tip)),
        ("8-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreFraud, tip)),
        ("9-E", tip => StringHelper.Get(T.levelTips.leveltips_encoreTreachery, tip)),
        ("P-1", tip => StringHelper.Get(T.levelTips.leveltips_primeFirst1, T.levelTips.leveltips_primeFirst2, "\n\n", tip)),
        ("P-2", tip => StringHelper.Get(T.levelTips.leveltips_primeSecond, tip)),
        ("P-3", tip => StringHelper.Get(T.levelTips.leveltips_primeThird, tip)),
        ("Endless", tip => StringHelper.Get(T.levelTips.leveltips_cybergrind, tip)),
        ("CreditsMuseum2", tip => StringHelper.Get(T.levelTips.leveltips_devMuseum, tip)),
    };

    public static string GetLevelTip(string tipDescriptionText)
    {
        string currentSceneName = GetCurrentSceneName();

        foreach (var (prefix, build) in LevelTips)
            if (currentSceneName.Contains(prefix))
                return build(tipDescriptionText);

        Logging.Warn("The source of the Level tip is not specified in the mod. We returned the value as it was. Level name: " + currentSceneName + ". tipDescriptionText= \"" + tipDescriptionText + "\"");
        return tipDescriptionText;
    }
}
