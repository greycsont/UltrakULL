using UltrakULL.json;

namespace UltrakULL;

public static class LevelNames
{
    public static string GetDiscordLevelName(string missionName)
    {
        var names = LanguageManager.CurrentLanguage.levelNames;

        if (missionName.Contains("Main Menu")) return names.levelName_mainMenu;
        if (missionName.Contains("Endless")) return names.levelName_cybergrind;
        if (missionName.Contains("uk_construct")) return names.levelName_sandbox;
        if (missionName.Contains("Tutorial")) return names.levelName_tutorial;
        if (missionName.Contains("CreditsMuseum2")) return names.levelName_devMuseum;
        if (missionName.Contains("Intermission") || missionName.Contains("EarlyAccessEnd")) return "???";

        string levelName = missionName switch
        {
            var value when value.Contains("0-1") => Format("0-1", names.levelName_preludeFirst),
            var value when value.Contains("0-2") => Format("0-2", names.levelName_preludeSecond),
            var value when value.Contains("0-3") => Format("0-3", names.levelName_preludeThird),
            var value when value.Contains("0-4") => Format("0-4", names.levelName_preludeFourth),
            var value when value.Contains("0-5") => Format("0-5", names.levelName_preludeFifth),
            var value when value.Contains("0-S") => Format("0-S", names.levelName_preludeSecret),
            var value when value.Contains("1-1") => Format("1-1", names.levelName_limboFirst),
            var value when value.Contains("1-2") => Format("1-2", names.levelName_limboSecond),
            var value when value.Contains("1-3") => Format("1-3", names.levelName_limboThird),
            var value when value.Contains("1-4") => Format("1-4", names.levelName_limboFourth),
            var value when value.Contains("1-S") => Format("1-S", names.levelName_limboSecret),
            var value when value.Contains("2-1") => Format("2-1", names.levelName_lustFirst),
            var value when value.Contains("2-2") => Format("2-2", names.levelName_lustSecond),
            var value when value.Contains("2-3") => Format("2-3", names.levelName_lustThird),
            var value when value.Contains("2-4") => Format("2-4", names.levelName_lustFourth),
            var value when value.Contains("2-S") => Format("2-S", names.levelName_lustSecret),
            var value when value.Contains("3-1") => Format("3-1", names.levelName_gluttonyFirst),
            var value when value.Contains("3-2") => Format("3-2", names.levelName_gluttonySecond),
            var value when value.Contains("4-1") => Format("4-1", names.levelName_greedFirst),
            var value when value.Contains("4-2") => Format("4-2", names.levelName_greedSecond),
            var value when value.Contains("4-3") => Format("4-3", names.levelName_greedThird),
            var value when value.Contains("4-4") => Format("4-4", names.levelName_greedFourth),
            var value when value.Contains("4-S") => Format("4-S", names.levelName_greedSecret),
            var value when value.Contains("5-1") => Format("5-1", names.levelName_wrathFirst),
            var value when value.Contains("5-2") => Format("5-2", names.levelName_wrathSecond),
            var value when value.Contains("5-3") => Format("5-3", names.levelName_wrathThird),
            var value when value.Contains("5-4") => Format("5-4", names.levelName_wrathFourth),
            var value when value.Contains("5-S") => Format("5-S", names.levelName_wrathSecret),
            var value when value.Contains("6-1") => Format("6-1", names.levelName_heresyFirst),
            var value when value.Contains("6-2") => Format("6-2", names.levelName_heresySecond),
            var value when value.Contains("7-1") => Format("7-1", names.levelName_violenceFirst),
            var value when value.Contains("7-2") => Format("7-2", names.levelName_violenceSecond),
            var value when value.Contains("7-3") => Format("7-3", names.levelName_violenceThird),
            var value when value.Contains("7-4") => Format("7-4", names.levelName_violenceFourth),
            var value when value.Contains("7-S") => Format("7-S", names.levelName_violenceSecret),
            var value when value.Contains("8-1") => Format("8-1", names.levelName_fraudFirst),
            var value when value.Contains("8-2") => Format("8-2", names.levelName_fraudSecond),
            var value when value.Contains("8-3") => Format("8-3", names.levelName_fraudThird),
            var value when value.Contains("8-4") => Format("8-4", names.levelName_fraudFourth),
            var value when value.Contains("8-S") => Format("8-S", names.levelName_fraudSecret),
            var value when value.Contains("9-1") => Format("9-1", names.levelName_treacheryFirst),
            var value when value.Contains("9-2") => Format("9-2", names.levelName_treacherySecond),
            var value when value.Contains("0-E") => Format("0-E", names.levelName_encorePrelude),
            var value when value.Contains("1-E") => Format("1-E", names.levelName_encoreLimbo),
            var value when value.Contains("P-1") => Format("P-1", names.levelName_primeFirst),
            var value when value.Contains("P-2") => Format("P-2", names.levelName_primeSecond),
            var value when value.Contains("P-3") => Format("P-3", names.levelName_primeThird),
            _ => null
        };

        if (levelName != null) return levelName;

        Logging.Warn("Unknown level name: " + missionName);
        return missionName;
    }

    public static string GetLevelName(int missionNum, string levelname = "None")
    {
        if (missionNum == 0)
            return LanguageManager.CurrentLanguage.levelNames.levelName_mainMenu;

        string missionNumber = GetMissionName.GetMissionNumberOnly(missionNum);
        if (string.IsNullOrEmpty(missionNumber))
            return levelname;

        string originalName = GetMissionName.GetMissionNameOnly(missionNum);
        return Format(missionNumber, GetMissionNameOnly(missionNum, originalName));
    }

    public static string GetMissionNameOnly(int missionNum, string fallback)
    {
        var names = LanguageManager.CurrentLanguage.levelNames;

        return missionNum switch
        {
            0 => names.levelName_mainMenu,
            1 => names.levelName_preludeFirst,
            2 => names.levelName_preludeSecond,
            3 => names.levelName_preludeThird,
            4 => names.levelName_preludeFourth,
            5 => names.levelName_preludeFifth,
            6 => names.levelName_limboFirst,
            7 => names.levelName_limboSecond,
            8 => names.levelName_limboThird,
            9 => names.levelName_limboFourth,
            10 => names.levelName_lustFirst,
            11 => names.levelName_lustSecond,
            12 => names.levelName_lustThird,
            13 => names.levelName_lustFourth,
            14 => names.levelName_gluttonyFirst,
            15 => names.levelName_gluttonySecond,
            16 => names.levelName_greedFirst,
            17 => names.levelName_greedSecond,
            18 => names.levelName_greedThird,
            19 => names.levelName_greedFourth,
            20 => names.levelName_wrathFirst,
            21 => names.levelName_wrathSecond,
            22 => names.levelName_wrathThird,
            23 => names.levelName_wrathFourth,
            24 => names.levelName_heresyFirst,
            25 => names.levelName_heresySecond,
            26 => names.levelName_violenceFirst,
            27 => names.levelName_violenceSecond,
            28 => names.levelName_violenceThird,
            29 => names.levelName_violenceFourth,
            30 => names.levelName_fraudFirst,
            31 => names.levelName_fraudSecond,
            32 => names.levelName_fraudThird,
            33 => names.levelName_fraudFourth,
            34 => names.levelName_treacheryFirst,
            35 => names.levelName_treacherySecond,
            100 => names.levelName_encorePrelude,
            101 => names.levelName_encoreLimbo,
            102 => names.levelName_encoreLust,
            103 => names.levelName_encoreGluttony,
            104 => names.levelName_encoreGreed,
            105 => names.levelName_encoreWrath,
            106 => names.levelName_encoreHeresy,
            107 => names.levelName_encoreViolence,
            108 => names.levelName_encoreFraud,
            109 => names.levelName_encoreTreachery,
            666 => names.levelName_primeFirst,
            667 => names.levelName_primeSecond,
            668 => names.levelName_primeThird,
            _ => fallback
        };
    }

    private static string Format(string missionNumber, string missionName) =>
        $"{missionNumber}: {missionName}";
}
