using System.IO;
using HarmonyLib;
using ScriptableObjects;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

/// <summary>
/// Warning: It's MonoSingleton
/// So we actually don't need to worry about the performance
/// Since it only run once after sceneload
/// </summary>
[HarmonyPatch(typeof(PowerVoiceController))]
public static class PowerAudioSwap
{
    [HarmonyPatch(nameof(PowerVoiceController.Awake))] [HarmonyPostfix]
    private static void Awake_Postfix(PowerVoiceController __instance)
    {
        if (!ShouldReplaceAudio())
            return;

        Replace(__instance.intro);
        Replace(__instance.enrage);
        Replace(__instance.taunt);
        Replace(__instance.cheapShot);
        Replace(__instance.hurt);
        Replace(__instance.hurtBig);
        Replace(__instance.death);
        Replace(__instance.rapier);
        Replace(__instance.greatsword);
        Replace(__instance.spear);
        Replace(__instance.spearThrow);
        Replace(__instance.glaive);
        Replace(__instance.glaiveThrow);
        __instance.fallScream = Replace(__instance.fallScream, "pow_ScreamContinuous");
    }

    internal static bool ShouldReplaceAudio()
    {
        return !LanguageManager.IsEnglish &&
               Settings.activeDubbing.Value == true;
    }

    internal static AudioClip Replace(AudioClip clip, string name = null)
    {
        if (clip == null)
            return null;

        return AudioSwapper.SwapClipWithFile(
            clip,
            Path.Combine(AudioSwapper.SpeechFolder, "power", name ?? clip.name));
    }

    internal static void Replace(AudioClip[] clips)
    {
        for (int i = 0; i < clips.Length; i++)
            clips[i] = Replace(clips[i]);
    }
}

/// <summary>
/// FUCK YOU SCRIPTABLE OBJECT FUCK YOU
/// </summary>
[HarmonyPatch(typeof(PowerIntro))]
public static class PowerIntroAudioSwap
{
    private sealed class OriginalAudio
    {
        public AudioClip IntroOverride;
        public PowerPersistentData PersistentData;
        public AudioClip[] RepeatedIntroClips;
    }

    [HarmonyPatch(nameof(PowerIntro.Activate)), HarmonyPrefix]
    private static void Activate_Prefix(PowerIntro __instance, out OriginalAudio __state)
    {
        __state = null;

        if (!PowerAudioSwap.ShouldReplaceAudio())
            return;

        __state = new OriginalAudio
        {
            IntroOverride = __instance.introOverride,
            PersistentData = __instance.persistentData,
            RepeatedIntroClips = __instance.persistentData?.RepeatedIntroClips
        };

        __instance.introOverride = PowerAudioSwap.Replace(__instance.introOverride);

        if (__state.RepeatedIntroClips != null)
        {
            AudioClip[] localizedClips = (AudioClip[])__state.RepeatedIntroClips.Clone();
            PowerAudioSwap.Replace(localizedClips);
            __state.PersistentData.RepeatedIntroClips = localizedClips;
        }
    }

    [HarmonyPatch(nameof(PowerIntro.Activate)), HarmonyPostfix]
    private static void Activate_Postfix(PowerIntro __instance, OriginalAudio __state)
    {
        if (__state == null)
            return;

        __instance.introOverride = __state.IntroOverride;

        if (__state.PersistentData != null)
            __state.PersistentData.RepeatedIntroClips = __state.RepeatedIntroClips;
    }
}
