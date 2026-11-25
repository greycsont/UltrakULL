using UnityEngine.UI;
using AngryLevelLoader.Notifications;
using HarmonyLib;

using UltrakULL.json;
using System.Collections.Generic;
using System.Reflection;

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

/*
[HarmonyPatch(typeof(AngryLevelLoader.Notifications.ScriptUpdateNotification.ScriptUpdateProgressField))]
public static class ScriptUpdateProgressFieldPatch
{
    private static MethodInfo LocalizeStatusTextMethodInfo = AccessTools.Method(
        typeof(ScriptUpdateProgressFieldPatch),
        nameof(ScriptUpdateProgressFieldPatch.LocalizeStatusText),
        new[] { typeof(string) }
    );

    [HarmonyPatch(nameof(AngryLevelLoader.Notifications.ScriptUpdateNotification.ScriptUpdateProgressField.SetStatusText))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> SetStatusTextTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        var matcher = new CodeMatcher(instructions);

        while (true)
        {
            matcher.MatchForward(false,
                new CodeMatch(i => i.opcode == OpCodes.Ldstr 
                          && ((string)i.operand == "<b>GLOBAL</b>" || (string)i.operand == "<b>FRIENDS</b>"))
            );

            if (matcher.IsInvalid)
                break;

            matcher.Advance(1);
            matcher.Insert(new CodeInstruction(OpCodes.Call, LocalizeLeaderboardCategoryTitleMethodInfo));
        }

        return matcher.InstructionEnumeration();
    }

    private static string LocalizeStatusText(string input)
    {
        
    }
}
*/