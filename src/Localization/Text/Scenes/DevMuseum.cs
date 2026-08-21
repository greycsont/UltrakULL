using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;


using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class DevMuseum
{
	private static readonly (string keyword, Func<string, string, string, string> build)[] Messages =
	{
		("RACE START", (m, m2, input) => LanguageManager.CurrentLanguage.devMuseum.museum_rocketRaceStart),
		("A R M B O Y", (m, m2, input) => LanguageManager.CurrentLanguage.act2.act2_heresyFirst_armboy),
		("TIME", (m, m2, input) => LanguageManager.CurrentLanguage.misc.levelstats_time + ": " + m.Split(':')[1]),
		("Chess", (m, m2, input) => LanguageManager.CurrentLanguage.devMuseum.museum_chessTip),
	};

	public static string GetMessage(string message, string message2, string input)
	{
		foreach (var (keyword, build) in Messages)
			if (message.Contains(keyword))
				return build(message, message2, input);

		return null;
	}

	public static string GetMuseumBook(string originalText)
	{
		if (originalText.Contains("HAKITA</color> - CREATOR OF ULTRAKILL</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita7 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita8 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita9 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita10 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita11 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita12 + "</size>\n\n<i><color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita13 + "</color></i>";
		}
		if (originalText.Contains("FRANCIS XIE</color> - CONCEPT AND TEXTURE ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie3 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie7 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie8 + "</size>\n\n<i><color=#4AACBD>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie9 + "</color></i>";
		}
		if (originalText.Contains("JERICHO_RUS</color> - ILLUSTRATOR, CONCEPT AND TEXTURE ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus3 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus7 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus8 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus9 + "</size>\n\n<i><color=#5cc6f1>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus10 + "</color></i>";
		}
		if (originalText.Contains("BIGROCKBMP</color> - CONCEPT ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP3 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP7 + "</size>\n\n<i><color=#DA6B6D>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP8 + "</color></i>";
		}
		if (originalText.Contains("MAXIMILIAN OVESSON</color> - UI ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson2 + "\n\n<i><color=#8f65da>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson3 + "</color></i>\n\n";
		}
		if (originalText.Contains("RHIANNON MITCHELL</color> - UI ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookRhiannonMitchell1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookRhiannonMitchell2 + "\n\n<i><color=#dabfff>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookRhiannonMitchell3 + "</color></i>\n\n";
		}
		if (originalText.Contains("VICTORIA HOLLAND</color> - LEAD 3D ARTIST AND GRAPHICS PROGRAMMER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland3 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland7 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland8 + "</size>\n\n<i><color=#F5ABB9>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland9 + "</color></i>\n\n";
		}
		if (originalText.Contains("TONI STIGELL</color> - 3D ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell4 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell7 + "</size>";
		}
		if (originalText.Contains("FLYINGDOG</color> - 3D ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog3 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog6 + "</size>";
		}
		if (originalText.Contains("SAMUEL JAMES BRYAN</color> - 3D ARTIST</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookSamuelJamesBryan1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSamuelJamesBryan2 + "\n\n<i><color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSamuelJamesBryan3 + "</color></i>";
		}
		if (originalText.Contains("<b><color=red>CAMERON MARTIN</color> - QUALITY ASSURANCE LEAD"))
		{
			return "<b>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamLine1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamLine2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamLine3 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamLine4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamLine5 + "</b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamDesc1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamDesc2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamDesc3 + "\n\n<color=red><i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamQuote1 + "</i></color>\n\n<color=#6a36be><i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamQuote2 + "</i></color>\n\n<color=#11c324><i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamQuote3 + "</i></color>\n\n<color=#e28eb6><i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamQuote4 + "</i></color>\n\n<color=#4480e6><i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeamQuote5 + "</i></color>";
		}
		if (originalText.Contains("<b><color=orange>PITR</color> - LEAD PROGRAMMER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr4 + "\n\n<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr7 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr8 + "</size>";
		}
		if (originalText.Contains("<b><color=orange>HECKTECK</color> - LEAD PROGRAMMER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookHeckteck1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHeckteck2 + "\n\n<i><color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHeckteck3 + "</color></i>";
		}
		if (originalText.Contains("HAZELUFF</color> - PROGRAMMER</b>"))
		{
			return "<b>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHazeluff1 + "</b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHazeluff2 + "\n\n<color=#6153AB><i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHazeluff3 + "</i></color>";
		}
		if (originalText.Contains("CHIZHOV</color> - ADDITIONAL PROGRAMMER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookCabalcrow1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookCabalcrow2 + "\n\n<i><color=#c0c0c0ff>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookCabalcrow3 + "</color></i>";
		}
		if (originalText.Contains("LUCAS VARNEY</color> - ADDITIONAL PROGRAMMER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookLucasVarney1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookLucasVarney2 + "\n\n<i><color=#BD8BF3>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookLucasVarney3 + "</color></i>";
		}
		if (originalText.Contains("BEN MOIR</color> - ADDITIONAL PROGRAMMER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir3 + "\n\n<i><color=#3EF242>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir4 + "</color></i>\n\n";
		}
		if (originalText.Contains("MEGANEKO</color> - GUEST COMPOSER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko3 + "\n\n<i><color=#E93436>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko4 + "</color></i>\n\n";
		}
		if (originalText.Contains("KEYGEN CHURCH</color> - GUEST COMPOSER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch3 + "\n\n<i><color=#aa0000>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch4 + "</color></i>\n\n";
		}
		if (originalText.Contains("HEALTH</color> - GUEST COMPOSER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth3 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth5 + "\n\n<i><color=red>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth6 + "</color></i>";
		}
		if (originalText.Contains("KING GIZZARD & THE LIZARD WIZARD</color> - GUEST COMPOSER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard3 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard5 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard6 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard7 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard8 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard9 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard10 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard11 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKingGizzard12;
		}
		if (originalText.Contains("QUETZAL TIRADO</color> - GUEST MUSICIAN</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado3 + "\n\n<i><color=#AA4CAD>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado4 + "</color></i>";
		}
		if (originalText.Contains("SALAD</color> - HELPING HAND</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad2 + "</size>\n\n<i><color=#20FF20>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad3 + "</color></i>";
		}
		if (originalText.Contains("JACOB H.H.R.</color> - WRITER (PROSE & DIALOGUE)</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookJacobHHR1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJacobHHR2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookJacobHHR3;
		}
		if (originalText.Contains("VVIZARD</color> - MUSEUM DEVELOPER</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard3 + "\n\n<i><color=#ee0c47>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard4 + "</color></i>";
		}
		if (originalText.Contains("ADDITIONAL MUSIC CREDITS"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic7 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic8 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic9 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic10 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic11 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic12 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic13;
		}
		// Here Here! the mf extra credit of UltrakULL
		// idk why it choose to add it in here - greycsont
		if (originalText.Contains("COMMUNITY CYBER GRIND"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits3 + "\n\nNO LOAFING\nDood\nSplendidLedraps\nJandy\nStuon\nDryzalar\nWakan\nSlimer\nWilliam\nBobot\nSpruce\nJacob\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits7 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits8 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits9 + "\n\n<b><color=orange>UltrakULL CREDITS</color>:</b>\n\nMod created by <color=orange>Clearwater</color>\nAdditional code contributions by <color=orange>Temperz87</color>, <color=orange>CoatlessAli</color>, <color=orange>Frizou</color>,\n<color=orange>lenarikil</color>, <color=orange>Susinopo</color>, <color=orange>Sophie</color>, <color=orange>greycsont</color>  and <color=orange>Dice</color>\nTranslations by various community members of the <color=orange>UltrakULL Translation Team</color>\nDocumentation contributions by <color=orange>Frizou</color>\n\n<color=orange><b>" + LanguageManager.CurrentLanguage.metadata.langDisplayName + "</b></color>:\n" + LanguageManager.CurrentLanguage.metadata.langAuthor;
		}
		if (originalText.Contains("STEPHAN WEYTE</color> - VOICE OF MINOS PRIME</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookStephanWeyte1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookStephanWeyte2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookStephanWeyte3 + "\n\n";
		}
		if (originalText.Contains("LENVAL BROWN</color> - VOICE OF SISYPHUS PRIME</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookLenvalBrown1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookLenvalBrown2;
		}
		if (originalText.Contains("GIANNI MATRAGRANO</color> - VOICE OF GABRIEL</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano3 + "\n\n<i><color=#20afdb>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano4 + "</color></i>";
		}
		if (originalText.Contains("MANDALORE</color> <color=#9884bb>HERRINGTON</color> - VOICE OF MYSTERIOUS DRUID KNIGHT</b>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore5 + "\n\n<i>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore6 + "</i>\n\n<i><color=#eabbd7>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore7 + "</color></i>";
		}
		if (originalText.Contains("KENNADY RAY</color> - VOICE OF POWER</b>"))
		{
			return "<b><color=#FF00A1>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPower1 + "</color></b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPower2 + "\n\n<color=#FF00A1><i>\"" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPower3 + "\"</i></color>";
		}
		if (originalText.Contains("VYLET PONY</color> - GUEST COMPOSER</b>"))
		{
			return "<b><color=#A26ADE>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVylet1 + "</color></b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVylet2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVylet3 + "\n\n<color=#A26ADE><i>\"" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVylet4 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVylet5 + "\"</i></color>";
		}
		if (originalText.Contains("DOMENICO ANTONAZZO</color> - RIGGING</b>"))
		{
			return "<b><color=#979283>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt1 + "</color></b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt2 + "\n\n<color=#979283><i>\"" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt3 + "\"</i></color>\n\n<b><color=#c7a6ef>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt4 + "</color></b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt5 + "\n\n<color=#c7a6ef><i>\"" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt6 + "\"</i></color>\n\n<b><color=#b12b39>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt7 + "</color></b>\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt8 + "\n\n<color=#b12b39><i>\"" + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalArt9 + "\"</i></color>";
		}
		if (originalText.Contains("FILTH</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth7;
		}
		if (originalText.Contains("STRAY</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray5;
		}
		if (originalText.Contains("SCHISM</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism6;
		}
		if (originalText.Contains("SWORDSMACHINE</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine6;
		}
		if (originalText.Contains("MALICIOUS FACE</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace7;
		}
		if (originalText.Contains("BEAMCUTTER</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter2 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter3 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter7 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter8 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter9;
		}
		if (originalText.Contains("BLACK HOLE CANNON</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon1 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon6 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon7 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon8;
		}
		if (originalText.Contains("REVOLVER</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver6;
		}
		if (originalText.Contains("SHOTGUN</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun5;
		}
		if (originalText.Contains("NAILGUN</color>"))
		{
			return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun1 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun2 + "\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun3 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun4 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun5 + "\n\n" + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun6;
		}
		return originalText ?? "";
	}

	private static void PatchPlaques()
	{
		// First part: Non-__DEV_SPACE_ALL placards
		GetInactiveRootObject("__Room_Courtyard").transform.GetChild(4).GetChild(0).gameObject.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMuseumTitle, path: ["Canvas (2)", "Text"]);
		GameObject gameObject = GetInactiveRootObject("__Room_FrontDesk_1").transform.GetChild(1).gameObject;
		GameObject gameObject2 = gameObject.transform.GetChild(58).gameObject;
		GameObject gameObject3 = gameObject.transform.GetChild(0).gameObject;
		GameObject gameObject4 = gameObject.transform.GetChild(1).gameObject;
		gameObject2.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHakita1, path: ["Canvas (3)", "Text"]);
		gameObject2.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHakita2, path: ["Canvas (3)", "Text (1)"]);
		gameObject3.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesArtRoom, path: ["Canvas (3)", "Text"]);
		gameObject4.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesNerdRoom, path: ["Canvas (3)", "Text"]);
		
		// New logic for __DEV_SPACE_ALL placards (lines 222-317)
		// Find the main container
		GameObject inactiveRootObject = GetInactiveRootObject("__DEV_SPACE_ALL");
		
		// Step 1: Find all placards directly under __DEV_SPACE_ALL (including Dev Space Large, etc.)
		List<GameObject> placards = new List<GameObject>();
		
		// Helper method to recursively find all placard objects
		void FindPlacardsRecursive(GameObject parent)
		{
			foreach (Transform child in parent.transform)
			{
				// Look for actual placard objects (not containers)
				if (child.name.Contains("Dev Smalll placard") || child.name.Contains("Dev Large Placard"))
				{
					placards.Add(child.gameObject);
				}
				else
				{
					// Continue searching in child containers (like Dev_Space_ (25), dev Space Large, etc.)
					FindPlacardsRecursive(child.gameObject);
				}
			}
		}
		
		FindPlacardsRecursive(inactiveRootObject);
		
		// Step 2: Process each placard found and log their initial content for debugging
		foreach (GameObject placard in placards)
		{
			// Get the Canvas (4) child
			GameObject canvas = FindDescendant(placard, "Canvas (4)");
			if (canvas == null)
			{
				Logging.Warn($"Canvas (4) not found for placard: {placard.name}");
				continue;
			}
			
			// Get Text and Text (1) components
			Text textComponent = SceneObjects.FindComponent<Text>(canvas, "Text");
			Text text1Component = SceneObjects.FindComponent<Text>(canvas, "Text (1)");
			
			if (textComponent == null || text1Component == null)
			{
				Logging.Warn($"Text or Text (1) component not found for placard: {placard.name}");
				continue;
			}
			
			// Get the initial text content to determine what to replace it with
			string initialText = textComponent.text ?? "";
			string initialText1 = text1Component.text ?? "";
			
			// Clean up text by removing control characters and trimming whitespace
			initialText = initialText.Trim().Replace("\n", "").Replace("\r", "").Replace("&THE", " & THE").Replace("  ", " ");
			initialText1 = initialText1.Trim().Replace("\n", "").Replace("\r", "");
			
			// Log the initial text content for debugging purposes
			Logging.Info($"Placard: {placard.name}");
			Logging.Info($"  Initial Text: '{initialText}'");
			Logging.Info($"  Initial Text (1): '{initialText1}'");
			
			// Apply translations based on initial text content
			if (initialText.Contains("KING GIZZARD"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKingGizzard1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKingGizzard2);
			}
			else if (initialText.Contains("Stephan Weyte"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesStephanWeyte1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesStephanWeyte2);
			}
			else if (initialText.Contains("Lenval Brown"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown2);
			}
			else if (initialText.Contains("Keygen Church"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKeygenChurch1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKeygenChurch2);
			}
			else if (initialText.Contains("Meganeko"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMeganeko1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMeganeko2);
			}
			else if (initialText.Contains("Salad"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSalad1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSalad2);
			}
			else if (initialText.Contains("Jacob H.H.R."))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJacobHHR1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJacobHHR2);
			}
			else if (initialText.Contains("Vvizard"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVVizard1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVVizard2);
			}
			else if (initialText.Contains("Mandalore Herrington"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMandalore1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMandalore2);
			}
			else if (initialText.Contains("Joy Young"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJoyYoung1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJoyYoung2);
			}
			else if (initialText.Contains("Arsi \"Hakita\" Patala"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHakita1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHakita2);
			}
			else if (initialText.Contains("Emanuil \"Cabalcrow\" Chizhov"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCabalcrow1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCabalcrow2);
			}
			else if (initialText.Contains("Ben Moir"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBenMoir1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBenMoir2);
			}
			else if (initialText.Contains("Lucas Varney"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLucasVarney1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLucasVarney2);
			}
			else if (initialText.Contains("Hazeluff"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHazeluff1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHazeluff2);
			}
			else if (initialText.Contains("KENNADY RAY"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKennadyRay1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKennadyRay2);
			}
			else if (initialText.Contains("Heckteck"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck2);
			}
			else if (initialText.Contains("Maximilian Ovesson"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMaxOvesson1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMaxOvesson2);
			}
			else if (initialText.Contains("RHIANNON MITCHELL"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesRhiannonMitchell1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesRhiannonMitchell2);
			}
			else if (initialText.Contains("BigRockBMP"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBigRockBMP1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBigRockBMP2);
			}
			else if (initialText.Contains("JERICHO_RUS"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJerichoRus1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJerichoRus2);
			}
			else if (initialText.Contains("Francis Xie"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFrancisXie1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFrancisXie2);
			}
			else if (initialText.Contains("Toni Stigell"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesToniStigell1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesToniStigell2);
			}
			else if (initialText.Contains("FlyingDog"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFlyingdog1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFlyingdog2);
			}
			else if (initialText.Contains("Samuel James Bryan"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSamuelJamesBryan1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSamuelJamesBryan2);
			}
			else if (initialText.Contains("Additional Music"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalMusic);
			}
			else if (initialText.Contains("VYLET PONY"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVyletPony1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVyletPony2);
			}
			else if (initialText.Contains("QUETZAL TIRADO"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesQuetzalTirado1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesQuetzalTirado2);
			}
			else if (initialText.Contains("HEALTH"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHealth1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHealth2);
			}
			else if (initialText.Contains("Cameron Martin"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCameronMartin1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCameronMartin2);
			}
			else if (initialText.Contains("Dalia Figueroa"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa2);
			}
			else if (initialText.Contains("Tucker Wilkin"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesTuckerWilkin1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesTuckerWilkin2);
			}
			else if (initialText.Contains("Scott Gurney"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesScottGurney1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesScottGurney2);
			}
			else if (initialText.Contains("Aaron Burzynski"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAaronBurzynski1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAaronBurzynski2);
			}
			else if (initialText.Contains("Victoria Holland"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVictoriaHolland1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVictoriaHolland2);
			}
			else if (initialText.Contains("Gianni Matragrano"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesGianniMatragrano1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesGianniMatragrano2);
			}
			else if (initialText.Contains("PITR"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesPitr1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesPitr2);
			}
			else if (initialText.Contains("HECKTECK"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck1);
				text1Component.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck2);
			}
			else if (initialText.Contains("Additional credits"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalCredits);
			}
			else if (initialText.Contains("Additional ART"))
			{
				textComponent.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalArt);
			}
			else
			{
				// Log for debugging (will be removed later)
				Logging.Warn($"No mapping found for initial text: '{initialText}' in placard: {placard.name}");
			}
		}
		
		// Last part: Remaining non-__DEV_SPACE_ALL placards (lines 318-420)
		GameObject gameObject5 = GetInactiveRootObject("__Room_Large_Lower").transform.GetChild(4).gameObject;
		Text daveOshryText1 = SceneObjects.FindComponent<Text>(gameObject5, "Wing name (4)", "Canvas (5)", "Text");
		Text daveOshryText2 = SceneObjects.FindComponent<Text>(gameObject5, "Wing name (4)", "Canvas (5)", "Text (1)");
		daveOshryText1.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaveOshry1);
		daveOshryText2.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaveOshry2);
		GameObject gameObject6 = GetInactiveRootObject("__Room_Large_Lower").transform.GetChild(3).gameObject;
		GameObject gameObject7 = gameObject6.transform.GetChild(9).gameObject;
		GameObject gameObject8 = gameObject6.transform.GetChild(10).gameObject;
		gameObject7.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesRestRoom, path: ["Canvas (3)", "Text"]);
		gameObject8.Localize<Text>(LanguageManager.CurrentLanguage.devMuseum.museum_plaquesTalkRoom, path: ["Canvas (3)", "Text"]);
		GameObject rocketRaceScreen = FindDescendant(GetInactiveRootObject("PuzzleScreen (2)"), "Canvas", "Background", "Start");
		rocketRaceScreen.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_rocketRace1, path: ["Text"]);
		rocketRaceScreen.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_rocketRace2, path: ["OpenButton", "Text"]);
		GameObject cinemaScreen = FindDescendant(GetInactiveRootObject("__Room_Theater"), "Ultrakill Projector", "PuzzleScreen", "Canvas", "Background");
		cinemaScreen.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_cinemaPlay, path: ["PlayButton", "Text"]);
		cinemaScreen.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_cinemaStop, path: ["StopButton", "Text"]);
		GameObject spoilerBackground1 = FindDescendant(GetInactiveRootObject("__DEV_SPACE_ALL"), "Prime 1 VA", "SpoilerBlock", "PuzzleScreen (1)", "Canvas", "Background");
		GameObject spoilerBackground2 = FindDescendant(GetInactiveRootObject("__DEV_SPACE_ALL"), "Prime 2 VA", "SpoilerBlock", "PuzzleScreen (1)", "Canvas", "Background");
		spoilerBackground1.Localize<TextMeshProUGUI>("<color=red>{0}</color>\n{1}".FormatWith( LanguageManager.CurrentLanguage.devMuseum.museum_spoiler1, LanguageManager.CurrentLanguage.devMuseum.museum_spoiler2), path: ["Text"]);
		spoilerBackground2.Localize<TextMeshProUGUI>("<color=red>{0}</color>\n{1}".FormatWith( LanguageManager.CurrentLanguage.devMuseum.museum_spoiler1, LanguageManager.CurrentLanguage.devMuseum.museum_spoiler2), path: ["Text"]);
		spoilerBackground1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_spoiler3, path: ["OpenButton/Text"]);
		spoilerBackground2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_spoiler3, path: ["OpenButton/Text"]);
}

	private static void PatchChess()
	{
		GameObject gameObjectChild = FindDescendant(GetInactiveRootObject("__Room_Aquarium"), "Geo", "Chess");
		GameObject gameObjectChild2 = FindDescendant(gameObjectChild, "PuzzleScreen", "Canvas", "Background", "Main Window");
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessVs, path: ["Versus Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessNewgame, path: ["Start New Game Button", "Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessBlack, path: ["Black", "Black Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessWhite, path: ["White", "White Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessBot, path: ["Black", "Bot Button", "Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessPlayer, path: ["Black", "Player Button", "Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessBot, path: ["White", "Bot Button", "Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessPlayer, path: ["White", "Player Button", "Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose, path: ["Settings", "Main Window", "Close Button", "Text"]);
		gameObjectChild2.Localize<TextMeshProUGUI>("{0}:".FormatWith( LanguageManager.CurrentLanguage.devMuseum.museum_chessBot), path: ["Settings", "Main Window", "Set Elo", "Slider", "Bot Text"]);
		gameObjectChild.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessWhitewin, path: ["WhiteWin", "WinText"]);
		gameObjectChild.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessBlackwin, path: ["BlackWin", "WinText"]);

	GameObject chessPieces = FindDescendant(gameObjectChild, "ChessPieces");

		Logging.Debug("Patching chess piece texts...");

	foreach (TMP_Text tmp in chessPieces.GetComponentsInChildren<TMP_Text>(true))
	{
		Transform t = tmp.transform;
		bool isPawn = false;
		string promotion = null;

		while (t != null)
		{
			if (t.name.StartsWith("W Pawn") || t.name.StartsWith("B Pawn"))
				isPawn = true;

			if (t.name == "Queen" || t.name == "Rook" || t.name == "Bishop" || t.name == "Knight")
				promotion = t.name;

			t = t.parent;
		}

		if (!isPawn)
			continue;

		if (tmp.name == "Text (TMP) (1)")
			tmp.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_chessPromotion);
		else if (promotion == "Queen")
			tmp.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_chessQueen);
		else if (promotion == "Rook")
			tmp.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_chessRook);
		else if (promotion == "Bishop")
			tmp.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_chessBishop);
		else if (promotion == "Knight")
			tmp.Localize(LanguageManager.CurrentLanguage.devMuseum.museum_chessKnight);
	}
}

	public static void Patch()
	{
		PatchPlaques();
		PatchChess();
	}
}
