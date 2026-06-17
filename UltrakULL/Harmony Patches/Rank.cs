using HarmonyLib;
using System;
using System.Collections.Generic;
using UltrakULL.json;
using TMPro;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch]
public static class RankPatch
{
	static bool enablepatchSetRank = true;
	[HarmonyPatch(typeof(FinalRank), nameof(FinalRank.SetRank))] [HarmonyPrefix]
	public static void FinalRank_SetRankPatch(FinalRank __instance, ref string rank)
	{
		try
		{
			if (!enablepatchSetRank) { return; }
			Logging.Info("CALLED SET RANK :D");
			Logging.Info(rank[16].ToString());

			rank = RankUtil.LocalizeRankLetter(rank);
		}
		catch (Exception e)
		{
			Logging.Warn("Failed to Patch SetRank :(");
			Logging.Warn(e.Message);
			enablepatchSetRank = false;
			return;
		}
	}

	[HarmonyPatch(typeof(StatsManager), nameof(StatsManager.GetRanks))] [HarmonyPostfix]
	public static void StatsManager_GetRanksPatch(FinalRank __instance, ref string __result)
	{
		try
		{
			__result = RankUtil.LocalizeRankLetter(__result);
		}
		catch (Exception e)
		{
			Logging.Warn("Failed to Patch GetRanks :(");
			Logging.Warn(e.ToString());
			return;
		}
	}

	static bool enableLevelSelectfix = true;
	[HarmonyPatch(typeof(LevelSelectPanel), nameof(LevelSelectPanel.CheckScore))] [HarmonyPostfix]
	public static void Postfix(LevelSelectPanel __instance)
	{
		try
		{
			TextMeshProUGUI componentInChildren = __instance.transform.Find("Stats").Find("Rank").GetComponentInChildren<TextMeshProUGUI>();
			componentInChildren.text = RankUtil.LocalizeRankLetter(componentInChildren.text);
		}
		catch (Exception e)
		{
			Logging.Warn("Failed to Patch Level Menu :(");
			if (LanguageManager.CurrentLanguage.ranks == null)
			{ Logging.Warn("Category \"Ranks\" is missing from the language file!"); return; }
			Logging.Warn(e.ToString());
			enableLevelSelectfix = false;
			return;
		}
	}

}

public static class RankUtil
{
	private static readonly Dictionary<char, Func<Rank, string>> rankLetterMap = new()
	{
		['P'] = r => r.rank_letter_p,
		['C'] = r => r.rank_letter_c,
		['B'] = r => r.rank_letter_b,
		['A'] = r => r.rank_letter_a,
		['S'] = r => r.rank_letter_s,
		['D'] = r => r.rank_letter_d,
	};

	public static string LocalizeRankLetter(string rank)
	{
		if (rank.Length < 16 || !rankLetterMap.TryGetValue(rank[15], out Func<Rank, string> getter))
			return rank;

		string replacement = getter(LanguageManager.CurrentLanguage.ranks) ?? "_";
		char[] chars = rank.ToCharArray();
		chars[15] = replacement[0];
		return new string(chars);
	}

	// Maps the game's numeric rank (as passed to RankHelper.GetRankLetter) to its localized field.
	private static readonly Dictionary<int, Func<Rank, string>> rankValueMap = new()
	{
		[12] = r => r.rank_letter_p,
		[1] = r => r.rank_letter_c,
		[2] = r => r.rank_letter_b,
		[3] = r => r.rank_letter_a,
		[4] = r => r.rank_letter_s,
		[5] = r => r.rank_letter_s,
		[6] = r => r.rank_letter_s,
	};

	public static string LocalizeRank(int rank)
	{
		if (rank < 0)
			return null;

		Func<Rank, string> getter = rankValueMap.TryGetValue(rank, out Func<Rank, string> g) ? g : r => r.rank_letter_d;
		return getter(LanguageManager.CurrentLanguage.ranks);
	}

}