using HarmonyLib;
using AngryLevelLoader.Fields;
using TMPro;
using UltrakULL.json;
using UnityEngine.UI;

namespace UltrakULL;

[PatchForMod("com.eternalUnion.angryLevelLoader", "AngryLevelLoader.Managers.ConfigManager", "InitializeConfig")]
[HarmonyPatch(typeof(OnlineLevelField))]
public static class OnlineLevelFieldPatch
{
    [HarmonyPatch(nameof(OnlineLevelField.OnCreateUI))] [HarmonyPostfix]
    public static void LocalizeOnlineLevelListPanel(OnlineLevelField __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!__instance.inited) return;

        var onlineLevel = LanguageManager.Current.angry.onlineLevel;

        __instance.currentUi.changelog.GetComponentInChildren<Text>(true).Localize(onlineLevel.changelog);
        __instance.currentUi.update.GetComponentInChildren<Text>(true).Localize(onlineLevel.update);
        __instance.currentUi.install.GetComponentInChildren<Text>(true).Localize(onlineLevel.install);
    }
}
