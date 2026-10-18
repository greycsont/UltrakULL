using System;
using HarmonyLib;
using UltrakULL.json;
using System.Globalization;
using AngryUiComponents;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

namespace UltrakULL;

[HarmonyPatch(typeof(AngryLevelLoader.Notifications.LevelUpdateNotification))]
public static class LevelUpdateNotificationPatch
{

    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.LevelUpdateNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(AngryLevelLoader.Notifications.LevelUpdateNotification __instance, ref RectTransform panel)
    {
        if (LanguageManager.IsEnglish) return;
        if (!LanguageManager.IsAngryTranslationLoaded) return;

        var ui = panel.GetComponentInChildren<AngryLevelUpdateNotificationComponent>(true);
        if (ui == null) return;

        var levelUpdateNotification = LanguageManager.Current.angry.angryUi.notifications.levelUpdateNotification;
        ui.gameObject.Localize<Text>(levelUpdateNotification.header, path: ["ConcretePanel", "Text (1)"]);
        ui.cancel.gameObject.Localize<Text>(levelUpdateNotification.b_cancel, path: ["Text"]);
        ui.update.gameObject.Localize<Text>(levelUpdateNotification.b_update, path: ["Text"]);

        var updates = __instance.onlineInfo.Updates;
        var dateFormat = levelUpdateNotification.dateFormat.Or("MM/dd/yyyy");
        var builder = new StringBuilder();

        for (int i = updates.Count - 1; i >= 0; i--)
        {
            var updateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(updates[i].Date);
            var stamp = updateTime.ToString(dateFormat, CultureInfo.InvariantCulture);

            if (i == updates.Count - 1)
                builder.Append($"<color=#00FF00>{levelUpdateNotification.latestVersion.Or("Latest Version")}</color> <color=grey>({stamp})</color>");
            else if (updates[i].Hash != __instance.currentHash)
                builder.Append($"\n\n<color=#b2b2b2>{levelUpdateNotification.pastVersion.Or("Past Version")}</color> <color=grey>({stamp})</color>");
            else
                builder.Append($"\n\n<color=yellow>{levelUpdateNotification.currentVersion.Or("Current Version")}</color> <color=grey>({stamp})</color>");

            builder.Append("<size=18>\n");
            builder.Append(updates[i].Message.Replace(@"\n", "\n"));
            builder.Append("</size>");
        }

        ui.body.text = builder.ToString();
    }
}
