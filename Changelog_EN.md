## 1.4.1
Fix:
- Fixed the compability with custom enemy's info page
- Fixed the font credits are placed in front of community cg pattern instead of after it
- Fixed the 5-S's fish terminal's back button are not localized
- Fixed a missing pause in intermission2 (6-2) between `fourth11` and `fourth12`
- Fixed certain texture will not replace by compression during static batching

New field:
- Add `shop.shop_returnToMissionReturn`
- Add `sandbox.sandbox_shop_close`
- Add `sandbox.sandbox_shop_loading`
- Add `secretLevels.secretLevels_fifth_leaderboard_global` and `secretLevels.secretLevels_fifth_leaderboard_friend` for localizing the fish leaderboards category title
- Add `tutorial.tutorial_introCalibrationExpired`, `tutorial.tutorial_introCalibrationNewCalibrationRequired` and `tutorial.tutorial_introCalibrationBeginningCalibration` for entering the tutorial first time


Behaviour change:
- Changed the linebreak in EnemyBios.Discription into two lines
- Add extra width to tmp in cybergrind terminal panel's title 
- Remove word wrap of difficulty title --DIFFICULTY-- to prevent some language may have extreme long to this
- Remove extra space of book's close prompt
- Remove the dep of the hard coded canvas so it's compatible with some custom levels with it's own canvas now
- Remove the IntroText's text replacement from IntroText patch to Tutorial's own patch so it's compatible with the UT meta custom level?
- Changed the guid and internal name of the mod

Angry:
- add bundleStatus.invalidLink
- add levelUpdateNotification.latestVersion/currentVersion/pastVersion and dateformat for translate level update notification's changelog, dateformat should be MM/dd/yyyy or yyyy/MM/dd or whatever
- add deleteBundleNotification for translate the delete bundle notification

## 1.4.0
- Fixed the MANADEL LEHAHIAN and CHAUAKIAH's subtitle not translated
- Fixed Gabriel Second's taunt13's subtitle are not translated
- Fixed the Minos's death scream are not translated
- Fixed 2-S, intermission1, intermission2's text wobbling
- Fixed 2-S's `UGH` are not translated cuz wrong string used for matching
- Fixed the assist conset panel's font size from 18 to 20
- Fixed the character P in result screen are not localized before the value of P get changes
- Fixed the insurrectionist's title in enemy info page are using the boss's name
- Fixed enemies name capitalization in option's COLOR page
- Fixed the intermission's skip button are not translated
- Fixed the 0-E's heat resistance and fixed heat are not translated
- Fixed the 1-E's warning text are not translated
- Fixed the StaticBatchingAtlasSwapper's matching will matching captured original texture to translated texture when reloaded the level multiple times
- Fixed the tutorial's audio slider min value could not translated
- Fixed the tutorial's calibration status could not translated

- Removed all hardcoded single quote mark in LevelString.cs (aka HUDMessage stuff)
- Removed extra hardcoded colon in cybergrind's waveboard

- Makes the enemy's name in option's color page to uppercase

- Corrected the mistyped string constant that was looking for `fs-tahoma-8px-v2 SDF` instead of `fs-tahoma-8px SDF v2`

- Add layout.json in (plugin)/fonts/(languageId) for UI Adapation
- Add fontconfig.json in (plugin)/fonts/(languageId) for selecting fonts freely
- Add turkey's font asset from UltraTurk(no)
- Add Spanish's font asset from UltraEspanish(?)
- Add layout.json in spanish for LevelStats's window and title drop

- Add ability to translate the AngryLevelLoader level's book/title/hudMessage/tipOfTheDay/name
- Add ability to translate the AngryLevelLoader's UI (not fully done yet)
- Add ability to translate the level's teleport points
- Add ability to translate the custom palettes (Official palette only)

json's field change:
- deprecated langHindusNumbers (idk about current wave)
- added misc.teleportLevels dict
- renamed shop_colorsAlternative to shop_colorsAlternate (I hate these bastard that always breaks compatibility by just a f typo)
- deleted Option.graphics_goreNote

- add fonts.UseFallback

- add Option.graphics_customColorPaletteGamebotColor;
- add Option.graphics_customColorPaletteNoir;
- add Option.graphics_customColorPalettePinkAndPurple;
- add Option.graphics_customColorPaletteRustic;
- add Option.graphics_customColorPaletteShake;
- add Option.graphics_customColorPaletteSinShitty;
- add Option.control_stats

- add Tutorial.tutorial_calibrationError
- add Tutorial.tutorial_calibrationOk;
- add Tutorial.tutorial_audioCalibrationConfirm
- add Tutorial.tutorial_audioCalibrationSliderOff

- add Act1.act1_lustSecond_feedbacker3;

- add LevelTips.levelTips_sandboxCheatCode

- remove act1_limboFourth_newArm
- add act1_limboFourth_newArm1 and act1_limboFourth_newArm2

- remove tutorial_introReminder;
- add tutorial_introReminder1 and tutorial_introReminder2;

- add fish_book11 because there's a f new sentence I HAVE TO SEE I HAVE TO KNOW that replaces fish_book9

## 1.3.1
- fixed forgot to hardcode the f assetbundle

## 1.3.0
- the sc font from purely dynamic atlas population to most of the glyph are using static and small set are added by dymanic, may have better performace than before

- add texture swap, supports StaticBatchingOptimizer
- add tested version of TMP font swap

- removed dubbing support for 2-s

## 1.2.0
- fixed the cybergrind music's display pos are not correct - issue by RewTwn
- fixed the fishing text doesn't have shadow / outline
- fixed the fishing text's font size are not correct
- fixed the fishing text doesn't have open animation
- fixed (?) the fishing text of fish caught not have line break when needed

1.1.0
- replace the fallback font used for VCROSD from Vonwaon Bitmap to WenQuanYi Bitmap Song 12px
- change the render mode of WenQuanYi Bitmap Song's 12px and 16px font to SDFAA_HINTED
- add 10 baseline to font Fusion-Pixel bassline drop(
- fixed the level select panel's result rank's anchor are set to buttom
- fixed 3-2 and 6-2's intermission's some text doesn't have shadow
- LanguageManager Rework(?) for compability of other language so there's tons of breaking change in future

## 1.0.2
- fixed the MirrorReaper and Providence missing one strategy
- fixed the Power's subtitle doesn't translate (but it's intended in 1.0.1 so i guess it cannot be count as fix)
- fixed certain style with rich text of colors but doesn't have the translation will be seen as with translation cause some bs like `+  x2` in styleHud

## 1.0.1
- fixed certain style doesn't translate, why f some style bonus doesn't using the dict?

