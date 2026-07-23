using System;
using System.IO;
using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

[HarmonyPatch(typeof(Mandalore), "Start")]
public static class MandaloreAudioSwap
{
    [HarmonyPostfix]
    public static void Mandalore_AudioSwap(Mandalore __instance)
    {
        try
        {
            if (LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value == "False" || isUsingEnglish())
                return;

            ApplyAudioSwap(__instance);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ApplyAudioSwap(Mandalore __instance)
    {
        try
        {
            if (__instance == null)
                return;

            //Mandalore uses an array for MandaloreVoice. voices[0] = Mandalore, voices[1] = Owl.
            //NOTE - both audio files for Manda & Owl play at the SAME TIME, so each file needs the
            //relevant period of silence before/after speaking.
            string mandaloreFolder = AudioSwapper.SpeechFolder + "mandalore" + Path.DirectorySeparatorChar;

            //Attack 1 (Full auto)
            __instance.voiceFull = AudioSwapper.SwapClipWithFile(__instance.voiceFull, mandaloreFolder + "mandaloreFullAuto");

            //Attack 2 (Fuller auto)
            __instance.voiceFuller = AudioSwapper.SwapClipWithFile(__instance.voiceFuller, mandaloreFolder + "mandaloreFullerAuto");

            //Phase change 1 (speed increase)
            __instance.voices[0].secondPhase = AudioSwapper.SwapClipWithFile(__instance.voices[0].secondPhase, mandaloreFolder + "mandalorePhaseChange1Manda");
            __instance.voices[1].secondPhase = AudioSwapper.SwapClipWithFile(__instance.voices[1].secondPhase, mandaloreFolder + "mandalorePhaseChange1Owl");

            //Phase change 2 (max speed)
            __instance.voices[0].thirdPhase = AudioSwapper.SwapClipWithFile(__instance.voices[0].thirdPhase, mandaloreFolder + "mandalorePhaseChange2Manda");
            __instance.voices[1].thirdPhase = AudioSwapper.SwapClipWithFile(__instance.voices[1].thirdPhase, mandaloreFolder + "mandalorePhaseChange2Owl");

            //Phase change 3 (sanded)
            __instance.voices[0].finalPhase = AudioSwapper.SwapClipWithFile(__instance.voices[0].finalPhase, mandaloreFolder + "mandalorePhaseChangeFinalManda");
            __instance.voices[1].finalPhase = AudioSwapper.SwapClipWithFile(__instance.voices[1].finalPhase, mandaloreFolder + "mandalorePhaseChangeFinalOwl");

            //Defeated
            __instance.voices[0].death = AudioSwapper.SwapClipWithFile(__instance.voices[0].death, mandaloreFolder + "mandaloreDefeatedManda");
            __instance.voices[1].death = AudioSwapper.SwapClipWithFile(__instance.voices[1].death, mandaloreFolder + "mandaloreDefeatedOwl");

            //Respawn taunts
            AudioClip[] mandaloreTauntManda = __instance.voices[0].taunts;
            AudioClip[] mandaloreTauntOwl = __instance.voices[1].taunts;

            string[] mandaTauntLines =
            {
                "mandaloreTaunt_YouCannotImagine",
                "mandaloreTaunt_What",
                "mandaloreTaunt_HoldStill"
            };

            string[] owlTauntLines =
            {
                "mandaloreTaunt_ImGonnaShootThem",
                "mandaloreTaunt_WhyAreWeInThePast",
                "mandaloreTaunt_ImGonnaPoisonYou",
            };

            int minLength = Math.Min(mandaloreTauntManda.Length, Math.Min(mandaloreTauntOwl.Length, mandaTauntLines.Length));
            for (int x = 0; x < minLength; x++)
            {
                switch (x)
                {
                    case 1:
                        mandaloreTauntOwl[x] = AudioSwapper.SwapClipWithFile(mandaloreTauntOwl[x], mandaloreFolder + owlTauntLines[x]);
                        break;
                    case 3:
                        mandaloreTauntManda[x] = AudioSwapper.SwapClipWithFile(mandaloreTauntManda[x], mandaloreFolder + mandaTauntLines[x]);
                        break;
                    default:
                        mandaloreTauntManda[x] = AudioSwapper.SwapClipWithFile(mandaloreTauntManda[x], mandaloreFolder + mandaTauntLines[x]);
                        mandaloreTauntOwl[x] = AudioSwapper.SwapClipWithFile(mandaloreTauntOwl[x], mandaloreFolder + owlTauntLines[x]);
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
