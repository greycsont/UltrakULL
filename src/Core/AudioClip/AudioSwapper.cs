using System;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.audio;

public static class AudioSwapper
{
    public static string SpeechFolder => LanguageManager.Current?.SpeechFolder ?? "";

    public static void OnSceneLoaded(string sceneName)
    {
        AudioLoader.Instance.Clear();

        if (LanguageManager.IsEnglish 
            || Settings.activeDubbing.Value == false)
            return;

        AudioLoader.Instance.PreloadScene(sceneName);
    }

    public static void WhenReady(Action swap)
    {
        if (LanguageManager.IsEnglish || swap == null)
            return;

        AudioLoader.Instance.WhenReady(() =>
            {
                try
                {
                    swap();
                }
                catch (Exception error)
                {
                    LogSwapError("scene audio", error);
                }
            });
    }

    public static AudioClip SwapClipWithFile(AudioClip sourceClip, string audioFilePath)
    {
        if (LanguageManager.IsEnglish)
            return sourceClip;

        try
        {
            return SwapClipWithFileCore(sourceClip, audioFilePath);
        }
        catch (Exception error)
        {
            LogSwapError(audioFilePath, error);
            return sourceClip;
        }
    }

    private static AudioClip SwapClipWithFileCore(AudioClip sourceClip, string audioFilePath)
    {
        return AudioLoader.Instance.Get(audioFilePath) ?? sourceClip;
    }

    private static void LogSwapError(string audioFilePath, Exception error)
    {
        Logging.Warn($"Failed to swap audio '{audioFilePath}': {error}");
    }
}
