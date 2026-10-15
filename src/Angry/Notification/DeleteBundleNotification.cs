using UnityEngine.UI;
using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(AngryLevelLoader.Notifications.DeleteBundleNotification))]
public static class DeleteBundleNotificationPatch
{
    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.DeleteBundleNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(AngryLevelLoader.Notifications.DeleteBundleNotification __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!LanguageManager.IsAngryTranslationLoaded) return;
        var ui = __instance.ui;

        var deleteBundleNotification = LanguageManager.Current.angry.angryUi.notifications.deleteBundleNotification;

        ui.deleteButton.onClick.AddListener(() =>
        {
            ui.body.text = deleteBundleNotification.b_deletingBundle.Or(ui.body.text);
        });

        ui.gameObject.Localize<Text>(deleteBundleNotification.header, path: ["Panel", "Header"]);
        ui.cancelButton.gameObject.Localize<Text>(deleteBundleNotification.b_cancel, path: ["Text"]);

        ui.body.Localize("{0}".FormatWith(string.Format(deleteBundleNotification.body, __instance.container.BundleName)));
    }
}

[HarmonyPatch(typeof(AngryLevelLoader.Notifications.DeleteBundleNotification.DeleteButtonComponent))]
public static class DeleteBundleComponentPatch
{
    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.DeleteBundleNotification.DeleteButtonComponent.Update))] [HarmonyPostfix]
    public static void LocalizeDeleteButton(AngryLevelLoader.Notifications.DeleteBundleNotification.DeleteButtonComponent __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!LanguageManager.IsAngryTranslationLoaded) return;
        var ui = __instance.ui;

        var deleteBundleNotification = LanguageManager.Current.angry.angryUi.notifications.deleteBundleNotification;

        if (__instance.timeRemaining == 0f)
        {
            __instance.ui.deleteText.text = deleteBundleNotification.b_delete.Or(__instance.ui.deleteText.text);
        }
        else
        {
            __instance.ui.deleteText.text = "{0}".FormatWith(string.Format(deleteBundleNotification.deleteWithTimeRemaining, (int)__instance.timeRemaining))
                .Or(__instance.ui.deleteText.text);
        }
    }
}
