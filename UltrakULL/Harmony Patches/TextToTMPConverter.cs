using System;
using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
public static class TextToTMPConverter
{
private static readonly Dictionary<int, TextMeshProUGUI> textToTMP = new Dictionary<int, TextMeshProUGUI>();

[HarmonyPatch(typeof(Text), "OnEnable")]
public static class TextOnEnablePatch
{
[HarmonyPostfix]
public static void Postfix(Text __instance)
{
if (__instance == null)
{
return;
}

ConvertTextToTMP(__instance);
}
}

[HarmonyPatch(typeof(Text), "set_text")]
public static class TextSetTextPatch
{
[HarmonyPostfix]
public static void Postfix(Text __instance)
{
if (__instance == null)
{
return;
}

UpdateTMPText(__instance);
}
}

[HarmonyPatch(typeof(Text), "OnDisable")]
public static class TextOnDisablePatch
{
[HarmonyPostfix]
public static void Postfix(Text __instance)
{
if (__instance == null)
{
return;
}

SetTMPActiveState(__instance, false);
}
}

private static void ConvertTextToTMP(Text source)
{
    if (source == null)
    {
        return;
    }

    if (IsIntermissionShadowParent(source))
    {
        source.canvasRenderer.SetAlpha(0f);
        return;
    }

    TextMeshProUGUI tmp = GetTMPForSource(source);
    if (tmp == null)
    {
        tmp = CreateTMPSibling(source);
        if (tmp == null)
        {
            return;
        }
        textToTMP[source.GetInstanceID()] = tmp;
    }

    CopyRectTransform(source.rectTransform, tmp.rectTransform);
    CopyTextProperties(source, tmp);

    if (Core.TMPFontReady)
    {
        TextMeshProFontSwap.SwapTMPFont(ref tmp);
    }

    if (IsIntermissionShadowChild(source))
    {
        ApplyIntermissionHardShadow(tmp);
    }

    source.canvasRenderer.SetAlpha(0f);
    SetTMPActiveState(source, source.isActiveAndEnabled);
}

private static void UpdateTMPText(Text source)
{
TextMeshProUGUI tmp = GetTMPForSource(source);
if (tmp == null)
{
return;
}

CopyRectTransform(source.rectTransform, tmp.rectTransform);

string currentText = source.text;
if (tmp.text == currentText)
{
return;
}

tmp.text = currentText;
tmp.ForceMeshUpdate();

if (tmp.rectTransform != null)
{
LayoutRebuilder.MarkLayoutForRebuild(tmp.rectTransform);
}
}

private static void SetTMPActiveState(Text source, bool active)
{
TextMeshProUGUI tmp = GetTMPForSource(source);
if (tmp == null)
{
return;
}

if (tmp.gameObject.activeSelf != active)
{
tmp.gameObject.SetActive(active);
}

if (tmp.rectTransform != null)
{
LayoutRebuilder.MarkLayoutForRebuild(tmp.rectTransform);
}
}

private static TextMeshProUGUI GetTMPForSource(Text source)
{
    if (source == null)
    {
        return null;
    }

    int id = source.GetInstanceID();
    if (textToTMP.TryGetValue(id, out TextMeshProUGUI tmp) && tmp != null)
    {
        return tmp;
    }

    textToTMP.Remove(id);
    return null;
}

private static bool IsIntermissionShadowParent(Text source)
{
    if (source == null || source.name != "Text" || source.transform.parent == null)
    {
        return false;
    }

    string sceneName = GetCurrentSceneName();
    if (sceneName != "Intermission1" && sceneName != "Intermission2")
    {
        return false;
    }

    return source.transform.parent.name == "Panel (1)"
        && source.transform.parent.parent != null
        && source.transform.parent.parent.name == "Panel"
        && source.transform.parent.parent.parent != null
        && source.transform.parent.parent.parent.name == "PowerUpVignette"
        && source.transform.parent.parent.parent.parent != null
        && source.transform.parent.parent.parent.parent.name == "Canvas";
}

private static bool IsIntermissionShadowChild(Text source)
{
    if (source == null || source.name != "Text (1)" || source.transform.parent == null)
    {
        return false;
    }

    string sceneName = GetCurrentSceneName();
    if (sceneName != "Intermission1" && sceneName != "Intermission2")
    {
        return false;
    }

    return source.transform.parent.name == "Text"
        && source.transform.parent.parent != null
        && source.transform.parent.parent.name == "Panel (1)"
        && source.transform.parent.parent.parent != null
        && source.transform.parent.parent.parent.name == "Panel"
        && source.transform.parent.parent.parent.parent != null
        && source.transform.parent.parent.parent.parent.name == "PowerUpVignette"
        && source.transform.parent.parent.parent.parent.parent != null
        && source.transform.parent.parent.parent.parent.parent.name == "Canvas";
}

private static void ApplyIntermissionHardShadow(TextMeshProUGUI target)
{
    if (target == null)
    {
        return;
    }

    Material shadowMaterial = new Material(target.fontSharedMaterial);
    shadowMaterial.SetVector("_UnderlayColor", new Vector4(0f, 0f, 0f, 0.75f));
    shadowMaterial.SetVector("_UnderlayOffset", new Vector4(1.5f, -1.5f, 0f, 0f));
    shadowMaterial.SetFloat("_UnderlaySoftness", 0f);
    shadowMaterial.SetFloat("_UnderlayDilate", 0f);
    target.fontSharedMaterial = shadowMaterial;
}

private static TextMeshProUGUI CreateTMPSibling(Text source)
{
if (source == null)
{
return null;
}

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

private static void CopyRectTransform(RectTransform source, RectTransform destination)
{
if (source == null || destination == null)
{
return;
}

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

private static void CopyTextProperties(Text source, TextMeshProUGUI target)
{
if (source == null || target == null)
{
return;
}

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

private static TextAlignmentOptions ConvertAlignment(TextAnchor anchor)
{
switch (anchor)
{
case TextAnchor.UpperLeft:
return TextAlignmentOptions.TopLeft;
case TextAnchor.UpperCenter:
return TextAlignmentOptions.Top;
case TextAnchor.UpperRight:
return TextAlignmentOptions.TopRight;
case TextAnchor.MiddleLeft:
return TextAlignmentOptions.Left;
case TextAnchor.MiddleCenter:
return TextAlignmentOptions.Center;
case TextAnchor.MiddleRight:
return TextAlignmentOptions.Right;
case TextAnchor.LowerLeft:
return TextAlignmentOptions.BottomLeft;
case TextAnchor.LowerCenter:
return TextAlignmentOptions.Bottom;
case TextAnchor.LowerRight:
return TextAlignmentOptions.BottomRight;
default:
return TextAlignmentOptions.TopLeft;
}
}

private static FontStyles ConvertFontStyle(FontStyle fontStyle)
{
switch (fontStyle)
{
case FontStyle.Bold:
return FontStyles.Bold;
case FontStyle.Italic:
return FontStyles.Italic;
case FontStyle.BoldAndItalic:
return FontStyles.Bold | FontStyles.Italic;
default:
return FontStyles.Normal;
}
}
}
}
