using HarmonyLib;
using System.IO;
using System.Reflection;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

[HarmonyPatch(typeof(Gabriel), "Start")]
public static class GabrielAudioSwap
{
    [HarmonyPostfix]
    public static void Gabriel_VoiceSwap(ref Gabriel __instance)
    {
        if (LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value == "False" || isUsingEnglish())
            return;

        ApplyVoiceSwap(__instance);
        ApplyOutroSwap(__instance);
    }

    private static void ApplyVoiceSwap(Gabriel __instance)
    {
        if (__instance == null)
            return;

        string gabeFirstFolder = AudioSwapper.SpeechFolder + "gabrielBossFirst" + Path.DirectorySeparatorChar;

        var gabeBase = __instance.gabe;
        if (gabeBase == null) return;

        // The game has renamed/moved the voice field across versions, so resolve it reflectively.
        GabrielVoice voice = null;
        try
        {
            var voiceProperty = gabeBase.GetType().GetProperty("voice");
            if (voiceProperty != null)
            {
                voice = voiceProperty.GetValue(gabeBase) as GabrielVoice;
            }
            else
            {
                var voiceField = gabeBase.GetType().GetField("voice", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (voiceField != null)
                {
                    voice = voiceField.GetValue(gabeBase) as GabrielVoice;
                }
            }
        }
        catch
        {
            return;
        }

        if (voice == null) return;

        //Taunts - line order matches in-game order, not alphabetical.
        AudioClip[] gabeTaunts = voice.taunt;
        string[] tauntLines =
        {
            "gabrielTaunt_YouDefyTheLight",
            "gabrielTaunt_AMereObject",
            "gabrielTaunt_ThereCanBeOnlyLight",
            "gabrielTaunt_Foolishness",
            "gabrielTaunt_AnImperfection",
            "gabrielTaunt_NotEvenMortal",
            "gabrielTaunt_YouAreLessThanNothing",
            "gabrielTaunt_YoureAnError",
            "gabrielTaunt_TheLightIsPerfection",
            "gabrielTaunt_YouAreOutclassed",
            "gabrielTaunt_YourCrimeIsExistence",
            "gabrielTaunt_YouMakeEven"
        };
        for (int x = 0; x < gabeTaunts.Length; x++)
            gabeTaunts[x] = AudioSwapper.SwapClipWithFile(gabeTaunts[x], gabeFirstFolder + tauntLines[x]);

        //Phase change
        voice.phaseChange = AudioSwapper.SwapClipWithFile(voice.phaseChange, gabeFirstFolder + "gabrielPhaseChange");

        //Big hurt
        AudioClip[] gabeBigHurt = voice.bigHurt;
        for (int x = 0; x < gabeBigHurt.Length; x++)
            gabeBigHurt[x] = AudioSwapper.SwapClipWithFile(gabeBigHurt[x], gabeFirstFolder + "gabrielBigHurt" + (x + 1));

        //Hurt
        AudioClip[] gabeHurt = voice.hurt;
        for (int x = 0; x < gabeHurt.Length; x++)
            gabeHurt[x] = AudioSwapper.SwapClipWithFile(gabeHurt[x], gabeFirstFolder + "gabrielHurt" + (x + 1));
    }

    private static void ApplyOutroSwap(Gabriel __instance)
    {
        if (__instance == null)
            return;

        string folder = AudioSwapper.SpeechFolder + "gabrielBossFirst" + Path.DirectorySeparatorChar;

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

            source.clip = AudioSwapper.SwapClipWithFile(source.clip, folder + "gabrielBigHurt1");
        }
    }
}
