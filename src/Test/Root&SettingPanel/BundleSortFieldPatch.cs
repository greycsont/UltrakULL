using HarmonyLib;
using AngryLevelLoader.Fields;
using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(BundleSortField))]
public static class BundleSortFieldPatch
{
    [HarmonyPatch(nameof(BundleSortField.OnCreateUI))] [HarmonyPostfix]
    public static void LocalizeButtons(BundleSortField __instance)
    {
        var sort = LanguageManager.Current?.angry?.sortingOption;

        __instance.currentUi.nameText.text = sort.name;
        __instance.currentUi.authorText.text = sort.author;
        __instance.currentUi.lastUpdateText.text = sort.lastUpdate;
        __instance.currentUi.lastPlayedText.text = sort.lastPlayed;
    }
}
