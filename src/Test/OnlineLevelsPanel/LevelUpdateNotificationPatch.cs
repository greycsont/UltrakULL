using System.Collections.Generic;
using HarmonyLib;
using AngryLevelLoader.Fields;
using UltrakULL.json;
using AngryLevelLoader.Notifications;
using System.Collections;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using AngryUiComponents;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
using System.IO;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(LevelUpdateNotification))]
public static class LevelUpdateNotificationPatch
{

    [HarmonyPatch(nameof(LevelUpdateNotification.OnUI))] [HarmonyPostfix]
    public static void Localize(ref RectTransform panel)
    {
        if (LanguageManager.IsEnglish) return;

        var ui = panel.GetComponentInChildren<AngryLevelUpdateNotificationComponent>(true);
        if (ui == null) return;

        var onlineLevel = LanguageManager.Current.angry.onlineLevel;
        ui.gameObject.Localize<Text>(onlineLevel.changelog_header, path: ["ConcretePanel", "Text (1)"]);
        ui.cancel.gameObject.Localize<Text>(onlineLevel.changelog_cancel, path: ["Text"]);
        ui.update.gameObject.Localize<Text>(onlineLevel.changelog_update, path: ["Text"]);
    }
}
