using System;
using System.IO;
using System.Linq;
using GreyAnnouncer.AudioClipLoad;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Networking;


namespace UltrakULL.audio;

public static class AudioSwapper
{
    public static string SpeechFolder => LanguageManager.Current?.SpeechFolder ?? "";

    public static AudioClip SwapClipWithFile(AudioClip sourceClip, string audioFilePath)
    {
        if (LanguageManager.IsEnglish)
            return sourceClip;

        string filePath = Directory.GetFiles(
            Path.GetDirectoryName(audioFilePath),
            Path.GetFileName(audioFilePath) + ".*").First();
            
        var audioType = filePath.TryGetAudioType();

        string fileUrl = new Uri(filePath).AbsoluteUri;
        Logging.Message("Swapping: " + fileUrl);

        using var fileRequest = UnityWebRequestMultimedia.GetAudioClip(fileUrl, audioType);

        try
        {
            fileRequest.SendWebRequest();
            while (!fileRequest.isDone) {}

            if (fileRequest.result != UnityWebRequest.Result.Success)
            {
                Logging.Warn(fileRequest.error + "\nExpected path: " + filePath);
            }
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
