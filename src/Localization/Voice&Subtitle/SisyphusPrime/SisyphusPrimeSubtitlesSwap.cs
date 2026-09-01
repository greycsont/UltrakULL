using System.Collections.Generic;
using HarmonyLib;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(SisyphusPrime))]
public class SisyphusPrimeSubtitlesSwap
{
	[HarmonyTranspiler]
	[HarmonyPatch(nameof(SisyphusPrime.Enrage))]
	[HarmonyPatch(nameof(SisyphusPrime.Taunt))]
	[HarmonyPatch(nameof(SisyphusPrime.Clap))]
	[HarmonyPatch(nameof(SisyphusPrime.StompCombo))]
	[HarmonyPatch(nameof(SisyphusPrime.UppercutCombo))]
	[HarmonyPatch(nameof(SisyphusPrime.ExplodeAttack))]
	private static IEnumerable<CodeInstruction> SisyphusPrime_SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize(instructions);
	}
}
