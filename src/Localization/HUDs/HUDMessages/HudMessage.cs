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
        Console.WriteLine(___txt.text);
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
        if (LanguageManager.IsEnglish || newmessage == null)
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

        if (format.Contains("WARNING:") && format.Contains("free fall"))
        {
            format = LevelStrings.FreeFallWarning();
            return;
        }

        var input = newinputs is { Length: > 0 } ? newinputs[0] : null;
        var translated = HudMessageStrings.GetMessage(format, "", input);
        if (translated != format)
        {
            format = translated;
            newinputs = null;
        }
    }

    [HarmonyPatch(nameof(HudMessageReceiver.ShowHudMessage))] [HarmonyPrefix]
    private static void TranslateInputs(ref string[] ___inputs, ref bool ___inputPreProcessed)
    {
        if (___inputs == null || ___inputs.Length == 0)
            return;

        for (int i = 0; i < ___inputs.Length; i++)
            ___inputs[i] = InputNames.Localize(___inputs[i]);
    }
}