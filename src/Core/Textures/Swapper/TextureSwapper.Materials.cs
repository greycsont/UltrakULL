using UnityEngine;

namespace UltrakULL;

public static partial class TextureSwapper
{
    private static void ReplaceRendererPropertyBlocks()
    {
        foreach (var renderer in Resources.FindObjectsOfTypeAll<Renderer>())
        {
            if (renderer == null)
                continue;

            Material[] materials = renderer.sharedMaterials;
            var block = new MaterialPropertyBlock();
            for (int materialIndex = 0; materialIndex < materials.Length; materialIndex++)
            {
                var material = materials[materialIndex];
                if (material == null || material.shader == null)
                    continue;

                block.Clear();
                renderer.GetPropertyBlock(block, materialIndex);
                if (block.isEmpty)
                    continue;

                bool modified = false;
                foreach (string property in material.GetTexturePropertyNames())
                {
                    int propertyId = Shader.PropertyToID(property);
                    // Shared material values belong to ReplaceMaterialTextures.
                    // This pass must only preserve and replace actual instance overrides.
                    Texture current = block.GetTexture(propertyId);
                    if (current == null)
                        continue;

                    Texture desired = ResolveMaterialTexture(material, property, current);
                    if (desired == current)
                        continue;

                    block.SetTexture(propertyId, desired);
                    modified = true;
                    replacementCount["Renderer property block slot(s)"]++;
                    Logging.Info(
                        $"Renderer " +
                        $"'{renderer.transform.GetPath()}' | " +
                        $"material[{materialIndex}] '{material.name}'.{property} | " +
                        $"'{current.name}' -> '{desired?.name ?? "<null>"}'", true);
                }

                if (modified)
                    renderer.SetPropertyBlock(block, materialIndex);
            }
        }
    }

    private static void ReplaceMaterialTextures()
    {
        foreach (var material in Resources.FindObjectsOfTypeAll<Material>())
            ReplaceMaterialTextureProperties(material);
    }

    private static void ReplaceMaterialTextureProperties(Material material)
    {
        if (material == null || material.shader == null)
            return;

        foreach (string property in material.GetTexturePropertyNames())
        {
            Texture current = material.GetTexture(property);
            Texture desired = ResolveMaterialTexture(material, property, current);
            if (desired == current)
                continue;

            LogReplacement(material, property, current, desired);
            material.SetTexture(property, desired);
            replacementCount["material property(s)"]++;
        }
    }

    private static Texture ResolveMaterialTexture(Material material, string property,
        Texture current)
    {
        var desired = GetDesiredTexture(current);
        var canonical = GetCanonicalTexture(current);
        if (desired != current
            || canonical == null
            || !IsUnusableAssetName(canonical.name)
            || !IsMainTextureProperty(property)
            || !TryGetFile(material.name, out ReplacementFile file))
            return desired;

        desired = GetDesiredMaterialTexture(material, property, canonical, file);
        if (desired != current
            && diagnostics.Add($"material-fallback:{material.GetInstanceID()}:{property}"))
            Logging.Info(
                $"Texture name '{canonical.name}' is not usable; " +
                $"matched {material.name}.{property} through material name -> '{file.Path}'.", true);
        return desired;
    }
}
