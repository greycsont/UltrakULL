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
    private static readonly (string keyword, Func<string> build)[] TutorialMessages =
    {
        ("Press '<color=orange>{0}</color>' to <color=orange>PUNCH</color>.", () => T.tutorial.tutorial_punch1 + "<color=orange>{0}</color>" + T.tutorial.tutorial_punch2),
        ("Hold '<color=orange>{0}</color>' to <color=orange>SLIDE</color>.", () => T.tutorial.tutorial_slide1 + "<color=orange>{0}</color>" + T.tutorial.tutorial_slide2),
        ("Press '<color=#00DFFF>{0}</color>' to <color=#00DFFF>DASH</color> through danger.$Consumes <color=#00DFFF>STAMINA</color>. Can be performed in air.", () => T.tutorial.tutorial_dash1 + "<color=#00DFFF>{0}</color>" + T.tutorial.tutorial_dash2 + "\n" + T.tutorial.tutorial_dash3),
        ("Deal close range damage to douse yourself in <color=red>FRESH BLOOD</color>. <color=red>THIS IS THE ONLY WAY TO REGAIN HEALTH</color>.", () => T.tutorial.tutorial_health1 + "\n" + T.tutorial.tutorial_health2),
        ("<color=orange>JUMP</color> while near a <color=orange>WALL</color> to <color=orange>WALL JUMP</color>. (Max. 3 times)", () => T.tutorial.tutorial_walljump),
        ("Press '<color=orange>{0}</color>' in the air to <color=orange>GROUND SLAM</color>.$Hold for <color=orange>SHOCKWAVE</color>.", () => T.tutorial.tutorial_shockwave1 + "<color=orange>{0}</color>" + T.tutorial.tutorial_shockwave2 + "\n" + T.tutorial.tutorial_shockwave3),
        ("Most levels have secret <color=#00ffffff>SOUL ORBS</color>.$Touch them to get a <color=orange>POINT BONUS</color>.", () => T.tutorial.tutorial_orb1 + "\n" + T.tutorial.tutorial_orb2),
    };

    private static readonly (string keyword, Func<string> build)[] DevMuseumMessages =
	{
		("A R M B O Y ! ! !", () => LanguageManager.CurrentLanguage.act2.act2_heresyFirst_armboy),
	};

    /// <summary>
    /// These part of the messages can be found in the code
    /// There's a note shows which function contains it
    /// 
    /// The 4-S CrateCounter and DevMuseum.Victory() was in a different class
    /// </summary>
    private static readonly (string keyword, Func<string> build)[] Messages =
    {
        // Press punch when not equip any arm
        // FistControl.Update()
        ("<color=red>CAN'T PUNCH IF YOU HAVE NO ARM EQUIPPED, DUMBASS</color>\nArms can be re-equipped at the shop", () => "<color=red>" + T.misc.hud_noArm1 + "</color>\n" + T.misc.hud_noArm2),
        
        // When level's timer starts without tick DISABLE ASSIST Popup in Major Assists
        // StatsManager.StartTimer()
        // StatsManager.MajorUsed()
        ("<color=#4C99E6>MAJOR ASSISTS ARE ENABLED.</color>", () => "<color=#4C99E6>" + T.misc.hud_majorAssists + "</color>"),
        
        // Red Orb
        // Bonus.OnTriggerEnter()
        ("<color=red>RED SOUL ORBS</color> give <color=green>200 HEALTH</color>. \nOverheal cannot be regained with blood.", () => T.misc.hud_overhealOrb1 + "\n" + T.misc.hud_overhealOrb2),
        
        // Trying to whiplash the skull that opens the door and you are opposite side of the door
        // HookArm.ItemGrabError()
        ("<color=red>ERROR: BLOCKING DOOR WOULD CLOSE</color>", () => "<color=red>" + T.misc.hud_itemGrabError + "</color>"),
        
        // LevelStatsEnabler.LevelStatsTutorial()
        ("Hold <color=orange>TAB</color> to see current stats when <color=orange>REPLAYING</color> a level.\n<color=orange>DOUBLE TAP</color> to keep open.", () => T.misc.hud_levelStats1 + "\n" + T.misc.hud_levelStats2),
        
        // Out of bound
        // OutOfBounds.OnTriggerEnter()
        // TeleportPlayer.PerformTheTeleport()
        ("Whoops, sorry about that.", () => T.misc.hud_outOfBounds),
        
        // 4-S's end
        // PlatformerDancer.DanceEnd()
        ("<color=orange>CLASH MODE</color> CHEAT UNLOCKED", () => T.misc.hud_clashMode),
        
        // 7-S: <color=orange>DRONE HAUNTING</color> CHEAT UNLOCKED
        ("<color=orange>DRONE HAUNTING</color> CHEAT UNLOCKED", () => T.misc.hud_droneHaunting),
        
        // First variant bought in shop
        // ShopZone.TurnOff()
        ("Cycle through <color=orange>EQUIPPED</color> variations with '<color=orange>{0}</color>'.", () => T.misc.hud_weaponVariation),
        
        // Sandbox: when you editing a destoried object
        // Sandbox.SandboxAlterMenu.Update()
        ("<color=red>Altered object was destroyed.</color>", () => "<color=red>" + T.misc.enemyAlter_alteredDestroyed + "</color>"),
        
        // P-1
        ("<color=red>WARNING:</color> INSUFFICIENT LIGHT. $<color=orange>RECOMMENDATION:</color> Return and take the torch.", () => T.primeSanctum.primeSanctum_first_insufficientlight),
        
        // Start Cybergrind with no pattern selected
        // EndlessGrid.DisplayNoPatternWarning()
        ("NO PATTERNS SELECTED.", () => T.cyberGrind.cybergrind_noPatternsSelected),
        
        // When entering the secret mission
        // But it should be in the scene, I put it here atm because i'm lazy
        ("You have found a <color=orange>SECRET MISSION</color>.", () => T.misc.secretMissionFound),

        // 5-S
        // BaitItem.OnTriggerEnter()
        ("<color=red>This bait didn't work here!</color>", () => T.fishing.fish_baitNotWork),
        ("A fish took the bait.", () => T.fishing.fish_baitTaken),

        // FishCooker.OnTriggerEnter()
        ("Too small for this fish.\n:^(", () => T.fishing.fish_tooSmall),
        ("Cooking failed.", () => T.fishing.fish_cookingFailed),

        // FishingRodWeapon.Update()
        ("Fishing interrupted", () => T.fishing.fish_interrupted),
        ("Nothing seems to be biting here...", () => T.fishing.fish_noFishBiting),

        // DevMuseum
        // ChessManager.SetUpNewGame()
        ("Chess pieces can be moved with the <color=orange>mover arm</color>.", () => LanguageManager.CurrentLanguage.devMuseum.museum_chessTip),

        // RaceRingTracker.Start()
        // Short reminder - this class adds HudMessage at runtime
        ("RACE START", () => LanguageManager.CurrentLanguage.devMuseum.museum_rocketRaceStart),

        // There's a SpreadGasoline.Enable() that shows a message
        // But I couldn't find the cheat in the game
    };

    public static string GetMessage(string message)
    {
        // An empty message is deliberate (e.g. Level 4-4 repeats the previous
        // one) - don't route or warn about it.
        if (string.IsNullOrEmpty(message))
            return null;

        string currentSceneName = GetCurrentSceneName();

        // Tutorial
        if (currentSceneName.Contains("Tutorial"))
        {
            foreach (var (keyword, build) in TutorialMessages)
                if (message.Equals(keyword))
                    return build();
        }

        // DevMuseum.
        if (currentSceneName.Contains("CreditsMuseum2"))
        {
            foreach (var (keyword, build) in DevMuseumMessages)
                if (message.Equals(keyword))
                    return build();
        }

        // Every level (Prelude, Acts 1-3, Encores)
        string levelMessage = LevelStrings.GetMessage(message);
        if (levelMessage != null)
            return levelMessage;

        foreach (var (keyword, build) in Messages)
            if (message.Equals(keyword))
                return build();

        Logging.Warn("No translation for \"" + message + "\" in \"" + currentSceneName + "\"");
        return null;
    }
}
