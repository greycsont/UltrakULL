using System.IO;
using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

[HarmonyPatch(typeof(GabrielSecond), "Awake")]
public static class GabrielSecondAudioSwap
{
    [HarmonyPostfix]
    public static void GabrielSecond_VoiceSwap(ref GabrielSecond __instance)
    {
        if (LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value == "False" || isUsingEnglish())
            return;

        ApplyVoiceSwap(__instance);
        ApplyOutroSwap(__instance);
    }

    private static void ApplyVoiceSwap(GabrielSecond __instance)
    {
        if (__instance == null)
            return;

        GabrielVoice voice = __instance.GetComponent<GabrielVoice>();
        if (voice == null)
        {
            Debug.LogWarning("[UltrakULL] GabrielVoice component not found on GabrielSecond!");
            return;
        }
        string gabeSecondFolder = AudioSwapper.SpeechFolder + "gabrielBossSecond" + Path.DirectorySeparatorChar;

        // Taunts
        AudioClip[] gabeSecondTaunts = voice.taunt;
        string[] tauntLines =
        {
            "gabrielSecondTaunt_IsThisWhatILostTo",
            "gabrielSecondTaunt_YoureGettingRusty",
            "gabrielSecondTaunt_LetsSettleThis",
            "gabrielSecondTaunt_NothingButScrap",
            "gabrielSecondTaunt_IllShowYouDivine",
            "gabrielSecondTaunt_TimeToRight",
            "gabrielSecondTaunt_YouNeedMorePower"
        };
        for (int i = 0; i < gabeSecondTaunts.Length; i++)
            gabeSecondTaunts[i] = AudioSwapper.SwapClipWithFile(gabeSecondTaunts[i], gabeSecondFolder + tauntLines[i]);

        // Phase change
        voice.phaseChange = AudioSwapper.SwapClipWithFile(voice.phaseChange, gabeSecondFolder + "gabrielSecondPhaseChange");

        // Big hurt
        AudioClip[] gabeSecondBigHurt = voice.bigHurt;
        for (int i = 0; i < gabeSecondBigHurt.Length; i++)
            gabeSecondBigHurt[i] = AudioSwapper.SwapClipWithFile(gabeSecondBigHurt[i], gabeSecondFolder + "gabrielSecondBigHurt" + (i + 1));

        // Hurt
        AudioClip[] gabeSecondHurt = voice.hurt;
        for (int i = 0; i < gabeSecondHurt.Length; i++)
            gabeSecondHurt[i] = AudioSwapper.SwapClipWithFile(gabeSecondHurt[i], gabeSecondFolder + "gabrielSecondHurt" + (i + 1));

        // Taunts second phase
        string[] tauntLinesSecondPhase =
        {
            "gabrielSecondTaunt_IveNeverHadAFight",
            "gabrielSecondTaunt_ShowMeWhat",
            "gabrielSecondTaunt_NowThisIsAFight",
            "gabrielSecondTaunt_WhatIsThisFeeling",
            "gabrielSecondTaunt_ComeGetSomeBlood",
            "gabrielSecondTaunt_ComeOnMachine",
            "gabrielSecondTaunt_IllShowYouTrueSplendor"
        };
        AudioClip[] gabeSecondTauntsSecondPhase = voice.tauntSecondPhase;
        for (int i = 0; i < gabeSecondTauntsSecondPhase.Length; i++)
            gabeSecondTauntsSecondPhase[i] = AudioSwapper.SwapClipWithFile(gabeSecondTauntsSecondPhase[i], gabeSecondFolder + tauntLinesSecondPhase[i]);
    }

    private static void ApplyOutroSwap(GabrielSecond __instance)
    {
        if (__instance == null)
            return;

        string folder = AudioSwapper.SpeechFolder + "gabrielBossSecond" + Path.DirectorySeparatorChar;

        GabrielOutro outro = Object.FindObjectOfType<GabrielOutro>(true);
        if (outro == null)
            return;

        AudioSource[] sources = outro.GetComponentsInChildren<AudioSource>(true);
        foreach (AudioSource source in sources)
        {
            if (source == null || source.clip == null)
                continue;
            if (source.clip.name != "gab_BigHurt1")
                continue;

            source.clip = AudioSwapper.SwapClipWithFile(source.clip, folder + "gabrielSecondBigHurt1");
        }
    }
}
