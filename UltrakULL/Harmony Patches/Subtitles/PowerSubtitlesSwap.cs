using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.Subtitles;

[NeedRework]
[HarmonyPatch(typeof(PowerVoiceController))]
public static class PowerSubtitlesSwap
{

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Intro")]
	private static IEnumerable<CodeInstruction> Intro_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceSubtitleInMethod(instructions, "power_intro");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Enrage")]
	private static IEnumerable<CodeInstruction> Enrage_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceSubtitleInMethod(instructions, "power_enrage");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Taunt")]
	private static IEnumerable<CodeInstruction> Taunt_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceSubtitleInMethod(instructions, "power_taunt");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "CheapShot")]
	private static IEnumerable<CodeInstruction> CheapShot_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceSubtitleInMethod(instructions, "power_cheapShot");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Rapier")]
	private static IEnumerable<CodeInstruction> Rapier_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceFixedSubtitle(instructions, "power_rapier");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Greatsword")]
	private static IEnumerable<CodeInstruction> Greatsword_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceFixedSubtitle(instructions, "power_greatsword");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Spear")]
	private static IEnumerable<CodeInstruction> Spear_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceFixedSubtitle(instructions, "power_spear");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "SpearThrow")]
	private static IEnumerable<CodeInstruction> SpearThrow_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceFixedSubtitle(instructions, "power_spearThrow");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "Glaive")]
	private static IEnumerable<CodeInstruction> Glaive_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceFixedSubtitle(instructions, "power_glaive");
	}

	[HarmonyTranspiler]
	[HarmonyPatch(typeof(PowerVoiceController), "GlaiveThrow")]
	private static IEnumerable<CodeInstruction> GlaiveThrow_Transpile(IEnumerable<CodeInstruction> instructions)
	{
		return ReplaceFixedSubtitle(instructions, "power_glaiveThrow");
	}

	private static IEnumerable<CodeInstruction> ReplaceSubtitleInMethod(IEnumerable<CodeInstruction> instructions, string baseKey)
	{
		List<CodeInstruction> list = new List<CodeInstruction>(instructions);

		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].opcode == OpCodes.Ldstr && list[i].operand is string text)
			{
				int variantIndexFromOriginal = GetVariantIndexFromOriginal(text);
				string text2 = $"subtitles_{baseKey}_{variantIndexFromOriginal}";
				string subtitlesFieldSafe = GetSubtitlesFieldSafe(text2);
				if (!string.IsNullOrEmpty(subtitlesFieldSafe) && subtitlesFieldSafe != text)
				{

					list[i].operand = subtitlesFieldSafe;

					num++;
				}
			}
		}

		return list;
	}

	private static IEnumerable<CodeInstruction> ReplaceFixedSubtitle(IEnumerable<CodeInstruction> instructions, string baseKey)
	{
		List<CodeInstruction> list = new List<CodeInstruction>(instructions);

		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (!(list[i].opcode == OpCodes.Ldstr) || !(list[i].operand is string text))
			{
				continue;
			}

			if ((!(baseKey == "power_spearThrow") || !(text != "Over here!")) && (!(baseKey == "power_glaiveThrow") || !(text != "Take THIS!")))
			{
				string subtitlesFieldSafe = GetSubtitlesFieldSafe("subtitles_" + baseKey);
				if (!string.IsNullOrEmpty(subtitlesFieldSafe) && subtitlesFieldSafe != text)
				{

					list[i].operand = subtitlesFieldSafe;

					num++;
				}
			}
		}

		return list;
	}

	private static int GetVariantIndexFromOriginal(string originalText)
	{
		if (string.IsNullOrEmpty(originalText))
			return 0;

		switch (originalText)
		{
			case "Be afraid, machine.":
				return 0;
			case "Here shall be your grave.":
				return 1;
			case "It is over, machine!":
				return 2;
			case "Surrender or perish!":
				return 3;
			case "Lay down and die!":
				return 4;
			case "Bastard!":
				return 0;
			case "You piece of SHIT!":
				return 1;
			case "Just DIE already!":
				return 2;
			case "Why won't you die!?":
				return 3;
			case "God DAMN it!":
				return 4;
			case "This lowly thing could never have bested him!":
				return 0;
			case "An inconvenience at best.":
				return 1;
			case "This is a waste of my time!":
				return 2;
			case "Just another worthless object.":
				return 3;
			case "PAY ATTENTION!":
				return 0;
			case "Wait your TURN!":
				return 1;
			case "WRONG TARGET!":
				return 2;
			default:
				Logging.Warn("[PowerTranspiler] GetVariantIndexFromOriginal: UNKNOWN string '" + originalText + "'");
				return 0;
		}
	}

	private static string GetSubtitlesFieldSafe(string key)
	{
		try
		{
			var a = LanguageManager.CurrentLanguage?.subtitles;
			if (a == null)
			{
				Logging.Warn("[PowerSubtitlesSwap] Key is null in CurrentLanguage. Using fallback.");
				return null;
			}
			FieldInfo field = a.GetType().GetField(key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				Logging.Warn("[PowerSubtitlesSwap] Field '" + key + "' not found in Subtitles. Using fallback.");
				return null;
			}
			string text = field.GetValue(a) as string;

			return text;
		}
		catch (Exception ex)
		{
			Logging.Error("[PowerSubtitlesSwap] Exception in GetSubtitlesFieldSafe for key '" + key + "': " + ex.Message);
			return null;
		}
	}

}
