using System;
using System.Collections.Generic;
using System.IO;
using UltrakULL.json;

namespace UltrakULL;

public static partial class TextureSwapper
{
    internal readonly struct ReplacementFile(string path, byte[] bytes, int width, int height)
    {
        public readonly string Path = path;
        public readonly byte[] Bytes = bytes;
        public readonly int Width = width;
        public readonly int Height = height;
    }

    private static readonly Dictionary<string, ReplacementFile> files = new();

    private static void LoadFiles(Lang language)
    {
        RestoreMutatedTextures();
        QueueGeneratedAssetsForCleanup();
        files.Clear();
        diagnostics.Clear();

        if (language == null || language.IsEnglish) {
            Logging.Message("Restored original textures for English.", true);
            return;
        }

        string folder = language.TextureFolder;
        if (!Directory.Exists(folder))
        {
            WarnOnce($"folder:{folder}", $"Texture folder does not exist: '{folder}'.");
            return;
        }

        foreach (string path in Directory.EnumerateFiles(folder, "*.png"))
        {
            if (!TryReadPngSize(path, out byte[] bytes, out int width, out int height))
                continue;

            string name = Path.GetFileNameWithoutExtension(path);
            if (files.ContainsKey(name))
            {
                WarnOnce($"duplicate:{name}",
                    $"Multiple PNGs map to '{name}'; using '{files[name].Path}'.");
                continue;
            }

            files.Add(name, new ReplacementFile(path, bytes, width, height));
        }

        Logging.Message($"Loaded {files.Count} replacement PNG(s) for '{language.Name}'.", true);
    }

    /// <summary>
    /// PNG signature: https://www.w3.org/TR/PNG-Structure.html#3Chunks
    /// IHDR header: https://www.w3.org/TR/PNG-Chunks.html#C.IHDR
    /// Width and height are 4-byte unsigned integers in network byte order.
    /// </summary>
    private static bool TryReadPngSize(string path, out byte[] png, out int width, out int height)
    {
        byte[] pngSignature = { 137, 80, 78, 71, 13, 10, 26, 10 };
        byte[] ihdrHeader = { 0, 0, 0, 13, 73, 72, 68, 82 };
        try
        {
            png = File.ReadAllBytes(path);
        }
        catch (Exception ex)
        {
            png = null;
            width = height = 0;
            WarnOnce($"read:{path}", $"Cannot read '{path}': {ex.Message}");
            return false;
        }

        width = height = 0;
        if (png.Length < 24
            || !png.AsSpan(0, 8).SequenceEqual(pngSignature)
            || !png.AsSpan(8, 8).SequenceEqual(ihdrHeader))
        {
            WarnOnce($"png:{path}", $"Invalid PNG: '{path}'.");
            return false;
        }

        Span<byte> ihdr = png.AsSpan(16, 13);
        width = ReadBigEndianInt(ihdr[..4]);
        height = ReadBigEndianInt(ihdr.Slice(4, 4));
        if (width > 0 && height > 0)
            return true;

        WarnOnce($"png:{path}", $"Invalid PNG: '{path}'.");
        return false;

        int ReadBigEndianInt(ReadOnlySpan<byte> bytes) =>
            (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3];
    }

    internal static bool TryGetFile(string assetName, out ReplacementFile file)
    {
        file = default;
        if (string.IsNullOrEmpty(assetName))
            return false;

        if (files.TryGetValue(assetName, out file))
            return true;

        const string suffix = " (Instance)";
        string normalized = assetName;
        while (normalized.EndsWith(suffix, StringComparison.Ordinal))
            normalized = normalized.Substring(0, normalized.Length - suffix.Length);

        if (normalized == assetName || !files.TryGetValue(normalized, out file))
            return false;

        if (diagnostics.Add($"normalized:{assetName}:{normalized}"))
            Logging.Info($"Normalized '{assetName}' -> '{normalized}'.", true);
        return true;
    }
}
