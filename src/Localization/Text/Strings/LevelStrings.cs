using System;
using UltrakULL.json;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

/// <summary>
/// Single table for every level's HUD messages, level names and challenges
/// (Prelude, Acts 1-3, Encores). Merged from the old per-act classes.
///
/// Semantics: a level name/challenge that is missing, empty, or not in the
/// table falls back to the original scene name (e.g. "Level 1-1") — never to
/// a hard-coded English placeholder. A HUD message with no keyword match
/// returns null, matching StringHelper.
/// </summary>
public static class LevelStrings
{
    private static JsonFormat T => LanguageManager.CurrentLanguage;

    // Cross-level messages, checked before the per-level keyword lists.
    private static readonly (string keyword, Func<string, string, string, string> build)[] CommonMessages =
    {
        // Slab revolver switch (was Act1-only; the keyword is Act1-specific anyway).
        ("mechanism", (m, m2, input) => T.act1.act1_secret),
    };

    // Per-level band-aid state (kept across calls).
    private static string level11PreviousMessage;
    private static string level44PreviousMessage;

    public static string GetMessage(string message, string message2, string input)
    {
        string levelId = GetCurrentSceneName();

        // Level 4-4: an empty message repeats the previously shown one.
        if (levelId == "Level 4-4" && (message + message2) == "")
            return level44PreviousMessage;

        // Level 8-4 is handled by its table entry (keywords below). The
        // free-fall warning itself is matched and translated by SendHudMessage2
        // at level of HudMessage.cs (it carries {0}/{1} templates the game
        // formats with the input names), not routed through GetMessage here.
        string full = message + message2;

        foreach (var (keyword, build) in CommonMessages)
            if (full.Contains(keyword))
                return build(message, message2, input);

        foreach (var level in Levels)
        {
            if (level.LevelId != levelId)
                continue;

            foreach (var (keyword, build) in level.Messages)
                if (full.Contains(keyword))
                    return build(message, message2, input);

            return level.Fallback?.Invoke(message, message2, input);
        }

        return null;
    }

    /// <summary>
    /// The 8-4 free-fall warning template, built from the translated parts.
    /// The game's ShowHudMessage converts each input name (KeyCode -> display
    /// name, localized by ShowHudMessageInputNamePatch) and then string.Formats
    /// it into the {0}/{1} placeholders. Detection of the warning (WARNING: +
    /// free fall) lives in SendHudMessage2_Prefix, which matches by content
    /// regardless of scene. Later the parts become a single JSON template field
    /// the translators write {0}/{1} in directly.
    /// </summary>
    public static string FreeFallWarning() =>
        T.act3.act3_fraudFourth_fallWarning_part1 + "\n"
        + T.act3.act3_fraudFourth_fallWarning_part2 + " <color=orange>{0}</color> "
        + T.act3.act3_fraudFourth_fallWarning_part3 + " <color=orange>{1}</color>.";

    public static string GetLevelName()
    {
        string sceneName = GetCurrentSceneName();
        return LevelNameFor(sceneName);
    }

    public static string GetLevelChallenge(string currentLevel)
    {
        return ChallengeFor(currentLevel);
    }

    /// <summary>
    /// "0-1: <name>" from the translated field, or the original scene name when
    /// the field is empty/missing/unknown.
    /// </summary>
    public static string LevelNameFor(string sceneName)
    {
        foreach (var level in Levels)
        {
            if (level.LevelId != sceneName)
                continue;

            string name = level.LevelName();
            if (StringHelper.IsEmpty(name))
                return sceneName;

            return sceneName.Substring("Level ".Length) + ": " + name;
        }

        return sceneName;
    }

    /// <summary>
    /// The translated challenge for the level, or the original scene name when
    /// the field is empty/missing/unknown.
    /// </summary>
    public static string ChallengeFor(string sceneName)
    {
        foreach (var level in Levels)
        {
            if (level.LevelId != sceneName)
                continue;

            string challenge = level.Challenge();
            return StringHelper.IsEmpty(challenge) ? sceneName : challenge;
        }

        return sceneName;
    }

    private static readonly LevelEntry[] Levels =
    {
        // ===== Prelude =====
        //0-1 - Into The Fire
        new LevelEntry("Level 0-1",
            () => T.levelNames.levelName_preludeFirst,
            () => T.levelChallenges.challenges_preludeFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("PIPE CLIP", (m, m2, input) => T.prelude.prelude_first_pipeClip),
                ("REVOLVER", (m, m2, input) => T.prelude.prelude_first_revolverPierce1 + "<color=orange>" + input + "</color>" + T.prelude.prelude_first_revolverPierce2),
                ("DEFLECT", (m, m2, input) => T.prelude.prelude_first_parry),
                ("HARD DAMAGE", (m, m2, input) => T.prelude.prelude_first_hardDamage1 + "\n" + T.prelude.prelude_first_hardDamage2),
                ("GROUND SLAM", (m, m2, input) => T.prelude.prelude_first_groundSlam1 + "<color=orange>" + input + "</color>" + T.prelude.prelude_first_groundSlam2),
            }),
        //0-2 - The Meatgrinder
        new LevelEntry("Level 0-2",
            () => T.levelNames.levelName_preludeSecond,
            () => T.levelChallenges.challenges_preludeSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("POINTS", (m, m2, input) => T.prelude.prelude_second_shop),
                ("UPDOOR", (m, m2, input) => T.prelude.prelude_second_doorClip),
                ("EQUIPPED", (m, m2, input) => T.prelude.prelude_second_changeEquipped + "<color=orange>" + input + "</color>."),
            }),
        //0-3 - Double Down
        new LevelEntry("Level 0-3",
            () => T.levelNames.levelName_preludeThird,
            () => T.levelChallenges.challenges_preludeThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("FIREPOWER", (m, m2, input) => "<color=red>" + T.prelude.prelude_third_needShotgun + "</color>"),
                ("explosive", (m, m2, input) => T.prelude.prelude_third_shotgun1 + "<color=orange>" + input + "</color>" + T.prelude.prelude_third_shotgun2 + "\n" + T.prelude.prelude_third_shotgun3),
                ("pierces", (m, m2, input) => T.prelude.prelude_third_shotgunPierce),
            }),
        //0-4 - A One-Machine Army (no HUD box strings)
        new LevelEntry("Level 0-4",
            () => T.levelNames.levelName_preludeFourth,
            () => T.levelChallenges.challenges_preludeFourth),
        //0-5 - Cerberus (no HUD box strings)
        new LevelEntry("Level 0-5",
            () => T.levelNames.levelName_preludeFifth,
            () => T.levelChallenges.challenges_preludeFifth),
        //0-S - Something Wicked (no translated name/challenge)
        new LevelEntry("Level 0-S",
            () => null,
            () => null,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("wicked", (m, m2, input) => T.prelude.prelude_secret_somethingWicked),
            }),

        // ===== Act 1 =====
        //1-1 - Heart Of The Sunrise
        new LevelEntry("Level 1-1",
            () => T.levelNames.levelName_limboFirst,
            () => T.levelChallenges.challenges_limboFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("ITEMS", (m, m2, input) =>
                {
                    level11PreviousMessage = T.act1.act1_limboFirst_items1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_items2;
                    return T.act1.act1_limboFirst_items1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_items2;
                }),
                ("NAILGUN", (m, m2, input) =>
                {
                    level11PreviousMessage = T.act1.act1_limboFirst_nailgun1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_nailgun2 + "\n" + T.act1.act1_limboFirst_nailgun3;
                    return T.act1.act1_limboFirst_nailgun1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_nailgun2 + "\n" + T.act1.act1_limboFirst_nailgun3;
                }),
            },
            fallback: (m, m2, input) => level11PreviousMessage),
        //1-2 - The Burning World
        new LevelEntry("Level 1-2",
            () => T.levelNames.levelName_limboSecond,
            () => T.levelChallenges.challenges_limboSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("BLUE", (m, m2, input) => T.act1.act1_limboSecond_blueAttack),
            }),
        //1-3 - Hall Of Sacred Remains
        new LevelEntry("Level 1-3",
            () => T.levelNames.levelName_limboThird,
            () => T.levelChallenges.challenges_limboThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("SPLIT", (m, m2, input) => T.act1.act1_limboThird_splitDoor1 + "\n" + T.act1.act1_limboThird_splitDoor2),
            }),
        //1-4 - Clair De Lune
        new LevelEntry("Level 1-4",
            () => T.levelNames.levelName_limboFourth,
            () => T.levelChallenges.challenges_limboFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("PICK", (m, m2, input) => T.act1.act1_limboFourth_book),
                ("Hank", (m, m2, input) => T.act1.act1_limboFourth_hank1 + "\n" + T.act1.act1_limboFourth_hank2),
                ("versions", (m, m2, input) => T.misc.hud_alternateVersion),
                ("ALTERNATE REVOLVER", (m, m2, input) => T.act1.act1_limboFourth_alternateRevolver),
                ("EQUIPPED", (m, m2, input) => T.act1.act1_limboFourth_newArm1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFourth_newArm2),
            }),
        //1-S - The Witless
        new LevelEntry("Level 1-S",
            () => T.levelNames.levelName_limboSecret,
            () => null,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("LOOKS", (m, m2, input) => T.act1.act1_limboSecret_noclipSkip),
            }),
        //2-1 - Bridgeburner
        new LevelEntry("Level 2-1",
            () => T.levelNames.levelName_lustFirst,
            () => T.levelChallenges.challenges_lustFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("KNUCKLE", (m, m2, input) => T.act1.act1_lustFirst_knuckleblaster1 + "<color=orange>" + input + "</color>" + T.act1.act1_lustFirst_knuckleblaster2),
                ("DASH", (m, m2, input) => T.act1.act1_lustFirst_dashJump),
            }),
        //2-2 - Death at 20,000 Volts
        new LevelEntry("Level 2-2",
            () => T.levelNames.levelName_lustSecond,
            () => T.levelChallenges.challenges_lustSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("FEEDBACKER", (m, m2, input) => T.act1.act1_lustSecond_feedbacker1 + "\n" + T.act1.act1_lustSecond_feedbacker2 + "<color=orange>" + input + "</color>."),
                ("RAILCANNON", (m, m2, input) => T.act1.act1_lustSecond_railcannon),
                ("CHECKPOINTS", (m, m2, input) => T.act1.act1_lustSecond_checkPoints),
            }),
        //2-3 - Sheer Heart Attack
        new LevelEntry("Level 2-3",
            () => T.levelNames.levelName_lustThird,
            () => T.levelChallenges.challenges_lustThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("water", (m, m2, input) => T.act1.act1_lustThird_water),
            }),
        //2-4 - Court Of The Corpse King
        new LevelEntry("Level 2-4",
            () => T.levelNames.levelName_lustFourth,
            () => T.levelChallenges.challenges_lustFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("OFF THE BEATEN TRACK", (m, m2, input) => T.act1.act1_lustFourth_offTheBeatenTrack),
            }),
        //2-S
        new LevelEntry("Level 2-S",
            () => T.levelNames.levelName_lustSecret,
            () => null),
        //3-1 - Belly Of The Beast
        new LevelEntry("Level 3-1",
            () => T.levelNames.levelName_gluttonyFirst,
            () => T.levelChallenges.challenges_gluttonyFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("YUP, THAT'S A CAVITY", (m, m2, input) => T.act1.act1_greedFirst_cavity),
            }),
        //3-2 - In The Flesh
        new LevelEntry("Level 3-2",
            () => T.levelNames.levelName_gluttonySecond,
            () => T.levelChallenges.challenges_gluttonySecond),

        // ===== Act 2 =====
        //4-1
        new LevelEntry("Level 4-1",
            () => T.levelNames.levelName_greedFirst,
            () => T.levelChallenges.challenges_greedFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("An eye opens.", (m, m2, input) => T.act2.act2_greed_secretDoor),
            }),
        //4-2
        new LevelEntry("Level 4-2",
            () => T.levelNames.levelName_greedSecond,
            () => T.levelChallenges.challenges_greedSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("BLEED", (m, m2, input) => T.act2.act2_greedSecond_sand),
                ("A door opens.", (m, m2, input) => T.act3.act3_violenceFirst_doorOpens),
            }),
        //4-3
        new LevelEntry("Level 4-3",
            () => T.levelNames.levelName_greedThird,
            () => T.levelChallenges.challenges_greedThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("FILTH", (m, m2, input) => T.act2.act2_greedThird_wallClip),
                ("wicked", (m, m2, input) => T.act2.act2_greedThird_troll1),
                ("kidding", (m, m2, input) => T.act2.act2_greedThird_troll2),
                ("TOMB", (m, m2, input) => T.act2.act2_greedThird_tombOfKings),
            }),
        //4-4
        new LevelEntry("Level 4-4",
            () => T.levelNames.levelName_greedFourth,
            () => T.levelChallenges.challenges_greedFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("versions", (m, m2, input) => T.misc.hud_alternateVersion),
                ("ALTERNATE NAILGUN", (m, m2, input) => T.act2.act2_greedFourth_alternateNailgun),
                ("You're", (m, m2, input) => T.act2.act2_greedFourth_v2),
                ("Hold", (m, m2, input) =>
                {
                    level44PreviousMessage = T.act2.act2_greedFourth_whiplash1 + "<color=orange>" + input + "</color>" + T.act2.act2_greedFourth_whiplash2;
                    return level44PreviousMessage;
                }),
                ("HEAVY", (m, m2, input) =>
                {
                    level44PreviousMessage = T.act2.act2_greedFourth_whiplash3;
                    return level44PreviousMessage;
                }),
            }),
        //4-S
        new LevelEntry("Level 4-S",
            () => null,
            () => null,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("HOLD", (m, m2, input) => T.act2.act2_greedSecret_holdToJump1 + "<color=orange>" + input + "</color>" + T.act2.act2_greedSecret_holdToJump2),
            }),
        //5-1
        new LevelEntry("Level 5-1",
            () => T.levelNames.levelName_wrathFirst,
            () => T.levelChallenges.challenges_wrathFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("HOOKPOINT", (m, m2, input) => T.act2.act2_wrathFirst_slingshot),
                ("SENTRIES", (m, m2, input) => T.act2.act2_wrathFirst_sentry),
                ("drained", (m, m2, input) => T.act2.act2_wrathFirst_waterDrained),
                // Renamed to act2_wrathFirst_whiplashHardDamage* because message moved from 4-4 to 5-1
                ("REDUCE", (m, m2, input) => T.act2.act2_wrathFirst_whiplashHardDamage1 + "\n" + T.act2.act2_wrathFirst_whiplashHardDamage2),
                ("UNDERWATER", (m, m2, input) => T.act2.act2_wrathFirst_whiplashUnderwater),
                ("A door opens.", (m, m2, input) => T.act3.act3_violenceFirst_doorOpens),
            }),
        //5-2
        new LevelEntry("Level 5-2",
            () => T.levelNames.levelName_wrathSecond,
            () => T.levelChallenges.challenges_wrathSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("JAKITO", (m, m2, input) => T.act2.act2_wrathSecond_jakito1),
                ("THANK", (m, m2, input) => T.act2.act2_wrathSecond_jakito2),
                ("NO", (m, m2, input) => T.act2.act2_wrathSecond_jakito3),
                ("Hark", (m, m2, input) => T.act2.act2_wrathSecond_neptune),
                ("IDOL", (m, m2, input) => T.act2.act2_wrathSecond_idol),
            }),
        //5-3
        new LevelEntry("Level 5-3",
            () => T.levelNames.levelName_wrathThird,
            () => T.levelChallenges.challenges_wrathThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("Indirect", (m, m2, input) => T.act2.act2_wrathThird_rocketLauncher),
                ("FALLING", (m, m2, input) => T.act2.act2_wrathThird_rocketLauncherMidair),
                ("Soldiers", (m, m2, input) => T.act2.act2_wrathThird_soldierBlock),
                ("Hank", (m, m2, input) => T.act2.act2_wrathThird_hank),
            }),
        //5-4
        new LevelEntry("Level 5-4",
            () => T.levelNames.levelName_wrathFourth,
            () => T.levelChallenges.challenges_wrathFourth),
        //5-S (fishing)
        new LevelEntry("Level 5-S",
            () => null,
            () => null,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("living", (m, m2, input) => T.fishing.fish_living),
                ("Too small", (m, m2, input) => T.fishing.fish_tooSmall),
                ("This bait", (m, m2, input) => T.fishing.fish_baitNotWork),
                ("A fish took", (m, m2, input) => T.fishing.fish_baitTaken),
                ("Fishing interrupted", (m, m2, input) => T.fishing.fish_interrupted),
                ("Cooking failed", (m, m2, input) => T.fishing.fish_cookingFailed),
                ("Nothing seems", (m, m2, input) => T.fishing.fish_noFishBiting),
            }),
        //6-1
        new LevelEntry("Level 6-1",
            () => T.levelNames.levelName_heresyFirst,
            () => T.levelChallenges.challenges_heresyFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("A R M B O Y", (m, m2, input) => T.act2.act2_heresyFirst_armboy),
            }),
        //6-2
        new LevelEntry("Level 6-2",
            () => T.levelNames.levelName_heresySecond,
            () => T.levelChallenges.challenges_heresySecond),

        // ===== Act 3 =====
        //7-1
        new LevelEntry("Level 7-1",
            () => T.levelNames.levelName_violenceFirst,
            () => T.levelChallenges.challenges_violenceFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("A door opens.", (m, m2, input) => T.act3.act3_violenceFirst_doorOpens),
            }),
        //7-2
        new LevelEntry("Level 7-2",
            () => T.levelNames.levelName_violenceSecond,
            () => T.levelChallenges.challenges_violenceSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("Swap arms with", (m, m2, input) => T.act3.act3_violenceSecond_guttermanTutorial1 + "<color=orange>" + input + "</color>" + T.act3.act3_violenceSecond_guttermanTutorial2),
                ("You should probably", (m, m2, input) => T.act3.act3_violenceSecond_guttermanTutorialNoKB),
                ("BIGGER BOOM", (m, m2, input) => "<color=red>" + T.act3.act3_violenceSecond_biggerBoom + "</color>"),
                ("versions", (m, m2, input) => T.misc.hud_alternateVersion),
                ("ALTERNATE SHOTGUN", (m, m2, input) => T.act3.act3_violenceSecond_alternateShotgun),
            }),
        //7-3
        new LevelEntry("Level 7-3",
            () => T.levelNames.levelName_violenceThird,
            () => T.levelChallenges.challenges_violenceThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("F E E D", (m, m2, input) => "<color=red>" + T.act3.act3_violenceThird_feedIt + "</color>"),
            }),
        //7-4
        new LevelEntry("Level 7-4",
            () => T.levelNames.levelName_violenceFourth,
            () => T.levelChallenges.challenges_violenceFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("MAGENTA", (m, m2, input) => T.act3.act3_violenceFourth_magentaAttack),
            }),
        //7-S
        new LevelEntry("Level 7-S",
            () => null,
            () => null),
        //8-1
        new LevelEntry("Level 8-1",
            () => T.levelNames.levelName_fraudFirst,
            () => T.levelChallenges.challenges_fraudFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife),
                ("It is happening again", (m, m2, input) => T.act3.act3_fraudSecond_happeningAgain),
            }),
        //8-2
        new LevelEntry("Level 8-2",
            () => T.levelNames.levelName_fraudSecond,
            () => T.levelChallenges.challenges_fraudSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife),
                ("YOU'RE NOT SUPPOSED TO BE HERE.", (m, m2, input) => T.act3.act3_secretNotReady),
                ("It is happening again", (m, m2, input) => T.act3.act3_fraudSecond_happeningAgain),
            }),
        //8-3
        new LevelEntry("Level 8-3",
            () => T.levelNames.levelName_fraudThird,
            () => T.levelChallenges.challenges_fraudThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife),
                ("It is happening again", (m, m2, input) => T.act3.act3_fraudSecond_happeningAgain),
            }),
        //8-4
        new LevelEntry("Level 8-4",
            () => T.levelNames.levelName_fraudFourth,
            () => T.levelChallenges.challenges_fraudFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife),
                ("It is happening again", (m, m2, input) => T.act3.act3_fraudSecond_happeningAgain),
            }),
        //8-S
        new LevelEntry("Level 8-S",
            () => null,
            () => null),
        //9-1
        new LevelEntry("Level 9-1",
            () => T.levelNames.levelName_treacheryFirst,
            () => T.levelChallenges.challenges_treacheryFirst),
        //9-2
        new LevelEntry("Level 9-2",
            () => T.levelNames.levelName_treacherySecond,
            () => T.levelChallenges.challenges_treacherySecond),

        // ===== Encores =====
        new LevelEntry("Level 0-E",
            () => T.levelNames.levelName_encorePrelude,
            () => "There are no Challenges for this level.",
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("RADIANT", (m, m2, input) => T.encore.encorePrelude_aboutRadiantEnemies),
            }),
        new LevelEntry("Level 1-E",
            () => T.levelNames.levelName_encoreLimbo,
            () => "There are no Challenges for this level."),
    };

    private sealed class LevelEntry
    {
        public LevelEntry(
            string levelId,
            Func<string> levelName,
            Func<string> challenge,
            (string keyword, Func<string, string, string, string> build)[] messages = null,
            Func<string, string, string, string> fallback = null)
        {
            LevelId = levelId;
            LevelName = levelName;
            Challenge = challenge;
            Messages = messages ?? Array.Empty<(string, Func<string, string, string, string>)>();
            Fallback = fallback;
        }

        public string LevelId { get; }
        public Func<string> LevelName { get; }
        public Func<string> Challenge { get; }
        public (string keyword, Func<string, string, string, string> build)[] Messages { get; }
        public Func<string, string, string, string> Fallback { get; }
    }
}
