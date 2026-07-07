using System;
using System.IO;
using BepInEx;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Networking;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.audio;

public static class AudioSwapper
{
    // Set at runtime by LanguageManager.SetCurrentLanguage. Not initialized from CurrentLanguage here:
    // this static initializer can run (via the type's cctor) before the language is set, which NRE'd.
    public static string SpeechFolder = "";
    
    public static AudioClip SwapClipWithFile(AudioClip sourceClip, string audioFilePath)
    {
        if(isUsingEnglish())
        {
            return sourceClip;
        }
        string file = "file://" + audioFilePath + ".ogg";
        Logging.Message("Swapping: " + file);

        UnityWebRequest fileRequest = UnityWebRequestMultimedia.GetAudioClip(file,AudioType.OGGVORBIS);
        fileRequest.SendWebRequest();
        try
        {
            while (!fileRequest.isDone) {}

            if (fileRequest.isNetworkError || fileRequest.isHttpError) Logging.Warn(fileRequest.error + "\n Expected path: " + audioFilePath + ".ogg");
            else
            {
                sourceClip = DownloadHandlerAudioClip.GetContent(fileRequest);
            }
        }
        catch (Exception err)
        {
            Logging.Warn("Failed to swap " + audioFilePath);
            Logging.Warn($"{err.Message}, {err.StackTrace}");
        }
        return sourceClip;
    }
}
