using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;


namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(SceneHelper))]
public class LoadingTextPatch
{
    public static TextMeshProUGUI loadingText;
    
    public static void UpdateLoadingText()
    {
        if(loadingText != null)
        {
            loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
        }
    }

    /// <summary>
    /// This patch will active after scene loaded
    /// not when loading blocker enabled
    /// </summary>
    /// <param name="__instance"></param>
    [HarmonyPatch(nameof(SceneHelper.OnSceneLoaded))] [HarmonyPostfix]
    public static void LoadingTextPatch_Postfix(SceneHelper __instance)
    {
        if(isUsingEnglish()) return;

        loadingText = GetTextMeshProUGUI(FindDescendant(__instance.loadingBlocker,"Panel","Text"));
        loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
    }
}