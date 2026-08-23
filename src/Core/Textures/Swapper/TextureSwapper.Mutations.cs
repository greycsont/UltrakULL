using System;
using System.Collections.Generic;
using UltrakULL.json;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UltrakULL;

public static partial class TextureSwapper
{
    private readonly struct MutatedTexture(byte[] originalPng, FilterMode filterMode,
        TextureWrapMode wrapMode, int anisoLevel)
    {
        public readonly byte[] OriginalPng = originalPng;
        public readonly FilterMode FilterMode = filterMode;
        public readonly TextureWrapMode WrapMode = wrapMode;
        public readonly int AnisoLevel = anisoLevel;
    }

    private static readonly Dictionary<Texture2D, MutatedTexture> mutatedTextures = new();

    private static void ReplaceLoadedTextures()
    {
        if (LanguageManager.IsEnglish)
            return;

        foreach (Texture2D texture in Resources.FindObjectsOfTypeAll<Texture2D>())
        {
            if (texture == null
                || textureReplacementCache.IsReplacement(texture)
                || mutatedTextures.ContainsKey(texture)
                || !TryGetFile(texture.name, out ReplacementFile file))
                continue;

            if (texture.width != file.Width || texture.height != file.Height)
            {
                WarnOnce($"texture-size:{texture.GetInstanceID()}:{file.Path}",
                    $"Size mismatch '{texture.name}': texture {texture.width}x{texture.height}, " +
                    $"PNG {file.Width}x{file.Height}.");
                continue;
            }

            byte[] original = CapturePng(texture);
            if (original == null)
                continue;

            var state = new MutatedTexture(
                original, texture.filterMode, texture.wrapMode, texture.anisoLevel);
            if (!ImageConversion.LoadImage(texture, file.Bytes, false))
            {
                WarnOnce($"load:{texture.GetInstanceID()}:{file.Path}",
                    $"Unity rejected '{file.Path}' for '{texture.name}'.");
                continue;
            }

            ApplySampling(texture, state.FilterMode, state.WrapMode, state.AnisoLevel);
            mutatedTextures.Add(texture, state);
            Logging.Info($"Texture2D '{texture.name}' {texture.width}x{texture.height} | " +
                $"PNG: '{file.Path}'", true);
            replacementCount["loaded Texture2D object(s)"]++;
        }
    }

    private static byte[] CapturePng(Texture2D source)
    {
        RenderTexture temporary = null;
        RenderTexture previous = RenderTexture.active;
        Texture2D readable = null;
        try
        {
            temporary = RenderTexture.GetTemporary(source.width, source.height, 0,
                RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
            Graphics.Blit(source, temporary);
            RenderTexture.active = temporary;
            readable = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
            readable.ReadPixels(new Rect(0, 0, source.width, source.height), 0, 0);
            readable.Apply();
            return ImageConversion.EncodeToPNG(readable);
        }
        catch (Exception ex)
        {
            WarnOnce($"capture:{source.GetInstanceID()}",
                $"Cannot capture '{source.name}': {ex.Message}");
            return null;
        }
        finally
        {
            RenderTexture.active = previous;
            if (temporary != null)
                RenderTexture.ReleaseTemporary(temporary);
            if (readable != null)
                Object.Destroy(readable);
        }
    }

    private static void RestoreMutatedTextures()
    {
        foreach (var item in mutatedTextures)
        {
            Texture2D texture = item.Key;
            MutatedTexture state = item.Value;
            if (texture == null)
                continue;
            if (!ImageConversion.LoadImage(texture, state.OriginalPng, false))
                Logging.Error($"Failed to restore '{texture.name}'.", true);
            ApplySampling(texture, state.FilterMode, state.WrapMode, state.AnisoLevel);
        }
        mutatedTextures.Clear();
    }
}
