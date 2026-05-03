using HarmonyLib;
using System.Linq;
using TMPro;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;


namespace UltrakULL.Harmony_Patches
{
    public class JukeboxPatch
    {
        [HarmonyPatch(typeof(UnlockCondition.HasCompletedLevelChallenge),"description",MethodType.Getter)]
        public class CybergrindJukeboxCompleteLevelChallengeRequirement
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteLevelRequirementPatch(ref UnlockCondition.HasCompletedLevelChallenge __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicCompleteChallengeRequirement + " " + GetMissionName.GetMissionNumberOnly(__instance.levelIndex);
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(UnlockCondition.HasSeenEnemy),"description",MethodType.Getter)]
        public class CybergrindJukeboxHasSeenEnemyRequirement
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteLevelRequirementPatch(ref UnlockCondition.HasSeenEnemy __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSeeEnemyRequirement;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(UnlockCondition.HasReachedLevel),"description",MethodType.Getter)]
        public class CybergrindJukeboxUnlockLevelRequirement
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxUnlockLevelRequirementPatch(ref UnlockCondition.HasReachedLevel __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlockLevelRequirement;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(UnlockCondition.HasCompletedLevel),"description",MethodType.Getter)]
        public class CybergrindJukeboxCompleteLevelRequirement
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteLevelRequirementPatch(ref UnlockCondition.HasCompletedLevel __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicCompleteLevelRequirement + " " +  GetMissionName.GetMissionNumberOnly(__instance.levelIndex);
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(UnlockCondition.HasCompletedSecretLevel),"description",MethodType.Getter)]
        public class CybergrindJukeboxCompleteSecretLevelRequirement
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteSecretLevelRequirementPatch(ref UnlockCondition.HasCompletedSecretLevel __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicCompleteLevelRequirement + " " + __instance.secretLevelIndex + "-S";
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(CustomPatterns), "Toggle")]
        public class CybergrindCustomPatternsToggle
        {
            [HarmonyPostfix]
            public static void Postfix(CustomPatterns __instance)
            {
                if (isUsingEnglish()) return;

                bool mode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
                TextMeshProUGUI btn = Traverse.Create(__instance).Field("stateButtonText").GetValue<TextMeshProUGUI>();

                btn.text = mode
                    ? LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButtonNot
                    : LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButton;

                btn.transform.root.GetComponentsInChildren<TextMeshProUGUI>(true)
                    .FirstOrDefault(t => t.name == "Warning Text")?
                    .gameObject.SetActive(!mode);
            }
        }
    }
}