using System;
using System.IO;
using System.Linq;
using System.Collections;
using BepInEx;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Networking;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.audio
{
    public static class AudioSwapper
    {
    // Folder where language audio is stored: <BepInEx.ConfigPath>/ultrakull/audio/<lang>/
    // Make writable because LanguageManager updates this when switching languages.
    public static string SpeechFolder { get; set; } = Path.Combine(Paths.ConfigPath, "ultrakull", "audio", LanguageManager.CurrentLanguage.metadata.langName) + Path.DirectorySeparatorChar;

        // Small MonoBehaviour host so static code can run coroutines
        private class CoroutineHost : MonoBehaviour { }
        private static CoroutineHost coroutineHost;

        private static void EnsureHost()
        {
            if (coroutineHost != null)
                return;
            var go = new GameObject("AudioSwapper_CoroutineHost");
            UnityEngine.Object.DontDestroyOnLoad(go);
            coroutineHost = go.AddComponent<CoroutineHost>();
        }

        /// <summary>
        /// Non-blocking: starts a coroutine that loads an AudioClip from disk and calls onComplete on the main thread.
        /// If loading fails, the original sourceClip is passed to the callback.
        /// </summary>
        public static void SwapClipWithFileAsync(AudioClip sourceClip, string audioFilePath, Action<AudioClip> onComplete)
        {
            try
            {
                EnsureHost();
                coroutineHost.StartCoroutine(LoadClipCoroutine(sourceClip, audioFilePath, onComplete));
            }
            catch (Exception e)
            {
                Logging.Warn("SwapClipWithFileAsync failed to start coroutine: " + e.Message);
                onComplete?.Invoke(sourceClip);
            }
        }

        private static IEnumerator LoadClipCoroutine(AudioClip sourceClip, string audioFilePath, Action<AudioClip> onComplete)
        {
            if (isUsingEnglish())
            {
                onComplete?.Invoke(sourceClip);
                yield break;
            }
            
            string filePath = Directory.GetFiles(
                Path.GetDirectoryName(audioFilePath), 
                Path.GetFileName(audioFilePath) + ".*"
            ).FirstOrDefault();

            AudioType type = TryGetAudioType(filePath);
            string fileUrl = "file://" + filePath;
            Logging.Message("Async swapping: " + fileUrl);

            using (var req = UnityWebRequestMultimedia.GetAudioClip(fileUrl, type))
            {
                var op = req.SendWebRequest();
                while (!op.isDone)
                    yield return null;

#if UNITY_2020_1_OR_NEWER
                if (req.result != UnityWebRequest.Result.Success)
#else
#pragma warning disable 0618
                if (req.isNetworkError || req.isHttpError)
#pragma warning restore 0618
#endif
                {
                    Logging.Warn(req.error + "\n Expected path: " + filePath);
                    onComplete?.Invoke(sourceClip);
                    yield break;
                }

                var newClip = DownloadHandlerAudioClip.GetContent(req);
                onComplete?.Invoke(newClip ?? sourceClip);
            }
        }

        /// <summary>
        /// Synchronous fallback kept for compatibility. Try to avoid calling this on the main thread.
        /// </summary>
        public static AudioClip SwapClipWithFile(AudioClip sourceClip, string audioFilePath)
        {
            if (isUsingEnglish())
                return sourceClip;

            string filePath = Directory.GetFiles(
                Path.GetDirectoryName(audioFilePath), 
                Path.GetFileName(audioFilePath) + ".*"
            ).FirstOrDefault();

            AudioType type = TryGetAudioType(filePath);

            string fileUrl = "file://" + filePath;
            Logging.Message("Swapping (sync fallback): " + fileUrl);

            UnityWebRequest req = null;
            try
            {
                req = UnityWebRequestMultimedia.GetAudioClip(fileUrl, type);
                var op = req.SendWebRequest();
                while (!op.isDone)
                {
                    // Blocking fallback; keep sleep very small to reduce CPU impact.
                    System.Threading.Thread.Sleep(1);
                }

#if UNITY_2020_1_OR_NEWER
                if (req.result != UnityWebRequest.Result.Success)
#else
#pragma warning disable 0618
                if (req.isNetworkError || req.isHttpError)
#pragma warning restore 0618
#endif
                {
                    Logging.Warn(req.error + "\n Expected path: " + audioFilePath + ".ogg");
                }
                else
                {
                    var newClip = DownloadHandlerAudioClip.GetContent(req);
                    if (newClip != null)
                        sourceClip = newClip;
                }
            }
            catch (Exception err)
            {
                Logging.Warn("Failed to swap " + audioFilePath);
                Logging.Warn(err.Message + ", " + err.StackTrace);
            }
            finally
            {
                if (req != null)
                    req.Dispose();
            }

            return sourceClip;
        }

        public static AudioType TryGetAudioType(string path)
        {
            var parts = path.Split('.');
            for (int i = 1; i <= parts.Length; i++)
            {
                var result = GetUnityAudioType(parts[parts.Length - i]);
                if (result != AudioType.UNKNOWN) 
                    return result;
            }
            return AudioType.UNKNOWN;
        }

        private static AudioType GetUnityAudioType(string extension)
        {
            switch (extension)
            {
                case "aac":  return AudioType.ACC;
                case "aiff": return AudioType.AIFF;
                case "aif":  return AudioType.AIFF;
                case "aifc": return AudioType.AIFF;
                case "it":   return AudioType.IT;
                case "mod":  return AudioType.MOD;
                case "mp3":  return AudioType.MPEG;
                case "mpga": return AudioType.MPEG;
                case "mpeg": return AudioType.MPEG;
                case "ogg":  return AudioType.OGGVORBIS;
                case "s3m":  return AudioType.S3M;
                case "wav":  return AudioType.WAV;
                case "xm":   return AudioType.XM;
                case "xma":  return AudioType.XMA;
                case "vag":  return AudioType.VAG;
                default:     return AudioType.UNKNOWN;
            }
        }
    }

    
}
