using System.Collections.Generic;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(GabrielVoice), "Start")]
public static class GabrielSubtitlesSwap
{
	[HarmonyPostfix]
	public static void GabrielVoice_Start(ref GabrielVoice __instance, ref string[] ___taunts, ref string[] ___tauntsSecondPhase)
	{
		__instance.phaseChangeSubtitle = SubtitleLocalizer.Localize(__instance.phaseChangeSubtitle);
		for (int i = 0; i < ___taunts.Length; i++)
			___taunts[i] = SubtitleLocalizer.Localize(___taunts[i]);
		for (int i = 0; i < ___tauntsSecondPhase.Length; i++)
			___tauntsSecondPhase[i] = SubtitleLocalizer.Localize(___tauntsSecondPhase[i]);
		SubtitledAudioSourcesReplacer.ReplaceSubsAndAudio();
	}
}
