using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;
using System.Data;
using System.Threading.Tasks;

namespace UltrakULL;

public static class MainMenu
{
	//Patches all text strings in the title menu.
	private static void PatchMainMenu(GameObject mainMenu)
	{
		try
		{
			GameObject titleObject = FindDescendant(mainMenu, "Main Menu (1)", "LeftSide");

			//Early access tag
			TextMeshProUGUI earlyAccessText = GetTextMeshProUGUI(FindDescendant(titleObject, "Text (3)", "Text"));
			earlyAccessText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_earlyAccess;
			TextMeshProUGUI earlyAccessBackground = GetTextMeshProUGUI(FindDescendant(titleObject, "Text (3)"));
			earlyAccessBackground.text = "<mark=#000000>" + LanguageManager.CurrentLanguage.frontend.mainmenu_earlyAccess;

			//V1 Initialization strings
			TextMeshProUGUI v1InitText = GetTextMeshProUGUI(FindDescendant(titleObject, "Text (2)", "Text (1)"));
			v1InitText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_v1Init;
			TextMeshProUGUI v1InitBackground = GetTextMeshProUGUI(FindDescendant(titleObject, "Text (2)")); // Yep. Background is a TMP too. 
			v1InitBackground.text = "<mark=#000000>" + LanguageManager.CurrentLanguage.frontend.mainmenu_v1Init;

			//Init Socials
			TextMeshProUGUI initSocialsText = GetTextMeshProUGUI(FindDescendant(titleObject, "Panel", "Text (2)", "Text"));
			initSocialsText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_initSocials;
			TextMeshProUGUI initSocialsBackground = GetTextMeshProUGUI(FindDescendant(titleObject, "Panel", "Text (2)")); // Yep. Background is a TMP too. 
			initSocialsBackground.text = "<mark=#000000>" + LanguageManager.CurrentLanguage.frontend.mainmenu_initSocials;

			GameObject holidayObject = FindDescendant(titleObject, "Holiday Greetings"); 
			//Halloween
			TextMeshProUGUI halloweenText = GetTextMeshProUGUI(FindDescendant(holidayObject, "Text (Halloween)"));
			halloweenText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_halloween;

			//Easter
			TextMeshProUGUI easterText = GetTextMeshProUGUI(FindDescendant(holidayObject, "Text (Easter)"));
			easterText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_easter;

			//Christmas
			TextMeshProUGUI christmasText = GetTextMeshProUGUI(FindDescendant(holidayObject, "Text (Christmas)"));
			christmasText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_christmas;

			//Play button
			TextMeshProUGUI playButtonText = GetTextMeshProUGUI(FindDescendant(titleObject, "Continue", "Text"));
			playButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_play;

			//Options button
			TextMeshProUGUI optionsButtontext = GetTextMeshProUGUI(FindDescendant(titleObject, "Options", "Text"));
			optionsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_options;

			//Credits button
			TextMeshProUGUI creditsButtontext = GetTextMeshProUGUI(FindDescendant(titleObject, "Credits", "Text"));
			creditsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_credits;

			//Quit button
			TextMeshProUGUI quitButtontext = GetTextMeshProUGUI(FindDescendant(titleObject, "Quit", "Text"));
			quitButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;
		}
		catch (Exception e)
		{
			Logging.Error("An error occured while patching main menu. Check the console for details.");
			Logging.Error(e.ToString());
		}
	}

	private static void PatchPopUps(GameObject mainMenu)
	{
		try
		{
			GameObject aboutEncoreObject = FindDescendant(FindDescendant(mainMenu, "EncorePopUp (1)"), "Image");

			//About Encore Title
			TextMeshProUGUI aboutEncoreTitleText = GetTextMeshProUGUI(FindDescendant(aboutEncoreObject, "Text (TMP) (1)"));
			if (LanguageManager.CurrentLanguage.frontend.aboutEncoreTitle != "")
			{
				aboutEncoreTitleText.text = LanguageManager.CurrentLanguage.frontend.aboutEncoreTitle;
			}
			else 
			{
			Logging.Warn("No aboutEncoreTitle text found in the language file. Using default: " + aboutEncoreTitleText.text);
			}
			//About Encore Main text
			TextMeshProUGUI aboutEncoreMainText = GetTextMeshProUGUI(FindDescendant(aboutEncoreObject, "Text (TMP)"));
			if (LanguageManager.CurrentLanguage.frontend.aboutEncoreMain != "")
			{
				aboutEncoreMainText.text = LanguageManager.CurrentLanguage.frontend.aboutEncoreMain;
			}
			else 
			{ 
				Logging.Warn("No aboutEncoreMain text found in the language file. Using default: " + aboutEncoreMainText.text); 
			}

			//About Encore Button //Umm, id dont know, need to translate "Ok" button, but... OK
			GameObject aboutEncoreButtonTextObject = FindDescendant(aboutEncoreObject, "General (1)", "Text");
			TextMeshProUGUI aboutEncoreButtonText = GetTextMeshProUGUI(aboutEncoreButtonTextObject);
			if (LanguageManager.CurrentLanguage.frontend.aboutEncoreButton != "")
			{
				aboutEncoreButtonText.text = LanguageManager.CurrentLanguage.frontend.aboutEncoreButton;
			}
			else
			{
				Logging.Warn("No aboutEncoreButton text found in the language file. Using default: " + aboutEncoreButtonText.text);
			}

			//Encore available PopUp
			GameObject encoreAvailableObject = FindDescendant(mainMenu, "EncorePopUp", "Image");

			//Encore available Main text
			TextMeshProUGUI encoreAvailableMainText = GetTextMeshProUGUI(FindDescendant(encoreAvailableObject, "Text (TMP)"));
			if (LanguageManager.CurrentLanguage.frontend.encoreAvailableMainText != "")
			{
				encoreAvailableMainText.text = LanguageManager.CurrentLanguage.frontend.encoreAvailableMainText;
			}
			else
			{
				Logging.Warn("No encoreAvailableMainText text found in the language file. Using default: " + encoreAvailableMainText.text);
			}

			//Encore available Button //Umm, id dont know, need to translate "Ok" button, but... OK
			GameObject encoreAvailableButtonTextObject = FindDescendant(encoreAvailableObject, "General (1)", "Text");
			TextMeshProUGUI encoreAvailableButtonText = GetTextMeshProUGUI(encoreAvailableButtonTextObject);
			if (LanguageManager.CurrentLanguage.frontend.encoreAvailableButton != "")
			{
				encoreAvailableButtonText.text = LanguageManager.CurrentLanguage.frontend.encoreAvailableButton;
			}
			else
			{
				Logging.Warn("No encoreAvailableButton text found in the language file. Using default: " + encoreAvailableButtonText.text);
			}

		}
		catch (Exception e)
		{
			Logging.Error("An error occured while patching PopUp's. Check the console for details.");
			Logging.Error(e.ToString());
		}
	}


/*public static void ChangeTitle(GameObject mainMenu) // This feature is currently disabled because there is a more global texture replacement feature (＞﹏＜)
	{
		try
		{
			Logging.Warn("Attempting to change the main menu's title image");
			GameObject trueMainMenu = FindDescendant(FindDescendant(mainMenu, "Main Menu (1)"), "LeftSide");
			GameObject titleObject = FindDescendant(trueMainMenu, "Title");
			GameObject titleObjectArabic = null;
			string currentLangName = LanguageManager.CurrentLanguage.metadata.langName;
			bool usingArabicLogo = false;

		if (currentLangName.Substring(currentLangName.Length - 2).ToUpper() == "AR" && Core.ArabicUltrakillLogo != null)
			{
				if (titleObjectArabic == null)
				{
					GameObject.Instantiate(titleObject, titleObject.transform.position, Quaternion.identity, trueMainMenu.transform);
				}
				titleObjectArabic = FindDescendant(trueMainMenu, "Title(Clone)");
				titleObjectArabic.GetComponent<Image>().sprite = Core.ArabicUltrakillLogo;
				usingArabicLogo = true;
			}
			else
			{
				usingArabicLogo = false;
		}
		if (titleObjectArabic != null)
		{
				if (usingArabicLogo)
				{
					trueMainMenu.GetComponent<ObjectActivateInSequence>().objectsToActivate[0] = titleObjectArabic;
				titleObject.SetActive(false);
					titleObjectArabic.SetActive(true);
				}
				else
			{
				trueMainMenu.GetComponent<ObjectActivateInSequence>().objectsToActivate[0] = titleObject;
				titleObject.SetActive(true);
					titleObjectArabic.SetActive(false);
				}
		}
	}
	catch (Exception e)
	{
		Logging.Error("An error occured while switching the title. Check the console for details.");
		Logging.Error(e.ToString());
	}
}*/

	//Patches all text strings in the difficulty selection menu.
	private static void PatchDifficultyMenu(GameObject frontEnd)
	{
		try
		{
			GameObject difficultyObject = FindDescendant(frontEnd, "Difficulty Select (1)","Interactables");

			//Difficulty header text (note: this can't fit much without reducing the default font size.)
			TextMeshProUGUI difficultyText = GetTextMeshProUGUI(difficultyObject.transform.Find("Title").gameObject);
			difficultyText.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_title + "--";

			//Easy header text
			GameObject easyObject = difficultyObject.transform.Find("Easy").gameObject;
			TextMeshProUGUI easyText = GetTextMeshProUGUI(easyObject);
			easyText.text =LanguageManager.CurrentLanguage.frontend.difficulty_easy;

			//Normal header text
			TextMeshProUGUI normalText = GetTextMeshProUGUI(difficultyObject.transform.Find("Normal").gameObject);
			normalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

			//Hard header text
			TextMeshProUGUI hardText = GetTextMeshProUGUI(difficultyObject.transform.Find("Hard").gameObject);
			hardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

			//Harmless header
			GameObject harmlessTextObject = FindDescendant(difficultyObject, "Casual Easy");
			TextMeshProUGUI harmlessText = GetTextMeshProUGUI(harmlessTextObject.transform.Find("Name").gameObject);
			harmlessText.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

			//Lenient header
			GameObject lenientTextObject = FindDescendant(difficultyObject, "Casual Hard");
			TextMeshProUGUI lenientText = GetTextMeshProUGUI(lenientTextObject.transform.Find("Name").gameObject);
			lenientText.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

			//Standard header
			GameObject standardTextObject = FindDescendant(difficultyObject, "Standard");
			TextMeshProUGUI standardText = GetTextMeshProUGUI(standardTextObject.transform.Find("Name").gameObject);
			standardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard + " <color=orange>*</color>";

			//Violent header
			GameObject violentTextObject = FindDescendant(difficultyObject, "Violent");
			TextMeshProUGUI violentText = GetTextMeshProUGUI(violentTextObject.transform.Find("Name").gameObject);
			violentText.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

			//Brutal header
			GameObject brutalTextObject = FindDescendant(difficultyObject, "Brutal");
			TextMeshProUGUI brutalText = GetTextMeshProUGUI(brutalTextObject.transform.Find("Name").gameObject);
			brutalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

			//UKMD header
			GameObject umdTextObject = FindDescendant(difficultyObject, "V1 Must Die");
			TextMeshProUGUI umdText = GetTextMeshProUGUI(umdTextObject.transform.Find("Name").gameObject);
			umdText.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

			TextMeshProUGUI underConstructionText = GetTextMeshProUGUI(FindDescendant(umdTextObject, "Under Construction"));
			underConstructionText.text = LanguageManager.CurrentLanguage.frontend.difficulty_underConstruction;


			//No need for UMD header yet as it's not in-game
			if (LanguageManager.IsRightToLeft)
			{
				RtlFixDifficultyButton(brutalTextObject, brutalText);
				RtlFixDifficultyButton(violentTextObject, violentText);
				RtlFixDifficultyButton(standardTextObject, standardText);
				RtlFixDifficultyButton(lenientTextObject, lenientText);
				RtlFixDifficultyButton(harmlessTextObject, harmlessText);
			}

			//Tooltip
			GameObject assistTip = FindDescendant(difficultyObject, "Assist Tip");
			TextMeshProUGUI assistTipText = GetTextMeshProUGUI(assistTip);
			assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
		}
		catch (Exception e)
		{
			Logging.Error("Failed to patch difficulty menu.");
			Logging.Error(e.ToString());
		}
	}

	//Same as above.
	private static void PatchDifficultyDescriptors(GameObject frontEnd)
	{
		try
		{
			GameObject difficultyObject = FindDescendant(frontEnd, "Difficulty Select (1)", "Interactables");

			//Harmless title
			GameObject harmlessObject = FindDescendant(difficultyObject, "Harmless Info");
			TextMeshProUGUI harmlessTitle = GetTextMeshProUGUI(harmlessObject.transform.Find("Title (1)").gameObject);
			harmlessTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_harmless + "--";

		//Harmless descriptor
			TextMeshProUGUI harmlessDescriptor = GetTextMeshProUGUI(harmlessObject.transform.Find("Text").gameObject);
			harmlessDescriptor.text =
				LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
				+ "\n\n"
				+ LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
				+ "\n\n"
				+ "<color=green>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

			//Lenient title
			GameObject lenientObject = FindDescendant(difficultyObject, "Lenient Info");
			TextMeshProUGUI lenientTitle = GetTextMeshProUGUI(lenientObject.transform.Find("Title (1)").gameObject);
			lenientTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_lenient + "--";

			//Lenient descriptor
			TextMeshProUGUI lenientDescriptor = GetTextMeshProUGUI(lenientObject.transform.Find("Text").gameObject);
			lenientDescriptor.text =
				LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
				+ "\n\n"
				+ LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
				+ "\n\n"
				+ "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

			//Standard title
			GameObject standardObject = FindDescendant(difficultyObject, "Standard Info");
			TextMeshProUGUI standardTitle = GetTextMeshProUGUI(standardObject.transform.Find("Title (1)").gameObject);
			standardTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_standard + "--";

			//Standard descriptor
			TextMeshProUGUI standardDescriptor = GetTextMeshProUGUI(standardObject.transform.Find("Text").gameObject);
			standardDescriptor.text =
				LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
				+ "\n\n"
				+ LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
				+ "\n\n"
				+ "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

			//Violent title
			GameObject violentObject = FindDescendant(difficultyObject, "Violent Info");
			TextMeshProUGUI violentTitle = GetTextMeshProUGUI(violentObject.transform.Find("Title (1)").gameObject);
			violentTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_violent + "--";

			//Violent descriptor
			TextMeshProUGUI violentDescriptor = GetTextMeshProUGUI(violentObject.transform.Find("Text").gameObject);
			violentDescriptor.text =
			LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
				+ "\n\n"
				+ LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
			+ "\n\n"
				+ "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

			//Brutal title
			GameObject brutalObject = FindDescendant(difficultyObject, "Brutal Info");
			TextMeshProUGUI brutalTitle = GetTextMeshProUGUI(brutalObject.transform.Find("Title (1)").gameObject);
			brutalTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_brutal + "--";

			//Brutal descriptor
			TextMeshProUGUI brutalDescriptor = GetTextMeshProUGUI(brutalObject.transform.Find("Text").gameObject);
			brutalDescriptor.text =
				"<color=white>" + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription1
			+ "\n\n"
			+ LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription2 + "</color>"
			+ "\n\n"
			+ "<b>" + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription3 + "<b>";
			// RTL
			if (LanguageManager.IsRightToLeft)
			{
				harmlessDescriptor.alignment = TextAlignmentOptions.TopRight;
				harmlessTitle.alignment = TextAlignmentOptions.MidlineRight;
				lenientDescriptor.alignment = TextAlignmentOptions.TopRight;
				lenientTitle.alignment = TextAlignmentOptions.MidlineRight;
				standardDescriptor.alignment = TextAlignmentOptions.TopRight;
				standardTitle.alignment = TextAlignmentOptions.MidlineRight;
				violentDescriptor.alignment = TextAlignmentOptions.TopRight;
				violentTitle.alignment = TextAlignmentOptions.MidlineRight;
			}

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
		catch (Exception e)
		{
			Logging.Error("Failed to patch difficulty text.");
			Logging.Error(e.ToString());
		}

	}

	public static void RtlFixActButton(GameObject obj, TextMeshProUGUI txt)
	{
		RectTransform rect = txt.rectTransform;
		if (rect != null)
		{
			rect.anchorMax = new Vector2(1.0f, 0.5f);
			rect.anchorMin = new Vector2(1.0f, 0.5f);
			rect.anchoredPosition = new Vector3(-388f, 0f, 0f);
		}

		GameObject act1RankIcon = obj.transform.Find("RankPanel").gameObject;
		if (act1RankIcon != null)
		{
			Image rankImage = act1RankIcon.GetComponent<Image>();
			if (rankImage != null)
			{
				RectTransform rankRect = rankImage.rectTransform;
				rankRect.anchorMin = new Vector2(0.00f, 0.50f);
				rankRect.anchorMax = new Vector2(0.00f, 0.50f);
				rankRect.anchoredPosition = new Vector3(43f, 0f, 0f);
			}
		}
	}

	public static void RtlFixDifficultyButton(GameObject obj, TextMeshProUGUI txt)
	{
		RectTransform rect = txt.rectTransform;
		if (rect != null)
		{
			rect.anchorMax = new Vector2(1.0f, 0.5f);
			rect.anchorMin = new Vector2(1.0f, 0.5f);
			rect.anchoredPosition = new Vector3(-388f, 0f, 0f);
		}

		GameObject act1RankIcon = obj.transform.Find("RankPanel").gameObject;
		if (act1RankIcon != null)
		{
			Image rankImage = act1RankIcon.GetComponent<Image>();
			if (rankImage != null)
			{
				RectTransform rankRect = rankImage.rectTransform;
				if (rankRect != null)
				{
					rankRect.anchorMin = new Vector2(0.00f, 0.50f);
					rankRect.anchorMax = new Vector2(0.00f, 0.50f);
					rankRect.anchoredPosition = new Vector3(43f, 0f, 0f);
				}
			}
		}

		GameObject progressObject = obj.transform.Find("Progress").gameObject;
		if (progressObject != null)
		{
			TextMeshProUGUI progress = progressObject.GetComponent<TextMeshProUGUI>();
			if (progress != null)
			{
				progress.alignment = TextAlignmentOptions.MidlineLeft;
				RectTransform rectTrans = progress.rectTransform;
				if (rectTrans != null)
				{
					rectTrans.anchorMin = new Vector2(0.0f, 0.5f);
					rectTrans.anchorMax = new Vector2(0.0f, 0.5f);
					GameObject rankPanel = obj.transform.Find("RankPanel")?.gameObject;
					RectTransform parentRect = obj.GetComponent<RectTransform>();
					float minDistance = -70f; // Минимальный отступ между Rank и Progress
					float progressWidth = rectTrans.rect.width;
					float newX = 0f;

					if (rankPanel != null)
					{
						RectTransform rankRect = rankPanel.GetComponent<RectTransform>();
						if (rankRect != null)
						{
							// Вычисляем правый край RankPanel с учетом его позиции и ширины
							float rankFullRight = rankRect.anchoredPosition.x + (rankRect.rect.width * 1.0f);
							// Ставим Progress справа от RankPanel (учитываем, что anchor слева)
							newX = rankFullRight + minDistance;
						}
					}

					// Проверка на выход за пределы родителя
					if (parentRect != null)
					{
						float parentRight = parentRect.rect.width;
						float maxX = parentRight - progressWidth - minDistance;
						if (newX > maxX)
						{
							newX = maxX;
						}
					}

					rectTrans.anchoredPosition = new Vector2(newX, 0.0f);
				}
			}
			else
			{
			}
		}

	}

	private static void PatchChapterSelect(GameObject frontEnd)
	{
		GameObject chapterObject = FindDescendant(frontEnd, "Chapter Select", "Chapters");
		TextMeshProUGUI chapterText = GetTextMeshProUGUI(FindDescendant(frontEnd, "Chapter Select", "Title (1)"));
		chapterText.text = "--" + LanguageManager.CurrentLanguage.frontend.chapter_title + "--";

		//Start patching the Primary and Secondary chapters type titles
		GameObject primaryObject = FindDescendant(chapterObject, "Primary", "Title");
		TextMeshProUGUI primaryText = GetTextMeshProUGUI(primaryObject);
		primaryText.text = LanguageManager.CurrentLanguage.frontend.chapter_type_primary;

		GameObject secondaryObject = FindDescendant(chapterObject, "Secondary", "Title");
		TextMeshProUGUI secondaryText = GetTextMeshProUGUI(secondaryObject);
		secondaryText.text = LanguageManager.CurrentLanguage.frontend.chapter_type_secondary;
		// End patching the Primary and Secondary chapters type titles

		GameObject preludeObject = FindDescendant(chapterObject, "Prelude");
		TextMeshProUGUI preludeText = GetTextMeshProUGUI(preludeObject.transform.Find("Name").gameObject);
		preludeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prelude;

		GameObject act1Object = FindDescendant(chapterObject, "Act I");
		TextMeshProUGUI act1Text = GetTextMeshProUGUI(act1Object.transform.Find("Name").gameObject);
		act1Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act1;

		GameObject act2Object = FindDescendant(chapterObject, "Act II");
		TextMeshProUGUI act2Text = GetTextMeshProUGUI(act2Object.transform.Find("Name").gameObject);
		act2Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act2;

		GameObject act3Object = FindDescendant(chapterObject, "Act III");
		TextMeshProUGUI act3Text = GetTextMeshProUGUI(act3Object.transform.Find("Name").gameObject);
		act3Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act3;

		GameObject encoreObject = FindDescendant(chapterObject, "Encore");
		TextMeshProUGUI encoreText = GetTextMeshProUGUI(encoreObject.transform.Find("Name").gameObject);
		encoreText.text = LanguageManager.CurrentLanguage.frontend.chapter_encore;


		GameObject primeObject = FindDescendant(chapterObject, "Prime");
		TextMeshProUGUI primeText = GetTextMeshProUGUI(primeObject.transform.Find("Name").gameObject);
		primeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prime;

		GameObject cgObject = FindDescendant(chapterObject, "The Cyber Grind");
		TextMeshProUGUI cgText = GetTextMeshProUGUI(cgObject.transform.Find("Name").gameObject);
		cgText.text = LanguageManager.CurrentLanguage.frontend.chapter_cyberGrind;

		GameObject sandboxObject = FindDescendant(chapterObject, "Sandbox");
		TextMeshProUGUI sandboxText = GetTextMeshProUGUI(sandboxObject.transform.Find("Name").gameObject);
		sandboxText.text = LanguageManager.CurrentLanguage.frontend.chapter_sandbox;

		if (LanguageManager.IsRightToLeft)
		{
			RtlFixActButton(preludeObject, preludeText);
			RtlFixActButton(act1Object, act1Text);
			RtlFixActButton(act2Object, act2Text);
			RtlFixActButton(act3Object, act3Text);
			RtlFixActButton(encoreObject, encoreText);
			RtlFixActButton(sandboxObject, sandboxText);
			RtlFixActButton(cgObject, cgText);
			RtlFixActButton(primeObject, primeText);
		}
	}

	private static void PatchLevelSelectPrelude(GameObject frontEnd)
	{
		GameObject lsPreludeObject = FindDescendant(frontEnd, "Level Select (Prelude)");
		
		GameObject preludeHeader = FindDescendant(lsPreludeObject,"Overture","Header");

		//Prelude title
		TextMeshProUGUI preludeTitleText = GetTextMeshProUGUI(FindDescendant(preludeHeader,"Text"));
		preludeTitleText.text = LanguageManager.CurrentLanguage.frontend.layer_prelude;
		preludeTitleText.fontSize = 36;

		//Prelude secret mission title
		TextMeshProUGUI secretText = GetTextMeshProUGUI(FindDescendant(preludeHeader, "Secret Mission", "Text").gameObject);
		secretText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
		

		GameObject preludeObject = FindDescendant(FindDescendant(lsPreludeObject, "Overture"),"Level Row");
		
		//0-1 challenge
		GameObject firstObject = FindDescendant(preludeObject, "0-1 Panel");
		TextMeshProUGUI firstChallenge = GetTextMeshProUGUI(FindDescendant(firstObject,"Panel", "Text"));
		firstChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-1");

		//0-2 challenge
		GameObject secondObject = FindDescendant(preludeObject, "0-2 Panel");
		TextMeshProUGUI secondChallenge = GetTextMeshProUGUI(FindDescendant(secondObject, "Panel (2)", "Text"));
		secondChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-2");

		//0-3 challenge
		GameObject thirdObject = FindDescendant(preludeObject, "0-3 Panel");
		TextMeshProUGUI thirdChallenge = GetTextMeshProUGUI(FindDescendant(thirdObject, "Panel (4)", "Text"));
		thirdChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-3");

		//0-4 challenge
		GameObject fourthObject = FindDescendant(preludeObject, "0-4 Panel");
		TextMeshProUGUI fourthChallenge = GetTextMeshProUGUI(FindDescendant(fourthObject, "Panel (6)", "Text"));
		fourthChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-4");

		//0-5 challenge
		GameObject fifthObject = FindDescendant(preludeObject, "0-5 Panel");

		TextMeshProUGUI fifthChallenge = GetTextMeshProUGUI(FindDescendant(fifthObject, "Panel (6)", "Text"));
		fifthChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-5");
		
		//Full intro panel why this is not using the TMPro
		GameObject fullIntroObject = FindDescendant(FindDescendant(lsPreludeObject, "FullIntroPopup"), "Panel");

		Text fullIntroText = GetTextfromGameObject(fullIntroObject.transform.Find("Text").gameObject);
		fullIntroText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPrompt;

		UnityEngine.UI.Text fullIntroYesText = GetTextfromGameObject(FindDescendant(fullIntroObject, "Button (1)").transform.Find("Text").gameObject);
		fullIntroYesText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptYes;

		Text fullIntroNoText = GetTextfromGameObject(FindDescendant(fullIntroObject, "Button").transform.Find("Text").gameObject);
		fullIntroNoText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptNo;

		Text fullIntroCancelText = GetTextfromGameObject(FindDescendant(fullIntroObject, "Button (2)").transform.Find("Text").gameObject);
		fullIntroCancelText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptCancel;
	}

	//Patches all text strings in the Act 1 menu.
	private static void PatchLevelSelectAct1(GameObject frontEnd)
	{
		GameObject act1Object = FindDescendant(frontEnd, "Level Select (Act I)", "Scroll Rect", "Contents");

		GameObject limboObject = FindDescendant(act1Object, "Layer 1 Limbo");
		GameObject lustObject = FindDescendant(act1Object, "Layer 2 Lust");
		GameObject gluttonyObject = FindDescendant(act1Object, "Layer 3 Gluttony");

		//Layer 1 - Limbo
		GameObject limboHeader = FindDescendant(limboObject,"Header");

		TextMeshProUGUI limboTitle = GetTextMeshProUGUI(FindDescendant(limboHeader, "Text"));
		limboTitle.text = LanguageManager.CurrentLanguage.frontend.layer_limbo;

		TextMeshProUGUI limboSecretMissionText = GetTextMeshProUGUI(FindDescendant(limboHeader, "Secret Mission", "Text"));
		limboSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;

		//Main levels
		GameObject limboContent = FindDescendant(limboObject,"Level Row");

		TextMeshProUGUI limboFirstChallenge = GetTextMeshProUGUI(FindDescendant(limboContent, "1-1 Panel", "Panel", "Text"));
		limboFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 1-1");

		TextMeshProUGUI limboSecondChallenge = GetTextMeshProUGUI(FindDescendant(limboContent, "1-2 Panel", "Panel (2)", "Text"));
		limboSecondChallenge.text = Act1Strings.GetLevelChallenge("Level 1-2");

		TextMeshProUGUI limboThirdChallenge = GetTextMeshProUGUI(FindDescendant(limboContent, "1-3 Panel", "Panel (4)", "Text"));
		limboThirdChallenge.text = Act1Strings.GetLevelChallenge("Level 1-3");

		TextMeshProUGUI limboClimaxChallenge = GetTextMeshProUGUI(FindDescendant(limboContent, "1-4 Panel", "Panel (6)", "Text"));
		limboClimaxChallenge.text = Act1Strings.GetLevelChallenge("Level 1-4");

		//Layer 2 - Lust
		GameObject lustHeader = FindDescendant(lustObject,"Header");

		TextMeshProUGUI lustTitle = GetTextMeshProUGUI(FindDescendant(lustHeader, "Text"));
		lustTitle.text = LanguageManager.CurrentLanguage.frontend.layer_lust;

		TextMeshProUGUI lustSecretMissionText = GetTextMeshProUGUI(FindDescendant(lustHeader, "Secret Mission", "Text"));
		lustSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
		
		GameObject lustContent = FindDescendant(lustObject,"Level Row");

		//Main levels
		TextMeshProUGUI lustFirstChallenge = GetTextMeshProUGUI(FindDescendant(lustContent, "2-1 Panel", "Panel", "Text"));
		lustFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 2-1");

		TextMeshProUGUI lustSecondChallenge = GetTextMeshProUGUI(FindDescendant(lustContent, "2-2 Panel", "Panel (2)", "Text"));
		lustSecondChallenge.text = Act1Strings.GetLevelChallenge("Level 2-2");

		TextMeshProUGUI lustThirdChallenge = GetTextMeshProUGUI(FindDescendant(lustContent, "2-3 Panel", "Panel (4)", "Text"));
		lustThirdChallenge.text = Act1Strings.GetLevelChallenge("Level 2-3");

		TextMeshProUGUI lustClimaxChallenge = GetTextMeshProUGUI(FindDescendant(lustContent, "2-4 Panel", "Panel (6)", "Text"));
		lustClimaxChallenge.text = Act1Strings.GetLevelChallenge("Level 2-4");

		//Layer 3 - Gluttony
		GameObject gluttonyHeader = FindDescendant(gluttonyObject,"Header");

	    TextMeshProUGUI gluttonyTitle = GetTextMeshProUGUI(FindDescendant(gluttonyHeader, "Text"));
		gluttonyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_gluttony;
		
		//Main levels
		GameObject gluttonyContent = FindDescendant(gluttonyObject,"Level Row");

	    TextMeshProUGUI gluttonyFirstChallenge = GetTextMeshProUGUI(FindDescendant(gluttonyContent, "3-1 Panel", "Panel", "Text"));
		gluttonyFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 3-1");

	    TextMeshProUGUI gluttonySecondChallenge = GetTextMeshProUGUI(FindDescendant(gluttonyContent, "3-2 Panel", "Panel (2)", "Text"));
		gluttonySecondChallenge.text = Act1Strings.GetLevelChallenge("Level 3-2");

	}

	private static void PatchLevelSelectAct2(GameObject frontEnd)
	{
		GameObject act2Object = FindDescendant(frontEnd, "Level Select (Act II)", "Scroll Rect", "Contents");

		GameObject greedObject = FindDescendant(act2Object, "Layer 4 Greed");
		GameObject wrathObject = FindDescendant(act2Object, "Layer 5 Wrath");
		GameObject heresyObject = FindDescendant(act2Object, "Layer 6 Heresy");

		//Layer 4 - Greed
		GameObject greedHeader = FindDescendant(greedObject,"Header");

	    TextMeshProUGUI greedTitle = GetTextMeshProUGUI(FindDescendant(greedHeader, "Text"));
		greedTitle.text = LanguageManager.CurrentLanguage.frontend.layer_greed;

	    TextMeshProUGUI greedSecretMissionText = GetTextMeshProUGUI(FindDescendant(greedHeader, "Secret Mission", "Text"));
		greedSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
		
		//Main levels
		GameObject greedContent = FindDescendant(greedObject,"Level Row");


	    TextMeshProUGUI greedFirstChallenge = GetTextMeshProUGUI(FindDescendant(greedContent, "4-1 Panel", "Panel", "Text"));
		greedFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 4-1");

	    TextMeshProUGUI greedSecondChallenge = GetTextMeshProUGUI(FindDescendant(greedContent, "4-2 Panel", "Panel (2)", "Text"));
		greedSecondChallenge.text = Act2Strings.GetLevelChallenge("Level 4-2");

	    TextMeshProUGUI greedThirdChallenge = GetTextMeshProUGUI(FindDescendant(greedContent, "4-3 Panel", "Panel (4)", "Text"));
		greedThirdChallenge.text = Act2Strings.GetLevelChallenge("Level 4-3");

	    TextMeshProUGUI greedClimaxChallenge = GetTextMeshProUGUI(FindDescendant(greedContent, "4-4 Panel", "Panel (6)", "Text"));
		greedClimaxChallenge.text = Act2Strings.GetLevelChallenge("Level 4-4");

		
		//Layer 5 - Wrath
		GameObject wrathHeader =  FindDescendant(wrathObject, "Header");

	    TextMeshProUGUI wrathTitle = GetTextMeshProUGUI(FindDescendant(wrathHeader, "Text"));
		wrathTitle.text = LanguageManager.CurrentLanguage.frontend.layer_wrath;

	    TextMeshProUGUI wrathSecretMissionText = GetTextMeshProUGUI(FindDescendant(wrathHeader, "Secret Mission", "Text"));
		wrathSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
		
		//Main levels
		GameObject wrathContent = FindDescendant(wrathObject,"Level Row");

	    TextMeshProUGUI wrathFirstChallenge = GetTextMeshProUGUI(FindDescendant(wrathContent, "5-1 Panel", "Panel", "Text"));
		wrathFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 5-1");

	    TextMeshProUGUI wrathSecondChallenge = GetTextMeshProUGUI(FindDescendant(wrathContent, "5-2 Panel", "Panel (2)", "Text"));
		wrathSecondChallenge.text = Act2Strings.GetLevelChallenge("Level 5-2");

	    TextMeshProUGUI wrathThirdChallenge = GetTextMeshProUGUI(FindDescendant(wrathContent, "5-3 Panel", "Panel (4)", "Text"));
		wrathThirdChallenge.text = Act2Strings.GetLevelChallenge("Level 5-3");

	    TextMeshProUGUI wrathFourthChallenge = GetTextMeshProUGUI(FindDescendant(wrathContent, "5-4 Panel", "Panel (6)", "Text"));
		wrathFourthChallenge.text = Act2Strings.GetLevelChallenge("Level 5-4");


		//Layer 6 - Heresy
		GameObject heresyHeader = FindDescendant(heresyObject,"Header");

	    TextMeshProUGUI heresyTitle = GetTextMeshProUGUI(FindDescendant(heresyHeader, "Text"));
		heresyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_heresy;
		
		//Main levels
		GameObject heresyContent = FindDescendant(heresyObject,"Level Row");


	    TextMeshProUGUI heresyFirstChallenge = GetTextMeshProUGUI(FindDescendant(heresyContent, "6-1 Panel", "Panel", "Text"));
		heresyFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 6-1");

	    TextMeshProUGUI heresySecondChallenge = GetTextMeshProUGUI(FindDescendant(heresyContent, "6-2 Panel", "Panel (2)", "Text"));
		heresySecondChallenge.text = Act2Strings.GetLevelChallenge("Level 6-2");
	}
	
	private static void PatchLevelSelectAct3(GameObject frontEnd)
	{
		GameObject act3Object = FindDescendant(frontEnd, "Level Select (Act III)", "Scroll Rect", "Contents");

		GameObject violenceObject = FindDescendant(act3Object, "Layer 7 Violence");
		GameObject fraudObject = FindDescendant(act3Object, "Layer 8 Fraud");
		GameObject treacheryObject = FindDescendant(act3Object, "Layer 9 Treachery");

		//Layer 7 - Violence
		GameObject violenceHeader = FindDescendant(violenceObject,"Header");

	    TextMeshProUGUI violenceTitle = GetTextMeshProUGUI(FindDescendant(violenceHeader, "Text"));
		violenceTitle.text = LanguageManager.CurrentLanguage.frontend.layer_violence;

	    TextMeshProUGUI violenceSecretMissionText = GetTextMeshProUGUI(FindDescendant(violenceHeader, "Secret Mission", "Text"));
		violenceSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
		
		//Main levels
		GameObject violenceContent = FindDescendant(violenceObject,"Level Row");


		TextMeshProUGUI violenceFirstChallenge = GetTextMeshProUGUI(FindDescendant(violenceContent, "7-1 Panel", "Panel", "Text"));
		violenceFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 7-1");

		TextMeshProUGUI violenceSecondChallenge = GetTextMeshProUGUI(FindDescendant(violenceContent, "7-2 Panel", "Panel (2)", "Text"));
		violenceSecondChallenge.text = Act3Strings.GetLevelChallenge("Level 7-2");

		TextMeshProUGUI violenceThirdChallenge = GetTextMeshProUGUI(FindDescendant(violenceContent, "7-3 Panel", "Panel (4)", "Text"));
		violenceThirdChallenge.text = Act3Strings.GetLevelChallenge("Level 7-3");

		TextMeshProUGUI violenceClimaxChallenge = GetTextMeshProUGUI(FindDescendant(violenceContent, "7-4 Panel", "Panel (6)", "Text"));
		violenceClimaxChallenge.text = Act3Strings.GetLevelChallenge("Level 7-4");

		
		//Layer 8 - Fraud
		GameObject fraudHeader = FindDescendant(fraudObject,"Header");

		TextMeshProUGUI fraudTitle = GetTextMeshProUGUI(FindDescendant(fraudHeader, "Text"));
		fraudTitle.text = LanguageManager.CurrentLanguage.frontend.layer_fraud;

		TextMeshProUGUI fraudSecretMissionText = GetTextMeshProUGUI(FindDescendant(fraudHeader, "Secret Mission", "Text"));
		fraudSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
		
		//Main levels
		GameObject fraudContent = FindDescendant(fraudObject,"Level Row");


		TextMeshProUGUI fraudFirstChallenge = GetTextMeshProUGUI(FindDescendant(fraudContent, "8-1 Panel", "Panel", "Text"));
		fraudFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 8-1");

		TextMeshProUGUI fraudSecondChallenge = GetTextMeshProUGUI(FindDescendant(fraudContent, "8-2 Panel", "Panel (2)", "Text"));
		fraudSecondChallenge.text = Act3Strings.GetLevelChallenge("Level 8-2");

		TextMeshProUGUI fraudThirdChallenge = GetTextMeshProUGUI(FindDescendant(fraudContent, "8-3 Panel", "Panel (4)", "Text"));
		fraudThirdChallenge.text = Act3Strings.GetLevelChallenge("Level 8-3");

		TextMeshProUGUI fraudClimaxChallenge = GetTextMeshProUGUI(FindDescendant(fraudContent, "8-4 Panel", "Panel (6)", "Text"));
		fraudClimaxChallenge.text = Act3Strings.GetLevelChallenge("Level 8-4");


		//Layer 9 - Treachery
		GameObject treacheryHeader = FindDescendant(treacheryObject,"Header");

	    TextMeshProUGUI treacheryTitle = GetTextMeshProUGUI(FindDescendant(treacheryHeader, "Text"));
		treacheryTitle.text = LanguageManager.CurrentLanguage.frontend.layer_treachery;
		
		//Main levels
		GameObject treacheryContent = FindDescendant(treacheryObject,"Level Row");


	    TextMeshProUGUI treacheryFirstChallenge = GetTextMeshProUGUI(FindDescendant(treacheryContent, "9-1 Panel", "Panel", "Text"));
		treacheryFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 9-1");

	    TextMeshProUGUI treacherySecondChallenge = GetTextMeshProUGUI(FindDescendant(treacheryContent, "9-2 Panel", "Panel (2)", "Text"));
		treacherySecondChallenge.text = Act3Strings.GetLevelChallenge("Level 9-2");
	}

	private static void PatchLevelSelectEncore(GameObject frontEnd)
	{
		GameObject lsEncoreObject = FindDescendant(frontEnd, "Level Select (Encore)", "Scroll Rect", "Contents");

		GameObject encoreHeader = FindDescendant(lsEncoreObject, "Encores", "Header");

		//Encore title
		TextMeshProUGUI preludeTitleText = GetTextMeshProUGUI(FindDescendant(encoreHeader, "Text"));
		preludeTitleText.text = LanguageManager.CurrentLanguage.frontend.chapter_encore;
		preludeTitleText.fontSize = 36;
		
	}

	private static void PatchLevelSelectPrime(GameObject frontEnd)
	{
		GameObject primeObject = FindDescendant(frontEnd, "Level Select (Prime)", "Prime Sanctums", "Header");
		TextMeshProUGUI primeTitle = GetTextMeshProUGUI(FindDescendant(primeObject, "Text"));
		primeTitle.text = LanguageManager.CurrentLanguage.frontend.layer_prime;
	}

	private static void PatchTextArroundV1(GameObject mainMenu)
	{
		GameObject textV1 = FindDescendant(mainMenu, "Main Menu (1)", "BackgroundSwapper", "Text (TMP)", "V1Text");
		TextMeshProUGUI wingModule = GetTextMeshProUGUI(FindDescendant(textV1, "Text (TMP)"));
		TextMeshProUGUI armModuleFactory = GetTextMeshProUGUI(FindDescendant(textV1, "Text (TMP) (1)"));
		TextMeshProUGUI armModuleFeedbacker = GetTextMeshProUGUI(FindDescendant(textV1, "Text (TMP) (2)"));
		TextMeshProUGUI visualCortexModule = GetTextMeshProUGUI(FindDescendant(textV1, "Text (TMP) (3)"));
		TextMeshProUGUI legModule = GetTextMeshProUGUI(FindDescendant(textV1, "Text (TMP) (4)"));

		if (!string.IsNullOrEmpty(LanguageManager.CurrentLanguage.frontend.wingModule))
			wingModule.text = LanguageManager.CurrentLanguage.frontend.wingModule;
		if (!string.IsNullOrEmpty(LanguageManager.CurrentLanguage.frontend.armModuleFactory))
			armModuleFactory.text = LanguageManager.CurrentLanguage.frontend.armModuleFactory;
		if (!string.IsNullOrEmpty(LanguageManager.CurrentLanguage.frontend.armModuleFeedbacker))
			armModuleFeedbacker.text = LanguageManager.CurrentLanguage.frontend.armModuleFeedbacker;
		if (!string.IsNullOrEmpty(LanguageManager.CurrentLanguage.frontend.visualCortexModule))
			visualCortexModule.text = LanguageManager.CurrentLanguage.frontend.visualCortexModule;
		if (!string.IsNullOrEmpty(LanguageManager.CurrentLanguage.frontend.legModule))
			legModule.text = LanguageManager.CurrentLanguage.frontend.legModule;
	}

	public static void Patch(GameObject frontEnd)
	{
		try
		{
			PatchMainMenu(frontEnd);
			PatchTextArroundV1(frontEnd);
			PatchPopUps(frontEnd);
			//ChangeTitle(frontEnd);
			PatchDifficultyMenu(frontEnd);
			PatchDifficultyDescriptors(frontEnd);

			PatchChapterSelect(frontEnd);
			PatchLevelSelectPrelude(frontEnd);
			PatchLevelSelectAct1(frontEnd);
			PatchLevelSelectAct2(frontEnd);
			PatchLevelSelectAct3(frontEnd);
			PatchLevelSelectEncore(frontEnd);
			PatchLevelSelectPrime(frontEnd);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}

	}

}
