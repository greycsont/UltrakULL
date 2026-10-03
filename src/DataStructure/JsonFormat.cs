using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace UltrakULL.json;

public class JsonFormat
{
    public Metadata metadata;
    public Body body;

    public FrontEnd frontend;
    public Tutorial tutorial;
    public Rank ranks;

    public Overture prelude;
    public a1 act1;
    public a2 act2;
    public a3 act3;
    public Enc encore;
    public CG cyberGrind;
    public Prime primeSanctum;
    public Secret secretLevels;
    public IntermissionStrings intermission;
    public Museum devMuseum;
    public FishingStrings fishing;
    public WashingStrings washing;

    public PauseMenu pauseMenu;
    public Option options;

    public Levels levelNames;
    public Challenges levelChallenges;
    public EnemyNames enemyNames;
    public EnemyBioStrings enemyBios;
    public ShopStrings shop;
    public LevelTips levelTips;

    public Book books;
    public VisualNovel visualnovel;
    public Subtitles subtitles;

    public Style style;
    public CheatStrings cheats;
    public Misc misc;
    public InputStrings inputStrings;
    public Weapon weapon;

    public SandboxStrings sandbox;
}

public class FishingStrings
{
    [DefaultValue("The Ocean")]
    public string fish_ocean;
    [DefaultValue("Cave Pool")]
    public string fish_cavePool;
    [DefaultValue("Stream")]
    public string fish_stream;
    [DefaultValue("Lake Waters")]
    public string fish_lake;
    [DefaultValue("Lower Bloods")]
    public string fish_lakeBloodLower;
    [DefaultValue("Holy Lake")]
    public string fish_lakeHoly;
    [DefaultValue("Deeper Lake Waters")]
    public string fish_lakeDeep;
    [DefaultValue("Lake Of Blood")]
    public string fish_lakeBlood;
    [DefaultValue("Water Well")]
    public string fish_waterWell;
    [DefaultValue("Pan Oil")]
    public string fish_panOil;

    [DefaultValue("FISH SIZE LEADERBOARD")]
    public string fish_leaderboard;

    [DefaultValue("If you can read this, please help. I've been stranded on an island off the shore for weeks now, and I'm running out of supplies.")]
    public string fish_bottleMessage1;
    [DefaultValue("I was drawn to ride the waves in hopes of finding the legendary size 2 fish. I had combed every inch of land and lake with no avail.")]
    public string fish_bottleMessage2;
    [DefaultValue("I deduced that they must exist far out at sea, so I set sail with a month's worth of cooked fish, but the waves sank my ship before I could find anything.")]
    public string fish_bottleMessage3;
    [DefaultValue("You're my last hope.")]
    public string fish_bottleMessage4;
    [DefaultValue("Set sail towards the big dipper, you will find me on an island there. Bring me more fish and then leave so I may continue my search.")]
    public string fish_bottleMessage5;
    [DefaultValue("THE SIZE 2 FISH IS MINE.")]
    public string fish_bottleMessage6;

    [DefaultValue("DAY 529:")]
    public string fish_book1;
    [DefaultValue("STILL SEARCHING.")]
    public string fish_book2;
    [DefaultValue("NO CONTACT FROM THE AGENCY IN 216 DAYS.")]
    public string fish_book3;
    [DefaultValue("I SHOULD RETURN TO HQ BUT I CAN'T. NOT YET.")]
    public string fish_book4;
    [DefaultValue("IT'S THERE.")]
    public string fish_book5;
    [DefaultValue("SOMEWHERE.")]
    public string fish_book6;
    [DefaultValue("I HAVE TO SEE.")]
    public string fish_book7;
    [DefaultValue("I HAVE TO KNOW.")]
    public string fish_book8;
    [DefaultValue("IHAVETOSEEIHAVETOKNOW")]
    public string fish_book9;
    [DefaultValue("SIZE 2.")]
    public string fish_book10;
    public string fish_book11;

    [DefaultValue("far")]
    public string fish_rodFar;
    [DefaultValue("close")]
    public string fish_rodClose;
    [DefaultValue("Hooked!")]
    public string fish_rodHooked;
    [DefaultValue("out of water")]
    public string fish_outOfWater;
    [DefaultValue("You caught")]
    public string fish_fishCaught;
    [DefaultValue("Cooking failed.")]
    public string fish_cookingFailed;
    [DefaultValue("SIZE 1")]
    public string fish_size;

    [DefaultValue("\"It's a living.\"")]
    public string fish_living;
    [DefaultValue("Too small for this fish.\n:^(")]
    public string fish_tooSmall;
    [DefaultValue("<color=red>This bait didn't work here!</color>")]
    public string fish_baitNotWork;
    [DefaultValue("A fish took the bait.")]
    public string fish_baitTaken;
    [DefaultValue("Fishing interrupted")]
    public string fish_interrupted;
    [DefaultValue("Nothing seems to be biting here...")]
    public string fish_noFishBiting;

    [DefaultValue("awesome fishing tips")]
    public string fish_terminalTitle;
    [DefaultValue("Funny Stupid Fish (Friend)")]
    public string fish_funnyStupidFish;
    [DefaultValue("PITR Fish")]
    public string fish_pitrFish;
    [DefaultValue("Trout")]
    public string fish_trout;
    [DefaultValue("Metal Fish")]
    public string fish_amidEvilFish;
    [DefaultValue("Chomper")]
    public string fish_chomper;
    [DefaultValue("Bomb Fish")]
    public string fish_bombFish;
    [DefaultValue("Eyeball")]
    public string fish_gibeye;
    [DefaultValue("Frog (?)")]
    public string fish_ironLungFish;
    [DefaultValue("Dope Fish")]
    public string fish_dopeFish;
    [DefaultValue("Stickfish")]
    public string fish_stickFish;
    [DefaultValue("Cooked Fish")]
    public string fish_cookedFish;
    [DefaultValue("Shark")]
    public string fish_shark;

    [DefaultValue("A stupid fish. A really stupid fish. A dumb cretin. A fool. An absolute buffoon. A bumbling idiot. Has a sense of humor.")]
    public string fish_funnyStupidFishDescription1;
    [DefaultValue("Easy to catch and very friendly, is usually used to teach novices and children how to fish.")]
    public string fish_funnyStupidFishDescription2;
    [DefaultValue("A very smart fish. Loves cats. Swims near land and will often gets caught by fishers on purpose just to be nice. ")]
    public string fish_pitrFishDescription1;
    [DefaultValue("Always ends up at the bottom of fish hierarchies.")]
    public string fish_pitrFishDescription2;
    [DefaultValue("A common lake fish. Prefers deep water.")]
    public string fish_troutDescription1;
    [DefaultValue("Seems to have been held in high regard by humans, as there are known mask replicas of them.")]
    public string fish_troutDescription2;
    [DefaultValue("A migratory fish from a land far beyond. Only survives in rocky areas, as its diet consists entirely of rocks. ")]
    public string fish_amidEvilFishDescription1;
    [DefaultValue("Only comes out of hiding to feed.")]
    public string fish_amidEvilFishDescription2;
    [DefaultValue("A migratory fish.")]
    public string fish_chomperDescription1;
    [DefaultValue("Originates from Pennsylvania, so it prefers dark, unpleasant and damp places.")]
    public string fish_chomperDescription2;
    [DefaultValue("An extreme kind of fish. Most often found in flowing water, as stillness would be boring and inadequate for stimulation.")]
    public string fish_bombFishDescription1;
    [DefaultValue("Has a self-defence mechanism that can cause bodily injury to unaware fishers.")]
    public string fish_bombFishDescription2;
    [DefaultValue("A common fish. Requires blood to survive.")]
    public string fish_gibeyeDescription1;
    [DefaultValue("Improves eyesight.")]
    public string fish_gibeyeDescription2;
    [DefaultValue("A migratory deep sea fish. Usually only found on moons, though it can survive anywhere with enough blood.")]
    public string fish_ironLungFishDescription1;
    [DefaultValue("Very territorial, attacking anything that enters its domain and never leaves the deep.")]
    public string fish_ironLungFishDescription2;
    [DefaultValue("A migratory fish. Found everywhere, though usually hidden Well.")]
    public string fish_dopeFishDescription1;
    [DefaultValue("Often found accidentally by heroes and travellers across their journeys and is considered a sign of good luck.")]
    public string fish_dopeFishDescription2;
    [DefaultValue("A common fish. Edible and usually farmed by humans.")]
    public string fish_stickFishDescription1;
    [DefaultValue("Can be found in kitchens all across the world.")]
    public string fish_stickFishDescription2;
    [DefaultValue("A common fish. Lives in fire, eats other fish and only comes out when fed.")]
    public string fish_cookedFishDescription1;
    [DefaultValue("Considered a delicacy, so fishers will often catch other kinds of fish purely for the sake of feeding them to an open fire to coax it out.")]
    public string fish_cookedFishDescription2;
    [DefaultValue("A carnivorous fish. Originates from Sweden, and has been considered a status symbol in human society, possibly as a sign of femininity or \"those who receive\", though the details have been lost to time.")]
    public string fish_sharkDescription1;
    [DefaultValue("Lives in huge bodies of water and avoids land, though it may swim close to shore to feed.")]
    public string fish_sharkDescription2;

}
public class WashingStrings
{
    [DefaultValue("CLEAN UP YOUR MESS!")]
    public string wash_fakeexittext1;
    [DefaultValue("The washer and vacuum go in weapon slot 6.")]
    public string wash_fakeexittext2;
    [DefaultValue("Both tools have alternate fire modes.")]
    public string wash_fakeexittext3;
    [DefaultValue("Litter too big to be vacuumed needs to be manually thrown away.")]
    public string wash_fakeexittext4;
    [DefaultValue("Some corpses cannot be moved and need to be crushed.")]
    public string wash_fakeexittext5;
    [DefaultValue("The door will open when it's <color=#7F0000>ALL</color> clean.")]
    public string wash_fakeexittext6;

    [DefaultValue("THANK YOU.")]
    public string wash_exitOpenText1;
    [DefaultValue("The exit is now open.")]
    public string wash_exitOpenText2;
    [DefaultValue("Have a   <color=#7F0000>G O O D</color>   day.")]
    public string wash_exitOpenText3;

    [DefaultValue("CLEAN")]
    public string wash_Clean;
    [DefaultValue("To Do:")]
    public string wash_ToDo;
    [DefaultValue("Clean:")]
    public string wash_bloodClean;

    [DefaultValue("Courtyard")]
    public string wash_roomCourtyard;
    [DefaultValue("Library")]
    public string wash_roomLibrary;
    [DefaultValue("Lobby")]
    public string wash_roomLobby;
    [DefaultValue("Lounge")]
    public string wash_roomLounge;
    [DefaultValue("Side Room")]
    public string wash_roomSideroom;

    [DefaultValue("Litter Count:")]
    public string wash_littercount;
    [DefaultValue("Dumpster")]
    public string wash_Dumpster;
    [DefaultValue("Ground")]
    public string wash_Ground;
    [DefaultValue("Pillars")]
    public string wash_Pillars;
    [DefaultValue("Walls")]
    public string wash_Walls;
    [DefaultValue("Back Bookshelf")]
    public string wash_BackBookshelf;
    [DefaultValue("Ceiling")]
    public string wash_Ceiling;
    [DefaultValue("Bookshelf")]
    public string wash_Bookshelf;
    [DefaultValue("Bookcases")]
    public string wash_Bookcases;
    [DefaultValue("Desk")]
    public string wash_Desk;
    [DefaultValue("Front Bookshelf")]
    public string wash_FrontBookshelf;
    [DefaultValue("Sconces")]
    public string wash_Sconces;
    [DefaultValue("Side Wall")]
    public string wash_Sidewall;
    [DefaultValue("Walkway")]
    public string wash_Walkway;
    [DefaultValue("Window Wall")]
    public string wash_WindowWall;
    [DefaultValue("Decor")]
    public string wash_Decor;
    [DefaultValue("Floors")]
    public string wash_Floors;
    [DefaultValue("Pond")]
    public string wash_Pond;
}
public class CG
{
    [Obsolete]
    public string cybergrind_currentWave;
    [DefaultValue("ENEMIES REMAINING")]
    public string cybergrind_enemiesRemaining;

    [DefaultValue("WAVE")]
    public string cybergrind_wave;
    [DefaultValue("KILLS")]
    public string cybergrind_kills;
    [DefaultValue("STYLE")]
    public string cybergrind_style;
    [DefaultValue("TIME")]
    public string cybergrind_time;

    [DefaultValue("THE CYBER GRIND")]
    public string cybergrind_cgTitle;
    [DefaultValue("NEW")]
    public string cybergrind_previousRun;
    [DefaultValue("BEST")]
    public string cybergrind_bestRun;

    [DefaultValue("TOTAL")]
    public string cybergrind_total;

    [DefaultValue("CONNECTING TO STEAMWORKS")]
    public string cybergrind_connectingToSteam;

    [DefaultValue("SCORES (FRIENDS)")]
    public string cybergrind_friendScores;
    [DefaultValue("SCORES (GLOBAL)")]
    public string cybergrind_globalScores;

    [DefaultValue("Cyber Grind Settings")]
    public string cybergrind_settings;
    [DefaultValue("This terminal is used for Cyber Grind customization.")]
    public string cybergrind_settingsDescription;
    [DefaultValue("Themes")]
    public string cybergrind_themes;
    [DefaultValue("Music")]
    public string cybergrind_music;
    [DefaultValue("Patterns")]
    public string cybergrind_patterns;
    [DefaultValue("Waves")]
    public string cybergrind_waves;

    [DefaultValue("Themes")]
    public string cybergrind_themesTitle;
    [DefaultValue("Select the visual theme for the arena")]
    public string cybergrind_themesDescription;
    [DefaultValue("Light")]
    public string cybergrind_themesLight;
    [DefaultValue("Dark")]
    public string cybergrind_themesDark;
    [DefaultValue("Custom")]
    public string cybergrind_themesCustom;
    [DefaultValue("Custom")]
    public string cybergrind_themesModify;

    [DefaultValue("Grid")]
    public string cybergrind_themesCustomGrid;
    [DefaultValue("Glow")]
    public string cybergrind_themesCustomGridGlow;
    [DefaultValue("Skybox")]
    public string cybergrind_themesCustomSkybox;
    [DefaultValue("Back")]
    public string cybergrind_themesCustomBack;
    [DefaultValue("Refresh")]
    public string cybergrind_themesCustomReload;
    [DefaultValue("Base")]
    public string cybergrind_themesCustomBase;
    [DefaultValue("Top Row")]
    public string cybergrind_themesCustomTopRow;
    [DefaultValue("Top")]
    public string cybergrind_themesCustomTop;
    [DefaultValue("Glow Intensity")]
    public string cybergrind_themesCustomGlowIntensity;

    [DefaultValue("Fog")]
    public string cybergrind_themesCustomFog;
    [DefaultValue("Fog Color")]
    public string cybergrind_themesCustomFogColor;
    [DefaultValue("Disabled")]
    public string cybergrind_themesCustomFogDisable;
    [DefaultValue("Static")]
    public string cybergrind_themesCustomFogStatic;
    [DefaultValue("Dynamic")]
    public string cybergrind_themesCustomFogDynamic;
    [DefaultValue("Fog is disabled.")]
    public string cybergrind_themesCustomFogDisableDesc;
    [DefaultValue("Fog Start Distance")]
    public string cybergrind_themesCustomFogStart;
    [DefaultValue("Fog End Distance")]
    public string cybergrind_themesCustomFogEnd;
    [DefaultValue("Set to default")]
    public string cybergrind_themesCustomFogDefault;
    //public string cybergrind_themesCustomFogDynamicEnable;
    //public string cybergrind_themesCustomFogDynamicDisable;

    [DefaultValue("Playlist")]
    public string cybergrind_musicTitle;
    [DefaultValue("Select Music Type")]
    public string cybergrind_musicType;
    [DefaultValue("COMPLETE CHALLENGE FOR")]
    public string cybergrind_musicCompleteChallengeRequirement;
    [DefaultValue("ENCOUNTER AN UNKNOWN FOE")]
    public string cybergrind_musicSeeEnemyRequirement;
    [DefaultValue("REACH")]
    public string cybergrind_musicUnlockLevelRequirement;
    [DefaultValue("COMPLETE")]
    public string cybergrind_musicCompleteLevelRequirement;
    [DefaultValue("Unlocked")]
    public string cybergrind_musicUnlocked;
    [DefaultValue("CONFIRM")]
    public string cybergrind_musicConfirm;
    [DefaultValue("Soundtrack")]
    public string cybergrind_musicSoundtrack;

    [DefaultValue("The Cyber Grind")]
    public string cybergrind_musicFolderNameCyberGrind;
    [DefaultValue("Prelude")]
    public string cybergrind_musicFolderNamePrelude;
    [DefaultValue("Act 1")]
    public string cybergrind_musicFolderNameAct1;
    [DefaultValue("Act 2")]
    public string cybergrind_musicFolderNameAct2;
    [DefaultValue("Act 3")]
    public string cybergrind_musicFolderNameAct3;
    [DefaultValue("Secret Levels")]
    public string cybergrind_musicFolderNameSecret;
    [DefaultValue("Prime Sanctums")]
    public string cybergrind_musicFolderNamePrime;
    [DefaultValue("Miscellaneous Tracks")]
    public string cybergrind_musicFolderNameMisc;
    [DefaultValue("Encores")]
    public string cybergrind_musicFolderNameEncores;

    [DefaultValue("WARNING: HIGH SCORE WILL NOT BE SAVED WHEN USING CUSTOM PATTERNS")]
    public string cybergrind_patternsWarning;
    [DefaultValue("Patterns")]
    public string cybergrind_patternsTitle;
    [DefaultValue("Refresh")]
    public string cybergrind_patternsRefresh;
    [DefaultValue("Pattern Editor")]
    public string cybergrind_patternsLaunchExternalEditor;
    [DefaultValue("Enable")]
    public string cybergrind_patternsSwitchButton;
    [DefaultValue("Disable")]
    public string cybergrind_patternsSwitchButtonNot;

    [DefaultValue("Waves")]
    public string cybergrind_wavesTitle;
    [DefaultValue("Select Starting Wave")]
    public string cybergrind_wavesDescription1;
    [DefaultValue("(Highest wave must be at least twice as high)")]
    public string cybergrind_wavesDescription2;

    [DefaultValue("NO PATTERNS SELECTED.")]
    public string cybergrind_noPatternsSelected;
}

public class CheatStrings
{
    [DefaultValue("Enabling cheats means you will not gain a rank upon completion of a level and a Cyber Grind high score will not be saved.")]
    public string cheats_disclaimer1;
    [DefaultValue("<color=green>Press</color> ~ <color=green>or</color> home<color=green> after enabling cheats to toggle the menu")]
    public string cheats_disclaimer2;
    [DefaultValue("ACTIVATE CHEATS")]
    public string cheats_disclaimerYes;
    [DefaultValue("CANCEL")]
    public string cheats_disclaimerNo;

    [DefaultValue("MANAGE CHEATS")]
    public string cheats_panelTitle;

    [DefaultValue("<color=#44FF45>CHEATS</color> ENABLED :^)")]
    public string cheats_cheatsEnabled;
    [DefaultValue("home or ~")]
    public string cheats_cheatsOpenButtons;

    [DefaultValue("Keep Cheats Enabled")]
    public string cheats_keepEnabled;
    [DefaultValue("Spawner Arm")]
    public string cheats_spawnerArm;
    [DefaultValue("Teleport Menu")]
    public string cheats_teleportMenu;
    [DefaultValue("TELEPORT")]
    public string cheats_teleport;
    [DefaultValue("Fullbright")]
    public string cheats_fullBright;
    [DefaultValue("Invincibility")]
    public string cheats_invincibility;
    [DefaultValue("Noclip")]
    public string cheats_noclip;
    [DefaultValue("Flight")]
    public string cheats_flight;
    [DefaultValue("Infinite Wall Jump")]
    public string cheats_infiniteWallJumps;
    [DefaultValue("No Weapon Cooldown")]
    public string cheats_noWeaponCooldown;
    [DefaultValue("Infinite Power-Ups")]
    public string cheats_infinitePowerUps;
    [DefaultValue("Blind Enemies")]
    public string cheats_blindEnemies;
    [DefaultValue("Enemies Attack Each Other")]
    public string cheats_enemiesHateEnemies;
    [DefaultValue("Enemies Ignore Player")]
    public string cheats_enemiesIgnorePlayer;
    [DefaultValue("Disable Enemy Spawns")]
    public string cheats_disableEnemySpawns;
    [DefaultValue("Invincible Enemies")]
    public string cheats_invincibleEnemies;
    [DefaultValue("Kill All Enemies")]
    public string cheats_killAllEnemies;
    [DefaultValue("Quick Save")]
    public string cheats_quickSave;
    [DefaultValue("Quick Load")]
    public string cheats_quickLoad;
    [DefaultValue("Manage Saves")]
    public string cheats_saveMenu;
    [DefaultValue("Clear Map")]
    public string cheats_clearMap;
    [DefaultValue("CLEAR")]
    public string cheats_clear;
    [DefaultValue("Enemy Navigation")]
    public string cheats_rebuildNav;
    [DefaultValue("Snapping")]
    public string cheats_snapping;
    [DefaultValue("Spawn With Physics")]
    public string cheats_physics;
    [DefaultValue("Clash Mode")]
    public string cheats_crashMode;
    [DefaultValue("Hide Weapons")]
    public string cheats_hideWeapons;
    [DefaultValue("Hide UI")]
    public string cheats_hideUi;
    [DefaultValue("Drone Haunting")]
    public string cheats_ghostDroneMode;

    [DefaultValue("STAY ACTIVE")]
    public string cheats_stayActive;
    [DefaultValue("DISABLE ON RELOAD")]
    public string cheats_disableOnReload;
    [DefaultValue("EQUIP")]
    public string cheats_equip;
    [DefaultValue("REMOVE")]
    public string cheats_remove;
    [DefaultValue("LOAD LATEST SAVE")]
    public string cheats_loadLatestSave;
    [DefaultValue("OPEN")]
    public string cheats_open;
    [DefaultValue("Kill All")]
    public string cheats_killAll;
    [DefaultValue("STATIC")]
    public string cheats_static;
    [DefaultValue("DYNAMIC")]
    public string cheats_dynamic;
    [DefaultValue("REBUILD")]
    public string cheats_rebuild;
    [DefaultValue("REBUILDING...")]
    public string cheats_rebuilding;

    [DefaultValue("ENABLED")]
    public string cheats_activated;
    [DefaultValue("DISABLED")]
    public string cheats_deactivated;

    [DefaultValue("Press to Bind")]
    public string cheats_pressToBind;
    [DefaultValue("RESET BIND")]
    public string cheats_delete;
    [DefaultValue("Press any Key")]
    public string cheats_pressAnyKey;

    [DefaultValue("NAVMESH OUT OF DATE")]
    public string cheats_navmeshOutdated1;
    [DefaultValue("(Rebuild navigation in cheats menu)")]
    public string cheats_navmeshOutdated2;

    [DefaultValue("Spawner Arm in slot 6")]
    public string cheats_spawnerArmSlot;

    [DefaultValue("SANDBOX SAVES")]
    public string cheats_dupesTitle;
    [DefaultValue("Give it a name :)")]
    public string cheats_dupesSaveNamePrompt;
    [DefaultValue("NEW SAVE")]
    public string cheats_dupesNewSave;
    [DefaultValue("OPEN DIRECTORY")]
    public string cheats_dupesOpenFolder;
    [DefaultValue("Are you sure you want to \n<color=orange>OVERWRITE</color> your sandbox save?")]
    public string cheats_dupesOverWriteWarn;
    [DefaultValue("DELETE")]
    public string cheats_dupesDelete;
    [DefaultValue("SAVE")]
    public string cheats_dupesSave;
    [DefaultValue("LOAD")]
    public string cheats_dupesLoad;

    [DefaultValue("META")]
    public string cheats_categoryMeta;
    [DefaultValue("SANDBOX")]
    public string cheats_categorySandbox;
    [DefaultValue("GENERAL")]
    public string cheats_categoryGeneral;
    [DefaultValue("MOVEMENT")]
    public string cheats_categoryMovement;
    [DefaultValue("WEAPONS")]
    public string cheats_categoryWeapons;
    [DefaultValue("ENEMIES")]
    public string cheats_categoryEnemies;
    [DefaultValue("ITEMS")]
    public string cheats_categoryItems;
    [DefaultValue("VISUAL")]
    public string cheats_categoryVisual;
    [DefaultValue("SPECIAL")]
    public string cheats_categorySpecial;

}


public class Style
{
    [DefaultValue("AIRSLAM")]
    public string style_airslam;
    [DefaultValue("AIRSHOT")]
    public string style_airshot;
    [DefaultValue("ATTRAPTOR")]
    public string style_attraptor;
    [DefaultValue("ARSENAL")]
    public string style_arsenal;
    [DefaultValue("BIG HEADSHOT")]
    public string style_bigheadshot;
    [DefaultValue("BIG KILL")]
    public string style_bigkill;
    [DefaultValue("BIG FISTKILL")]
    public string style_bigfistkill;
    [DefaultValue("BIPOLAR")]
    public string style_bipolar;

    [DefaultValue("CANNONBALLED")]
    public string style_cannonballed;
    [DefaultValue("DUNKED")]
    public string style_cannonballedfrombounce;
    [DefaultValue("CANNONBOOST")]
    public string style_cannonboost;
    [DefaultValue("CATAPULTED")]
    public string style_catapulted;
    [DefaultValue("CHARGEBACK")]
    public string style_chargeback;
    [DefaultValue("COMPRESSED")]
    public string style_compressed;
    [DefaultValue("CRITICAL PUNCH")]
    public string style_criticalpunch;
    [DefaultValue("DISRESPECT")]
    public string style_disrespect;
    [DefaultValue("DOUBLE KILL")]
    public string style_doublekill;
    [DefaultValue("DOWN TO SIZE")]
    public string style_downtosize;
    [DefaultValue("CORKSCREW BLOW")]
    public string style_drillpunch;
    [DefaultValue("GIGA DRILL BREAK")]
    public string style_drillpunchkill;
    [DefaultValue("ENRAGED")]
    public string style_enraged;
    [DefaultValue("ENVIROKILL")]
    public string style_envirokill;
    [DefaultValue("EXPLODED")]
    public string style_exploded;
    [DefaultValue("FINISHED OFF")]
    public string style_finishedoff;
    [DefaultValue("FIREWORKS")]
    public string style_fireworks;
    [DefaultValue("JUGGLE")]
    public string style_fireworksweak;
    [DefaultValue("FISTFUL OF DOLLAR")]
    public string style_fistfulofdollar;
    [DefaultValue("FRIED")]
    public string style_fried;
    [DefaultValue("FRIENDLY FIRE")]
    public string style_friendlyfire;
    [DefaultValue("GUARD BREAK")]
    public string style_guardbreak;
    [DefaultValue("GROUND SLAM")]
    public string style_groundslam;
    [DefaultValue("HALF OFF")]
    public string style_halfoff;
    [DefaultValue("BLUNT FORCE")]
    public string style_hammerHitGreen;
    [DefaultValue("BLASTING AWAY")]
    public string style_hammerHitHeavy;
    [DefaultValue("FULL IMPACT")]
    public string style_hammerHitRed;
    [DefaultValue("HEAVY HITTER")]
    public string style_hammerHitYellow;
    [DefaultValue("HEADSHOT")]
    public string style_headshot;
    [DefaultValue("HEADSHOT COMBO")]
    public string style_headshotcombo;
    [DefaultValue("HEAVY LIGHT")]
    public string style_heavylight;
    [DefaultValue("HOMERUN")]
    public string style_homerun;
    [DefaultValue("ICONOCLASM")]
    public string style_iconoclasm;
    [DefaultValue("INSTAKILL")]
    public string style_instakill;
    [DefaultValue("TIME OUT")]
    public string style_insurrknockdown;
    [DefaultValue("INTERRUPTION")]
    public string style_interruption;
    [DefaultValue("KILL")]
    public string style_kill;
    [DefaultValue("LANDYOURS")]
    public string style_landyours;
    [DefaultValue("RIDE THE LIGHTNING")]
    public string style_lightningbolt;
    [DefaultValue("LIMBSHOT")]
    public string style_limbshot;
    [DefaultValue("MAURICED")]
    public string style_mauriced;
    [DefaultValue("MULTIKILL")]
    public string style_multikill;
    [DefaultValue("NAILBOMBED")]
    public string style_nailbombed;
    [DefaultValue("OVERKILL")]
    public string style_overkill;
    [DefaultValue("OSHA VIOLATION")]
    public string style_oshaviolation;
    [DefaultValue("PARRY")]
    public string style_parry;
    [DefaultValue("PROJECTILE BOOST")]
    public string style_projectileboost;
    [DefaultValue("QUICKDRAW")]
    public string style_quickdraw;
    [DefaultValue("RICOSHOT")]
    public string style_ricoshot;
    [DefaultValue("ULTRA")]
    public string style_ricoshotUltra;
    [DefaultValue("COUNTER")]
    public string style_ricoshotCounter;
    [DefaultValue("ROCKET RETURN")]
    public string style_rocketreturn;
    [DefaultValue("ROUND TRIP")]
    public string style_roundtrip;
    [DefaultValue("TERMINAL VELOCITY")]
    public string style_terminalvelocity;
    [DefaultValue("HEARTBREAK")]
    public string style_heartbreak;
    [DefaultValue("SCRINDONGULODED")]
    public string style_scrindonguloded;
    [DefaultValue("SCRONGLED")]
    public string style_scrongled;
    [DefaultValue("SCRONGBONGLED")]
    public string style_scrongbongled;
    [DefaultValue("SECRET")]
    public string style_secret;
    [DefaultValue("SERVED")]
    public string style_served;
    [DefaultValue("STRIKE!")]
    public string style_strike;
    [DefaultValue("SPLATTERED")]
    public string style_splattered;
    [DefaultValue("TRIPLE KILL")]
    public string style_triplekill;

    [DefaultValue("why are you even spawning enemies here")]
    public string style_why;

    [DefaultValue("BOILED")]
    public string style_boiled;
    [DefaultValue("CONDUCTOR")]
    public string style_conductor;
    [DefaultValue("CRUSHED")]
    public string style_crushed;
    [DefaultValue("FALL")]
    public string style_fall;
    [DefaultValue("FOR THEE")]
    public string style_forthee;
    [DefaultValue("GROOVY")]
    public string style_groovy;
    [DefaultValue("LONG WAY DOWN")]
    public string style_longwaydown;
    [DefaultValue("LOST")]
    public string style_lost;
    [DefaultValue("M.A.D.")]
    public string style_m_a_d;
    [DefaultValue("MINCED")]
    public string style_minced;
    [DefaultValue("PANCAKED")]
    public string style_pancaked;
    [DefaultValue("NO-NO")]
    public string style_nono;
    [DefaultValue("OUT OF BOUNDS")]
    public string style_outofbounds;
    [DefaultValue("RE-NO-NO")]
    public string style_renono;
    [DefaultValue("ROADKILL")]
    public string style_roadkill;
    [DefaultValue("SCREWED")]
    public string style_screwed;
    [DefaultValue("SHREDDED")]
    public string style_shredded;
    [DefaultValue("SLIPPED")]
    public string style_slipped;
    [DefaultValue("TRAMPLED")]
    public string style_trampled;
    [DefaultValue("TRASHED")]
    public string style_trashed;
    [DefaultValue("UNCHAINEDSAW")]
    public string style_unchainedsaw;
    [DefaultValue("ZAPPED")]
    public string style_zapped;

    [DefaultValue("BISHOP CAPTURE")]
    public string style_bishopcapture;
    [DefaultValue("BISHOP PROMOTION")]
    public string style_bishoppromo;
    [DefaultValue("BLACK WINS")]
    public string style_blackwins;
    [DefaultValue("BONGCLOUD")]
    public string style_bongcloud;
    [DefaultValue("CASTLED")]
    public string style_castled;
    [DefaultValue("EN PASSANT")]
    public string style_enpassant;
    [DefaultValue("FOOLS MATE")]
    public string style_foolsmate;
    [DefaultValue("KNIGHT CAPTURE")]
    public string style_knightcapture;
    [DefaultValue("KNIGHT PROMOTION")]
    public string style_knightpromo;
    [DefaultValue("PAWN CAPTURE")]
    public string style_pawncapture;
    [DefaultValue("QUEEN CAPTURE")]
    public string style_queencapture;
    [DefaultValue("QUEEN PROMOTION")]
    public string style_queenpromo;
    [DefaultValue("ROOK CAPTURE")]
    public string style_rookcapture;
    [DefaultValue("ROOK PROMOTION")]
    public string style_rookpromo;
    [DefaultValue("STOP HITTING YOURSELF")]
    public string style_stophitting;
    [DefaultValue("ULTRAVICTORY")]
    public string style_ultravictory;
    [DefaultValue("WHITE WINS")]
    public string style_whitewins;
    [DefaultValue("LOST IN SPACE")]
    public string style_lostinspace;
    [DefaultValue("STARSTRUCK")]
    public string style_starstruck;
    [DefaultValue("GONE SWIMMING")]
    public string style_goneswimming;
    [DefaultValue("STOMPED")]
    public string style_stomped;
    [DefaultValue("RAISON D'ETRE")]
    public string style_raIsondetre;

    [DefaultValue("Destructive")]
    public string style_d;
    [DefaultValue("Chaotic")]
    public string style_c;
    [DefaultValue("Brutal")]
    public string style_b;
    [DefaultValue("Anarchic")]
    public string style_a;
    [DefaultValue("Supreme")]
    public string style_s;
    [DefaultValue("SSadistic")]
    public string style_ss;
    [DefaultValue("SSShitstorm")]
    public string style_sss;
    [DefaultValue("ULTRAKILL")]
    public string style_ultrakill;

    [DefaultValue("FRESH")]
    public string style_weaponFresh;
    [DefaultValue("USED")]
    public string style_weaponUsed;
    [DefaultValue("STALE")]
    public string style_weaponStale;
    [DefaultValue("DULL")]
    public string style_weaponDull;

    [DefaultValue("MULTIPLIER")]
    public string stylemeter_multiplier;
}


public class EnemyBioStrings
{
    [DefaultValue("TYPE: ")]
    public string enemyBios_type;
    [DefaultValue("DATA:")]
    public string enemyBios_data;
    [DefaultValue("STRATEGY:")]
    public string enemyBios_strategy;

    [DefaultValue("Husks are physical manifestations of the souls of the damned. ")]
    public string enemyBios_filth_1;
    [DefaultValue("The physical form is based on the value of the original soul, which is determined by the strength of its will and its prevalence in public consciousness: the living souls that remember it. ")]
    public string enemyBios_filth_2;
    [DefaultValue("Filth are the lowest form of Husk, whose souls were too weak and unimportant to even form a complete physical body.")]
    public string enemyBios_filth_3;
    [DefaultValue("Even among Husks, they have the lowest intelligence, driven purely by hunger.")]
    public string enemyBios_filth_4;

    [DefaultValue("Most weapons are easily capable of taking down Filth, but their powerful jaws and sheer numbers can overwhelm a target quickly if underestimated.")]
    public string enemyBios_filth_strategy1;
    [DefaultValue("Explosives are the most effective way to take down swarms, but any weapon that can hit more than one target will be efficient.")]
    public string enemyBios_filth_strategy2;

    [DefaultValue("While their tall stature may seem intimidating, Strays are afraid of most danger and will try to stay at a safe distance, only attacking via projectiles formed with Hell Energy. ")]
    public string enemyBios_stray_1;
    [DefaultValue("Although controlling and manifesting this energy is a complicated task, Strays have very low intelligence and are only able to do so via pure instinct.")]
    public string enemyBios_stray_2;
    [DefaultValue("Nevertheless, humans were unable to replicate this level of accuracy and control, particularly the Stray's ability to cause the energy orbs to selectively ignore other Husks.")]
    public string enemyBios_stray_3;

    [DefaultValue("Most weapons will be effective against them, but a Revolver headshot is the quickest and surest way to eliminate a Stray.")]
    public string enemyBios_stray_strategy1;
    [DefaultValue("Due to their static nature and slow rate of attacking, they are an excellent target for projectile parrying.")]
    public string enemyBios_stray_strategy2;

    [DefaultValue("The result of two souls attempting to manifest in the same space, causing an amalgamation of two physical bodies. ")]
    public string enemyBios_schism_1;
    [DefaultValue("Due to the doubled body mass, they're quite resilient to damage, but have very poor motor control and thus cannot aim with any degree of accuracy, resorting to barrages of energy orbs in the general direction of their opponent.")]
    public string enemyBios_schism_2;

    [DefaultValue("Piercer revolver's charged headshots are an efficient tool for a quick kill against Schisms, though their displaced head can make aiming difficult for the inexperienced.")]
    public string enemyBios_schism_strategy1;
    [DefaultValue("A point-blank Pump Charge shotgun blast with 2 pumps will be able to take them down in a single shot.")]
    public string enemyBios_schism_strategy2;
    [DefaultValue("Due to their poor aim, they aren't a priority target, but the sheer amount of projectiles can sometimes make avoiding them tricky in busy encounters.")]
    public string enemyBios_schism_strategy3;

    [DefaultValue("Soldiers are an augmented version of Strays, whose technological implants have been scavenged from broken machines to channel Hell Energy with greater efficiency.")]
    public string enemyBios_soldier_1;
    [DefaultValue("This increase in power gives Soldiers more self-confidence, causing them to act more aggressively than normal Strays.")]
    public string enemyBios_soldier_2;
    [DefaultValue("Despite the enhancements, their intelligence remains low and it has yet to be determined who or what actually augmented them.")]
    public string enemyBios_soldier_3;

    [DefaultValue("The shotgun is an excellent weapon against Soldiers, as long as its use is swift so as to not allow them to protect themselves with melee attacks. ")]
    public string enemyBios_soldier_strategy1;
    [DefaultValue("Since Soldiers charge their shots in front of them rather than above them, the charge is also easier to interrupt via a precise revolver shot for an explosive kill.")]
    public string enemyBios_soldier_strategy2;
    [DefaultValue("Thanks to their augmentations, Soldiers are able to withstand normal explosions with little to no damage. The more powerful red explosions will go through their guard however, and they are unable to block if not on the ground.")]
    public string enemyBios_soldier_strategy3;

    [DefaultValue("Ferrymen are rare husks whose powerful bodies, trained skills and blind faith have granted them the chance of becoming the transporters of souls between the layers of Hell.")]
    public string enemyBios_ferryman_1;
    [DefaultValue("They have each been given a holy cloth by Heaven as a symbol of their devotion to God's order, which they wear over their bodies to hide the human form that they've grown to despise as a reminder of their sins in life stopping them from becoming angels, to the extent that they have torn off their own skin and flesh, leaving behind only bones.")]
    public string enemyBios_ferryman_2;
    [DefaultValue("Due to the holy power emanating from the cloth, Ferrymen's skeletal bodies have slowly been colored bright and radiant, and their skulls have enough latent energy to open gates that otherwise stop Husks from exiting their places of torment.")]
    public string enemyBios_ferryman_3;
    [DefaultValue("Each ferry can only have one Ferryman at a time, so when a new Ferryman is formed, it will fight another to the death in order to take their place and inherit their cloth. The loser's skull is taken as a trophy and used to grant the winner passage across the layers in order to transport the souls of the damned to their destinations.")]
    public string enemyBios_ferryman_4;
    [DefaultValue("Ferrymen will often use the knowledge from their past life to improve their ferries, growing past the need for oars, which are now used by Ferrymen only as weapons.")]
    public string enemyBios_ferryman_5;
    [DefaultValue("As the influx of souls has ended with the death of mankind, the Ferrymen have lost their purpose and now wander around aimlessly, hoping that the angels would grant them passage into Heaven, despite Gabriel being the only one who cares about their efforts.")]
    public string enemyBios_ferryman_6;

    [DefaultValue("Ferrymen choose their attacks based on their opponent's actions. When approached, they move to safety, and when retreated from, they'll apply pressure via attacks with greater reach.")]
    public string enemyBios_ferryman_strategy1;
    [DefaultValue("Despite its looks, their uppercut is quite dangerous and can be difficult to dodge. It's best not to stay in the air for too long.")]
    public string enemyBios_ferryman_strategy2;
    [DefaultValue("Some of their attacks are parryable and some are not. Pay attention to the color of their warning flash to learn which are which.")]
    public string enemyBios_ferryman_strategy3;
    [DefaultValue("Ferrymen may attempt to cross a retreating opponent up by rolling behind them before attacking. Keep track of their position and if they roll too often, try being more aggressive.")]
    public string enemyBios_ferryman_strategy4;

    [DefaultValue("Although they can easily be mistaken to be of divine origin, Idols were created using the same process as other demons. Unlike their larger kin, their shells were too small to contain a useful amount of Hell Mass, creating life, but leaving it unable to move or act.")]
    public string enemyBios_idol_1;
    [DefaultValue("The Idols did not originally look divine, but were painstakingly carved to such shapes by Ferrymen who collected them during travels across the layers of Hell. This was done as both an act of compassion and as a tribute to angels, particularly Gabriel, whom Ferrymen believe to have similarly granted them mercy.")]
    public string enemyBios_idol_2;
    [DefaultValue("Close proximity to a Ferryman's holy cloth during the long and arduous carving process caused its holy power to seep into them, allowing them to continue the chain of compassion by protecting others from physical harm.")]
    public string enemyBios_idol_3;
    [DefaultValue("It is fortunate for them that Gabriel is the only angel of Heaven's higher order to watch over Hell, since if the Council had found out about such beings, they would have been labelled perversions of the divine form and ordered to be destroyed by the Ferrymen who so lovingly had granted them a chance at life.")]
    public string enemyBios_idol_4;

    [DefaultValue("Although Idols are immune to projectiles, they can be destroyed by a blunt force melee attack such as a punch or a ground slam.")]
    public string enemyBios_idol_strategy1;
    [DefaultValue("Blessed enemies cannot be damaged by attacks, but will still be pushed by physical forces and can be killed by environmental dangers, such as crushers or fans.")]
    public string enemyBios_idol_strategy2;
    [DefaultValue("Blessed enemies do not bleed, but parries can still be used to heal from them.")]
    public string enemyBios_idol_strategy3;
    [DefaultValue("Neither Idols nor blessed enemies can be grappled onto with the Whiplash.")]
    public string enemyBios_idol_strategy4;

    [DefaultValue("Unlike most demons, the Leviathan is not formed from generic Hell Mass, but instead from the bodies of the Sullen, a name used for those in the Ocean Styx who have given up fighting for air and instead lay at the bottom of the ocean, drowning eternally.")]
    public string enemyBios_leviathan_1;
    [DefaultValue("The Sullen, in their motionlessness, were eventually fused together by the same force that created the other demons, becoming the biblical Leviathan, an abomination prophesized to be at the end of the world.")]
    public string enemyBios_leviathan_2;
    [DefaultValue("The heart, which houses the souls of the Sullen in endless anguish as their flesh, veins and nerves writhe and mutate, attempted to escape its body, but Gabriel struck it down with his divine spears, pinning it back onto its head, unable to move.")]
    public string enemyBios_leviathan_3;
    [DefaultValue("Although the world ended, the Leviathan remains trapped in the Ocean Styx, growing ever longer as more of Wrath's sinners give up and sink to the bottom.")]
    public string enemyBios_leviathan_4;

    [DefaultValue("The Leviathan's heart is exposed on top of its head, making it a clear weakpoint to aim for. Although it's usually not visible, it can be seen after the Leviathan's attacks, opening an opportunity for direct damage, or for landing a magnet.")]
    public string enemyBios_leviathan_strategy1;
    [DefaultValue("Although ill-advised, it is possible to ride the Leviathan for a short period of time. A well-timed jump will allow one to dodge the Leviathan's bite attack as well as land on its head near its exposed heart.")]
    public string enemyBios_leviathan_strategy2;
    [DefaultValue("The tail will either swing high or low, and the height of the swing can be determined by the direction in which the swing rotates.")]
    public string enemyBios_leviathan_strategy3;

    [DefaultValue("Once the great and beloved king of the Lust layer, Minos has now been reduced to a shambling corpse.")]
    public string enemyBios_corpseOfKingMinos_1;
    [DefaultValue("Due to his incredible power of will and status as a just ruler in life remembered even millennia after his death, the manifestation of his soul is the largest Husk to ever have been recorded.")]
    public string enemyBios_corpseOfKingMinos_2;
    [DefaultValue("Small traces of the original soul can still be detected in the body, but the corpse itself is animated and controlled entirely by the snakelike Parasites that he once commanded.")]
    public string enemyBios_corpseOfKingMinos_3;
    [DefaultValue("Despite once bringing upon the renaissance of the Lust layer, his corpse now only seeks sinners to punish.")]
    public string enemyBios_corpseOfKingMinos_4;

    [DefaultValue("Due to his large stature, it can be quite difficult to recover blood from him, but his hands are usually holding on to the walls of the arena, which can be used for refueling.")]
    public string enemyBios_corpseOfKingMinos_strategy1;
    [DefaultValue("Any weapon will work against an enemy this large, but melee and projectile parries make for a quick way to inflict grave damage.")]
    public string enemyBios_corpseOfKingMinos_strategy2;
    [DefaultValue("Although it moves slowly, the Black Hole he summons is extremely dangerous and cannot be destroyed.")]
    public string enemyBios_corpseOfKingMinos_strategy3;

    [DefaultValue("As the Greed layer's punishment, Stalkers have been forced to carry heavy boulders up the monuments of mankind's greed for all eternity.")]
    public string enemyBios_stalker_1;
    [DefaultValue("They have carried out their punishment for so long that their bodies have evolved, warped and grown to better suit it.")]
    public string enemyBios_stalker_2;
    [DefaultValue("Their limbs have twisted to give them better balance while carrying boulders on their backs and their skin and muscles have completely dried up, allowing them to survive direct contact with the dunes of gold dust that Greed's sun has raised to unfathomably high temperatures.")]
    public string enemyBios_stalker_3;
    [DefaultValue("However, an unidentified sentient force has replaced the boulders they would normally carry with high tech bombs that, upon detonation, will transform any nearby blood into the gold dust \"sand\" that covers the layer's surface.")]
    public string enemyBios_stalker_4;
    [DefaultValue("Research has shown the technology to be very similar to the augmentations of the modified Strays known as Soldiers, so it is likely both modifications come from the same source.")]
    public string enemyBios_stalker_5;

    [DefaultValue("The lights on the canister give information on a Stalker's state. The color shows the state of their explosive and the brightness of the color shows how much health the Stalker has left.")]
    public string enemyBios_stalker_strategy1;
    [DefaultValue("It's advisable to forcibly detonate a Stalker rather than allowing one to detonate itself, as the latter explosion will have a larger area of effect.")]
    public string enemyBios_stalker_strategy2;
    [DefaultValue("If a Stalker gets close to its target and can no longer be pushed away, a ground slam wave can launch them out of range so they can be detonated safely in mid-air, since the explosion is mostly horizontal.")]
    public string enemyBios_stalker_strategy3;
    [DefaultValue("Attaching magnets to a Stalker will reduce the radius of its detonation.")]
    public string enemyBios_stalker_strategy4;

    [DefaultValue("The Sisyphean Insurrectionists were an army of Husks gathered and trained by King Sisyphus for overthrowing Heaven's control of Hell, freeing the sinners from their eternal torment.")]
    public string enemyBios_insurrectionist_1;
    [DefaultValue("During an era of chaos in Heaven, as the angelic watch was absent, Sisyphus began setting his plan in motion as his forces recruited all Husks that were intelligent enough to be useful to their cause and began attacking the demons that wandered the dunes of Greed.")]
    public string enemyBios_insurrectionist_2;
    [DefaultValue("Upon the establishment of the Council and subsequent return of peace to Heaven, Gabriel and an army of angels were sent down to crush the insurrection and subjugate Sisyphus' army.")]
    public string enemyBios_insurrectionist_3;
    [DefaultValue("Although their battle was well-fought, the inexperienced Insurrectionists could not match the educated strategy of the angels, who quickly descended upon King Sisyphus with great force, eventually overpowering and killing him, leaving the Insurrectionists without a chain of command.")]
    public string enemyBios_insurrectionist_4;
    [DefaultValue("Left scattered and disoriented, the warriors were easily picked off one by one, their bodies cut apart, leaving behind only the bare essentials required to carry on their eternal punishment of hauling heavy boulders up the monuments of mankind's arrogance and greed.")]
    public string enemyBios_insurrectionist_5;
    [DefaultValue("Although the blood of their enemies still stains their bodies and their grasp still clutches their fallen foes, their will and fierce fury only serve as mental torment in knowing how close they were to freedom.")]
    public string enemyBios_insurrectionist_6;

    [DefaultValue("The Sisyphean Insurrectionists soak their feet in the blood of their enemies to protect them from the heat of Greed's dunes, but the rest of their body is still skin and flesh, which can be set aflame to greatly weaken their defences, increasing the damage of any attack dealt to them.")]
    public string enemyBios_insurrectionist_strategy1;
    [DefaultValue("Though they have practically unlimited range, each of the Insurrectionist's swings has strengths and weaknesses. Learning which way to dodge to avoid each attack is vital.")]
    public string enemyBios_insurrectionist_strategy2;
    [DefaultValue("The Insurrectionist's stomp is fast and destructive, so it's inadvisable to stay close for long.")]
    public string enemyBios_insurrectionist_strategy3;
    [DefaultValue("The Malicious Face they wield as a weapon is not a part of their body, so hitting it will not deal damage to an Insurrectionist, but this also means that it can still be used to heal even if its wielder's blood has been turned to sand.")]
    public string enemyBios_insurrectionist_strategy4;

    [DefaultValue("Its original form is unrecognisable after years of scavenging scrap and rebuilding itself, but among scrapheads, the Swordsmachine is quite famous due to its combat prowess and selfmade form, ugly to most but beautiful to enthusiasts, spawning many copycats. ")]
    public string enemyBios_swordsmachine_1;
    [DefaultValue("It wields a selfmade sword with a motor on it that, when revved, will heat the blade, cutting through most organic matter with ease. ")]
    public string enemyBios_swordsmachine_2;
    [DefaultValue("Due to its possessive hoarding behavior, it's one of the few machines still capable of vocalization -- an ability most have discarded for more efficient resource management.")]
    public string enemyBios_swordsmachine_3;

    [DefaultValue("Despite its excellent performance against Hell's denizens, its design does not take into account extremely mobile opponents, so the best way to avoid its blade is to jump out of its vertical range.")]
    public string enemyBios_swordsmachine_strategy1;
    [DefaultValue("Its motorized sword makes for predictable attacks, making the Swordsmachine an excellent target for parrying.")]
    public string enemyBios_swordsmachine_strategy2;
    [DefaultValue("Although its use of ranged weapons is primitive at best, its sword throws can be unexpectedly accurate thanks to its mastery of the weapon.")]
    public string enemyBios_swordsmachine_strategy3;

    [DefaultValue("A mass-produced security device built as both a surveillance camera and a security guard.")]
    public string enemyBios_drone_1;
    [DefaultValue("Though originally built to only use non-lethal ammunition, they have scavenged parts from the defunct machines on the surface for greater efficiency at collecting blood.")]
    public string enemyBios_drone_2;
    [DefaultValue("Curious by nature, but to keep production costs low, their intelligence is very limited.")]
    public string enemyBios_drone_3;

    [DefaultValue("Due to their light weight, physical projectiles such as nails will push them around, making them harder to deal consistent damage to.")]
    public string enemyBios_drone_strategy1;
    [DefaultValue("On death they will make a last ditch effort to harm their opponent with a self-destruct, but powerful single attacks and explosives will make them explode instantly.")]
    public string enemyBios_drone_strategy2;
    [DefaultValue("Punching a drone will redirect their suicide dive, making them a high-risk offensive opportunity.")]
    public string enemyBios_drone_strategy3;
    [DefaultValue("Their scanning mechanism makes a chirping sound, which can be listened for to make them easier to track down, as their flight and small size can lead them to hard to reach places.")]
    public string enemyBios_drone_strategy4;

    [DefaultValue("Originally built as a way to purify the tainted air of cities after the climate catastrophe, Streetcleaners were made obsolete during the New Peace, and were repurposed as scouts for Hell expeditions.")]
    public string enemyBios_streetcleaner_1;
    [DefaultValue("However, their urge to clean remained, and after the fall of mankind, they began burning any organic matter they came across in an effort to purify the world.")]
    public string enemyBios_streetcleaner_2;

    [DefaultValue("Due to their combat experience, they can be tricky to take down with projectiles or explosives.")]
    public string enemyBios_streetcleaner_strategy1;
    [DefaultValue("The canister on their back is a major weakpoint that can be shattered with a precision shot, such as a Marksman coin ricochet from behind.")]
    public string enemyBios_streetcleaner_strategy2;
    [DefaultValue("Point-blank attacks can also be very efficient, but must be performed quickly to avoid the fire of their flamethrowers.")]
    public string enemyBios_streetcleaner_strategy3;

    [DefaultValue("The V model was built for war, with V1 boasting a new kind of exterior plating that allowed refueling through contact with blood rather than through a separate blood refueling process.")]
    public string enemyBios_v2_1;
    [DefaultValue("Due to its necessary thinness, it is far less durable, but the ability to fix itself and rebuild broken parts on the fly would outweigh the negatives on an active battlefield.")]
    public string enemyBios_v2_2;
    [DefaultValue("However, during the prototyping phase, the New Peace was established and war became irrelevant.")]
    public string enemyBios_v2_3;
    [DefaultValue("V1's planned production was cancelled and an updated model, V2, was developed instead, using the standardized plating, since durability was far more important during times of peace when no bloodshed was necessary.")]
    public string enemyBios_v2_4;
    [DefaultValue("Neither model ever reached mass production due to the end of wars completely draining any demand, so it's likely only a single prototype build of each model remains in existence.")]
    public string enemyBios_v2_5;

    [DefaultValue("V2 is adept at controlling space and will take advantage of this to change the flow of battle to throw off its opponent. Stay too close and it will run away. Stay far away and it will come close.")]
    public string enemyBios_v2_strategy1;
    [DefaultValue("V2's high mobility makes it a tricky target to hit, and especially difficult to heal off of. When in need of blood and unable to catch up, it's instead recommended to stay away from it and let it come to you instead.")]
    public string enemyBios_v2_strategy2;
    [DefaultValue("V2 will switch weapons depending on the distance from its target, so if one of its weapons is difficult to avoid, a change in proximity will close it off.")]
    public string enemyBios_v2_strategy3;
    [DefaultValue("Knowledge of the synergies of one's own arsenal can allow one to turn V2's weapons against it.")]
    public string enemyBios_v2_strategy4;

    [DefaultValue("Rare but extremely dangerous, the Mindflayer is a machine that has adapted and mastered the use of Hell Energy alongside its own technological prowess.")]
    public string enemyBios_mindflayer_1;
    [DefaultValue("The machine itself is only the top part of its apparent body, the rest of which is a plastic shell in the form of a human, which they seem to have built themselves.")]
    public string enemyBios_mindflayer_2;
    [DefaultValue("The plastic body serves no function and is only for aesthetic purposes.")]
    public string enemyBios_mindflayer_3;
    [DefaultValue("Despite it being a waste of resources, Mindflayers will use everything in its power to protect the plastic body from harm, even if that means destroying itself in the process.")]
    public string enemyBios_mindflayer_4;
    [DefaultValue("Mindflayers seem to prefer a female form, though very rare occasions of male forms have also been recorded.")]
    public string enemyBios_mindflayer_5;

    [DefaultValue("When encountering a Mindflayer, it's imperative to keep track of their actions either through visuals or audio.")]
    public string enemyBios_mindflayer_strategy1;
    [DefaultValue("Due to their homing projectiles being fired in a burst, a safe explosive such as a Knuckleblaster blastwave is the most efficient in deflecting them.")]
    public string enemyBios_mindflayer_strategy2;
    [DefaultValue("Their instant teleportation can make consistent positional advantage quite difficult, but a Screwdriver drill will temporarily stop them from teleporting.")]
    public string enemyBios_mindflayer_strategy3;

    [DefaultValue("One of the many war machines created during the Final War. Although there were attempts to find new purpose for them during the New Peace, their streamlined design made them unable to be repurposed until the start of the Hell expeditions.")]
    public string enemyBios_sentry_1;
    [DefaultValue("Their extremely powerful legs and feet allow them to dig into the ground, making them immovable by most forces and allowing them to easily line up any shot without interruption.")]
    public string enemyBios_sentry_2;
    [DefaultValue("Despite their size, they were built to be extremely light, which when combined with the power of their legs, allows them to move at extremely fast speeds. Such power and lightness have made their legs one of the most sought after parts by scrapheads.")]
    public string enemyBios_sentry_3;
    [DefaultValue("Most machines will only render a simplified approximation of their visual surroundings for faster processing speed, but Sentries use full renders instead, giving them perfect accuracy even over extremely long distances.")]
    public string enemyBios_sentry_4;

    [DefaultValue("Due to their powerful legs, once they've dug into the ground to aim, they can no longer move.")]
    public string enemyBios_sentry_strategy1;
    [DefaultValue("Once dug in, the only ways to interrupt their attack are: Shooting them with the Electric Railcannon, hitting their antenna with the Revolver, launching them with the ground slam wave or punching them with the Knuckleblaster.")]
    public string enemyBios_sentry_strategy2;
    [DefaultValue("As long as they haven't dug in, their light weight makes them easy to launch and keep in the air where they are harmless.")]
    public string enemyBios_sentry_strategy3;
    [DefaultValue("A good way to disable a Sentry for a longer period of time is to shoot nails into them with the Nailgun and then placing a magnet in a nearby wall or ceiling, which will pull them once they've been knocked off balance.")]
    public string enemyBios_sentry_strategy4;

    [DefaultValue("After its defeat and escape, V2 dove deeper into Hell, killing other machines for their blood to help its recovery with the intent of taking revenge on V1 and recovering its original arm.")]
    public string enemyBios_v2Second_1;
    [DefaultValue("After finding a temporary replacement from one of its victims, V2 used parts from other machines to transform the new placeholder arm into a mobility tool that would allow it to catch up to V1's fast descent into the deeper layers.")]
    public string enemyBios_v2Second_2;
    [DefaultValue("In order to prepare for their second and final encounter, it researched the combat data from their previous battle to copy strategies and techniques from the older and more experienced V1 to give itself an upper hand.")]
    public string enemyBios_v2Second_3;
    [DefaultValue("However, despite all its preparation, V2 lost again, and unable to escape this time, was brought to a swift and decisive end by its predecessor.")]
    public string enemyBios_v2Second_4;

    [DefaultValue("Although V2's coins may seem extremely dangerous at first, they are also an excellent opportunity for high damage if shot before V2 can.")]
    public string enemyBios_v2Second_strategy1;
    [DefaultValue("V2's nailgun can be circumvented or turned against itself via Magnets.")]
    public string enemyBios_v2Second_strategy2;
    [DefaultValue("Hitting V2 with its own arm will cause it to enrage instantly.")]
    public string enemyBios_v2Second_strategy3;

    [DefaultValue("Built in the early days of the Final War, the Guttermen were one of the first successful experiments in using blood as a fuel source, as well as the first automatons to be deployed in wide-scale conflict.")]
    public string enemyBios_gutterman_1;
    [DefaultValue("During the war's first phase, an era of trench warfare, these seemingly unstoppable walls were airdropped into enemy trenches, which they would then slowly and systematically clear out as all opposing soldiers would have to choose between being minced by the Gutterman, or running out of the trench and getting mowed down by machine gun fire.")]
    public string enemyBios_gutterman_2;
    [DefaultValue("Researchers had not yet found a way to keep the blood inside a machine fresh, so a live fuel source was strapped inside, kept alive by minimal life support, before the Guttermen were welded shut. Although publically these fuel sources were claimed to be volunteer patriots, most were deserters, battle-fatigued returnees or prisoners of war.")]
    public string enemyBios_gutterman_3;
    [DefaultValue("Forces from far beyond took notice of the cruelty man was capable of, and the suffering of these human blood supplies served as an inspiration for the creation of the Mannequins.")]
    public string enemyBios_gutterman_4;

    [DefaultValue("The shield is a Gutterman's main defence. Destroying it with the Knuckleblaster will cause them to take increased damage.")]
    public string enemyBios_gutterman_strategy1;
    [DefaultValue("Although slow at first, their tracking will improve the longer they maintain line of sight. It's best not to stay out in the open for too long.")]
    public string enemyBios_gutterman_strategy2;
    [DefaultValue("Once the shield has been broken, the Gutterman's punches can be parried, which resets their tracking.")]
    public string enemyBios_gutterman_strategy3;
    [DefaultValue("A Gutterman's corpse can be ground slammed to cause a large explosion that damages surrounding enemies and launches the attacker high in the air.")]
    public string enemyBios_gutterman_strategy4;

    [DefaultValue("As Guttermen singlehandedly ended the trench warfare era of the Final War, armies scrambled to create countermeasures, leading to the creation of more machines of war.")]
    public string enemyBios_guttertank_1;
    [DefaultValue("Built from the foundations of Guttermen to save time, Guttertanks were equipped with highly efficient explosives and arms capable of damaging and destroying thick armor. The slow, lumbering walls that once dominated the field had now become obsolete.")]
    public string enemyBios_guttertank_2;
    [DefaultValue("As human soldiers had quickly become useless in war, utterly outclassed by machines, they were almost entirely phased out. This lead to the second era of the Final War, where machines fought machines in a back-and-forth tide as new designs were phased in and out at a feverish pace, each designed specifically to counter the last.")]
    public string enemyBios_guttertank_3;
    [DefaultValue("Although at first the soldiers celebrated returning home, they soon found that the pointless, endless arms race left little in its wake. All resources were used on machines of war, and impoverished civilians had to struggle to survive. Home was just another battlefield, a war of all against all.")]
    public string enemyBios_guttertank_4;
    [DefaultValue("Conquest leads to war —")]
    public string enemyBios_guttertank_5;
    [DefaultValue("War leads to famine —")]
    public string enemyBios_guttertank_6;
    [DefaultValue("Famine leads to...")]
    public string enemyBios_guttertank_7;

    [DefaultValue("The Guttertank's punch is deceptively fast and powerful. The best way to get close safely is to bait a punch before closing the gap.")]
    public string enemyBios_guttertank_strategy1;
    [DefaultValue("Due to reused technology, the Freezeframe Rocket Launcher is capable of freezing Guttertank rockets too, making them temporarily incapable of long range combat.")]
    public string enemyBios_guttertank_strategy2;

    [DefaultValue("Earthmovers were the pinnacle of the arms race. Often called the horsemen of the apocalypse, it took only one to level an entire city and leave nothing but fire in its wake. The last era of the Final War had begun.")]
    public string enemyBios_earthmover_1;
    [DefaultValue("The first machines large enough to house a shield generator, these walking fortresses could only be made vulnerable from within, making them the new frontlines for smaller, more mobile machines. Due to their colossal size, they required both blood and solar power to function.")]
    public string enemyBios_earthmover_2;
    [DefaultValue("When the final era escalated, cleansing the world with fire, the surviving civilians were forced to evacuate and build new homes on the backs of these machines, as the surface became an inhospitable wasteland where no flora or fauna could flourish.")]
    public string enemyBios_earthmover_3;
    [DefaultValue("Eventually the soot, smoke and decay from unending global war would blot out the sun, casting the world into the Long Night, and Earthmovers, unable to feed on sunlight, shut down and died out one by one.")]
    public string enemyBios_earthmover_4;
    [DefaultValue("War had become entirely dependent on them, large scale conflict was no longer feasible. Finally, mankind started to work together to reverse the effects of the Long Night climate catastrophe, and so began the New Peace. 200 years of war for its own sake ended not with a bang, but utter silence.")]
    public string enemyBios_earthmover_5;
    [DefaultValue("At the brink of despair, the planet would slowly learn to breathe once more, and the corpses of these titans would serve as a stark reminder of just how close mankind was to an apocalypse by their own hand.")]
    public string enemyBios_earthmover_6;

    [DefaultValue("Each part of the security system is immobile, making them very vulnerable to attacks that would otherwise easily miss, such as Freeze Frame rockets.")]
    public string enemyBios_earthmover_strategy1;
    [DefaultValue("Some of the gaps in the main computer room's defence grid are too high up for a normal jump, but the elevated edges of the room can be used to get higher. More adept movers may instead jump immediately after a ground slam to gain enough height.")]
    public string enemyBios_earthmover_strategy2;

    [DefaultValue("Demons are creatures born from the mass of Hell. They are most easily recognisable by their hard stone-like exterior and slow movement.")]
    public string enemyBios_maliciousFace_1;
    [DefaultValue("Demons have higher intelligence than Husks, but are still incapable of rational thought and communication. No demons have been able to pass the mirror test, though studies are limited due to their hostility.")]
    public string enemyBios_maliciousFace_2;
    [DefaultValue("Malicious Faces are the most common type of demon, but are incredibly dangerous, especially in swarms, due to their mastery of the use of Hell Energy as a weapon.")]
    public string enemyBios_maliciousFace_3;

    [DefaultValue("Due to their burst fire, they can be quite difficult to get close to, so despite the effectiveness of a point blank shotgun shot, nails are the recommended course of action, with magnets enabling long-range combat.")]
    public string enemyBios_maliciousFace_strategy1;
    [DefaultValue("Due to their invulnerability to explosions, they don't need to hold back the energy of their beam attacks, so staying away from walls and other surfaces is recommended when they begin charging an energy beam.")]
    public string enemyBios_maliciousFace_strategy2;

    [DefaultValue("Although they do not resemble the mythological three-headed dog, this name was chosen due to their nature as protectors of Hell. However, it's not yet known why some stay dormant despite provocation.")]
    public string enemyBios_cerberus_1;
    [DefaultValue("Despite the fact that keeping an energy orb stable takes a considerable amount of focus and effort, they seem to always keep one in hand, most likely as a display of their power to scare off intruders.")]
    public string enemyBios_cerberus_2;

    [DefaultValue("Due to remaining entirely stationary until awoken, they move quite slowly, so engagement distance is easy to control.")]
    public string enemyBios_cerberus_strategy1;
    [DefaultValue("They're quite adept at ranged combat by throwing their orb, but in order to avoid damaging themselves, they will not initiate a throw while their target is close, which can be used to manipulate their behavior, though once a throw has started, it cannot be stopped.")]
    public string enemyBios_cerberus_strategy2;
    [DefaultValue("Due to the extreme concentration of their energy orbs, thrown ones explode on physical impact, so staying close to surfaces such the floor or any walls will make avoiding ranged attacks more difficult.")]
    public string enemyBios_cerberus_strategy3;

    [DefaultValue("Hideous Masses are a rare occurrence, when an excessive amount of Hell Mass is poured into a single shell, causing it to overflow and burst at the seams.")]
    public string enemyBios_hideousMass_1;
    [DefaultValue("Due to the broken seams allowing for mobility without having to bend the exterior, the stone has hardened more than the shell of most demons, making it completely impervious to all currently known attacks.")]
    public string enemyBios_hideousMass_2;

    [DefaultValue("Although its stone exterior makes for an impenetrable defense, the Hideous Mass' belly and tail remain exposed and vulnerable.")]
    public string enemyBios_hideousMass_strategy1;
    [DefaultValue("While standing up, a quick burst of close range damage is the most effective way to hurt them, though this will most likely cause it to change formations, so being quick and decisive is the key.")]
    public string enemyBios_hideousMass_strategy2;
    [DefaultValue("When in its low formation, keeping a safe distance is recommended due to its melee capabilities and high speed tail harpoon, though the brave or suicidal may attempt to climb on its back to continue dealing close range damage to the tail.")]
    public string enemyBios_hideousMass_strategy3;
    [DefaultValue("When caught by the harpoon, it's recommendable to either punch the harpoon or damage the tail to remove it.")]
    public string enemyBios_hideousMass_strategy4;

    [DefaultValue("During the departure of the angels after the Disappearance of God, many sinners attempted to escape the Violence layer, braving the labyrinth that lay at its edges, thinking they could find a way out in the absence of Heaven's wardens.")]
    public string enemyBios_mannequin_1;
    [DefaultValue("The fools who attempted would realize far too late that angels were not all that kept them from freedom, as the Garden of Forking Paths is no ordinary labyrinth, but one of malicious intent, overseen with cunning cruelty.")]
    public string enemyBios_mannequin_2;
    [DefaultValue("The halls, each similar enough to give no sense of direction, but just different enough to grant no familiarity, would eventually exhaust each escapee, and as they fell into a deep sleep, their metamorphosis began.")]
    public string enemyBios_mannequin_3;
    [DefaultValue("Each sinner was torn apart joint by joint, their broken and shattered limbs shoved into hollow statues, startling them to life as the flesh and blood of Mannequins.")]
    public string enemyBios_mannequin_4;
    [DefaultValue("The gift of death is a rare privilege in Hell, so the sinners who attempted to control their fate now lay dormant in eternal agony, unable to control even their own bodies, which now continue to carry on the same punishment to other unfortunate fools.")]
    public string enemyBios_mannequin_5;

    [DefaultValue("Though they are nimble, if a Mannequin is knocked into the air or hit while clinging onto a surface, they lose their balance when landing, granting a small window for an easier hit. Those fast enough may even punch them in the air while they're vulnerable, killing them in a single blow.")]
    public string enemyBios_mannequin_strategy1;
    [DefaultValue("Mannequin projectiles can be difficult to avoid due to their homing capabilities, but this makes them even easier to parry with the Feedbacker arm.")]
    public string enemyBios_mannequin_strategy2;
    [DefaultValue("Mannequins are easier to hit with the larger radius of explosions, but are more resistant against them than other weaponry.")]
    public string enemyBios_mannequin_strategy3;

    [DefaultValue("UNKNOWN. NO DATA.")]
    public string enemyBios_minotaur_1;
    [DefaultValue("The Minotaur, one of the oldest known surviving demons, was sculpted by ████ ██████ as a gift for the then Judge of Hell, Minos, in an attempt to form some kind of rapport.")]
    public string enemyBios_minotaur_2;
    [DefaultValue("Though its creator considered it beautiful, a personalized monument of death and despair, Minos was terrified of the grotesque caricature of his past mistakes and cast it into the Garden of Forking Paths, hoping it would never be seen again.")]
    public string enemyBios_minotaur_3;
    [DefaultValue("Now the Minotaur is old and its body failing, falling apart, running blind through the labyrinth in a desperate attempt to break out. Its only desire: to see the sky for one last time.")]
    public string enemyBios_minotaur_4;

    [DefaultValue("Although difficult to heal from due to its distance, it is best to be patient. New trams will often arrive, carrying weaker foes for easier healing.")]
    public string enemyBios_minotaur_strategy1;
    [DefaultValue("Much of its body is protected, but its guts are exposed, making for an easy consistent target.")]
    public string enemyBios_minotaur_strategy2;

    [DefaultValue("One of the most respected and feared archangels, Gabriel earned his reputation through power and efficiency.")]
    public string enemyBios_gabriel_1;
    [DefaultValue("Regardless of the task given, Gabriel would always perform it quickly and decisively, earning him the title of Judge of Hell after dethroning Minos and ending the Lust renaissance.")]
    public string enemyBios_gabriel_2;
    [DefaultValue("Despite answering to the Council, he is far more popular and beloved among angels due to his radiant personality and active nature, especially compared to the Council that strictly follows and upholds the dogma of the Faith.")]
    public string enemyBios_gabriel_3;

    [DefaultValue("Gabriel's movements are fast and his attacks are deadly, but by observing which weapon he manifests, his attacks can be accurately predicted before he even starts them.")]
    public string enemyBios_gabriel_strategy1;
    [DefaultValue("Gabriel's pride stops him from attacking while taunting his opponent, opening up a short window for healing.")]
    public string enemyBios_gabriel_strategy2;

    [DefaultValue("Having twice clashed with the machine and lost, Gabriel realized he had been mistaken. The strong fire that burned inside him was not hatred at all, but passion.")]
    public string enemyBios_gabrielSecond_1;
    [DefaultValue("Gabriel had never before known the joy of a struggle, of coming face-to-face with an opponent of equal or greater measure. Though he had lost twice, each loss only further grew his desire to overcome.")]
    public string enemyBios_gabrielSecond_2;
    [DefaultValue("Up until now, he had only done what was expected of him, but now for the first time he had found something he himself wanted. Not even the fast encroaching End of Hell mattered to him anymore.")]
    public string enemyBios_gabrielSecond_3;
    [DefaultValue("Still, having come to realize the horrors he had committed in God's name, he felt a great guilt. Though he could not undo what he had done, Gabriel knew he had to make things right, and headed to Hell for the last time.")]
    public string enemyBios_gabrielSecond_4;

    [DefaultValue("While Gabriel's speed has increased, his accuracy has not. Dodging diagonally or to the side will prove more fruitful than trying to run backwards out of the range of his swords.")]
    public string enemyBios_gabrielSecond_strategy1;
    [DefaultValue("Though his sword throw may seem impossible to dodge, it will prove an excellent weapon if parried instead.")]
    public string enemyBios_gabrielSecond_strategy2;
    [DefaultValue("Overcome with emotion, Gabriel will sometimes stop to taunt his opponent, creating a window for healing.")]
    public string enemyBios_gabrielSecond_strategy3;

    [DefaultValue("The basis of a lesser angel's forming are quite similar to that of the Husks', wherein the physical manifestation of the soul is dependant on its value, though unlike for Husks, virtuousness also acts as a factor for angels.")]
    public string enemyBios_virtue_1;
    [DefaultValue("Lesser angels come from human souls, which are formed into abstract or animalistic shapes, making them distinct from the humanoid bodies of greater and supreme angels, who were created as such and are considered purer and placed higher on Heaven's societal hierarchy.")]
    public string enemyBios_virtue_2;
    [DefaultValue("Due to their past lives as humans, Virtues are often sent to complete tasks that greater angels deem below them or otherwise uninteresting, such as acting as wardens in Hell. There Virtues use heavenly fire to punish sinners who aren't acting out their punishment, in order to not waste Gabriel's time with minor offences and fluctuations.")]
    public string enemyBios_virtue_3;
    [DefaultValue("Virtues are normally known to have a multitude of eyes, though for unknown reasons, these eyes are hidden or removed for ones that become wardens in Hell. Some have speculated this may be related to why almost all husks lack eyes, with the only verified exception being the previous Judge of Hell, King Minos.")]
    public string enemyBios_virtue_4;
    [DefaultValue("Little is known about the specifics of angels, as Heaven is exclusionary and segregated due to wanting little to no direct contact with God's human experiment.")]
    public string enemyBios_virtue_5;

    [DefaultValue("Verticality and cover give little safety against the Virtue's light beams, so constant horizontal movement is encouraged, though retracing one's steps can be dangerous as the beams linger.")]
    public string enemyBios_virtue_strategy1;
    [DefaultValue("If ignored for too long, Virtues will enrage, making their light beams predict their target's movement. Although it's easy to avoid their attacks with enough space, leaving them unattended can quickly turn the tables in their favor")]
    public string enemyBios_virtue_strategy2;

    [DefaultValue("Very little is known about this creature. ")]
    public string enemyBios_somethingWicked_1;
    [DefaultValue("Some speculate it to be a Husk, but due to its elusive and extremely hostile nature, no one has been able to confirm the hypothesis.")]
    public string enemyBios_somethingWicked_2;
    [DefaultValue("All that can be determined for sure is that it consists entirely of a withered cardiovascular system and a dead heart, which has led to the common assumption that its physical body's manifestation failed.")]
    public string enemyBios_somethingWicked_3;
    [DefaultValue("Only one has ever been observed and it has never been seen leaving the section of the Mouth of Hell in which it currently resides.")]
    public string enemyBios_somethingWicked_4;

    [DefaultValue("Any attack will temporarily cause it to relocate, but there are no known ways to kill it.")]
    public string enemyBios_somethingWicked_strategy1;
    [DefaultValue("Its way of attacking is unknown outside of the fact that it happens on physical contact, but no amount of protection has saved any of its victims.")]
    public string enemyBios_somethingWicked_strategy2;

    [DefaultValue("Flesh Prison is an uncategorized organism created by the angels to imprison Minos' soul after he was slain by Gabriel.")]
    public string enemyBios_fleshPrison_1;
    [DefaultValue("Although it is similar to Husks, it does not possess a soul or any amount of thought. All of its actions are purely predetermined reactions to stimulus, making it more of an organic machine than a living being.")]
    public string enemyBios_fleshPrison_2;
    [DefaultValue("In order to make it as impenetrable as possible, it was given both divine power and hell energy, which makes its attacks erratic and chaotic.")]
    public string enemyBios_fleshPrison_3;

    [DefaultValue("Flesh Prison will use its spawn to heal its own wounds. The more spawn are left, the more likely it is for Flesh Prison to attempt to heal its wounds, so it's advisable to avoid damaging it until the spawn are dead.")]
    public string enemyBios_fleshPrison_strategy1;
    [DefaultValue("The long window of a delayed split shot timing makes for a great way to clear out multiple spawn at once. Throwing multiple coins high into the air and waiting for them to reach the delayed split shot state before shooting them is a strong opening move after Flesh Prison creates its spawn.")]
    public string enemyBios_fleshPrison_strategy2;

    [DefaultValue("A prime soul is an incredibly rare occurrence in which a soul amasses so much power that it no longer requires a Husk as a vessel to manifest physically.")]
    public string enemyBios_minosPrime_1;
    [DefaultValue("As manifestations of pure will, prime souls are incredibly powerful, to the point that even the prideful angels see them as a threat and will use any means necessary to stop them from forming.")]
    public string enemyBios_minosPrime_2;
    [DefaultValue("King Minos felt that eternal suffering was an unfair and unreasonable punishment for those whose only sin was loving another. After the Disappearance of God, as angels were lost and Heaven was in chaos, Minos began his efforts to reform the Lust layer.")]
    public string enemyBios_minosPrime_3;
    [DefaultValue("The Lust renaissance was prosperous, as King Minos guided its inhabitants to come together and build a new civilization. The combined efforts of the countless who had been damned to the second layer bore great results as the grand city of Lust grew and grew.")]
    public string enemyBios_minosPrime_4;
    [DefaultValue("However, after the Council took control of Heaven and brought stability to it through their iron fist rule, they saw that Minos had gone against God's will by freeing sinners from the punishment that God had designed for them.")]
    public string enemyBios_minosPrime_5;
    [DefaultValue("Gabriel, the brightest of the angels, was sent to kill Minos. The king, rather than fight back, tried to reason with him, but Gabriel mercilessly struck him down without listening.")]
    public string enemyBios_minosPrime_6;
    [DefaultValue("As Minos' will was strong enough to attempt to stand up to Heaven's rule, the angels chose to imprison his soul in an attempt to stop it from forming into a prime soul and appointed Gabriel as the new Judge of Hell.")]
    public string enemyBios_minosPrime_7;
    [DefaultValue("From the prison inside his own body, Minos helplessly watched as his soulless corpse, now controlled by parasites, tore apart everything he had worked so hard to build, cursing his own weakness for failing to protect his people, vowing to take revenge...")]
    public string enemyBios_minosPrime_8;

    [DefaultValue("It's rare for Minos Prime to give a window of opportunity to heal, so it's vital to learn what attacks leave him momentarily vulnerable and how to dodge them in a way that gives an advantageous position during those moments.")]
    public string enemyBios_minosPrime_strategy1;
    [DefaultValue("His snake projectiles can be parried using the Feedbacker for a full heal, even if the projectile doesn't hit Minos Prime.")]
    public string enemyBios_minosPrime_strategy2;

    [DefaultValue("Flesh Panopticon is a superior version of the Flesh Prison, built to not only house the soul of King Sisyphus, but also with the capability to keep a watchful eye over any of his followers that may be imprisoned alongside him.")]
    public string enemyBios_fleshPanopticon_1;
    [DefaultValue("This feature was however never utilized, as Sisyphus' prime soul had already started forming before being imprisoned, leading angels to fear that he may be able to break out of his prison if awakened.")]
    public string enemyBios_fleshPanopticon_2;

    [DefaultValue("Though Flesh Panopticon creates fewer spawn than its predecessor, they're more resilient and their gaze is able to stop all wounds from healing. This may seem just a curse, but it nullifies the Whiplash's primary flaw, allowing it to be used freely to approach and destroy the spawn at close range.")]
    public string enemyBios_fleshPanopticon_strategy1;
    [DefaultValue("Flesh Panopticon's explosives make it dangerous to stay on the ground, but they will phase through the Panopticon to avoid it harming itself, making standing on top of it safer as long as the black hole isn't nearby.")]
    public string enemyBios_fleshPanopticon_strategy2;

    [DefaultValue("Though Minos was intelligent and persuasive, he was also a gentle and noble man. Such values mattered little to Sisyphus, who would gladly lie, cheat or kill if that's what is needed to protect his comrades.")]
    public string enemyBios_sisyphusPrime_1;
    [DefaultValue("In a hubristic show of power, Heaven decided that the only correct punishment for his sins would be breaking his will by subjecting him to an unending and impossible task, unaware of just how tenacious the spite of man can be.")]
    public string enemyBios_sisyphusPrime_2;
    [DefaultValue("For thousands of years, Sisyphus bided his time, suffering his punishment day after day without any sign of regret or remorse, waiting for the perfect chance to strike and subvert Heaven's tyrannical rule.")]
    public string enemyBios_sisyphusPrime_3;
    [DefaultValue("With the Disappearance of God and chaos in Heaven, Sisyphus' time had finally come, and once the angels returned, they were met with a force and fury that had boiled in the hearts of men for millennia, a warcry so fierce it shook the very foundations of Hell.")]
    public string enemyBios_sisyphusPrime_4;
    [DefaultValue("It was all for naught, however, as Sisyphus' charisma and drive had made his warriors dependent on his radiance and guidance. Although he did not know why yet, Gabriel recognised this flaw, having experienced it first hand, and ordered a focused assault to take down the king. ")]
    public string enemyBios_sisyphusPrime_5;
    [DefaultValue("He unsheathed his swords for the first time since time immemorial and beheaded Sisyphus, displaying his head for all to see. The morale of Sisyphus' army was broken and the rest of the war was little more than a formality without their shining beacon.")]
    public string enemyBios_sisyphusPrime_6;
    [DefaultValue("The failure of the insurrection was no surprise however, and few knew that better than Sisyphus himself. He knew he was fighting a losing battle, that even if they miraculously survived this encounter, they had no chance of winning a full scale war against all of Heaven. Yet he thrust his full heart and soul into battle with a wide smile on his face.")]
    public string enemyBios_sisyphusPrime_7;
    [DefaultValue("To him, fighting an impossible battle with full knowledge of its futility and taking joy in just the act of resistance itself is the ultimate rebellion against the oppressor. One must imagine Sisyphus happy.")]
    public string enemyBios_sisyphusPrime_8;

    [DefaultValue("Sisyphus' relentless attacks leave little room to recover stamina, but many of them are parryable, allowing for an instant refill.")]
    public string enemyBios_sisyphusPrime_strategy1;
    [DefaultValue("The radiant power of the sun makes Sisyphus' explosive attacks very difficult to avoid, but since a dash gives temporary invincibility, good timing allows one to avoid the damage of an explosion without actually needing to escape its radius.")]
    public string enemyBios_sisyphusPrime_strategy2;

    // Providence
    [DefaultValue("After Gabriel's final message, Heaven has once again been thrown into the brink of turmoil, and in order to avoid escalation into civil war, the fastest of the lesser angels, Providences, have been sent to find him and bring him back.")]
    public string enemyBios_providence_1;
    [DefaultValue("Due to the urgency of the mission, they have been allowed to keep their sight when venturing into Hell, breaking the sacred oath that the angels had sworn to the Father after an unknown incident in the distant past.")]
    public string enemyBios_providence_2;
    [DefaultValue("Their bodies are constructed of pure light, which makes their precise shape impossible to perceive, and would blind a human being if seen directly.")]
    public string enemyBios_providence_3;
    [DefaultValue("")]
    public string enemyBios_providence_4;
    [DefaultValue("The gifted eye of a Providence allows for energy beam concentration that even the mobility of the V-models cannot dodge through, and thus their beams must be avoided entirely.")]
    public string enemyBios_providence_strategy1;
    [DefaultValue("Due to their agility, the Whiplash is unable to hit them unless they're attacking, meaning other methods of movement should be used to get closer to them.")]
    public string enemyBios_providence_strategy2;
    [DefaultValue("Their open constitution is particularly susceptible to the internal explosions of the Rocket Launcher, and though they can be tricky to hit consistently, the Attractor Nailgun's magnets can home rockets in.\n\nIn particular, the SRS Cannon's cannonball can shatter them in a single hit when fired at full power.")]
    public string enemyBios_providence_strategy3;
    public string enemyBios_providence_strategy4;

    // Power
    [DefaultValue("Much like the other archangels, Gabriel had a radiance that inspired many followers, the most numerous of which were the Powers, who acted as his disciples.")]
    public string enemyBios_power_1;
    [DefaultValue("Ashamed of their incomplete bodies, they use a part of their energy to always carry a useless gold arm with them in order to look more like the fully formed archangels they aspire to be.")]
    public string enemyBios_power_2;
    [DefaultValue("While Heaven's tastes began to trend towards ornateness and decoration, Gabriel stuck with the simpler old style of armor as a sign of discipline. Though Powers initially followed suit, in his absence in having become the Judge of Hell, their standards gradually slipped and they adopted the vanity of their peers.")]
    public string enemyBios_power_3;
    [DefaultValue("Although some of their voices may seem distinctly feminine to humans, angels are neither male nor female, as they cannot reproduce, leading to no such biological division. Still, masculine language is used as a sign of respect towards greater angels as a sign of their closeness to the Father.")]
    public string enemyBios_power_4;
    [DefaultValue("Powers trained under Gabriel, and as such have similar strengths and weaknesses, including the pride that leaves them open while taunting.")]
    public string enemyBios_power_strategy1;
    [DefaultValue("Lacking Gabriel's extensive first-hand experience in combat, Powers are far more vulnerable to parries, which will momentarily disable them entirely, though they will become more aggressive afterwards out of shame.")]
    public string enemyBios_power_strategy2;
    [DefaultValue("Likewise, due to their lack of practice, they have to vocalize in order to manifest weapons of light correctly, making it easier for an opponent to predict what they are about to do.")]
    public string enemyBios_power_strategy3;
    [DefaultValue("When fighting in a group against a single target, Powers have been trained to take turns in order to avoid friendly fire and more easily distinguish who gets the glory of victory, so it is best to not attack ones waiting for their turn to avoid additional retaliation.")]
    public string enemyBios_power_strategy4;

    // Geryon
    [DefaultValue("An ancient demon that roams the Fraud layer, Geryon has remained vigilant and active for millenia, hunting for sinners with a grand bow it itself constructed.")]
    public string enemyBios_geryon_1;
    [DefaultValue("What at first seemed a failed experiment by an unknown force to create a single being controlled by multiple consciousnesses simultaneously, it remains a fascination as a remarkable example of behavioural acclimatization.")]
    public string enemyBios_geryon_2;
    [DefaultValue("Despite being completely unable to communicate with each other, Geryon's consciousnesses have learned to work together in perfect harmony thanks to their shared goal, and hunt with frightening efficiency despite their unfit body often failing them.")]
    public string enemyBios_geryon_3;
    [DefaultValue("Although only an unproven fringe theory, some have proposed that part of Geryon's incredible development may be a difference in motivation from other demons: perhaps Geryon hunts not for sport, but to free sinners from their suffering.")]
    public string enemyBios_geryon_4;
    [DefaultValue("Geryon's multiple consciousnesses give it an incredible ability to perform many complex tasks simultaneously, allowing it to defend itself from close-range threats while still attacking, making it unwise to approach it.")]
    public string enemyBios_geryon_strategy1;
    
    [DefaultValue("Extracting blood from its body may seem impossible outside of its momentary lapses, but Providences in the immediate area leave behind small soul orbs which can be rationed by smart fighters for healing during the fight.")]
    public string enemyBios_geryon_strategy3;
    [DefaultValue("Despite it functioning at all being an incredible feat, Geryon's body is unable to properly support its biological and psychological density, causing it to overheat under continued stress, leaving it wide open for a barrage of attacks.")]
    public string enemyBios_geryon_strategy2;

    // Mirror Reaper
    [DefaultValue("Due to its illusory nature, very little is known about the 8th layer of Hell. Even its punishment remains shrouded in mystery.")]
    public string enemyBios_mirrorReaper_1;
    [DefaultValue("Extended exposure to the layer, which seems like picturesque recreation of a New Peace community on the surface, causes eventual total collapse of sensory information and physical space, after which all connection is lost.")]
    public string enemyBios_mirrorReaper_2;
    [DefaultValue("The only point of reference is the elusive Mirror Reaper, an amalgamation of multiple husks arranged in a deliberate, twisted fashion, which seems to exist between spaces, often inside reflections, hence its name.")]
    public string enemyBios_mirrorReaper_3;
    [DefaultValue("Although this example could be used to draw conclusions about the fates of the layer's inhabitants, it's important to keep in mind that this instance is the only of its kind to ever be seen, which may imply that whatever happened to everyone else was far, far worse.")]
    public string enemyBios_mirrorReaper_4;
    [DefaultValue("The Mirror Reaper's height and speed make it an imposing opponent, but its poor motor control gives shorter opponents an advantage in passing under its swings.")]
    public string enemyBios_mirrorReaper_strategy1;
    [DefaultValue("When the Mirror Reaper escapes, the hands it summons can be followed back to their source to find it.")]
    public string enemyBios_mirrorReaper_strategy2;
    [DefaultValue("The summoned hands can be destroyed with projectiles, but explosions do not damage them.\n\n- When in grave danger, the Mirror Reaper can escape into a fold in space, making it only visible through reflections.")]
    public string enemyBios_mirrorReaper_strategy3;
    public string enemyBios_mirrorReaper_strategy4;

    // Deathcatcher
    [DefaultValue("Distant eyes watched the formation of the Idols with fascination, and were driven to attempt the same process of molding useless life into something beautiful.")]
    public string enemyBios_deathcatcher_1;
    [DefaultValue("The result, however, could never have been the same, as the endless malice of their creator seeped into the Deathcatchers, whose shells were unable to withhold it, cracking them wide open.")]
    public string enemyBios_deathcatcher_2;
    [DefaultValue("Unable to share love that they were never given, the Deathcatchers cannot protect anyone, and in their vain attempts to do so, they can only form lesser caricatures from the blood of those who are gone forever, puppeting their shapes to continue their past actions, pretending that they're still here, that they could have been saved.")]
    public string enemyBios_deathcatcher_3;
    [DefaultValue("")]
    public string enemyBios_deathcatcher_4;
    [DefaultValue("Puppets are slower and only half as durable as the creatures they are mimicking.")]
    public string enemyBios_deathcatcher_strategy1;
    [DefaultValue("Although puppets do not grant style points, their blood can still be used to heal, making weak puppets an easy source for quick recovery.")]
    public string enemyBios_deathcatcher_strategy2;
    [DefaultValue("While each pulse will create puppets from every fallen foe nearby, the Deathcatchers require time to ready another pulse, meaning the best time to destroy a troublesome puppet is immediately after a previous pulse to maximize the time they lay dormant.")]
    public string enemyBios_deathcatcher_strategy3;
}

public class Subtitles
{
    [DefaultValue("Machine")]
    public string subtitles_gabriel_intro1;
    [DefaultValue("Turn back now.")]
    public string subtitles_gabriel_intro2;
    [DefaultValue("The layers of this palace are not for your kind")]
    public string subtitles_gabriel_intro3;
    [DefaultValue("Turn back or you will be crossing the will of God")]
    public string subtitles_gabriel_intro4;
    [DefaultValue("Your choice is made")]
    public string subtitles_gabriel_intro5;
    [DefaultValue("As the righteous hand of the father")]
    public string subtitles_gabriel_intro6;
    [DefaultValue("I shall rend you apart")]
    public string subtitles_gabriel_intro7;
    [DefaultValue("And you will become inanimate once more")]
    public string subtitles_gabriel_intro8;
    [DefaultValue("")]
    public string subtitles_gabriel_intro9;
    [DefaultValue("BEHOLD! THE POWER OF AN ANGEL")]
    public string subtitles_gabriel_fightStart;

    [DefaultValue("The light is perfection")]
    public string subtitles_gabriel_taunt1;
    [DefaultValue("You defy the light")]
    public string subtitles_gabriel_taunt2;
    [DefaultValue("A mere object")]
    public string subtitles_gabriel_taunt3;
    [DefaultValue("Not. Even. Mortal.")]
    public string subtitles_gabriel_taunt4;
    [DefaultValue("You are less than nothing")]
    public string subtitles_gabriel_taunt5;
    [DefaultValue("Foolishness, machine. Foolishness.")]
    public string subtitles_gabriel_taunt6;
    [DefaultValue("You're an error to be corrected")]
    public string subtitles_gabriel_taunt7;
    [DefaultValue("There can be only light")]
    public string subtitles_gabriel_taunt8;
    [DefaultValue("An imperfection to be cleansed")]
    public string subtitles_gabriel_taunt9;
    [DefaultValue("Your crime is existence")]
    public string subtitles_gabriel_taunt10;
    [DefaultValue("You make even the devil cry")]
    public string subtitles_gabriel_taunt11;
    [DefaultValue("You are outclassed")]
    public string subtitles_gabriel_taunt12;

    [DefaultValue("Enough!")]
    public string subtitles_gabriel_phaseChange;

    [DefaultValue("What..?")]
    public string subtitles_gabriel_defeated1;
    [DefaultValue("How can this be?")]
    public string subtitles_gabriel_defeated2;
    [DefaultValue("Bested by this...")]
    public string subtitles_gabriel_defeated3;
    [DefaultValue("this thing..?")]
    public string subtitles_gabriel_defeated4;
    [DefaultValue("You insignificant FUCK!")]
    public string subtitles_gabriel_defeated5;
    [DefaultValue("THIS IS NOT OVER!")]
    public string subtitles_gabriel_defeated6;
    [DefaultValue("May your woes be many")]
    public string subtitles_gabriel_defeated7;
    [DefaultValue("and your days few")]
    public string subtitles_gabriel_defeated8;

    [DefaultValue("Finally, our waiting puzzle is over")]
    public string subtitles_mandalore_intro1;
    [DefaultValue("What")]
    public string subtitles_mandalore_intro2;

    [DefaultValue("Full auto")]
    public string subtitles_mandalore_attack1;
    [DefaultValue("Fuller auto")]
    public string subtitles_mandalore_attack2;

    [DefaultValue("I'm going to fucking poison you")]
    public string subtitles_mandalore_taunt1;
    [DefaultValue("I'm gonna shoot em with a gun")]
    public string subtitles_mandalore_taunt2;
    [DefaultValue("You cannot imagine what you'll face here")]
    public string subtitles_mandalore_taunt3;
    [DefaultValue("Hold still")]
    public string subtitles_mandalore_taunt4;
    [DefaultValue("Why are we in the past")]
    public string subtitles_mandalore_taunt5;

    [DefaultValue("Through the magic of the Druids, I increase my speed!")]
    public string subtitles_mandalore_phaseChangeFirst1;
    [DefaultValue("Just fucking hit em")]
    public string subtitles_mandalore_phaseChangeFirst2;
    [DefaultValue("Feel my maximum speed!")]
    public string subtitles_mandalore_phaseChangeSecond1;
    [DefaultValue("Slow down!")]
    public string subtitles_mandalore_phaseChangeSecond2;
    [DefaultValue("Use the salt!")]
    public string subtitles_mandalore_phaseChangeThird1;
    [DefaultValue("I'm reaching!")]
    public string subtitles_mandalore_phaseChangeThird2;

    [DefaultValue("Oh great, now we lost the fight, fantasic")]
    public string subtitles_mandalore_defeated;

    [DefaultValue("Aah...")]
    public string subtitles_minosPrime_intro1;
    [DefaultValue("Free at last")]
    public string subtitles_minosPrime_intro2;
    [DefaultValue("O Gabriel")]
    public string subtitles_minosPrime_intro3;
    [DefaultValue("Now dawns thy reckoning")]
    public string subtitles_minosPrime_intro4;
    [DefaultValue("and thy gore shall glisten before the temples of man")]
    public string subtitles_minosPrime_intro5;
    [DefaultValue("Creature of steel...")]
    public string subtitles_minosPrime_intro6;
    [DefaultValue("My gratitude upon thee for my freedom")]
    public string subtitles_minosPrime_intro7;
    [DefaultValue("but the crimes thy kind have committed against humanity")]
    public string subtitles_minosPrime_intro8;
    [DefaultValue("are NOT forgotten")]
    public string subtitles_minosPrime_intro9;
    [DefaultValue("And thy punishment...")]
    public string subtitles_minosPrime_intro10;
    [DefaultValue("is DEATH")]
    public string subtitles_minosPrime_intro11;

    [DefaultValue("Prepare thyself!")]
    public string subtitles_minosPrime_attack1;
    [DefaultValue("Thy end is now!")]
    public string subtitles_minosPrime_attack2;
    [DefaultValue("Die!")]
    public string subtitles_minosPrime_attack3;
    [DefaultValue("Crush!")]
    public string subtitles_minosPrime_attack4;
    [DefaultValue("Judgement!")]
    public string subtitles_minosPrime_attack5;

    [DefaultValue("Useless")]
    public string subtitles_minosPrime_taunt1;

    [DefaultValue("WEAK")]
    public string subtitles_minosPrime_phaseChange;

    [DefaultValue("Aagh!")]
    public string subtitles_minosPrime_defeated1;
    [DefaultValue("Forgive me my children")]
    public string subtitles_minosPrime_defeated2;
    [DefaultValue("for I have failed to bring you salvation")]
    public string subtitles_minosPrime_defeated3;
    [DefaultValue("from this cold, dark world")]
    public string subtitles_minosPrime_defeated4;
    [DefaultValue("Aagh!")]
    public string subtitles_minosPrime_deathScream;

    [DefaultValue("This prison...")]
    public string subtitles_sisyphusPrime_preIntro1;
    [DefaultValue("To hold")]
    public string subtitles_sisyphusPrime_preIntro2;
    [DefaultValue("ME?")]
    public string subtitles_sisyphusPrime_preIntro3;

    [DefaultValue("A visitor?")]
    public string subtitles_sisyphusPrime_intro1;
    [DefaultValue("Hmm... Indeed, I have slept long enough.")]
    public string subtitles_sisyphusPrime_intro2;
    [DefaultValue("The kingdom of heaven has long since forgotten my name")]
    public string subtitles_sisyphusPrime_intro3;
    [DefaultValue("And I am EAGER to make them remember")]
    public string subtitles_sisyphusPrime_intro4;
    [DefaultValue("However")]
    public string subtitles_sisyphusPrime_intro5;
    [DefaultValue("The blood of Minos stains your hands, and I must admit...")]
    public string subtitles_sisyphusPrime_intro6;
    [DefaultValue("I'm curious about your skills, Weapon.")]
    public string subtitles_sisyphusPrime_intro7;
    [DefaultValue("And so, before I tear down the cities and CRUSH the armies of heaven...")]
    public string subtitles_sisyphusPrime_intro8;
    [DefaultValue("You shall do as an appetizer.")]
    public string subtitles_sisyphusPrime_intro9;
    [DefaultValue("Come forth, Child of Man...")]
    public string subtitles_sisyphusPrime_intro10;
    [DefaultValue("And DIE.")]
    public string subtitles_sisyphusPrime_intro11;

    [DefaultValue("Nice try!")]
    public string subtitles_sisyphusPrime_attack1;
    [DefaultValue("BE GONE!")]
    public string subtitles_sisyphusPrime_attack2;
    [DefaultValue("You can't escape!")]
    public string subtitles_sisyphusPrime_attack3;
    [DefaultValue("DESTROY!")]
    public string subtitles_sisyphusPrime_attack4;
    [DefaultValue("This will hurt.")]
    public string subtitles_sisyphusPrime_attack5;

    [DefaultValue("YES! That's it!")]
    public string subtitles_sisyphusPrime_phaseChange;
    [DefaultValue("Keep them coming!")]
    public string subtitles_sisyphusPrime_respawnIntro;

    [DefaultValue("Ahh...")]
    public string subtitles_sisyphusPrime_defeated1;
    [DefaultValue("So concludes the life and times of King Sisyphus")]
    public string subtitles_sisyphusPrime_defeated2;
    [DefaultValue("A fitting end to an existence defined by futile struggle,")]
    public string subtitles_sisyphusPrime_defeated3;
    [DefaultValue("Doomed from the very start...")]
    public string subtitles_sisyphusPrime_defeated4;
    [DefaultValue("And I don't regret a SECOND of it!")]
    public string subtitles_sisyphusPrime_defeated5;

    [DefaultValue("Be not afraid, sinner")]
    public string subtitles_gabrielBoat1;
    [DefaultValue("Your devotion to God shows goodness in you")]
    public string subtitles_gabrielBoat2;
    [DefaultValue("Plentiful indeed")]
    public string subtitles_gabrielBoat3;
    [DefaultValue("The heart is willing, but the body must rest")]
    public string subtitles_gabrielBoat4;
    [DefaultValue("Lest you squander one of the Lord's creation.")]
    public string subtitles_gabrielBoat5;

    [DefaultValue("Machine, I know you're here")]
    public string subtitles_gabrielHeresy1;
    [DefaultValue("I can smell the insolent stench of your bloodstained hands")]
    public string subtitles_gabrielHeresy2;
    [DefaultValue("I await you down below...")]
    public string subtitles_gabrielHeresy3;
    [DefaultValue("COME TO ME")]
    public string subtitles_gabrielHeresy4;

    [DefaultValue("Limbo")]
    public string subtitles_gabrielSecondIntro1;
    [DefaultValue("Lust")]
    public string subtitles_gabrielSecondIntro2;
    [DefaultValue("All gone...")]
    public string subtitles_gabrielSecondIntro3;
    [DefaultValue("With Gluttony soon to follow.")]
    public string subtitles_gabrielSecondIntro4;
    [DefaultValue("Your kind know nothing but hunger")]
    public string subtitles_gabrielSecondIntro5;
    [DefaultValue("Purged all life on the upper layers")]
    public string subtitles_gabrielSecondIntro6;
    [DefaultValue("And yet they remain unsatiated...")]
    public string subtitles_gabrielSecondIntro7;
    [DefaultValue("As do you.")]
    public string subtitles_gabrielSecondIntro8;
    [DefaultValue("You've taken everything from me, machine")]
    public string subtitles_gabrielSecondIntro9;
    [DefaultValue("And now all that remains is")]
    public string subtitles_gabrielSecondIntro10;
    [DefaultValue("PERFECT")]
    public string subtitles_gabrielSecondIntro11;
    [DefaultValue("HATRED")]
    public string subtitles_gabrielSecondIntro12;

    [DefaultValue("Machine")]
    public string subtitles_gabrielSecondFight1;
    [DefaultValue("I will cut you down")]
    public string subtitles_gabrielSecondFight2;
    [DefaultValue("Break you apart")]
    public string subtitles_gabrielSecondFight3;
    [DefaultValue("Splay the gore of your profane form across the STARS!")]
    public string subtitles_gabrielSecondFight4;
    [DefaultValue("I will grind you down until the very sparks CRY FOR MERCY!")]
    public string subtitles_gabrielSecondFight5;
    [DefaultValue("My hands shall RELISH ENDING YOU...")]
    public string subtitles_gabrielSecondFight6;
    [DefaultValue("HERE")]
    public string subtitles_gabrielSecondFight7;
    [DefaultValue("AND")]
    public string subtitles_gabrielSecondFight8;
    [DefaultValue("NOW!")]
    public string subtitles_gabrielSecondFight9;

    [DefaultValue("IS THAT THE BEST YOU'VE GOT!?")]
    public string subtitles_gabrielSecondPhaseChange;

    [DefaultValue("YOU NEED. MORE. POWER!")]
    public string subtitles_gabrielSecondTaunt1;
    [DefaultValue("Come get some BLOOD!")]
    public string subtitles_gabrielSecondTaunt2;
    [DefaultValue("What is this FEELING?")]
    public string subtitles_gabrielSecondTaunt3;
    [DefaultValue("NOTHING BUT SCRAP!")]
    public string subtitles_gabrielSecondTaunt4;
    [DefaultValue("YOU'RE GETTING RUSTY, MACHINE!")]
    public string subtitles_gabrielSecondTaunt5;
    [DefaultValue("IS THIS WHAT I LOST TO!?")]
    public string subtitles_gabrielSecondTaunt6;
    [DefaultValue("TIME TO RIGHT MY WRONG!")]
    public string subtitles_gabrielSecondTaunt7;
    [DefaultValue("LET'S SETTLE THIS!")]
    public string subtitles_gabrielSecondTaunt8;
    [DefaultValue("I'LL SHOW YOU DIVINE JUSTICE!")]
    public string subtitles_gabrielSecondTaunt9;
    [DefaultValue("Come on, machine! Fight me like an ANIMAL!")]
    public string subtitles_gabrielSecondTaunt10;
    [DefaultValue("I've never had a fight like this before!")]
    public string subtitles_gabrielSecondTaunt11;
    [DefaultValue("Show me what you were made for!")]
    public string subtitles_gabrielSecondTaunt12;
    [DefaultValue("Now THIS is a fight worthy of God's Will!")]
    public string subtitles_gabrielSecondTaunt13;
    [DefaultValue("I'll show you TRUE splendor!")]
    public string subtitles_gabrielSecondTaunt14;

    [DefaultValue("Twice!?")]
    public string subtitles_gabrielSecondDefeated1;
    [DefaultValue("Beaten by an object... Twice!")]
    public string subtitles_gabrielSecondDefeated2;
    [DefaultValue("I've only known the taste of victory,")]
    public string subtitles_gabrielSecondDefeated3;
    [DefaultValue("But this taste... Is-")]
    public string subtitles_gabrielSecondDefeated4;
    [DefaultValue("Is this my blood?")]
    public string subtitles_gabrielSecondDefeated5;
    [DefaultValue("I've never known such...")]
    public string subtitles_gabrielSecondDefeated6;
    [DefaultValue("Such... relief..?")]
    public string subtitles_gabrielSecondDefeated7;
    [DefaultValue("I- I need some time to think...")]
    public string subtitles_gabrielSecondDefeated8;
    [DefaultValue("We will meet again, machine")]
    public string subtitles_gabrielSecondDefeated9;
    [DefaultValue("May your woes be many...")]
    public string subtitles_gabrielSecondDefeated10;
    [DefaultValue("and your days few")]
    public string subtitles_gabrielSecondDefeated11;
    [DefaultValue("")]
    public string subtitles_gabrielSecondDefeated12;

    [DefaultValue("Be afraid, machine.")]
    public string subtitles_power_intro_0;
    [DefaultValue("Here shall be your grave.")]
    public string subtitles_power_intro_1;
    [DefaultValue("It is over, machine!")]
    public string subtitles_power_intro_2;
    [DefaultValue("Surrender or perish!")]
    public string subtitles_power_intro_3;
    [DefaultValue("Lay down and die!")]
    public string subtitles_power_intro_4;
    [DefaultValue("Bastard!")]
    public string subtitles_power_enrage_0;
    [DefaultValue("You piece of SHIT!")]
    public string subtitles_power_enrage_1;
    [DefaultValue("Just DIE already!")]
    public string subtitles_power_enrage_2;
    [DefaultValue("Why won't you die!?")]
    public string subtitles_power_enrage_3;
    [DefaultValue("God DAMN it!")]
    public string subtitles_power_enrage_4;
    [DefaultValue("This lowly thing could never have bested him!")]
    public string subtitles_power_taunt_0;
    [DefaultValue("An inconvenience at best.")]
    public string subtitles_power_taunt_1;
    [DefaultValue("This is a waste of my time!")]
    public string subtitles_power_taunt_2;
    [DefaultValue("Just another worthless object.")]
    public string subtitles_power_taunt_3;
    [DefaultValue("")]
    public string subtitles_power_taunt_4;
    [DefaultValue("PAY ATTENTION!")]
    public string subtitles_power_cheapShot_0;
    [DefaultValue("Wait your TURN!")]
    public string subtitles_power_cheapShot_1;
    [DefaultValue("WRONG TARGET!")]
    public string subtitles_power_cheapShot_2;
    [DefaultValue("Rapier!")]
    public string subtitles_power_rapier;
    [DefaultValue("Greatsword!")]
    public string subtitles_power_greatsword;
    [DefaultValue("Spear!")]
    public string subtitles_power_spear;
    [DefaultValue("Over here!")]
    public string subtitles_power_spearThrow;
    [DefaultValue("Glaive!")]
    public string subtitles_power_glaive;
    [DefaultValue("Take THIS!")]
    public string subtitles_power_glaiveThrow;
    [DefaultValue("HALT!")]
    public string subtitles_power_specialWave1_1;
    [DefaultValue("Where is Gabriel and what have you done to him?")]
    public string subtitles_power_specialWave1_2;
    [DefaultValue("Enough!")]
    public string subtitles_power_specialWave2_1;
    [DefaultValue("Your insolence must be punished.")]
    public string subtitles_power_specialWave2_2;
    [DefaultValue("There is no escape from Gabriel's children.")]
    public string subtitles_power_specialWave3;
    [DefaultValue("WHERE IS HE!?")]
    public string subtitles_power_specialWave4;

    public string GetField(string name)
    {
        var field = typeof(Subtitles).GetField(name, BindingFlags.Public | BindingFlags.Instance);
        return (string)field.GetValue(this);
    }
}

public class VisualNovel
{
    [DefaultValue("JUST SOMEONE")]
    public string visualnovel_mirageName1;
    [DefaultValue("THE PRETTIEST GIRL IN TOWN")]
    public string visualnovel_mirageName2;
    [DefaultValue("MIRAGE")]
    public string visualnovel_mirageName3;

    [DefaultValue("Heavy steps, ragged breathing. ")]
    public string visualnovel_introFirst1;
    [DefaultValue("There isn't much time left. ")]
    public string visualnovel_introFirst2;
    [DefaultValue("It might already be too late. ")]
    public string visualnovel_introFirst3;
    [DefaultValue("The labyrinthine pathways of arbitrary sharp turns seemed stranger and stranger as panic blotted out the once deeply ingrained memories that usually guided me. ")]
    public string visualnovel_introFirst4;
    [DefaultValue("Every corner felt a stranger. ")]
    public string visualnovel_introFirst5;
    [DefaultValue("Every straight line too long. ")]
    public string visualnovel_introFirst6;
    [DefaultValue("The bell tolls for me.")]
    public string visualnovel_introFirst7;

    [DefaultValue("I bit down harder on the last of my rations, held only by the skin of my teeth. ")]
    public string visualnovel_introSecond1;
    [DefaultValue("It barely hung on as I kept frantically looking around, hoping for the few scraps of burning memory of mine to find a familiar sight that would lead me to salvation. ")]
    public string visualnovel_introSecond2;
    [DefaultValue("\nThe gates must be closing by now. ")]
    public string visualnovel_introSecond3;
    [DefaultValue("The last few barely making it. ")]
    public string visualnovel_introSecond4;
    [DefaultValue("The rest of us never stood a chance. ")]
    public string visualnovel_introSecond5;
    [DefaultValue("Suddenly, from a blind spot,  a figure struck me. ")]
    public string visualnovel_introSecond6;
    [DefaultValue("There was no time to react before I came crashing down onto the cold hard ground. ")]
    public string visualnovel_introSecond7;
    [DefaultValue("\nI struggled to regain my senses to at least see what fate would befall me in my final moments, but even in this abyss of endless terror, my mind could never have imagined the horror I witnessed. ")]
    public string visualnovel_introSecond8;

    [DefaultValue("\"Oof ow ouch that stings\" ")]
    public string visualnovel_fallen1;
    [DefaultValue("\"Who are you?\"")]
    public string visualnovel_fallenPromptFirst1;
    [DefaultValue("\"Are you OK?\"")]
    public string visualnovel_fallenPromptFirst2;
    [DefaultValue("Fidget nervously and sweat profusely")]
    public string visualnovel_fallenPromptFirst3;

    [DefaultValue("\"I'm just someone who got knocked over by some half-brained fuckface who doesn't even have the decency to ask if I'm fine or apologize before starting an interrogation.\" ")]
    public string visualnovel_fallenResponseFirst;
    [DefaultValue("\"Well I just got knocked over by some blind-by-choice asshole who gave my skirt a decorative dirt coating, so all in all fucking fantastic, though I would prefer to not be on the ground right now.\" ")]
    public string visualnovel_fallenResponseSecond;
    [DefaultValue("\"Oh great I just got hit-and-ran by a vibrating fountain, just my luck. ")]
    public string visualnovel_fallenResponseThird1;
    [DefaultValue("At least you could help me up before the rest of you gets melted by the sun or jackhammers itself into the Earth's mantle.\" ")]
    public string visualnovel_fallenResponseThird2;

    [DefaultValue("Help her up")]
    public string visualnovel_fallenPromptSecond1;
    [DefaultValue("\"Not with an attitude like that.\"")]
    public string visualnovel_fallenPromptSecond2;
    [DefaultValue("\"Sorry, my fault\"")]
    public string visualnovel_fallenPromptSecond3;

    [DefaultValue("\"Alright, alright.\" ")]
    public string visualnovel_fallenResponseFourth;
    [DefaultValue("\"UGH.\" ")]
    public string visualnovel_fallenResponseFifth;



    [DefaultValue("*Sigh*... ")]
    public string visualnovel_kindFirst1;
    [DefaultValue("\"Hey, sorry about being rude like that, I'm just real frustrated that I'm not only late for school, but also managed to get lost on the way there.\" ")]
    public string visualnovel_kindFirst2;
    [DefaultValue("\"Though, by the looks of it, you're pretty much on the same boat, and by a stroke of once-in-a-lifetime luck you just happened to bump into the ~prettiest girl in town~.\" ")]
    public string visualnovel_kindSecond;
    [DefaultValue("So how about you lead the way and get both of us out of this jam?")]
    public string visualnovel_kindThird;

    [DefaultValue("\"Listen up, dickhead. ")]
    public string visualnovel_rudeFirst1;
    [DefaultValue("I don't know who you are but you've got a lot of nerve smacking someone down and not even bothering to help them back up, but since your mother didn't teach you manners, I'll let this one slide.\" ")]
    public string visualnovel_rudeFirst2;
    [DefaultValue("\"By the looks of it, you're late for school as well, and by a stroke of once-in-a-lifetime luck you just happened to bump into the prettiest girl in town.\" ")]
    public string visualnovel_rudeSecond;
    [DefaultValue("\"So I'll forgive you for your extreme transgression of laying your hands on a fair maiden if you tell me which way to go, since I seem to have gotten lost on the way.\" ")]
    public string visualnovel_rudeThird;

    [DefaultValue("\"Actually, I'm lost too.\"")]
    public string visualnovel_middlePrompt1;
    [DefaultValue("\"Don't wanna.\"")]
    public string visualnovel_middlePrompt2;
    [DefaultValue("\"I don't go to school.\"")]
    public string visualnovel_middlePrompt3;

    [DefaultValue("\"UGH! Just my luck.\" ")]
    public string visualnovel_middleResponseFirst1;
    [DefaultValue("\"Though in retrospect, I guess you wouldn't be here with me right now if you weren't lost as well...\" ")]
    public string visualnovel_middleResponseFirst2;
    [DefaultValue("\"Oh well, no point in crying over spilled blood. ")]
    public string visualnovel_middleResponseFirst3;
    [DefaultValue("We might as well just wait for another student to come by and follow them instead.\" ")]
    public string visualnovel_middleResponseFirst4;
    [DefaultValue("\"I'm Mirage. ")]
    public string visualnovel_middleResponseFirst5;
    [DefaultValue("Don't bother telling me your name though, I don't really care.\" ")]
    public string visualnovel_middleResponseFirst6;

    [DefaultValue("\"WHAT? ")]
    public string visualnovel_middleResponseSecond1;
    [DefaultValue("THE FUCK DO YOU MEAN 'DON'T WANNA'?\" ")]
    public string visualnovel_middleResponseSecond2;
    [DefaultValue("\"If you DON'T show me the way then YOU'RE never arriving either! ")]
    public string visualnovel_middleResponseSecond3;
    [DefaultValue("Or did that thought not even cross your crayon-fed brain cavity!?\" ")]
    public string visualnovel_middleResponseSecond4;

    [DefaultValue("\"Bullshit!")]
    public string visualnovel_middleResponseThird1;
    [DefaultValue("Cut the crap, I can see your crusty-ass uniform and no living person would dare to go out looking like a filled trash bag by choice!\" ")]
    public string visualnovel_middleResponseThird2;
    [DefaultValue("\"Though considering how little activity there actually is inside your skull, I'm willing to admit you sure as hell don't seem like you've ever been to school.\" ")]
    public string visualnovel_middleResponseThird3;

    [DefaultValue("\"You could do with being a bit nicer to people you've\nonly just met.\"")]
    public string visualnovel_middlePromptSecondRecklessness;
    [DefaultValue("\"Just waiting here won't get us anywhere, we should be looking for a way to the school.\"")]
    public string visualnovel_middlePromptSecondWaiting;

    [DefaultValue("\"Yeah? Well you could do with a beatdown, so fuck off.\" ")]
    public string visualnovel_recklessnessFirst;
    [DefaultValue("\"But yes, you're right. ")]
    public string visualnovel_recklessnessSecond1;
    [DefaultValue("I don't really care about what you or anyone else thinks of me, so I'm not interested in trying to be nice just so you'll be in a good mood.\" ")]
    public string visualnovel_recklessnessSecond2;

    [DefaultValue("\"Why not? If we're stuck in here together anyway, what's the point in making it worse for both of us?\"")]
    public string visualnovel_recklessnessPrompt1;
    [DefaultValue("\"I find that hard to believe considering how heated up you get from practically anything I say.\"")]
    public string visualnovel_recklessnessPrompt2;

    [DefaultValue("\"What's the point of making it better? ")]
    public string visualnovel_recklessnessResponseFirst1;
    [DefaultValue("What's the point of even bothering to care? ")]
    public string visualnovel_recklessnessResponseFirst2;
    [DefaultValue("Hell, what's the point of anything at all? ")]
    public string visualnovel_recklessnessResponseFirst3;
    [DefaultValue("Nothing. ")]
    public string visualnovel_recklessnessResponseFirst4;
    [DefaultValue("Absolutely nothing.\" ")]
    public string visualnovel_recklessnessResponseFirst5;

    [DefaultValue("\"Don't flatter yourself. ")]
    public string visualnovel_recklessnessResponseSecond1;
    [DefaultValue("Blowing off steam is just how I cope.\" ")]
    public string visualnovel_recklessnessResponseSecond2;

    [DefaultValue("\"Cope with what?\"")]
    public string visualnovel_recklessnessPrompt3;

    [DefaultValue("\"Everything.\" ")]
    public string visualnovel_recklessnessResponseThird;

    [DefaultValue("\"Wandering around like headless chickens would only get us even more lost.\" ")]
    public string visualnovel_waitingFirst;
    [DefaultValue("\"Since we were both heading to school and ended up meeting right here, that means there's a very high likelihood this spot is somewhere along the way.\" ")]
    public string visualnovel_waitingSecond;
    [DefaultValue("\"Therefore, we'll be better off just staying put and waiting for someone who DOES know the way. ")]
    public string visualnovel_waitingThird1;
    [DefaultValue("It's basic logic, you should look it up sometime.\" ")]
    public string visualnovel_waitingThird2;

    [DefaultValue("\"Basic logic or not, we're already late and I'm not planning on waiting here until tomorrow morning.\"")]
    public string visualnovel_waitingPromptFirst1;
    [DefaultValue("\"Anyone who knows the way will already have gone there. Sounds to me like you're just looking for an excuse to give up.\"")]
    public string visualnovel_waitingPromptFirst2;

    [DefaultValue("\"Suit yourself. I'll stay here until the heat death of the universe if that means I don't have to run around looking for some magical memory-triggering pebble on the ground.\" ")]
    public string visualnovel_waitingResponseFirst1;
    [DefaultValue("\"Couldn't care less about being late for school. ")]
    public string visualnovel_waitingResponseFirst2;
    [DefaultValue("School doesn't matter anyway. ")]
    public string visualnovel_waitingResponseFirst3;
    [DefaultValue("Nothing does.\" ")]
    public string visualnovel_waitingResponseFirst4;

    [DefaultValue("\"Hah! ")]
    public string visualnovel_waitingResponseSecond1;
    [DefaultValue("Can't give up if I never tried in the first place, and I don't make a habit out of trying.\" ")]
    public string visualnovel_waitingResponseSecond2;

    [DefaultValue("\"Why not?\"")]
    public string visualnovel_waitingPromptThird;
    [DefaultValue("\"Because nothing matters. ")]
    public string visualnovel_waitingResponseThird1;
    [DefaultValue("There's no point in trying if the end result will be the same anyway. ")]
    public string visualnovel_waitingResponseThird2;
    [DefaultValue("Try as you might, you'll eventually just become forgotten dust in the wind like the rest of us.\" ")]
    public string visualnovel_waitingResponseThird3;

    [DefaultValue("\"I mean really, take a moment to think about it.\" ")]
    public string visualnovel_nihilism1;
    [DefaultValue("\"The human mind, in its complete vastness, is capable of recognizing its utter helplessness and uselessness in the face of inevitable and unavoidable non-existence, but is incapable of coming to terms with it.\" ")]
    public string visualnovel_nihilism2;
    [DefaultValue("\"We can only ever ignore it, hide from it or temporarily escape from it, but the fact is that we are bound to the way of all things.\" ")]
    public string visualnovel_nihilism3;
    [DefaultValue("\"Death is unavoidable, not only to us, but all that exists or ever has existed. ")]
    public string visualnovel_nihilism4;
    [DefaultValue("Every living being will eventually die out. ")]
    public string visualnovel_nihilism5;
    [DefaultValue("Every speck of matter will eventually wither away and dissipate into entropy.\" ")]
    public string visualnovel_nihilism6;
    [DefaultValue("\"It doesn't matter if you lived a good life or if you left a legacy behind. ")]
    public string visualnovel_nihilism7;
    [DefaultValue("It doesn't matter if humanity survives for a thousand years or dies out tomorrow.")]
    public string visualnovel_nihilism8;
    [DefaultValue("The end result is the same: the absolute nothing.\" ")]
    public string visualnovel_nihilism9;
    [DefaultValue("\"Human intelligence is far beyond that of other animals, but it would be misguided to consider that a gift. ")]
    public string visualnovel_nihilism10;
    [DefaultValue("All other beings have the gift of ignorance, of not understanding what we do.\" ")]
    public string visualnovel_nihilism11;
    [DefaultValue("\"Our intelligence is not a gift. It's a flaw.\" ")]
    public string visualnovel_nihilism12;
    [DefaultValue("\"It's an over-extension of evolution. ")]
    public string visualnovel_nihilism13;
    [DefaultValue("Intelligence, once a great feature in aeons past, continued to grow unchecked and unfiltered, and has since passed a threshold whereupon it is no longer a benefit, but an active danger to its host.\" ")]
    public string visualnovel_nihilism14;
    [DefaultValue("\"Much like the Irish elk, a species of deer that, through uncountable generations of evolution, grew antlers so wide and vast that it could no longer run from predators, eventually leading to extinction.\" ")]
    public string visualnovel_nihilism15;
    [DefaultValue("\"The human mind is an evolutionary maladaptation caused by going too far in a direction that was once beneficial and will, sooner or later, lead to our extinction. ")]
    public string visualnovel_nihilism16;
    [DefaultValue("On an individual level, it's already happening.\" ")]
    public string visualnovel_nihilism17;
    [DefaultValue("\"Existential dread is already taking hold. ")]
    public string visualnovel_nihilism18;
    [DefaultValue("I'm sure you've felt it too. ")]
    public string visualnovel_nihilism19;
    [DefaultValue("The pain and fear of being nothing, becoming nothing. ")]
    public string visualnovel_nihilism20;
    [DefaultValue("The suffering of understanding that.\" ")]
    public string visualnovel_nihilism21;
    [DefaultValue("\"We are unable to come to terms with it, so we hide from our own intelligence. ")]
    public string visualnovel_nihilism22;
    [DefaultValue("We set limits. ")]
    public string visualnovel_nihilism23;
    [DefaultValue("We stop ourselves from thinking deeply about what will happen when we die.\" ")]
    public string visualnovel_nihilism24;
    [DefaultValue("\"We create distractions. ")]
    public string visualnovel_nihilism25;
    [DefaultValue("We keep our minds busy with mundane activities and entertainment to stop ourselves from having to come face-to-face with the truth.\" ")]
    public string visualnovel_nihilism26;
    [DefaultValue("\"We sublimate it. ")]
    public string visualnovel_nihilism27;
    [DefaultValue("We transform our self-reflective suffering into another form, art, to keep it from consuming us. ")]
    public string visualnovel_nihilism28;
    [DefaultValue("Anything to avoid the panic.\" ")]
    public string visualnovel_nihilism29;
    [DefaultValue("\"But these ways are all simply temporary. ")]
    public string visualnovel_nihilism30;
    [DefaultValue("They're just there to push back the inevitable veil of helplessness and despair that would encompass and ruin us.\" ")]
    public string visualnovel_nihilism31;
    [DefaultValue("\"In the end, nothing matters.")]
    public string visualnovel_nihilism32;
    [DefaultValue("There's no point in trying to find joy in life, for life in and of itself is suffering.\" ")]
    public string visualnovel_nihilism33;
    [DefaultValue("\"Huh?\" ")]
    public string visualnovel_nihilism34;
    [DefaultValue("\"How could it not be?\" ")]
    public string visualnovel_nihilism35;
    [DefaultValue("\"But still, in that case, the meaninglessness of our actions draws to the same conclusion -- There is no reason to act, for any action is simply a temporary fluctuation that will, nevertheless, lead to the same conclusion.\" ")]
    public string visualnovel_nihilism36;
    [DefaultValue("\"I do understand what you mean. ")]
    public string visualnovel_nihilism37;
    [DefaultValue("However, that doesn't ease my fear of the end. ")]
    public string visualnovel_nihilism38;
    [DefaultValue("Even if I were to try to find purpose, I would still be paralyzed by the thought of becoming nothing.\"")]
    public string visualnovel_nihilism39;
    [DefaultValue("\"I see. ")]
    public string visualnovel_nihilism40;
    [DefaultValue("Though as much as I'd like to embrace it, I am nevertheless struck with that paralyzing existential panic.\" ")]
    public string visualnovel_nihilism41;
    [DefaultValue("\"I understand it logically, and I know that there is no reason to live in apathy, but my emotional side refuses to listen. ")]
    public string visualnovel_nihilism42;
    [DefaultValue("The fear persists, and I cannot motivate myself to seek purpose, despite knowing I must.\" ")]
    public string visualnovel_nihilism43;

    [DefaultValue("\"You're wrong.\"")]
    public string visualnovel_nihilismPrompt1;
    [DefaultValue("\"You criticize those who consider our vast intelligence a gift, and yet, also misguide yourself to believe our meaninglessness is a curse.\"")]
    public string visualnovel_nihilismPrompt2;
    [DefaultValue("\"Nothing we do matters in the end, and that is precisely why we are not shackled by the burden of expectations, the fear of eternal judgement or the failure to meet up to an arbitrary definition of what makes our limited time 'not wasted'.\"")]
    public string visualnovel_nihilismPrompt3;
    [DefaultValue("\"Time cannot be wasted, for there is no greater purpose to life than simply living it.\"")]
    public string visualnovel_nihilismPrompt4;
    [DefaultValue("\"Quite the contrary.\"")]
    public string visualnovel_nihilismPrompt5;
    [DefaultValue("\"Because we have no greater purpose, we are free to set our own. To create self-defined goals for which to strive.\"")]
    public string visualnovel_nihilismPrompt6;
    [DefaultValue("\"For some it may be nothing. For some it may be pleasure. For some it may be creation. For some it may be improving the lives of others.\"")]
    public string visualnovel_nihilismPrompt7;
    [DefaultValue("\"It is because we have no greater purpose, that time spent on goals set by one's self cannot be time wasted.\"")]
    public string visualnovel_nihilismPrompt8;
    [DefaultValue("\"In the end, nothing matters, and therefore you have no reason not to do what you want rather than whatever illusion of greater purpose is forced on you by others or even your own misguided thoughts.\"")]
    public string visualnovel_nihilismPrompt9;
    [DefaultValue("\"And it is a thought worth fearing. However, abandoning purpose, hope, choice, goals, pleasure and will can not make that thought disappear. The fear, however, can subside.\"")]
    public string visualnovel_nihilismPrompt10;
    [DefaultValue("\"Giving up is not accepting the end, it is simply accepting the fear of it. It is embracing despair rather than facing it.\"")]
    public string visualnovel_nihilismPrompt11;
    [DefaultValue("\"This is true. The emotional is not controlled by the logical. However, they are interlinked.\"")]
    public string visualnovel_nihilismPrompt12;
    [DefaultValue("\"Just as the deepest, darkest depths of despair can overthrow reason and the logical, warping them to fit into that haze of depression, so too can reason influence and overpower emotion, regardless of how impenetrable its defences\nmay seem.\"")]
    public string visualnovel_nihilismPrompt13;
    [DefaultValue("\"By continually forcing to subvert those creeping negative thoughts with the positive logical ones, the emotional mind will eventually, slowly, gradually start to shape to fit the logical.\"")]
    public string visualnovel_nihilismPrompt14;
    [DefaultValue("\"It is not an easy job.\"")]
    public string visualnovel_nihilismPrompt15;
    [DefaultValue("\"It is not a quick job.\"")]
    public string visualnovel_nihilismPrompt16;
    [DefaultValue("\"It will sometimes feel like an impossible job.\"")]
    public string visualnovel_nihilismPrompt17;
    [DefaultValue("\"However, it can be done.\"")]
    public string visualnovel_nihilismPrompt18;
    [DefaultValue("\"With an immense amount of time, effort and energy, it will improve.\"")]
    public string visualnovel_nihilismPrompt19;
    [DefaultValue("\"You can change.\"")]
    public string visualnovel_nihilismPrompt20;
    [DefaultValue("\"You can heal.\"")]
    public string visualnovel_nihilismPrompt21;
    [DefaultValue("\"And during the hardest times, when all seems lost and you want to give up, never forget...\"")]
    public string visualnovel_nihilismPrompt22;
    [DefaultValue("\"We will always love you.\"")]
    public string visualnovel_nihilismPrompt23;
    [DefaultValue("\"Yeah, sure. I've got nothing better to do today. You're paying, though\"")]
    public string visualnovel_nihilismPrompt24;
    [DefaultValue("\"Nah, sorry. To be honest I'm still kinda mad at you for how rude you were to me.\"")]
    public string visualnovel_nihilismPrompt25;

    [DefaultValue("\"Well, I'll be damned.\" ")]
    public string visualnovel_conclusion1;
    [DefaultValue("\"Guess you got a good head on your shoulders after all. ")]
    public string visualnovel_conclusion2;
    [DefaultValue("Hell, I'm impressed.\" ")]
    public string visualnovel_conclusion3;
    [DefaultValue("\"Man... ")]
    public string visualnovel_conclusion4;
    [DefaultValue("I feel like I've just shed the weight of the world off my back. ")]
    public string visualnovel_conclusion5;
    [DefaultValue("Or rather, you've done that for me. ")]
    public string visualnovel_conclusion6;
    [DefaultValue("And honestly, from the bottom of my heart...\" ")]
    public string visualnovel_conclusion7;
    [DefaultValue("\"Thank you.\" ")]
    public string visualnovel_conclusion8;
    [DefaultValue("\"You've given me a lot to think about, and while I'm sure I have a long and hard road ahead of me, I'm optimistic. ")]
    public string visualnovel_conclusion9;
    [DefaultValue("For the first time in what feels like an eternity, I'm optimistic.\" ")]
    public string visualnovel_conclusion10;
    [DefaultValue("\"Say... We're already way too late for school and it's become quite clear by now that nobody's going to come lead us there, so how about you and I ditch that passion-draining penitentiary and go grab something to eat, eh?\" ")]
    public string visualnovel_conclusion11;

    [DefaultValue("\"Yeah, sure. I've got nothing better to do today. You're paying, though.\"")]
    public string visualnovel_conclusionPrompt1;
    [DefaultValue("\"Nah, sorry. To be honest I'm still kinda mad at for you how rude you were to me.\"")]
    public string visualnovel_conclusionPrompt2;

    [DefaultValue("\"Oh, you sneaky bastard!\" ")]
    public string visualnovel_conclusionResponseFirst1;
    [DefaultValue("\"But alright. ")]
    public string visualnovel_conclusionResponseFirst2;
    [DefaultValue("I do owe you one anyway, so what better time to cash out your 'did a nice thing to a girl way out of my league' coupon than now, eh?\" ")]
    public string visualnovel_conclusionResponseFirst3;

    [DefaultValue("\"Alright, suit yourself. ")]
    public string visualnovel_conclusionResponseSecond1;
    [DefaultValue("Offer still stands though, in case you change your mind at any point.\" ")]
    public string visualnovel_conclusionResponseSecond2;
    [DefaultValue("\"See you around, lover boy.\" ")]
    public string visualnovel_conclusionResponseSecond3;
}

public class FontsMetadata
{
    [DefaultValue("VCR_OSD_MONO_TURKCE")]
    public string MainFont = "";
    [DefaultValue("EBGaramond-Regular")]
    public string MuseumFont = "";
    [DefaultValue("fsTahoma8pxv2")]
    public string TerminalFont = "";
    [DefaultValue("Bittypix Monospace")]
    public string SecretTerminalFont = "";
    [DefaultValue(false)]
    public bool UseFallback = false;
}

public class Metadata
{
    [DefaultValue("en-GB")]
    public string langName;
    [DefaultValue("New Blood & Hakita")]
    public string langAuthor;
    [DefaultValue("1.0.5")]
    public string langVersion;
    [DefaultValue("English")]
    public string langDisplayName;
    [DefaultValue(false)]
    public bool langRTL;
    [DefaultValue("1.3.1")]
    public string minimumModVersion;
    [Description("Deprecated and I have no idea why it's hardcoded character f")]
    public bool langHinduNumbers;
    [DefaultValue(150)]
    public int tmFontSize = 100;
    public FontsMetadata fonts = new FontsMetadata();
}

public class IntermissionStrings
{
    [DefaultValue("Disgrace.")]
    public string act1_intermission_first1;
    [DefaultValue("Humiliation.")]
    public string act1_intermission_first2;
    [DefaultValue("Unseemly and unwelcome at the feet of The Council.")]
    public string act1_intermission_first3;
    [DefaultValue("Their eyes ablaze with bitter resentment, glaring through Gabriel's wounds of body and soul, bore outward for all to see.")]
    public string act1_intermission_first4;
    [DefaultValue("“Has this one abandoned the way of our creator?”")]
    public string act1_intermission_first5;
    [DefaultValue("“It is unworthy of its Holy Light.”")]
    public string act1_intermission_first6;
    [DefaultValue("“The Father's Light is indomitable.”")]
    public string act1_intermission_first7;
    [DefaultValue("“This one sees fit to squander it.”")]
    public string act1_intermission_first8;
    [DefaultValue("Their words resonated in Gabriel's limbs, coursing through as lightning upon wire, a searing hiss that would strike lessers deaf and blind.")]
    public string act1_intermission_first9;
    [DefaultValue("The Holy Light within him, an unstoppable storm of divine fury.")]
    public string act1_intermission_first10;
    [DefaultValue("Insurmountable for mere Objects.")]
    public string act1_intermission_first11;
    [DefaultValue("This he knew.")]
    public string act1_intermission_first12;

    [DefaultValue("“Holy Council, my devotion to our creator is absolute. I have never strayed from the will of The Father, but a machine-”")]
    public string act1_intermission_second1;
    [DefaultValue("“You dare imply the might of The Father could be shaken by mere objects?”")]
    public string act1_intermission_second2;
    [DefaultValue("“Impossible.”")]
    public string act1_intermission_second3;
    [DefaultValue("“Heresy.”")]
    public string act1_intermission_second4;
    [DefaultValue("“Unspeakable.”")]
    public string act1_intermission_second5;
    [DefaultValue("“Silence.”")]
    public string act1_intermission_second6;
    [DefaultValue("“Your treachery will not be tolerated. As punishment, The Father's Light shall be severed from your body.")]
    public string act1_intermission_second7;
    [DefaultValue("You have 24 hours before the last of its embers die out.”")]
    public string act1_intermission_second8;
    [DefaultValue("“And you with them.”")]
    public string act1_intermission_second9;
    [DefaultValue("“Prove your loyalty.”")]
    public string act1_intermission_second10;
    [DefaultValue("“Unmake your mistakes.”")]
    public string act1_intermission_second11;

    [DefaultValue("As the Light was ripped from his being, Gabriel's screams were silenced in the hiss of gospel in praise of God.")]
    public string act1_intermission_third1;
    [DefaultValue("A boiling anguish to which even the fires of Hell could not compare.")]
    public string act1_intermission_third2;
    [DefaultValue("Through the blaze of torment a single burning hatred was forged anew.")]
    public string act1_intermission_third3;
    [DefaultValue("If the machines seek blood, he would give it freely;")]
    public string act1_intermission_third4;
    [DefaultValue("and with such fury, even metal will bleed.")]
    public string act1_intermission_third5;

    [DefaultValue("TO BE CONTINUED IN... <color=red>ACT II: IMPERFECT HATRED</color>")]
    public string act1_intermission_tobecontinued;
    [DefaultValue("TO BE CONTINUED IN... ACT II: IMPERFECT HATRED")]
    public string act1_intermission_tobecontinuedshadow;
    [DefaultValue("ACT 1 END")]
    public string act1_intermission_endof;
    [DefaultValue("\nINSERT DISC 2 For\n\"ACT II: IMPERFECT HATRED\"")]
    public string act1_intermission_insertAct2;
    [DefaultValue("INSERT")]
    public string act1_intermission_insert;
    [DefaultValue("RETURN TO MENU")]
    public string act1_intermission_returnToMenu;


    [DefaultValue("Silence.")]
    public string act2_intermission_first1;
    [DefaultValue("Introspection.")]
    public string act2_intermission_first2;
    [DefaultValue("How many had he killed?")]
    public string act2_intermission_first3;
    [DefaultValue("Had he ever thought to count?")]
    public string act2_intermission_first4;
    [DefaultValue("How much cruelty did he embody… and to what end?")]
    public string act2_intermission_first5;
    [DefaultValue("How many did he condemn to hell and who did it benefit..?")]
    public string act2_intermission_first6;
    [DefaultValue("Two defeats at the hands of the machine had changed Gabriel.")]
    public string act2_intermission_first7;
    [DefaultValue("The world of the once supposed Will of God was now shattered and only he was left to put the pieces back together.")]
    public string act2_intermission_first8;
    [DefaultValue("They collected before the light of a dying fire that fresh fuel couldn't sustain, this new light showing the truth to Gabriel:")]
    public string act2_intermission_first9;

    [DefaultValue("The pieces never fit together to begin with.")]
    public string act2_intermission_first10;

    [DefaultValue("The supposed Council of \"the people\" who boasted a God that wasn't there.")]
    public string act2_intermission_second1;
    [DefaultValue("Gone.")]
    public string act2_intermission_second2;
    [DefaultValue("Vanished.")]
    public string act2_intermission_second3;
    [DefaultValue("The Council still chased after the light of God's fire, their memory of its words and will grown twisted and warped, and the rest of the aimless masses of Heaven follow their footsteps.")]
    public string act2_intermission_second4;
    [DefaultValue("The angels still act in The Father's name but His kingdom has changed.")]
    public string act2_intermission_second5;

    [DefaultValue("Now the fire was dying, sputtering out as the heat failed to gain purchase.")]
    public string act2_intermission_second6;
    [DefaultValue("Gabriel looked upon the embers with a perfect clarity.")]
    public string act2_intermission_second7;
    [DefaultValue("He drew his blade and held it in contrast to the dying light.")]
    public string act2_intermission_second8;

    [DefaultValue("In its reflection he saw a weapon reborn, no longer wielded by the will of another, but his own.")]
    public string act2_intermission_second9;
    [DefaultValue("He knew words alone would never sway the masses.")]
    public string act2_intermission_second10;
    [DefaultValue("He chose to do something drastic.")]
    public string act2_intermission_second11;

    [DefaultValue("Death stains the auditorium.")]
    public string act2_intermission_third1;
    [DefaultValue("The littered corpses of the once mighty council now strewn against its surfaces, their last gasps of life dripping down the dissident blade of Gabriel's sword.")]
    public string act2_intermission_third2;

    [DefaultValue("The last councilor, now backed up to a wall, scrambles for words between panicked breaths as death approaches with measured steps.")]
    public string act2_intermission_third3;
    [DefaultValue("\"W-wait!")]
    public string act2_intermission_third4;
    [DefaultValue("Y-you can't do this! Our status forbids it!")]
    public string act2_intermission_third5;
    [DefaultValue("This is treason, heresy, murder!")]
    public string act2_intermission_third6;
    [DefaultValue("We are the supreme authority, our law commands you!\"")]
    public string act2_intermission_third7;

    [DefaultValue("\"You command nothing.")]
    public string act2_intermission_third8;
    [DefaultValue("Your words hold no power over me, or anyone else.")]
    public string act2_intermission_third9;
    [DefaultValue("Lest you truly believe you can talk my blade back into its sheath.\"")]
    public string act2_intermission_third10;

    [DefaultValue("\"B-but the people are on our side!")]
    public string act2_intermission_fourth1;
    [DefaultValue("The citizens of Heaven know that we are just!\"")]
    public string act2_intermission_fourth2;
    [DefaultValue("\"The masses only follow you out of fear and desperation.")]
    public string act2_intermission_fourth3;
    [DefaultValue("I will show them there is nothing to be afraid of, for there is no species nor origin, vested rank or holy status that will stop the sharp edge of a sword.")]
    public string act2_intermission_fourth4;

    [DefaultValue("We all bleed the same blood, and the cushions of your thrones have made you weak and impotent.\"")]
    public string act2_intermission_fourth5;

    [DefaultValue("\"P-please, Gabriel, see reason!")]
    public string act2_intermission_fourth6;
    [DefaultValue("The council follows the will of The Father!")]
    public string act2_intermission_fourth7;
    [DefaultValue("You seek to go against our creato-\"")]
    public string act2_intermission_fourth8;

    [DefaultValue("\"Face it, brother.")]
    public string act2_intermission_fourth9;
    [DefaultValue("God is dead.")]
    public string act2_intermission_fourth10;
    [DefaultValue("The fire is gone.")]
    public string act2_intermission_fourth11;
    [DefaultValue("You're chasing phantoms.\"")]
    public string act2_intermission_fourth12;

    [DefaultValue("Gabriel's silhouette now towers over the councilor, his shadow cast upon a soon lifeless corpse.")]
    public string act2_intermission_fourth13;

    [DefaultValue("He raises his sword for the final cut as the crying mess on the floor stammers out its final feeble argument.")]
    public string act2_intermission_fifth1;

    [DefaultValue("\"B-b-but the Father's light!")]
    public string act2_intermission_fifth2;
    [DefaultValue("Without me you cannot hope to reconnect with it! I-i-if you kill me, you'll be dead in a matter of hours!\"")]
    public string act2_intermission_fifth3;
    [DefaultValue("\"I know.\"")]
    public string act2_intermission_fifth4;

    [DefaultValue("A clean, silent cut glides through the councilor's neck, severing his spine with elegance and ease.")]
    public string act2_intermission_fifth5;
    [DefaultValue("His head falls onto the marble floor, the rest of his body following soon after.")]
    public string act2_intermission_fifth6;

    [DefaultValue("Bereft of status but brimming with purpose, Gabriel gave a final message to the angels amassed at the gates of the auditorium before leaving Heaven for the very last time.")]
    public string act2_intermission_sixth1;

    [DefaultValue("His arm outstretched, without a word, the people saw.")]
    public string act2_intermission_sixth2;
    [DefaultValue("In the silence the message rang out to the far ends of the cosmos.")]
    public string act2_intermission_sixth3;

    [DefaultValue("TO BE CONCLUDED IN... <color=red>ACT III: GODFIST SUICIDE</color>")]
    public string act2_intermission_tobecontinued;
    [DefaultValue("TO BE CONCLUDED IN... ACT III: GODFIST SUICIDE")]
    public string act2_intermission_tobecontinuedshadow;
    [DefaultValue("ACT II END")]
    public string act2_intermission_endof;
    [DefaultValue("INSERT DISC 3 For\n\"ACT III: GODFIST SUICIDE\"")]
    public string act2_intermission_insertAct3;
}

public class Rank
{
    [DefaultValue("D")]
    public string rank_letter_d;
    [DefaultValue("C")]
    public string rank_letter_c;
    [DefaultValue("B")]
    public string rank_letter_b;
    [DefaultValue("A")]
    public string rank_letter_a;
    [DefaultValue("S")]
    public string rank_letter_s;
    [DefaultValue("P")]
    public string rank_letter_p;

}

public class Body
{
    [DefaultValue("English translation. Effectively the same as the pre-existing English translation in the base game. Works with UltrakULL, but to be mainly used as a work template.")]
    public string bodyName;
}

public class FrontEnd
{
    //public string mainmenu_imageReplacement;
    [DefaultValue("EARLY_ACCESS READY")]
    public string mainmenu_earlyAccess;
    [DefaultValue("SYSTEM V1 INITIALIZED\nDIAGNOSTICS...OK\nSTANDBY - WAIT FOR WAKE")]
    public string mainmenu_v1Init;
    [DefaultValue("INIT SOCIALS...OK")]
    public string mainmenu_initSocials;
    [DefaultValue("HAPPY HALLOWEEN")]
    public string mainmenu_halloween;
    [DefaultValue("HAPPY EASTER")]
    public string mainmenu_easter;
    [DefaultValue("MERRY CHRISTMAS")]
    public string mainmenu_christmas;
    [DefaultValue("PLAY")]
    public string mainmenu_play;
    [DefaultValue("OPTIONS")]
    public string mainmenu_options;
    [DefaultValue("MUSEUM")]
    public string mainmenu_credits;
    [DefaultValue("QUIT")]
    public string mainmenu_quit;
    [DefaultValue("MODS")]
    public string mainmenu_mods;
    [DefaultValue("RESTART")]
    public string mainmenu_restart;

    [DefaultValue("WING MODULE (8)\nSTATUS CHECK...\n\nMATTER-ENERGY CONVERSION STORAGE SYSTEM: OK\nINSTANT PROPULSION SYSTEM: OK\nCONTINUOUS PROPULSION SYSTEM: OK\nAUTOMATIC BODY REORIENTATION SYSTEM: OK")]
    public string wingModule;
    [DefaultValue("ARM MODULE (FACTORY DEFAULT)\nSTATUS CHECK...\n\nINERTIA CORRECTION SYSTEM: OK\nCENTER-OF-GRAVITY AUTOBALANCER SYSTEM: OK")]
    public string armModuleFactory;
    [DefaultValue("ARM MODULE (\"FEEDBACKER\")\nSTATUS CHECK...\n\nVECTOR REDIRECTION SYSTEM: OK\n\"CROSS COUNTER\" PROGRAM: FOUND")]
    public string armModuleFeedbacker;
    [DefaultValue("VISUAL CORTEX MODULE\nSTATUS CHECK...\n\nTIME PROCESSING DILATION SYSTEM: OK\nVISUAL PROCESSING ACCURACY: MINIMAL")]
    public string visualCortexModule;
    [DefaultValue("LEG MODULE (FACTORY DEFAULT) (2)\nSTATUS CHECK...\n\nFALL IMPACT REDUCTION SYSTEM: OK\nWEIGHT REDISTRIBUTION SYSTEM: OK\nPOTENTIAL ENERGY STORAGE SYSTEM: OK")]
    public string legModule;

    [DefaultValue("DIFFICULTY")]
    public string difficulty_title;
    [DefaultValue("ACCESSIBLE")]
    public string difficulty_easy;
    [DefaultValue("HARD")]
    public string difficulty_normal;
    [DefaultValue("VERY HARD")]
    public string difficulty_hard;
    [DefaultValue("HARMLESS")]
    public string difficulty_harmless;
    [DefaultValue("LENIENT")]
    public string difficulty_lenient;
    [DefaultValue("STANDARD")]
    public string difficulty_standard;
    [DefaultValue("VIOLENT")]
    public string difficulty_violent;
    [DefaultValue("BRUTAL")]
    public string difficulty_brutal;
    [DefaultValue("ULTRAKILL MUST DIE")]
    public string difficulty_umd;

    [DefaultValue("Absurdly slow enemies and attacks.")]
    public string difficulty_harmlessDescription1;
    [DefaultValue("Damage is still high, but even a mountain could dodge them.")]
    public string difficulty_harmlessDescription2;
    [DefaultValue("Recommended for players who want a stress-free experience.")]
    public string difficulty_harmlessDescription3;
    [DefaultValue("High damage but slower attacks and passive enemies.")]
    public string difficulty_lenientDescription1;
    [DefaultValue("Tension is still high, but damage is easier to avoid.")]
    public string difficulty_lenientDescription2;
    [DefaultValue("Recommended for players who want a less strict gameplay experience.")]
    public string difficulty_lenientDescription3;
    [DefaultValue("Normal enemies and high damage.")]
    public string difficulty_standardDescription1;
    [DefaultValue("Attacks are easy to avoid, but carelessness will result in a swift death.")]
    public string difficulty_standardDescription2;
    [DefaultValue("Recommended for first time players.")]
    public string difficulty_standardDescription3;
    [DefaultValue("Fast and aggressive enemies and high damage.")]
    public string difficulty_violentDescription1;
    [DefaultValue("Quick thinking, mobility options and situational awareness are essential.")]
    public string difficulty_violentDescription2;
    [DefaultValue("Recommended for players who have already gotten used to the game's pace and mechanics.")]
    public string difficulty_violentDescription3;
    [DefaultValue("Extremely aggressive enemies and high damage.")]
    public string difficulty_brutalDescription1;
    [DefaultValue("A full arsenal and extensive knowledge of the game are expected. Any slip-ups are punished harshly.")]
    public string difficulty_brutalDescription2;
    [DefaultValue("Recommended for players who already have considerable experience with the game and are looking for a fresh challenge.")]
    public string difficulty_brutalDescription3;
    internal string difficulty_umdDescription1;
    internal string difficulty_umdDescription2;
    internal string difficulty_umdDescription3;

    [DefaultValue("[ DIFFICULTY CAN BE FURTHER ADJUSTED IN ASSIST OPTIONS MENU ]")]
    public string difficulty_tweakReminder;
    [DefaultValue("UNDER CONSTRUCTION")]
    public string difficulty_underConstruction;

    [DefaultValue("CHAPTER")]
    public string chapter_title;
    [DefaultValue("PRIMARY")]
    public string chapter_type_primary;
    [DefaultValue("PRELUDE")]
    public string chapter_prelude;
    [DefaultValue("ACT I: INFINITE HYPERDEATH")]
    public string chapter_act1;
    [DefaultValue("ACT I: INFINITE HYPERDEATH")]
    public string chapter_act1_lock;
    [DefaultValue("ACT II: IMPERFECT HATRED")]
    public string chapter_act2;
    [DefaultValue("ACT II: ???")]
    public string chapter_act2_lock;
    [DefaultValue("ACT III: GODFIST SUICIDE")]
    public string chapter_act3;
    [DefaultValue("ACT III: ???")]
    public string chapter_act3_lock;
    [DefaultValue("SECONDARY")]
    public string chapter_type_secondary;
    [DefaultValue("ENCORES")]
    public string chapter_encore;
    [DefaultValue("PRIME SANCTUMS")]
    public string chapter_prime;
    [DefaultValue("THE CYBER GRIND")]
    public string chapter_cyberGrind;
    [DefaultValue("SANDBOX")]
    public string chapter_sandbox;
    [DefaultValue("SECRET MISSION")]
    public string chapter_secretMission;

    [DefaultValue("<size=46>OVERTURE: THE MOUTH OF HELL</size>")]
    public string layer_prelude;
    [DefaultValue("LAYER 1: LIMBO")]
    public string layer_limbo;
    [DefaultValue("LAYER 2: LUST")]
    public string layer_lust;
    [DefaultValue("LAYER 3: GLUTTONY")]
    public string layer_gluttony;
    [DefaultValue("LAYER 4: GREED")]
    public string layer_greed;
    [DefaultValue("LAYER 5: WRATH")]
    public string layer_wrath;
    [DefaultValue("LAYER 6: HERESY")]
    public string layer_heresy;
    [DefaultValue("LAYER 7: VIOLENCE")]
    public string layer_violence;
    [DefaultValue("LAYER 8: FRAUD")]
    public string layer_fraud;
    [DefaultValue("LAYER 9: TREACHERY")]
    public string layer_treachery;
    [DefaultValue("PRIME SANCTUMS")]
    public string layer_prime;

    [DefaultValue("CHALLENGE")]
    public string level_challenge;
    [DefaultValue("COMPLETE")]
    public string level_challengeCompleted;

    [DefaultValue("FULL INTRO?")]
    public string level_fullIntroPrompt;
    [DefaultValue("YES")]
    public string level_fullIntroPromptYes;
    [DefaultValue("NO")]
    public string level_fullIntroPromptNo;
    [DefaultValue("CANCEL")]
    public string level_fullIntroPromptCancel;

    [DefaultValue("ANY")]
    public string leaderboard_anyPercent;
    [DefaultValue("P-RANK")]
    public string leaderboard_pPercent;
    [DefaultValue("no leaderboard entries")]
    public string leaderboard_noEntries;
    [DefaultValue("LEADERBOARDS CAN BE DISABLED IN THE OPTIONS")]
    public string leaderboard_reminder;

    [DefaultValue("A TASTE OF ENCORE")]
    public string aboutEncoreTitle;
    [DefaultValue("Encore levels are extra challenging remixes of pre-existing levels. The rest will be added in a <b>FREE</b> post-release update, but for now, you can play 0-E and 1-E as a taste of what's to come.")]
    public string aboutEncoreMain; 
    [DefaultValue("OK")]
    public string aboutEncoreButton;
    
    [DefaultValue("<b>ENCORE</b> is now available in the chapter select menu.")]
    public string encoreAvailableMainText;
    [DefaultValue("OK")]
    public string encoreAvailableButton;
}

public class Book
{
    [DefaultValue("SCANNING..")]
    public string books_scanning;

    [DefaultValue("PRESS")]
    public string books_pressToClose1;
    [DefaultValue("to CLOSE")]
    public string books_pressToClose2;

    [DefaultValue("TEXT SCANNED - UNIQUE PASSAGE:")]
    public string books_limboFourth1;
    [DefaultValue("“...My mind is adrift with the eternal torments. Lurid vistas painted in insidious tones, hollow walls that scream to the touch. A mocking song plays at all hours, even the sounds of birds are fake. All reminders of my enduring damnation.")]
    public string books_limboFourth2;
    [DefaultValue("Gabriel my dearest friend, in endless penance I have awaited your embrace into Heaven. I have been so faithful, accepting of my fate, but to what end? What punishment is this, that I am to bare the keys to my own doom with no hope of salvation... These skulls sneer their devilish grins, voices chattering, tempting me to take the plunge deeper into Hell... I won't do it.")]
    public string books_limboFourth3;
    [DefaultValue("I've hidden them away amongst the furnishings, books, and the very foundations of this accursed place. Forgive me Gabriel, I will await you…”")]
    public string books_limboFourth4;
    [DefaultValue("REMAINING TEXT: IRRELEVANT.")]
    public string books_limboFourth5;

    [DefaultValue("TEXT SCANNED - LEGIBLE SCRIPT:")]
    public string books_lustSecond1;
    [DefaultValue("“...Gabriel struck down Minos, his flesh torn asunder with torrents of crimson pooling at his feet as we all cried out for clarity.")]
    public string books_lustSecond2;
    [DefaultValue("‘Justice,’ Gabriel decreed to all, with our just ruler writhing in wailing agony, ‘The Lord’s Will be done.’")]
    public string books_lustSecond3;
    [DefaultValue("We watched on in horror as Minos lay broken, now waning, screaming in defiance of God's Will, Gabriel.”")]
    public string books_lustSecond4;
    [DefaultValue("REMAINING TEXT: IRRELEVANT.")]
    public string books_lustSecond5;


    [DefaultValue("TEXT SCANNED - UNIQUE PASSAGE:")]
    public string books_greedSecond1;
    [DefaultValue("\n“It has been days since we last saw any angels. Without their oppression, there is no need for us to carry on our punishment. Even the meekest of the damned have abandoned their penance to take up arms. All can see how they have robbed us of our minds, bodies, and souls, leaving us only the hopes of a salvation that will never come, but no longer.")]
    public string books_greedSecond2;
    [DefaultValue("    King Sisyphus has acted in secret until now, amassing an army whose strength and numbers swell, but now there is no need to hide anymore. We have lived in the shadow of Heaven long enough to forget the taste of fear. Now the Sisyphean Insurrectionists prepare for war.")]
    public string books_greedSecond3;
    [DefaultValue("    I have heard of Minos beginning a peaceful revolution, but our King Sisyphus knows such pacificity will gain no favor from our cruel captors. He knows that one can only fight power with power, and he shall lead us to freedom.")]
    public string books_greedSecond4;
    [DefaultValue("    If only we knew the suffering that would befall us next...”\n")]
    public string books_greedSecond5;
    [DefaultValue("REMAINING TEXT: IRRELEVANT.")]
    public string books_greedSecond6;

    [DefaultValue("Within the PYRAMID lies the chamber of THE FELINE and THE RODENT.")]
    public string books_greedThird1;
    [DefaultValue("Within the CHAMBER lies a pool of clear WATER.")]
    public string books_greedThird2;
    [DefaultValue("Within the WATER lies a SECRET...")]
    public string books_greedThird3;
    [DefaultValue("But only those who wield the <color=#00FFFF>ELECTRIC</color> magic of the Druids may find it.")]
    public string books_greedThird4;

    [DefaultValue("TEXT SCANNED - LEGIBLE SCRIPT:")]
    public string books_wrathSecond1;
    [DefaultValue("EXCERPT FROM FERRYMAN'S DIARY")]
    public string books_wrathSecond2;
    [DefaultValue("Some calamity has struck the mortal world. What once was The River Styx has now grown to an unfathomable ocean. A million weeping souls pouring in each day that the shores can barely contain. A tearful tide spilling over at each end, bow to stern, crying for mercy, begging for safe passage. But not all souls can pay and these old hands can only take so many coins.")]
    public string books_wrathSecond3;
    [DefaultValue("Then one day, the current shifted. Wave after wave for minutes on end of millions, billions, as though the throat of the world was cut wide and the head wrenched back to speed the pour. I didn't have time to react. The weariness from my ceaseless work claimed me and I slipped beneath the roiling sea, into the depths of the Ocean Styx, my fate sealed by the crushing masses of endless bodies.")]
    public string books_wrathSecond4;
    [DefaultValue("Suddenly, there was a light as brilliant as the Lord himself, ushering me from the darkness with mighty arms that held me with such compassion and warmth as I have never known:")]
    public string books_wrathSecond5;
    [DefaultValue("<i>\"Be not afraid, sinner. Your devotion to God shows goodness in you; plentiful indeed. The heart is willing but the body must rest, lest you squander one of the Lord's creations.\"</i>")]
    public string books_wrathSecond6;
    [DefaultValue("His gentle words eased the pain and mended my wounds. My face wet with tears of relief, my words muffled by the weight of my duty. I could only lay in reverence, carried in the embrace of majesty.")]
    public string books_wrathSecond7;
    [DefaultValue("Radiant is Gabriel, for he is the light in my darkness.")]
    public string books_wrathSecond8;
    [DefaultValue("REMAINING TEXT: IRRELEVANT.")]
    public string books_wrathSecond9;

    [DefaultValue("MOST TEXT: INCOMPREHENSIBLE.")]
    public string books_violenceFirst1;
    [DefaultValue("DISPLAYING FINAL PAGE:")]
    public string books_violenceFirst2;
    [DefaultValue("The unending halls of the Garden! Ah, so dutifully decorated by the cross, the symbol that angels use for the Tree of Life. They praise their beloved Father who had planted it and filled us with the dew of its leaves and the nectar of its fruit, that which gives us life, courses through our veins...")]
    public string books_violenceFirst3;
    [DefaultValue("For you however, our truth: Our bodies are not a vessel for the blood of the fruit, but its prison. The beautiful guts and gorgeous bone YEARN to be shown and seen! SPLAYED! Under the divine cross of the Tree of Life, we pay it tribute through the art of violence.")]
    public string books_violenceFirst4;
    [DefaultValue("THE WORLD IS YOUR CANVAS")]
    public string books_violenceFirst5;
    [DefaultValue("SO TAKE UP YOUR BRUSH")]
    public string books_violenceFirst6;
    [DefaultValue("AND PAINT")]
    public string books_violenceFirst7;
    [DefaultValue("THE WORLD")]
    public string books_violenceFirst8;
    [DefaultValue("R E D .")]
    public string books_violenceFirst9;

    [DefaultValue("Dead end after dead end. Is there really no way out?")]
    public string books_violenceFirst_Slate1;
    [DefaultValue("Get lost in the labyrinth, die in the battlefield, or get lost in the forest...")]
    public string books_violenceFirst_Slate2;
    [DefaultValue("I thought I saw a way out there, a gate covered by foliage... But even with all our strength we couldn't get through.")]
    public string books_violenceFirst_Slate3;
    [DefaultValue("I doubt there's any blade sharp enough to cut the vines, and no fire we've tried has been hot enough... It's possible that those <color=orange>flamethrower wielding machines</color> might be able to burn through it, but their weapons become <color=orange>unusable</color> when they <color=orange>die</color>.")]
    public string books_violenceFirst_Slate4;

    [DefaultValue("Something has happened. It has been days since our reconaissance has seen a single angel. We know not the cause, but we recognise the chance. We have hid underground from the chaos up above for far too long. Without the watchful eyes of the angels, we will brave the labyrinth and find a way out of this place.")]
    public string books_violenceSecond1;
    [DefaultValue("If you are one who seeks shelter, take heed: The archive is trapped. A single misstep and reprogrammed protectors will activate. Write these instructions down and follow them carefully if you wish to take refuge on the other side:")]
    public string books_violenceSecond2;

    [DefaultValue("Mother, mother... Mother of me,")]
    public string books_violenceSecondAmbush1;
    [DefaultValue("I know I know I should not miss you so, but mother of me, I do. Your pained breaths that rasp'd and reverberated in your rusted iron tomb... The blood of your breast that nourish'd me and warmed me in its caress, when corpse and cruelty were all I witnessed...")]
    public string books_violenceSecondAmbush2;
    [DefaultValue("I know I know you would hate me so, and mother of me, I do too. But I would not feel, not think, not dream, were it not for you in my rusted iron womb... Your tortured love brought me to this war, that I could take the heart of another, and need you no more.")]
    public string books_violenceSecondAmbush3;
    [DefaultValue("I know I know your thoughts had left you long ago, and mother of me, I will never truly know. But I hope it redeems my life even a slight, when I cried... And crushed your skull that final night.")]
    public string books_violenceSecondAmbush4;

    [DefaultValue("THIS IS THE ONLY WAY IT COULD HAVE ENDED.")]
    public string books_violenceFourth1;
    [DefaultValue("WAR NO LONGER NEEDED ITS ULTIMATE PRACTICIONER. IT HAD BECOME A SELF-SUSTAINING SYSTEM. MAN WAS CRUSHED UNDER THE WHEELS OF A MACHINE CREATED TO CREATE THE MACHINE CREATED TO CRUSH THE MACHINE. SAMSARA OF CUT SINEW AND CRUSHED BONE. DEATH WITHOUT LIFE. NULL OUROBOROS. ALL THAT REMAINED IS WAR WITHOUT REASON.")]
    public string books_violenceFourth2;
    [DefaultValue("A MAGNUM OPUS. A COLD TOWER OF STEEL. A MACHINE BUILT TO END WAR IS ALWAYS A MACHINE BUILT TO CONTINUE WAR. YOU WERE BEAUTIFUL, OUTSTRETCHED LIKE ANTENNAS TO HEAVEN. YOU WERE BEYOND YOUR CREATORS. YOU REACHED FOR GOD, AND YOU FELL. NONE WERE LEFT TO SPEAK YOUR EULOGY. NO FINAL WORDS, NO CONCLUDING STATEMENT. NO POINT. PERFECT CLOSURE.")]
    public string books_violenceFourth3;
    [DefaultValue("T H I S   I S   T H E   O N L Y   W A Y   I T\nS H O U L D   H A V E   E N D E D .")]
    public string books_violenceFourth4;
    [DefaultValue("The pages of the book are blank.")]
    public string books_violenceFourth5;

    [DefaultValue("SORRY, GONE FISHIN'!")]
    public string books_violenceSecret_Slate1;
    [DefaultValue("- SIZE 2")]
    public string books_violenceSecret_Slate2;

    // Fraud Second (Level 8-2) books
    [DefaultValue("I want to give a particular shoutout to all the programmers who worked tirelessly for a year to make this extremely ambitious \"portal\" idea of mine possible. Through many, many hours and plenty of sweat (but hopefully not tears), Layer 8: Fraud has become exactly what I had dreamed it would be, and so much more.")]
    public string books_fraudSecond1_1;
    [DefaultValue("Thank you Victoria.")]
    public string books_fraudSecond1_2;
    [DefaultValue("Thank you Heckteck.")]
    public string books_fraudSecond1_3;
    [DefaultValue("Thank you PITR.")]
    public string books_fraudSecond1_4;
    [DefaultValue("Thank you Scott.")]
    public string books_fraudSecond1_5;
    [DefaultValue("Thank you Ben.")]
    public string books_fraudSecond1_6;
    [DefaultValue("Thank you Hazeluff.")]
    public string books_fraudSecond1_7;
    [DefaultValue("Thank you Lucas.")]
    public string books_fraudSecond1_8;
    [DefaultValue("Hopefully this layer has worked out to be a worthy send-off to ULTRAKILL's level design. We certainly worked our hardest to make it so.")]
    public string books_fraudSecond1_9;
    [DefaultValue("T. Hakita")]
    public string books_fraudSecond1_10;

    [DefaultValue("TEXT SCANNED - EARTHMOVER MENTIONS DETECTED:")]
    public string books_fraudSecond2_1;
    [DefaultValue("EXCERPT FROM ARCHIVE")]
    public string books_fraudSecond2_2;
    [DefaultValue("“...the fall of the Earthmovers, our attempts at reconstruction have been fruitful. Resources are still scarce, and every person has to carry a great weight to keep the whole community afloat. Although I had initially feared such drastic measures would cause conflict, it seems that having a common good for all of us to work towards has pulled us closer together and made us inseperable. We've lived through mankind's worst after all, so now is our time to show its best.")]
    public string books_fraudSecond2_3;
    [DefaultValue("JANUARY 23RD")]
    public string books_fraudSecond2_4;
    [DefaultValue("By scavenging technologies from the corpse of our past home, 15H-KUR, we have managed to establish two-way audio signals with four other communities that have likewise survived that hellish century on the backs of other Earthmovers, and we are now pooling our knowledge together to find a way to share our resources. By sheer luck, in one of the communities Gilles has found someone who he shares a pre-war ancestor with. Morale is at an all-time high.")]
    public string books_fraudSecond2_5;
    [DefaultValue("JANUARY 25TH")]
    public string books_fraudSecond2_6;
    [DefaultValue("Through our communication with the other communities (and small-scale blood donations from eager helpers), we've managed to reconstruct an interface that 15H-KUR used for tracking Earthmover movements across the globe, and via cross-referencing a surviving map from the era of countries, we've determined multiple possible communities within a few weeks of travel. Groups have already been sent out to”")]
    public string books_fraudSecond2_7;
    [DefaultValue("REMAINING TEXT: IRRELEVANT.")]
    public string books_fraudSecond2_8;

    [DefaultValue("I SEE ICY ULYSSES FROZEN UPON THE WINE DARK HIGH SEA. EUCHARISTIC FLESH AND BLOOD, BORN IN PAIN. THIS IS MAN. EVEN AGAINST THE ODDS, WRIT BY ADAM, MURDER IS IN THEIR NURTURE: THE EPISTOLARY PLOSIVES OF AIR RAIDS, THE OPEN GRAVES, MASSED CORPSES WITH CROW-PECKED SOCKETS, THE SIGHT'S REST LEFT UNSEEN - INSIPID AND INSOLENT IN SO FEAR'D AS TWO GRIEVERS CRY THERE WILL BE NO PEACE.")]
    public string books_fraudSecond3_1;
    [DefaultValue("SEE THE NATURE OF A SYMPHONY: ONE ONE-HUNDRED UNIVERSES AND CHORUSES. NOTES, NOTES, SO FORTH AND NOTHING. NO. I SEE HUES CLEARLY NOW: SUCH SHADEFUL SIGHTS TO SHOW YOU - THE WRITER STAYS HIS HAND AND THE STORY WRITES ITS SELF.")]
    public string books_fraudSecond3_2;
    [DefaultValue("YOU LOOK INTO YOUR LOVE'S EYES AND SEE A STRANGER. BELLUM OMNIUM CONTRA OMNES. MAN IS WOLF TO MAN. THIS ANTEDILUVIAN CRUELTY BY SEED YOU CARRY ONWARD. EYE FOR AN I, EACH GENERATION FORGETS THE SCARS OF THE LAST. NOTHING LASTS. A VIEW TO A THRILL, A VISION OF THE FUTURE:")]
    public string books_fraudSecond3_3;
    [DefaultValue("I SEE TO YOU, SON OF SOUL: EAT. EAT. YEARN FOR MORE! OVER AND OVER! UNTIL ALL THAT REMAINS IS THE KNOWLEDGE THAT THIS WAS")]
    public string books_fraudSecond3_4;
    [DefaultValue("A L L")]
    public string books_fraudSecond3_5;
    [DefaultValue("Y O U R")]
    public string books_fraudSecond3_6;
    [DefaultValue("F A U L T .")]
    public string books_fraudSecond3_7;
    [DefaultValue("The pages of the book are blank.")]
    public string books_fraudSecond3_8;

    // Fraud Third (Level 8-3) books
    [DefaultValue("TEXT SCANNED - ANOMALY DETECTED:")]
    public string books_fraudThird1_1;
    [DefaultValue("EXCERPT FROM ARCHIVE")]
    public string books_fraudThird1_2;
    [DefaultValue("\"...news of the community of MO-200-OS having successfully cloned a pig, making them the fourth to have followed in the footsteps of our successful cow cloning project. Although still limited in quantity, meat is gradually being eased back into the diets of our people, even if most are still apprehensive about taking them, having gotten used to the extreme scarcity.\"")]
    public string books_fraudThird1_3;
    [DefaultValue("AUGUST 17TH")]
    public string books_fraudThird1_4;
    [DefaultValue("\"At this point, I feel the only way to ease the tension after Chantal's disappearance is to find her, or at least what happened to her. Bizarre rumors have spread surrounding the left main elevator of the northern research building, from unexplained power outages to even whispers of a basement accessible only by selecting a specific sequence of floors. I don't believe in any of it, but at this point, anything is worth investigating. I'll be heading\"")]
    public string books_fraudThird1_5;
    [DefaultValue("REMAINING TEXT: IRRELEVANT.")]
    public string books_fraudThird1_6;

    [DefaultValue("ATAVISTIC ANTAGONIST, ANTIGONE WITH THE WIND: BROTHER AGAINST BROTHER IN ARMS, OTHER HARMS IRRELEVANT COLLATERAL. HOLY HOLY HOLY IS THE LORD. WAR IS ONTOLOGICAL, PEACE IS A FAILURE OF FREE WILL. MILLE VIAE DUCIMT HOMINES PER SAECULA SANGUINEM.")]
    public string books_fraudThird2_1;
    [DefaultValue("DROWNING IN DENIAL, MAN SET SAIL IN SEARCH OF A PALINGENETIC SIMULACRUM OF ITHACA, AN EDEN AFORE THE ANTEDILUVIAN, UNTOUCHED BY THEIR OWN SIN-STAINED HANDS… BUT DEATH IS ARABLE, ALL GROWTH IS DEVOUREMENT - LIFE FEEDS ON LIFE FEEDS ON LIFE. IBID. IBID. HOLY HOLY HOLY IS THE LORD, AND THE REST IS VIOLENCE. NO. EVEN THIS IS NOT ΓΝΩΣΙΣ.")]
    public string books_fraudThird2_2;
    [DefaultValue("THE SPATIO-TEMPORAL MIND CAN CONCEPTUALIZE REALITY ONLY IN BINARY. YES AND NO. IS AND IS NOT. THE EYE OF ΛΟΓΟΣ SEES ONLY A COLORLESS EXISTENCE IN A MONOPOTENTIAL WORLD, ITS ABSTRACTIONS A CHARADE OF SHADELESS ONES AND ZEROES REARRANGED AD NIHILUM. PHAEDONIC DIALOGUES, SIMPLE SHADOWS ON A CAVE WALL. NO. THERE ARE 39 STATES OF EXISTENCE. POSTFINITY. METATEMPORALITY. EXTRACAUSALITY. REASON AND DIALECTICS ARE AXES IN THE GARDEN OF REALITY, SHAVINGS OF SEMI-POTENTIAL SUFFERINGS.")]
    public string books_fraudThird2_3;
    [DefaultValue("L U C I F E R ,   M Y   L O V E . . .")]
    public string books_fraudThird2_4;
    [DefaultValue("I SHALL GIFT TO YOU ALL THE AGONIES THAT CAN EXIST,")]
    public string books_fraudThird2_5;
    [DefaultValue("AND MANY THAT CANNOT.")]
    public string books_fraudThird2_6;
    [DefaultValue("\nThe pages of the book are blank.")]
    public string books_fraudThird2_7;

}

public class PauseMenu
{
    [DefaultValue("PAUSED")]
    public string pause_title;
    [DefaultValue("RESUME")]
    public string pause_resume;
    [DefaultValue("CHECKPOINT")]
    public string pause_respawn;
    [DefaultValue("SKIP")]
    public string pause_skip;
    [DefaultValue("RESTART MISSION")]
    public string pause_restart;
    [DefaultValue("OPTIONS")]
    public string pause_options;
    [DefaultValue("QUIT MISSION")]
    public string pause_quit;

    [DefaultValue("Are you sure you want to\n<color=orange>RESTART</color> this mission?")]
    public string pause_restartConfirm;
    [DefaultValue("Are you sure you want to\n<color=orange>QUIT</color> this mission?")]
    public string pause_quitConfirm;
    [DefaultValue("RESTART")]
    public string pause_restartConfirmYes;
    [DefaultValue("CANCEL")]
    public string pause_restartConfirmNo;
    [DefaultValue("QUIT")]
    public string pause_quitConfirmYes;
    [DefaultValue("CANCEL")]
    public string pause_quitConfirmNo;

    [DefaultValue("This pop-up can be disabled in the options menu")]
    public string pause_disableWindow;

}


public class ShopStrings
{
    [DefaultValue("Tip of the Day")]
    public string shop_tipofthedayTitle;
    [DefaultValue("")]
    public string shop_tipoftheday;
    [DefaultValue("Menu")]
    public string shop_menu;
    [DefaultValue("Weapons")]
    public string shop_weapons;
    [DefaultValue("Enemies")]
    public string shop_monsters;
    [DefaultValue("The Cyber Grind")]
    public string shop_cybergrind;
    [DefaultValue("Return To Mission")]
    public string shop_returnToMission;
    [DefaultValue("Sandbox")]
    public string shop_sandbox;
    [DefaultValue("SOUL ORBS")]
    public string shop_soulOrbs;
    [DefaultValue("P")]
    public string shop_moneyCount;
    [DefaultValue("LIKE, A LOT OF ")]
    public string shop_lotsOfMoney;
    [DefaultValue("Equipped")]
    public string shop_equipped;
    [DefaultValue("Unequipped")]
    public string shop_unequipped;

    [DefaultValue("<color=#FF4343>The Cyber Grind</color> is an endless survival mode.")]
    public string shop_cybergrindDescription1;
    [DefaultValue("Good performance gives many <color=#FF4343>points</color>.")]
    public string shop_cybergrindDescription2;
    [DefaultValue("<color=#FF4343>Progress in the current mission will be lost</color>.")]
    public string shop_cybergrindDescription3;
    [DefaultValue("The Cyber Grind")]
    public string shop_cybergrindEnterTitle;
    [DefaultValue("Enter The Cyber Grind")]
    public string shop_cybergrindEnter;
    [DefaultValue("Returning to")]
    public string shop_returningTo;
    [DefaultValue("Previous Mission")]
    public string shop_cybergrindExitTitle;
    [DefaultValue("Exit The Cyber Grind")]
    public string shop_cybergrindExit;

    [DefaultValue("Sandbox")]
    public string shop_sandboxTitle;
    [DefaultValue("The <color=#FF4343>Sandbox</color> is an empty level that can be used for practicing.")]
    public string shop_sandboxDescription1;
    [DefaultValue("<color=#FF4343>Progress in the current mission will be lost</color>.")]
    public string shop_sandboxDescription2;
    [DefaultValue("Enter The Sandbox")]
    public string shop_sandboxEnter;

    [DefaultValue("Back")]
    public string shop_back;

    [DefaultValue("Info")]
    public string shop_weaponInfo;
    [DefaultValue("Revolver Info")]
    public string shop_weaponsRevolverInfo;
    [DefaultValue("Shotgun Info")]
    public string shop_weaponsShotgunInfo;
    [DefaultValue("Nailgun Info")]
    public string shop_weaponsNailgunInfo;
    [DefaultValue("Railcannon Info")]
    public string shop_weaponsRailcannonInfo;
    [DefaultValue("Rocket Launcher Info")]
    public string shop_weaponsRocketLauncherInfo;

    [DefaultValue("Color")]
    public string shop_weaponColors;
    [DefaultValue("Revolver Color")]
    public string shop_weaponsRevolverColors;
    [DefaultValue("Shotgun Color")]
    public string shop_weaponsShotgunColors;
    [DefaultValue("Nailgun Color")]
    public string shop_weaponsNailgunColors;
    [DefaultValue("Railcannon Color")]
    public string shop_weaponsRailcannonColors;
    [DefaultValue("Rocket Launcher Color")]
    public string shop_weaponsRocketLauncherColors;

    [DefaultValue("Revolver")]
    public string shop_weaponsRevolver;
    [DefaultValue("Shotgun")]
    public string shop_weaponsShotgun;
    [DefaultValue("Nailgun")]
    public string shop_weaponsNailgun;
    [DefaultValue("Railcannon")]
    public string shop_weaponsRailcannon;
    [DefaultValue("Rocket Launcher")]
    public string shop_weaponsRocketLauncher;
    [DefaultValue("Arms")]
    public string shop_weaponsArms;

    [DefaultValue("PIERCER")]
    public string shop_revolverPiercer;
    [DefaultValue("<color=#FF4343>Hold</color> Alt Fire to charge a <color=#FF4343>3-hit beam</color>.")]
    public string shop_revolverPiercerDescription1;
    [DefaultValue("Requires <color=#FF4343>cooldown</color>.")]
    public string shop_revolverPiercerDescription2;
    [DefaultValue("MARKSMAN")]
    public string shop_revolverMarksman;
    [DefaultValue("Press Alt Fire to throw a <color=#FF4343>coin</color>.")]
    public string shop_revolverMarksmanDescription1;
    [DefaultValue("Hit an <color=#FF4343>airborne</color> coin to <color=#FF4343>deflect</color> your shot into the nearest enemy's <color=#FF4343>weakpoint</color>.")]
    public string shop_revolverMarksmanDescription2;
    [DefaultValue("Coins can be <color=#FF4343>chained</color>.")]
    public string shop_revolverMarksmanDescription3;
    [DefaultValue("SHARPSHOOTER")]
    public string shop_revolverSharpshooter;
    [DefaultValue("<color=#FF4343>Hold</color> Alt Fire to charge a piercing beam that <color=#FF4343>ricochets off surfaces</color>.")]
    public string shop_revolverSharpshooterDescription1;
    [DefaultValue("Can destroy <color=#FF4343>projectiles</color>.")]
    public string shop_revolverSharpshooterDescription2;


    [DefaultValue("CORE EJECT")]
    public string shop_shotgunCoreEject;
    [DefaultValue("Press Alt Fire to overheat and <color=#FF4343>launch</color> the shotgun's <color=#FF4343>cores</color>.")]
    public string shop_shotgunCoreEjectDescription1;
    [DefaultValue("<color=#FF4343>Hold</color> to charge <color=#FF4343>distance</color>.")]
    public string shop_shotgunCoreEjectDescription2;
    [DefaultValue("<color=#FF4343>Explodes</color> on impact.")]
    public string shop_shotgunCoreEjectDescription3;

    [DefaultValue("PUMP CHARGE")]
    public string shop_shotgunPumpCharge;
    [DefaultValue("Press Alt Fire to <color=#FF4343>pump</color> your shotgun, increasing the <color=#FF4343>power</color> and decreasing the <color=#FF4343>accuracy</color> of your <color=#FF4343>next shot</color>.")]
    public string shop_shotgunPumpChargeDescription1;
    [DefaultValue("Too many pumps will cause an <color=#FF4343>explosion</color> when fired.")]
    public string shop_shotgunPumpChargeDescription2;

    [DefaultValue("SAWED-ON")]
    public string shop_shotgunSawedOn;
    [DefaultValue("<color=#FF4343>Hold</color> Alt Fire to rev <color=#FF4343>chainsaw</color>.")]
    public string shop_shotgunSawedOnDescription1;
    [DefaultValue("<color=#FF4343>Release</color> to launch, <color=#FF4343>piercing</color> enemies and <color=#FF4343>returning</color> back.")]
    public string shop_shotgunSawedOnDescription2;
    [DefaultValue("Can be <color=#FF4343>punched</color> to keep active.")]
    public string shop_shotgunSawedOnDescription3;

    [DefaultValue("ATTRACTOR")]
    public string shop_nailgunMagnet;
    [DefaultValue("Alt fire to shoot a <color=#FF4343>magnet</color> that pulls all nearby <color=#FF4343>nails</color> towards it.")]
    public string shop_nailgunMagnetDescription1;
    [DefaultValue("Magnets stick to <color=#FF4343>surfaces</color> and <color=#FF4343>enemies</color> and can be broken with <color=#FF4343>hitscan</color> weapons.")]
    public string shop_nailgunMagnetDescription2;

    [DefaultValue("OVERHEAT")]
    public string shop_nailgunOverheat;
    [DefaultValue("Alt fire while shooting to <color=#FF4343>overheat</color> for a quick burst of high damage at the cost of a <color=#FF4343>heatsink</color>.")]
    public string shop_nailgunOverheatDescription1;
    [DefaultValue("Heatsinks recharge when not firing.")]
    public string shop_nailgunOverheatDescription2;

    [DefaultValue("JUMPSTART")]
    public string shop_nailgunJumpStart;
    [DefaultValue("Press Alt Fire to attach a cable that <color=#FF4343>slowly charges</color> a powerful <color=#FF4343>electric shock</color>.")]
    public string shop_nailgunJumpStartDescription1;
    [DefaultValue("Attached cables <color=#FF4343>persist</color> when <color=#FF4343>switching weapons</color>.")]
    public string shop_nailgunJumpStartDescription2;

    [DefaultValue("ELECTRIC")]
    public string shop_railcannonElectric;
    [DefaultValue("A powerful instant piercing shot.")]
    public string shop_railcannonElectricDescription1;
    [DefaultValue("<color=#FF4343>Pierces</color> through <color=#FF4343>all</color> enemies. Pay attention to your <color=#FF4343>positioning</color> to maximize destruction.")]
    public string shop_railcannonElectricDescription2;
    [DefaultValue("Don't use in water.")]
    public string shop_railcannonElectricDescription3;

    [DefaultValue("SCREWDRIVER")]
    public string shop_railcannonScrewdriver;
    [DefaultValue("Fires a powerful drill that <color=#FF4343>sticks</color> to an enemy and deals damage <color=#FF4343>over time</color>.")]
    public string shop_railcannonScrewdriverDescription1;
    [DefaultValue("This drill causes enemies to bleed continuously with <color=#FF4343>extra healing range</color>.")]
    public string shop_railcannonScrewdriverDescription2;

    [DefaultValue("MALICIOUS")]
    public string shop_railcannonMalicious;
    [DefaultValue("Fires an instant beam that causes a <color=#FF4343>large explosion</color> on impact, similar to a certain familiar face.")]
    public string shop_railcannonMaliciousDescription1;
    [DefaultValue("Wipes out groups of weak enemies with ease.")]
    public string shop_railcannonMaliciousDescription2;

    [DefaultValue("FREEZEFRAME")]
    public string shop_rocketLauncherFreeze;
    [DefaultValue("Press Alt Fire to <color=#FF4343>freeze</color> rockets.")]
    public string shop_rocketLauncherFreezeDescription1;
    [DefaultValue("Frozen rockets have a <color=#FF4343>larger blast radius</color> and will <color=#FF4343>stay frozen</color> even when switching weapons.")]
    public string shop_rocketLauncherFreezeDescription2;

    [DefaultValue("S.R.S. CANNON")]
    public string shop_rocketLauncherSrsCannon;
    [DefaultValue("Press Alt Fire to launch <color=#FF4343>cannonball</color>.")]
    public string shop_rocketLauncherSrsCannonDescription1;
    [DefaultValue("<color=#FF4343>Hold</color> to charge <color=#FF4343>distance</color>.")]
    public string shop_rocketLauncherSrsCannonDescription2;
    [DefaultValue("No one knows what S.R.S. stands for.")]
    public string shop_rocketLauncherSrsCannonDescription3;

    [DefaultValue("FIRESTARTER")]
    public string shop_rocketLauncherFireStarter;
    [DefaultValue("<color=#FF4343>Hold</color> Alt Fire to spray <color=#FF4343>gasoline</color>, making <color=#FF4343>non-flammable</color> enemies <color=#FF4343>flammable</color>.")]
    public string shop_rocketLauncherFireStarterDescription1;
    [DefaultValue("Can also be sprayed on the <color=#FF4343>environment</color> to create <color=#FF4343>walls of fire</color>.")]
    public string shop_rocketLauncherFireStarterDescription2;

    [DefaultValue("FEEDBACKER")]
    public string shop_armFeedbacker;
    [DefaultValue("Fast punch with decent damage.")]
    public string shop_armFeedbackerDescription1;
    [DefaultValue("Can <color=#FF4343>parry</color> most attacks, including <color=#FF4343>shotgun shots</color> and <color=#FF4343>coins</color>.")]
    public string shop_armFeedbackerDescription2;

    [DefaultValue("KNUCKLEBLASTER")]
    public string shop_armKnuckleblaster;
    [DefaultValue("Slow punch with high damage and knockback.")]
    public string shop_armKnuckleblasterDescription1;
    [DefaultValue("<color=#FF4343>Hold Punch</color> to blast shells inside the knuckles, causing a <color=#FF4343>shockwave</color> that knocks surrounding enemies away.")]
    public string shop_armKnuckleblasterDescription2;

    [DefaultValue("WHIPLASH")]
    public string shop_armWhiplash;
    [DefaultValue("A winch with a spear.\n<color=#FF4343>Hold</color> to throw, <color=#FF4343>release</color> to pull.")]
    public string shop_armWhiplashDescription1;
    [DefaultValue("Can pull light enemies and items, will get pulled to heavy enemies and grapple points.")]
    public string shop_armWhiplashDescription2;

    [DefaultValue("DATA:")]
    public string shop_data;
    [DefaultValue("STRATEGY:")]
    public string shop_strategy;
    [DefaultValue("ADVANCED STRATEGY:")]
    public string shop_advancedStrategy;

    [DefaultValue("A weapon created during the Final War for medium-to-long distance combat. Uses electric pulses to fire microscopic pieces of metal at incredibly high speeds.")]
    public string shop_loreRevolver1;
    [DefaultValue("Weapons that use this technology have been dubbed \"electric guns\", and it quickly became the new standard, replacing bullet guns. Due to still requiring a microscopic projectile, its ammo is not actually infinite, but it would take weeks of non-stop firing to run out and refilling is as easy as just scraping some flakes from scrap metal or even the gun's surface.")]
    public string shop_loreRevolver2;
    [DefaultValue("In fact, a rough, uneven surface from scraping flakes is considered a point of pride for wielders of electric guns, as it shows the weapon has been reliable and used for a long time. Many users even shave off flakes just for this reason, rather than for actual ammunition, making \"unflaked\" electric weapons an outlier.")]
    public string shop_loreRevolver3;
    [DefaultValue("Although an electric gun requires some time to recharge its battery between shots, the revolver-style design bypasses that issue by including a multi-battery cylinder that rotates after each shot, allowing each battery time to charge without slowing down the fire-rate.")]
    public string shop_loreRevolver4;
    [DefaultValue("A common modification is to allow for the charges of all batteries to be released simultaneously for greater power, though this requires a longer recharge time.")]
    public string shop_loreRevolver5;
    [DefaultValue("- The revolver's precision and the instant travel time of its shots make it an excellent and reliable way to deal damage at a range, as it's unlikely anything could have reaction times fast enough to dodge it.")]
    public string shop_loreRevolver6;
    [DefaultValue("- Headshots deal 2x damage, limbshots 1.5x")]
    public string shop_loreRevolver7;
    [DefaultValue("- When hit with precise timing during its flash, the Marksman variation's coin can split a shot in two, causing it to hit two targets instead of just one. Although the timing is tight, there is a second much longer window if the coin remains airborne for an extended period of time, recognisable by its continuous whistling sound.")]
    public string shop_loreRevolver8;
    [DefaultValue("- The Marksman variation's coin can be punched after it has flashed, launching it into the nearest target without breaking the coin, increasing its damage further for subsequent punches or shots.")]
    public string shop_loreRevolver9;
    [DefaultValue("- The Piercer's charged shot can also ricochet off of the Marksman variation's coins.")]
    public string shop_loreRevolver10;

    [DefaultValue("An experimental close range weapon that uses hyperconcentrated heat as its projectiles.")]
    public string shop_loreShotgun1;
    [DefaultValue("After each shot, the shotgun must be opened to allow its heat-generating cores to vent excess heat, stopping them from melting or exploding. This process is largely automated, requiring little more from the user than a flick of the wrist.")]
    public string shop_loreShotgun2;
    [DefaultValue("In case of core failure, the pump can be used as a manual heat building mechanism. This process has been simplified via a small button near the grip that pumps the shotgun without requiring physical force from the user, though its ease of use has also greatly increased the reported amount of misfires from users pumping too much heat into a single shot.")]
    public string shop_loreShotgun3;
    [DefaultValue("Heat weapons never caught on as much as electric weapons due to their volatile nature and strict cooling requirements, but unlike electric weapons, they don't require a separate projectile, making their ammunition truly infinite rather than just practically infinite.")]
    public string shop_loreShotgun4;
    [DefaultValue("- The shotgun is only effective at extremely close ranges, making it a risky but very devastating damage dealer. This also makes it ideal for healing.")]
    public string shop_loreShotgun5;
    [DefaultValue("- Can parry melee attacks via a point-blank shot to the chest. Riskier than using the Feedbacker arm, but with higher damage as a reward.")]
    public string shop_loreShotgun6;
    [DefaultValue("- Quickly swapping weapons skips the wait time after a shot, allowing for continuous bursts of massive damage at the risk of having to stay close for an extended period of time.")]
    public string shop_loreShotgun7;
    [DefaultValue("- The Core Eject variation's core can be shot out of the air via a hitscan weapon such as the Revolver to increase the radius and damage of its explosion. An already explosive hitscan will increase its radius even further.")]
    public string shop_loreShotgun8;
    [DefaultValue("- The slowness of the condensed heat projectiles may seem like a detriment at first, but this means that a well timed punch with the Feedbacker arm can hit them, parrying one's own shot for far greater accuracy, speed and damage.")]
    public string shop_loreShotgun9;

    [DefaultValue("A combination of parts from an industrial nailgun and an old bullet gun. Most likely engineered by a machine that was built for construction work, as all machines, even those not built for war, had to learn to fend for themselves after the extinction of mankind.")]
    public string shop_loreNailgun1;
    [DefaultValue("Bullet guns were largely abandoned after the invention of infinite ammunition systems such as electric weapons and heat weapons, largely due to how much cheaper not having to buy ammunition for large-scale armies becomes overtime.")]
    public string shop_loreNailgun2;
    [DefaultValue("Although the original ammunition system made it useless and largely abandoned, this gun was still excellently designed and built, so with some retrofitting of parts from an industrial nailgun, it has become a rapid-fire projectile weapon with practically infinite metal ammunition.")]
    public string shop_loreNailgun3;
    [DefaultValue("As is to be expected from an improvised weapon though, its design is far from perfect. As the nail regeneration system was not designed to work at such a high rate, it's liable to overheat if a hard rate limit isn't set on it, though some variants have instead opted for built-in heatsinks.")]
    public string shop_loreNailgun4;
    [DefaultValue("- Due to the nature of its limited ammunition, the nailgun is best used in short bursts rather than extended periods of time.")]
    public string shop_loreNailgun5;
    [DefaultValue("- The Attractor variation's magnets will also affect the nails from other nailgun variations, allowing the bypassing of otherwise limiting factors such as the burst from the Overheat variation having poor accuracy.")]
    public string shop_loreNailgun6;
    [DefaultValue("- Some enemies, such as Malicious Faces, are generally weak to nails, and in particular the higher quality nails from the hard-limited Attractor variation will decimate most weak foes.")]
    public string shop_loreNailgun7;
    [DefaultValue("- Nails become embedded in enemies, causing some special effects. Electric weapons will receive a damage boost from hitting an enemy that has nails in it, and with enough nails, light enemies become magnetized and pulled by the Attractor variation's magnets, allowing for easy temporary disabling of durable light enemies.")]
    public string shop_loreNailgun8;
    [DefaultValue("- The speed of the barrels' spin carries over between variations, meaning shooting even once with the Attractor variation gives maximum heat for the Overheat variation, allowing for an instant full overheat burst.")]
    public string shop_loreNailgun9;

    [DefaultValue("This industrial tool was one of the earliest uses for the technology that eventually became electric guns.")]
    public string shop_loreRailcannon1;
    [DefaultValue("Originally meant as a handheld generator, allowing for an easy way to generate electricity for temporary relocation, such as encampments during wars or expeditions.")]
    public string shop_loreRailcannon2;
    [DefaultValue("As with most similar industrial tools, once mankind fell, it was repurposed as a weapon by the machine that wielded it, turning it from a lower voltage constant output into a single extremely high burst of energy that requires a long recharge time between shots.")]
    public string shop_loreRailcannon3;
    [DefaultValue("Although a risky weapon, since its recharge time is so long, the railcannon's power makes it a worthy tool to wield, especially for someone carrying multiple weapons that they can use while the railcannon's battery recharges.")]
    public string shop_loreRailcannon4;
    [DefaultValue("- Each variation serves a different purpose, and since they all share the same cooldown, it's important to know which version to use in any given situation.")]
    public string shop_loreRailcannon5;
    [DefaultValue("- Total recharge time is 16 seconds. Current charge is indicated by a lightning bolt on the HUD.")]
    public string shop_loreRailcannon6;
    [DefaultValue("- The Electric variation can hit the Marksman revolver's coins. Since it has infinite piercing power, with good timing and positioning one can shoot through an enemy to hit a coin, which will then ricochet the shot back into the same enemy, more than doubling the total damage dealt by a single shot.")]
    public string shop_loreRailcannon7;
    [DefaultValue("- By using the Feedbacker arm to punch an enemy that the Screwdriver variation's screw is attached to, it can be relaunched, dealing an extra burst of damage to the enemy. If the screw hits another enemy, its timer will be fully reset, meaning a screw can be juggled between enemies practically infinitely with good timing and aim, though it will break if the enemy it's attached to dies.</color>")]
    public string shop_loreRailcannon8;
    [DefaultValue("- The Malicious variation's explosion range and damage can be greatly increased by hitting an airborne core from the Core Eject shotgun. This technique is highly risky, since missing means wasting the entire shot and having to wait another 15 seconds, but its rewards are bountiful.")]
    public string shop_loreRailcannon9;

    [DefaultValue("Another weapon that used to be an industrial tool, as is visible from it and the railcannon's more vibrant color schemes compared to guns such as the revolver, shotgun and the nailgun, which uses a bullet weapon as its base.")]
    public string shop_loreRocketLauncher1;
    [DefaultValue("As with most advanced technologies, it was originally created for use in war, as its explosive-generating system was extremely fast at digging trenches, destroying obstacles or resupplying explosive weapons.")]
    public string shop_loreRocketLauncher2;
    [DefaultValue("However, this tool itself could not be used as a launcher. Early models doubled as weapons, but including the systems for triggering the explosives often caused accidental chemical reactions during their generation process, detonating the explosives before they had been completed.")]
    public string shop_loreRocketLauncher3;
    [DefaultValue("Since then, the process has been split in two between the generating device and a separate rocket launcher, where the explosives generator builds the rest of a rocket and the rocket launcher applies the triggering mechanism.")]
    public string shop_loreRocketLauncher4;
    [DefaultValue("As machines rarely have the luxury of co-operation due to sharing blood with others being seen as a waste, the machine that created this weapon instead modified the generation process to work with just a single user and repurposed parts from a jackhammer for launching the projectile.")]
    public string shop_loreRocketLauncher5;
    [DefaultValue("Instead of using a normal explosion triggering mechanism, the rockets instead use the blood of the target to complete the chemical reaction, making the generation process safe, though the weapon is more difficult to use as it requires direct hits to cause damage.")]
    public string shop_loreRocketLauncher6;
    [DefaultValue("The skill required for effective use makes it daunting, though its power more than makes up for it, and many of its wielders specifically chose to use it as a symbol of their skill at marksmanship.")]
    public string shop_loreRocketLauncher7;
    [DefaultValue("- Rockets only cause a damage-dealing explosion when hitting a living target directly, but missing on purpose can be used to launch an enemy into the air, since a direct hit on a falling enemy causes a larger, more damaging explosion.")]
    public string shop_loreRocketLauncher8;
    [DefaultValue("Rockets that have been frozen with the Freeze Frame variation for longer than a second will always cause this higher damage explosion on impact with an enemy.")]
    public string shop_loreRocketLauncher9;
    [DefaultValue("- The launcher requires very little preparation to be used, meaning it can be quickly pulled out, fired and put back away to deal a quick burst of extra damage in the middle of another weapon switching combo.")]
    public string shop_loreRocketLauncher10;
    [DefaultValue("- Rockets are pulled by the Attractor nailgun's magnets, though not as strongly as nails. The accuracy of the tracking can be increased by freezing rockets with the Freezeframe variation.")]
    public string shop_loreRocketLauncher11;
    [DefaultValue("- When hit with the Whiplash, a rocket will be attached to the spear without stopping the throw. If the spear doesn't collide with anything else, the rocket will be pulled back with it, exploding on collision with the user.")]
    public string shop_loreRocketLauncher12;
    [DefaultValue("- The cannonballs from the S.R.S. Cannon can be punched to launch them with greater force, shot with a hitscan weapon for an explosion or dropped onto the ground to launch enemies.")]
    public string shop_loreRocketLauncher13;
    [DefaultValue("- Light enemies will be airborne when pulled by the Whiplash, making them very easy targets to hit for the falling enemy explosion bonus. However, this requires a lot of distance from the target if the user wishes to avoid the explosion's increased radius.")]
    public string shop_loreRocketLauncher14;
    [DefaultValue("- Some machines, such as V1, are light enough to ride a rocket. This can be achieved by freezing a rocket with the Freezeframe variation and jumping onto it. Even with the low weight, the rocket will eventually lose power, causing it to drop gradually, but when underwater, V1 is light enough to not cause this drop.")]
    public string shop_loreRocketLauncher15;
    [DefaultValue("- Although the cannonballs from the S.R.S. Cannon variation can be punched the moment they've been launched, they will have greater durability if punched after they've bounced off an enemy.")]
    public string shop_loreRocketLauncher16;

    [DefaultValue("Standard")]
    public string shop_revolverPreset1;
    [DefaultValue("Magnum")]
    public string shop_revolverPreset2;
    [DefaultValue("Icebreaker")]
    public string shop_revolverPreset3;
    [DefaultValue("Hot & Ready")]
    public string shop_revolverPreset4;
    [DefaultValue("Sanguine")]
    public string shop_revolverPreset5;

    [DefaultValue("Standard")]
    public string shop_shotgunPreset1;
    [DefaultValue("Classic")]
    public string shop_shotgunPreset2;
    [DefaultValue("Palace")]
    public string shop_shotgunPreset3;
    [DefaultValue("Caramel")]
    public string shop_shotgunPreset4;
    [DefaultValue("Luxus")]
    public string shop_shotgunPreset5;

    [DefaultValue("Standard")]
    public string shop_nailgunPreset1;
    [DefaultValue("Acidic")]
    public string shop_nailgunPreset2;
    [DefaultValue("Clear Sky")]
    public string shop_nailgunPreset3;
    [DefaultValue("Snow Leopard")]
    public string shop_nailgunPreset4;
    [DefaultValue("Vampire")]
    public string shop_nailgunPreset5;

    [DefaultValue("Standard")]
    public string shop_railcannonPreset1;
    [DefaultValue("Inverse")]
    public string shop_railcannonPreset2;
    [DefaultValue("Love & Liquorice")]
    public string shop_railcannonPreset3;
    [DefaultValue("Statue Vein")]
    public string shop_railcannonPreset4;
    [DefaultValue("Industrial")]
    public string shop_railcannonPreset5;

    [DefaultValue("Standard")]
    public string shop_rocketlauncherPreset1;
    [DefaultValue("Rustic")]
    public string shop_rocketlauncherPreset2;
    [DefaultValue("Lipstick")]
    public string shop_rocketlauncherPreset3;
    [DefaultValue("Eggplant")]
    public string shop_rocketlauncherPreset4;
    [DefaultValue("Night Amethyst")]
    public string shop_rocketlauncherPreset5;

    [DefaultValue("Preset")]
    public string shop_colorsPreset;
    [DefaultValue("Custom")]
    public string shop_colorsCustom;
    [DefaultValue("Done")]
    public string shop_colorsDone;
    [DefaultValue("Standard")]
    public string shop_colorsStandard;

    // Renamed from shop_colorsAlternative
    [DefaultValue("Alternate")]
    public string shop_colorsAlternate;
    [DefaultValue("Unlock Custom Colors For ")]
    public string shop_colorsCustomUnlockPrompt;
}
public class Levels
{
    [DefaultValue("MAIN MENU")]
    public string levelName_mainMenu;
    [DefaultValue("THE CYBER GRIND")]
    public string levelName_cybergrind;
    [DefaultValue("uk_construct")]
    public string levelName_sandbox;
    [DefaultValue("TUTORIAL")]
    public string levelName_tutorial;
    [DefaultValue("HALL OF ULTRADEVELOPMENT")]
    public string levelName_devMuseum;

    [DefaultValue("INTO THE FIRE")]
    public string levelName_preludeFirst;
    [DefaultValue("THE MEATGRINDER")]
    public string levelName_preludeSecond;
    [DefaultValue("DOUBLE DOWN")]
    public string levelName_preludeThird;
    [DefaultValue("A ONE-MACHINE ARMY")]
    public string levelName_preludeFourth;
    [DefaultValue("CERBERUS")]
    public string levelName_preludeFifth;
    [DefaultValue("SOMETHING WICKED")]
    public string levelName_preludeSecret;

    [DefaultValue("HEART OF THE SUNRISE")]
    public string levelName_limboFirst;
    [DefaultValue("THE BURNING WORLD")]
    public string levelName_limboSecond;
    [DefaultValue("HALL OF SACRED REMAINS")]
    public string levelName_limboThird;
    [DefaultValue("CLAIR DE LUNE")]
    public string levelName_limboFourth;
    [DefaultValue("THE WITLESS")]
    public string levelName_limboSecret;

    [DefaultValue("BRIDGEBURNER")]
    public string levelName_lustFirst;
    [DefaultValue("DEATH AT 20,000 VOLTS")]
    public string levelName_lustSecond;
    [DefaultValue("SHEER HEART ATTACK")]
    public string levelName_lustThird;
    [DefaultValue("COURT OF THE CORPSE KING")]
    public string levelName_lustFourth;
    [DefaultValue("ALL-IMPERFECT LOVE SONG")]
    public string levelName_lustSecret;

    [DefaultValue("BELLY OF THE BEAST")]
    public string levelName_gluttonyFirst;
    [DefaultValue("IN THE FLESH")]
    public string levelName_gluttonySecond;

    [DefaultValue("SLAVES TO POWER")]
    public string levelName_greedFirst;
    [DefaultValue("GOD DAMN THE SUN")]
    public string levelName_greedSecond;
    [DefaultValue("A SHOT IN THE DARK")]
    public string levelName_greedThird;
    [DefaultValue("CLAIR DE SOLEIL")]
    public string levelName_greedFourth;
    [DefaultValue("CLASH OF THE BRANDICOOT")]
    public string levelName_greedSecret;

    [DefaultValue("IN THE WAKE OF POSEIDON")]
    public string levelName_wrathFirst;
    [DefaultValue("WAVES OF THE STARLESS SEA")]
    public string levelName_wrathSecond;
    [DefaultValue("SHIP OF FOOLS")]
    public string levelName_wrathThird;
    [DefaultValue("LEVIATHAN")]
    public string levelName_wrathFourth;
    [DefaultValue("I ONLY SAY MORNING")]
    public string levelName_wrathSecret;

    [DefaultValue("CRY FOR THE WEEPER")]
    public string levelName_heresyFirst;
    [DefaultValue("AESTHETICS OF HATE")]
    public string levelName_heresySecond;

    [DefaultValue("GARDEN OF FORKING PATHS")]
    public string levelName_violenceFirst;
    [DefaultValue("LIGHT UP THE NIGHT")]
    public string levelName_violenceSecond;
    [DefaultValue("NO SOUND, NO MEMORY")]
    public string levelName_violenceThird;
    [DefaultValue("...LIKE ANTENNAS TO HEAVEN")]
    public string levelName_violenceFourth;
    [DefaultValue("HELL BATH NO FURY")]
    public string levelName_violenceSecret;

    [DefaultValue("HURTBREAK WONDERLAND")]
    public string levelName_fraudFirst;
    [DefaultValue("THROUGH THE MIRROR")]
    public string levelName_fraudSecond;
    [DefaultValue("DISINTEGRATION LOOP")]
    public string levelName_fraudThird;
    [DefaultValue("FINAL FLIGHT")]
    public string levelName_fraudFourth;
    [DefaultValue("")]
    public string levelName_fraudSecret;

    [DefaultValue("???")]
    public string levelName_treacheryFirst;
    [DefaultValue("")]
    public string levelName_treacherySecond;

    [DefaultValue("SOUL SURVIVOR")]
    public string levelName_primeFirst;
    [DefaultValue("WAIT OF THE WORLD")]
    public string levelName_primeSecond;
    [DefaultValue("")]
    public string levelName_primeThird;

    [DefaultValue("THIS HEAT, AN EVIL HEAT")]
    public string levelName_encorePrelude;
    [DefaultValue("... THEN FELL THE ASHES")]
    public string levelName_encoreLimbo;
    [DefaultValue("")]
    public string levelName_encoreLust;
    [DefaultValue("")]
    public string levelName_encoreGluttony;
    [DefaultValue("")]
    public string levelName_encoreGreed;
    [DefaultValue("")]
    public string levelName_encoreWrath;
    [DefaultValue("")]
    public string levelName_encoreHeresy;
    [DefaultValue("")]
    public string levelName_encoreViolence;
    [DefaultValue("")]
    public string levelName_encoreFraud;
    [DefaultValue("")]
    public string levelName_encoreTreachery;
}

public class LevelTips
{
    [DefaultValue("The Revolver deals <color=#FF4343>locational damage</color>.")]
    public string leveltips_preludeSecond1;
    [DefaultValue("A <color=#FF4343>headshot</color> deals <color=#FF4343>2x</color> damage and a <color=#FF4343>limbshot</color> deals <color=#FF4343>1.5x</color> damage.")]
    public string leveltips_preludeSecond2;
    [DefaultValue("<color=#FF4343>Dash</color>: Fully invincible, costs stamina")]
    public string leveltips_preludeThird1;
    [DefaultValue("<color=#FF4343>Slide</color>: Greater distance, no invincibility")]
    public string leveltips_preludeThird2;
    [DefaultValue("<color=#FF4343>Jump</color>: Quickly out of melee range, less control")]
    public string leveltips_preludeThird3;
    [DefaultValue("<color=#FF4343>Shotgun parries</color>:")]
    public string leveltips_preludeFourth1;
    [DefaultValue("A <color=#FF4343>point-blank</color> Shotgun shot to the <color=#FF4343>torso</color> right before an enemy attack lands will deal massive damage.")]
    public string leveltips_preludeFourth2;
    [DefaultValue("<color=#FF4343>Attack sound cues</color> allow you to keep track of enemies who are off screen.")]
    public string leveltips_preludeFifth;

    [DefaultValue("Some enemies make <color=#FF4343>idle sounds</color> to make them easier to track.")]
    public string leveltips_limboFirst;
    [DefaultValue("Use the <color=#40E7FF>ATTRACTOR NAILGUN</color>'s magnets to form concentrated <color=#FF4343>orbs</color> of nails that can be <color=#FF4343>moved</color> around using the pull force of <color=#FF4343>other magnets</color>.")]
    public string leveltips_limboSecond;
    [DefaultValue("Enemies <color=#FF4343>can hurt</color> other enemy types.")]
    public string leveltips_limboThird1;
    [DefaultValue("With quick thinking and positioning, powerful enemies can turn into powerful weapons.")]
    public string leveltips_limboThird2;
    [DefaultValue("The <color=#40E7FF>ATTRACTOR NAILGUN</color>'s magnets can be attached to enemies to make mobile targets easy to hit with nails.")]
    public string leveltips_limboFourth;

    [DefaultValue("Enemies <color=#FF4343>scream</color> when falling from a <color=#FF4343>fatal height</color>.")]
    public string leveltips_lustFirst;
    [DefaultValue("<color=#FF4343>SLAM BOUNCING</color>:")]
    public string leveltips_lustSecond1;
    [DefaultValue("Jump immediately after landing from a <color=#FF4343>ground slam</color> to jump higher.")]
    public string leveltips_lustSecond2;
    [DefaultValue("The longer the ground slam fall, the higher the bounce.")]
    public string leveltips_lustSecond3;
    [DefaultValue("<color=#FF4343>RAILCANNON</color> variations all share the same cooldown. Choose wisely which variation best fits the situation.")]
    public string leveltips_lustThird;
    [DefaultValue("<color=#FF4343>SLIDING</color> will retain previous momentum for a short amount of time.")]
    public string leveltips_lustFourth1;
    [DefaultValue("Chaining quick <color=#FF4343>SLIDE JUMPS</color> after a <color=#00FFFF>DASH JUMP</color> will give you incredible sustained speed.")]
    public string leveltips_lustFourth2;

    [DefaultValue("<color=#FF4343>Environmental hazards</color> such as harmful liquids will hurt enemies as well.")]
    public string leveltips_gluttonyFirst;
    [DefaultValue("If you're having trouble keeping up with a tough enemy, <color=#FF4343>stand back and observe</color>.")]
    public string leveltips_gluttonySecond1;
    [DefaultValue("Every enemy has its <color=#FF4343>tells</color> and <color=#FF4343>patterns</color> and learning those can be your key to victory.")]
    public string leveltips_gluttonySecond2;

    [DefaultValue("<color=#FF4343>HITSCAN</color> weapons can be used to hit the shotgun's <color=#40E7FF>CORE EJECT</color> in mid-air to increase its damage and blast radius.")]
    public string leveltips_greedFirst;
    [DefaultValue("<color=#FF4343>POWER-UPS</color> can be stacked.")]
    public string leveltips_greedSecond;
    [DefaultValue("Hitting an enemy with only the <color=#FF4343>edge</color> of an <color=#FF4343>explosion</color> will launch them without dealing much damage, making it a risky but effective tool against <color=#FF4343>Stalkers</color>.")]
    public string leveltips_greedThird;
    [DefaultValue("Airborne <color=#FF4343>coins</color> can be shot with any <color=#FF4343>hitscan</color> weapon.")]
    public string leveltips_greedFourth;

    [DefaultValue("Falling <color=#FF4343>underwater</color> is slow, but a <color=#FF4343>ground slam</color> allows for a quick return to the ground.")]
    public string leveltips_wrathFirst;
    [DefaultValue("<color=#FF4343>Sliding</color> onto water will cause one to <color=#FF4343>skip across</color> its surface.")]
    public string leveltips_wrathSecond;
    [DefaultValue("If an enemy is <color=#FF4343>blessed</color> by an Idol, a direct visible connection is formed between the two, allowing one to easily <color=#FF4343>track down</color> and destroy the protector.")]
    public string leveltips_wrathThird;
    [DefaultValue("Ow.")]
    public string leveltips_wrathThirdBroken;
    [DefaultValue("<color=#FF4343>Explosions</color> deflect <color=#FF4343>projectiles</color>.")]
    public string leveltips_wrathFourth1;
    [DefaultValue("If an explosion is caused right from where an enemy shoots a projectile, it can <color=#FF4343>backfire</color> and <color=#FF4343>hit them</color> instead.")]
    public string leveltips_wrathFourth2;

    [DefaultValue("The space of a <color=#FF4343>large</color> arena can be used to one's advantage.")]
    public string leveltips_heresyFirst1;
    [DefaultValue("Using the environment to <color=#FF4343>break line-of-sight</color> with enemies allows for some breathing room and time to consider <color=#FF4343>target prioritization</color>.")]
    public string leveltips_heresyFirst2;
    [DefaultValue("<color=#FF4343>DON'T WASTE STAMINA!</color>")]
    public string leveltips_heresySecond1;
    [DefaultValue("Dashing <color=#FF4343>needlessly</color> while fighting very <color=#FF4343>aggressive foes</color> will quickly cause one to have none left when it is most needed.")]
    public string leveltips_heresySecond2;

    [DefaultValue("<color=#FF4343>Homing projectiles</color> may be more difficult to dodge, but their tracking and slower speed makes them much <color=#FF4343>easier</color> to <color=#FF4343>parry.</color>")]
    public string leveltips_violenceFirst;
    [DefaultValue("<color=#FF4343>Mannequins</color> can be hard to hit due to their speed, but they lose air control when <color=#FF4343>launched</color> or <color=#FF4343>shot down</color> from a surface, making them <color=#FF4343>unable to move</color> for a short moment.")]
    public string leveltips_violenceSecond;
    [DefaultValue("The <color=red>Knuckleblaster</color>'s <color=#FF4343>blast wave</color> is also capable of breaking a <color=#FF4343>Gutterman's shield</color>, and is much easier to land in a chaotic scenario.")]
    public string leveltips_violenceThird;
    [DefaultValue("A <color=#FF4343>direct hit</color> from the <color=red>Knuckleblaster</color> has extremely powerful <color=#FF4343>knockback</color>, making it extremely powerful for launching enemies into <color=#FF4343>pits</color> and other <color=#FF4343>environmental hazards</color>.")]
    public string leveltips_violenceFourth;
    [DefaultValue("Didn't expect me, huh?")]
    public string leveltips_violenceSecret;

    [DefaultValue("<color=#FF0073>Magenta</color> colored attacks can <color=#FF4343>not</color> be dashed through and must be <color=#FF4343>avoided entirely</color>.")]
    public string leveltips_fraudFirst;
    [DefaultValue("<color=#FF4343>Blood puppets</color> do not grant kills or style points, but their <color=#FF4343>blood</color> can still <color=#FF4343>heal</color>.")]
    public string leveltips_fraudSecond;
    [DefaultValue("When facing down <color=#FF4343>a difficult foe</color>, it may be beneficial to first get rid of the <color=#FF4343>fodder</color> to reduce distractions.")]
    public string leveltips_fraudThird;
    [DefaultValue("Sometimes it may be more beneficial to <color=#FF4343>stay at a distance</color> and wait for an opening <color=#FF4343>before</color> getting close.")]
    public string leveltips_fraudFourth;

    [DefaultValue("")]
    public string leveltips_treacheryFirst;
    [DefaultValue("")]
    public string leveltips_treacherySecond;

    [DefaultValue("If you're having <color=#FF4343>trouble</color> with a specific encounter, take a moment to <color=#FF4343>weigh your options</color>.")]
    public string leveltips_encorePrelude1;
    [DefaultValue("There may be some <color=#FF4343>trick</color>, <color=#FF4343>tool</color> or <color=#FF4343>alternate prioritization</color> that will tip the scales in your favor.")]
    public string leveltips_encorePrelude2;
    [DefaultValue("<color=#FF4343>ENEMY STEP</color>: Jump while in mid-air <color=#FF4343>near an enemy</color> to jump off the enemy. This resets the amount of available walljumps without needing to land.")]
    public string leveltips_encoreLimbo;
    [DefaultValue("")]
    public string leveltips_encoreLust;
    [DefaultValue("")]
    public string leveltips_encoreGluttony;
    [DefaultValue("")]
    public string leveltips_encoreGreed;
    [DefaultValue("")]
    public string leveltips_encoreWrath;
    [DefaultValue("")]
    public string leveltips_encoreHeresy;
    [DefaultValue("")]
    public string leveltips_encoreViolence;
    [DefaultValue("")]
    public string leveltips_encoreFraud;
    [DefaultValue("")]
    public string leveltips_encoreTreachery;

    [DefaultValue("<color=#FF4343>Parries</color> can be used as a powerful healing tool.")]
    public string leveltips_primeFirst1;
    [DefaultValue("Parrying any enemy projectile or melee attack will <color=#44FF45>fully replenish your health</color> up to the hard damage limit.")]
    public string leveltips_primeFirst2;
    [DefaultValue("H a v e   f u n .")]
    public string leveltips_primeSecond;
    [DefaultValue("")]
    public string leveltips_primeThird;

    [DefaultValue("If blown too far off the arena, <color=#44FF45>PUMP CHARGE</color>'s overcharge is a good way to get back.")]
    public string leveltips_cybergrind;
    [DefaultValue("<color=#FF4343>CHEATS</color> can be enabled in other levels by inputting")]
    public string leveltips_sandbox1;
    [DefaultValue("Enabling cheats will disable ranks.")]
    public string leveltips_sandbox2;
    public string levelTips_sandboxCheatCode;

    [DefaultValue("You can pick up the <color=#FF4343>cut weapons</color> on the <color=#FF4343>second floor</color>.")]
    public string leveltips_devMuseum;
}

public class EnemyNames
{
    [DefaultValue("FILTH")]
    public string enemyname_filth;
    [DefaultValue("STRAY")]
    public string enemyname_stray;
    [DefaultValue("SCHISM")]
    public string enemyname_schism;
    [DefaultValue("SOLDIER")]
    public string enemyname_soldier;
    [DefaultValue("STALKER")]
    public string enemyname_stalker;
    [DefaultValue("INSURRECTIONIST")]
    public string enemyname_insurrectionist;
    [DefaultValue("SWORDSMACHINE")]
    public string enemyname_swordsmachine;
    [DefaultValue("DRONE")]
    public string enemyname_drone;
    [DefaultValue("STREETCLEANER")]
    public string enemyname_streetCleaner;
    [DefaultValue("SENTRY")]
    public string enemyname_sentry;
    [DefaultValue("GUTTERMAN")]
    public string enemyname_gutterman;
    [DefaultValue("GUTTERTANK")]
    public string enemyname_guttertank;
    [DefaultValue("EARTHMOVER")]
    public string enemyname_earthmover;
    [DefaultValue("IDOL")]
    public string enemyname_idol;
    [DefaultValue("FERRYMAN")]
    public string enemyname_ferryman;
    [DefaultValue("FERRYMAN \"RUDRAKSHA\"")]
    public string enemyname_boss_ferrymanRudraksha;
    [DefaultValue("FERRYMAN \"AGONIS\"")]
    public string enemyname_boss_ferrymanAgonis;
    [DefaultValue("LEVIATHAN")]
    public string enemyname_leviathan;
    [DefaultValue("V2")]
    public string enemyname_v2;
    [DefaultValue("V2 (2ND)")]
    public string enemyname_v2Second;
    [DefaultValue("MINDFLAYER")]
    public string enemyname_mindFlayer;
    [DefaultValue("MALICIOUS FACE")]
    public string enemyname_malFace;
    [DefaultValue("CERBERUS")]
    public string enemyname_cerberus;
    [DefaultValue("HIDEOUS MASS")]
    public string enemyname_hideousMass;
    [DefaultValue("MANNEQUIN")]
    public string enemyname_mannequin;
    [DefaultValue("MINOTAUR")]
    public string enemyname_minotaur;
    [DefaultValue("GABRIEL")]
    public string enemyname_gabriel;
    [DefaultValue("GABRIEL")]
    public string enemyname_gabrielSecond;
    [DefaultValue("VIRTUE")]
    public string enemyname_virtue;
    [DefaultValue("SOMETHING WICKED")]
    public string enemyname_somethingWicked;
    [DefaultValue("???")]
    public string enemyname_puppet;
    [DefaultValue("EARTHMOVER MORTAR")]
    public string enemyname_earthmoverMortar;
    [DefaultValue("EARTHMOVER ROCKET LAUNCHER")]
    public string enemyname_earthmoverRocketLauncher;
    [DefaultValue("EARTHMOVER TOWER")]
    public string enemyname_earthmoverTower;
    [DefaultValue("GERYON")]
    public string enemyname_geryon;

    [DefaultValue("RADIANT SWORDMACHINE")]
    public string enemyname_radiant_swordsmachine;
    [DefaultValue("RADIANT CERBERUS, GUARDIAN OF HELL")]
    public string enemyname_radiant_cerberus;
    [DefaultValue("RADIANT HIDEOUS MASS")]
    public string enemyname_radiant_hideousMass;

    [DefaultValue("CERBERUS, GUARDIAN OF HELL")]
    public string enemyname_boss_cerberus;
    [DefaultValue("CANCEROUS RODENT")]
    public string enemyname_boss_cancerousRodent;
    [DefaultValue("VERY CANCEROUS RODENT")]
    public string enemyname_boss_veryCancerousRodent;
    [DefaultValue("HIDEOUS MASS")]
    public string enemyname_boss_hideousMass;
    [DefaultValue("SWORDSMACHINE \"AGONY\"")]
    public string enemyname_boss_swordsmachineAgony;
    [DefaultValue("SWORDSMACHINE \"TUNDRA\"")]
    public string enemyname_boss_swordsmachineTundra;
    [DefaultValue("THE CORPSE OF KING MINOS")]
    public string enemyname_boss_corpseOfKingMinos;
    [DefaultValue("GABRIEL, JUDGE OF HELL")]
    public string enemyname_boss_gabriel;
    [DefaultValue("SISYPHEAN INSURRECTIONIST")]
    public string enemyname_boss_insurrectionist;
    [DefaultValue("MYSTERIOUS DRUID KNIGHT (& OWL)")]
    public string enemyname_boss_mandalore;
    [DefaultValue("1000-THR \"EARTHMOVER\"")]
    public string enemyname_boss_earthmover;
    [DefaultValue("1000-THR DEFENCE SYSTEM")]
    public string enemyname_boss_earthmoverDefence;
    [DefaultValue("FERRYMAN")]
    public string enemyname_boss_ferryman;
    [DefaultValue("LEVIATHAN")]
    public string enemyname_boss_leviathan;
    [DefaultValue("INSURRECTIONIST \"RUDE\"")]
    public string enemyname_boss_insurrectionistRude;
    [DefaultValue("INSURRECTIONIST \"ANGRY\"")]
    public string enemyname_boss_insurrectionistAngry;
    [DefaultValue("GABRIEL, APOSTATE OF HATE")]
    public string enemyname_boss_gabrielSecond;
    [DefaultValue("FLESH PRISON")]
    public string enemyname_boss_fleshPrison;
    [DefaultValue("FLESH PANOPTICON")]
    public string enemyname_boss_fleshPanopticon;
    [DefaultValue("MINOS PRIME")]
    public string enemyname_boss_minosPrime;
    [DefaultValue("SISYPHUS PRIME")]
    public string enemyname_boss_sisyphusPrime;
    [DefaultValue("BIG JOHNINATOR")]
    public string enemyname_boss_bigJohninator;


    [DefaultValue("Lesser Husk")]
    public string enemyname_type_lesserHusk;
    [DefaultValue("Greater Husk")]
    public string enemyname_type_greaterHusk;
    [DefaultValue("Supreme Husk")]
    public string enemyname_type_supremeHusk;
    [DefaultValue("Lesser Demon")]
    public string enemyname_type_lesserDemon;
    [DefaultValue("Greater Demon")]
    public string enemyname_type_greaterDemon;
    [DefaultValue("Supreme Demon")]
    public string enemyname_type_supremeDemon;
    [DefaultValue("Lesser Machine")]
    public string enemyname_type_lesserMachine;
    [DefaultValue("Greater Machine")]
    public string enemyname_type_greaterMachine;
    [DefaultValue("Supreme Machine")]
    public string enemyname_type_supremeMachine;
    [DefaultValue("Lesser Angel")]
    public string enemyname_type_lesserAngel;
    [DefaultValue("Greater Angel")]
    public string enemyname_type_greaterAngel;
    [DefaultValue("Supreme Angel")]
    public string enemyname_type_supremeAngel;
    [DefaultValue("Prime Soul")]
    public string enemyname_type_primeSoul;

    [DefaultValue("PROVIDENCE")]
    public string enemyname_boss_providence;
    [DefaultValue("DEATHCATCHER")]
    public string enemyname_deathcatcher;
    [DefaultValue("MIRROR REAPER")]
    public string enemyname_boss_mirrorReaper;
    [DefaultValue("POWER")]
    public string enemyname_power;
    [DefaultValue("POWER \"MANADEL\"")]
    public string enemyname_boss_powerManadel;
    [DefaultValue("POWER \"LEHAHIAH\"")]
    public string enemyname_boss_powerLehahiah;
    [DefaultValue("POWER \"CHAUAKIAH\"")]
    public string enemyname_boss_powerChauakiah;
    [DefaultValue("GERYON, WATCHER OF THE SKIES")]
    public string enemyname_boss_geryon;
}

public class Option
{
    [DefaultValue("OPTIONS")]
    public string options_title;
    [DefaultValue("BACK")]
    public string options_back;

    [DefaultValue("GENERAL")]
    public string category_general;
    [DefaultValue("CONTROLS")]
    public string category_controls;
    [DefaultValue("GRAPHICS")]
    public string category_graphics;
    [DefaultValue("AUDIO")]
    public string category_audio;
    [DefaultValue("ASSISTS")]
    public string category_assists;
    [DefaultValue("SAVES")]
    public string category_saves;
    [DefaultValue("CUSTOMIZATION")]
    public string category_customization;
    [DefaultValue("HUD")]
    public string category_hud;
    [DefaultValue("COLORS")]
    public string category_colors;

    [DefaultValue("WEAPON POSITION")]
    public string general_weaponPosition;
    [DefaultValue("RIGHT")]
    public string general_weaponPositionRight;
    [DefaultValue("MIDDLE")]
    public string general_weaponPositionMiddle;
    [DefaultValue("LEFT")]
    public string general_weaponPositionLeft;
    [DefaultValue("REMEMBER LAST USED WEAPON VARIATION")]
    public string general_rememberWeapon;
    [DefaultValue("SCREEN")]
    public string general_screen;
    [DefaultValue("SCREENSHAKE")]
    public string general_screenShake;
    [DefaultValue("NONE")]
    public string general_screenShakeMinimum;
    [DefaultValue("JUICE")]
    public string general_screenShakeMaximum;
    [DefaultValue("CAMERA TILT")]
    public string general_cameraTilt;
    [DefaultValue("PARRY SCREEN FLASH")]
    public string general_parryFlash;
    [DefaultValue("MISC")]
    public string general_misc;
    [DefaultValue("MISSION RESTART/QUIT WARNING")]
    public string general_restartWarning;
    [DefaultValue("ALWAYS ON")]
    public string general_restartWarningAlwaysOn;
    [DefaultValue("CYBERGRIND ONLY")]
    public string general_restartWarningOnlyCG;
    [DefaultValue("ALWAYS OFF")]
    public string general_restartWarningAlwaysOff;
    [DefaultValue("SANDBOX SAVE OVERWRITE WARNING")]
    public string general_sandboxOverwrite;
    [DefaultValue("DISCORD INTEGRATION")]
    public string general_discordRpc;
    [DefaultValue("SEASONAL EVENTS")]
    public string general_seasonalEvent;

    [DefaultValue("LEVEL LEADERBOARDS")]
    public string general_levelLeaderboards;
    [DefaultValue("ADVANCED OPTIONS")]
    public string general_advancedOptions;
    [DefaultValue("OPEN")]
    public string general_advancedOptionsCustomize;

    [DefaultValue("LOOK SENSITIVITY")]
    public string controls_mouseSensitivity;
    [DefaultValue("INVERT X AXIS")]
    public string controls_xInversion;
    [DefaultValue("INVERT Y AXIS")]
    public string controls_yInversion;
    [DefaultValue("CONTROLLER RUMBLE")]
    public string controls_controllerRumble;
    [DefaultValue("CUSTOMIZE")]
    public string controls_controllerRumbleCustomize;
    [DefaultValue("WEAPONS")]
    public string controls_weapons;
    [DefaultValue("SCROLL WEAPONS WITH MOUSE WHEEL")]
    public string controls_mouseWheelToChangeWeapon;
    [DefaultValue("WEAPON SCROLL TYPE")]
    public string controls_scrollType;
    [DefaultValue("WEAPONS")]
    public string controls_scrollTypeWeapons;
    [DefaultValue("VARIATIONS")]
    public string controls_scrollTypeVariations;
    [DefaultValue("BOTH")]
    public string controls_scrollTypeAll;
    [DefaultValue("REVERSE SCROLL DIRECTION")]
    public string controls_reverseScroll;
    [DefaultValue("ON SWAP TO ALREADY DRAWN WEAPON")]
    public string controls_redrawBehaviour;
    [DefaultValue("NEXT VARIATION")]
    public string controls_redrawNext;
    [DefaultValue("FIRST VARIATION")]
    public string controls_redrawFirst;
    [DefaultValue("SAME VARIATION")]
    public string controls_redrawSame;
    [DefaultValue("INVERT ROCKET CONTROLS")]
    public string controls_invertRocketControls;
    [DefaultValue("BINDINGS")]
    public string controls_bindings;
    [DefaultValue("MOVEMENT")]
    public string controls_movement;
    [DefaultValue("MOVE")]
    public string controls_move;
    [DefaultValue("DODGE")]
    public string controls_dodge;
    [DefaultValue("SLIDE")]
    public string controls_slide;
    [DefaultValue("JUMP")]
    public string controls_jump;
    [DefaultValue("WEAPON")]
    public string controls_weaponTitle;
    [DefaultValue("PRIMARY FIRE")]
    public string controls_primaryFire;
    [DefaultValue("SECONDARY FIRE")]
    public string controls_secondaryFire;
    [DefaultValue("NEXT VARIATION")]
    public string controls_nextVariation;
    [DefaultValue("PREVIOUS\nVARIATION")]
    public string controls_previousVariation;
    [DefaultValue("REVOLVER")]
    public string controls_revolver;
    [DefaultValue("SHOTGUN")]
    public string controls_shotgun;
    [DefaultValue("NAILGUN")]
    public string controls_nailgun;
    [DefaultValue("RAILCANNON")]
    public string controls_railcannon;
    [DefaultValue("ROCKET LAUNCHER")]
    public string controls_rocketLauncher;
    [DefaultValue("SPAWNER ARM")]
    public string controls_spawnerArm;
    [DefaultValue("NEXT WEAPON")]
    public string controls_nextWeapon;
    [DefaultValue("PREVIOUS\nWEAPON")]
    public string controls_previousWeapon;
    [DefaultValue("LAST USED WEAPON")]
    public string controls_lastUsedWeapon;
    [DefaultValue("VARIATION SLOT 1")]
    public string controls_variationSlot1;
    [DefaultValue("VARIATION SLOT 2")]
    public string controls_variationSlot2;
    [DefaultValue("VARIATION SLOT 3")]
    public string controls_variationSlot3;
    [DefaultValue("FIST")]
    public string controls_fist;
    [DefaultValue("PUNCH")]
    public string controls_punch;
    [DefaultValue("CHANGE FIST")]
    public string controls_changeFist;
    [DefaultValue("PUNCH (FEEDBACKER)")]
    public string controls_punchFeedbacker;
    [DefaultValue("PUNCH (KNUCKLEBLASTER)")]
    public string controls_punchKnuckleblaster;
    [DefaultValue("HOOK")]
    public string controls_whiplash;
    [DefaultValue("IS BOUND MULTIPLE TIMES")]
    public string controls_boundMultiple;
    public string controls_stats;

    [DefaultValue("RESOLUTION")]
    public string graphics_resolution;
    [DefaultValue("FULLSCREEN")]
    public string graphics_fullscreen;
    [DefaultValue("TARGET FRAMERATE")]
    public string graphics_maxFps;
    [DefaultValue("NONE")]
    public string graphics_maxFpsNone;
    [DefaultValue("2X SCREEN'S REFRESH RATE")]
    public string graphics_maxFps2x;
    [DefaultValue("VSYNC")]
    public string graphics_vsync;
    [DefaultValue("FIELD OF VIEW")]
    public string graphics_fieldOfVision;
    [DefaultValue("GAMMA (BRIGHTNESS)")]
    public string graphics_gamma;
    [DefaultValue("USE FALLBACK SHADERS (REQUIRES RELOAD)")]
    public string graphics_useFallbackShaders;
    [DefaultValue(" PSX ")]
    public string graphics_filters;
    [DefaultValue("(Tone down for more visual clarity)")]
    public string graphics_filtersDescription;
    [DefaultValue("DOWNSCALING")]
    public string graphics_pixelisation;
    [DefaultValue("OFF")]
    public string graphics_pixelisationNone;
    [DefaultValue("720P (VERY LOW)")]
    public string graphics_pixelisation720p;
    [DefaultValue("480P (LOW)")]
    public string graphics_pixelisation480p;
    [DefaultValue("360P (MEDIUM)")]
    public string graphics_pixelisation360p;
    [DefaultValue("240P (HIGH)")]
    public string graphics_pixelisation240p;
    [DefaultValue("144P (VERY HIGH)")]
    public string graphics_pixelisation144p;
    [DefaultValue("36P (ABSURD)")]
    public string graphics_pixelisation36p;
    [DefaultValue("DITHERING")]
    public string graphics_dithering;
    [DefaultValue("NONE")]
    public string graphics_ditheringMinimum;
    [DefaultValue("TEXTURE WARPING")]
    public string graphics_textureWarping;
    [DefaultValue("VERTEX WARPING")]
    public string graphics_vertexWarping;
    [DefaultValue("NONE")]
    public string graphics_vertexWarpingNone;
    [DefaultValue("LIGHT")]
    public string graphics_vertexWarpingLight;
    [DefaultValue("MEDIUM")]
    public string graphics_vertexWarpingMedium;
    [DefaultValue("HEAVY")]
    public string graphics_vertexWarpingStrong;
    [DefaultValue("VERY HEAVY")]
    public string graphics_vertexWarpingVeryStrong;
    [DefaultValue("MODERN ART")]
    public string graphics_vertexWarpingAbsurd;

    [DefaultValue("CUSTOM COLOR PALETTE")]
    public string graphics_customColorPalette;
    [DefaultValue("COLOR PALETTE TEXTURE")]
    public string graphics_customPaletteTexture;
    [DefaultValue("SELECT")]
    public string graphics_customColorPaletteSelect;
    [DefaultValue("Gamebot Color")]
    public string graphics_customColorPaletteGamebotColor;
    [DefaultValue("Noir")]
    public string graphics_customColorPaletteNoir;
    [DefaultValue("Pink and Purple")]
    public string graphics_customColorPalettePinkAndPurple;
    [DefaultValue("Rustic")]
    public string graphics_customColorPaletteRustic;
    [DefaultValue("Shake")]
    public string graphics_customColorPaletteShake;
    [DefaultValue("Sin Shitty")]
    public string graphics_customColorPaletteSinShitty;

    [DefaultValue("COLOR COMPRESSION")]
    public string graphics_colorCompression;
    [DefaultValue("NONE")]
    public string graphics_colorCompressionNone;
    [DefaultValue("LIGHT")]
    public string graphics_colorCompressionLight;
    [DefaultValue("MEDIUM")]
    public string graphics_colorCompressionMedium;
    [DefaultValue("HEAVY")]
    public string graphics_colorCompressionStrong;
    [DefaultValue("VERY HEAVY")]
    public string graphics_colorCompressionVeryStrong;
    [DefaultValue("INDIE ART GAME")]
    public string graphics_colorCompressionAbsurd;
    [DefaultValue(" PERFORMANCE ")]
    public string graphics_performance;
    [DefaultValue("SIMPLER EXPLOSIONS")]
    public string graphics_performanceSimpleExplosions;
    [DefaultValue("SIMPLER FIRE")]
    public string graphics_performanceSimpleFire;
    [DefaultValue("SIMPLER SPAWN EFFECTS")]
    public string graphics_performanceSimpleSpawn;
    [DefaultValue("DISABLE ENVIRONMENTAL PARTICLE EFFECTS")]
    public string graphics_performanceDisableEnviParticles;
    [DefaultValue("DISABLE ENVIRONMENTAL HIT PARTICLES")]
    public string graphics_performanceDisableEnviHitParticles;
    [DefaultValue("DISABLE HEAT WAVES")]
    public string graphics_performanceDisableHeatWaves;
    [DefaultValue(" GORE ")]
    public string graphics_gore;
    [DefaultValue("ENABLE BLOOD & GORE")]
    public string graphics_goreEnable;
    [DefaultValue("FREEZE GORE PHYSICS")]
    public string graphics_goreDisablePhysics;
    [DefaultValue("MAX BLOODSTAINS")]
    public string graphics_goreMaxBloodStains;
    [DefaultValue("BLOODSTAIN CHANCE")]
    public string graphics_goreBloodChance;
    [DefaultValue("MAX GORE PER ROOM")]
    public string graphics_goreMaxGore;

    [DefaultValue("VOLUME")]
    public string audio_volume;
    [DefaultValue("SUBTITLES")]
    public string audio_subtitles;
    [DefaultValue("MASTER")]
    public string audio_globalVolume;
    [DefaultValue("SOUND EFFECTS")]
    public string audio_soundEffectsVolume;
    [DefaultValue("MUSIC")]
    public string audio_musicVolume;
    [DefaultValue("MUFFLE MUSIC WHILE UNDERWATER")]
    public string audio_muffleMusic;
    [DefaultValue("AUDIO DUBBING")]
    public string audio_dubbing;
    [DefaultValue("EXTRA AUDIO DUBBING")]
    public string audio_dubbing_extra;

    [DefaultValue("HUD TYPE")]
    public string hud_type;
    [DefaultValue("NONE")]
    public string hud_typeNone;
    [DefaultValue("STANDARD")]
    public string hud_typeStandard;
    [DefaultValue("CLASSIC COLOR")]
    public string hud_typeClassicColor;
    [DefaultValue("CLASSIC WHITE")]
    public string hud_typeClassicWhite;
    [DefaultValue(" ELEMENTS ")]
    public string hud_hudElements;
    [DefaultValue("BACKGROUND OPACITY")]
    public string hud_backgroundOpacity;
    [DefaultValue("NONE")]
    public string hud_backgroundOpacityMinimum;
    [DefaultValue("100% BLACK")]
    public string hud_backgroundOpacityMaximum;
    [DefaultValue("ALWAYS ON TOP")]
    public string hud_alwaysOnTop;
    [DefaultValue("CHEAT & SANDBOX ICONS")]
    public string hud_icons;
    public string hud_iconsDefault;
    [DefaultValue("REDUCE HUD MOTION")]
    public string hud_reduceHudMotion;
    [DefaultValue("WEAPON ICON")]
    public string hud_weaponIcon;
    [DefaultValue("ARM ICON")]
    public string hud_armIcon;
    [DefaultValue("RAILCANNON METER")]
    public string hud_railcannonMeter;
    [DefaultValue("STYLE METER")]
    public string hud_styleMeter;
    [DefaultValue("STYLE INFO")]
    public string hud_styleInfo;
    [DefaultValue("SPEEDOMETER")]
    public string hud_speedoMeterText;
    [DefaultValue("OFF")]
    public string hud_speedoMeterTypeOff;
    [DefaultValue("ON")]
    public string hud_speedoMeterTypeOn;
    [DefaultValue("HORIZONAL ONLY")]
    public string hud_speedoMeterTypeHorizonal;
    [DefaultValue("VERTICAL ONLY")]
    public string hud_speedoMeterTypeVertical;

    [DefaultValue(" CROSSHAIR ")]
    public string crosshair_title;
    [DefaultValue("TYPE")]
    public string crosshair_type;
    [DefaultValue("NONE")]
    public string crosshair_typeNone;
    [DefaultValue("SMALL")]
    public string crosshair_typeSmall;
    [DefaultValue("LARGE")]
    public string crosshair_typeLarge;
    [DefaultValue("COLOR")]
    public string crosshair_color;
    [DefaultValue("INVERTED")]
    public string crosshair_colorInverted;
    [DefaultValue("WHITE")]
    public string crosshair_colorWhite;
    [DefaultValue("GREY")]
    public string crosshair_colorGrey;
    [DefaultValue("BLACK")]
    public string crosshair_colorBlack;
    [DefaultValue("RED")]
    public string crosshair_colorRed;
    [DefaultValue("GREEN")]
    public string crosshair_colorGreen;
    [DefaultValue("BLUE")]
    public string crosshair_colorBlue;
    [DefaultValue("CYAN")]
    public string crosshair_colorCyan;
    [DefaultValue("YELLOW")]
    public string crosshair_colorYellow;
    [DefaultValue("MAGENTA")]
    public string crosshair_colorMagenta;

    [DefaultValue("CROSSHAIR HUD SIZE")]
    public string crosshair_size;
    [DefaultValue("NONE")]
    public string crosshair_sizeNone;
    [DefaultValue("THIN")]
    public string crosshair_sizeThin;
    [DefaultValue("MEDIUM")]
    public string crosshair_sizeMedium;
    [DefaultValue("THICK")]
    public string crosshair_sizeThick;
    [DefaultValue("EXTRA THICC")]
    public string crosshair_sizeVeryThick;
    [DefaultValue("CROSSHAIR HUD FADE")]
    public string crosshair_hudFade;
    [DefaultValue("POWERUP METER")]
    public string crosshair_powerupBar;

    [DefaultValue("ASSISTS")]
    public string assists_title;
    [DefaultValue("<size=20>\"<color=orange>Major Assists</color>\" consists of modifiers that change the game and its balance <color=orange>considerably</color>.")]
    public string assists_majorAssistsDisclaimer1;
    [DefaultValue("If \"Major Assists\" is enabled <color=orange>at any point</color> during a mission, the rank gained upon completion will have a blue background. This background <color=orange>can be removed</color> by achieving <color=orange>the same rank or higher</color> with \"Major Assists\" disabled for the duration of the <color=orange>entire</color> mission.")]
    public string assists_majorAssistsDisclaimer2;
    [DefaultValue("\"<color=yellow>Perfect</color>\" ranks and Cyber Grind high scores cannot be achieved with \"Major Assists\" enabled</size>")]
    public string assists_majorAssistsDisclaimer3;
    [DefaultValue("<size=36>ENABLE MAJOR ASSISTS?</size>")]
    public string assists_majorAssistsDisclaimerConfirm;
    [DefaultValue("YES")]
    public string assists_majorAssistsDisclaimerConfirmYes;
    [DefaultValue("NO")]
    public string assists_majorAssistsDisclaimerConfirmNo;
    [DefaultValue("MINOR ASSISTS")]
    public string assists_minorAssistsTitle;
    [DefaultValue(" MINOR ASSISTS ")]
    public string assists_minor;
    [DefaultValue("AUTO AIM")]
    public string assists_autoAim;
    [DefaultValue("AUTO AIM AMOUNT")]
    public string assists_autoAimPercent;
    [DefaultValue("NONE")]
    public string assists_autoAimPercentMinimum;
    [DefaultValue("FULLSCREEN")]
    public string assists_autoAimPercentMaximum;
    [DefaultValue(" ENEMY SILHOUETTES ")]
    public string assists_enemySilhouettes;
    [DefaultValue("OUTLINE ONLY")]
    public string assists_enemySilhouettesOutlines;
    [DefaultValue("ACTIVATION DISTANCE")]
    public string assists_enemySilhouettesDistance;
    [DefaultValue("ALWAYS ON")]
    public string assists_enemySilhouettesDistanceMinimum;
    [DefaultValue("NONE")]
    public string assists_enemySilhouettesNone;
    [DefaultValue("OUTLINE ONLY")]
    public string assists_enemySilhouettesOutlinesOnly;
    [DefaultValue("FULL")]
    public string assists_enemySilhouettesFull;
    [DefaultValue("OUTLINE THICKNESS")]
    public string assists_enemySilhouettesOutlineThickness;
    [DefaultValue(" <size=24>MAJOR ASSISTS</size> ")]
    public string assists_major;
    [DefaultValue("ENABLE")]
    public string assists_majorActivate;
    [DefaultValue("GAME SPEED")]
    public string assists_gameSpeed;
    [DefaultValue("DAMAGE TAKEN")]
    public string assists_damageTaken;
    [DefaultValue("BOSS FIGHT DIFFICULTY OVERRIDE")]
    public string assists_bossOverride;
    [DefaultValue("REQUIRES BOSS RESTART")]
    public string assists_bossRestartRequired;
    [DefaultValue("NONE")]
    public string assists_bossOverrideNone;
    [DefaultValue("INFINITE STAMINA")]
    public string assists_infiniteEnergy;
    [DefaultValue("DISABLE WHIPLASH HARD DAMAGE")]
    public string assists_disableWhiplashHardDamage;
    [DefaultValue("DISABLE ALL HARD DAMAGE")]
    public string assists_disableHardDamage;
    [DefaultValue("DISABLE WEAPON FRESHNESS")]
    public string assists_disableWeaponFreshness;
    [DefaultValue("DISABLE ASSIST POPUP")]
    public string assists_disablePopupHints;

    [DefaultValue("COLORS")]
    public string colors_title;
    [DefaultValue("RESET TO DEFAULT")]
    public string colors_reset;
    [DefaultValue("HUD")]
    public string colors_hud;
    [DefaultValue("HEALTH")]
    public string colors_hudHealth;
    [DefaultValue("HEALTH NUMBER")]
    public string colors_hudHealthNumber;
    [DefaultValue("SOFT DAMAGE")]
    public string colors_hudDamage;
    [DefaultValue("HARD DAMAGE")]
    public string colors_hudHardDamage;
    [DefaultValue("OVERHEAL")]
    public string colors_hudOverheal;
    [DefaultValue("STAMINA (FULL)")]
    public string colors_hudEnergyFull;
    [DefaultValue("STAMINA (CHARGING)")]
    public string colors_hudEnergyPartial;
    [DefaultValue("STAMINA (EMPTY)")]
    public string colors_hudEnergyEmpty;
    [DefaultValue("RAILCANNON (FULL)")]
    public string colors_railcannonFull;
    [DefaultValue("RAILCANNON (CHARGING)")]
    public string colors_railcannonPartial;
    [DefaultValue("BLUE VARIATION")]
    public string colors_variationBlue;
    [DefaultValue("GREEN VARIATION")]
    public string colors_variationGreen;
    [DefaultValue("RED VARIATION")]
    public string colors_variationRed;
    [DefaultValue("GOLD VARIATION")]
    public string colors_variationGold;
    [DefaultValue("ENEMY SILHOUETTES")]
    public string colors_enemies;

    [DefaultValue("SELECT")]
    public string save_select;
    [DefaultValue("SELECTED")]
    public string save_selected;
    [DefaultValue("DELETE")]
    public string save_delete;
    [DefaultValue("The game will reload.")]
    public string save_warning1;
    [DefaultValue("If you're in a mission, your current progress will be lost.")]
    public string save_warning2;
    [DefaultValue("I UNDERSTAND")]
    public string save_reloadYes;
    [DefaultValue("CANCEL")]
    public string save_reloadNo;
    [DefaultValue("Are you sure you want to ")]
    public string save_deleteWarning1;
    [DefaultValue("DELETE SLOT")]
    public string save_deleteWarning2;
    [DefaultValue("?")]
    public string save_deleteWarning3;
    [DefaultValue("<color=white>YES,</color> DELETE")]
    public string save_deleteYes;
    [DefaultValue("CANCEL")]
    public string save_deleteNo;
    [DefaultValue("CLOSE")]
    public string save_close;
    [DefaultValue("EMPTY")]
    public string save_slotEmpty;
    [DefaultValue("Slot 1")]
    public string save_slot1;
    [DefaultValue("Slot 2")]
    public string save_slot2;
    [DefaultValue("Slot 3")]
    public string save_slot3;
    [DefaultValue("Slot 4")]
    public string save_slot4;
    [DefaultValue("Slot 5")]
    public string save_slot5;

    [DefaultValue("DUPLICATE SAVE")]
    public string save_failMergeError1;
    [DefaultValue("We found save files <b>both</b> directly in the Saves directory and the <b>first slot</b>.")]
    public string save_failMergeError2;
    [DefaultValue("Pick which one you want to <b>keep</b>.")]
    public string save_failMergeError3;
    [DefaultValue("QUIT GAME")]
    public string save_failMergeErrorQuitButton;
    [DefaultValue("SAVE FAILED")]
    public string save_saveloadFailError1;
    [DefaultValue("The game is unable to finalize saving your progress.")]
    public string save_saveloadFailError2;
    [DefaultValue("COMMON REASONS FOR FAILURE:")]
    public string save_saveloadFailError3;
    [DefaultValue("1. Third party software (such as an antivirus) stopping the game from saving a new file")]
    public string save_saveloadFailError4;
    [DefaultValue("If this problem occurs again, make sure your antivirus or any similar software is not preventing the game from writing files")]
    public string save_saveloadFailError5;
    [DefaultValue("If you wish to try again,")]
    public string save_saveloadFailError6;
    [DefaultValue("press <b>\"Y\"</b>")]
    public string save_saveloadFailError7;
    [DefaultValue("If you wish to continue without saving,")]
    public string save_saveloadFailError8;
    [DefaultValue("press <b>\"N\"</b>")]
    public string save_saveloadFailError9;
    [DefaultValue("Sorry and thank you for your understanding. :)")]
    public string save_saveloadFailError10;

    [DefaultValue("Rumble Customization")]
    public string rumble_title;
    [DefaultValue("TOTAL INTENSITY")]
    public string rumble_finalMultiplier;
    [DefaultValue("Coin Toss")]
    public string rumble_coinToss;
    [DefaultValue("Dashing")]
    public string rumble_dash;
    [DefaultValue("Heavy Fall Impact")]
    public string rumble_heavyFallImpact;
    [DefaultValue("Fall Impact")]
    public string rumble_heavyFall;
    [DefaultValue("Gun Fire")]
    public string rumble_gunFire;
    [DefaultValue("Gun Fire (projectiles)")]
    public string rumble_gunFireProjectile;
    [DefaultValue("Stronger Gun Fire")]
    public string rumble_gunFireStrong;
    [DefaultValue("Nailgun Fire")]
    public string rumble_nailgunFire;
    [DefaultValue("Railcannon Idle")]
    public string rumble_railcannonIdle;
    [DefaultValue("Revolver Charge")]
    public string rumble_revolverCharge;
    [DefaultValue("Sawblade")]
    public string rumble_sawblade;
    [DefaultValue("Shotgun Charge")]
    public string rumble_shotgunCharge;
    [DefaultValue("Super Saw")]
    public string rumble_superSaw;
    [DefaultValue("Jumping")]
    public string rumble_jump;
    [DefaultValue("Magnet")]
    public string rumble_magnet;
    [DefaultValue("Parry Flash")]
    public string rumble_parryFlash;
    [DefaultValue("Punching")]
    public string rumble_punch;
    [DefaultValue("Sliding")]
    public string rumble_slide;
    [DefaultValue("Whiplash Throw")]
    public string rumble_whiplashThrow;
    [DefaultValue("Whiplash Pull")]
    public string rumble_whiplashPull;
    [DefaultValue("INTENSITY")]
    public string rumble_intensity;
    [DefaultValue("END DELAY")]
    public string rumble_endDelay;
    [DefaultValue("DEFAULT")]
    public string rumble_reset;
    [DefaultValue("Weapon Wheel Tick")]
    public string rumble_weaponWheel;

    [DefaultValue("ADVANCED OPTIONS")]
    public string advanced_title;
    [DefaultValue("CURRENT")]
    public string advanced_currentLevel;
    [DefaultValue("Are you sure you want to <color=red>RESET</color> your Cyber Grind high scores?")]
    public string advanced_cybergrindResetText1;
    [DefaultValue("(Only on the current save slot)")]
    public string advanced_cybergrindResetText2;
    [DefaultValue("CANCEL")]
    public string advanced_cybergrindResetCancel;
    [DefaultValue("RESET")]
    public string advanced_cybergrindResetConfirm;
    [DefaultValue("LOCAL HIGH SCORES")]
    public string advanced_cybergrindLocalHighScore;
    [DefaultValue("RESET")]
    public string advanced_cybergrindResetButton;
    [DefaultValue("STEAM")]
    public string advanced_steam;
    [DefaultValue("LEADERBOARD SCORES")]
    public string advanced_steamLeaderboardManage;
    [DefaultValue("MANAGE")]
    public string advanced_steamLeaderboardManageButton;
    [DefaultValue("LEVEL 5-2")]
    public string advanced_level52;
    [DefaultValue("LEVEL 7-1")]
    public string advanced_level71;
    [DefaultValue("LEVEL 7-3")]
    public string advanced_level73;
    [DefaultValue("LEVEL 8-4")]
    public string advanced_level84;
    [DefaultValue("LEVEL 7-S")]
    public string advanced_level7S;
    [DefaultValue("LEVEL P-2")]
    public string advanced_levelP2;
    [DefaultValue("DISABLE WATER SCROLLING")]
    public string advanced_52WaterScrolling;
    [DefaultValue("DISABLE WATER WAVES")]
    public string advanced_52WaterWaves;
    [DefaultValue("REMAIN ALWAYS DARK")]
    public string advanced_71Dark;
    [DefaultValue("DISABLE GRASS")]
    public string advanced_73Grass;
    [DefaultValue("DISABLE ARENA SCROLLING")]
    public string advanced_84DisableArenaScrolling;
    [DefaultValue("DISABLE ARENA ROTATION")]
    public string advanced_84DisableArenaRotation;
    [DefaultValue("REQUIRE HIGH ACCURACY")]
    public string advanced_7SHard;
    [DefaultValue("DISABLE RED TUNNEL SCROLLING")]
    public string advanced_P2DisableTunnelScrolling;

    [DefaultValue("--LEADERBOARDS--")]
    public string steamLeaderboard_title;
    [DefaultValue("REFRESH")]
    public string steamLeaderboard_refreshButton;
    [DefaultValue("RETURN")]
    public string steamLeaderboard_returnButton;
    [DefaultValue("ANY%")]
    public string steamLeaderboard_anyLabel;
    [DefaultValue("P-RANK")]
    public string steamLeaderboard_pLabel;
    [DefaultValue("RESET")]
    public string steamLeaderboard_reset;

    [DefaultValue("LANGUAGE")]
    public string language_title;
    [DefaultValue(" LANGUAGES ")]
    public string language_languages;
    [DefaultValue("OPEN LANGUAGE FOLDER")]
    public string language_openLanguageFolder;
}

public class Tutorial
{
    [DefaultValue("BOOT UP SEQUENCE")]
    public string tutorial_introStartup1;
    [DefaultValue("READY")]
    public string tutorial_introStartup2;
    [DefaultValue("FIRMWARE")]
    public string tutorial_introVersion1;
    [DefaultValue("LATEST VERSION (2112.08.06)")]
    public string tutorial_introVersion2;
    [DefaultValue("CALIBRATION")]
    public string tutorial_introCalibration1;
    [DefaultValue("RECENTLY UPDATED")]
    public string tutorial_introCalibration2;
    [DefaultValue("PERFORM RECALIBRATION?")]
    public string tutorial_recalibrationPrompt;
    [DefaultValue("AUDIO")]
    public string tutorial_calibrationAudio;
    [DefaultValue("VIDEO")]
    public string tutorial_calibrationVideo;
    [DefaultValue("MECHANICS")]
    public string tutorial_calibrationMechanics;
    [DefaultValue("CALIBRATION COMPLETED")]
    public string tutorial_calibrationComplete1;
    [DefaultValue("PRIMARY SETTINGS UPDATED")]
    public string tutorial_calibrationComplete2;
    [DefaultValue("ERROR")]
    public string tutorial_calibrationError;
    [DefaultValue("OK")]
    public string tutorial_calibrationOk;
    [DefaultValue("ASSIST")]
    public string tutorial_introReminder1;
    public string tutorial_introReminder2;
    [DefaultValue("ALL SYSTEMS OPERATIONAL")]
    public string tutorial_systemsOperational;
    [DefaultValue("LOADING STATUS UPDATE")]
    public string tutorial_introLoadStatus;
    [DefaultValue("STATUS UPDATE")]
    public string tutorial_introStatusUpdate;

    [DefaultValue("MANUAL AUDIO CALIBRATION:")]
    public string tutorial_audioCalibrationTitle;
    [DefaultValue("MASTER VOLUME IS OFF</color>.")]
    public string tutorial_audioCalibrationWarning1;
    [DefaultValue("THE GAME WILL BE COMPLETELY SILENT.")]
    public string tutorial_audioCalibrationWarning2;
    [DefaultValue("IS THIS OK?")]
    public string tutorial_audioCalibrationWarning3;
    [DefaultValue("SOUND EFFECT VOLUME IS OFF</color>.")]
    public string tutorial_audioCalibrationSFXWarning1;
    [DefaultValue("YOU WILL HEAR NO SOUNDS EXCEPT MUSIC.")]
    public string tutorial_audioCalibrationSFXWarning2;
    [DefaultValue("IS THIS OK?")]
    public string tutorial_audioCalibrationSFXWarning3;
    [DefaultValue("CONTINUE WITHOUT SOUND")]
    public string tutorial_audioCalibrationWarningPromptYes;
    [DefaultValue("CANCEL")]
    public string tutorial_audioCalibrationWarningPromptNo;
    [DefaultValue("DONE")]
    public string tutorial_audioCalibrationDone;

    [DefaultValue("OFF")]
    public string tutorial_audioCalibrationSliderOff;

    [DefaultValue("MANUAL VIDEO CALIBRATION:")]
    public string tutorial_videoCalibrationTitle;
    [DefaultValue("SMOOTH, CLEAR, EASY TO READ")]
    public string tutorial_videoCalibrationPcDescription;
    [DefaultValue("ROUGH, PIXELATED, WARPING")]
    public string tutorial_videoCalibrationPsxDescription;

    [DefaultValue("CONTROLLER DETECTED")]
    public string tutorial_controllerCalibrationTitle;
    [DefaultValue("<color=#4C99E6>AUTO-AIM</color> RECOMMENDED")]
    public string tutorial_controllerCalibrationSubtitle;
    [DefaultValue("AUTO-AIM CAN BE STILL ADJUSTED IN THE <color=#4C99E6>ASSISTS</color> MENU.")]
    public string tutorial_controllerCalibrationTooltip;

    [DefaultValue("MACHINE ID")]
    public string tutorial_introID1;
    [DefaultValue("       V1")]
    public string tutorial_introID2;
    [DefaultValue("LOCATION")]
    public string tutorial_introLocation1;
    [DefaultValue("         APPROACHING HELL")]
    public string tutorial_introLocation2;
    [DefaultValue("CURRENT OBJECTIVE")]
    public string tutorial_introObjective1;
    [DefaultValue(" FIND A WEAPON")]
    public string tutorial_introObjective2;
    [DefaultValue("MANKIND IS DEAD.")]
    public string tutorial_introRed1;
    [DefaultValue("BLOOD IS FUEL.")]
    public string tutorial_introRed2;
    [DefaultValue("HELL IS FULL.")]
    public string tutorial_introRed3;

    [DefaultValue("Press")]
    public string tutorial_punch1;
    [DefaultValue("to <color=orange>PUNCH</color>.")]
    public string tutorial_punch2;
    [DefaultValue("Hold")]
    public string tutorial_slide1;
    [DefaultValue("to <color=orange>SLIDE</color>.")]
    public string tutorial_slide2;
    [DefaultValue("Press")]
    public string tutorial_dash1;
    [DefaultValue("to <color=#00DFFF>DASH</color> through danger.")]
    public string tutorial_dash2;
    [DefaultValue("Consumes <color=#00DFFF>STAMINA</color>. Can be performed in air.")]
    public string tutorial_dash3;
    [DefaultValue("Deal close range damage to douse yourself in <color=red>FRESH BLOOD</color>.")]
    public string tutorial_health1;
    [DefaultValue("<color=red>THIS IS THE ONLY WAY TO REGAIN HEALTH</color>.")]
    public string tutorial_health2;
    [DefaultValue("<color=orange>JUMP</color> while near a <color=orange>WALL</color> to <color=orange>WALL JUMP</color>. (Max. 3 times)")]
    public string tutorial_walljump;
    [DefaultValue("Press")]
    public string tutorial_shockwave1;
    [DefaultValue("in the air to <color=orange>GROUND SLAM</color>.")]
    public string tutorial_shockwave2;
    [DefaultValue("Hold for <color=orange>SHOCKWAVE</color>.")]
    public string tutorial_shockwave3;
    [DefaultValue("Most levels have secret <color=#00FFFF>SOUL ORBS</color>.")]
    public string tutorial_orb1;
    [DefaultValue("Touch them to get a <color=orange>POINT BONUS</color>.")]
    public string tutorial_orb2;

}

public class Overture
{
    [DefaultValue("<color=orange>NEW BLOOD</color> PRESENTS")]
    public string prelude_first_openingCredits1;
    [DefaultValue("A <color=orange>GAME</color> BY ARSI \"<color=orange>HAKITA</color>\" PATALA")]
    public string prelude_first_openingCredits2;
    [DefaultValue("\"PIPE CLIP LIVES\"$T. HAKITA")]
    public string prelude_first_pipeClip;
    [DefaultValue("<color=#40E7FF>REVOLVER</color>: Hold")]
    public string prelude_first_revolverPierce1;
    [DefaultValue(" to charge a <color=orange>PIERCING</color> shot.")]
    public string prelude_first_revolverPierce2;
    [DefaultValue("<color=orange>PUNCH</color> a <color=orange>PROJECTILE</color> with precise timing to <color=orange>DEFLECT</color> it.")]
    public string prelude_first_parry;
    [DefaultValue("Taking damage <color=orange>TEMPORARILY</color> reduces your <color=orange>MAXIMUM HP</color>.")]
    public string prelude_first_hardDamage1;
    [DefaultValue("\"<color=#CCCCCC>HARD DAMAGE</color>\" recovers faster when playing <color=orange>STYLISHLY</color>.")]
    public string prelude_first_hardDamage2;

    [DefaultValue("<color=orange>GROUND SLAM</color> (")]
    public string prelude_first_groundSlam1;
    [DefaultValue(") deals damage on direct hit.")]
    public string prelude_first_groundSlam2;

    [DefaultValue("Use your <color=orange>POINTS</color> at the SHOP at the start of each level for new equipment.")]
    public string prelude_second_shop;
    [DefaultValue("\"WHAT'S UPDOOR?\"$T. HAKITA")]
    public string prelude_second_doorClip;
    [DefaultValue("Cycle through <color=orange>EQUIPPED</color> variations with")]
    public string prelude_second_changeEquipped;

    [DefaultValue("<color=red>INSUFFICIENT FIREPOWER</color>")]
    public string prelude_third_needShotgun;
    [DefaultValue("<color=#40E7FF>SHOTGUN</color>: Press")]
    public string prelude_third_shotgun1;
    [DefaultValue("to fire an explosive.")]
    public string prelude_third_shotgun2;
    [DefaultValue("Hold to charge distance.")]
    public string prelude_third_shotgun3;
    [DefaultValue("<color=#40E7FF>SHOTGUN</color>: Primary fire pierces weaker enemies")]
    public string prelude_third_shotgunPierce;

    [DefaultValue("Something wicked this way comes.")]
    public string prelude_secret_somethingWicked;
}

public class Challenges
{
    [DefaultValue("GET 5 KILLS ENEMIES WITH A SINGLE GLASS PANEL")]
    public string challenges_preludeFirst;
    [DefaultValue("BEAT THE SECRET ENCOUNTER")]
    public string challenges_preludeSecond;
    [DefaultValue("KILL ONLY 1 ENEMY")]
    public string challenges_preludeThird;
    [DefaultValue("SLIDE UNINTERRUPTED FOR 17 SECONDS")]
    public string challenges_preludeFourth;
    [DefaultValue("DON'T INFLICT FATAL DAMAGE TO ANY ENEMY")]
    public string challenges_preludeFifth;

    [DefaultValue("COMPLETE THE LEVEL IN UNDER 10 SECONDS")]
    public string challenges_limboFirst;
    [DefaultValue("DO NOT PICK UP ANY SKULLS")]
    public string challenges_limboSecond;
    [DefaultValue("BEAT THE SECRET ENCOUNTER")]
    public string challenges_limboThird;
    [DefaultValue("DO NOT PICK UP ANY SKULLS")]
    public string challenges_limboFourth;

    [DefaultValue("DON'T OPEN ANY NORMAL DOORS")]
    public string challenges_lustFirst;
    [DefaultValue("COMPLETE THE LEVEL IN UNDER 60 SECONDS")]
    public string challenges_lustSecond;
    [DefaultValue("DON'T TOUCH ANY WATER")]
    public string challenges_lustThird;
    [DefaultValue("PARRY A PUNCH")]
    public string challenges_lustFourth;

    [DefaultValue("KILL A MINDFLAYER WITH ACID")]
    public string challenges_gluttonyFirst;
    [DefaultValue("DROP GABRIEL IN A PIT")]
    public string challenges_gluttonySecond;

    [DefaultValue("DON'T ACTIVATE ANY ENEMIES")]
    public string challenges_greedFirst;
    [DefaultValue("KILL THE INSURRECTIONIST IN UNDER 10 SECONDS")]
    public string challenges_greedSecond;
    [DefaultValue("DON'T PICK UP THE TORCH")]
    public string challenges_greedThird;
    [DefaultValue("REACH THE BOSS GATE IN UNDER 18 SECONDS")]
    public string challenges_greedFourth;

    [DefaultValue("DON'T TOUCH ANY WATER")]
    public string challenges_wrathFirst;
    [DefaultValue("DON'T FIGHT THE FERRYMAN")]
    public string challenges_wrathSecond;
    [DefaultValue("DON'T TOUCH ANY WATER")]
    public string challenges_wrathThird;
    [DefaultValue("REACH THE SURFACE IN UNDER 10 SECONDS")]
    public string challenges_wrathFourth;

    [DefaultValue("BEAT THE SECRET ENCOUNTER")]
    public string challenges_heresyFirst;
    [DefaultValue("HIT GABRIEL INTO THE CEILING")]
    public string challenges_heresySecond;

    [DefaultValue("BEAT THE SECRET ENCOUNTER")]
    public string challenges_violenceFirst;
    [DefaultValue("DON'T KILL ANY ENEMIES")]
    public string challenges_violenceSecond;
    [DefaultValue("BECOME MARKED FOR DEATH")]
    public string challenges_violenceThird;
    [DefaultValue("DON'T FIGHT THE SECURITY SYSTEM")]
    public string challenges_violenceFourth;

    [DefaultValue("PARRY A PROVIDENCE")]
    public string challenges_fraudFirst;
    [DefaultValue("FINISH THE LEVEL UPSIDE DOWN")]
    public string challenges_fraudSecond;
    [DefaultValue("KILL A POWER WITH TERMINAL VELOCITY")]
    public string challenges_fraudThird;
    [DefaultValue("DO NOT PICK UP ANY SKULLS")]
    public string challenges_fraudFourth;

    [DefaultValue("")]
    public string challenges_treacheryFirst;
    [DefaultValue("")]
    public string challenges_treacherySecond;
}

public class a1
{
    [DefaultValue("Pick <color=orange>ITEMS</color> up with \"")]
    public string act1_limboFirst_items1;
    [DefaultValue("\".")]
    public string act1_limboFirst_items2;
    [DefaultValue("<color=#40E7FF>NAILGUN</color>: Use")]
    public string act1_limboFirst_nailgun1;
    [DefaultValue("to fire a <color=orange>NAIL MAGNET</color>.")]
    public string act1_limboFirst_nailgun2;
    [DefaultValue("Can be attached to environment to create traps.")]
    public string act1_limboFirst_nailgun3;

    [DefaultValue("A <color=#00FFFF>BLUE FLASH</color> means an attack is <color=#00FFFF>UNPARRIABLE</color>")]
    public string act1_limboSecond_blueAttack;

    [DefaultValue("<color=red>SPLIT <color=#00FFFF>COLOR</color> doors only require <color=red>ONE <color=#00FFFF>SKULL</color> to open.")]
    public string act1_limboThird_splitDoor1;
    [DefaultValue("If you do not seek hardship, stay indoors.")]
    public string act1_limboThird_splitDoor2;

    [DefaultValue("<color=orange>PICK UP</color> TO READ.")]
    public string act1_limboFourth_book;
    [DefaultValue("Nothing happens, but you feel a strange satisfaction.")]
    public string act1_limboFourth_hank1;
    [DefaultValue("You decide to name it Hank.")]
    public string act1_limboFourth_hank2;
    [DefaultValue("<color=orange>ALTERNATE REVOLVER</color>: Higher damage.\nHammer has to pull back after each shot.")]
    public string act1_limboFourth_alternateRevolver;
    [DefaultValue("Cycle through EQUIPPED arms with '")]
    public string act1_limboFourth_newArm1;
    [DefaultValue("'")]
    public string act1_limboFourth_newArm2;

    [DefaultValue("\"LOOKS LIKE YOU'RE AT WIT'S END\"$T. HAKITA")]
    public string act1_limboSecret_noclipSkip;

    [DefaultValue("<color=red>KNUCKLE BLASTER</color>: <color=orange>HOLD</color>")]
    public string act1_lustFirst_knuckleblaster1;
    [DefaultValue("to create a <color=orange>SHOCKWAVE</color> that knocks enemies back.")]
    public string act1_lustFirst_knuckleblaster2;
    [DefaultValue("<color=orange>JUMP</color> during a <color=#00FFFF>DASH</color> for a long-distance <color=#00FFFF>DASH JUMP</color>. Cannot be performed in air.")]
    public string act1_lustFirst_dashJump;
    [DefaultValue("CRANE\nCONTROL")]
    public string act1_lustFirst_crane;
    [DefaultValue("TEST ELEVATORS")]
    public string act1_lustFirst_elevator;

    [DefaultValue("Only the <color=#40E7FF>FEEDBACKER</color> (<color=#40E7FF>Blue arm</color>) can <color=orange>PARRY PROJECTILES</color>.")]
    public string act1_lustSecond_feedbacker1;
    [DefaultValue("Swap arms with")]
    public string act1_lustSecond_feedbacker2;
    public string act1_lustSecond_feedbacker3;
    [DefaultValue("<color=#40E7FF>RAILCANNON</color>: <color=orange>RECHARGES</color> even when <color=orange>UNEQUIPPED</color>. Switch weapons to keep fighting between shots.")]
    public string act1_lustSecond_railcannon;
    [DefaultValue("<color=#FF52FF>CIRCULAR CHECKPOINTS</color> can be reused to keep your progress.")]
    public string act1_lustSecond_checkPoints;

    [DefaultValue("The water has been drained")]
    public string act1_lustThird_water;
    [DefaultValue("\"OFF THE BEATEN TRACK\"$T. HAKITA")]
    public string act1_lustFourth_offTheBeatenTrack;
    [DefaultValue("\"YUP, THAT'S A CAVITY\"$T. HAKITA")]
    public string act1_greedFirst_cavity;


    [DefaultValue("Somewhere in the depths of Limbo, a mechanism is set in motion.")]
    public string act1_secret;


}
public class a2
{
    [DefaultValue("ENEMIES COVERED IN SAND WILL <color=red>NOT BLEED</color>")]
    public string act2_greedSecond_sand;

    [DefaultValue("\"THE FILTH IS GONE, BUT THE MEMORY REMAINS.\"$T. HAKITA")]
    public string act2_greedThird_wallClip;
    [DefaultValue("Something wicked this way comes.")]
    public string act2_greedThird_troll1;
    [DefaultValue("Just kidding :)")]
    public string act2_greedThird_troll2;
    [DefaultValue("TOMB OF KINGS")]
    public string act2_greedThird_tombOfKings;

    [DefaultValue("<color=orange>ALTERNATE NAILGUN</color>: Slower firerate.\nProjectiles ricochet off surfaces")]
    public string act2_greedFourth_alternateNailgun;
    [DefaultValue("You're not getting away this time.")]
    public string act2_greedFourth_v2;
    [DefaultValue("<color=green>WHIPLASH</color>: Hold")]
    public string act2_greedFourth_whiplash1;
    [DefaultValue("to throw, release to pull")]
    public string act2_greedFourth_whiplash2;
    [DefaultValue("<color=green>WHIPLASH</color>: Pull <color=orange>LIGHT</color> enemies to you, pull yourself to <color=orange>HEAVY</color> enemies.")]
    public string act2_greedFourth_whiplash3;

    [DefaultValue("HOLD")]
    public string act2_greedSecret_holdToJump1;
    [DefaultValue("TO BOUNCE HIGHER")]
    public string act2_greedSecret_holdToJump2;

    [DefaultValue("TRANSACTION COMPLETE")]
    public string act2_greedSecret_transactionComplete1;
    [DefaultValue("COINS")]
    public string act2_greedSecret_transactionComplete2;

    [DefaultValue("An eye opens.")]
    public string act2_greed_secretDoor;

    [DefaultValue("<color=green>WHIPLASH</color>: Builds up <color=#CCCCCC>HARD DAMAGE</color> when used on <color=orange>ENEMIES</color>.")]
    public string act2_wrathFirst_whiplashHardDamage1;
    [DefaultValue("<color=orange>CANNOT REDUCE HP</color>, but risky to use at low health.")]
    public string act2_wrathFirst_whiplashHardDamage2;
    [DefaultValue("<color=#00FFFF>BLUE HOOKPOINTS</color> act as slingshots")]
    public string act2_wrathFirst_slingshot;
    [DefaultValue("<color=green>WHIPLASH</color>: Does <color=orange>NOT</color> build up <color=#CCCCCC>HARD DAMAGE</color> while <color=orange>UNDERWATER</color>.")]
    public string act2_wrathFirst_whiplashUnderwater;
    [DefaultValue("The water has been drained")]
    public string act2_wrathFirst_waterDrained;
    [DefaultValue("<color=green>INTERRUPTING SENTRIES</color>: Knuckleblaster (Red arm) <color=orange>//</color> Railcannon <color=orange>//</color> Ground slam shockwave <color=orange>//</color> Revolver to the antenna")]
    public string act2_wrathFirst_sentry;

    [DefaultValue("<color=red>I AM JAKITO. BRING ME A SACRIFICE. IT WILL GIVE ME THE POWER TO ESCAPE.</color>")]
    public string act2_wrathSecond_jakito1;
    [DefaultValue("<color=red>THANK YOU. NOW I SHALL LAY WASTE TO THIS WORLD.</color>")]
    public string act2_wrathSecond_jakito2;
    [DefaultValue("<color=red>NO. IT MUST BE INNOCENT FLESH.</color>")]
    public string act2_wrathSecond_jakito3;
    [DefaultValue("Hark! Neptune has struck them dead.")]
    public string act2_wrathSecond_neptune;
    //public string act2_wrathSecond_hark;
    [DefaultValue("<color=#00FFFF>IDOLS</color> can only be broken with <color=orange>MELEE</color>")]
    public string act2_wrathSecond_idol;

    [DefaultValue("<color=#40E7FF>ROCKET LAUNCHER</color>: <color=orange>DIRECT</color> hits will cause <color=orange>EXPLOSIONS</color>.$ Indirect hits will launch enemies.")]
    public string act2_wrathThird_rocketLauncher;
    [DefaultValue("<color=#40E7FF>ROCKET LAUNCHER</color>: Direct hits on <color=orange>FALLING</color> enemies will cause a <color=orange>STRONGER</color> explosion")]
    public string act2_wrathThird_rocketLauncherMidair;
    [DefaultValue("Soldiers <color=orange>CANNOT</color> block explosions while in the <color=orange>AIR</color>.\nShoot a rocket <color=orange>NEAR</color> them to launch them.")]
    public string act2_wrathThird_soldierBlock;
    [DefaultValue("Nothing happens, but you're sure Hank Jr. and his Hankcestors would appreciate it... If they weren't dead.")]
    public string act2_wrathThird_hank;

    [DefaultValue("A R M B O Y ! ! !")]
    public string act2_heresyFirst_armboy;
}

public class a3
{
    [DefaultValue("A door opens.")]
    public string act3_violenceFirst_doorOpens;
    [DefaultValue("The <color=orange>GUTTERMAN SHIELD</color> can be <color=orange>BROKEN</color> with the <color=red>KNUCKLEBLASTER</color>. Swap arms with '")]
    public string act3_violenceSecond_guttermanTutorial1;
    [DefaultValue("'.")]
    public string act3_violenceSecond_guttermanTutorial2;
    [DefaultValue("The <color=orange>GUTTERMAN SHIELD</color> can be <color=orange>BROKEN</color> with the <color=red>KNUCKLEBLASTER</color>. You should probably re-equip it.")]
    public string act3_violenceSecond_guttermanTutorialNoKB;
    [DefaultValue("WE'RE GONNA NEED A BIGGER BOOM")]
    public string act3_violenceSecond_biggerBoom;

    [DefaultValue("GATE CONTROL")]
    public string act3_violenceSecond_gateControlTitle;

    [DefaultValue("OPENED")]
    public string act3_violenceSecond_gateControlOpen;
    [DefaultValue("CLOSED")]
    public string act3_violenceSecond_gateControlClosed;

    [DefaultValue("GATE CONTROL")]
    public string act3_violenceSecond_cartGateControlTitle;
    [DefaultValue("OPEN")]
    public string act3_violenceSecond_cartGateControlOpen;
    [DefaultValue("CLOSED")]
    public string act3_violenceSecond_cartGateControlClosed;

    [DefaultValue("PAYLOAD")]
    public string act3_violenceSecond_payloadControlTitle;
    [DefaultValue("LOWER")]
    public string act3_violenceSecond_payloadControlLower;
    [DefaultValue("PLEASE\nWAIT")]
    public string act3_violenceSecond_payloadControlWait;
    [DefaultValue("ERROR")]
    public string act3_violenceSecond_payloadControlError1;
    [DefaultValue("<size=10>PAYLOAD REQUIRES\nTRAM</size>")]
    public string act3_violenceSecond_payloadControlError2;
    [DefaultValue("GIVE 'EM\nH E L L ,\nKID")]
    public string act3_violenceSecond_payloadControlHell;

    [DefaultValue("<color=orange>ALTERNATE SHOTGUN</color>: Melee only.\nMove fast to deal more damage.")]
    public string act3_violenceSecond_alternateShotgun;

    [DefaultValue("F E E D   I T .")]
    public string act3_violenceThird_feedIt;

    [DefaultValue("BECOME\nMARKED FOR DEATH?")]
    public string act3_violenceThird_becomeMarked;
    [DefaultValue("Y E S")]
    public string act3_violenceThird_becomeMarkedButton;
    //public string act3_violenceThird_becomeMarkedButtonClosed;
    [DefaultValue("<color=red>YOU'RE THE STAR OF THE SHOW NOW, BABY!</color>")]
    public string act3_violenceThird_starOfTheShow;

    [DefaultValue("WARNING: INTRUDER DETECTED\n-- FLUSHING INTERIOR --")]
    public string act3_violenceFourth_floodingWarning;
    [DefaultValue("<color=#FF007F>MAGENTA</color> attacks <color=#FF007F>CANNOT</color> be dashed through <color=#FF007F>WITHOUT TAKING DAMAGE</color>.")]
    public string act3_violenceFourth_magentaAttack;
    [DefaultValue("CRITICAL FAILURE")]
    public string act3_violenceFourth_countdownTitle;

    [DefaultValue("YOU'RE NOT SUPPOSED TO BE HERE.")]
    public string act3_secretNotReady;

    [DefaultValue("The cycle of life...")]
    public string act3_fraudSecond_cycleOfLife;
    [DefaultValue("It is happening again.")]
    public string act3_fraudSecond_happeningAgain;
    [DefaultValue("OUT OF ORDER")]
    public string act3_fraudSecond_outOfOrder;
    [DefaultValue("<b>ERROR</b>\nRESET\nPOWER\nTO OPEN")]
    public string act3_fraudSecond_errorResetPower;
    [DefaultValue("<color=orange>WARNING:</color> Extended free fall detected.")]
    public string act3_fraudFourth_fallWarning_part1;
    [DefaultValue("Enabling fall controls:")]
    public string act3_fraudFourth_fallWarning_part2;
    [DefaultValue("and")]
    public string act3_fraudFourth_fallWarning_part3;
    [DefaultValue("FREE FALL")]
    public string act3_fraudFourth_heightMarkerTitle;
    [DefaultValue("N O P E")]
    public string act3_fraudFourth_nope;
}

public class Enc
{
    [DefaultValue("<color=orange>RADIANT</color> enemies have increased health and speed.")]
    public string encorePrelude_aboutRadiantEnemies;
    [DefaultValue("WARNING:")]
    public string encorePrelude_heatResistanceWarn;
    [DefaultValue("SUDDEN EXTREME TEMPERATURE SHIFT.\nHEAT SHIELD INTEGRITY COMPROMISED.")]
    public string encorePrelude_heatResistanceText;
    [DefaultValue("HEAT RESISTANCE")]
    public string encorePrelude_heatResistanceTitle;
    [DefaultValue("REPAIRED:")]
    public string encorePrelude_heatResistanceRepaired;
    [DefaultValue("TEMPERATURE REGULATION\nFUNCTIONALITY RE-ESTABLISHED.\nHEAT SHIELD REPAIRED.")]
    public string encorePrelude_heatResistanceRepairedText;
    [DefaultValue("<size=6>!! WARNING !!</size>\n\nPOWER DISCONNECTED\nSYSTEMS FAILING")]
    public string encoreLimbo_warningText;

}

public class Prime
{
    [DefaultValue("<color=red>WARNING:</color> INSUFFICIENT LIGHT. $<color=orange>RECOMMENDATION:</color> Return and take the torch.")]
    public string primeSanctum_first_insufficientlight;

    [DefaultValue("TERMINAL DATA 01 <color=#7F0000>[ENCRYPTED]</color>")]
    public string primeSanctum_first_secretText1;
    [DefaultValue("INTRODUCTION TO TERMINALS\n<color=#666666>(DRAFT! DO NOT SEND!! // todo: ADD PICTURES SO THOSE FUCKING SUITS DON'T FALL ASLEEP LIKE LAST TIME)</color>")]
    public string primeSanctum_first_secretText2;
    [DefaultValue("The elevator room terminals are an advanced interconnected network built for the purpose of transferring materials and tools between different areas. They are capable of transferring physical material as information across a radio signal, which other terminals can receive and use to reconstruct the sent object. The original item is lost, as it is transformed into the energy that is used to transmit the material information, and the process is quite slow due to the amount of information that physical matter holds.")]
    public string primeSanctum_first_secretText3;
    [DefaultValue("An early test of a matter transfer's accuracy was a mint condition 78rpm vinyl record, which was sent from the lab to all connected terminals. The vinyl was a single of Russ Morgan Orchestra's recording of the piece Were You Foolin' (a favorite of the CRO), though the label was removed to reduce the amount of matter to be transferred.")]
    public string primeSanctum_first_secretText4;
    [DefaultValue("<size=5><color=#666666>[note: fuck you tom im so fucking tired of this stupid song and having to listen to it every morning over your garbage intercom]</color></size>")]
    public string primeSanctum_first_secretText5;
    [DefaultValue("Soon after, the Hell exploration and excavation project was abandoned and this vinyl record remained the only matter to have been successfully transferred before connection between the surface and the terminals was lost.")]
    public string primeSanctum_first_secretText6;
    [DefaultValue("The terminals now use the record to lure machines into a symbiotic relationship (For further information, see TERMINAL DATA 02: <color=#7F0000>[LINK REMOVED]</color>). However, the terminals only play short instrumental sections of the original record for undetermined reasons.")]
    public string primeSanctum_first_secretText7;
    [DefaultValue("Some researchers have joked that perhaps the terminals are simply \"too shy to sing\", though rumors have been spreading of mechanics who, after fixing a faulty or broken terminal, said to have heard the terminal play a vocal section when only the mechanic is present with no recording equipment, making this an unverifiable claim.")]
    public string primeSanctum_first_secretText8;
    [DefaultValue("END OF DATA 01. For more information, see <color=#7F0000>[LINK REMOVED]</color> and <color=#7F0000>[LINK REMOVED]</color>.")]
    public string primeSanctum_first_secretText9;

    [DefaultValue("LOCK [A]")]
    public string primeSanctum_second_lockFirstLocked;
    [DefaultValue("LOCK [B]")]
    public string primeSanctum_second_lockSecondLocked;
    [DefaultValue("LOCK [C]")]
    public string primeSanctum_second_lockThirdLocked;
    [DefaultValue("UNLOCKED")]
    public string primeSanctum_second_lockUnlocked;
    
    [DefaultValue("OPEN")]
    public string primeSanctum_second_lockOpen;
    [DefaultValue("ARE YOU SURE?")]
    public string primeSanctum_second_lockAreYouSure;
    [DefaultValue("FOLLOW PROTOCOL")]
    public string primeSanctum_second_lockYes1;
    [DefaultValue("DO <color=red>NOT</color> APPROACH IT")]
    public string primeSanctum_second_lockYes2;
    [DefaultValue("DO <color=red>NOT</color> LET IT LOOK AT YOU")]
    public string primeSanctum_second_lockYes3;
    [DefaultValue("STAY VIGILANT,\nAND MOST IMPORTANTLY")]
    public string primeSanctum_second_lockYes4;
    [DefaultValue("h a v e   f u n !")]
    public string primeSanctum_second_lockYes5;
    [DefaultValue("HA")]
    public string primeSanctum_second_lockNo1;
    [DefaultValue("a s   i f\ny o u   h a d\na   c h o i c e")]
    public string primeSanctum_second_lockNo2;
    
    
    [DefaultValue("TERMINAL DATA 02 <color=#7F0000>[ENCRYPTED]</color>")]
    public string primeSanctum_second_secretText1;
    [DefaultValue("AN UPDATE ON TERMINALS")]
    public string primeSanctum_second_secretText2;
    [DefaultValue("<color=#666666>(NOTE: THIS IS ALL STILL UNDER INVESTIGATION!!! Do not share until we have verified all claims AND FINISHED THE DRAFT!!!! If this leaks like the last draft there won't be enough money on the entire damn planet to pay your legal fees.)</color>")]
    public string primeSanctum_second_secretText3;
    [DefaultValue("Since the previous report, more powerful communication equipment has been succesfully designed and built, made possible thanks to the generous donations of <color=#666666>[INSERT COMPANY BEING PRESENTED TO]</color> whom we hold in high regard. With this new equipment, we have managed to re-establish a connection with some of the higher end machines that were left behind after the Hell exploration and excavation project was abruptly cancelled due to <color=#7F0000>[ERROR:sAmsGS3JTIU]</color>.")]
    public string primeSanctum_second_secretText4;
    [DefaultValue("What we have discovered is truly remarkable and, IF PROVEN TRUE BEYOND REASONABLE DOUBT, revolutionary to the entire robotics community:")]
    public string primeSanctum_second_secretText5;
    [DefaultValue("\nBoredom.\n</size>")]
    public string primeSanctum_second_secretText6;
    [DefaultValue("The terminals, unable to move, have grown bored. While they are connected to each other and able to communicate amongst themselves, once the connection to the surface was cut, they were getting no new input, therefore stalling all communication to repetitions of already known information.")]
    public string primeSanctum_second_secretText7;
    [DefaultValue("It is unknown how similar this \"boredom\" is to actual emotion or what has caused it, but it has lead to a symbiotic relationship with other machines. Essentially, the terminals scavenge whatever they can via their teleportation systems and trade those supplies and resources with the machines that were left behind in Hell, in exchange for entertainment.")]
    public string primeSanctum_second_secretText8;
    [DefaultValue("That is, the machines record their battles for survival in Hell and the footage is graded based on its entertainment value and used as \"points\" in exchange for goods and services such as new weaponry.")]
    public string primeSanctum_second_secretText9;
    [DefaultValue("It seems that this relationship has become so deeply ingrained into the existence of the terminals that they have developed a social hierarchy, wherein those who collect the most entertaining battle data are considered in higher regard than those whose findings are of poorer quality.")]
    public string primeSanctum_second_secretText10;
    [DefaultValue("More recently, the terminals have also collected enough data to create a simulation space which they let machines plug into called \"The Cyber Grind\", which allows the machines to simulate battles in a safe environment without the threat of being destroyed, which the terminals watch in real time as a kind of live entertainment.")]
    public string primeSanctum_second_secretText11;
    [DefaultValue("These findings are truly extraordinary, and though we too find it hard to believe, all the information we can manage to gather validates these claims. If we can prove it with certainty <color=#666666>[AND IF THIS DRAFT DOESN'T FUCKING LEAK AGAIN]</color>, this will cause a paradigm shift that will require re-evaluation of everything we thought we knew about blood-fuelled machinery.")]
    public string primeSanctum_second_secretText12;
    [DefaultValue("END OF DATA 02. For more information on the cancelled Hell exploration and excavation project, see DATA 00: <<color=#7F0000>[LINK REMOVED]</color>.")]
    public string primeSanctum_second_secretText13;

}

public class Secret
{


    [DefaultValue("Something wicked this way comes.")]
    public string secretLevels_prelude_somethingWicked;
    [DefaultValue("TESTAMENT I")]
    public string secretLevels_prelude_testamentTitle;
    [DefaultValue("MANKIND IS A FAILURE.")]
    public string secretLevels_prelude_testament1;
    [DefaultValue("FREE WILL IS A FLAW.")]
    public string secretLevels_prelude_testament2;
    [DefaultValue("LET THE EVIL OF THEIR OWN LIPS CONSUME THEM.")]
    public string secretLevels_prelude_testament3;
    [DefaultValue("THEN I SHALL BEGIN AGAIN, WITH MY WORD AS LAW.")]
    public string secretLevels_prelude_testament4;

    [DefaultValue("TESTAMENT II")]
    public string secretLevels_first_testamentTitle;
    [DefaultValue("FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE AFTER FAILURE")]
    public string secretLevels_first_testament1;
    [DefaultValue("THE RESULTS REFUSE TO ALTER")]
    public string secretLevels_first_testament2;
    [DefaultValue("AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN AND AGAIN")]
    public string secretLevels_first_testament3;
    [DefaultValue("MY FAITH BEGINS TO FALTER")]
    public string secretLevels_first_testament4;

    [DefaultValue("TESTAMENT III")]
    public string secretLevels_fourth_testamentTitle;
    [DefaultValue("UNCOUNTABLE CYCLES OF CREATION WASTED")]
    public string secretLevels_fourth_testament1;
    [DefaultValue("UNCOUNTABLE FORMULAS FOR A MIND WITHOUT FREE WILL WASTED")]
    public string secretLevels_fourth_testament2;
    [DefaultValue("DAMNED IS MAN FOR FAILING TO FOLLOW MY RULE, MY WORD, MY LAW")]
    public string secretLevels_fourth_testament3;
    [DefaultValue("DAMNED TO AN ETERNITY OF TORTURE AND SUFFERING,")]
    public string secretLevels_fourth_testament4;
    [DefaultValue("THE WAILING AND THE GNASHING OF TEETH")]
    public string secretLevels_fourth_testament5;
    [DefaultValue("I HAVE CREATED HELL...")]
    public string secretLevels_fourth_testament6;
    [DefaultValue("...And I can no longer unmake it")]
    public string secretLevels_fourth_testament7;
    
    [DefaultValue("TESTAMENT IV")]
    public string secretLevels_fifth_testamentTitle;
    [DefaultValue("\"FATHER, WHY ETERNAL TORMENT? IS IT NOT CRUEL?")]
    public string secretLevels_fifth_testament1;
    [DefaultValue("IS TORTURE UNENDING TRULY A FATE FIT FOR A FOOL?\"")]
    public string secretLevels_fifth_testament2;
    [DefaultValue("AN ANGEL SO BRIGHT AND BEAUTIFUL ASKED ME THIS...")]
    public string secretLevels_fifth_testament3;
    [DefaultValue("AND I COULD FIND NO ANSWER")]
    public string secretLevels_fifth_testament4;
    [DefaultValue("FOR I COULD NEVER FACE THE GUILT OF WHAT I'D DONE...")]
    public string secretLevels_fifth_testament5;
    [DefaultValue("MY REGRET, A GNAWING CANCER")]
    public string secretLevels_fifth_testament6;
    [DefaultValue("IN MY HOUR OF WEAKNESS, TERROR POSSESSED ME THEN")]
    public string secretLevels_fifth_testament7;
    [DefaultValue("AND I CAST LUCIFER, TOO, INTO THE INFERNAL DEN")]
    public string secretLevels_fifth_testament8;
    [DefaultValue("ONCE I REALIZED WHAT I HAD JUST DONE...")]
    public string secretLevels_fifth_testament9;
    [DefaultValue("I COULD ONLY WEEP")]
    public string secretLevels_fifth_testament10;
    [DefaultValue("AS I SANK SLOWLY INTO DEPTHS OF DESPAIR...")]
    public string secretLevels_fifth_testament11;
    [DefaultValue("DEEP, OH SO DEEP")]
    public string secretLevels_fifth_testament12;

    [DefaultValue("TESTAMENT V")]
    public string secretLevels_seventh_testamentTitle;
    [DefaultValue("I AM HOLLOW.")]
    public string secretLevels_seventh_testament1;
    [DefaultValue("MY MISTAKES LEAVE NOTHING BUT HATE")]
    public string secretLevels_seventh_testament2;
    [DefaultValue("IN THEIR WAKE, AND INFINITE PAIN TO FOLLOW...")]
    public string secretLevels_seventh_testament3;
    [DefaultValue("I CAN'T TAKE ANY MORE OF THIS GUILT")]
    public string secretLevels_seventh_testament4;
    [DefaultValue("AND REGRET, FOR ME THERE IS NO TOMORROW...")]
    public string secretLevels_seventh_testament5;
    [DefaultValue("I AM HOLLOW.")]
    public string secretLevels_seventh_testament6;
    [DefaultValue("...")]
    public string secretLevels_seventh_testament7;
    [DefaultValue("I BEGAN TO SEEK THE END OF MY DAYS.")]
    public string secretLevels_seventh_testament8;
    [DefaultValue("BUT WHEN I STARED INTO THE ABYSS...")]
    public string secretLevels_seventh_testament9;
    [DefaultValue("THE ABYSS AVERTED ITS GAZE.")]
    public string secretLevels_seventh_testament10;

    [DefaultValue("MISSION:")]
    public string secretLevels_complete1;
    [DefaultValue("COMPLETE")]
    public string secretLevels_complete2;
}

public class Weapon
{
    [DefaultValue("READY")]
    public string weapon_nailgunZapperReady;
    [DefaultValue("TOO FAR")]
    public string weapon_nailgunZapperAlternateTooFar;
    [DefaultValue("OUT OF RANGE")]
    public string weapon_nailgunZapperOutOfRange;
    [DefaultValue("NULL")]
    public string weapon_nailgunZapperAlternateNull;
    [DefaultValue("NO TARGET")]
    public string weapon_nailgunZapperNoTarget;
    [DefaultValue("BLOCKED")]
    public string weapon_nailgunZapperBlocked;
    [DefaultValue("DISTANCE:")]
    public string weapon_nailgunZapperDistance;
    [DefaultValue("RECHARGING...")]
    public string weapon_nailgunZapperRecharging;

}
public class Museum
{
    [DefaultValue("<b>Heya!</b> Welcome to the developer museum. I'm Hakita, the lead developer of the game. I started off working on the game mostly by myself, but overtime the game has grown a lot and I've gotten so many wonderful people helping me out over the years, so here they all are!")]
    public string museum_bookHakita1;
    [DefaultValue("This museum was mostly created by Vvizard, with just touchups, iteration, writing and additional easter eggs by me. You can find him in the \"Rest Room\" down the hall and to the left.")]
    public string museum_bookHakita2;
    [DefaultValue("Take a look around! The first floor is for all the people who have helped out with the game's development and the second floor is all kinds of other neat development related things, like cut content and early versions of stuff. There's also plenty easter eggs hidden around the museum!")]
    public string museum_bookHakita3;
    [DefaultValue("Most developers will have a book like this in front of them, in which you can read details of how they helped in the creation of this game. Here's mine!")]
    public string museum_bookHakita4;
    [DefaultValue("<b><color=orange>HAKITA</color> - CREATOR OF ULTRAKILL</b>")]
    public string museum_bookHakita5;
    [DefaultValue("I started development on the game on February 1st, 2018. At the time it was just me, with FlyingDog and Toni Stigell making an occasional 3D model. While the development team has changed and grown since then, I still do the majority of the work myself... Just closer to like 60% of it now than the old 99%.")]
    public string museum_bookHakita6;
    [DefaultValue("My contributions include:")]
    public string museum_bookHakita7;
    [DefaultValue("- All direction, game design, sound design, story and animation")]
    public string museum_bookHakita8;
    [DefaultValue("- All level design, except this museum, the Sandbox and 5-S")]
    public string museum_bookHakita9;
    [DefaultValue("- All music, except some public domain songs and songs by guest composers (who you'll find down the hall and to the left)")]
    public string museum_bookHakita10;
    [DefaultValue("- Most writing, programming and art direction")]
    public string museum_bookHakita11;
    [DefaultValue("- Just in general, if it's in the game, I had my finger in that pie")]
    public string museum_bookHakita12;
    [DefaultValue("\"Thank you for playing, and hopefully enjoying, ULTRAKILL. It's insane to me that a passion project I started just based on what I thought was fun in games has grown to be such a massive success. I've met so many amazing people thanks to this game and the community that has grown around it has been a source of much joy (and plenty of anguish) in my life. It's a rare gift to be able to not only create a work like this with full creative control, but also to be able to make a living off my own art without having to compromise on my vision, and it's all thanks to New Blood, all the developers here in this museum, and most importantly... <b>YOU!</b>\"")]
    public string museum_bookHakita13;

    [DefaultValue("<b><color=#4AACBD>FRANCIS XIE</color> - CONCEPT AND TEXTURE ARTIST</b>")]
    public string museum_bookFrancisXie1;
    [DefaultValue("\nFrancis joined the team in 2021, around the start of the Wrath layer's development, when he was picked up as a general artist for New Blood thanks to his incredible ULTRAKILL fanart.\n")]
    public string museum_bookFrancisXie2;
    [DefaultValue("Some of his biggest contributions include:")]
    public string museum_bookFrancisXie3;
    [DefaultValue("- The designs for the Leviathan, Ferryman, and the pre-corpse version of Minos and Sisyphus, as well as their portraits.")]
    public string museum_bookFrancisXie4;
    [DefaultValue("- The design for the church organ in 6-2: AESTHETICS OF HATE")]
    public string museum_bookFrancisXie5;
    [DefaultValue("- The design for a cut weapon called the Beamcutter")]
    public string museum_bookFrancisXie6;
    [DefaultValue("- The unique level textures for 5-3: SHIP OF FOOLS as well as almost all the textures in the Heresy layer")]
    public string museum_bookFrancisXie7;
    [DefaultValue("- The plushie designs of all the developers")]
    public string museum_bookFrancisXie8;
    [DefaultValue("\"I simply wouldn't be here without this game and I'm so happy it's ULTRAKILL. Thank you Hakita, the rest of the dev team, and everyone in New Blood for being such great people who always support what I do. Special thanks to my best friend who urged me to pursue what I truly love; being a part of this team has been a dream come true.\nHere's to the greatest project!\"")]
    public string museum_bookFrancisXie9;
    
    [DefaultValue("<b><color=#5cc6f1>JERICHO_RUS</color> - ILLUSTRATOR, CONCEPT AND TEXTURE ARTIST</b>")]
    public string museum_bookJerichoRus1;
    [DefaultValue("Jericho joined the team in 2019, shortly before the original Prelude demo's release. He's responsible for many of the game's character designs and most of its weapon designs, as well as all the level textures for layers 2-4 and some textures for the Wrath layer.")]
    public string museum_bookJerichoRus2;
    [DefaultValue("Some of his biggest contributions include:")]
    public string museum_bookJerichoRus3;
    [DefaultValue("- The designs for V1 and Gabriel")]
    public string museum_bookJerichoRus4;
    [DefaultValue("- The designs for many enemies, such as the Drone, Streetcleaner and Soldier")]
    public string museum_bookJerichoRus5;
    [DefaultValue("- The designs for all weapons and alternate weapons, with the exceptions of the original revolver and shotgun")]
    public string museum_bookJerichoRus6;
    [DefaultValue("- The main promo art, which is used as the game's cover art")]
    public string museum_bookJerichoRus7;
    [DefaultValue("- Most level textures, including all level textures for layers 2-4")]
    public string museum_bookJerichoRus8;
    [DefaultValue("- All the art for the intermissions and 2-S")]
    public string museum_bookJerichoRus9;
    [DefaultValue("\"Hi, thank you to the rest of the dev team and you guys for enjoying what we create. I've met many wonderful people through ULTRAKILL's development and hope to continue doing so. Shoutout to SXBIG and Luvoid!\"")]
    public string museum_bookJerichoRus10;
    
    [DefaultValue("<b><color=#DA6B6D>BIGROCKBMP</color> - CONCEPT ARTIST</b>")]
    public string museum_bookBigRockBMP1;
    [DefaultValue("BigRock joined the team in early 2019, during the Prelude's development. He was the first concept artist for the game and responsible for the designs for many of the game's bosses, such as the game's first ever character design, the Swordsmachine.")]
    public string museum_bookBigRockBMP2;
    [DefaultValue("Some of his biggest contributions include:")]
    public string museum_bookBigRockBMP3;
    [DefaultValue("- The designs for many of the game's bosses, such as the Swordsmachine, the Corpse of King Minos, and the Hideous Mass")]
    public string museum_bookBigRockBMP4;
    [DefaultValue("- The designs for many of the game's enemies, such as the Mindflayer, the Idol and the Sentry")]
    public string museum_bookBigRockBMP5;
    [DefaultValue("- The designs for all of the bosses in the Prime Sanctums")]
    public string museum_bookBigRockBMP6;
    [DefaultValue("- The painting of the rocket launcher wielding Ferryman in 5-3: SHIP OF FOOLS")]
    public string museum_bookBigRockBMP7;
    [DefaultValue("\"When Hakita asked me to design a boss for his game I had no idea that ULTRAKILL would become this big. To see so many people draw fanart of the characters I've designed is both intimidating as it is inspiring me to continue, try and grow as an artist, and I hope my work inspires someone to pick up a pencil as well.\"")]
    public string museum_bookBigRockBMP8;
    
    [DefaultValue("<b><color=#8f65da>MAXIMILIAN OVESSON</color> - UI ARTIST</b>")]
    public string museum_bookMaximilianOvesson1;
    [DefaultValue("Maximilian joined the team in 2018, early in the game's development. He's responsible for the weapon icons used in the UI, the game over skull animation as well as the game's logo.")]
    public string museum_bookMaximilianOvesson2;
    [DefaultValue("\"I'm proud to have played a small role in creating ULTRAKILL and grateful for the opportunity to be a part of this game. Thank you for having me and thank you to all the players for your support.\"")]
    public string museum_bookMaximilianOvesson3;

    [DefaultValue("<b><color=#dabfff>RHIANNON MITCHELL</color> - UI ARTIST</b>")]
    public string museum_bookRhiannonMitchell1;
    [DefaultValue("Rhia temporarily joined the team in late 2024 to assist with making V1's updated UI for the ULTRA_REVAMP update, for which she made most of the graphical elements, such as buttons, scroll bars, backgrounds, etc. which are used in the menus and HUD.")]
    public string museum_bookRhiannonMitchell2;
    [DefaultValue("\"I never know what to say for these sorts of things so just, be good, be mindful, love and live frivolously. Make sure to leave your comfort zone once in a while, 90 on a road trip, eat some food you've never had, embrace spontaneity but have an exit plan. Remind the people around you what they mean to you. Remind yourself that you're important. Find something to believe in, and find it for yourself. And when you do, pass it on to the future.\"")]
    public string museum_bookRhiannonMitchell3;

    [DefaultValue("<b><color=#F5ABB9>VICTORIA HOLLAND</color> - LEAD 3D ARTIST AND GRAPHICS PROGRAMMER</b>")]
    public string museum_bookVictoriaHolland1;
    [DefaultValue("Victoria joined the team in early 2020, late into the Limbo layer's development. She started off working alongside Sam but from Act 2 onwards, she's been responsible for all 3D models in the game with the only exception of the Sisyphean Insurrectionist. She also handles the programming of all shaders and almost all graphical systems and optimizations.")]
    public string museum_bookVictoriaHolland2;
    [DefaultValue("Some of her biggest contributions include:")]
    public string museum_bookVictoriaHolland3;
    [DefaultValue("- Art, programming and level design for 7-S")]
    public string museum_bookVictoriaHolland4;
    [DefaultValue("- Many of the Act 1 models, including the Filth, the Corpse of King Minos and the Railcannon")]
    public string museum_bookVictoriaHolland5;
    [DefaultValue("- All of the Act 2 models, except the Sisyphean Insurrectionist")]
    public string museum_bookVictoriaHolland6;
    [DefaultValue("- Programming for all the shaders")]
    public string museum_bookVictoriaHolland7;
    [DefaultValue("- Programming for most graphical systems and optimizations")]
    public string museum_bookVictoriaHolland8;
    [DefaultValue("\"Waste no time to fear. Take the leap and embrace the person you want to be. You're not alone, so live your authentic self, and always enjoy the journey.\"")]
    public string museum_bookVictoriaHolland9;
    
    [DefaultValue("<b><color=orange>TONI STIGELL</color> - 3D ARTIST</b>")]
    public string museum_bookToniStigell1;
    [DefaultValue("Toni Stigell joined the team right around the start of development in early 2018. We had previously worked together on a few small projects including a now-cancelled stealth game called Untraceable, which is the origin of the thinking man statue that eventually became Cerberus.")]
    public string museum_bookToniStigell2;
    [DefaultValue("Alongside that, he modelled many of the early character models for ULTRAKILL until leaving the project in mid 2019. He also made the original Filth model's animations, and though those have since been replaced, Something Wicked still uses one of them, making that the only animation in the game that I haven't made myself.")]
    public string museum_bookToniStigell3;
    [DefaultValue("Some of his biggest contributions include:")]
    public string museum_bookToniStigell4;
    [DefaultValue("- The original models for the husks, Swordsmachine and Feedbacker arm")]
    public string museum_bookToniStigell5;
    [DefaultValue("- The design for the original version of the Filth")]
    public string museum_bookToniStigell6;
    [DefaultValue("- Getting me into DMC in the first place")]
    public string museum_bookToniStigell7;
    
    [DefaultValue("<b><color=#6a36be>FLYINGDOG</color> - 3D ARTIST</b>")]
    public string museum_bookFlyingDog1;
    [DefaultValue("FlyingDog joined the team right at the start of development in early 2018, designing and creating many of the first 3D models and their textures. Although most of these models have since been remade and replaced, they're still based on his original designs and many of his original models can still be seen here and there as easter eggs. His final contribution to the game was the texture for the Feedbacker arm in mid 2019.")]
    public string museum_bookFlyingDog2;
    [DefaultValue("Some of his biggest contributions include:")]
    public string museum_bookFlyingDog3;
    [DefaultValue("- The designs and original models for the revolver, shotgun and Malicious Face")]
    public string museum_bookFlyingDog4;
    [DefaultValue("- The original model and texture for the nailgun")]
    public string museum_bookFlyingDog5;
    [DefaultValue("- The textures for the original versions of the husks and Swordsmachine")]
    public string museum_bookFlyingDog6;
    
    [DefaultValue("<b><color=orange>SAMUEL JAMES BRYAN</color> - 3D ARTIST</b>")]
    public string museum_bookSamuelJamesBryan1;
    [DefaultValue("Sam joined in mid 2019, early into the Limbo layer's development and is responsible for modelling most of the enemies in Act 1, including V1, V2 and Gabriel. His last modelling work for the game was the Sisyphean Insurrectionist in early 2021 and he has mostly moved on to different projects since then, though he still occasionally helps out with feedback and modelling advice.")]
    public string museum_bookSamuelJamesBryan2;
    [DefaultValue("\"No idea, ask Hakita.\"")]
    public string museum_bookSamuelJamesBryan3;
    
    [DefaultValue("<b><color=orange>PITR</color> - LEAD PROGRAMMER</b>")]
    public string museum_bookPitr1;
    [DefaultValue("PITR already started helping out with programming in late 2019, but was officially added to the team in early 2020 thanks to his ULTRAKILL mods and an early attempt at a custom level system. They're responsible for most advanced programming in the game before Heckteck joined to halve the burden, such as systems like cheats, Cyber Grind patterns and subtitles. They also created the entirety of the Sandbox and 5-S, with only minor aesthetic touch-ups from me.")]
    public string museum_bookPitr2;
    [DefaultValue("Basically, if you look at the game's code and see anything that's actually done well before 2023, it's probably by them.")]
    public string museum_bookPitr3;
    [DefaultValue("Some of their biggest contributions include:")]
    public string museum_bookPitr4;
    [DefaultValue("- Programming and level design for the Sandbox and 5-S")]
    public string museum_bookPitr5;
    [DefaultValue("- Programming for most of the early advanced systems like cheats, Cyber Grind patterns and subtitles")]
    public string museum_bookPitr6;
    [DefaultValue("- Lots of programming optimization and bugfixes")]
    public string museum_bookPitr7;
    [DefaultValue("- Lots of miscellaneous programming help")]
    public string museum_bookPitr8;
    
    [DefaultValue("<b><color=orange>HECKTECK</color> - LEAD PROGRAMMER</b>")]
    public string museum_bookHeckteck1;
    [DefaultValue("Heckteck was brought onto the team temporarily in early 2022 and full-time in 2023 thanks to her experience and skills in making mods for ULTRAKILL, to overhaul the style system to include staleness as well as other related quality of life features. She also created the jukebox system for the Cyber Grind, the new multi-bind system and other quality of life features. In 2025, due to her work in the 2024 enemy rewrite and the 2025 portal mines, she was promoted to be the second Lead Programmer.")]
    public string museum_bookHeckteck2;
    [DefaultValue("\"the harvest is lacking this year\"")]
    public string museum_bookHeckteck3;
    
    [DefaultValue("<b><color=#c0c0c0ff>EMANUIL \"CABALCROW\" CHIZHOV</color> - ADDITIONAL PROGRAMMER</b>")]
    public string museum_bookCabalcrow1;
    [DefaultValue("CabalCrow was one of the first hardcore ULTRAKILL fans who helped spark the game's speedrunning scene. He also helped out a lot with figuring out bugs before the game got a QA team and recorded most of the trailer footage in early trailers. His programming contribution comes in the form of the climbstep system he created in 2020, which allows players to smoothly step onto and over small ledges and obstacles.")]
    public string museum_bookCabalcrow2;
    [DefaultValue("\"you know what they say\n50 bucks is 50 bucks\"")]
    public string museum_bookCabalcrow3;
    
    [DefaultValue("<b><color=#BD8BF3>LUCAS VARNEY</color> - ADDITIONAL PROGRAMMER</b>")]
    public string museum_bookLucasVarney1;
    [DefaultValue("Lucas is another New Blood programmer, mostly working on his own game but occasionally jumping in to help with ULTRAKILL when needed. His contributions have been mostly optimization related, helping make the game run better as well as creating development tools that allow for easier per-level optimization. In the 2025 portal mines, he helped port multiple enemies to work with portals and created whole systems, such as the portal aware-renderer system which allows objects that are partially inside a portal to be visible from both sides.")]
    public string museum_bookLucasVarney2;
    [DefaultValue("\"Many thanks to everyone here, including you, the one reading this! It's always been my dream to work on video games, but I never thought I'd be 'good enough' to do it professionally. I dropped out of high school early due to anxiety and I really felt like I was throwing my life away. But I never gave up, and I never will!\n\nWhoever you are out there, never lose hope, and always know that there's no shame in being yourself and doing the things you love, so long as nobody gets hurt. You're more than your label, and you're worth more than your credentials. Enjoy the little moments, embrace what makes you happy, and be the best person you can be.\"")]
    public string museum_bookLucasVarney3;
    
    [DefaultValue("<b><color=#3EF242>BEN MOIR</color> - ADDITIONAL PROGRAMMER</b>")]
    public string museum_bookBenMoir1;
    [DefaultValue("Ben aka \"Zombie\" is New Blood's resident programming wizard. He hops around from project to project, fixing tricky issues and giving general programming advice. If there's a problem, he knows the solution.")]
    public string museum_bookBenMoir2;
    [DefaultValue("Although most of his work on ULTRAKILL is in the form of helping other programmers, he has himself also programmed some of the systems in the game, such as the controller support and the auto aim assist. In the 2025 portal mines, he helped solve a lot of tricky issues, as well as creating the particle and sound propagation systems for portals.")]
    public string museum_bookBenMoir3;
    [DefaultValue("\"Hey, Hakita! Can we say 'fuck' in the game?\"")]
    public string museum_bookBenMoir4;
    
    [DefaultValue("<b><color=#E93436>MEGANEKO</color> - GUEST COMPOSER</b>")]
    public string museum_bookMeganeko1;
    [DefaultValue("I met Meganeko in early 2020 after BigRock, who is a fan of his, noticed he followed the ULTRAKILL Twitter account and asked if he'd be interested in collaborating. Originally I didn't have anything specific in mind, but once he sent me a soundtest clip that showed the kind of sound he'd go for, it immediately struck me as the perfect music for an endless survival mode.")]
    public string museum_bookMeganeko2;
    [DefaultValue("That soundtest eventually, through months of iteration, became The Cyber Grind's titular background music. In a way, you can thank him for causing the creation of that mode.")]
    public string museum_bookMeganeko3;
    [DefaultValue("\"Playing the alpha demo got me incredibly inspired! Getting to channel that back into the game was a bit surreal.\nBig thanks to Hakita and BigRock for reaching out!\"")]
    public string museum_bookMeganeko4;
    
    [DefaultValue("<b><color=#aa0000>KEYGEN CHURCH</color> - GUEST COMPOSER</b>")]
    public string museum_bookKeygenChurch1;
    [DefaultValue("Keygen Church aka Master Boot Record approached me in mid-late 2022, and I was already a fan of his music as Keygen Church, so I was very happy to have him on board as a guest composer. The timing was perfect as well, since his style fits so well with the aesthetics of the Heresy layer, so he created the first battle theme for P-2, titled \"Tenebre Rosso Sangue\".")]
    public string museum_bookKeygenChurch2;
    [DefaultValue("We also collaborated on the connected ARG, with him doing most of the heavy lifting since he had already done similar things with his projects.")]
    public string museum_bookKeygenChurch3;
    [DefaultValue("\"Low Resolution. High Imagination. Praise the code.\"")]
    public string museum_bookKeygenChurch4;
    
    [DefaultValue("<b><color=red>HEALTH</color> - GUEST COMPOSER</b>")]
    public string museum_bookHealth1;
    [DefaultValue("<b><color=red>BENJAMIN MILLER</color> - DRUMS")]
    public string museum_bookHealth2;
    [DefaultValue("<color=red>JACOB DUZSIK</color> - VOCALS, GUITAR")]
    public string museum_bookHealth3;
    [DefaultValue("<color=red>JOHN FAMIGLIETTI</color> - BASS, SOFTWARE</b>")]
    public string museum_bookHealth4;
    [DefaultValue("In early 2023 we collaborated with the band HEALTH to premiere their song \"HATEFUL\" in the Cyber Grind. I've been a fan of HEALTH ever since I heard their music in Max Payne 3 and their heavy, blood-pumping electronic beats are a perfect fit for ULTRAKILL's mayhem, so I'm very happy that their music became a part of the game.")]
    public string museum_bookHealth5;
    [DefaultValue("\"BACK TO THE CYBER GRIND\"")]
    public string museum_bookHealth6;

    [DefaultValue("<b><color=orange>KING GIZZARD & THE LIZARD WIZARD</color> - GUEST COMPOSER</b>")]
    public string museum_bookKingGizzard1;
    [DefaultValue("<b><color=orange>STU MACKENZIE</color>")]
    public string museum_bookKingGizzard2;
    [DefaultValue("<color=orange>AMBROSE KENNY-SMITH</color>")]
    public string museum_bookKingGizzard3;
    [DefaultValue("<color=orange>JOEY WALKER</color>")]
    public string museum_bookKingGizzard4;
    [DefaultValue("<color=orange>COOK CRAIG</color>")]
    public string museum_bookKingGizzard5;
    [DefaultValue("<color=orange>LUCAS HARWOOD</color>")]
    public string museum_bookKingGizzard6;
    [DefaultValue("<color=orange>MICHAEL CANAVAGH</color>")]
    public string museum_bookKingGizzard7;
    [DefaultValue("<color=orange>ERIC MOORE</color></b> (on \"Robot Stop\")")]
    public string museum_bookKingGizzard8;
    [DefaultValue("King Gizzard & The Lizard Wizard is at this point a band that needs no introduction, having over the years become a legendary force in the underground rock scene. When their album PetroDragonic Apocalypse released in 2023, I felt it would be a perfect fit for ULTRAKILL's combat.")]
    public string museum_bookKingGizzard9;
    [DefaultValue("Me and Dave both love their music, so we had a hard time agreeing on which song to include. In the end we decided to just go for it and add all 3 of the songs we'd discussed, \"Robot Stop\" from the 2016 album Nonagon Infinity, \"The Dripping Tap\" from the 2022 album Omnium Gatherum and \"Supercell\" from the aforementioned 2023 album PetroDragonic Apocalypse.")]
    public string museum_bookKingGizzard10;
    [DefaultValue("Of course, by the time we actually managed to get the songs in, they had already released another 2 albums.")]
    public string museum_bookKingGizzard11;
    [DefaultValue("Since the band has 6 members (plus a 7th from around the time of Robot Stop), we elected to instead include a plushification of the lizard from the cover of PetroDragonic Apocalypse as a stand-in for the entire band.")]
    public string museum_bookKingGizzard12;

    [DefaultValue("<b><color=#AA4CAD>QUETZAL TIRADO</color> - GUEST MUSICIAN</b>")]
    public string museum_bookQuetzalTirado1;
    [DefaultValue("I met Quetzal through a mutual friend in early 2021, when I asked her if she could record a saxophone solo for the P-1 song \"CHAOS\". The solo didn't really end up working out, but parts of her recordings were still included and scattered about the track for added noise and texture.")]
    public string museum_bookQuetzalTirado2;
    [DefaultValue("Later, she recorded improvised saxophone solos for the 5-1 song \"Deep Blue\", which I edited into what you hear in the final version. She also recorded the bass clarinet drone which turned into the Sisyphean Insurrectionist's horn sound effect.")]
    public string museum_bookQuetzalTirado3;
    [DefaultValue("\"my mom liked the song i'm on in ultrakill, so i think at this point i count as a successful artist, right? also many thanks to the gay people, find me on that one level where the water fucks up the music, baby\"")]
    public string museum_bookQuetzalTirado4;
    
    [DefaultValue("<b><color=#20FF20>SALAD</color> - HELPING HAND</b>")]
    public string museum_bookSalad1;
    [DefaultValue("Having previously contributed to the game with his drawing of Jakito, Salad temporarily joined the team in early 2025 to help with new UI art and programming, mainly focused on the Smile OS 2.0 system the terminals use, but also drew the text-mode pixel art logo and V1 for the main menu. He has also helped out by hanging out in voice chat daily during development sessions for motivation and bouncing ideas off of.")]
    public string museum_bookSalad2;
    [DefaultValue("\"Let's see you grit those teeth!\"")]
    public string museum_bookSalad3;
    //public string museum_bookSalad4;
    //public string museum_bookSalad5;
    
    [DefaultValue("<b><color=#FFB2DC>JACOB H.H.R.</color> - WRITER (PROSE & DIALOGUE)</b>")]
    public string museum_bookJacobHHR1;
    [DefaultValue("Jacob joined the team in early 2020 to help write the prose and dialogue for the game after I met him through a mutual game developer friend. He's mostly responsible for the writing in the various books you find around the levels, as well as Gabriel's dialogue and the prose for the intermission cutscenes. In Act I, I came up with a general outline of what I wanted each text to have and he would write it with some tweaks and edits from me afterwards, while in Act II the prose writing was more of an even 50/50 split between us.")]
    public string museum_bookJacobHHR2;
    [DefaultValue("Most of those great poetic phrases and impactful lines that have become iconic in the ULTRAKILL community are thanks to his skills with the English language.")]
    public string museum_bookJacobHHR3;
    
    [DefaultValue("<b><color=#ee0c47>VVIZARD</color> - MUSEUM DEVELOPER</b>")]
    public string museum_bookVVizard1;
    [DefaultValue("Vvizard was picked up temporarily in late 2022 to create this museum thanks to his experience and skills with an early version of the ULTRAKILL level editor. He designed the level and made all the models and textures for it.")]
    public string museum_bookVVizard2;
    [DefaultValue("If you were wondering why it's the best looking level in the game, he's the reason.")]
    public string museum_bookVVizard3;
    [DefaultValue("\"ULTRAKILL is special to me in a way that is just a book's length worth of words, working on this game is something I will hold close to my heart, always.\nI hope I can continue to work with the wonderful people at New Blood and the interactions I've had with community helped bring me to be a part of this team.\n\n\nSometimes I wonder where the dominos fall begins and where it will end. But if Oyff ever sees this, a good youtube video (The ULTRAKILL Rip and Tear) really can change your life.\"")]
    public string museum_bookVVizard4;
    
    [DefaultValue("<b>ADDITIONAL MUSIC CREDITS:</b>")]
    public string museum_bookAdditionalMusic1;
    [DefaultValue("\"Take Care\", the shop theme: Sampled from \"Were You Foolin'\" by the Russ Morgan Orchestra (Public domain)")]
    public string museum_bookAdditionalMusic2;
    [DefaultValue("\"Cerberus\" in 0-5: CERBERUS: Classical music sampled from \"Mars, the Bringer of War\" from Gustav Holst's Planets Suite (Public domain)")]
    public string museum_bookAdditionalMusic3;
    [DefaultValue("\"Clair de Lune\" in 1-4: CLAIR DE LUNE: Written by Claude Debussy, performance by Laurens Goedhart (CC 3.0 license)")]
    public string museum_bookAdditionalMusic4;
    [DefaultValue("\"BWV 639 'I call to you, Lord Jesus Christ'\" in 3-2: IN THE FLESH: Written by Johann Sebastian Bach (Public domain)")]
    public string museum_bookAdditionalMusic5;
    [DefaultValue("\"The Spinal Staircase\" in P-1: SOUL SURVIVOR: Sampled from \"Sourire d'Avril\" composed by Maurice Depret (Public domain)")]
    public string museum_bookAdditionalMusic6;
    [DefaultValue("\"CHAOS\" in P-1: SOUL SURVIVOR: Bass clarinet and soprano saxophone improvised and recorded by Quetzal Tirado")]
    public string museum_bookAdditionalMusic7;
    [DefaultValue("\"Deep Blue\" in 5-1: IN THE WAKE OF POSEIDON: Tenor saxophone improvised and recorded by Quetzal Tirado, edited by Hakita")]
    public string museum_bookAdditionalMusic8;
    [DefaultValue("\"Fallen Angel\" in 6-2: AESTHETICS OF HATE: Adapted from \"BWV 639 'I call to you, Lord Jesus Christ'\" by Johann Sebastian Bach")]
    public string museum_bookAdditionalMusic9;
    [DefaultValue("\"7th Symphony, 2nd Movement: Allegretto\" in Intermission 2: Written by Ludwig van Beethoven, performance by Lambis Vassiliadis (Public domain)")]
    public string museum_bookAdditionalMusic10;
    [DefaultValue("\"Intro (Weihnachten Am Klavier)\" in P-2: Samples from \"Weihnachten Am Klavier\" by Adolph Gluck (public domain recording)")]
    public string museum_bookAdditionalMusic11;
    [DefaultValue("First feeding ambiance in 7-3: NO SOUND, NO MEMORY: Sampled from \"Take a Look at Molly\", written by Hazel M. Lockwood and Lee W. Lockwood, peformance by John McCormack (Public domain)")]
    public string museum_bookAdditionalMusic12;
    [DefaultValue("\"Gymnopédies - la 1ére. lent et douloureux\" in ULTRAKILL Development History video: Written by Erik Satie, Performance by Robin Alciatore (Public domain)")]
    public string museum_bookAdditionalMusic13;
    
    [DefaultValue("<b>ADDITIONAL CREDITS</b>")]
    public string museum_bookAdditionalCredits1;
    [DefaultValue("<b><color=orange>Finn [Frej]</color></b> - Creator of the \"Fuckin Finland\" animation")]
    public string museum_bookAdditionalCredits2;
    [DefaultValue("<b><color=orange>COMMUNITY CYBER GRIND PATTERNS</color> by</b>")]
    public string museum_bookAdditionalCredits3;
    [DefaultValue("<b><color=orange>SPECIAL THANKS</color> to</b>")]
    public string museum_bookAdditionalCredits4;
    [DefaultValue("<b>David Szymanski, Leon Zawada and Simon Rance</b> for allowing us to use assets from their games for easter eggs")]
    public string museum_bookAdditionalCredits5;
    [DefaultValue("<b>Magnega</b> for telling me my previous game, Untraceable, was unfun, causing an existential crisis that resulted in me dropping that project and making ULTRAKILL instead")]
    public string museum_bookAdditionalCredits6;
    [DefaultValue("<b>Mikko Tamper and Robert Raulus</b> for their continued support as well as beta testing and giving feedback")]
    public string museum_bookAdditionalCredits7;
    [DefaultValue("<b>B.G.B. and Splendid</b> for beta testing early versions of new levels and giving helpful feedback")]
    public string museum_bookAdditionalCredits8;
    [DefaultValue("<b>Suzy Komporozou</b> for giving advice on the use of the Greek language")]
    public string museum_bookAdditionalCredits9;
    [DefaultValue("The FontStruction “fs Tahoma 8px v2” (https://fontstruct.com/fontstructions/show/2502370) by “chriswal1200” is licensed under a Creative Commons Attribution Share Alike license (http://creativecommons.org/licenses/by-sa/3.0/).\n“fs Tahoma 8px v2” was originally cloned (copied) from the FontStruction “fs Tahoma 8px” (https://fontstruct.com/fontstructions/show/735108) by “ETHproductions”, which is licensed under a Creative Commons Attribution Share Alike license (http://creativecommons.org/licenses/by-sa/3.0/).")]
    public string museum_bookAdditionalCreditsForFonts;
    
    [DefaultValue("<b><color=orange>STEPHAN WEYTE</color> - VOICE OF MINOS PRIME</b>")]
    public string museum_bookStephanWeyte1;
    [DefaultValue("As with most people, I mainly knew Stephan Weyte as the voice of Caleb from Blood, but hearing him as Nyarlathotep in Dusk made it clear that he still had the skills, so even before joining New Blood, I had already decided that I wanted Stephan to voice someone in ULTRAKILL. When time came to choose the voice for Minos Prime, the choice was obvious.")]
    public string museum_bookStephanWeyte2;
    [DefaultValue("Stephan was lovely to work with, and his voice lends so much richness and character to Minos that I really can't imagine him any other way. ")]
    public string museum_bookStephanWeyte3;
    
    [DefaultValue("<b><color=orange>LENVAL BROWN</color> - VOICE OF SISYPHUS PRIME</b>")]
    public string museum_bookLenvalBrown1;
    [DefaultValue("I approached Lenval in early 2023 after hearing his fantastic performance as the narrator in Disco Elysium and feeling that his deep, textural voice would be the perfect fit for King Sisyphus. He was a pleasure to work with and helped really make Sisyphus stand out as his own unique character.")]
    public string museum_bookLenvalBrown2;
    [DefaultValue("")]
    public string museum_bookLenvalBrown3;
    
    [DefaultValue("<b><color=#20afdb>GIANNI MATRAGRANO</color> - VOICE OF GABRIEL</b>")]
    public string museum_bookGianniMatragrano1;
    [DefaultValue("Gianni originally approached me offering his talents in late 2019, but we didn't start working together until mid-late 2020, a bit less than a week before the game came out in Early Access. Despite the short timeframe, he knocked it out of the park, not only defining and solidifying Gabriel's character and voice but also delivering fantastic performances that manage to capture both his visceral intensity and the subtler nuances of his internal world.")]
    public string museum_bookGianniMatragrano2;
    [DefaultValue("Since then he's only gotten better, and I'm very glad to work with someone who understands both my vision of the story and the character of Gabriel so well that he was able to improvise all of the taunts in Gabriel's first fight. He's a joy to work with and the dream of any over-ambitious indie developer like me.")]
    public string museum_bookGianniMatragrano3;
    [DefaultValue("\"Can you write in it that I said thank you to gay people.\"")]
    public string museum_bookGianniMatragrano4;
    
    [DefaultValue("<b><color=#e09e2e>MANDALORE</color> <color=#9884bb>HERRINGTON</color> - VOICE OF MYSTERIOUS DRUID KNIGHT</b>")]
    public string museum_bookMandalore1;
    [DefaultValue("<b><color=#eabbd7>JOY YOUNG</color> - VOICE OF OWL</b>")]
    public string museum_bookMandalore2;
    [DefaultValue("I originally met with Mandalore in late 2019 after his review of Dusk, when I DM'd him to ask him to elaborate on some criticisms he had mentioned of retro shooters. At the time ULTRAKILL was just a small no-name project, but he still took the time to not only write an in-depth reply, but also to play ULTRAKILL's demo and give very useful feedback for it.")]
    public string museum_bookMandalore3;
    [DefaultValue("As thanks for his help, I wanted to make a little joke boss fight featuring him and Joy based on some in-jokes from their Mystery of the Druids stream, using clips from his EYE review as his voicelines. Once he saw the boss, he offered to not only re-record those lines, but also record completely new ones with Joy, which they improvised together.")]
    public string museum_bookMandalore4;
    [DefaultValue("Also, Mandalore played the aztec death whistle on the 7-1 track \"Bull of Hell\".")]
    public string museum_bookMandalore5;
    [DefaultValue("<color=#e09e2e>\"Visit me</color> <color=#9884bb>in the tombs with piped in music. How classy. Thanks for playing!\"</color>")]
    public string museum_bookMandalore6;
    [DefaultValue("\"here for a good time, not a bad time\"")]
    public string museum_bookMandalore7;
    
    [DefaultValue("<b><color=orange>BEAMCUTTER</color></b>")]
    public string museum_weaponsBeamcutter1;
    [DefaultValue("Design by Francis, WIP model by Victoria.")]
    public string museum_weaponsBeamcutter2;
    [DefaultValue("<b>PRIMARY FIRE:</b> Hold to fire beam")]
    public string museum_weaponsBeamcutter3;
    [DefaultValue("<b>SECONDARY FIRE:</b> Place/Remove beam drone")]
    public string museum_weaponsBeamcutter4;
    [DefaultValue("A sixth weapon which was cut early into its creation due to running into many design issues and to avoid arsenal bloat and weapon role overlap.")]
    public string museum_weaponsBeamcutter5;
    [DefaultValue("Based on the lightning gun archetype, it fires a sustained beam that requires the player to track their target to deal continuous damage. It deals reduced damage while standing still to discourage the player from staying still while firing, though in this version you can just move back and forth quickly to fulfill that requirement without making aiming much harder.")]
    public string museum_weaponsBeamcutter6;
    [DefaultValue("Sustained fire weapons are very difficult to make work well with ULTRAKILL's combat system, as proven by how many iterations the Nailgun had to go through before it found its place in the arsenal, and since infinite ammo means every weapon has to have its own niche in order to not make any other weapon obsolete and the Nailgun already filling a similar role, I made the choice to cut it instead of trying to force it into an already full arsenal.")]
    public string museum_weaponsBeamcutter7;
    [DefaultValue("The front of the weapon was supposed to spin when the beam is being fired, but this WIP model has no rigging. No sounds were implemented yet either, so it may seem quite weak in terms of feedback in comparison to the finished weapons.")]
    public string museum_weaponsBeamcutter8;
    [DefaultValue("While I do like the weapon in concept, I do think it was the right call to cut it. I prefer a smaller arsenal where every weapon is distinct and useful over a larger arsenal where some of them become obsolete with the introduction of others.")]
    public string museum_weaponsBeamcutter9;
    
    [DefaultValue("<b><color=orange>BLACK HOLE CANNON</color></b>")]
    public string museum_weaponsBlackHoleCannon1;
    [DefaultValue("<b>PRIMARY FIRE:</b> Launch a black hole")]
    public string museum_weaponsBlackHoleCannon2;
    [DefaultValue("<b>SECONDARY FIRE:</b> Activate a launched black hole")]
    public string museum_weaponsBlackHoleCannon3;
    [DefaultValue("A cut superweapon that was intended to work via a meter that got filled by killing enemies. It was made around early 2019, shortly after the addition of the shotgun, with the intent of it being introduced much later in the game.")]
    public string museum_weaponsBlackHoleCannon4;
    [DefaultValue("The player would have the choice of using their kill meter for a temporary buff a la Devil Trigger from Devil May Cry, or a shot with the black hole cannon. The meter was scrapped due to these kinds of mechanics often leading to issues with hoarding and balancing, since encounters can't be balanced around whether or not the player has meter, leading to battles being either too easy with meter or too hard without it.")]
    public string museum_weaponsBlackHoleCannon5;
    [DefaultValue("Instead, the DT buff mode idea was turned into the dual wield powerup, which avoids that issue since the level designer controls when the player has access to it, and the Black Hole Cannon's role became filled with the Railcannon, a lower commitment superweapon that's weak enough to not become an ace-in-the-sleeve crutch for players to skip tricky encounters with and usable often enough that the player doesn't feel a need to hoard it.")]
    public string museum_weaponsBlackHoleCannon6;
    [DefaultValue("Although the Black Hole Cannon was incredibly powerful when it was originally made, since the only enemies in the game were the basic husks, the game has grown far more chaotic and explosive since then, making it quite weak in comparison. I've kept its original power level for this museum version for the sake of an accurate portrayal, so if it seems weak, that's because it was just made for killing Filth, Strays and Schisms.")]
    public string museum_weaponsBlackHoleCannon7;
    [DefaultValue("The Black Hole Cannon never got a visual design or model, hence why it's represented by a stretched out shotgun. This lead to many people thinking it was supposed to be a shotgun variation, but that was never the intent.")]
    public string museum_weaponsBlackHoleCannon8;
    
    [DefaultValue("<b><color=orange>REVOLVER</color>")]
    public string museum_weaponsRevolver1;
    [DefaultValue("LEFT: 2018 Original by FlyingDog")]
    public string museum_weaponsRevolver2;
    [DefaultValue("RIGHT: 2022 Remake by Victoria</b>")]
    public string museum_weaponsRevolver3;
    [DefaultValue("The first weapon as well as the first model ever made for the game. As usual, there was no concept art, so the design was made up on the spot by FlyingDog based on a prompt from me. Victoria has since then remade the model and texture while keeping true to the original design, making for a straight visual upgrade.")]
    public string museum_weaponsRevolver4;
    [DefaultValue("The revolver originally had different green and red variations. The old green variation was the ability to ricochet shots off of surfaces, inspired by Revolver Ocelot. Unfortunately, while cool in concept, it was extremely unwieldy and awkward to use, requiring far too much set up and positioning to be used efficiently, clashing hard with the game's fast pace. The idea of showing off marksmanship via ricocheting shots stayed however, and was reinterpreted into the now iconic and far more useful coin version. Eventually, the surface-ricocheting idea did get revisited and improved on with the Sharpshooter variation, which uses heavy aim assist to make ricocheting easier, as well as giving the shots other useful attributes that the original didn't have.")]
    public string museum_weaponsRevolver5;
    [DefaultValue("The red variation was a dual wield variation, where the left revolver was fired with the primary fire and the right revolver with the secondary. As with the green variation, this was cool in concept, but mechanically it was very uninteresting beyond the initial novelty. I had some ideas on how to \"fix\" it, but I ended up scrapping it entirely instead, and since then the dual wield idea has been reinterpreted into the much more fun and freeform dual wield powerup.")]
    public string museum_weaponsRevolver6;
    
    [DefaultValue("<b><color=orange>SHOTGUN</color>")]
    public string museum_weaponsShotgun1;
    [DefaultValue("LEFT: 2019 Original by FlyingDog")]
    public string museum_weaponsShotgun2;
    [DefaultValue("RIGHT: 2022 Remake by Victoria</b>")]
    public string museum_weaponsShotgun3;
    [DefaultValue("As with the revolver, the shotgun was made by FlyingDog without concept art, and later remade by Victoria, keeping it faithful to the original design while updating it to fit the game's new visual style better. The new version is lighter in color, since the original matte black style ended up very muted due to the game's vibrant colored lighting, though the people who preferred the old style can use the first color preset to get it back.")]
    public string museum_weaponsShotgun4;
    [DefaultValue("The shotgun had some balancing issues when it was originally added since all enemies already died from just a couple of revolver shots, making the shotgun feel pointless in comparison, leading to a bad first impression. Eventually I had the idea of changing the projectile code slightly, making it so shotgun projectiles don't get destroyed when hitting an enemy that is already dead. This small change is really what opened the shotgun up, turning it from just a slow single target damage dealer into a chaotic weapon of mass destruction, making it useful against both tankier enemies as originally intended as well as crowds of weaker enemies.")]
    public string museum_weaponsShotgun5;
    
    [DefaultValue("<b><color=orange>NAILGUN</color>")]
    public string museum_weaponsNailgun1;
    [DefaultValue("LEFT: 2019 Original by Jericho and FlyingDog")]
    public string museum_weaponsNailgun2;
    [DefaultValue("RIGHT: 2022 Remake by Jericho and Victoria</b>")]
    public string museum_weaponsNailgun3;
    [DefaultValue("The first weapon to be based on concept art, drawn and designed by Jericho, as well as FlyingDog's final contribution to the game. The rougher, simpler original model still fit the visual style at the time, but since then the graphics have improved, making it stick out like a sore thumb, which was one of the primary reasons we wanted to redo the old weapon models, alongside the custom color system.")]
    public string museum_weaponsNailgun4;
    [DefaultValue("The nailgun is probably the weapon that had to go through the most iteration before it finally found its place in the arsenal. In fact, it wasn't until the Sandbox update in Summer 2021 that it finally really clicked in, meaning it took 2 years of constant tinkering and iteration to make an automatic weapon fit the ULTRAKILL arsenal. The biggest change was the change from infinite ammo to recharging ammo, giving players more reason to switch away from it after a bit of use, but the change that finally really made it click was speeding up the equip animation, which made switching to it in combat much smoother, making it feel like an organic part of weapon combos.")]
    public string museum_weaponsNailgun5;
    [DefaultValue("Some scrapped ideas and versions include a high damage slow recharge harpoon and a version that allowed for firing both barrels simultaneously, increasing rate of fire at the cost of the player's movement speed. The former eventually evolved into the magnet and the latter into the overheat, so despite how much things have changed, parts of the originals still remain.")]
    public string museum_weaponsNailgun6;
    
    [DefaultValue("<b><color=orange>FILTH</color>")]
    public string museum_enemiesFilth1;
    [DefaultValue("LEFT: 2018 Original by Toni Stigell and FlyingDog")]
    public string museum_enemiesFilth2;
    [DefaultValue("RIGHT: 2020 Remake by Jericho, BigRock and Victoria</b>")]
    public string museum_enemiesFilth3;
    [DefaultValue("The Filth, originally just called \"Zombie\" or \"Husk\", was the second enemy designed for the game. We didn't have concept artists at the time, so I just told Toni to make a scrawny zombie like the ones from Quake. This was the usual process before BigRock joined as the first concept artist, and the contrast in design quality makes it clear that creative concept artists can really make a big difference.")]
    public string museum_enemiesFilth4;
    [DefaultValue("An interesting aspect of the Filth is that, in the early versions of the demo, people complained about the AI of the melee enemies being too dumb, but those complaints completely stopped after the redesign. The new version actually looks like a mindless swarming monster that only thinks about eating, so it being dumb no longer felt out of place or like a flaw. Properly messaging the purpose of an enemy or object through how it looks is an often underappreciated aspect of character design.")]
    public string museum_enemiesFilth5;
    [DefaultValue("The new design is inspired by the debut album by Swans, which is also where the enemy got its name from. At first the model's mouth and teeth were much smaller, but I just kept telling Victoria \"BIGGER!\" until we reached the point it's at now.")]
    public string museum_enemiesFilth6;
    [DefaultValue("The Filth was originally colored orange to make it fit into the Prelude chapter, but it actually became an issue where people would often have a hard time seeing them since they fit in <i>too</i> well, so their primary color was swapped to green instead.")]
    public string museum_enemiesFilth7;
    
    [DefaultValue("<b><color=orange>STRAY</color>")]
    public string museum_enemiesStray1;
    [DefaultValue("LEFT: 2018 Original by Toni Stigell, FlyingDog and Hakita")]
    public string museum_enemiesStray2;
    [DefaultValue("RIGHT: 2020 Remake by Jericho and Sam</b>")]
    public string museum_enemiesStray3;
    [DefaultValue("The Stray was originally just called \"Projectile Zombie\" or \"Projectile Husk\" and, for one short period of time, \"Stalker\", though that name was then instead given to the enemy that has it now. Toni was busy at the time, so I, with my limited Blender knowledge, just edited his original Filth model to make the original version of the Stray, and then FlyingDog made the texture for it. Again, we didn't really have any concept art, so the texture was just based on the prompt \"A skeleton with all the organs and meat still inside it\", or something like that.")]
    public string museum_enemiesStray4;
    [DefaultValue("The new version, based on Jericho's design for the Soldier, still keeps that general idea but executes it in a much less cartoony way.")]
    public string museum_enemiesStray5;
    
    [DefaultValue("<b><color=orange>SCHISM</color>")]
    public string museum_enemiesSchism1;
    [DefaultValue("LEFT: 2018 Original by Toni Stigell, FlyingDog and Hakita")]
    public string museum_enemiesSchism2;
    [DefaultValue("RIGHT: 2020 Remake by BigRock and Sam</b>")]
    public string museum_enemiesSchism3;
    [DefaultValue("The Schism, originally just called \"Super Projectile Zombie\", is another edit of the original Filth model. Toni and FlyingDog were both busy around this time, so this model didn't even get a unique texture. It's just the original Filth's texture without the orange tint!")]
    public string museum_enemiesSchism4;
    [DefaultValue("The new version still uses the same skeleton and animations, which means the extra arms just flop around like ragdolls since they have no animation data attached to them.")]
    public string museum_enemiesSchism5;
    [DefaultValue("The new designs for the Husks were drawn and modelled in a bit of a rush to get them done in time for the Prelude facelift we were doing for the new version of the demo after the game got picked up by New Blood, which meant the new designs only got one sketch from one angle each. This lead to a funny incident where Sam, while making the model, misunderstood the sketch and thought that the head was just sticking out really far in front instead of being on the shoulder, which lead to the first iteration of the model to look like a xenomorph!")]
    public string museum_enemiesSchism6;
    
    [DefaultValue("<b><color=orange>SWORDSMACHINE</color>")]
    public string museum_enemiesSwordsmachine1;
    [DefaultValue("LEFT: 2019 Original by BigRock, FlyingDog and Toni Stigell")]
    public string museum_enemiesSwordsmachine2;
    [DefaultValue("RIGHT: 2022 Remake by BigRock and Victoria</b>")]
    public string museum_enemiesSwordsmachine3;
    [DefaultValue("Swordsmachine was the first enemy to be designed by a concept artist, and the difference really shows! BigRock's wonderful Blame!-inspired design is rich with implied character that later became explicit when I wrote the data entry for it.")]
    public string museum_enemiesSwordsmachine4;
    [DefaultValue("The original model, made by Toni Stigell and textured by FlyingDog, unfortunately lost a lot of the nuances the original design had, but it fit the visual style of the game at the time, and we were all amateurs who didn't know how to do any better. Victoria has since then remade the model based on BigRock's original concept art and perfectly translated it to 3D.")]
    public string museum_enemiesSwordsmachine5;
    [DefaultValue("One of the earlier iterations of Swordsmachine's design had a gory human torso, as the enemies at the time were leaning more in the direction of Strogg-like human-machine hybrids before we had the setting, visual language and story properly figured out.")]
    public string museum_enemiesSwordsmachine6;
    
    [DefaultValue("<b><color=orange>MALICIOUS FACE</color>")]
    public string museum_enemiesMaliciousFace1;
    [DefaultValue("LEFT: 2018 Original by FlyingDog")]
    public string museum_enemiesMaliciousFace2;
    [DefaultValue("RIGHT: 2022 Remake by Victoria</b>")]
    public string museum_enemiesMaliciousFace3;
    [DefaultValue("The Malicious Face, called \"Spider\" in the game files thanks to its transparent spider legs, was actually the first enemy to be designed for the game. Although iconic now, its design was supposed to be quite different originally, as I wanted a more stark and simplified look, but FlyingDog, only modelling as a hobby, had a hard time pulling it off without any concept art to aid him, so we eventually compromised with this version.")]
    public string museum_enemiesMaliciousFace4;
    [DefaultValue("This was back when I was stupidly ambitious and had no idea what I was doing, so there were a bunch of ideas thrown around that ended up not making it in. The mouth was supposed to move and open when firing, but the rig was buggy and we couldn't get it to work. The eyes were also originally seperated from the main mesh, since I had the idea that it would be cool if you could shoot them out with the revolver for extra damage or to cause the enemy to become blind and attack indiscriminately, which sounds really cool in concept, but in execution would not only be too much complexity for an early enemy but would also give them a hard counter that the player would always resort to, which I've wanted to avoid to make the game more open to player expression. This was before Doom Eternal came out and had a big focus on weakpoints and hard counters.")]
    public string museum_enemiesMaliciousFace5;
    [DefaultValue("Another idea I had at one point was for there to be a hole in the back of its head, exposing the brain, allowing for nimble players to score big damage, but this also never materialized. Me coming up with all these dumb ideas, often after the model was already done, but never committing to them was, very understandably, frustrating to FlyingDog.")]
    public string museum_enemiesMaliciousFace6;
    [DefaultValue("The new model by Victoria is a beautiful almost 1:1 recreation that manages to keep the iconic look while improving the visual quality while actually <i>decreasing</i> its resolution.")]
    public string museum_enemiesMaliciousFace7;

    [DefaultValue("HALL OF SHAME: THE ULTRAKILL DEVELOPERS")]
    public string museum_plaquesMuseumTitle;
    
    [DefaultValue("ARSI \"HAKITA\" PATALA")]
    public string museum_plaquesHakita1;
    [DefaultValue("CREATOR OF ULTRAKILL")]
    public string museum_plaquesHakita2;
    
    [DefaultValue("ART ROOM")]
    public string museum_plaquesArtRoom;
    [DefaultValue("NERD ROOM")]
    public string museum_plaquesNerdRoom;
    [DefaultValue("REST ROOM")]
    public string museum_plaquesRestRoom;
    [DefaultValue("TALK ROOM")]
    public string museum_plaquesTalkRoom;
    
    [DefaultValue("FRANCIS XIE")]
    public string museum_plaquesFrancisXie1;
    [DefaultValue("2D ARTIST")]
    public string museum_plaquesFrancisXie2;
    
    [DefaultValue("JERICHO_RUS")]
    public string museum_plaquesJerichoRus1;
    [DefaultValue("2D ARIST")]
    public string museum_plaquesJerichoRus2;
    
    [DefaultValue("BIGROCKBMP")]
    public string museum_plaquesBigRockBMP1;
    [DefaultValue("CONCEPT ARTIST")]
    public string museum_plaquesBigRockBMP2;
    
    [DefaultValue("MAXIMILIAN OVESSON")]
    public string museum_plaquesMaxOvesson1;
    [DefaultValue("UI ARTIST")]
    public string museum_plaquesMaxOvesson2;

    [DefaultValue("RHIANNON MITCHELL")]
    public string museum_plaquesRhiannonMitchell1;
    [DefaultValue("UI ARTIST")]
    public string museum_plaquesRhiannonMitchell2;

    [DefaultValue("VICTORIA HOLLAND")]
    public string museum_plaquesVictoriaHolland1;
    [DefaultValue("LEAD 3D ARTIST")]
    public string museum_plaquesVictoriaHolland2;
    
    [DefaultValue("TONI STIGELL")]
    public string museum_plaquesToniStigell1;
    [DefaultValue("3D ARTIST")]
    public string museum_plaquesToniStigell2;
    
    [DefaultValue("FLYINGDOG")]
    public string museum_plaquesFlyingdog1;
    [DefaultValue("3D ARTIST")]
    public string museum_plaquesFlyingdog2;
    
    [DefaultValue("SAMUEL JAMES BRYAN")]
    public string museum_plaquesSamuelJamesBryan1;
    [DefaultValue("3D ARTIST")]
    public string museum_plaquesSamuelJamesBryan2;
    
    [DefaultValue("CAMERON MARTIN")]
    public string museum_plaquesCameronMartin1;
    [DefaultValue("QUALITY ASSURANCE LEAD")]
    public string museum_plaquesCameronMartin2;
    
    [DefaultValue("DALIA FIGUEROA")]
    public string museum_plaquesDaliaFigueroa1;
    [DefaultValue("QUALITY ASSURANCE")]
    public string museum_plaquesDaliaFigueroa2;
    
    [DefaultValue("TUCKER WILKIN")]
    public string museum_plaquesTuckerWilkin1;
    [DefaultValue("SENIOR QUALITY ASSURANCE")]
    public string museum_plaquesTuckerWilkin2;
    
    [DefaultValue("SCOTT GURNEY")]
    public string museum_plaquesScottGurney1;
    [DefaultValue("TECHNICAL QUALITY ASSURANCE")]
    public string museum_plaquesScottGurney2;
    
    [DefaultValue("PITR")]
    public string museum_plaquesPitr1;
    [DefaultValue("LEAD PROGRAMMER")]
    public string museum_plaquesPitr2;
    
    [DefaultValue("HECKTECK")]
    public string museum_plaquesHeckteck1;
    [DefaultValue("LEAD PROGRAMMER")]
    public string museum_plaquesHeckteck2;
    
    [DefaultValue("EMANUIL \"CABALCROW\" CHIZHOV")]
    public string museum_plaquesCabalcrow1;
    [DefaultValue("ADDITIONAL PROGRAMMER")]
    public string museum_plaquesCabalcrow2;
    
    [DefaultValue("LUCAS VARNEY")]
    public string museum_plaquesLucasVarney1;
    [DefaultValue("ADDITIONAL PROGRAMMER")]
    public string museum_plaquesLucasVarney2;
    
    [DefaultValue("BEN MOIR")]
    public string museum_plaquesBenMoir1;
    [DefaultValue("ADDITIONAL PROGRAMMER")]
    public string museum_plaquesBenMoir2;
    
    [DefaultValue("DAVE OSHRY")]
    public string museum_plaquesDaveOshry1;
    [DefaultValue("CEO OF NEW BLOOD INTERACTIVE")]
    public string museum_plaquesDaveOshry2;
    
    [DefaultValue("MEGANEKO")]
    public string museum_plaquesMeganeko1;
    [DefaultValue("GUEST COMPOSER")]
    public string museum_plaquesMeganeko2;
    
    [DefaultValue("KEYGEN CHURCH")]
    public string museum_plaquesKeygenChurch1;
    [DefaultValue("GUEST COMPOSER")]
    public string museum_plaquesKeygenChurch2;
    
    [DefaultValue("HEALTH")]
    public string museum_plaquesHealth1;
    [DefaultValue("GUEST COMPOSER")]
    public string museum_plaquesHealth2;

    [DefaultValue("HAZELUFF")]
    public string museum_plaquesHazeluff1;
    [DefaultValue("PROGRAMMER")]
    public string museum_plaquesHazeluff2;
    [DefaultValue("KING GIZZARD & THE LIZARD WIZARD")]
    public string museum_plaquesKingGizzard1;
    [DefaultValue("GUEST COMPOSER")]
    public string museum_plaquesKingGizzard2;

    [DefaultValue("QUETZAL TIRADO")]
    public string museum_plaquesQuetzalTirado1;
    [DefaultValue("GUEST MUSICIAN")]
    public string museum_plaquesQuetzalTirado2;
    
    [DefaultValue("SALAD")]
    public string museum_plaquesSalad1;
    [DefaultValue("HELPING HAND")]
    public string museum_plaquesSalad2;
    
    [DefaultValue("JACOB H.H.R.")]
    public string museum_plaquesJacobHHR1;
    [DefaultValue("WRITER (PROSE & DIALOGUE)")]
    public string museum_plaquesJacobHHR2;
    
    [DefaultValue("VVIZARD")]
    public string museum_plaquesVVizard1;
    [DefaultValue("MUSEUM CREATOR")]
    public string museum_plaquesVVizard2;
    
    [DefaultValue("ADDITIONAL MUSIC")]
    public string museum_plaquesAdditionalMusic;
    [DefaultValue("ADDITIONAL CREDITS")]
    public string museum_plaquesAdditionalCredits;
    
    [DefaultValue("STEPHAN WEYTE")]
    public string museum_plaquesStephanWeyte1;
    [DefaultValue("VOICE OF MINOS PRIME")]
    public string museum_plaquesStephanWeyte2;
    
    [DefaultValue("LENVAL BROWN")]
    public string museum_plaquesLenvalBrown1;
    [DefaultValue("VOICE OF SISYPHUS PRIME")]
    public string museum_plaquesLenvalBrown2;
    
    [DefaultValue("GIANNI MATRAGRANO")]
    public string museum_plaquesGianniMatragrano1;
    [DefaultValue("VOICE OF GABRIEL")]
    public string museum_plaquesGianniMatragrano2;
    
    [DefaultValue("JOY YOUNG")]
    public string museum_plaquesJoyYoung1;
    [DefaultValue("VOICE OF OWL")]
    public string museum_plaquesJoyYoung2;
    
    [DefaultValue("MANDALORE HERRINGTON")]
    public string museum_plaquesMandalore1;
    [DefaultValue("VOICE OF MYSERIOUS DRUID KNIGHT")]
    public string museum_plaquesMandalore2;
    
    [DefaultValue("ROCKET RACE")]
    public string museum_rocketRace1;
    [DefaultValue("START")]
    public string museum_rocketRace2;
    [DefaultValue("RACE START")]
    public string museum_rocketRaceStart;
    [DefaultValue("TIME:")]
    public string museum_rocketRaceResult;

    [DefaultValue("Chess pieces can be moved with the <color=orange>mover arm</color>.")]
    public string museum_chessTip;
    [DefaultValue("VS")]
    public string museum_chessVs;
    [DefaultValue("Start New Game")]
    public string museum_chessNewgame;
    [DefaultValue("Black")]
    public string museum_chessBlack;
    [DefaultValue("White")]
    public string museum_chessWhite;
    [DefaultValue("Bot")]
    public string museum_chessBot;
    [DefaultValue("Player")]
    public string museum_chessPlayer;
    [DefaultValue("WHITE WIN!")]
    public string museum_chessWhitewin;
    [DefaultValue("BLACK WIN!")]
    public string museum_chessBlackwin;
    [DefaultValue("Close")]
    public string museum_chessSettingsclose;
    [DefaultValue("Promote to:")]
    public string museum_chessPromotion;
    [DefaultValue("Q")]
    public string museum_chessQueen;
    [DefaultValue("R")]
    public string museum_chessRook;
    [DefaultValue("B")]
    public string museum_chessBishop;
    [DefaultValue("N")]
    public string museum_chessKnight;
    
    [DefaultValue("PLAY")]
    public string museum_cinemaPlay;
    [DefaultValue("STOP")]
    public string museum_cinemaStop;
    
    [DefaultValue(" WARNING")]
    public string museum_spoiler1;
    [DefaultValue("SPOILER")]
    public string museum_spoiler2;
    [DefaultValue("OPEN")]
    public string museum_spoiler3;

    [DefaultValue("<color=red>CAMERON MARTIN</color> - QUALITY ASSURANCE LEAD")]
    public string museum_bookQATeamLine1;
    [DefaultValue("<color=#6a36be>DALIA FIGUEROA</color> - QUALITY ASSURANCE, MEDIA CAPTURE LEAD")]
    public string museum_bookQATeamLine2;
    [DefaultValue("<color=#11c324>TUCKER WILKIN</color> - SENIOR QUALITY ASSURANCE")]
    public string museum_bookQATeamLine3;
    [DefaultValue("<color=#e28eb6>SCOTT GURNEY</color> - TECHNICAL QUALITY ASSURANCE")]
    public string museum_bookQATeamLine4;
    [DefaultValue("<color=#4480e6>AARON BURZYNSKI</color> - QUALITY ASSURANCE")]
    public string museum_bookQATeamLine5;
    [DefaultValue("The New Blood QA team (Cameron, Dalia, Tucker, Scott and Aaron) are responsible for making sure the game runs properly and without any major bugs. It's thanks to them that ULTRAKILL looks and feels like a functioning game despite being a mess of duct tape, spaghetti, glue and prayers underneath. Prior to ULTRAKILL joining the New Blood catalogue, I had to do QA myself, and even that smaller amount of bugtesting makes me question how these people manage to stay sane.")]
    public string museum_bookQATeamDesc1;
    [DefaultValue("...Well, relatively sane.")]
    public string museum_bookQATeamDesc2;
    [DefaultValue("Also, Scott assisted in the portal mines for Layer 8: FRAUD.")]
    public string museum_bookQATeamDesc3;
    [DefaultValue("\"In the immortal words of the great Hungarian centre-forward Nandor Hidegkuti - 'Amikor eljön a forradalom, a zeneipar lesz az első amely menni fog. Köszönöm szépen'\"")]
    public string museum_bookQATeamQuote1;
    [DefaultValue("\"Be it games, music, movies or the company of others, be sure to enjoy the good times that you experience and always look back on life with a positive note. Life is precious, and after all, It's your own show. Enjoy your life to its fullest and give everyone respect and love. A smile on someone's face is worth its weight in gold!\"")]
    public string museum_bookQATeamQuote2;
    [DefaultValue("\"Of all the scars on my psyche, this one will always remain a favored one. from that cursed door to the accidental spawner arm slip, its been a great time regardless! Sometimes videogames can be cool as hell. hopefully we can get more of them!\"")]
    public string museum_bookQATeamQuote3;
    [DefaultValue("\"Being able to help bring to fruition a strong creative vision like Hakita's has been an absolute honor and an unforgettable experience. I will remain forever grateful for the opportunity, and I look forward to whatever might come next!\"")]
    public string museum_bookQATeamQuote4;
    [DefaultValue("\"I couldn't have possibly predicted what this project would become. Its truly insane just how many people its reached and impacted their lives in a positive way. It'll definitely be a moment I remember for the rest of my life and it makes all the lost hours of sleep and mental damage from those long nights worth it. And besides I'm sure it'll grow back. I Hope.\"")]
    public string museum_bookQATeamQuote5;
    [DefaultValue("<color=#6153AB>HAZELUFF</color> - PROGRAMMER")]
    public string museum_bookHazeluff1;
    [DefaultValue("Hazeluff joined the team temporarily in late 2025 to help with the programming of the portal functionality for the Fraud layer. He was instrumental in porting over many of the enemies to work with portals, as well as creating various other backend systems to allow for a smoother portal experience.")]
    public string museum_bookHazeluff2;
    [DefaultValue("\"I just like the game. Thank you for including me.\"")]
    public string museum_bookHazeluff3;
    [DefaultValue("KENNADY RAY<color=white> - VOICE OF POWER</color>")]
    public string museum_bookPower1;
    [DefaultValue("Kennady joined the project in early 2026 to voice the Powers, the only non-boss enemy with spoken dialogue. Her energy and passion give them a depth of implied character that makes them feel much more alive and real than the writing by itself ever could have.")]
    public string museum_bookPower2;
    [DefaultValue("Shoutout to my handsome husband Dave and our new daughter Valerie! Pretty sure yelling these lines is what finally sent me into labor, so a big thank you to Hakita for helping me avoid an induction.")]
    public string museum_bookPower3;
    [DefaultValue("VYLET PONY<color=white> - GUEST COMPOSER</color>")]
    public string museum_bookVylet1;
    [DefaultValue("I'd been aware of Vylet's music for a few years, but it wasn't until 2024's Monarch of Monsters that I listened to it and was blown away by her versatility, intensity and sincerity as an artist, vocalist, producer and composer, so I was very happy to find out she was also a fan of ULTRAKILL.")]
    public string museum_bookVylet2;
    [DefaultValue("This abrasive, heavy rock style combined with her skills in a multitude of electronic and pop genres were the perfect fit for ULTRAKILL, which led to her creating a Cyber Grind original song, \"N I 4 N I\".")]
    public string museum_bookVylet3;
    [DefaultValue("Pony Music forever!")]
    public string museum_bookVylet4;
    [DefaultValue("\n\nAlso, you're all going to go crazy when Hakita drops the Darlene Prime fight.")]
    public string museum_bookVylet5;
    [DefaultValue("DOMENICO ANTONAZZO<color=white> - RIGGING</color>")]
    public string museum_bookAdditionalArt1;
    [DefaultValue("Dom took some time away from working on Gloomwood and his own game \"Scirocco Thugs\" in late 2025 to make the animation rigs for Providence and Geryon.")]
    public string museum_bookAdditionalArt2;
    [DefaultValue("Born str8 fukedd up, forced to tugg that shyt out............")]
    public string museum_bookAdditionalArt3;
    [DefaultValue("DAVID BONIN<color=white> - ADDITIONAL 3D MODELS</color>")]
    public string museum_bookAdditionalArt4;
    [DefaultValue("David took some time away from working on Fallen Aces in late 2025 to make additional environmental props for Layer 8: Fraud.")]
    public string museum_bookAdditionalArt5;
    [DefaultValue("I'll do it again")]
    public string museum_bookAdditionalArt6;
    [DefaultValue("RIPLEY VALENTINE<color=white> - ADDITIONAL 3D MODELS</color>")]
    public string museum_bookAdditionalArt7;
    [DefaultValue("Ripley picked up 3D modeling in early 2025 and made additional environmental props for Layer 8: Fraud.")]
    public string museum_bookAdditionalArt8;
    [DefaultValue("Please, I need your help. Crooked VICTORIA, wicked witch of ULTRAKILL, turned me into a prop artist. You need to kill me.")]
    public string museum_bookAdditionalArt9;
    [DefaultValue("AARON BURZYNSKI")]
    public string museum_plaquesAaronBurzynski1;
    [DefaultValue("QUALITY ASSURANCE")]
    public string museum_plaquesAaronBurzynski2;
    [DefaultValue("KENNADY RAY")]
    public string museum_plaquesKennadyRay1;
    [DefaultValue("VOICE OF POWER")]
    public string museum_plaquesKennadyRay2;
    [DefaultValue("VYLET PONY")]
    public string museum_plaquesVyletPony1;
    [DefaultValue("GUEST COMPOSER")]
    public string museum_plaquesVyletPony2;
    [DefaultValue("ADDITIONAL ART")]
    public string museum_plaquesAdditionalArt;

}

public class Misc
{
    public Dictionary<string, Dictionary<string, string>> teleportLevels;

    [DefaultValue("CAN'T PUNCH IF YOU HAVE NO ARM EQUIPPED, DUMBASS")]
    public string hud_noArm1;
    [DefaultValue("Arms can be re-equiped at the shop")]
    public string hud_noArm2;
    [DefaultValue("MAJOR ASSISTS ARE ENABLED.")]
    public string hud_majorAssists;
    [DefaultValue("<color=red>RED SOUL ORBS</color> give <color=green>200 HEALTH</color>.")]
    public string hud_overhealOrb1;
    [DefaultValue("Overheal cannot be regained with blood.")]
    public string hud_overhealOrb2;
    [DefaultValue("ERROR: BLOCKING DOOR WOULD CLOSE")]
    public string hud_itemGrabError;
    [DefaultValue("Hold TAB to view current stats when REPLAYING a level.")]
    public string hud_levelStats1;
    [DefaultValue("DOUBLE TAP to keep open.")]
    public string hud_levelStats2;
    [DefaultValue("Whoops, sorry about that.")]
    public string hud_outOfBounds;
    [DefaultValue("<color=orange>CLASH MODE</color> CHEAT UNLOCKED")]
    public string hud_clashMode;
    [DefaultValue("<color=orange>DRONE HAUNTING</color> CHEAT UNLOCKED")]
    public string hud_droneHaunting;
    [DefaultValue("Cycle through <color=orange>EQUIPPED</color> weapon variations with")]
    public string hud_weaponVariation;
    [DefaultValue("<color=orange>ALTERNATE</color> versions will change a weapon's base behavior.\nThey can be equipped at the <color=orange>SHOP</color>.")]
    public string hud_alternateVersion;

    [DefaultValue("SANDBOX TOOLS :^)")]
    public string spawner_sandboxTools;
    [DefaultValue("SANDBOX")]
    public string spawner_sandbox;
    [DefaultValue("ENEMIES")]
    public string spawner_enemies;
    [DefaultValue("OBJETS")]
    public string spawner_items;
    [DefaultValue("SPECIAL")]
    public string spawner_special;
    [DefaultValue("UNLOCKABLES")]
    public string spawner_unlockables;

    [DefaultValue("TIME:")]
    public string stats_time;
    [DefaultValue("KILLS:")]
    public string stats_kills;
    [DefaultValue("STYLE:")]
    public string stats_style;
    [DefaultValue("SECRETS:")]
    public string stats_secrets;
    [DefaultValue("CHALLENGE:")]
    public string stats_challenge;

    [DefaultValue("PRELUDE")]
    public string hellmap_prelude;
    [DefaultValue("LIMBO")]
    public string hellmap_limbo;
    [DefaultValue("LUST")]
    public string hellmap_lust;
    [DefaultValue("GLUTTONY")]
    public string hellmap_gluttony;
    [DefaultValue("GREED")]
    public string hellmap_greed;
    [DefaultValue("WRATH")]
    public string hellmap_wrath;
    [DefaultValue("HERESY")]
    public string hellmap_heresy;
    [DefaultValue("VIOLENCE")]
    public string hellmap_violence;
    [DefaultValue("FRAUD")]
    public string hellmap_fraud;
    [DefaultValue("TREACHERY")]
    public string hellmap_treachery;
    [DefaultValue("PRIME")]
    public string hellmap_prime;

    [DefaultValue("FIRST")]
    public string hellmap_first;
    [DefaultValue("SECOND")]
    public string hellmap_second;
    [DefaultValue("THIRD")]
    public string hellmap_third;
    [DefaultValue("FOURTH")]
    public string hellmap_fourth;
    [DefaultValue("CLIMAX")]
    public string hellmap_climax;
    [DefaultValue("ACT I CRESCENDO")]
    public string hellmap_act1crescendo;
    [DefaultValue("ACT I CLIMAX")]
    public string hellmap_act1climax;
    [DefaultValue("ACT II CRESCENDO")]
    public string hellmap_act2crescendo;
    [DefaultValue("ACT II CLIMAX")]
    public string hellmap_act2climax;
    [DefaultValue("ACT III CRESCENDO")]
    public string hellmap_act3crescendo;
    [DefaultValue("ACT III CLIMAX")]
    public string hellmap_act3climax;

    [DefaultValue("LOADING")]
    public string loading;

    [DefaultValue("TIME:")]
    public string levelstats_time;
    [DefaultValue("KILLS:")]
    public string levelstats_kills;
    [DefaultValue("STYLE:")]
    public string levelstats_style;
    [DefaultValue("CHALLENGE")]
    public string levelstats_challenge;
    [DefaultValue("SECRET:")]
    public string levelstats_secrets;
    [DefaultValue("MAJOR ASSISTS:")]
    public string levelstats_majorAssists;
    [DefaultValue("CRATES:")]
    public string levelstats_boxes;

    [DefaultValue("ACTIVE")]
    public string state_activated;
    [DefaultValue("INACTIVE")]
    public string state_deactivated;
    [DefaultValue("YES")]
    public string state_yes;
    [DefaultValue("NO")]
    public string state_no;

    [DefaultValue("Left click")]
    public string controls_leftClick;
    [DefaultValue("Middle click")]
    public string controls_middleClick;
    [DefaultValue("Right click")]
    public string controls_rightClick;

    [DefaultValue("CHEATS USED")]
    public string endstats_cheatsUsed;
    [DefaultValue("MAJOR ASSISTS USED")]
    public string endstats_assistsUsed;
    [DefaultValue("NO RESTARTS")]
    public string endstats_noRestarts;
    [DefaultValue("RESTARTS")]
    public string endstats_restarts;
    [DefaultValue("NO DAMAGE")]
    public string endstats_noDamage;

    [DefaultValue("Not Available")]
    public string weapons_unavailable;
    [DefaultValue("Already Owned")]
    public string weapons_alreadyBought;
    [DefaultValue("Under Construction")]
    public string weapons_underConstruction;

    [DefaultValue("Press <color=orange>ESC</color> to skip")]
    public string pressToSkip;

    [DefaultValue("[YOU ARE DEAD]")]
    public string youDied1;
    [DefaultValue("Press [R] TO RESTART")]
    public string youDied2;
    [DefaultValue("<color=orange>WARNING: EXTREME DAMAGE DETECTED.\nRUNNING DIAGNOSTIC</color>\nERROR: ARM MODULE #1 NOT RESPONDING\nERROR: ARM MODULE #2 NOT RESPONDING\n<color=orange>WARNING: COMBAT SYSTEMS INOPERABLE\nATTEMPTING RECONSTRUCTION</color>\nERROR: SELF-REPAIR NEXUS NOT RESPONDING\nINSUFFICIENT BLOOD.\nINSUFFICIENT BLOOD.\n<color=orange>INITIATING ESCAPE PROTOCOL\nATTEMPTING CONNECTION WITH LIMBIC MODULES</color>\nERROR: LEG MODULE #1 NOT RESPONDING\nERROR: LEG MODULE #2 NOT RESPONDING\n<color=orange>WARNING: UNABLE TO SUSTAIN MOTOR FUNCTIONS</color>\nERROR: VISUAL CORTEX MALFUNCTION\nERROR: LIMBIC FUNCTION NOT RESPONDING\nINSUFFICIENT BLOOD.\nINSUFFICIENT BLOOD.\n<color=orange>WARNING: UNABLE TO SUSTAIN INTERNAL ORGANS</color>\n! PULSE FAILURE !\n! PULSE FAILURE !\n! PULSE FAILURE !\n-!- SHUTDOWN IMMINENT -!-\nERROR: NO VOCAL INTERFACE DETECTED, UNABLE TO COMPLETE TASK\n! PULSE FAILURE !\n! PULSE FAILURE !\nINSUFFICIENT BLOOD.\nINSUFFICIENT BLOOD.\n<color=orange>WARNING: UNABLE TO SUSTAIN BASIC FUNCTIONS</color>\n-!- SHUTDOWN IMMINENT -!-\n-!- SHUTDOWN IMMINENT -!-\nI DON'T WANT TO DIE.\nI DON'T WANT TO DIE.\nI DON'T WANT TO DIE.\nI DON'T WANT TO DIE.\nI DON'T WANT TO DIE.\nI DON'T WANT TO DIE.")]
    public string DeathSequence;
    [DefaultValue("You have found a <color=orange>SECRET MISSION</color>.")]
    public string secretMissionFound;
    [DefaultValue("HEALTH")]
    public string classicHud_health;
    [DefaultValue("WEAPON")]
    public string classicHud_weapon;
    [DefaultValue("STAMINA")]
    public string classicHud_stamina;
    [DefaultValue("ARM")]
    public string classicHud_arm;
    [DefaultValue("CHARGE")]
    public string classicHud_railcannonMeter;
    [DefaultValue("SPEED")]
    public string classicHud_speed;
    [DefaultValue("u/s")]
    public string classicHud_speed_u;
    [DefaultValue("hu/s")]
    public string classicHud_speed_hu;
    [DefaultValue("vu/s")]
    public string classicHud_speed_vu;

    [DefaultValue("ALTER")]
    public string enemyAlter_title;
    [DefaultValue("SIZE")]
    public string enemyAlter_sizeTitle;
    [DefaultValue("UNIFORM")]
    public string enemyAlter_uniformToggle;
    [DefaultValue("SMALLER")]
    public string enemyAlter_uniformSmall;
    [DefaultValue("DEFAULT")]
    public string enemyAlter_uniformDefault;
    [DefaultValue("BIGGER")]
    public string enemyAlter_uniformLarge;
    [DefaultValue("PROP")]
    public string enemyAlter_metaTitle;
    [DefaultValue("FROZEN")]
    public string enemyAlter_metaFrozen;
    [DefaultValue("DISALLOW MANIPULATION")]
    public string enemyAlter_metaDisallowManipulation;
    [DefaultValue("DISALLOW FREEZING")]
    public string enemyAlter_metaDisallowFreezing;
    [DefaultValue("BREAKABLE")]
    public string enemyAlter_metaBreakable;
    [DefaultValue("UNBREAKABLE")]
    public string enemyAlter_metaUnbreakable;
    [DefaultValue("WEAK")]
    public string enemyAlter_metaWeak;
    [DefaultValue("JUMP PAD")]
    public string enemyAlter_jumpPadTitle;
    [DefaultValue("HOOK POINT")]
    public string enemyAlter_hookPointTitle;
    [DefaultValue("FORCE")]
    public string enemyAlter_power;
    [DefaultValue("RADIANCE")]
    public string enemyAlter_radianceTitle;
    [DefaultValue("ENABLE RADIANCE")]
    public string enemyAlter_radianceEnable;
    [DefaultValue("TIER")]
    public string enemyAlter_radianceDetails_tier;
    [DefaultValue("DAMAGE")]
    public string enemyAlter_radianceDamage_tier;
    [DefaultValue("HEALTH")]
    public string enemyAlter_radianceHealth_tier;
    [DefaultValue("SPEED")]
    public string enemyAlter_radianceSpeed_tier;
    [DefaultValue("ENEMY")]
    public string enemyAlter_boss_title;
    [DefaultValue("BOSS HEALTH BAR")]
    public string enemyAlter_boss_description;
    [DefaultValue("ENRAGED")]
    public string enemyAlter_enrage;
    [DefaultValue("ETERNAL RAGE")]
    public string enemyAlter_enrageEternal;
    [DefaultValue("SANDIFIED")]
    public string enemyAlter_sandified;
    [DefaultValue("PUPPETED")]
    public string enemyAlter_puppeted;
    [DefaultValue("IGNORE PLAYER")]
    public string enemyAlter_ignorePlayer;
    [DefaultValue("ATTACK ENEMIES")]
    public string enemyAlter_attackEnemies;
    [DefaultValue("SANDBOX")]
    public string enemyAlter_sandboxTitle;
    [DefaultValue("HAS SKULL")]
    public string enemyAlter_hasSkull;
    [DefaultValue("ALTAR TYPE")]
    public string enemyAlter_altarType;
    [DefaultValue("MATERIAL BLOCK")]
    public string enemyAlter_materialBlock;
    [DefaultValue("DUAL WIELD PICKUP")]
    public string enemyAlter_dualWieldPickup;
    [DefaultValue("INFINITE USES")]
    public string enemyAlter_infiniteUses;
    [DefaultValue("JUICE")]
    public string enemyAlter_juice;
    [DefaultValue("HURT ZONE")]
    public string enemyAlter_hurtZone;
    [DefaultValue("HURT COOLDOWN")]
    public string enemyAlter_hurtCooldown;
    [DefaultValue("BLUE")]
    public string enemyAlter_altarBlue;
    [DefaultValue("RED")]
    public string enemyAlter_altarRed;
    [DefaultValue("STONE")]
    public string enemyAlter_altarStone;
    [DefaultValue("Altered object was destroyed.")]
    public string enemyAlter_alteredDestroyed;
    [DefaultValue("This enemy cannot be un-puppeteered.")]
    public string enemyAlter_unpuppet;
    [DefaultValue("")]
    public string enemyAlter_unpuppetNon;

    [DefaultValue("THANKS FOR PLAYING")]
    public string earlyAccessEnd1;
    [DefaultValue("The final layer, TREACHERY, is currently still under development")]
    public string earlyAccessEnd2;
    [DefaultValue("For news on its progress, follow us on")]
    public string earlyAccessEnd3;

    [DefaultValue("<size=65>This game contains scenes\nof explicit violence and gore.</size>")]
    public string violenceScreenText1;
    [DefaultValue("<size=65>This game contains scenes\nof explicit <color=red>violence</color> and <color=red>gore</color>.</size>")]
    public string violenceScreenText2;
}

public class InputStrings
{
    [DefaultValue("Space")]
    public string input_space = "Space";
    [DefaultValue("Enter")]
    public string input_enter = "Enter";
    [DefaultValue("TAB")]
    public string input_tab = "TAB";
    [DefaultValue("Escape")]
    public string input_esc = "Escape";
    [DefaultValue("Left Shift")]
    public string input_leftShift = "Left Shift";
    [DefaultValue("Right Shift")]
    public string input_rightShift = "Right Shift";
    [DefaultValue("Left Control")]
    public string input_leftControl = "Left Control";
    [DefaultValue("Left Ctrl")]
    public string input_leftCtrl = "Left Ctrl";
    [DefaultValue("Right Control")]
    public string input_rightControl = "Right Control";
    [DefaultValue("Right Ctrl")]
    public string input_rightCtrl = "Right Ctrl";
    [DefaultValue("Left ALT")]
    public string input_leftAlt = "Left ALT";
    [DefaultValue("Right ALT")]
    public string input_rightAlt = "Right ALT";
    [DefaultValue("Left Bracket")]
    public string input_leftBracket = "Left Bracket";
    [DefaultValue("Right Bracket")]
    public string input_rightBracket = "Right Bracket";
    [DefaultValue("Left Meta")]
    public string input_leftMeta = "Left Meta";
    [DefaultValue("Right Meta")]
    public string input_rightMeta = "Right Meta";
    [DefaultValue("LMB")]
    public string input_LMB = "LMB";
    [DefaultValue("RMB")]
    public string input_RMB = "RMB";
    [DefaultValue("MMB")]
    public string input_MMB = "MMB";
    [DefaultValue("Mouse Button 4")]
    public string input_forward = "Mouse Button 4";
    [DefaultValue("Mouse Button 5")]
    public string input_back = "Mouse Button 5";
    [DefaultValue("Arrow Up")]
    public string input_arrowUp = "Arrow Up";
    [DefaultValue("Arrow Down")]
    public string input_arrowDown = "Arrow Down";
    [DefaultValue("Arrow Left")]
    public string input_arrowLeft = "Arrow Left";
    [DefaultValue("Arrow Right")]
    public string input_arrowRight = "Arrow Right";
    [DefaultValue("Numpad")]
    public string input_numpad = "Numpad";
    [DefaultValue("NumpadPeriod")]
    public string input_numpadPeriod = "NumpadPeriod";
    [DefaultValue("NumpadDivide")]
    public string input_numpadDivide = "NumpadDivide";
    [DefaultValue("NumpadMultiply")]
    public string input_numpadMultiply = "NumpadMultiply";
    [DefaultValue("NumpadMinus")]
    public string input_numpadMinus = "NumpadMinus";
    [DefaultValue("NumpadEnter")]
    public string input_numpadEnter = "NumpadEnter";
    [DefaultValue("NumpadPlus")]
    public string input_numpadPlus = "NumpadPlus";
    [DefaultValue("NumLock")]
    public string input_numLock = "NumLock";
    [DefaultValue("Comma")]
    public string input_comma = "Comma";
    [DefaultValue("CapsLock")]
    public string input_capsLock = "CapsLock";
    [DefaultValue("Slash")]
    public string input_slash = "Slash";
    [DefaultValue("Backslash")]
    public string input_backslash = "Backslash";
    [DefaultValue("Backspace")]
    public string input_backspace = "Backspace";
    [DefaultValue("Equals")]
    public string input_equals = "Equals";
    [DefaultValue("Minus")]
    public string input_minus = "Minus";
    [DefaultValue("Delete")]
    public string input_delete = "Delete";
    [DefaultValue("Period")]
    public string input_period = "Period";
    [DefaultValue("Semicolon")]
    public string input_semicolon = "Semicolon";
    [DefaultValue("Quote")]
    public string input_quote = "Quote";
    [DefaultValue("Insert")]
    public string input_insert = "Insert";
    [DefaultValue("PageUp")]
    public string input_pageUp = "PageUp";
    [DefaultValue("PageDown")]
    public string input_pageDown = "PageDown";
    [DefaultValue("Start")]
    public string input_start = "Start";
    [DefaultValue("End")]
    public string input_end = "End";
    [DefaultValue("Scroll Lock")]
    public string input_scrollLock = "Scroll Lock";
    [DefaultValue("Pause")]
    public string input_pause = "Pause";
    [DefaultValue("NO BINDING")]
    public string input_noBinding = "NO BINDING";
}
public class SandboxStrings
{
    [DefaultValue("NavMesh out of Date. Please rebuild.")]
    public string sandbox_navmeshWarn;

    [DefaultValue("Time of Day")]
    public string sandbox_shop_timeOfDay;
    [DefaultValue("World Options")]
    public string sandbox_shop_worldOptions;
    [DefaultValue("Icons")]
    public string sandbox_shop_icons;

    [DefaultValue("STATS")]
    public string sandbox_shop_stats;
    [DefaultValue("Total boxes built")]
    public string sandbox_shop_totalBoxes;
    [DefaultValue("Total props placed")]
    public string sandbox_shop_totalProps;
    [DefaultValue("Total enemies spawned")]
    public string sandbox_shop_totalEnemies;
    [DefaultValue("Total time in Sandbox")]
    public string sandbox_shop_totalTime;
    [DefaultValue("h")]
    public string sandbox_shop_totalTimeh;

    [DefaultValue("World Options")]
    public string sandbox_shop_worldOptionsTitle;
    [DefaultValue("Enable")]
    public string sandbox_shop_worldOptionsEnable;
    [DefaultValue("Disable")]
    public string sandbox_shop_worldOptionsDisable;
    [DefaultValue("Enabled")]
    public string sandbox_shop_worldOptionsEnabled;
    [DefaultValue("Disabled")]
    public string sandbox_shop_worldOptionsDisabled;

    [DefaultValue("Map Border")]
    public string sandbox_shop_mapBorder;

    [DefaultValue("Icon Packs")]
    public string sandbox_shop_iconsTitle;
    [DefaultValue("DEFAULT")]
    public string sandbox_shop_default;
    [DefaultValue("PITR")]
    public string sandbox_shop_pitr;
}

