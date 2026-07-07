using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(SisyphusPrime))]
public class SisyphusPrimeSubtitlesSwap
{
	private const int LdstrInstructionOffset = 3;

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(SisyphusPrime), "Enrage")]
	[HarmonyPatch(typeof(SisyphusPrime), "Taunt")]
	[HarmonyPatch(typeof(SisyphusPrime), "Clap")]
	[HarmonyPatch(typeof(SisyphusPrime), "StompCombo")]
	[HarmonyPatch(typeof(SisyphusPrime), "UppercutCombo")]
	[HarmonyPatch(typeof(SisyphusPrime), "ExplodeAttack")]
	private static IEnumerable<CodeInstruction> SisyphusPrime_SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize(instructions);
	}
}
