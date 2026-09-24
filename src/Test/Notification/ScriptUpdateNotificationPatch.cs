using UnityEngine.UI;
using AngryLevelLoader.Notifications;
using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(ScriptUpdateNotification))]
public static class ScriptUpdateNotificationPatch
{
    [HarmonyPatch(nameof(ScriptUpdateNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(ScriptUpdateNotification __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!LanguageManager.IsAngryTranslationLoaded) return;
        
        var ui = __instance.ui;

        ui.gameObject.Localize<Text>("脚本更新", path: ["ConcretePanel", "Text (1)"]);
        ui.cancel.gameObject.Localize<Text>("取消", path: ["Text"]);
        ui.update.gameObject.Localize<Text>("更新", path: ["Text"]);
        ui.continueButton.gameObject.Localize<Text>("继续", path: ["Text"]);
    }
}
