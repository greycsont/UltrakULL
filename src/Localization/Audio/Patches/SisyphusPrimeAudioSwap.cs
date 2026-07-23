using BepInEx.Configuration;
using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

[HarmonyPatch(typeof(SisyphusPrime), "Start")]
public class SisyphusPrimeAudioSwap
{
    [HarmonyPostfix]
    public static void SisyphusPrimeAudioSwapPatch(ref SisyphusPrime __instance)
    {
        if (LanguageManager.configFile.Bind<string>("General", "activeDubbing", "False", (ConfigDescription)null).Value == "False" || isUsingEnglish())
            return;

        ApplyAudioSwap(__instance);
    }

    private static void ApplyAudioSwap(SisyphusPrime __instance)
    {
        if (__instance == null)
            return;

        string folder = AudioSwapper.SpeechFolder + "sisyphusPrime\\";

        AudioClip[] begoneAttacks = __instance.clapVoice;
        for (int i = 0; i < begoneAttacks.Length; i++)
            begoneAttacks[i] = AudioSwapper.SwapClipWithFile(begoneAttacks[i], folder + "sisyphusBegone" + (i + 1));

        AudioClip[] thisWillHurtAttack = __instance.explosionVoice;
        for (int i = 0; i < thisWillHurtAttack.Length; i++)
            thisWillHurtAttack[i] = AudioSwapper.SwapClipWithFile(thisWillHurtAttack[i], folder + "sisyphusThisWillHurt");

        AudioClip[] grunt = __instance.hurtVoice;
        for (int i = 0; i < grunt.Length; i++)
            grunt[i] = AudioSwapper.SwapClipWithFile(grunt[i], folder + "sisyphusGrunt");

        AudioClip[] stompAttacks = __instance.stompComboVoice;
        for (int i = 0; i < stompAttacks.Length; i++)
            stompAttacks[i] = AudioSwapper.SwapClipWithFile(stompAttacks[i], folder + "sisyphusYouCantEscape" + (i + 1));

        AudioClip[] taunts = __instance.tauntVoice;
        for (int i = 0; i < taunts.Length; i++)
            taunts[i] = AudioSwapper.SwapClipWithFile(taunts[i], folder + "sisyphusNiceTry" + (i + 1));

        AudioClip[] uppercutAttacks = __instance.uppercutComboVoice;
        for (int i = 0; i < uppercutAttacks.Length; i++)
            uppercutAttacks[i] = AudioSwapper.SwapClipWithFile(uppercutAttacks[i], folder + "sisyphusDestroy" + (i + 1));

        //Phase change
        __instance.phaseChangeVoice = AudioSwapper.SwapClipWithFile(__instance.phaseChangeVoice, folder + "sisyphusYesThatsIt");
    }
}
