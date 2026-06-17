using HarmonyLib;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(RankHelper), nameof(RankHelper.GetRankLetter))]
public static class RankHelperPatch
{
	[HarmonyPostfix]
	public static void Patch(ref string __result, int rank)
	{
		__result = RankUtil.LocalizeRank(rank) ?? __result;
	}
}
