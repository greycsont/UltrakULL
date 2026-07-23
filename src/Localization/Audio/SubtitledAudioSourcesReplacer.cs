using System.Collections.Generic;
using BepInEx;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.ReflectionUtils;
using static UltrakULL.CommonFunctions;
using static UltrakULL.audio.AudioSwapper;
using static System.IO.Path;

namespace UltrakULL;

public static class SubtitledAudioSourcesReplacer
{
    // SpeechFolder comes from the static import of AudioSwapper.
    public static SubtitledSourcesConfig Config;

    // Called by the scene-load pipeline's deferred wave (after it has already waited).
    public static void ReplaceSubsAndAudio()
    {
        if (!TryLoadMetadata(out var objectReferences)) 
            return;
        
        foreach (var objectReference in objectReferences)
        {
            foreach (var gameObject in objectReference.Objects)
            {
                var subtitledAudioSource = GetObject(gameObject).GetComponent<SubtitledAudioSource>();
                var audioSource = GetObject(gameObject).GetComponentInChildren<AudioSource>();

                if (ActiveDubbingEnabled())
                    audioSource.clip = SwapClipWithFile(audioSource.clip, Combine(SpeechFolder, objectReference.AudioPath));
                
                if (subtitledAudioSource != null)
                    SetPrivate(subtitledAudioSource, typeof(SubtitledAudioSource), "subtitles", objectReference.ToSubtitleData());
            }
        }
    }

    private static bool ActiveDubbingEnabled()
    {
        return LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value != "False";
    }

    private static bool TryLoadMetadata(out List<SubtitledObjectReference> references)
    {
        if (Config != null && Config.Scenes.TryGetValue(GetCurrentSceneName(), out references))
            return true;

        references = default;
        return false;
    }
}