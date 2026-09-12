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

        var angry = LanguageManager.Current.angry;

        __instance.currentUi.gameObject.Localize<Text>(LanguageManager.CurrentLanguage.frontend.difficulty_title, path:["DifficultyText"]);

        __instance.currentUi.gameObject.Localize<Text>(angry.rootPanel.gamemode, path:["GamemodeText"]);
        
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

        var gamemodeDropdown = __instance.currentUi.gamemodeList;
        foreach (var mode in gamemodeDropdown.options)
        {
            var translatedMode = mode.text switch
            {
                "None" => angry.category.none,
                "No Monsters" => angry.category.noMonsters,
                "No Monsters/Weapons" => angry.category.noMonstersAndWeapons,
                _ => mode.text,
            };

            mode.text = translatedMode.Or(mode.text);
        }


    }
}
