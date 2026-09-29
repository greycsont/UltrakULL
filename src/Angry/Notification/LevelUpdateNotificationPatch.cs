using System.Collections.Generic;
using HarmonyLib;
using AngryLevelLoader.Fields;
using UltrakULL.json;
using System.Collections;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using AngryUiComponents;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
using System.IO;

namespace UltrakULL;

[HarmonyPatch(typeof(AngryLevelLoader.Notifications.LevelUpdateNotification))]
public static class LevelUpdateNotificationPatch
{

    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.LevelUpdateNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(ref RectTransform panel)
    {
        if (LanguageManager.IsEnglish) return;
        if (!LanguageManager.IsAngryTranslationLoaded) return;

        var ui = panel.GetComponentInChildren<AngryLevelUpdateNotificationComponent>(true);
        if (ui == null) return;

        var levelUpdateNotification = LanguageManager.Current.angry.angryUi.notifications.levelUpdateNotification;
        ui.gameObject.Localize<Text>(levelUpdateNotification.header, path: ["ConcretePanel", "Text (1)"]);
        ui.cancel.gameObject.Localize<Text>(levelUpdateNotification.b_cancel, path: ["Text"]);
        ui.update.gameObject.Localize<Text>(levelUpdateNotification.b_update, path: ["Text"]);
    }
}
