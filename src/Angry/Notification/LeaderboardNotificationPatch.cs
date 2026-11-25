using System.IO;
using HarmonyLib;
using UnityEngine.UI;

using UltrakULL.json;

namespace UltrakULL;

/*
[HarmonyPatch(typeof(AngryLevelLoader.Notifications.LeaderboardNotification))]
public static class LeaderboardNotificationPatch
{
    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.LeaderboardNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(AngryLevelLoader.Notifications.LeaderboardNotification __instance)
    {
        var currentUi = __instance.currentUi;

        var leaderboardNotificationTranslation = LanguageManager.Current.angry.angryUi.notifications.leaderboardNotification;

        currentUi.header.Localize(leaderboardNotificationTranslation.header.FormatWith(__instance.bundleName, __instance.levelName));

        currentUi.closeButton.gameObject.Localize<Text>(leaderboardNotificationTranslation.back,
            path: ["Text"]);

        currentUi.pageText.Localize<Text>(leaderboardNotificationTranslation.page,
            path: []);
    }
}
*/