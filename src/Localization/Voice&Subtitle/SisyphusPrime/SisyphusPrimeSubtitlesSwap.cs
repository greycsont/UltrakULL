using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(SisyphusPrime))]
public class SisyphusPrimeSubtitlesSwap
{
	public static MethodInfo LocalizeSisyphusSubtitleMethodInfo = AccessTools.Method(
		typeof(SisyphusPrimeSubtitlesSwap),
		nameof(SisyphusPrimeSubtitlesSwap.LocalizeSisyphusSubtitle),
		new[] { typeof(string) }
	);

	[HarmonyTranspiler]
	[HarmonyPatch(nameof(SisyphusPrime.Enrage))]
	[HarmonyPatch(nameof(SisyphusPrime.Taunt))]
	[HarmonyPatch(nameof(SisyphusPrime.Clap))]
	[HarmonyPatch(nameof(SisyphusPrime.StompCombo))]
	[HarmonyPatch(nameof(SisyphusPrime.UppercutCombo))]
	[HarmonyPatch(nameof(SisyphusPrime.ExplodeAttack))]
	private static IEnumerable<CodeInstruction> SisyphusPrime_SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize2(instructions, LocalizeSisyphusSubtitleMethodInfo);
	}

	public static string LocalizeSisyphusSubtitle(string input)
	{
		if (LanguageManager.IsEnglish)
			return input;

		var s = LanguageManager.CurrentLanguage?.subtitles;

		return (input switch
		{
			"Nice try!" => s.subtitles_sisyphusPrime_attack1,
			"BE GONE!" => s.subtitles_sisyphusPrime_attack2,
			"You can't escape!" => s.subtitles_sisyphusPrime_attack3,
			"DESTROY!" => s.subtitles_sisyphusPrime_attack4,
			"This will hurt." => s.subtitles_sisyphusPrime_attack5,
			"YES! That's it!" => s.subtitles_sisyphusPrime_phaseChange,
			_ => input,
		}).Or(input);
	}
}
