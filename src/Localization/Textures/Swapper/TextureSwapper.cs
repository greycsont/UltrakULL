using System;
using System.Collections.Generic;
using System.Linq;
using UltrakULL.json;

namespace UltrakULL;

/// <summary>
/// Applies the current language's texture overlay once after scene loading.
/// </summary>
public static partial class TextureSwapper
{
    private static readonly HashSet<string> diagnostics = new();
    private static readonly Dictionary<string, int> replacementCount = new()
    {
        ["Image slot(s)"] = 0,
        ["StyleHUD rank sprite(s)"] = 0,
        ["RawImage(s)"] = 0,
        ["SpriteRenderer(s)"] = 0,
        ["SpriteMask(s)"] = 0,
        ["Renderer property block slot(s)"] = 0,
        ["material property(s)"] = 0,
        ["loaded Texture2D object(s)"] = 0
    };

    private static bool scanInProgress;

    internal static void Initialize() =>
        LanguageManager.OnLanguageChanged += change => LoadFiles(change.NewValue);

    public static void Apply()
    {
        Scan();
        //StaticBatchAtlasSwapper.Apply();
    }

    private static void Scan()
    {
        if (scanInProgress)
            return;

        scanInProgress = true;
        try
        {
            foreach (string key in replacementCount.Keys.ToArray())
                replacementCount[key] = 0;

            ReplaceImages();
            ReplaceStyleHud();
            ReplaceRawImages();
            ReplaceSpriteRenderers();
            ReplaceSpriteMasks();
            ReplaceRendererPropertyBlocks();
            ReplaceMaterialTextures();
            ReplaceLoadedTextures();
            CleanupStaleAssets();

            if (replacementCount.Values.Sum() > 0)
                Logging.Message($"Applied: {string.Join(", ", replacementCount.Select(item =>
                    $"{item.Value} {item.Key}"))}.", true);
        }
        catch (Exception ex)
        {
            Logging.Error($"Scan failed: {ex}", true);
        }
        finally
        {
            scanInProgress = false;
        }
    }

    private static void WarnOnce(string key, string message)
    {
        if (diagnostics.Add(key))
            Logging.Warn(message, true);
    }
}
