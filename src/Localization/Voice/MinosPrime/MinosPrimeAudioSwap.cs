using HarmonyLib;
using System.IO;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;


namespace UltrakULL.Harmony_Patches.AudioSwaps;

[HarmonyPatch(typeof(MinosPrime), "Start")]
public class MinosPrimeAudioSwap
{
    [HarmonyPostfix]
    public static void MinosPrime_VoiceSwap(MinosPrime __instance)
    {
        if (Settings.activeDubbing.Value == false || LanguageManager.IsEnglish)
            return;

        AudioSwapper.WhenReady(() => ApplyVoiceSwap(__instance));
    }

    private static void ApplyVoiceSwap(MinosPrime __instance)
    {
        if (__instance == null)
            return;

        string minosPrimeFolder = Path.Combine(AudioSwapper.SpeechFolder, "minosPrime");

        //Rider Kick (Die)
        AudioClip[] minosPrimeKick = __instance.riderKickVoice;
        for (int x = 0; x < minosPrimeKick.Length; x++)
            minosPrimeKick[x] = AudioSwapper.SwapClipWithFile(minosPrimeKick[x], Path.Combine(minosPrimeFolder, "minosPrimeDie" + (x + 1)));

        //Dropkick (Judgement)
        AudioClip[] minosPrimeJudgement = __instance.dropkickVoice;
        for (int x = 0; x < minosPrimeJudgement.Length; x++)
            minosPrimeJudgement[x] = AudioSwapper.SwapClipWithFile(minosPrimeJudgement[x], Path.Combine(minosPrimeFolder, "minosPrimeJudgement" + (x + 1)));

        //Crush attack (Crush)
        AudioClip[] minosPrimeCrush = __instance.dropAttackVoice;
        for (int x = 0; x < minosPrimeCrush.Length; x++)
            minosPrimeCrush[x] = AudioSwapper.SwapClipWithFile(minosPrimeCrush[x], Path.Combine(minosPrimeFolder, "minosPrimeCrush" + (x + 1)));

        //Punches/Boxing (Thy end is now)
        AudioClip[] minosPrimePunch = __instance.boxingVoice;
        for (int x = 0; x < minosPrimePunch.Length; x++)
            minosPrimePunch[x] = AudioSwapper.SwapClipWithFile(minosPrimePunch[x], Path.Combine(minosPrimeFolder, "minosPrimeThyEndIsNow" + (x + 1)));

        //Combo (prepare thyself)
        AudioClip[] minosPrimeCombo = __instance.comboVoice;
        for (int x = 0; x < minosPrimeCombo.Length; x++)
            minosPrimeCombo[x] = AudioSwapper.SwapClipWithFile(minosPrimeCombo[x], Path.Combine(minosPrimeFolder, "minosPrimePrepareThyself" + (x + 1)));

        //Phase change
        __instance.phaseChangeVoice = AudioSwapper.SwapClipWithFile(__instance.phaseChangeVoice, Path.Combine(minosPrimeFolder, "minosPrimePhaseChange"));

        //Hurt
        AudioClip[] minosPrimeHurt = __instance.hurtVoice;
        for (int x = 0; x < minosPrimeHurt.Length; x++)
            minosPrimeHurt[x] = AudioSwapper.SwapClipWithFile(minosPrimeHurt[x], Path.Combine(minosPrimeFolder, "minosPrimeHurt" + (x + 1)));
    }
}
