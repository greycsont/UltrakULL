using HarmonyLib;
using System;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(LevelNameFinder), "OnEnable")]
    public static class LevelNameFinderTranslation
    {
        [HarmonyPostfix]
        public static void OnEnable_Postfix(LevelNameFinder __instance, TMP_Text ___txt2)
        {
            if (isUsingEnglish())
                return;

            if (___txt2 == null)
                return;

            if (GetPath(__instance.transform).Contains("FinishCanvas"))
                return;

            ___txt2.text = "<color=red>" +
                           LanguageManager.CurrentLanguage.shop.shop_returningTo +
                           ":</color>\n" +
                           LevelNames.GetLevelName(__instance.otherLevelNumber);
        }
        private static string GetPath(Transform current)
        {
            string path = current.name;

            while (current.parent != null)
            {
                current = current.parent;
                path = current.name + "/" + path;
            }

            return path;
        }
    }
}
