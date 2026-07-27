using System.Text.RegularExpressions;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(IntermissionController))]
public static class LocalizeIntermission
{
    [HarmonyPatch(nameof(IntermissionController.Start))] [HarmonyPrefix]
    public static bool Start_MyPatch(IntermissionController __instance, ref string ___preText, ref string ___fullString, ref Text ___txt)
    {
        /*
        In the original, there is no ▼ (wait input) between act2_intermission_fourth8 and act2_intermission_fourth9.
        Therefore, I disable the update stop for English(to ensure that the behavior is the same between English and other languages.
        If this option is not suitable, remove the ▼ between act2_intermission_fourth8 and act2_intermission_fourth9)
        */

        //if (LanguageManager.IsEnglish) return true; 

        ___txt = __instance.GetComponent<Text>();
        ___txt.verticalOverflow = VerticalWrapMode.Overflow;
        ___fullString = ___txt.text;
        ___txt.text = "";

        IntermissionStrings intStrings = new IntermissionStrings();
        ___fullString = intStrings.GetIntermissionString(___fullString);
        ___txt.text = ___fullString;

        if (GetCurrentSceneName() == "Level 2-S")
        {
            string openingTag = "<color=grey>";
            string closingTag = "</color>";
            string mirageName = Regex.Replace(___preText, @"<[^>]*>", "");

            switch (mirageName)
            {
                case "JUST SOMEONE:":
                    ___preText = $"{LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName1}:";
                    break;
                case "THE PRETTIEST GIRL IN TOWN:":
                    ___preText = $"{LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName2}:";
                    break;
                case "MIRAGE:":
                    ___preText = $"{LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName3}:";
                    break;
            }
        }

        return true;
    }
}
