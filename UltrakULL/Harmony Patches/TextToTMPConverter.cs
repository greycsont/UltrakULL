using System;
using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL;

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

            // Skip conversion for UniverseLibCanvas texts (UnityExplorer UI)
            if (IsUniverseLibCanvas(source))
            {
                // Logging.Message($"Skipping conversion for UniverseLibCanvas text: {source.gameObject.name}");
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
            SyncEffects(source, tmp);

            if (Core.TMPFontReady)
            {
                // Determine original font from Text component
                string originalFontName = source.font?.name;
                bool isMuseumFont = (originalFontName == "GFS Garaldus") || (originalFontName?.Contains("Garaldus") == true) ||
                                    (originalFontName?.Contains("EBGaramond") == true) || (originalFontName?.Contains("Garamond") == true);

                // Build object path for logging
                string objectPath = source.gameObject.name;
                if (source.transform.parent != null)
                {
                    objectPath = source.transform.parent.name + "/" + objectPath;
                    if (source.transform.parent.parent != null)
                    {
                        objectPath = source.transform.parent.parent.name + "/" + objectPath;
                    }
                }

                bool isInterChild = IsIntermissionShadowChild(source);
                Logging.Message($"[TMPCONV] Convert: {objectPath}, origFont='{originalFontName}', scene='{GetCurrentSceneName()}', isInterChild={isInterChild}");

                TextMeshProFontSwap.SwapTMPFont(
                    ref tmp,
                    isConvertedFromText: true,
                    originalFontName: originalFontName
                );

                if (isInterChild)
                {
                    Logging.Message($"[TMPCONV]   -> is IntermissionShadowChild, adding Shadow component");
                    AddIntermissionShadow(tmp);
                }
            }

            source.canvasRenderer.SetAlpha(0f);
            SetTMPActiveState(source, source.isActiveAndEnabled);
            Logging.Message($"[TMPCONV] Done: {source.gameObject.name}");
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

        private static bool IsUniverseLibCanvas(Text source)
        {
            if (source == null)
            {
                return false;
            }

            // Список паттернов, характерных для UniverseLib/UnityExplorer
            string[] universeLibPatterns = new string[]
            {
        "UniverseLibCanvas",
        "unityexplorer",
        "com.sinai",
        "UniverseLib",
        "ExplorerCanvas",
        "InspectorCanvas",
        "MouseInspectDropdown",
        "Dropdown List",
        "Viewport",
        "Inspector",
        "PanelHolder"
            };

            // Проверить всю иерархию объекта
            Transform current = source.transform;
            while (current != null)
            {
                string name = current.gameObject.name;

                // Проверить все паттерны (без учета регистра)
                string nameLower = name.ToLowerInvariant();
                foreach (string pattern in universeLibPatterns)
                {
                    if (nameLower.Contains(pattern.ToLowerInvariant()))
                    {
                        // Logging.Message($"Skipping UniverseLib text: {GetFullPath(source.transform)} (matched pattern: {pattern})");
                        return true;
                    }
                }
                current = current.parent;
            }

            // Дополнительно проверить полный путь
            string fullPath = GetFullPath(source.transform);
            string fullPathLower = fullPath.ToLowerInvariant();
            foreach (string pattern in universeLibPatterns)
            {
                if (fullPathLower.Contains(pattern.ToLowerInvariant()))
                {
                    // Logging.Message($"Skipping UniverseLib text by path: {fullPath} (matched pattern: {pattern})");
                    return true;
                }
            }

            // Отладочное логирование: если путь содержит "com.sinai", но не был распознан
            if (fullPathLower.Contains("com.sinai"))
            {
                // Logging.Warn($"UniverseLib text NOT recognized despite 'com.sinai' in path: {fullPath}. Patterns checked: {string.Join(", ", universeLibPatterns)}");
            }

            return false;
        }

        private static string GetFullPath(Transform transform)
        {
            if (transform == null)
                return string.Empty;

            List<string> pathParts = new List<string>();
            Transform current = transform;
            while (current != null)
            {
                string name = current.gameObject.name;
                // Удаляем "(Clone)" из имени для лучшего сопоставления
                if (name.EndsWith("(Clone)"))
                    name = name.Substring(0, name.Length - 7).TrimEnd();
                pathParts.Add(name);
                current = current.parent;
            }
            pathParts.Reverse();
            return string.Join("/", pathParts);
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

        private static void SyncEffects(Text source, TextMeshProUGUI target)
        {
            if (source == null || target == null)
            {
                return;
            }

            Shadow sourceShadow = source.GetComponent<Shadow>();
            Shadow targetShadow = target.GetComponent<Shadow>();
            if (sourceShadow != null)
            {
                if (targetShadow == null || targetShadow.GetType() != typeof(Shadow))
                {
                    if (targetShadow != null)
                    {
                        UnityEngine.Object.Destroy(targetShadow);
                    }
                    targetShadow = target.gameObject.AddComponent<Shadow>();
                }

                CopyShadowSettings(sourceShadow, targetShadow);
            }
            else if (targetShadow != null && targetShadow.GetType() == typeof(Shadow))
            {
                UnityEngine.Object.Destroy(targetShadow);
            }

            Outline sourceOutline = source.GetComponent<Outline>();
            Outline targetOutline = target.GetComponent<Outline>();
            if (sourceOutline != null)
            {
                if (targetOutline == null)
                {
                    targetOutline = target.gameObject.AddComponent<Outline>();
                }

                CopyShadowSettings(sourceOutline, targetOutline);
            }
            else if (targetOutline != null)
            {
                UnityEngine.Object.Destroy(targetOutline);
            }
        }

        private static void CopyShadowSettings(Shadow source, Shadow target)
        {
            if (source == null || target == null)
            {
                return;
            }

            target.effectColor = source.effectColor;
            target.effectDistance = source.effectDistance;
            target.useGraphicAlpha = source.useGraphicAlpha;
        }

        private static void AddIntermissionShadow(TextMeshProUGUI tmp)
        {
            if (tmp == null) return;
            Shadow shadow = tmp.GetComponent<Shadow>();
            if (shadow == null)
                shadow = tmp.gameObject.AddComponent<Shadow>();
            shadow.effectColor = new Color(0f, 0f, 0f, 0.75f);
            shadow.effectDistance = new Vector2(1.5f, -1.5f);
            shadow.useGraphicAlpha = true;
            Logging.Message($"[TMPCONV]   Shadow component added: color=({shadow.effectColor.r},{shadow.effectColor.g},{shadow.effectColor.b},{shadow.effectColor.a}), dist=({shadow.effectDistance.x},{shadow.effectDistance.y})");
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
