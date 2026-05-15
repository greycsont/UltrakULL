using System;
using System.IO;
using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(GabrielSecond), "Awake")]
    public static class GabrielSecondAudioSwap
    {
        [HarmonyPostfix]
        public static void GabrielSecond_VoiceSwap(ref GabrielSecond __instance)
        {
            if (LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value == "False" || isUsingEnglish())
            {
                return;
            }
            GabrielSecond instance = __instance;
            AudioPreloadManager.EnsureCurrentScenePreloaded(delegate { ApplyVoiceSwap(instance); });
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
            AudioSwapper.LogAudioSourceDiagnostics(voice.GetComponent<AudioSource>(), "GabrielSecondVoice");
            string gabeSecondFolder = AudioSwapper.SpeechFolder + "gabrielBossSecond" + Path.DirectorySeparatorChar;
            
            // Taunts
            AudioClip[] gabeSecondTaunts = voice.taunt;
            string[] tauntLines = new string[]
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
            {
                int ix = i;
                string gabrielSecondTauntString = gabeSecondFolder + tauntLines[ix];
                AudioSwapper.SwapClipInArrayAsync(gabeSecondTaunts, ix, gabrielSecondTauntString);
            }
            
            // Phase change
            AudioClip tmpPhase = voice.phaseChange;
            string gabrielSecondPhaseChangeString = gabeSecondFolder + "gabrielSecondPhaseChange";
            AudioSwapper.SwapClipWithFileAsync(tmpPhase, gabrielSecondPhaseChangeString, (clip) =>
            {
                try { voice.phaseChange = clip; }
                catch { }
            });
            
            // Big hurt
            AudioClip[] gabeSecondBigHurt = voice.bigHurt;
            for (int i = 0; i < gabeSecondBigHurt.Length; i++)
            {
                int ix = i;
                string gabrielSecondBigHurtString = gabeSecondFolder + "gabrielSecondBigHurt" + (ix + 1).ToString();
                AudioSwapper.SwapClipInArrayAsync(gabeSecondBigHurt, ix, gabrielSecondBigHurtString);
            }
            
            // Hurt
            AudioClip[] gabeSecondHurt = voice.hurt;
            for (int i = 0; i < gabeSecondHurt.Length; i++)
            {
                int ix = i;
                string gabrielSecondHurtString = gabeSecondFolder + "gabrielSecondHurt" + (ix + 1).ToString();
                AudioSwapper.SwapClipInArrayAsync(gabeSecondHurt, ix, gabrielSecondHurtString);
            }
            
            // Taunts second phase
            string[] tauntLinesSecondPhase = new string[]
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
            {
                int ix = i;
                string gabeSecondTauntsSecondPhaseString = gabeSecondFolder + tauntLinesSecondPhase[ix];
                AudioSwapper.SwapClipInArrayAsync(gabeSecondTauntsSecondPhase, ix, gabeSecondTauntsSecondPhaseString);
            }
        }
    }
}
