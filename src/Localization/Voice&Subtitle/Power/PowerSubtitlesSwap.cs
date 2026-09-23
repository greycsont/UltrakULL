using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(PowerVoiceController))]
public static class PowerSubtitlesSwap
{
	public static MethodInfo LocalizePowerSubtitleMethodInfo = AccessTools.Method(
		typeof(PowerSubtitlesSwap),
		nameof(PowerSubtitlesSwap.LocalizePowerSubtitle),
		new[] { typeof(string) }
	);

	[HarmonyTranspiler]
	[HarmonyPatch(nameof(PowerVoiceController.Intro))]
	[HarmonyPatch(nameof(PowerVoiceController.Enrage))]
	[HarmonyPatch(nameof(PowerVoiceController.Taunt))]
	[HarmonyPatch(nameof(PowerVoiceController.CheapShot))]
	[HarmonyPatch(nameof(PowerVoiceController.Rapier))]
	[HarmonyPatch(nameof(PowerVoiceController.Greatsword))]
	[HarmonyPatch(nameof(PowerVoiceController.Spear))]
	[HarmonyPatch(nameof(PowerVoiceController.SpearThrow))]
	[HarmonyPatch(nameof(PowerVoiceController.Glaive))]
	[HarmonyPatch(nameof(PowerVoiceController.GlaiveThrow))]
	private static IEnumerable<CodeInstruction> PowerSubtitlesSwap__SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize3(instructions, LocalizePowerSubtitleMethodInfo);
	}

	public static string LocalizePowerSubtitle(string input)
	{
		if (LanguageManager.IsEnglish)
			return input;

		var s = LanguageManager.CurrentLanguage.subtitles;

		return (input switch
		{
			"Be afraid, machine." => s.subtitles_power_intro_0,
			"Here shall be your grave." => s.subtitles_power_intro_1,
			"It is over, machine!" => s.subtitles_power_intro_2,
			"Surrender or perish!" => s.subtitles_power_intro_3,
			"Lay down and die!" => s.subtitles_power_intro_4,

			"Bastard!" => s.subtitles_power_enrage_0,
			"You piece of SHIT!" => s.subtitles_power_enrage_1,
			"Just DIE already!" => s.subtitles_power_enrage_2,
			"Why won't you die!?" => s.subtitles_power_enrage_3,
			"God DAMN it!" => s.subtitles_power_enrage_4,

			"This lowly thing could never have bested him!" => s.subtitles_power_taunt_0,
			"An inconvenience at best." => s.subtitles_power_taunt_1,
			"This is a waste of my time!" => s.subtitles_power_taunt_2,
			"Just another worthless object." => s.subtitles_power_taunt_3,

			"PAY ATTENTION!" => s.subtitles_power_cheapShot_0,
			"Wait your TURN!" => s.subtitles_power_cheapShot_1,
			"WRONG TARGET!" => s.subtitles_power_cheapShot_2,

			"Rapier!" => s.subtitles_power_rapier,
			"Greatsword!" => s.subtitles_power_greatsword,
			"Spear!" => s.subtitles_power_spear,
			"Over here!" => s.subtitles_power_spearThrow,
			"Glaive!" => s.subtitles_power_glaive,
			"Take THIS!" => s.subtitles_power_glaiveThrow,

			_ => input,
		}).Or(input);
	}
}
