using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

// Pure helpers for mirroring a legacy UnityEngine.UI.Text into a TextMeshProUGUI: building the
// sibling object and copying properties/effects across. Stateless — TMPTwin owns the lifecycle
// and calls into here. Kept separate so the component itself stays lifecycle-only.
internal static class TextMirror
{
    internal static TextMeshProUGUI CreateSibling(Text source)
    {
        if (source == null) return null;

        Transform parent = source.transform.parent;
        GameObject tmpObject = new GameObject($"TMP_for_{source.gameObject.name}_{source.GetInstanceID()}", typeof(RectTransform));
        tmpObject.transform.SetParent(parent, worldPositionStays: false);
        tmpObject.transform.SetSiblingIndex(source.transform.GetSiblingIndex() + 1);

        TextMeshProUGUI tmp = tmpObject.AddComponent<TextMeshProUGUI>();
        LayoutElement layoutElement = tmpObject.AddComponent<LayoutElement>();
        layoutElement.ignoreLayout = true;

        CopyRectTransform(source.rectTransform, tmp.rectTransform);
        return tmp;
    }

    // Fishing result text ("Fish Caught Label" / "Fish Size Text") animates its scale and uses
    // best-fit sizing; copying those normally leaves the twin squashed. Lock size and scale.
    internal static void ApplyFishingTMP(Text source, TextMeshProUGUI tmp)
    {
        if (source == null || tmp == null) return;

        TMP_FontAsset twinFont = FontManager.GetTwinFont(source.font != null ? source.font.name : null);
        if (twinFont != null) tmp.font = twinFont;
        tmp.text = source.text;
        tmp.color = source.color;
        tmp.richText = source.supportRichText;
        tmp.alignment = ConvertAlignment(source.alignment);
        tmp.enableWordWrapping = false;
        tmp.overflowMode = TextOverflowModes.Overflow;
        tmp.enableAutoSizing = false;
        tmp.fontSize = source.fontSize;
        tmp.fontSizeMax = source.fontSize;
        tmp.fontSizeMin = source.fontSize;
        tmp.rectTransform.localScale = Vector3.one;
        tmp.ForceMeshUpdate(true);
    }

    internal static void CopyRectTransform(RectTransform source, RectTransform destination)
    {
        if (source == null || destination == null) return;

        destination.anchorMin = source.anchorMin;
        destination.anchorMax = source.anchorMax;
        destination.pivot = source.pivot;
        destination.anchoredPosition = source.anchoredPosition;
        destination.sizeDelta = source.sizeDelta;
        destination.localScale = source.localScale;
        destination.localEulerAngles = source.localEulerAngles;
        destination.offsetMin = source.offsetMin;
        destination.offsetMax = source.offsetMax;
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
