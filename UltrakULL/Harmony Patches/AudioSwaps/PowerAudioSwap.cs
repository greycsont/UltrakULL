using BepInEx.Configuration;
using HarmonyLib;
using ScriptableObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using static UltrakULL.ReflectionUtils;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(PowerVoiceController), "Awake")]
    public static class PowerAudioSwap
    {
        private static readonly BindingFlags FieldFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private static readonly List<PowerVoiceController> KnownInstances = new List<PowerVoiceController>();

        private static readonly string[] ArrayFields =
        {
            "intro",
            "enrage",
            "taunt",
            "cheapShot",
            "hurt",
            "hurtBig",
            "death",
            "rapier",
            "greatsword",
            "spear",
            "spearThrow",
            "glaive",
            "glaiveThrow"
        };

        [HarmonyPostfix]
        private static void Postfix(PowerVoiceController __instance)
        {
            if (LanguageManager.configFile.Bind<string>("General", "activeDubbing", "False", (ConfigDescription)null).Value == "False" || CommonFunctions.isUsingEnglish())
                return;

            if (!KnownInstances.Contains(__instance))
                KnownInstances.Add(__instance);

            AudioSwapper.LogAudioSourceDiagnostics(__instance.GetComponent<AudioSource>(), "PowerVoiceController");
            // Detailed logging for debugging audio swaps
            Logging.Info($"[PowerAudioSwap] Processing PowerVoiceController instance {__instance.GetInstanceID()} in scene '{GetCurrentSceneName()}'");

            string powerFolder = Path.Combine(AudioSwapper.SpeechFolder, "power");
            AudioSwapper.PreloadFolderAsync(powerFolder, () =>
            {
                RebindPowerClips(__instance);
            });
        }

        public static void RebindCachedInstances()
        {
            for (int i = KnownInstances.Count - 1; i >= 0; i--)
            {
                PowerVoiceController instance = KnownInstances[i];
                if (instance == null)
                {
                    KnownInstances.RemoveAt(i);
                    continue;
                }

                RebindPowerClips(instance);
            }
        }

        private static bool ShouldUseScenePreload()
        {
            if (GetCurrentSceneName() == "Level 8-3")
                return true;

            try
            {
                return LanguageManager.configFile.Bind<string>("General", "audioPreloadMode", "Scene", (ConfigDescription)null).Value == "StartupAll";
            }
            catch
            {
                return false;
            }
        }

        private static void RebindPowerClips(PowerVoiceController __instance)
        {
            string folder = Path.Combine(AudioSwapper.SpeechFolder, "power");
            foreach (string fieldName in ArrayFields)
                SwapArrayField(__instance, fieldName, folder);

            SwapSingleField(__instance, "fallScream", folder, "pow_ScreamContinuous");
        }

        private static void SwapArrayField(PowerVoiceController instance, string fieldName, string folder)
        {
            FieldInfo field = typeof(PowerVoiceController).GetField(fieldName, FieldFlags);
            if (field == null)
            {
                Logging.Error("[AudioSwap] PowerVoiceController field not found: " + fieldName);
                return;
            }

            AudioClip[] clips = field.GetValue(instance) as AudioClip[];
            if (clips == null)
            {
                Logging.Warn($"[PowerAudioSwap] Field '{fieldName}' returned null array.");
                return;
            }

            for (int i = 0; i < clips.Length; i++)
            {
                int index = i;
                AudioClip original = clips[index];
                if (original == null)
                {
                    Logging.Warn($"[PowerAudioSwap] Clip at index {index} in field '{fieldName}' is null, skipping.");
                    continue;
                }

                string path = Path.Combine(folder, original.name);
                Logging.Info($"[PowerAudioSwap] Attempting to preload clip '{original.name}' from '{path}'.");
                AudioSwapper.PreloadClipAsync(path, original, delegate (AudioClip newClip)
                {
                    if (newClip != null)
                    {
                        Logging.Info($"[PowerAudioSwap] Successfully preloaded localized clip '{newClip.name}' for field '{fieldName}'.");
                        clips[index] = newClip;
                        field.SetValue(instance, clips);
                        UltrakULL.Harmony_Patches.Subtitles.PowerSubtitlesSwap.RegisterPowerClipAsHandled(newClip.name);
                    }
                    else
                    {
                        Logging.Warn($"[PowerAudioSwap] Preload returned null for clip '{original.name}' in field '{fieldName}'. Keeping original.");
                    }
                });
            }
        }

        private static void SwapSingleField(PowerVoiceController instance, string fieldName, string folder, string replacementName)
        {
            FieldInfo field = typeof(PowerVoiceController).GetField(fieldName, FieldFlags);
            if (field == null)
            {
                Logging.Error("[AudioSwap] PowerVoiceController field not found: " + fieldName);
                return;
            }

            AudioClip original = field.GetValue(instance) as AudioClip;
            if (original == null)
            {
                Logging.Warn($"[PowerAudioSwap] Single field '{fieldName}' is null, nothing to swap.");
                return;
            }

            string fullPath = Path.Combine(folder, replacementName);
            Logging.Info($"[PowerAudioSwap] Attempting to preload single clip '{original.name}' from '{fullPath}'.");
            AudioSwapper.PreloadClipAsync(fullPath, original, delegate (AudioClip newClip)
            {
                if (newClip != null)
                {
                    Logging.Info($"[PowerAudioSwap] Successfully replaced '{fieldName}' with localized clip '{newClip.name}'.");
                    try { field.SetValue(instance, newClip); } catch { }
                    UltrakULL.Harmony_Patches.Subtitles.PowerSubtitlesSwap.RegisterPowerClipAsHandled(newClip.name);
                }
                else
                {
                    Logging.Warn($"[PowerAudioSwap] Preload failed for '{fieldName}'. Keeping original clip.");
                }
            });
        }
    }

    [HarmonyPatch(typeof(PowerIntro), "Activate")]
    public static class PowerIntroSwap
    {
        private static readonly BindingFlags fieldFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private static bool wasPerformedIntro = false;

        [HarmonyPrefix]
        private static void Prefix(PowerIntro __instance)
        {
            // early return 전에 먼저 세팅
            FieldInfo persistentDataField = typeof(PowerIntro).GetField("persistentData", fieldFlags);
            PowerPersistentData persistentData = (PowerPersistentData)persistentDataField.GetValue(__instance);
            wasPerformedIntro = persistentData != null && persistentData.PerformedIntro && persistentData.RepeatedIntroOverrideClip;

            if (LanguageManager.configFile.Bind<string>("General", "activeDubbing", "False", (ConfigDescription)null).Value == "False" || CommonFunctions.isUsingEnglish())
                return;

            FieldInfo introOverrideField = typeof(PowerIntro).GetField("introOverride", fieldFlags);
            AudioClip introOverride = (AudioClip)introOverrideField.GetValue(__instance);

            Logging.Warn("PowerIntro: introOverride = " + (introOverride != null ? introOverride.name : "null"));

            if (introOverride == null)
            {
                Logging.Warn("PowerIntro: introOverride is null, will use PowerVoiceController.Intro()");
            }
            else
            {
                string folder = Path.Combine(AudioSwapper.SpeechFolder, "power");
                string path = Path.Combine(folder, introOverride.name);

                AudioSwapper.LogAudioSourceDiagnostics(__instance.GetComponent<AudioSource>(), "PowerIntro (introOverride)");

                bool shouldUseScenePreload = false;
                try
                {
                    shouldUseScenePreload = LanguageManager.configFile.Bind<string>("General", "audioPreloadMode", "Scene", (ConfigDescription)null).Value == "StartupAll";
                }
                catch { shouldUseScenePreload = false; }

                if (shouldUseScenePreload || GetCurrentSceneName() == "Level 8-3")
                {
                    if (AudioPreloadManager.IsScenePreloaded(GetCurrentSceneName()))
                    {
                        AudioSwapper.PreloadClipAsync(path, introOverride, (AudioClip newClip) =>
                        {
                            introOverrideField.SetValue(__instance, newClip);
                            Logging.Warn("PowerIntro: Successfully replaced introOverride with localized version: " + newClip.name);
                            UltrakULL.Harmony_Patches.Subtitles.PowerSubtitlesSwap.RegisterPowerClipAsHandled(newClip.name);
                        });
                    }
                    else
                    {
                        AudioPreloadManager.EnsureCurrentScenePreloaded();
                    }
                }
                else
                {
                    AudioSwapper.PreloadClipAsync(path, introOverride, (AudioClip newClip) =>
                    {
                        introOverrideField.SetValue(__instance, newClip);
                        Logging.Warn("PowerIntro: Successfully replaced introOverride with localized version: " + newClip.name);
                        UltrakULL.Harmony_Patches.Subtitles.PowerSubtitlesSwap.RegisterPowerClipAsHandled(newClip.name);
                    });
                }
            }

            Logging.Warn($"PowerIntro: persistentData.PerformedIntro = {persistentData?.PerformedIntro}");
            Logging.Warn($"PowerIntro: persistentData.RepeatedIntroOverrideClip = {persistentData?.RepeatedIntroOverrideClip}");

            if (persistentData != null && persistentData.RepeatedIntroClips != null && persistentData.RepeatedIntroClips.Length > 0)
            {
                string folder = Path.Combine(AudioSwapper.SpeechFolder, "power");
                for (int i = 0; i < persistentData.RepeatedIntroClips.Length; i++)
                {
                    AudioClip originalClip = persistentData.RepeatedIntroClips[i];
                    if (originalClip == null) continue;

                    string path = Path.Combine(folder, originalClip.name);
                    AudioSwapper.PreloadClipAsync(path, originalClip, (AudioClip newClip) =>
                    {
                        persistentData.RepeatedIntroClips[i] = newClip;
                        Logging.Warn($"PowerIntro: Successfully replaced RepeatedIntroClips[{i}] with localized version: " + newClip.name);
                        UltrakULL.Harmony_Patches.Subtitles.PowerSubtitlesSwap.RegisterPowerClipAsHandled(newClip.name);
                    });
                }
            }
        }

        [HarmonyPostfix]
        private static void Postfix(PowerIntro __instance)
        {
            if (CommonFunctions.isUsingEnglish()) return;
            if (!wasPerformedIntro) return;

            SubtitledAudioSource subtitledSource = __instance.GetComponent<SubtitledAudioSource>();
            if (subtitledSource == null) return;

            var currentData = (SubtitledAudioSource.SubtitleData)typeof(SubtitledAudioSource)
                .GetField("subtitles", fieldFlags)
                .GetValue(subtitledSource);

            if (currentData?.lines == null || currentData.lines.Length == 0) return;

            SetPrivate(subtitledSource, typeof(SubtitledAudioSource), "subtitles",
                new SubtitledAudioSource.SubtitleData
                {
                    lines = new[] { currentData.lines[0] }
                });
        }
    }
}
