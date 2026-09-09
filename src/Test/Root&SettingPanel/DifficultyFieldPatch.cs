using HarmonyLib;
using AngryLevelLoader.Fields;
using UltrakULL.json;
using UnityEngine.UI;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(DifficultyField))]
public static class DifficultyFieldPatch
{
    [HarmonyPatch(nameof(DifficultyField.OnCreateUI))] [HarmonyPostfix]
    public static void LocalizeButtons(DifficultyField __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!__instance.inited) return;

        __instance.currentUi.gameObject.Localize<Text>(LanguageManager.CurrentLanguage.frontend.difficulty_title, path:["DifficultyText"]);

        var difficultyDropdown = __instance.currentUi.difficultyList;

        foreach (var option in difficultyDropdown.options)
        {
            var translatedDiff = option.text switch
            {
                "HARMLESS" => LanguageManager.CurrentLanguage.frontend.difficulty_harmless,
                "LENIENT" => LanguageManager.CurrentLanguage.frontend.difficulty_lenient,
                "STANDARD" => LanguageManager.CurrentLanguage.frontend.difficulty_standard,
                "VIOLENT" => LanguageManager.CurrentLanguage.frontend.difficulty_violent,
                "BRUTAL" => LanguageManager.CurrentLanguage.frontend.difficulty_brutal,
                _ => option.text,
            };

            option.text = translatedDiff.Or(option.text);
        }


    }
}
