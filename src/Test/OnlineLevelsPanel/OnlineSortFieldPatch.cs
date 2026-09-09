using HarmonyLib;
using AngryLevelLoader.Fields;
using UltrakULL.json;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(OnlineSortField))]
public static class OnlineSortFieldPatch
{
    [HarmonyPatch(nameof(OnlineSortField.OnCreateUI))] [HarmonyPostfix]
    public static void LocalizeButtons(OnlineSortField __instance)
    {
        if (LanguageManager.IsEnglish) return;
        var sort = LanguageManager.Current?.angry?.sortingOption;

        __instance.currentUi.nameText.text = sort.name;
        __instance.currentUi.authorText.text = sort.author;
        __instance.currentUi.lastUpdateText.text = sort.lastUpdate;
        __instance.currentUi.votesText.text = sort.votes;
    }
}
