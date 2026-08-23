using TMPro;
using UnityEngine;

namespace UltrakULL;

public static class TMPTextExtensions
{
    extension(TMP_Text value)
    {
        public void SetUnderlay(
            Color color,
            float offsetX = 0f,
            float offsetY = 0f,
            float dilate = 0f,
            float softness = 0f)
        {
            if (value == null)
                return;

            Material material = value.fontMaterial;
            material.EnableKeyword(ShaderUtilities.Keyword_Underlay);
            material.SetColor(ShaderUtilities.ID_UnderlayColor, color);
            material.SetFloat(ShaderUtilities.ID_UnderlayOffsetX, offsetX);
            material.SetFloat(ShaderUtilities.ID_UnderlayOffsetY, offsetY);
            material.SetFloat(ShaderUtilities.ID_UnderlayDilate, dilate);
            material.SetFloat(ShaderUtilities.ID_UnderlaySoftness, softness);
            ShaderUtilities.UpdateShaderRatios(material);

            value.UpdateMeshPadding();
            value.ForceMeshUpdate(true);
        }

        public void SetOutline(Color color, float width)
        {
            if (value == null)
                return;

            Material material = value.fontMaterial;
            material.EnableKeyword(ShaderUtilities.Keyword_Outline);
            material.SetColor(ShaderUtilities.ID_OutlineColor, color);
            material.SetFloat(ShaderUtilities.ID_OutlineWidth, width);
            ShaderUtilities.UpdateShaderRatios(material);

            value.UpdateMeshPadding();
            value.ForceMeshUpdate(true);
        }
    }
}
