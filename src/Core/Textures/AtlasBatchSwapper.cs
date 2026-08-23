using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UltrakULL.json;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UltrakULL;

/// <summary>
/// IDK why hakita choose to run static batching at runtime
/// </summary>
internal static class StaticBatchAtlasSwapper
{
    private readonly struct Template(string name, int width, int height, Color32[] pixels)
    {
        public readonly string Name = name;
        public readonly int Width = width;
        public readonly int Height = height;
        public readonly Color32[] Pixels = pixels;
    }

    private sealed class AtlasState(Texture2D texture, Color32[] originalPixels)
    {
        public readonly Texture2D Texture = texture;
        public readonly Color32[] OriginalPixels = originalPixels;
        public readonly List<(string Name, RectInt Rect)> Regions = new();
    }

    private readonly struct FeaturePoint(int x, int y, Color32 color, int contrast)
    {
        public readonly int X = x;
        public readonly int Y = y;
        public readonly Color32 Color = color;
        public readonly int Contrast = contrast;
    }

    private static readonly List<Template> pendingTemplates = new();
    private static readonly List<AtlasState> atlases = new();
    private static readonly HashSet<string> diagnostics = new();
    private static int optimizerId;
    private static bool resolving;

    /// <summary>
    /// Capture named textures before static batching
    /// </summary>
    internal static void Capture(StaticSceneOptimizer optimizer)
    {
        pendingTemplates.Clear();
        optimizerId = optimizer != null ? optimizer.GetInstanceID() : 0;
        if (optimizer == null || LanguageManager.IsEnglish)
            return;

        var seen = new HashSet<Texture2D>();
        List<MeshRenderer> renderers = optimizer.staticMRends;
        if (renderers == null)
        {
            WarnOnce("no-renderers",
                "StaticSceneOptimizer.staticMRends is null; " +
                "cannot capture pre-batch texture names.");
            return;
        }

        foreach (MeshRenderer renderer in renderers)
            CaptureRenderer(renderer);

        Logging.Message(
            $"Captured {pendingTemplates.Count} named " +
            $"pre-batch template(s) from {renderers.Count} renderer(s).", true);

        void CaptureRenderer(MeshRenderer renderer)
        {
            if (renderer == null)
                return;

            foreach (Material material in renderer.sharedMaterials)
                CaptureMaterial(material);
        }

        void CaptureMaterial(Material material)
        {
            foreach (var entry in GetMainTextures(material)) {
                Texture2D texture = entry.Texture;
                if (!seen.Add(texture)
                    || !TextureSwapper.TryGetFile(texture.name, out _))
                    continue;

                Color32[] pixels = ReadPixels(texture);
                if (pixels == null) {
                    WarnOnce($"template-read:{texture.GetInstanceID()}",
                        $"Cannot read source template " +
                        $"'{texture.name}' ({texture.width}x{texture.height}).");
                    continue;
                }
                pendingTemplates.Add(new Template(
                    texture.name, texture.width, texture.height, pixels));
            }
        }
    }

    /// <summary>
    /// Find captured textures in generated atlases
    /// </summary>
    internal static IEnumerator Resolve(StaticSceneOptimizer optimizer)
    {
        if (resolving
            || optimizer == null
            || optimizer.GetInstanceID() != optimizerId
            || pendingTemplates.Count == 0
            || LanguageManager.IsEnglish)
            yield break;

        resolving = true;
        var newAtlases = CollectAtlases(optimizer);
        if (newAtlases.Count == 0)
        {
            WarnOnce($"missing-atlas:{optimizerId}",
                "Optimizer finished, but no anonymous runtime " +
                "Texture2D was found on its batch materials.");
            resolving = false;
            yield break;
        }

        foreach (AtlasState atlas in newAtlases)
        {
            Template[] templates = pendingTemplates.ToArray();
            Color32[] source = atlas.OriginalPixels;
            int sourceWidth = atlas.Texture.width;
            int sourceHeight = atlas.Texture.height;
            Task<List<(Template Template, RectInt Rect)>> task = Task.Run(
                () => FindRegions(source, sourceWidth, sourceHeight, templates));
            while (!task.IsCompleted)
                yield return null;

            if (task.IsFaulted)
            {
                Logging.Error(
                    $"Region search failed for " +
                    $"{sourceWidth}x{sourceHeight} atlas: {task.Exception}", true);
                continue;
            }

            foreach (var result in task.Result)
            {
                if (result.Rect.width <= 0)
                {
                    WarnOnce($"not-found:{optimizerId}:{result.Template.Name}",
                        $"'{result.Template.Name}' was not found " +
                        $"in atlas '{atlas.Texture.name}' {sourceWidth}x{sourceHeight}.");
                    continue;
                }
                atlas.Regions.Add((result.Template.Name, result.Rect));
                Logging.Message(
                    $"Located '{result.Template.Name}' at " +
                    $"({result.Rect.x},{result.Rect.y}) {result.Rect.width}x" +
                    $"{result.Rect.height}.", true);
            }
            atlases.Add(atlas);
        }

        pendingTemplates.Clear();
        resolving = false;
        Apply();
    }

    /// <summary>
    /// Restore atlases and apply current replacements
    /// </summary>
    internal static void Apply()
    {
        foreach (AtlasState atlas in atlases)
        {
            if (atlas.Texture == null
                || atlas.OriginalPixels.Length != atlas.Texture.width * atlas.Texture.height)
                continue;

            atlas.Texture.SetPixels32(atlas.OriginalPixels);
            if (LanguageManager.IsEnglish)
            {
                atlas.Texture.Apply(false, false);
                continue;
            }

            int changed = 0;
            foreach (var region in atlas.Regions)
            {
                if (!TextureSwapper.TryGetFile(region.Name, out TextureSwapper.ReplacementFile file))
                    continue;

                if (file.Width != region.Rect.width || file.Height != region.Rect.height)
                {
                    WarnOnce($"size:{region.Name}:{file.Path}",
                        $"Cannot put '{file.Path}' into cached " +
                        $"region '{region.Name}': PNG is {file.Width}x{file.Height}, region is " +
                        $"{region.Rect.width}x{region.Rect.height}. Atlas layout " +
                        "must not be resized.");
                    continue;
                }

                Texture2D replacement = new(2, 2, TextureFormat.RGBA32, false);
                try
                {
                    if (!ImageConversion.LoadImage(replacement, file.Bytes, false))
                        continue;
                    atlas.Texture.SetPixels32(
                        region.Rect.x, region.Rect.y, region.Rect.width,
                        region.Rect.height, replacement.GetPixels32());
                    changed++;
                }
                catch (Exception ex)
                {
                    WarnOnce($"apply:{region.Name}:{file.Path}",
                        $"Failed to apply '{file.Path}': {ex.Message}");
                }
                finally
                {
                    Object.Destroy(replacement);
                }
            }
            atlas.Texture.Apply(false, false);
            if (changed > 0)
                Logging.Message(
                    $"Applied {changed} cached region(s) to " +
                    $"'{atlas.Texture.name}' without rescanning.", true);
        }
    }

    /// <summary>
    /// Collect atlases generated by static batching
    /// </summary>
    private static List<AtlasState> CollectAtlases(StaticSceneOptimizer optimizer)
    {
        var result = new List<AtlasState>();
        var seen = new HashSet<Texture2D>();
        Material[] materials =
        {
            optimizer.batchMaterialOutdoors,
            optimizer.batchMaterialEnvironment
        };

        foreach (Material material in materials)
        {
            foreach (var entry in GetMainTextures(material))
            {
                if (!seen.Add(entry.Texture))
                    continue;

                Color32[] pixels = ReadPixels(entry.Texture);
                if (pixels == null)
                    continue;
                    
                result.Add(new AtlasState(entry.Texture, pixels));
                Logging.Message(
                    $"Runtime atlas candidate: material " +
                    $"'{material.name}', {entry.Property}, texture '{entry.Texture.name}' " +
                    $"{entry.Texture.width}x{entry.Texture.height}.", true);
            }
        }
        return result;
    }

    /// <summary>
    /// Enumerate supported texture properties
    /// </summary>
    private static IEnumerable<(string Property, Texture2D Texture)> GetMainTextures(
        Material material)
    {
        if (material == null || material.shader == null)
            yield break;

        int count = material.shader.GetPropertyCount();
        for (int i = 0; i < count; i++) {
            if (material.shader.GetPropertyType(i) !=
                UnityEngine.Rendering.ShaderPropertyType.Texture)
                continue;

            string property = material.shader.GetPropertyName(i);
            if (property != "_MainTex"
                && property != "_BaseMap"
                && property != "_MainTexture")
                continue;

            if (material.GetTexture(property) is Texture2D texture)
                yield return (property, texture);
        }
    }

    /// <summary>
    /// Find every template in one atlas
    /// </summary>
    private static List<(Template Template, RectInt Rect)> FindRegions(
        Color32[] source, int sourceWidth,
        int sourceHeight, Template[] templates)
    {
        var results = new List<(Template, RectInt)>(templates.Length);
        foreach (Template template in templates)
            results.Add((template,
                FindRegion(source, sourceWidth, sourceHeight, template)));
        return results;
    }

    /// <summary>
    /// Sample a 5x5 grid and keep the 8 colors furthest from the average RGBA
    /// Scan them across the atlas and fully compare every matching candidate
    /// </summary>
    private static RectInt FindRegion(Color32[] source, int sourceWidth, int sourceHeight,
        Template template)
    {
        if (template.Width > sourceWidth || template.Height > sourceHeight)
            return default;

        FeaturePoint[] features = GetFeaturePoints(template);
        int maxX = sourceWidth - template.Width;
        int maxY = sourceHeight - template.Height;

        for (int y = 0; y <= maxY; y++) {
            for (int x = 0; x <= maxX; x++) {
                if (MatchesFeatures(source, sourceWidth, x, y, features)
                    && MatchesImage(source, sourceWidth, x, y, template))
                    return new RectInt(x, y, template.Width, template.Height);
            }
        }

        return default;
    }

    /// <summary>
    /// Select 8 distinctive points from a 5x5 template grid
    /// </summary>
    private static FeaturePoint[] GetFeaturePoints(Template template)
    {
        const int gridSize = 5;
        const int featureCount = 8;
        long red = 0, green = 0, blue = 0, alpha = 0;
        foreach (Color32 pixel in template.Pixels) {
            red += pixel.r;
            green += pixel.g;
            blue += pixel.b;
            alpha += pixel.a;
        }

        int count = template.Pixels.Length;
        int averageRed = (int)(red / count);
        int averageGreen = (int)(green / count);
        int averageBlue = (int)(blue / count);
        int averageAlpha = (int)(alpha / count);

        var points = new List<FeaturePoint>(gridSize * gridSize);
        for (int gy = 0; gy < gridSize; gy++) {
            for (int gx = 0; gx < gridSize; gx++) {
                int x = gx * (template.Width - 1) / (gridSize - 1);
                int y = gy * (template.Height - 1) / (gridSize - 1);
                Color32 color = template.Pixels[y * template.Width + x];
                int contrast = Math.Abs(color.r - averageRed)
                    + Math.Abs(color.g - averageGreen)
                    + Math.Abs(color.b - averageBlue)
                    + Math.Abs(color.a - averageAlpha);
                points.Add(new FeaturePoint(x, y, color, contrast));
            }
        }

        points.Sort((a, b) => b.Contrast.CompareTo(a.Contrast));
        return points.GetRange(0, Math.Min(featureCount, points.Count)).ToArray();
    }

    private static bool MatchesFeatures(Color32[] source, int sourceWidth, int x, int y,
        FeaturePoint[] features)
    {
        foreach (FeaturePoint feature in features) {
            Color32 candidate = source[(y + feature.Y) * sourceWidth + x + feature.X];
            if (!feature.Color.Equals(candidate))
                return false;
        }
        return true;
    }

    private static bool MatchesImage(Color32[] source, int sourceWidth, int x, int y,
        Template template)
    {
        for (int ty = 0; ty < template.Height; ty++) {
            for (int tx = 0; tx < template.Width; tx++) {
                Color32 expected = template.Pixels[ty * template.Width + tx];
                Color32 candidate = source[(y + ty) * sourceWidth + x + tx];
                if (!expected.Equals(candidate))
                    return false;
            }
        }
        return true;
    }

    private static Color32[] ReadPixels(Texture source)
    {
        RenderTexture temporary = null;
        RenderTexture previous = RenderTexture.active;
        Texture2D readable = null;
        try {
            temporary = RenderTexture.GetTemporary(
                source.width, source.height, 0, RenderTextureFormat.ARGB32,
                RenderTextureReadWrite.Default);
            Graphics.Blit(source, temporary);
            RenderTexture.active = temporary;
            readable = new Texture2D(
                source.width, source.height, TextureFormat.RGBA32, false);
            readable.ReadPixels(
                new Rect(0, 0, source.width, source.height), 0, 0);
            readable.Apply();
            return readable.GetPixels32();
        } catch (Exception ex) {
            WarnOnce($"read:{source.GetInstanceID()}",
                $"Failed to read '{source.name}': {ex.Message}");
            return null;
        } finally {
            RenderTexture.active = previous;
            if (temporary != null)
                RenderTexture.ReleaseTemporary(temporary);
            if (readable != null)
                Object.Destroy(readable);
        }
    }

    private static void WarnOnce(string key, string message)
    {
        if (diagnostics.Add(key))
            Logging.Warn(message, true);
    }
}
