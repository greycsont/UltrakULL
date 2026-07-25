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
		return SubtitleLocalizer.InjectLocalize(instructions);
	}
}
