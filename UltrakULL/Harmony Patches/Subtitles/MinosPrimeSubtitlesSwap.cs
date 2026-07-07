using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(MinosPrime))]
public class MinosPrimeSubtitlesSwap
{
	[HarmonyTranspiler]
	[HarmonyPatch(typeof(MinosPrime), "Update")]
	[HarmonyPatch(typeof(MinosPrime), "Combo")]
	[HarmonyPatch(typeof(MinosPrime), "Boxing")]
	[HarmonyPatch(typeof(MinosPrime), "RiderKick")]
	[HarmonyPatch(typeof(MinosPrime), "DropAttack")]
	[HarmonyPatch(typeof(MinosPrime), "Dropkick")]
	[HarmonyPatch(typeof(MinosPrime), "Enrage")]
	private static IEnumerable<CodeInstruction> MinosPrime_SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize(instructions);
	}
}
