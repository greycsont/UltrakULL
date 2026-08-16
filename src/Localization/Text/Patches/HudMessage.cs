using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UltrakULL.json;
using UltrakULL;


namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(CutsceneSkipText),"Show")]
public static class CutsceneSkipTextPatch
{
    [HarmonyPostfix]
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

[HarmonyPatch(typeof(HudMessageReceiver),"SendHudMessage")]
public static class SendHudMessagePatch
{
    [HarmonyPrefix]
    public static void SendHudMessage_Prefix(ref string newmessage,ref string newinput,ref string newmessage2, int delay = 0, bool silent = false)
    {
        if (!LanguageManager.IsEnglish)
        {
            if ((newmessage != null) && (newmessage2 != null) && (newinput != null))
            {                
                newmessage = StringsParent.GetMessage(newmessage, newmessage2, newinput);
                newmessage2 = "";
                newinput = "";
            }
            else
            {
                newmessage = HUDMessages.GetHUDToolTip(newmessage);
            }
        }
    }
}

[HarmonyPatch(typeof(HudMessageReceiver),"SendHudMessage2")]
public static class SendHudMessage2Patch
{
    [HarmonyPrefix]
    public static void SendHudMessage2_Prefix(ref string format, ref string[] newinputs, int delay, bool silent, ref bool inputBeenProcessed, bool automaticTimer)
    {
        if (!LanguageManager.IsEnglish
            && format != null
            && format.Contains("WARNING:")
            && format.Contains("free fall"))
        {
            // {0} {1}
            format = LevelStrings.FreeFallWarning();
        }
    }
}

[HarmonyPatch(typeof(HudMessageReceiver))]
public static class ShowHudMessageLocalizeInputsPatch
{
    [HarmonyPatch(nameof(HudMessageReceiver.ShowHudMessage))] [HarmonyPrefix]
    private static void TranslateInputs(ref string[] ___inputs, ref bool ___inputPreProcessed)
    {
        if (___inputs == null || ___inputs.Length == 0)
            return;

        for (int i = 0; i < ___inputs.Length; i++)
            ___inputs[i] = InputNames.Localize(___inputs[i]);
    }
}