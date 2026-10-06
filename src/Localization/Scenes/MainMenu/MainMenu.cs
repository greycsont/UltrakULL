using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;
using System.Data;
using System.Threading.Tasks;

using static UltrakULL.json.LanguageManager;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class MainMenu
{
	//Patches all text strings in the title menu.
	private static void PatchMainMenu(GameObject mainMenu)
	{
		GameObject titleObject = FindDescendant(mainMenu, "Main Menu (1)", "LeftSide");

		//Early access tag
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_earlyAccess, path: ["Text (3)", "Text"]);

		//Early access tag background
		titleObject.Localize<TextMeshProUGUI>("<mark=#000000>{0}".FormatWith(CurrentLanguage.frontend.mainmenu_earlyAccess), path: ["Text (3)"]);

		//V1 initialization
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_v1Init, path: ["Text (2)", "Text (1)"]);

		//V1 initialization background
		titleObject.Localize<TextMeshProUGUI>("<mark=#000000>{0}".FormatWith(CurrentLanguage.frontend.mainmenu_v1Init), path: ["Text (2)"]);

		//Init socials
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_initSocials, path: ["Panel", "Text (2)", "Text"]);

		//Init socials background
		titleObject.Localize<TextMeshProUGUI>("<mark=#000000>{0}".FormatWith(CurrentLanguage.frontend.mainmenu_initSocials), path: ["Panel", "Text (2)"]);

		//Halloween
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_halloween, path: ["Holiday Greetings", "Text (Halloween)"]);

		//Easter
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_easter, path: ["Holiday Greetings", "Text (Easter)"]);

		//Christmas
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_christmas, path: ["Holiday Greetings", "Text (Christmas)"]);

		//Play button
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_play, path: ["Continue", "Text"]);

		//Options button
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_options, path: ["Options", "Text"]);

		//Credits button
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_credits, path: ["Credits", "Text"]);

		//Quit button
		titleObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.mainmenu_quit, path: ["Quit", "Text"]);
	}

	private static void PatchPopUps(GameObject mainMenu)
	{
		//About Encore title
		mainMenu.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.aboutEncoreTitle, path: ["EncorePopUp (1)", "Image", "Text (TMP) (1)"]);

		//About Encore main text
		mainMenu.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.aboutEncoreMain, path: ["EncorePopUp (1)", "Image", "Text (TMP)"]);

		//About Encore button
		mainMenu.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.aboutEncoreButton, path: ["EncorePopUp (1)", "Image", "General (1)", "Text"]);

		//Encore available main text
		mainMenu.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.encoreAvailableMainText, path: ["EncorePopUp", "Image", "Text (TMP)"]);

		//Encore available button
		mainMenu.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.encoreAvailableButton, path: ["EncorePopUp", "Image", "General (1)", "Text"]);
	}

	//Patches all text strings in the difficulty selection menu.
	private static void PatchDifficultyMenu(GameObject frontEnd)
	{
		GameObject difficultyObject = FindDescendant(frontEnd, "Difficulty Select (1)", "Interactables");

		//Difficulty header text (note: this can't fit much without reducing the default font size.)
		difficultyObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.difficulty_title), path: ["Title"]);

		//Easy header text
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_easy, path: ["Easy"]);

		//Normal header text
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_normal, path: ["Normal"]);

		//Hard header text
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_hard, path: ["Hard"]);

		//Harmless header
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_harmless, path: ["Casual Easy", "Name"]);

		//Lenient header
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_lenient, path: ["Casual Hard", "Name"]);

		//Standard header
		difficultyObject.Localize<TextMeshProUGUI>("{0} <color=orange>*</color>".FormatWith(CurrentLanguage.frontend.difficulty_standard), path: ["Standard", "Name"]);

		//Violent header
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_violent, path: ["Violent", "Name"]);

		//Brutal header
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_brutal, path: ["Brutal", "Name"]);

		//UKMD header
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_umd, path: ["V1 Must Die", "Name"]);

		//UKMD under construction
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_underConstruction, path: ["V1 Must Die", "Under Construction"]);

		//Tooltip
		difficultyObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.difficulty_tweakReminder, path: ["Assist Tip"]);
	}

//Same as above.
	private static void PatchDifficultyDescriptors(GameObject frontEnd)
	{
		GameObject difficultyObject = FindDescendant(frontEnd, "Difficulty Select (1)", "Interactables");

		//Harmless title
		difficultyObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.difficulty_harmless), path: ["Harmless Info", "Title (1)"]);

		//Harmless descriptor
		difficultyObject.Localize<TextMeshProUGUI>("{0}\n\n{1}\n\n<color=green>{2}</color>".FormatWith(
			CurrentLanguage.frontend.difficulty_harmlessDescription1,
			CurrentLanguage.frontend.difficulty_harmlessDescription2,
			CurrentLanguage.frontend.difficulty_harmlessDescription3), path: ["Harmless Info", "Text"]);

		//Lenient title
		difficultyObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.difficulty_lenient), path: ["Lenient Info", "Title (1)"]);

		//Lenient descriptor
		difficultyObject.Localize<TextMeshProUGUI>("{0}\n\n{1}\n\n<color=yellow>{2}</color>".FormatWith(
			CurrentLanguage.frontend.difficulty_lenientDescription1,
			CurrentLanguage.frontend.difficulty_lenientDescription2,
			CurrentLanguage.frontend.difficulty_lenientDescription3), path: ["Lenient Info", "Text"]);

		//Standard title
		difficultyObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.difficulty_standard), path: ["Standard Info", "Title (1)"]);

		//Standard descriptor
		difficultyObject.Localize<TextMeshProUGUI>("{0}\n\n{1}\n\n<color=orange>{2}</color>".FormatWith(
			CurrentLanguage.frontend.difficulty_standardDescription1,
			CurrentLanguage.frontend.difficulty_standardDescription2,
			CurrentLanguage.frontend.difficulty_standardDescription3), path: ["Standard Info", "Text"]);

		//Violent title
		difficultyObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.difficulty_violent), path: ["Violent Info", "Title (1)"]);

		//Violent descriptor
		difficultyObject.Localize<TextMeshProUGUI>("{0}\n\n{1}\n\n<color=red>{2}</color>".FormatWith(
			CurrentLanguage.frontend.difficulty_violentDescription1,
			CurrentLanguage.frontend.difficulty_violentDescription2,
			CurrentLanguage.frontend.difficulty_violentDescription3), path: ["Violent Info", "Text"]);

		//Brutal title
		difficultyObject.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.difficulty_brutal), path: ["Brutal Info", "Title (1)"]);

		//Brutal descriptor
		difficultyObject.Localize<TextMeshProUGUI>("<color=white>{0}\n\n{1}</color>\n\n<b>{2}<b>".FormatWith(
			CurrentLanguage.frontend.difficulty_brutalDescription1,
			CurrentLanguage.frontend.difficulty_brutalDescription2,
			CurrentLanguage.frontend.difficulty_brutalDescription3), path: ["Brutal Info", "Text"]);
		//UMD stuff isn't in-game yet so the below is commmented out until the devs add them.

		/*UMD title - not in-game yet
			GameObject umdObject = FindDescendant(difficultyObject, "UMD Info");
		TextMeshProUGUI umdTitle = GetTextMeshProUGUI(umdObject.transform.Find("Title (1)").gameObject);
			umdTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

		//UMD descriptor - not in-game yet
		TextMeshProUGUI brutalDescriptor = GetTextMeshProUGUI(umdObject.transform.Find("Text").gameObject);
			umdDescriptor.text = 
				LanguageManager.CurrentLanguage.frontend.difficulty_umdDescription1
				+ "\n\n"
				+ LanguageManager.CurrentLanguage.frontend.difficulty_umdDescription2
				+ "\n\n"
				+ "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_umdDescription3 + "</color>";
			*/
	}

	private static void PatchChapterSelect(GameObject frontEnd)
	{
		GameObject chapterObject = FindDescendant(frontEnd, "Chapter Select", "Chapters");

		//Chapter select title
		frontEnd.Localize<TextMeshProUGUI>("--{0}--".FormatWith(CurrentLanguage.frontend.chapter_title), path: ["Chapter Select", "Title (1)"]);

		//Primary chapters type title
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_type_primary, path: ["Primary", "Title"]);

		//Secondary chapters type title
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_type_secondary, path: ["Secondary", "Title"]);

		//Prelude
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_prelude, path: ["Prelude", "Name"]);

		//Act I
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_act1, path: ["Act I", "Name"]);
		GameObject act1Object = FindDescendant(chapterObject, "Act I");
		var act1MenuActSelect = act1Object.GetComponent<MenuActSelect>();
		act1MenuActSelect.nameWhenDisabled = CurrentLanguage.frontend.chapter_act1_lock.Or(act1MenuActSelect.nameWhenDisabled);

		//Act II
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_act2, path: ["Act II", "Name"]);
		GameObject act2Object = FindDescendant(chapterObject, "Act II");
		var act2MenuActSelect = act2Object.GetComponent<MenuActSelect>();
		act2MenuActSelect.nameWhenDisabled = CurrentLanguage.frontend.chapter_act2_lock.Or(act2MenuActSelect.nameWhenDisabled);

		//Act III
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_act3, path: ["Act III", "Name"]);
		GameObject act3Object = FindDescendant(chapterObject, "Act III");
		var act3MenuActSelect = act3Object.GetComponent<MenuActSelect>();
		act3MenuActSelect.nameWhenDisabled = CurrentLanguage.frontend.chapter_act3_lock.Or(act3MenuActSelect.nameWhenDisabled);

		//Encore
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_encore, path: ["Encore", "Name"]);

		//Prime
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_prime, path: ["Prime", "Name"]);

		//The Cyber Grind
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_cyberGrind, path: ["The Cyber Grind", "Name"]);

		//Sandbox
		chapterObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_sandbox, path: ["Sandbox", "Name"]);
	}

	private static void PatchLevelSelectPrelude(GameObject frontEnd)
	{
		GameObject lsPreludeObject = FindDescendant(frontEnd, "Level Select (Prelude)");

		//Prelude title
		lsPreludeObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_prelude, path: ["Overture", "Header", "Text"]).fontSize = 36;

		//Prelude secret mission title
		lsPreludeObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Overture", "Header", "Secret Mission", "Text"]);

		//0-1 challenge
		lsPreludeObject.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 0-1"), path: ["Overture", "Level Row", "0-1 Panel", "Panel", "Text"]);

		//0-2 challenge
		lsPreludeObject.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 0-2"), path: ["Overture", "Level Row", "0-2 Panel", "Panel (2)", "Text"]);

		//0-3 challenge
		lsPreludeObject.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 0-3"), path: ["Overture", "Level Row", "0-3 Panel", "Panel (4)", "Text"]);

		//0-4 challenge
		lsPreludeObject.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 0-4"), path: ["Overture", "Level Row", "0-4 Panel", "Panel (6)", "Text"]);

		//0-5 challenge
		lsPreludeObject.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 0-5"), path: ["Overture", "Level Row", "0-5 Panel", "Panel (6)", "Text"]);

		//Full intro text (this one is not using TMP)
		lsPreludeObject.Localize<Text>(CurrentLanguage.frontend.level_fullIntroPrompt, path: ["FullIntroPopup", "Panel", "Text"]);

		//Full intro yes button
		lsPreludeObject.Localize<Text>(CurrentLanguage.frontend.level_fullIntroPromptYes, path: ["FullIntroPopup", "Panel", "Button (1)", "Text"]);

		//Full intro no button
		lsPreludeObject.Localize<Text>(CurrentLanguage.frontend.level_fullIntroPromptNo, path: ["FullIntroPopup", "Panel", "Button", "Text"]);

		//Full intro cancel button
		lsPreludeObject.Localize<Text>(CurrentLanguage.frontend.level_fullIntroPromptCancel, path: ["FullIntroPopup", "Panel", "Button (2)", "Text"]);
	}

	//Patches all text strings in the Act 1 menu.
	private static void PatchLevelSelectAct1(GameObject frontEnd)
	{
		GameObject act1Object = FindDescendant(frontEnd, "Level Select (Act I)", "Scroll Rect", "Contents");

		//Layer 1 - Limbo title
		act1Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_limbo, path: ["Layer 1 Limbo", "Header", "Text"]);

		//Layer 1 - Limbo secret mission
		act1Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Layer 1 Limbo", "Header", "Secret Mission", "Text"]);

		//1-1 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 1-1"), path: ["Layer 1 Limbo", "Level Row", "1-1 Panel", "Panel", "Text"]);

		//1-2 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 1-2"), path: ["Layer 1 Limbo", "Level Row", "1-2 Panel", "Panel (2)", "Text"]);

		//1-3 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 1-3"), path: ["Layer 1 Limbo", "Level Row", "1-3 Panel", "Panel (4)", "Text"]);

		//1-4 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 1-4"), path: ["Layer 1 Limbo", "Level Row", "1-4 Panel", "Panel (6)", "Text"]);

		//Layer 2 - Lust title
		act1Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_lust, path: ["Layer 2 Lust", "Header", "Text"]);

		//Layer 2 - Lust secret mission
		act1Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Layer 2 Lust", "Header", "Secret Mission", "Text"]);

		//2-1 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 2-1"), path: ["Layer 2 Lust", "Level Row", "2-1 Panel", "Panel", "Text"]);

		//2-2 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 2-2"), path: ["Layer 2 Lust", "Level Row", "2-2 Panel", "Panel (2)", "Text"]);

		//2-3 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 2-3"), path: ["Layer 2 Lust", "Level Row", "2-3 Panel", "Panel (4)", "Text"]);

		//2-4 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 2-4"), path: ["Layer 2 Lust", "Level Row", "2-4 Panel", "Panel (6)", "Text"]);

		//Layer 3 - Gluttony title
		act1Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_gluttony, path: ["Layer 3 Gluttony", "Header", "Text"]);

		//3-1 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 3-1"), path: ["Layer 3 Gluttony", "Level Row", "3-1 Panel", "Panel", "Text"]);

		//3-2 challenge
		act1Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 3-2"), path: ["Layer 3 Gluttony", "Level Row", "3-2 Panel", "Panel (2)", "Text"]);
	}

	private static void PatchLevelSelectAct2(GameObject frontEnd)
	{
		GameObject act2Object = FindDescendant(frontEnd, "Level Select (Act II)", "Scroll Rect", "Contents");

		//Layer 4 - Greed title
		act2Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_greed, path: ["Layer 4 Greed", "Header", "Text"]);

		//Layer 4 - Greed secret mission
		act2Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Layer 4 Greed", "Header", "Secret Mission", "Text"]);

		//4-1 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 4-1"), path: ["Layer 4 Greed", "Level Row", "4-1 Panel", "Panel", "Text"]);

		//4-2 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 4-2"), path: ["Layer 4 Greed", "Level Row", "4-2 Panel", "Panel (2)", "Text"]);

		//4-3 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 4-3"), path: ["Layer 4 Greed", "Level Row", "4-3 Panel", "Panel (4)", "Text"]);

		//4-4 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 4-4"), path: ["Layer 4 Greed", "Level Row", "4-4 Panel", "Panel (6)", "Text"]);

		//Layer 5 - Wrath title
		act2Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_wrath, path: ["Layer 5 Wrath", "Header", "Text"]);

		//Layer 5 - Wrath secret mission
		act2Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Layer 5 Wrath", "Header", "Secret Mission", "Text"]);

		//5-1 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 5-1"), path: ["Layer 5 Wrath", "Level Row", "5-1 Panel", "Panel", "Text"]);

		//5-2 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 5-2"), path: ["Layer 5 Wrath", "Level Row", "5-2 Panel", "Panel (2)", "Text"]);

		//5-3 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 5-3"), path: ["Layer 5 Wrath", "Level Row", "5-3 Panel", "Panel (4)", "Text"]);

		//5-4 challenge
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 5-4"), path: ["Layer 5 Wrath", "Level Row", "5-4 Panel", "Panel (6)", "Text"]);

		//Layer 6 - Heresy title
		act2Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_heresy, path: ["Layer 6 Heresy", "Header", "Text"]);

		//6-1 challenge (YES IT'S THE 1-1 PANEL)
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 6-1"), path: ["Layer 6 Heresy", "Level Row", "1-1 Panel", "Panel", "Text"]);

		//6-2 challenge (YES IT'S THE 1-2 PANEL)
		act2Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 6-2"), path: ["Layer 6 Heresy", "Level Row", "1-2 Panel", "Panel (2)", "Text"]);
	}

	private static void PatchLevelSelectAct3(GameObject frontEnd)
	{
		GameObject act3Object = FindDescendant(frontEnd, "Level Select (Act III)", "Scroll Rect", "Contents");

		//Layer 7 - Violence title
		act3Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_violence, path: ["Layer 7 Violence", "Header", "Text"]);

		//Layer 7 - Violence secret mission
		act3Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Layer 7 Violence", "Header", "Secret Mission", "Text"]);

		//7-1 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 7-1"), path: ["Layer 7 Violence", "Level Row", "7-1 Panel", "Panel", "Text"]);

		//7-2 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 7-2"), path: ["Layer 7 Violence", "Level Row", "7-2 Panel", "Panel (2)", "Text"]);

		//7-3 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 7-3"), path: ["Layer 7 Violence", "Level Row", "7-3 Panel", "Panel (4)", "Text"]);

		//7-4 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 7-4"), path: ["Layer 7 Violence", "Level Row", "7-4 Panel", "Panel (6)", "Text"]);

		//Layer 8 - Fraud title
		act3Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_fraud, path: ["Layer 8 Fraud", "Header", "Text"]);

		//Layer 8 - Fraud secret mission
		act3Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_secretMission, path: ["Layer 8 Fraud", "Header", "Secret Mission", "Text"]);

		//8-1 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 8-1"), path: ["Layer 8 Fraud", "Level Row", "8-1 Panel", "Panel", "Text"]);

		//8-2 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 8-2"), path: ["Layer 8 Fraud", "Level Row", "8-2 Panel", "Panel (2)", "Text"]);

		//8-3 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 8-3"), path: ["Layer 8 Fraud", "Level Row", "8-3 Panel", "Panel (4)", "Text"]);

		//8-4 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 8-4"), path: ["Layer 8 Fraud", "Level Row", "8-4 Panel", "Panel (6)", "Text"]);

		//Layer 9 - Treachery title
		act3Object.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_treachery, path: ["Layer 9 Treachery", "Header", "Text"]);

		//9-1 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 9-1"), path: ["Layer 9 Treachery", "Level Row", "9-1 Panel", "Panel", "Text"]);

		//9-2 challenge
		act3Object.Localize<TextMeshProUGUI>(LevelStrings.GetLevelChallenge("Level 9-2"), path: ["Layer 9 Treachery", "Level Row", "9-2 Panel", "Panel (2)", "Text"]);
	}

	private static void PatchLevelSelectEncore(GameObject frontEnd)
	{
		GameObject lsEncoreObject = FindDescendant(frontEnd, "Level Select (Encore)", "Scroll Rect", "Contents");

		//Encore title
		lsEncoreObject.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.chapter_encore, path: ["Encores", "Header", "Text"]);
	}

	private static void PatchLevelSelectPrime(GameObject frontEnd)
	{
		//Prime layer title
		frontEnd.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.layer_prime, path: ["Level Select (Prime)", "Prime Sanctums", "Header", "Text"]);
	}

	private static void PatchTextArroundV1(GameObject mainMenu)
	{
		GameObject textV1 = FindDescendant(mainMenu, "Main Menu (1)", "BackgroundSwapper", "Text (TMP)", "V1Text");

		//Wing module
		textV1.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.wingModule, path: ["Text (TMP)"]);

		//Arm module - factory
		textV1.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.armModuleFactory, path: ["Text (TMP) (1)"]);

		//Arm module - feedbacker
		textV1.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.armModuleFeedbacker, path: ["Text (TMP) (2)"]);

		//Visual cortex module
		textV1.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.visualCortexModule, path: ["Text (TMP) (3)"]);

		//Leg module
		textV1.Localize<TextMeshProUGUI>(CurrentLanguage.frontend.legModule, path: ["Text (TMP) (4)"]);
	}

	public static void Patch(GameObject frontEnd)
	{
		// currently it's only used in this class, will implement it to other class in future
		SafeRun.Run("MainMenu: Main Menu", () => PatchMainMenu(frontEnd));
		SafeRun.Run("MainMenu: V1 text", () => PatchTextArroundV1(frontEnd));
		SafeRun.Run("MainMenu: Popups", () => PatchPopUps(frontEnd));
		SafeRun.Run("MainMenu: Difficulty menu", () => PatchDifficultyMenu(frontEnd));
		SafeRun.Run("MainMenu: Difficulty descriptors", () => PatchDifficultyDescriptors(frontEnd));
		SafeRun.Run("MainMenu: Chapter select", () => PatchChapterSelect(frontEnd));
		SafeRun.Run("MainMenu: Level select (Prelude)", () => PatchLevelSelectPrelude(frontEnd));
		SafeRun.Run("MainMenu: Level select (Act I)", () => PatchLevelSelectAct1(frontEnd));
		SafeRun.Run("MainMenu: Level select (Act II)", () => PatchLevelSelectAct2(frontEnd));
		SafeRun.Run("MainMenu: Level select (Act III)", () => PatchLevelSelectAct3(frontEnd));
		SafeRun.Run("MainMenu: Level select (Encore)", () => PatchLevelSelectEncore(frontEnd));
		SafeRun.Run("MainMenu: Level select (Prime)", () => PatchLevelSelectPrime(frontEnd));
	}

}
