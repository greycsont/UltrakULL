using System;
using UltrakULL.json;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

/// <summary>
/// HudMessage
/// A component that sends message to HudMessageReceiver when triggered
/// This class contains all message that found by ultrakull dhm command
/// </summary>
public static class LevelStrings
{
    private static JsonFormat T => LanguageManager.CurrentLanguage;

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
                ("\"PIPE CLIP LIVES\"$T. HAKITA", (m, m2, input) => T.prelude.prelude_first_pipeClip),
                ("<color=#40E7FF>REVOLVER</color>: Hold <color=orange>{0}</color> to charge a <color=orange>PIERCING</color> shot.", (m, m2, input) => T.prelude.prelude_first_revolverPierce1 + "<color=orange>" + input + "</color>" + T.prelude.prelude_first_revolverPierce2),
                ("<color=orange>PUNCH</color> a <color=orange>PROJECTILE</color> with precise timing to <color=orange>DEFLECT</color> it.", (m, m2, input) => T.prelude.prelude_first_parry),
                ("Taking damage <color=orange>TEMPORARILY</color> reduces your <color=orange>MAXIMUM HP</color>.$\"<color=#CCCCCC>HARD DAMAGE</color>\" recovers faster when playing <color=orange>STYLISHLY</color>.", (m, m2, input) => T.prelude.prelude_first_hardDamage1 + "\n" + T.prelude.prelude_first_hardDamage2),
                ("<color=orange>GROUND SLAM</color> (<color=orange>{0}</color>) deals damage on direct hit.", (m, m2, input) => T.prelude.prelude_first_groundSlam1 + "<color=orange>" + input + "</color>" + T.prelude.prelude_first_groundSlam2),
            }),
        //0-2 - The Meatgrinder
        new LevelEntry("Level 0-2",
            () => T.levelNames.levelName_preludeSecond,
            () => T.levelChallenges.challenges_preludeSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("Use your <color=orange>POINTS</color> at the <color=orange>SHOP</color> at the start of each level for new equipment.", (m, m2, input) => T.prelude.prelude_second_shop),
                ("\"WHAT'S UPDOOR?\"$T. HAKITA", (m, m2, input) => T.prelude.prelude_second_doorClip),
                // Does this exists? (patch 17d4)
                ("EQUIPPED", (m, m2, input) => T.prelude.prelude_second_changeEquipped + "<color=orange>" + input + "</color>."),
            }),
        //0-3 - Double Down
        new LevelEntry("Level 0-3",
            () => T.levelNames.levelName_preludeThird,
            () => T.levelChallenges.challenges_preludeThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=red>INSUFFICIENT FIREPOWER</color>", (m, m2, input) => "<color=red>" + T.prelude.prelude_third_needShotgun + "</color>"),
                ("<color=#40E7FF>SHOTGUN</color>: Press '<color=orange>{0}</color>' to fire an explosive. Hold to charge distance.", (m, m2, input) => T.prelude.prelude_third_shotgun1 + "<color=orange>" + input + "</color>" + T.prelude.prelude_third_shotgun2 + "\n" + T.prelude.prelude_third_shotgun3),
                ("<color=#40E7FF>SHOTGUN</color>: Primary fire pierces weaker enemies", (m, m2, input) => T.prelude.prelude_third_shotgunPierce),
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
                // Also you have found a scret mission
                ("Something wicked this way comes.", (m, m2, input) => T.prelude.prelude_secret_somethingWicked),
            }),

        // ===== Act 1 =====
        //1-1 - Heart Of The Sunrise
        new LevelEntry("Level 1-1",
            () => T.levelNames.levelName_limboFirst,
            () => T.levelChallenges.challenges_limboFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("Pick <color=orange>ITEMS</color> up with \"<color=orange>{0}</color>\".", (m, m2, input) =>
                {
                    level11PreviousMessage = T.act1.act1_limboFirst_items1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_items2;
                    return T.act1.act1_limboFirst_items1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_items2;
                }),
                ("<color=#40E7FF>NAILGUN</color>: Use <color=orange>{0}</color> to fire a <color=orange>NAIL MAGNET</color>. Can be attached to environment to create traps.", (m, m2, input) =>
                {
                    level11PreviousMessage = T.act1.act1_limboFirst_nailgun1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_nailgun2 + "\n" + T.act1.act1_limboFirst_nailgun3;
                    return T.act1.act1_limboFirst_nailgun1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFirst_nailgun2 + "\n" + T.act1.act1_limboFirst_nailgun3;
                }),
                ("Somewhere in the depths of Limbo, a mechanism is set in motion.", (m, m2, input) => T.act1.act1_secret),
            },
            fallback: (m, m2, input) => level11PreviousMessage),
        //1-2 - The Burning World
        new LevelEntry("Level 1-2",
            () => T.levelNames.levelName_limboSecond,
            () => T.levelChallenges.challenges_limboSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("A <color=#00ffffff>BLUE FLASH</color> means an attack is <color=#00ffffff>UNPARRIABLE</color>", (m, m2, input) => T.act1.act1_limboSecond_blueAttack),
                ("Somewhere in the depths of Limbo, a mechanism is set in motion.", (m, m2, input) => T.act1.act1_secret),
            }),
        //1-3 - Hall Of Sacred Remains
        new LevelEntry("Level 1-3",
            () => T.levelNames.levelName_limboThird,
            () => T.levelChallenges.challenges_limboThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=red>SPLIT</color> <color=#00ffffff>COLOR</color> doors only require <color=red>ONE</color> <color=#00ffffff>SKULL</color> to open.$If you do not seek hardship, stay indoors.", (m, m2, input) => T.act1.act1_limboThird_splitDoor1 + "\n" + T.act1.act1_limboThird_splitDoor2),
                ("Somewhere in the depths of Limbo, a mechanism is set in motion.", (m, m2, input) => T.act1.act1_secret),
            }),
        //1-4 - Clair De Lune
        new LevelEntry("Level 1-4",
            () => T.levelNames.levelName_limboFourth,
            () => T.levelChallenges.challenges_limboFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=orange>PICK UP</color> TO READ.", (m, m2, input) => T.act1.act1_limboFourth_book),
                ("Nothing happens, but you feel a strange satisfaction.$You decide to name it Hank.", (m, m2, input) => T.act1.act1_limboFourth_hank1 + "\n" + T.act1.act1_limboFourth_hank2),
                ("<color=orange>ALTERNATE</color> versions will change a weapon's base behavior. They can be equipped at the <color=orange>SHOP</color>.", (m, m2, input) => T.misc.hud_alternateVersion),
                ("<color=orange>ALTERNATE REVOLVER</color>: Higher damage.$Hammer has to pull back after each shot.", (m, m2, input) => T.act1.act1_limboFourth_alternateRevolver),
                ("Cycle through <color=orange>EQUIPPED</color> arms with '<color=orange>{0}</color>'", (m, m2, input) => T.act1.act1_limboFourth_newArm1 + "<color=orange>" + input + "</color>" + T.act1.act1_limboFourth_newArm2),
                ("Somewhere in the depths of Limbo, a mechanism is set in motion.", (m, m2, input) => T.act1.act1_secret),
            }),
        //1-S - The Witless
        new LevelEntry("Level 1-S",
            () => T.levelNames.levelName_limboSecret,
            () => null,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("\"LOOKS LIKE YOU'RE AT WIT'S END\"$T. HAKITA", (m, m2, input) => T.act1.act1_limboSecret_noclipSkip),
            }),
        //2-1 - Bridgeburner
        new LevelEntry("Level 2-1",
            () => T.levelNames.levelName_lustFirst,
            () => T.levelChallenges.challenges_lustFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=red>KNUCKLE BLASTER</color>: <color=orange>HOLD</color> '<color=orange>{0}</color>' to create a <color=orange>SHOCKWAVE</color> that knocks enemies back.", (m, m2, input) => T.act1.act1_lustFirst_knuckleblaster1 + "<color=orange>" + input + "</color>" + T.act1.act1_lustFirst_knuckleblaster2),
                ("<color=orange>JUMP</color> during a <color=#00ffffff>DASH</color> for a long-distance <color=#00ffffff>DASH JUMP</color>.$Cannot be performed in air.", (m, m2, input) => T.act1.act1_lustFirst_dashJump),
            }),
        //2-2 - Death at 20,000 Volts
        new LevelEntry("Level 2-2",
            () => T.levelNames.levelName_lustSecond,
            () => T.levelChallenges.challenges_lustSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("Only the <color=#40E7FF>FEEDBACKER</color> (<color=#40E7FF>Blue arm</color>) can <color=orange>PARRY PROJECTILES</color>. Swap arms with '<color=orange>{0}</color>'.", (m, m2, input) => T.act1.act1_lustSecond_feedbacker1 + "\n" + T.act1.act1_lustSecond_feedbacker2 + "<color=orange>" + input + "</color>."),
                ("<color=#40E7FF>RAILCANNON</color>: <color=orange>RECHARGES</color> even when <color=orange>UNEQUIPPED</color>. Switch weapons to keep fighting between shots.", (m, m2, input) => T.act1.act1_lustSecond_railcannon),
                ("<color=#FF52FF>CIRCULAR CHECKPOINTS</color> can be reused to keep your progress.", (m, m2, input) => T.act1.act1_lustSecond_checkPoints),
            }),
        //2-3 - Sheer Heart Attack
        new LevelEntry("Level 2-3",
            () => T.levelNames.levelName_lustThird,
            () => T.levelChallenges.challenges_lustThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The water has been drained", (m, m2, input) => T.act1.act1_lustThird_water),
            }),
        //2-4 - Court Of The Corpse King
        new LevelEntry("Level 2-4",
            () => T.levelNames.levelName_lustFourth,
            () => T.levelChallenges.challenges_lustFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("\"OFF THE BEATEN TRACK\"$T. HAKITA", (m, m2, input) => T.act1.act1_lustFourth_offTheBeatenTrack),
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
                ("\"YUP, THAT'S A CAVITY\"$T. HAKITA", (m, m2, input) => T.act1.act1_greedFirst_cavity),
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
                ("ENEMIES COVERED IN SAND WILL <color=red>NOT BLEED</color>", (m, m2, input) => T.act2.act2_greedSecond_sand),
                ("A door opens.", (m, m2, input) => T.act3.act3_violenceFirst_doorOpens),
            }),
        //4-3
        new LevelEntry("Level 4-3",
            () => T.levelNames.levelName_greedThird,
            () => T.levelChallenges.challenges_greedThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("\"THE FILTH IS GONE, BUT THE MEMORY REMAINS\"$T. HAKITA", (m, m2, input) => T.act2.act2_greedThird_wallClip),
                ("Something wicked this way comes.", (m, m2, input) => T.act2.act2_greedThird_troll1),
                ("Just kidding :)", (m, m2, input) => T.act2.act2_greedThird_troll2),
                ("TOMB OF KINGS", (m, m2, input) => T.act2.act2_greedThird_tombOfKings),
            }),
        //4-4
        new LevelEntry("Level 4-4",
            () => T.levelNames.levelName_greedFourth,
            () => T.levelChallenges.challenges_greedFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=orange>ALTERNATE</color> versions will change a weapon's base behavior. They can be equipped at the <color=orange>SHOP</color>.", (m, m2, input) => T.misc.hud_alternateVersion),
                ("<color=orange>ALTERNATE NAILGUN</color>: Slower firerate.$Projectiles ricochet off surfaces.", (m, m2, input) => T.act2.act2_greedFourth_alternateNailgun),
                ("You're not getting away this time.", (m, m2, input) => T.act2.act2_greedFourth_v2),
                ("<color=green>WHIPLASH</color>: Hold <color=orange>{0}</color> to throw, release to pull", (m, m2, input) =>
                {
                    level44PreviousMessage = T.act2.act2_greedFourth_whiplash1 + "<color=orange>" + input + "</color>" + T.act2.act2_greedFourth_whiplash2;
                    return level44PreviousMessage;
                }),
                ("<color=green>WHIPLASH</color>: Pull <color=orange>LIGHT</color> enemies to you, pull yourself to <color=orange>HEAVY</color> enemies.", (m, m2, input) =>
                {
                    level44PreviousMessage = T.act2.act2_greedFourth_whiplash3;
                    return level44PreviousMessage;
                }),
                // Need hints for <color=green>WHIPLASH</color>: Builds up <color=#CCCCCC>HARD DAMAGE</color> when used on <color=orange>ENEMIES</color>.$<color=orange>CANNOT REDUCE HP</color>, but risky to use at low health.
            }),
        //4-S
        new LevelEntry("Level 4-S",
            () => null,
            () => null,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("HOLD [<color=orange>{0}</color>] TO BOUNCE HIGHER", (m, m2, input) => T.act2.act2_greedSecret_holdToJump1 + "<color=orange>" + input + "</color>" + T.act2.act2_greedSecret_holdToJump2),
            }),
        //5-1
        new LevelEntry("Level 5-1",
            () => T.levelNames.levelName_wrathFirst,
            () => T.levelChallenges.challenges_wrathFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=#00ffffff>BLUE HOOKPOINTS</color> act as slingshots", (m, m2, input) => T.act2.act2_wrathFirst_slingshot),
                ("<color=green>INTERRUPTING SENTRIES</color>:$Knuckleblaster (Red arm) <color=orange>//</color> Railcannon <color=orange>//</color> Ground slam shockwave <color=orange>//</color> Revolver to the antenna", (m, m2, input) => T.act2.act2_wrathFirst_sentry),
                ("The water has been drained", (m, m2, input) => T.act2.act2_wrathFirst_waterDrained),
                ("<color=green>WHIPLASH</color>: Builds up <color=#CCCCCC>HARD DAMAGE</color> when used on <color=orange>ENEMIES</color>.$<color=orange>CANNOT REDUCE HP</color>, but risky to use at low health.", (m, m2, input) => T.act2.act2_wrathFirst_whiplashHardDamage1 + "\n" + T.act2.act2_wrathFirst_whiplashHardDamage2),
                ("<color=green>WHIPLASH</color>: Does <color=orange>NOT</color> build up <color=#CCCCCC>HARD DAMAGE</color> while <color=orange>UNDERWATER</color>.", (m, m2, input) => T.act2.act2_wrathFirst_whiplashUnderwater),
                ("A door opens.", (m, m2, input) => T.act3.act3_violenceFirst_doorOpens),
            }),
        //5-2
        new LevelEntry("Level 5-2",
            () => T.levelNames.levelName_wrathSecond,
            () => T.levelChallenges.challenges_wrathSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=red>I AM JAKITO. BRING ME A SACRIFICE. IT WILL GIVE ME THE POWER TO ESCAPE.</color>", (m, m2, input) => T.act2.act2_wrathSecond_jakito1),
                ("<color=red>THANK YOU. NOW I SHALL LAY WASTE TO THIS WORLD.</color>", (m, m2, input) => T.act2.act2_wrathSecond_jakito2),
                ("<color=red>NO. IT MUST BE INNOCENT FLESH.</color>", (m, m2, input) => T.act2.act2_wrathSecond_jakito3),
                ("Hark! Neptune has struck them dead.", (m, m2, input) => T.act2.act2_wrathSecond_neptune),
                ("<color=#00ffffff>IDOLS</color> can only be broken with <color=orange>MELEE</color>", (m, m2, input) => T.act2.act2_wrathSecond_idol),
            }),
        //5-3
        new LevelEntry("Level 5-3",
            () => T.levelNames.levelName_wrathThird,
            () => T.levelChallenges.challenges_wrathThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=#40E7FF>ROCKET LAUNCHER</color>: <color=orange>DIRECT</color> hits cause <color=orange>EXPLOSIONS</color>.$Indirect hits will launch enemies.", (m, m2, input) => T.act2.act2_wrathThird_rocketLauncher),
                ("<color=#40E7FF>ROCKET LAUNCHER</color>: Direct hits on <color=orange>FALLING</color> enemies will cause a <color=orange>STRONGER</color> explosion", (m, m2, input) => T.act2.act2_wrathThird_rocketLauncherMidair),
                ("Soldiers <color=orange>CANNOT</color> block explosions while in the <color=orange>AIR</color>.$Shoot a rocket <color=orange>NEAR</color> them to launch them.", (m, m2, input) => T.act2.act2_wrathThird_soldierBlock),
                ("Nothing happens, but you're sure Hank Jr. and his Hankcestors would appreciate it... If they weren't dead.", (m, m2, input) => T.act2.act2_wrathThird_hank),
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
                ("\"It's a living.\"", (m, m2, input) => T.fishing.fish_living)
            }),
        //6-1
        new LevelEntry("Level 6-1",
            () => T.levelNames.levelName_heresyFirst,
            () => T.levelChallenges.challenges_heresyFirst,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("A R M B O Y ! ! !", (m, m2, input) => T.act2.act2_heresyFirst_armboy),
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
                // If you are using ultrakull dhm for this level, you may found message:
                //   Somewhere in the depths of Limbo, a mechanism is set in motion.
                // This message in here because the dev reuses the button from Limbo
                // But it will not show up so don't add it in here
                ("The <color=orange>GUTTERMAN SHIELD</color> can be <color=orange>BROKEN</color> with the <color=red>KNUCKLEBLASTER</color>. Swap arms with '<color=orange>{0}</color>'.", (m, m2, input) => T.act3.act3_violenceSecond_guttermanTutorial1 + "<color=orange>" + input + "</color>" + T.act3.act3_violenceSecond_guttermanTutorial2),
                ("The <color=orange>GUTTERMAN SHIELD</color> can be <color=orange>BROKEN</color> with the <color=red>KNUCKLEBLASTER</color>. You should probably re-equip it.", (m, m2, input) => T.act3.act3_violenceSecond_guttermanTutorialNoKB),
                ("<color=red>WE'RE GONNA NEED A BIGGER BOOM</color>", (m, m2, input) => "<color=red>" + T.act3.act3_violenceSecond_biggerBoom + "</color>"),
                ("<color=orange>ALTERNATE</color> versions will change a weapon's base behavior. They can be equipped at the <color=orange>SHOP</color>.", (m, m2, input) => T.misc.hud_alternateVersion),
                ("<color=orange>ALTERNATE SHOTGUN</color>: Melee only.$Move fast to deal more damage.", (m, m2, input) => T.act3.act3_violenceSecond_alternateShotgun),
            }),
        //7-3
        new LevelEntry("Level 7-3",
            () => T.levelNames.levelName_violenceThird,
            () => T.levelChallenges.challenges_violenceThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=red>F E E D   I T .</color>", (m, m2, input) => "<color=red>" + T.act3.act3_violenceThird_feedIt + "</color>"),
            }),
        //7-4
        new LevelEntry("Level 7-4",
            () => T.levelNames.levelName_violenceFourth,
            () => T.levelChallenges.challenges_violenceFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("<color=#FF007F>MAGENTA</color> attacks <color=#FF007F>CANNOT</color> be dashed through <color=#FF007F>WITHOUT TAKING DAMAGE</color>.", (m, m2, input) => T.act3.act3_violenceFourth_magentaAttack),
            }),
        //7-S
        new LevelEntry("Level 7-S",
            () => null,
            () => null),
        //8-1
        new LevelEntry("Level 8-1",
            () => T.levelNames.levelName_fraudFirst,
            () => T.levelChallenges.challenges_fraudFirst),
        //8-2
        new LevelEntry("Level 8-2",
            () => T.levelNames.levelName_fraudSecond,
            () => T.levelChallenges.challenges_fraudSecond,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life...", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife),
                ("YOU'RE NOT SUPPOSED TO BE HERE.", (m, m2, input) => T.act3.act3_secretNotReady),
                ("It is happening again.", (m, m2, input) => T.act3.act3_fraudSecond_happeningAgain),
            }),
        //8-3
        new LevelEntry("Level 8-3",
            () => T.levelNames.levelName_fraudThird,
            () => T.levelChallenges.challenges_fraudThird,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life...", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife)
            }),
        //8-4
        new LevelEntry("Level 8-4",
            () => T.levelNames.levelName_fraudFourth,
            () => T.levelChallenges.challenges_fraudFourth,
            new (string keyword, Func<string, string, string, string> build)[]
            {
                ("The cycle of life...", (m, m2, input) => T.act3.act3_fraudSecond_cycleOfLife),
                ("<color=orange>WARNING:</color> Extended free fall detected.\nEnabling fall controls: <color=orange>{0}</color> and <color=orange>{1}</color>.", 
                    (m, m2, input) => 
                        T.act3.act3_fraudFourth_fallWarning_part1 + "\n"
                        + T.act3.act3_fraudFourth_fallWarning_part2 + " <color=orange>{0}</color> "
                        + T.act3.act3_fraudFourth_fallWarning_part3 + " <color=orange>{1}</color>."),
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
                ("<color=orange>RADIANT</color> enemies have increased health and speed.", (m, m2, input) => T.encore.encorePrelude_aboutRadiantEnemies),
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
