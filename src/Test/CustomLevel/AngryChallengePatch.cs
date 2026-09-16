using HarmonyLib;
using AngryLevelLoader.Patches;
using UltrakULL.json;
using TMPro;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(StatsManager_SendInfo_Patch))]
public static class AngryChallengePatch
{
    [HarmonyPatch(nameof(StatsManager_SendInfo_Patch.Postfix))] [HarmonyPostfix]
    public static void PostfixPatch()
    {
        if (LanguageManager.IsEnglish) return;
        if (!AngrySceneTracker.InAngryLevel) return;

        FinalRank.Instance.gameObject.Localize<TextMeshProUGUI>(AngryLevelText.Challenge(),
            path: ["Challenge", "ChallengeText"]);
    }
}