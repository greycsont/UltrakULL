using System;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

/// <summary>
/// HUD-message router
/// </summary>
public static class HudMessageStrings
{
    private static JsonFormat T => LanguageManager.CurrentLanguage;

    // Tutorial
    private static readonly (string keyword, Func<string, string, string, string> build)[] TutorialMessages =
    {
        ("PUNCH", (m, m2, input) => T.tutorial.tutorial_punch1 + "<color=orange>" + input + "</color>" + T.tutorial.tutorial_punch2),
        ("SLIDE", (m, m2, input) => T.tutorial.tutorial_slide1 + "<color=orange>" + input + "</color>" + T.tutorial.tutorial_slide2),
        ("DASH", (m, m2, input) => T.tutorial.tutorial_dash1 + "<color=#00DFFF>" + input + "</color>" + T.tutorial.tutorial_dash2 + "\n" + T.tutorial.tutorial_dash3),
        ("HEALTH", (m, m2, input) => T.tutorial.tutorial_health1 + "\n" + T.tutorial.tutorial_health2),
        ("JUMP", (m, m2, input) => T.tutorial.tutorial_walljump),
        ("SHOCKWAVE", (m, m2, input) => T.tutorial.tutorial_shockwave1 + "<color=orange>" + input + "</color>" + T.tutorial.tutorial_shockwave2 + "\n" + T.tutorial.tutorial_shockwave3),
        ("ORBS", (m, m2, input) => T.tutorial.tutorial_orb1 + "\n" + T.tutorial.tutorial_orb2),
    };

    // Generic keyword table, checked after the scene routing (Tutorial /
    // DevMuseum / LevelStrings). Must stay behind LevelStrings: keywords like
    // EQUIPPED have per-level meanings that take priority over the generic one.
    private static readonly (string keyword, Func<string, string, string, string> build)[] PostSceneMessages =
    {
        // 1-3? (also handled by LevelStrings 1-4/4-4/7-2 with the same result)
        ("versions", (m, m2, input) => StringHelper.Get(T.misc.hud_alternateVersion, m)),
        // 4-4
        ("ALTERNATE NAILGUN", (m, m2, input) => StringHelper.Get(T.act2.act2_greedFourth_alternateNailgun, m)),
        // ClearWater's V-rank mod
        ("V-Rank", (m, m2, input) => m),
        // Press punch when not equip any arm
        ("PUNCH", (m, m2, input) =>
        {
            string part1 = T.misc.hud_noArm1;
            string part2 = T.misc.hud_noArm2;
            if (StringHelper.IsEmpty(part1) || StringHelper.IsEmpty(part2))
            {
                Logging.Warn($"[HudMessageStrings] Translation missing or empty for PUNCH, falling back to original: '{m}'");
                return m;
            }
            return "<color=red>" + part1 + "</color>\n" + part2;
        }),
        // When level's timer starts without tick DISABLE ASSIST Popup in Major Assists
        ("MAJOR", (m, m2, input) =>
        {
            string translated = T.misc.hud_majorAssists;
            if (StringHelper.IsEmpty(translated))
            {
                Logging.Warn($"[HudMessageStrings] Translation missing or empty for MAJOR, falling back to original: '{m}'");
                return m;
            }
            return "<color=#4C99E6>" + translated + "</color>";
        }),
        // Red Orb
        ("200", (m, m2, input) => StringHelper.Get(T.misc.hud_overhealOrb1, T.misc.hud_overhealOrb2, "\n", m)),
        // Trying to whiplash the skull that opens the door and you are opposite side of the door
        // Mainly happens in 7-1's skip
        ("ERROR", (m, m2, input) =>
        {
            string translated = T.misc.hud_itemGrabError;
            if (StringHelper.IsEmpty(translated))
            {
                Logging.Warn($"[HudMessageStrings] Translation missing or empty for ERROR, falling back to original: '{m}'");
                return m;
            }
            return "<color=red>" + translated + "</color>";
        }),
        // LevelStatsEnabler.LevelStatsTutorial()
        ("TAB", (m, m2, input) => StringHelper.Get(T.misc.hud_levelStats1, T.misc.hud_levelStats2, "\n", m)),
        // Out of bound
        ("Whoops", (m, m2, input) => StringHelper.Get(T.misc.hud_outOfBounds, m)),
        // 4-S's end: <color=orange>CLASH MODE</color> CHEAT UNLOCKED
        ("CLASH", (m, m2, input) => StringHelper.Get(T.misc.hud_clashMode, m)),
        // 7-S: <color=orange>DRONE HAUNTING</color> CHEAT UNLOCKED
        ("DRONE HAUNTING", (m, m2, input) => StringHelper.Get(T.misc.hud_droneHaunting, m)),
        // First variant bought in shop
        ("EQUIPPED", (m, m2, input) => StringHelper.Get(T.misc.hud_weaponVariation, m)),
        // Sandbox: when you editing a destoried object
        ("Altered", (m, m2, input) =>
        {
            string translated = T.misc.enemyAlter_alteredDestroyed;
            if (StringHelper.IsEmpty(translated))
            {
                Logging.Warn($"[HudMessageStrings] Translation missing or empty for Altered, falling back to original: '{m}'");
                return m;
            }
            return "<color=red>" + translated + "</color>";
        }),
        // P-1
        ("INSUFFICIENT LIGHT", (m, m2, input) => StringHelper.Get(T.primeSanctum.primeSanctum_first_insufficientlight, m)),
        ("=>", (m, m2, input) => m),
        // When entering the secret mission
        ("You have found a <color=orange>SECRET MISSION</color>.", (m, m2, input) => StringHelper.Get(T.misc.secretMissionFound, m)),
    };

    public static string GetMessage(string message, string message2, string input)
    {
        string currentSceneName = GetCurrentSceneName();
        if (input != null && input.Length > 0)
            input = InputNames.Localize(input);

        if (message.Contains("WARNING") || message.Contains("fall") || message.Contains("free"))
            Logging.Warn("[HudMessageStrings] Level: " + currentSceneName + " | message: '" + message + "' | message2: '" + message2 + "' | input: '" + input + "'");

        // Tutorial
        if (currentSceneName.Contains("Tutorial"))
        {
            foreach (var (keyword, build) in TutorialMessages)
                if (message.Contains(keyword))
                    return build(message, message2, input);
        }

        // DevMuseum.
        if (currentSceneName.Contains("CreditsMuseum2"))
        {
            string translated = DevMuseum.GetMessage(message, message2, input);
            if (translated != null)
                return translated;
        }

        // Every level (Prelude, Acts 1-3, Encores)
        string levelMessage = LevelStrings.GetMessage(message, message2, input);
        if (levelMessage != null)
            return levelMessage;

        foreach (var (keyword, build) in PostSceneMessages)
            if (message.Contains(keyword))
                return build(message, message2, input);

        Logging.Warn("No translation for \"" + message + "\" in \"" + currentSceneName + "\"");
        return message;
    }
}
