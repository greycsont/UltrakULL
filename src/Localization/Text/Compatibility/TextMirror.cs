using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

public static class TextMirror
{
    /// <summary>
    /// If you are worried about why create TMPro as Child
    /// Please Check 5-S's ./FishCanvas/
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static TextMeshProUGUI CreateChild(Text source)
    {
        if (source == null) return null;

        var tmpObject = new GameObject($"TMP_for_{source.gameObject.name}_{source.GetInstanceID()}", typeof(RectTransform));
        tmpObject.transform.SetParent(source.transform, worldPositionStays: false);

        var tmp = tmpObject.AddComponent<TextMeshProUGUI>();
        var layoutElement = tmpObject.AddComponent<LayoutElement>();
        layoutElement.ignoreLayout = true;

        var rt = tmp.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.localScale = Vector3.one;
        rt.localRotation = Quaternion.identity;
        return tmp;
    }

    public static void SetFont(Text source, TextMeshProUGUI target)
    {
        if (source == null || target == null) return;

        TMP_FontAsset twinFont = FontManager.GetTwinFont(source.font != null ? source.font.name : null);
        if (twinFont == null) return;

        target.font = twinFont;
        target.fontSharedMaterial = twinFont.material;
    }

    public static void CopyTextProperties(Text source, TextMeshProUGUI target)
    {
        if (source == null || target == null) return;

        target.text = source.text;
        target.fontSize = source.fontSize;
        target.color = source.color;
        target.richText = source.supportRichText;
        target.raycastTarget = source.raycastTarget;
        target.maskable = source.maskable;
        target.lineSpacing = source.lineSpacing;
        target.alignment = ConvertAlignment(source.alignment);
        target.enableWordWrapping = (source.horizontalOverflow == HorizontalWrapMode.Wrap);
        target.overflowMode = (source.verticalOverflow == VerticalWrapMode.Overflow) ? TextOverflowModes.Overflow : TextOverflowModes.Truncate;
        target.enableAutoSizing = source.resizeTextForBestFit;
        if (source.resizeTextForBestFit)
        {
            target.fontSizeMin = source.resizeTextMinSize;
            target.fontSizeMax = source.resizeTextMaxSize;
        }
        target.fontStyle = ConvertFontStyle(source.fontStyle);
    }

    /// <summary>
    /// It looks alright in 3-2 and 6-2(
    /// </summary>
    /// <param name="tmp"></param>
    internal static void AddIntermissionShadow(TextMeshProUGUI tmp)
    {
        if (tmp == null) return;
        tmp.SetUnderlay(new Color(0f, 0f, 0f, 0.75f), 0.5f, -0.5f, 0.1f);

        // Underlay is enabled after CopyTextProperties() already rebuilt the mesh
        // so recompute padding and rebuild
        // otherwise the offset underlay falls outside the old bounds and gets clipped.
        /* 
         * public override void UpdateMeshPadding()
         * {
         *     m_padding = ShaderUtilities.GetPadding(m_sharedMaterial, m_enableExtraPadding, m_isUsingBold);
         *     m_isMaskingEnabled = ShaderUtilities.IsMaskingEnabled(m_sharedMaterial);
         *     m_havePropertiesChanged = true;
         *     checkPaddingRequired = false;
         *     if (m_textInfo != null)
         *     {
         *         for (int i = 1; i < m_textInfo.materialCount; i++)
         *         {
         *            m_subTextObjects[i].UpdateMeshPadding(m_enableExtraPadding, m_isUsingBold);
         *         }
         *     }
         * }
         */
    }
    
    /// <summary>
    /// Yes, Word Wrapping is intentional in 5-S
    /// But tbh only one fish wil wrapping
    /// </summary>
    /// <param name="tmp"></param>
    internal static void ApplyFishCaughtShadow(TextMeshProUGUI tmp)
    {
        if (tmp == null) return;

        //1 - (1-0.2267)*(1-0.2225) = 0.398 => 0.4f
        tmp.SetUnderlay(new Color(0f, 0f, 0f, 0.4f), offsetY: -0.2f, dilate: 0.15f, softness: 0.15f);

        tmp.enableWordWrapping = false;
        tmp.overflowMode = TextOverflowModes.Overflow;

        
        tmp.ForceMeshUpdate(true);
    }

    /// <summary>
    /// I saw a video of naming in jai's base library and I saw this GOAT way for naiming
    /// </summary>
    /// <param name="tmp"></param>
    internal static void Apply_Fish_Size_Outline(TextMeshProUGUI tmp)
    {
        if (tmp == null) return;

        Material mat = tmp.fontMaterial;
        mat.EnableKeyword(ShaderUtilities.Keyword_Outline);
        mat.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.075f);

        // Hakita uses two shadow in a single object f
        mat.SetColor(ShaderUtilities.ID_OutlineColor, new Color(0f, 0f, 0f, 0.6125f));

        tmp.overflowMode = TextOverflowModes.Overflow;

        
        tmp.ForceMeshUpdate(true);
    }

     internal static void Apply_Fish_Location_Shadow(TextMeshProUGUI tmp)
    {
        if (tmp == null) return;

        tmp.SetUnderlay(new Color(0f, 0f, 0f, 0.8625f), offsetY: -0.25f, dilate: 0.25f); // -0.25f

        tmp.overflowMode = TextOverflowModes.Overflow;

        
        tmp.ForceMeshUpdate(true);
    }

    private static TextAlignmentOptions ConvertAlignment(TextAnchor anchor) => anchor switch
    {
        TextAnchor.UpperLeft => TextAlignmentOptions.TopLeft,
        TextAnchor.UpperCenter => TextAlignmentOptions.Top,
        TextAnchor.UpperRight => TextAlignmentOptions.TopRight,
        TextAnchor.MiddleLeft => TextAlignmentOptions.Left,
        TextAnchor.MiddleCenter => TextAlignmentOptions.Center,
        TextAnchor.MiddleRight => TextAlignmentOptions.Right,
        TextAnchor.LowerLeft => TextAlignmentOptions.BottomLeft,
        TextAnchor.LowerCenter => TextAlignmentOptions.Bottom,
        TextAnchor.LowerRight => TextAlignmentOptions.BottomRight,
        _ => TextAlignmentOptions.TopLeft
    };

    private static FontStyles ConvertFontStyle(FontStyle fontStyle) => fontStyle switch
    {
        FontStyle.Bold => FontStyles.Bold,
        FontStyle.Italic => FontStyles.Italic,
        FontStyle.BoldAndItalic => FontStyles.Bold | FontStyles.Italic,
        _ => FontStyles.Normal
    };
}
