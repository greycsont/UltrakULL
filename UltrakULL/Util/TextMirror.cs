using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

// Pure helpers for mirroring a legacy UnityEngine.UI.Text into a TextMeshProUGUI: building the
// sibling object and copying properties/effects across. Stateless — TMPTwin owns the lifecycle
// and calls into here. Kept separate so the component itself stays lifecycle-only.
internal static class TextMirror
{
    /// <summary>
    /// If you are worried about why create TMPro as Child
    /// Please Check 5-S's ./FishCanvas/
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    internal static TextMeshProUGUI CreateChild(Text source)
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

    internal static void CopyTextProperties(Text source, TextMeshProUGUI target)
    {
        if (source == null || target == null) return;

        TMP_FontAsset twinFont = FontManager.GetTwinFont(source.font != null ? source.font.name : null);
        if (twinFont != null) target.font = twinFont;
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

    [NeedRework]
    internal static void SyncEffects(Text source, TextMeshProUGUI target)
    {
        if (source == null || target == null) return;

        Shadow sourceShadow = source.GetComponent<Shadow>();
        Shadow targetShadow = target.GetComponent<Shadow>();
        if (sourceShadow != null)
        {
            // Outline derives from Shadow, so an existing Outline would match GetComponent<Shadow>();
            // only reuse a plain Shadow, otherwise replace it.
            if (targetShadow == null || targetShadow.GetType() != typeof(Shadow))
            {
                if (targetShadow != null) Object.Destroy(targetShadow);
                targetShadow = target.gameObject.AddComponent<Shadow>();
            }
            CopyShadowSettings(sourceShadow, targetShadow);
        }
        else if (targetShadow != null && targetShadow.GetType() == typeof(Shadow))
        {
            Object.Destroy(targetShadow);
        }

        Outline sourceOutline = source.GetComponent<Outline>();
        Outline targetOutline = target.GetComponent<Outline>();
        if (sourceOutline != null)
        {
            if (targetOutline == null)
                targetOutline = target.gameObject.AddComponent<Outline>();
            CopyShadowSettings(sourceOutline, targetOutline);
        }
        else if (targetOutline != null)
        {
            Object.Destroy(targetOutline);
        }
    }

    private static void CopyShadowSettings(Shadow source, Shadow target)
    {
        if (source == null || target == null) return;
        target.effectColor = source.effectColor;
        target.effectDistance = source.effectDistance;
        target.useGraphicAlpha = source.useGraphicAlpha;
    }

    // Drop shadow for the intermission text. UI.Shadow is inert on TMP, so use TMP's native underlay
    // on a per-instance material. Re-applied each Sync since CopyTextProperties resets the material.
    internal static void AddIntermissionShadow(TextMeshProUGUI tmp)
    {
        if (tmp == null) return;
        Material mat = tmp.fontMaterial; // instantiates a per-label material copy; leaves shared ones alone
        mat.EnableKeyword(ShaderUtilities.Keyword_Underlay);
        mat.SetColor(ShaderUtilities.ID_UnderlayColor, new Color(0f, 0f, 0f, 0.75f));
        mat.SetFloat(ShaderUtilities.ID_UnderlayOffsetX, 0.5f);
        mat.SetFloat(ShaderUtilities.ID_UnderlayOffsetY, -0.5f);
        mat.SetFloat(ShaderUtilities.ID_UnderlayDilate, 0.1f);
        mat.SetFloat(ShaderUtilities.ID_UnderlaySoftness, 0f);

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
        tmp.UpdateMeshPadding();
        tmp.ForceMeshUpdate();
    }
    
    /// <summary>
    /// Yes, Word Wrapping is intentional in 5-S
    /// But tbh only one fish wil wrapping
    /// </summary>
    /// <param name="source"></param>
    /// <param name="tmp"></param>
    internal static void ApplyFishingTMP(Text source, TextMeshProUGUI tmp)
    {
        if (source == null || tmp == null) return;

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
