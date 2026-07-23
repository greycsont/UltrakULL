using HarmonyLib;
using System.IO;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

[HarmonyPatch(typeof(MinosPrime), "Start")]
public class MinosPrimeAudioSwap
{
    [HarmonyPostfix]
    public static void MinosPrime_VoiceSwap(ref MinosPrime __instance)
    {
        if (LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value == "False" || isUsingEnglish())
            return;

        ApplyVoiceSwap(__instance);
    }

    private static void ApplyVoiceSwap(MinosPrime __instance)
    {
        if (__instance == null)
            return;

        string minosPrimeFolder = AudioSwapper.SpeechFolder + "minosPrime" + Path.DirectorySeparatorChar;

        //Rider Kick (Die)
        AudioClip[] minosPrimeKick = __instance.riderKickVoice;
        for (int x = 0; x < minosPrimeKick.Length; x++)
            minosPrimeKick[x] = AudioSwapper.SwapClipWithFile(minosPrimeKick[x], minosPrimeFolder + "minosPrimeDie" + (x + 1));

        //Dropkick (Judgement)
        AudioClip[] minosPrimeJudgement = __instance.dropkickVoice;
        for (int x = 0; x < minosPrimeJudgement.Length; x++)
            minosPrimeJudgement[x] = AudioSwapper.SwapClipWithFile(minosPrimeJudgement[x], minosPrimeFolder + "minosPrimeJudgement" + (x + 1));

        //Crush attack (Crush)
        AudioClip[] minosPrimeCrush = __instance.dropAttackVoice;
        for (int x = 0; x < minosPrimeCrush.Length; x++)
            minosPrimeCrush[x] = AudioSwapper.SwapClipWithFile(minosPrimeCrush[x], minosPrimeFolder + "minosPrimeCrush" + (x + 1));

        //Punches/Boxing (Thy end is now)
        AudioClip[] minosPrimePunch = __instance.boxingVoice;
        for (int x = 0; x < minosPrimePunch.Length; x++)
            minosPrimePunch[x] = AudioSwapper.SwapClipWithFile(minosPrimePunch[x], minosPrimeFolder + "minosPrimeThyEndIsNow" + (x + 1));

        //Combo (prepare thyself)
        AudioClip[] minosPrimeCombo = __instance.comboVoice;
        for (int x = 0; x < minosPrimeCombo.Length; x++)
            minosPrimeCombo[x] = AudioSwapper.SwapClipWithFile(minosPrimeCombo[x], minosPrimeFolder + "minosPrimePrepareThyself" + (x + 1));

        //Phase change
        __instance.phaseChangeVoice = AudioSwapper.SwapClipWithFile(__instance.phaseChangeVoice, minosPrimeFolder + "minosPrimePhaseChange");

        //Hurt
        AudioClip[] minosPrimeHurt = __instance.hurtVoice;
        for (int x = 0; x < minosPrimeHurt.Length; x++)
            minosPrimeHurt[x] = AudioSwapper.SwapClipWithFile(minosPrimeHurt[x], minosPrimeFolder + "minosPrimeHurt" + (x + 1));
    }
}
