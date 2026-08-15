using System.Collections.Generic;
using BepInEx;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.ReflectionUtils;
using static UltrakULL.audio.AudioSwapper;
using static System.IO.Path;

using static UltrakULL.SceneObjects;

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

        var audioReplacements = new List<(AudioSource source, string path)>();
        
        foreach (var objectReference in objectReferences)
        {
            foreach (var gameObject in objectReference.Objects)
            {
                var target = GetObject(gameObject);
                var subtitledAudioSource = target.GetComponent<SubtitledAudioSource>();

                if (ActiveDubbingEnabled())
                    audioReplacements.Add((
                        target.GetComponentInChildren<AudioSource>(),
                        Combine(SpeechFolder, objectReference.AudioPath)));
                
                if (subtitledAudioSource != null)
                    SetPrivate(subtitledAudioSource, typeof(SubtitledAudioSource), "subtitles", objectReference.ToSubtitleData());
            }
        }

        WhenReady(() =>
        {
            foreach (var replacement in audioReplacements)
                replacement.source.clip = SwapClipWithFile(replacement.source.clip, replacement.path);
        });
    }

    private static bool ActiveDubbingEnabled()
    {
        return Settings.activeDubbing.Value == true;
    }

    private static bool TryLoadMetadata(out List<SubtitledObjectReference> references)
    {
        if (Config != null && Config.Scenes.TryGetValue(GetCurrentSceneName(), out references))
            return true;

        references = default;
        return false;
    }
}
