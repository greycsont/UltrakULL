using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GreyAnnouncer.AudioClipLoad;
using UnityEngine;
using UnityEngine.Networking;

namespace UltrakULL.audio;

internal sealed class AudioLoader
{
    private const int MaxConcurrentLoads = 4;

    private static AudioLoader instance;

    public static AudioLoader Instance =>
        instance ??= new AudioLoader(MainPatch.Instance);

    private static readonly Dictionary<string, string[]> ScenePreloads = new()
    {
        ["Level 3-2"] = new[] { "gabrielBossFirst" },
        ["Level 4-3"] = new[] { "mandalore" },
        ["Level 6-2"] = new[] { "gabrielBossSecond" },
        ["Level P-1"] = new[] { "minosPrime" },
        ["Level P-2"] = new[] { "sisyphusPrime" },
        ["Level 8-3"] = new[] { "power" }
    };

    private readonly MonoBehaviour coroutineRunner;
    private readonly Dictionary<string, AudioClip> buffer = new();
    private readonly HashSet<string> loading = new();

    // Nobody will fucking load scene 2^32-1 times in ultrakill right?
    private int cacheVersion;
    private bool preloading;

    private AudioLoader(MonoBehaviour coroutineRunner)
    {
        this.coroutineRunner = coroutineRunner;
    }

    public void Clear()
    {
        cacheVersion++;
        preloading = false;
        loading.Clear();

        foreach (var clip in buffer.Values)
        {
            if (clip != null)
                UnityEngine.Object.Destroy(clip);
        }

        buffer.Clear();
    }


    public AudioClip Get(string audioFilePath)
    {
        var key = GetKey(audioFilePath);

        if (buffer.TryGetValue(key, out var clip))
            return clip;

        if (loading.Contains(key))
            return null;

        clip = Load(audioFilePath);
        if (clip != null)
            buffer[key] = clip;

        return clip;
    }

    private AudioClip Load(string audioFilePath)
    {
        var filePath = FindAudioFile(audioFilePath);
        if (filePath == null)
        {
            Logging.Warn($"Failed to find audio file: {audioFilePath}");
            return null;
        }

        var audioType = filePath.ToLowerInvariant().TryGetAudioType();
        var fileUrl = new Uri(filePath).AbsoluteUri;
        Logging.Message("Swapping synchronously: " + fileUrl);

        using var request = UnityWebRequestMultimedia.GetAudioClip(fileUrl, audioType);
        request.SendWebRequest();
        while (!request.isDone) { }

        if (request.result == UnityWebRequest.Result.Success)
            return DownloadHandlerAudioClip.GetContent(request);

        Logging.Warn(request.error + "\nExpected path: " + filePath);
        return null;
    }

    private IEnumerator PreloadSceneCoroutine(string sceneName)
    {
        if (!ScenePreloads.TryGetValue(sceneName, out var folderNames))
            yield break;

        var version = cacheVersion;
        var files = new Queue<string>(GetAudioFiles(folderNames));
        var active = 0;

        preloading = true;

        while (version == cacheVersion && (files.Count > 0 || active > 0))
        {
            while (files.Count > 0 && active < MaxConcurrentLoads)
            {
                var filePath = files.Dequeue();
                var key = GetKey(filePath);

                if (buffer.ContainsKey(key) || !loading.Add(key))
                    continue;

                active++;
                coroutineRunner.StartCoroutine(
                    LoadFile(filePath, key, version, () => active--));
            }

            yield return null;
        }

        if (version == cacheVersion)
            preloading = false;
    }

    private IEnumerator WaitUntilReady(Action callback)
    {
        // Awake runs before SceneManager.sceneLoaded. Waiting one frame lets MainPatch
        // start the current scene's preload before checking its state.
        yield return null;

        while (preloading)
            yield return null;

        callback();
    }

    private IEnumerator LoadFile(string filePath,
                                 string key,
                                 int version,
                                 Action onComplete)
    {
        var audioType = filePath.ToLowerInvariant().TryGetAudioType();
        var fileUrl = new Uri(filePath).AbsoluteUri;

        using var request = UnityWebRequestMultimedia.GetAudioClip(fileUrl, audioType);
        yield return request.SendWebRequest();

        if (version != cacheVersion)
        {
            onComplete();
            yield break;
        }

        loading.Remove(key);

        if (request.result == UnityWebRequest.Result.Success)
            buffer[key] = DownloadHandlerAudioClip.GetContent(request);
        else
            Logging.Warn($"Failed to load audio file '{filePath}': {request.error}");

        onComplete();
    }

    private List<string> GetAudioFiles(IEnumerable<string> folderNames)
    {
        var files = new List<string>();

        foreach (var folderName in folderNames)
        {
            var folder = Path.Combine(AudioSwapper.SpeechFolder, folderName);
            if (!Directory.Exists(folder))
                continue;

            files.AddRange(Directory
                .EnumerateFiles(folder, "*", SearchOption.AllDirectories)
                .Where(IsSupportedAudioFile));
        }

        return files;
    }

    private string FindAudioFile(string audioFilePath)
    {
        var directory = Path.GetDirectoryName(audioFilePath);
        if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            return null;

        var fileName = Path.GetFileName(audioFilePath);
        return Directory
            .EnumerateFiles(directory, fileName + ".*", SearchOption.TopDirectoryOnly)
            .FirstOrDefault(IsSupportedAudioFile);
    }

    private static string GetKey(string path) =>
        Path.ChangeExtension(Path.GetFullPath(path), null);

    public void PreloadScene(string sceneName) =>
        coroutineRunner.StartCoroutine(PreloadSceneCoroutine(sceneName));

    public void WhenReady(Action callback) =>
        coroutineRunner.StartCoroutine(WaitUntilReady(callback));

    public bool IsSupportedAudioFile(string path) =>
        path.ToLowerInvariant().TryGetAudioType() != AudioType.UNKNOWN;

}
