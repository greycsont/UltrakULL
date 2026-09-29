using UnityEngine.UI;
using AngryLevelLoader.Notifications;
using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(AngryLevelLoader.Notifications.ScriptUpdateNotification))]
public static class ScriptUpdateNotificationPatch
{
    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.ScriptUpdateNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(AngryLevelLoader.Notifications.ScriptUpdateNotification __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!LanguageManager.IsAngryTranslationLoaded) return;
        
        var ui = __instance.ui;

        var scriptUpdateNotification = LanguageManager.Current.angry.angryUi.notifications.scriptUpdateNotification;

        ui.gameObject.Localize<Text>(scriptUpdateNotification.header, path: ["ConcretePanel", "Text (1)"]);
        ui.cancel.gameObject.Localize<Text>(scriptUpdateNotification.b_cancel, path: ["Text"]);
        ui.update.gameObject.Localize<Text>(scriptUpdateNotification.b_update, path: ["Text"]);
        ui.continueButton.gameObject.Localize<Text>(scriptUpdateNotification.b_continue, path: ["Text"]);
    }
}
