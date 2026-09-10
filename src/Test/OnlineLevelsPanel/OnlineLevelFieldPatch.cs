using HarmonyLib;
using AngryLevelLoader.Fields;
using TMPro;
using UltrakULL.json;
using UnityEngine.UI;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER, "AngryLevelLoader.Managers.ConfigManager", "InitializeConfig")]
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

    [HarmonyPatch(nameof(OnlineLevelField.SearchKeywords), methodType: MethodType.Setter)] [HarmonyPostfix]
    public static void LocalizeOnlineLevelFieldTitle(OnlineLevelField __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (__instance.currentUi == null) return;

        var onlineLevel = LanguageManager.Current.angry.onlineLevel;
        var status = LanguageManager.Current.angry.bundleStatus;

        var t = __instance.currentUi.infoText.text;
        t = t.Replace("<color=red>(OUTDATED/LOCKED)</color>", $"<color=red>{onlineLevel.locked}</color>");
        t = t.Replace("Author: ", $"{onlineLevel.author}");
        t = t.Replace("Size: ", $"{onlineLevel.size}");

        __instance.currentUi.infoText.text = t;
    }

    [HarmonyPatch(nameof(OnlineLevelField.GetStatusString))] [HarmonyPostfix]
    public static void LocalizeStatusString(ref string __result)
    {
        if (LanguageManager.IsEnglish) return;

        var status = LanguageManager.Current.angry.bundleStatus;
        var onlineLevel = LanguageManager.Current.angry.onlineLevel;

        __result = __result switch
        {
            "<color=red><b>Network error</b></color>"     => $"<color=red><b>{onlineLevel.networkError}</b></color>",
            "<color=red><b>Validation error</b></color>"  => $"<color=red><b>{onlineLevel.validationError}</b></color>",
            "<color=red><b>File was modified</b></color>" => $"$<color=red><b>{onlineLevel.fileWasModified}</b></color>",
            "<color=red><b>Locked</b></color>"            => $"<color=red><b>{onlineLevel.locked}</b></color>",
            "<color=red>Not installed</color>"            => $"<color=red>{status.notInstalled}</color>",
            "<color=#00FFFF>Update available</color>"     => $"<color=#00FFFF>{status.updateAvailable}</color>",
            "<color=#00FF00>Installed</color>"            => $"<color=#00FF00>{status.installed}</color>",
            _ => __result,
        };
    }
}
