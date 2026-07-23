using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(PowerVoiceController))]
public static class PowerSubtitlesSwap
{

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Intro")]
	[HarmonyPatch(typeof(PowerVoiceController), "Enrage")]
	[HarmonyPatch(typeof(PowerVoiceController), "Taunt")]
	[HarmonyPatch(typeof(PowerVoiceController), "CheapShot")]
	[HarmonyPatch(typeof(PowerVoiceController), "Rapier")]
	[HarmonyPatch(typeof(PowerVoiceController), "Greatsword")]
	[HarmonyPatch(typeof(PowerVoiceController), "Spear")]
	[HarmonyPatch(typeof(PowerVoiceController), "SpearThrow")]
	[HarmonyPatch(typeof(PowerVoiceController), "Glaive")]
	[HarmonyPatch(typeof(PowerVoiceController), "GlaiveThrow")]
	private static IEnumerable<CodeInstruction> PowerSubtitlesSwap__SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize(instructions);
	}
}
