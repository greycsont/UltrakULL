using System.Collections.Generic;
using HarmonyLib;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(MinosPrime))]
public class MinosPrimeSubtitlesSwap
{
	[HarmonyTranspiler]
	[HarmonyPatch(nameof(MinosPrime.Update))]
	[HarmonyPatch(nameof(MinosPrime.Combo))]
	[HarmonyPatch(nameof(MinosPrime.Boxing))]
	[HarmonyPatch(nameof(MinosPrime.RiderKick))]
	[HarmonyPatch(nameof(MinosPrime.DropAttack))]
	[HarmonyPatch(nameof(MinosPrime.Dropkick))]
	[HarmonyPatch(nameof(MinosPrime.Enrage))]
	private static IEnumerable<CodeInstruction> MinosPrime_SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize(instructions);
	}
}
