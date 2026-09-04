using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UltrakULL.json;
using UltrakULL;


namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(CutsceneSkipText))]
public static class CutsceneSkipTextPatch
{
    [HarmonyPatch(nameof(CutsceneSkipText.Show))] [HarmonyPostfix]
    public static void CutsceneSkipText_Patch(CutsceneSkipText __instance, ref TMP_Text ___txt)
    {
        //Need to disable the TextOverride component. Slightly hacky but we can't access TextOverride directly.
        Component[] test = __instance.GetComponents(typeof(Component));
        Behaviour bhvr = (Behaviour)test[3];
        bhvr.enabled = false;
        ___txt.text = LanguageManager.CurrentLanguage.misc.pressToSkip;
    }
}

[HarmonyPatch(typeof(HudMessageReceiver))]
public static class SendHudMessagePatch
{
    /// <summary>
    /// Development history trivia: 
    /// SendHudMessage2 was added by me because we needed a way to support 
    ///   multiple button prompts in one message (for the final boss of Fraud) 
    /// 
    /// but the old SendHudMessage system didn't support that. 
    /// We didn't have time to go and update all the old messages to a new system, 
    /// so this new one was added on top
    /// 
    /// --Zombie
    /// </summary>
    [HarmonyPatch(nameof(HudMessageReceiver.SendHudMessage))] [HarmonyPrefix]
    public static bool SendHudMessage_Prefix(HudMessageReceiver __instance, ref string newmessage, ref string newinput, ref string newmessage2, int delay, bool silent, bool inputBeenProcessed, bool automaticTimer)
    {
        if (LanguageManager.IsEnglish)
            return true;

        var format = string.IsNullOrEmpty(newmessage2) ? newmessage : newmessage + "{0}" + newmessage2;
        var inputs = string.IsNullOrEmpty(newinput) ? null : new[] { newinput };

        __instance.SendHudMessage2(format, inputs, delay, silent, inputBeenProcessed, automaticTimer);
        return false;
    }

    [HarmonyPatch(nameof(HudMessageReceiver.SendHudMessage2))] [HarmonyPrefix]
    public static void SendHudMessage2_Prefix(ref string format, ref string[] newinputs, int delay, bool silent, ref bool inputBeenProcessed, bool automaticTimer)
    {
        if (LanguageManager.IsEnglish)
            return;
        var translated = HudMessageStrings.GetMessage(format);

        format = translated.Or(format);
    }

    /// <summary>
    /// This patch'll work after change the current way to translate the HUDMessage
    /// aka let the translate wrote {0} by there own
    /// </summary>
    [HarmonyPatch(nameof(HudMessageReceiver.ShowHudMessage))] [HarmonyPrefix]
    private static void TranslateInputs(HudMessageReceiver __instance)
    {
        if (__instance.inputs == null || __instance.inputs.Length == 0)
            return;

        for (int i = 0; i < __instance.inputs.Length; i++)
            __instance.inputs[i] = InputNames.Localize(__instance.inputs[i]);
    }
}