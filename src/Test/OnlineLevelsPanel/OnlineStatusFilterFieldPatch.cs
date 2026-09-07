using HarmonyLib;
using AngryLevelLoader.Fields;
using TMPro;
using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(OnlineStatusFilterField))]
public static class OnlineStatusFilterFieldPatch
{
    [HarmonyPatch(nameof(OnlineStatusFilterField.OnCreateUI))] [HarmonyPostfix]
    public static void LocalizeOnlineStatusFilter(OnlineStatusFilterField __instance)
    {
        if (LanguageManager.IsEnglish) return;
        var status = LanguageManager.Current?.angry?.bundleStatus;

        __instance.currentUi.installed.GetComponentInChildren<TMP_Text>(true).Localize(status.installed);
        __instance.currentUi.notInstalled.GetComponentInChildren<TMP_Text>(true).Localize(status.notInstalled);
        __instance.currentUi.updateAvailable.GetComponentInChildren<TMP_Text>(true).Localize(status.updateAvailable);
    }
}
