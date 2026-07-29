using System;
using System.Collections.Generic;
using UltrakULL.json;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UltrakULL;

public static partial class TextureSwapper
{
    private static readonly ReplacementCache<Sprite> spriteReplacementCache = new();
    private static readonly ReplacementCache<Texture> textureReplacementCache = new();
    private static readonly Dictionary<(Material, string), Texture2D> materialTextureCache = new();

    private static Sprite GetDesiredSprite(Sprite value)
    {
        if (value == null)
            return null;
        Sprite original = spriteReplacementCache.GetOriginal(value);
        if (LanguageManager.IsEnglish || !TryGetFile(original.name, out ReplacementFile file))
            return original;
        if (spriteReplacementCache.TryGetCurrent(original, out Sprite cached))
            return cached;

        Rect rect = original.rect;
        int width = Mathf.RoundToInt(rect.width);
        int height = Mathf.RoundToInt(rect.height);
        if (width <= 0 || height <= 0)
        {
            WarnOnce($"sprite-empty:{original.GetInstanceID()}",
                $"Invalid sprite rect '{original.name}': {width}x{height}.");
            return original;
        }

        float widthScale = file.Width / rect.width;
        float heightScale = file.Height / rect.height;
        float originalAspect = rect.width / rect.height;
        float replacementAspect = (float)file.Width / file.Height;
        if (!Mathf.Approximately(originalAspect, replacementAspect))
            WarnOnce($"sprite-aspect:{original.GetInstanceID()}:{file.Path}",
                $"Aspect change '{original.name}': {originalAspect:0.###} -> " +
                $"{replacementAspect:0.###} ({width}x{height} -> {file.Width}x{file.Height}).");

        Texture2D texture = CreateTexture(file, original.texture);
        if (texture == null)
            return original;

        Vector2 pivot = new(original.pivot.x / rect.width, original.pivot.y / rect.height);
        Vector4 border = original.border;
        border = new Vector4(border.x * widthScale, border.y * heightScale,
            border.z * widthScale, border.w * heightScale);
        Sprite replacement;
        try
        {
            replacement = Sprite.Create(texture, new Rect(0, 0, file.Width, file.Height),
                pivot, original.pixelsPerUnit, 0, SpriteMeshType.FullRect, border);
        }
        catch (Exception ex)
        {
            Object.Destroy(texture);
            WarnOnce($"sprite-create:{original.GetInstanceID()}:{file.Path}",
                $"Cannot create sprite '{original.name}': {ex.Message}");
            return original;
        }

        replacement.name = original.name;
        spriteReplacementCache.Add(original, replacement);
        return replacement;
    }

    private static Texture GetDesiredTexture(Texture value)
    {
        if (value == null)
            return null;
        Texture original = textureReplacementCache.GetOriginal(value);
        if (LanguageManager.IsEnglish
            || original is not Texture2D original2D
            || !TryGetFile(original.name, out ReplacementFile file))
            return original;
        if (textureReplacementCache.TryGetCurrent(original2D, out Texture cached))
            return cached;

        Texture2D replacement = CreateTexture(file, original2D);
        if (replacement == null)
            return original;
        textureReplacementCache.Add(original, replacement);
        return replacement;
    }

    private static Texture GetCanonicalTexture(Texture value) =>
        textureReplacementCache.GetOriginal(value);

    private static Texture GetDesiredMaterialTexture(Material material, string property,
        Texture original, ReplacementFile file)
    {
        if (LanguageManager.IsEnglish)
            return original;

        var key = (material, property);
        if (materialTextureCache.TryGetValue(key, out Texture2D cached) && cached != null)
            return cached;

        Texture2D replacement = CreateTexture(file, original);
        if (replacement == null)
            return original;
        materialTextureCache[key] = replacement;
        textureReplacementCache.Add(original, replacement, false);
        return replacement;
    }

    private static bool IsUnusableAssetName(string name) =>
        string.IsNullOrWhiteSpace(name) || string.Equals(name.Trim(), "untitled");

    private static bool IsMainTextureProperty(string property) 
        => string.Equals(property, "_MainTex") 
        || string.Equals(property, "_BaseMap")
        || string.Equals(property, "_MainTexture");

    private static Texture2D CreateTexture(ReplacementFile file, Texture source)
    {
        var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        if (!ImageConversion.LoadImage(texture, file.Bytes, false))
        {
            Object.Destroy(texture);
            WarnOnce($"decode:{file.Path}", $"Cannot decode '{file.Path}'.");
            return null;
        }
        texture.name = $"UltrakULL:{LanguageManager.Current.Name}:{source.name}";
        ApplySampling(texture, source.filterMode, source.wrapMode, source.anisoLevel);
        return texture;
    }

    private static void ApplySampling(Texture texture, FilterMode filter,
        TextureWrapMode wrap, int aniso)
    {
        texture.filterMode = filter;
        texture.wrapMode = wrap;
        texture.anisoLevel = aniso;
    }

    private static void QueueGeneratedAssetsForCleanup()
    {
        spriteReplacementCache.QueueCleanup();
        textureReplacementCache.QueueCleanup();
        materialTextureCache.Clear();
    }

    private static void CleanupStaleAssets()
    {
        spriteReplacementCache.Cleanup(sprite =>
        {
            Texture texture = sprite.texture;
            Object.Destroy(sprite);
            if (texture != null)
                Object.Destroy(texture);
        });
        textureReplacementCache.Cleanup(Object.Destroy);
    }

    private static void LogReplacement(Component component, string slot, Object original,
        Object replacement) =>
        Logging.Info($"{component.transform.GetPath()} | {slot} | " +
            $"'{original?.name ?? "<null>"}' -> '{replacement?.name ?? "<null>"}'" +
            GetSourceSuffix(original), true);

    private static void LogReplacement(Material material, string property, Texture original,
        Texture replacement) =>
        Logging.Info($"Material '{material.name}' ({material.shader.name}) | {property} | " +
            $"'{original?.name ?? "<null>"}' -> '{replacement?.name ?? "<null>"}'" +
            GetSourceSuffix(original), true);

    private static string GetSourceSuffix(Object value)
    {
        Object canonical = value;
        if (value is Sprite sprite)
            canonical = spriteReplacementCache.GetOriginal(sprite);
        else if (value is Texture texture)
            canonical = textureReplacementCache.GetOriginal(texture);

        return canonical != null && TryGetFile(canonical.name, out ReplacementFile file)
            ? $" | PNG: '{file.Path}'"
            : LanguageManager.IsEnglish ? " | restoring original" : "";
    }
}
