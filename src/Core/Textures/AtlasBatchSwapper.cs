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
    /// <summary>
    /// The image before the static batching
    /// </summary>
    /// <param name="name">name of the file</param>
    /// <param name="width">width of the image</param>
    /// <param name="height">height of the image</param>
    /// <param name="pixels">the colours of every pixel</param>
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

        /// <summary>
        /// The name of the file need to replace
        ///   and the position of replace's starting point
        /// </summary>
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
    private static readonly Dictionary<Texture2D, AtlasState> atlases = new();
    private static readonly HashSet<string> diagnostics = new();
    private static int optimizerId;
    private static bool resolving;

    /// <summary>
    /// Capture named textures before static batching
    /// </summary>
    internal static void Capture(StaticSceneOptimizer optimizer)
    {
        ReleaseAtlases();
        pendingTemplates.Clear();

        // the textures mutated in the last scene are still translated, put the originals back
        TextureSwapper.RestoreMutatedTextures();

        optimizerId = optimizer != null ? optimizer.GetInstanceID() : 0;
        if (optimizer == null || LanguageManager.IsEnglish)
            return;

        var seenBefore = new HashSet<Texture2D>();
        var renderers = optimizer.staticMRends;
        if (renderers == null)
        {
            WarnOnce("no-renderers",
                "StaticSceneOptimizer.staticMRends is null; " +
                "cannot capture pre-batch texture names.");
            return;
        }

        // Capture all renderer's material
        foreach (MeshRenderer renderer in renderers)
        {
            CaptureRenderer(renderer);
        }

        Logging.Message(
            $"Captured {pendingTemplates.Count} named " +
            $"pre-batch template(s) from {renderers.Count} renderer(s).", true);

        /// func used in here
        void CaptureRenderer(MeshRenderer renderer)
        {
            if (renderer == null)
                return;

            foreach (Material material in renderer.sharedMaterials)
                CaptureMaterial(material);
        }

        void CaptureMaterial(Material material)
        {
            foreach (var entry in GetMainTextures(material)) 
            {
                var texture = entry.Texture;

                // the material may point at the swapped texture, get the original object back
                var source = TextureSwapper.GetOriginalTexture(texture);
                var template = source != null ? source : texture;
                string name = source != null ? source.name : texture.name;

                // If it's seen before or has no png in the pack, skip it
                if (!seenBefore.Add(texture) || !TextureSwapper.TryGetFile(name, out _))
                    continue;

                Color32[] pixels = ReadPixels(template);
                if (pixels == null) {
                    WarnOnce($"template-read:{texture.GetInstanceID()}",
                        $"Cannot read source template " +
                        $"'{name}' ({template.width}x{template.height}).");
                    continue;
                }

                pendingTemplates.Add(new Template(name, template.width, template.height, pixels));
            }
        }
    }

    private static void ReleaseAtlases()
    {
        foreach (AtlasState state in atlases.Values)
        {
            if (state.Texture != null
                && state.OriginalPixels.Length == state.Texture.width * state.Texture.height)
            {
                state.Texture.SetPixels32(state.OriginalPixels);
                state.Texture.Apply(false, false);
            }
        }

        atlases.Clear();
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
        // Get the atlas of current scene
        List<AtlasState> sceneAtlases = GetOrCreateAtlases(optimizer);
        if (sceneAtlases.Count == 0)
        {
            WarnOnce($"missing-atlas:{optimizerId}",
                "Optimizer finished, but no runtime " +
                "Texture2D was found on its batch materials.");
            resolving = false;
            yield break;
        }

        Template[] pending = pendingTemplates.ToArray();
        var found = new HashSet<string>();
        // Search in every atlas this scene has; each one keeps the regions it owns
        foreach (AtlasState sceneAtlas in sceneAtlases)
        {
            Color32[] source = sceneAtlas.OriginalPixels;
            int sourceWidth = sceneAtlas.Texture.width;
            int sourceHeight = sceneAtlas.Texture.height;

            // Using the template to find it's location
            Task<List<(Template Template, RectInt Rect)>> task = Task.Run(
                () => FindRegions(source, sourceWidth, sourceHeight, pending));
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
                    continue;

                // add the name of position to sceneAtlas
                sceneAtlas.Regions.Add((result.Template.Name, result.Rect));
                found.Add(result.Template.Name);
                Logging.Message(
                    $"Located '{result.Template.Name}' at " +
                    $"({result.Rect.x},{result.Rect.y}) {result.Rect.width}x" +
                    $"{result.Rect.height}.", true);
            }
        }

        foreach (Template template in pending)
        {
            if (found.Contains(template.Name))
                continue;

            WarnOnce($"not-found:{optimizerId}:{template.Name}",
                $"'{template.Name}' was not found in " +
                $"{sceneAtlases.Count} runtime atlas(es).");
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
        int changed = 0;
        foreach (AtlasState state in atlases.Values)
        {
            if (state.Texture == null
                || state.OriginalPixels.Length != state.Texture.width * state.Texture.height)
                continue;

            // Reset the atlas to original one
            state.Texture.SetPixels32(state.OriginalPixels);
            if (LanguageManager.IsEnglish)
            {
                state.Texture.Apply(false, false);
                continue;
            }

            foreach (var region in state.Regions)
            {
                // Get the files to replace the region
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

                try
                {
                    // Get the pixel of the image
                    Color32[] replacementPixels = DecodePixels(file.Bytes);
                    if (replacementPixels == null)
                        continue;
                    // Sets the region to the pixel of image
                    state.Texture.SetPixels32(
                        region.Rect.x, region.Rect.y, region.Rect.width,
                        region.Rect.height, replacementPixels);
                    changed++;
                }
                catch (Exception ex)
                {
                    WarnOnce($"apply:{region.Name}:{file.Path}",
                        $"Failed to apply '{file.Path}': {ex.Message}");
                }
            }
            state.Texture.Apply(false, false);
        }

        if (changed > 0)
            Logging.Message(
                $"Applied {changed} cached region(s) to " +
                $"{atlases.Count} atlas(es) without rescanning.", true);
    }

    private static List<AtlasState> GetOrCreateAtlases(StaticSceneOptimizer optimizer)
    {
        var found = new List<AtlasState>();
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

                if (atlases.TryGetValue(entry.Texture, out AtlasState cached))
                {
                    found.Add(cached);
                    continue;
                }

                Color32[] pixels = ReadPixels(entry.Texture);
                if (pixels == null)
                    continue;
                    
                var state = new AtlasState(entry.Texture, pixels);
                atlases[entry.Texture] = state;
                found.Add(state);
                Logging.Message(
                    $"Runtime atlas candidate: material " +
                    $"'{material.name}', {entry.Property}, texture '{entry.Texture.name}' " +
                    $"{entry.Texture.width}x{entry.Texture.height}.", true);
            }
        }
        return found;
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

    private static Color32[] DecodePixels(byte[] png)
    {
        Texture2D decoded = new(2, 2, TextureFormat.RGBA32, false);
        try
        {
            return ImageConversion.LoadImage(decoded, png, false) ? decoded.GetPixels32() : null;
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            Object.Destroy(decoded);
        }
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
