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
        ("Press '<color=orange>{0}</color>' to <color=orange>PUNCH</color>.", (m, m2, input) => T.tutorial.tutorial_punch1 + "<color=orange>" + input + "</color>" + T.tutorial.tutorial_punch2),
        ("Hold '<color=orange>{0}</color>' to <color=orange>SLIDE</color>.", (m, m2, input) => T.tutorial.tutorial_slide1 + "<color=orange>" + input + "</color>" + T.tutorial.tutorial_slide2),
        ("Press '<color=#00DFFF>{0}</color>' to <color=#00DFFF>DASH</color> through danger.$Consumes <color=#00DFFF>STAMINA</color>. Can be performed in air.", (m, m2, input) => T.tutorial.tutorial_dash1 + "<color=#00DFFF>" + input + "</color>" + T.tutorial.tutorial_dash2 + "\n" + T.tutorial.tutorial_dash3),
        ("Deal close range damage to douse yourself in <color=red>FRESH BLOOD</color>. <color=red>THIS IS THE ONLY WAY TO REGAIN HEALTH</color>.", (m, m2, input) => T.tutorial.tutorial_health1 + "\n" + T.tutorial.tutorial_health2),
        ("<color=orange>JUMP</color> while near a <color=orange>WALL</color> to <color=orange>WALL JUMP</color>. (Max. 3 times)", (m, m2, input) => T.tutorial.tutorial_walljump),
        ("Press '<color=orange>{0}</color>' in the air to <color=orange>GROUND SLAM</color>.$Hold for <color=orange>SHOCKWAVE</color>.", (m, m2, input) => T.tutorial.tutorial_shockwave1 + "<color=orange>" + input + "</color>" + T.tutorial.tutorial_shockwave2 + "\n" + T.tutorial.tutorial_shockwave3),
        ("Most levels have secret <color=#00ffffff>SOUL ORBS</color>.$Touch them to get a <color=orange>POINT BONUS</color>.", (m, m2, input) => T.tutorial.tutorial_orb1 + "\n" + T.tutorial.tutorial_orb2),
    };

    private static readonly (string keyword, Func<string, string, string, string> build)[] DevMuseumMessages =
	{
		("A R M B O Y ! ! !", (m, m2, input) => LanguageManager.CurrentLanguage.act2.act2_heresyFirst_armboy),
	};

    /// <summary>
    /// These part of the messages can be found in the code
    /// There's a note shows which function contains it
    /// And CrateCounter was in a different class
    /// </summary>
    private static readonly (string keyword, Func<string, string, string, string> build)[] Messages =
    {
        // Press punch when not equip any arm
        // FistControl.Update()
        ("<color=red>CAN'T PUNCH IF YOU HAVE NO ARM EQUIPPED, DUMBASS</color>\nArms can be re-equipped at the shop", (m, m2, input) => "<color=red>" + T.misc.hud_noArm1 + "</color>\n" + T.misc.hud_noArm2),
        
        // When level's timer starts without tick DISABLE ASSIST Popup in Major Assists
        // StatsManager.StartTimer()
        // StatsManager.MajorUsed()
        ("<color=#4C99E6>MAJOR ASSISTS ARE ENABLED.</color>", (m, m2, input) => "<color=#4C99E6>" + T.misc.hud_majorAssists + "</color>"),
        
        // Red Orb
        // Bonus.OnTriggerEnter()
        ("<color=red>RED SOUL ORBS</color> give <color=green>200 HEALTH</color>. \nOverheal cannot be regained with blood.", (m, m2, input) => T.misc.hud_overhealOrb1 + "\n" + T.misc.hud_overhealOrb2),
        
        // Trying to whiplash the skull that opens the door and you are opposite side of the door
        // HookArm.ItemGrabError()
        ("<color=red>ERROR: BLOCKING DOOR WOULD CLOSE</color>", (m, m2, input) => "<color=red>" + T.misc.hud_itemGrabError + "</color>"),
        
        // LevelStatsEnabler.LevelStatsTutorial()
        ("Hold <color=orange>TAB</color> to see current stats when <color=orange>REPLAYING</color> a level.\n<color=orange>DOUBLE TAP</color> to keep open.", (m, m2, input) => T.misc.hud_levelStats1 + "\n" + T.misc.hud_levelStats2),
        
        // Out of bound
        // OutOfBounds.OnTriggerEnter()
        // TeleportPlayer.PerformTheTeleport()
        ("Whoops, sorry about that.", (m, m2, input) => T.misc.hud_outOfBounds),
        
        // 4-S's end
        // PlatformerDancer.DanceEnd()
        ("<color=orange>CLASH MODE</color> CHEAT UNLOCKED", (m, m2, input) => T.misc.hud_clashMode),
        
        // 7-S: <color=orange>DRONE HAUNTING</color> CHEAT UNLOCKED
        ("<color=orange>DRONE HAUNTING</color> CHEAT UNLOCKED", (m, m2, input) => T.misc.hud_droneHaunting),
        
        // First variant bought in shop
        // ShopZone.TurnOff()
        ("Cycle through <color=orange>EQUIPPED</color> variations with '<color=orange>{0}</color>'.", (m, m2, input) => T.misc.hud_weaponVariation),
        
        // Sandbox: when you editing a destoried object
        // Sandbox.SandboxAlterMenu.Update()
        ("<color=red>Altered object was destroyed.</color>", (m, m2, input) => "<color=red>" + T.misc.enemyAlter_alteredDestroyed + "</color>"),
        
        // P-1
        ("<color=red>WARNING:</color> INSUFFICIENT LIGHT. $<color=orange>RECOMMENDATION:</color> Return and take the torch.", (m, m2, input) => T.primeSanctum.primeSanctum_first_insufficientlight),
        
        // Start Cybergrind with no pattern selected
        // EndlessGrid.DisplayNoPatternWarning()
        ("NO PATTERNS SELECTED.", (m, m2, input) => T.cyberGrind.cybergrind_noPatternsSelected),
        
        // When entering the secret mission
        // But it should be in the scene, I put it here atm because i'm lazy
        ("You have found a <color=orange>SECRET MISSION</color>.", (m, m2, input) => T.misc.secretMissionFound),

        // 5-S
        // BaitItem.OnTriggerEnter()
        ("<color=red>This bait didn't work here!</color>", (m, m2, input) => T.fishing.fish_baitNotWork),
        ("A fish took the bait.", (m, m2, input) => T.fishing.fish_baitTaken),

        // FishCooker.OnTriggerEnter()
        ("Too small for this fish.\n:^(", (m, m2, input) => T.fishing.fish_tooSmall),
        ("Cooking failed.", (m, m2, input) => T.fishing.fish_cookingFailed),

        // FishingRodWeapon.Update()
        ("Fishing interrupted", (m, m2, input) => T.fishing.fish_interrupted),
        ("Nothing seems to be biting here...", (m, m2, input) => T.fishing.fish_noFishBiting),

        // DevMuseum
        // ChessManager.SetUpNewGame()
        ("Chess pieces can be moved with the <color=orange>mover arm</color>.", (m, m2, input) => LanguageManager.CurrentLanguage.devMuseum.museum_chessTip),

        // RaceRingTracker.Start()
        // Short reminder - this class adds HudMessage at runtime
        ("RACE START", (m, m2, input) => LanguageManager.CurrentLanguage.devMuseum.museum_rocketRaceStart),

        // RaceRingTracker.Victory()
		("TIME", (m, m2, input) => LanguageManager.CurrentLanguage.misc.levelstats_time + ": " + m.Split(':')[1]),

        // There's a SpreadGasoline.Enable() that shows a message
        // But I couldn't find the cheat in the game
    };

    public static string GetMessage(string message, string message2, string input)
    {
        // An empty message is deliberate (e.g. Level 4-4 repeats the previous
        // one) - don't route or warn about it.
        if (string.IsNullOrEmpty(message))
            return null;

        string currentSceneName = GetCurrentSceneName();
        if (input != null && input.Length > 0)
            input = InputNames.Localize(input);

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
            foreach (var (keyword, build) in DevMuseumMessages)
                if (message.Contains(keyword))
                    return build(message, message2, input);
        }

        // Every level (Prelude, Acts 1-3, Encores)
        string levelMessage = LevelStrings.GetMessage(message, message2, input);
        if (levelMessage != null)
            return levelMessage;

        foreach (var (keyword, build) in Messages)
            if (message.Contains(keyword))
                return build(message, message2, input);

        Logging.Warn("No translation for \"" + message + "\" in \"" + currentSceneName + "\"");
        return null;
    }
}
