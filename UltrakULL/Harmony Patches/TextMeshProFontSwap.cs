using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UltrakULL;
using UnityEngine;
using BepInEx;

namespace UltrakULL.Harmony_Patches
{
	public class TextMeshProFontSwap
	{
		private static class TMPFontLogger
		{
			private static HashSet<string> loggedFonts = new HashSet<string>();
			private static readonly object lockObject = new object();
			private static string logFilePath = null;

			private static string GetLogFilePath()
			{
				if (logFilePath == null)
				{
					logFilePath = Path.Combine(Paths.ConfigPath, "ultrakull", "fonts_tmp.txt");
				}
				return logFilePath;
			}

			public static void LogFont(TMP_FontAsset font)
			{
				if (font == null)
					return;

				string fontName = font.name;
				if (string.IsNullOrEmpty(fontName))
					return;

				lock (lockObject)
				{
					if (loggedFonts.Contains(fontName))
						return;

					loggedFonts.Add(fontName);
					string path = GetLogFilePath();
					try
					{
						Directory.CreateDirectory(Path.GetDirectoryName(path));
						File.AppendAllText(path, $"{fontName}\n");
						UltrakULL.Logging.Debug($"Logged TMP font: {fontName}");
					}
					catch (Exception e)
					{
						UltrakULL.Logging.Error($"Failed to log TMP font {fontName}: {e.Message}");
					}
				}
			}
		}

		[HarmonyPatch(typeof(TextMeshProUGUI), "OnEnable")]
		public static class TextMeshProFontSwapper
		{
			private static List<IntPtr> objectsFixed = new List<IntPtr>();

			[HarmonyPostfix]
			public static void SwapFont(ref TextMeshProUGUI __instance, IntPtr ___m_CachedPtr)
			{
				if ((objectsFixed.Count <= 0 || !objectsFixed.Contains(___m_CachedPtr)) && Core.TMPFontReady && (!CommonFunctions.isUsingEnglish() || !(CommonFunctions.GetCurrentSceneName() != "Main Menu")))
				{
					SwapTMPFont(ref __instance);
					objectsFixed.Add(___m_CachedPtr);
				}
			}
		}

		[HarmonyPatch(typeof(HudController))]
		public static class HudControllerPatch
		{
			public static bool isOverlaid = MonoSingleton<PrefsManager>.Instance.GetBool("hudAlwaysOnTop", false);

			[HarmonyPatch("SetAlwaysOnTop")]
			[HarmonyPrefix]
			public static bool SetAlwaysOnTop_Prefix(ref TMP_Text[] ___textElements, bool onTop, Material ___overlayTextMaterial, Material ___normalTextMaterial)
			{
				if (CommonFunctions.isUsingEnglish())
				{
					return true;
				}
				isOverlaid = onTop;
				if (___textElements.Length != 0)
				{
					TMP_Text[] array = ___textElements;
					foreach (TMP_Text val in array)
					{
						if (((Component)val.transform.parent).GetComponent<HealthBar>() != null && ((Component)val).gameObject.name.Equals("HP Text"))
						{
							val.fontSharedMaterial = (isOverlaid ? ___overlayTextMaterial : ___normalTextMaterial);
							continue;
						}
						TextMeshProUGUI __instance = ((Component)val).GetComponent<TextMeshProUGUI>();
						SwapTMPFont(ref __instance, isOverlaid, editOverlayStatus: true);
					}
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(SubtitleController))]
		public static class SubtitleFontSwapper
		{
			[HarmonyPatch("DisplaySubtitle", new Type[]
			{
				typeof(string),
				typeof(AudioSource),
				typeof(bool)
			})]
			[HarmonyPrefix]
			public static bool SubtitlePostfix(SubtitleController __instance, string caption, AudioSource audioSource, bool ignoreSetting, Subtitle ___subtitleLine, Transform ___container, Subtitle ___previousSubtitle)
			{
				if (!__instance.SubtitlesEnabled && !ignoreSetting)
				{
					return false;
				}
				Subtitle val = UnityEngine.Object.Instantiate<Subtitle>(___subtitleLine, ___container, true);
				((Component)val).GetComponentInChildren<TMP_Text>().text = caption;
				TextMeshProUGUI __instance2 = ((Component)val).GetComponentInChildren<TextMeshProUGUI>();
				if (Core.TMPFontReady)
				{
					SwapTMPFont(ref __instance2);
				}
				if (audioSource != null)
				{
					val.distanceCheckObject = audioSource;
				}
				((Component)val).gameObject.SetActive(true);
				if (___previousSubtitle == null)
				{
					val.ContinueChain();
				}
				else
				{
					___previousSubtitle.nextInChain = val;
				}
				___previousSubtitle = val;
				return false;
			}
		}

        public static void SwapTMPFont(ref TextMeshProUGUI __instance, bool onTop = false, bool editOverlayStatus = false, bool isConvertedFromText = false, string originalFontName = null)
        {
            if (__instance == null)
                return;

            Transform parent = ((TMP_Text)__instance).transform.parent;
            Transform grandParent = parent != null ? parent.parent : null;
            __instance.text = __instance.text ?? string.Empty;

            if (__instance?.text.Contains("■") == true && __instance.text.Contains("|"))
                return;

            if (parent != null &&
                ((Component)parent).GetComponent<HealthBar>() != null &&
                ((Component)__instance).gameObject.name.Equals("HP Text"))
            {
                return;
            }

            __instance.text = __instance.text ?? string.Empty;

            // Log the original font before replacement
            TMPFontLogger.LogFont(__instance.font);

			string text = null;
			if (parent != null && grandParent != null)
			{
				text = ((Component)grandParent).gameObject.name + "/" + ((Component)parent).gameObject.name + "/" + ((Component)((TMP_Text)__instance).transform).gameObject.name;
			}
			string langName = LanguageManager.CurrentLanguage?.metadata?.langName ?? string.Empty;
			string text2 = langName.Length >= 2 ? langName.ToLower().Substring(0, 2) : langName.ToLower();
			bool isUnderlaid = ((Component)__instance).gameObject.name.Contains("NameText") || ((Component)__instance).gameObject.name.Contains("LayerText") || (parent != null && ((Component)parent).gameObject.name.Contains("Cheats Info")) || (text?.Equals("ReadingScanned/Panel/Text (1)") ?? false);
			bool isOverlay = onTop;
			Material currentMaterial = ((TMP_Text)__instance).fontSharedMaterial;
			Vector4 underlayColor = new Vector4(0f, 0f, 0f, 0f);
			Vector4 underlayOffset = Vector4.zero;
			float underlaySoftness = 0f;
			float underlayDilate = 0f;
			bool preserveExistingUnderlay = false;
			if (currentMaterial != null && currentMaterial.HasProperty("_UnderlayColor"))
			{
				underlayColor = currentMaterial.GetVector("_UnderlayColor");
				preserveExistingUnderlay = underlayColor.w > 0.001f;
			}
			if (currentMaterial != null && currentMaterial.HasProperty("_UnderlayOffset"))
			{
				underlayOffset = currentMaterial.GetVector("_UnderlayOffset");
				preserveExistingUnderlay = preserveExistingUnderlay ||
					Mathf.Abs(underlayOffset.x) > 0.001f ||
					Mathf.Abs(underlayOffset.y) > 0.001f;
			}
			if (currentMaterial != null && currentMaterial.HasProperty("_UnderlaySoftness"))
			{
				underlaySoftness = currentMaterial.GetFloat("_UnderlaySoftness");
			}
			if (currentMaterial != null && currentMaterial.HasProperty("_UnderlayDilate"))
			{
				underlayDilate = currentMaterial.GetFloat("_UnderlayDilate");
			}

			// Force preserve shadow if this object is marked as having intermission shadow
			if (TextToTMPConverter.IsShadowApplied(__instance.GetInstanceID()))
			{
				preserveExistingUnderlay = true;
				// Ensure shadow parameters are set to intermission values
				underlayColor = new Vector4(0f, 0f, 0f, 0.9f);
				underlayOffset = new Vector4(2f, -2f, 0f, 0f);
				underlaySoftness = 0f;
				underlayDilate = 0f;
				Logging.Message($"SwapTMPFont: Object {__instance.gameObject.name} has intermission shadow, preserving parameters");
			}

			// Determine which font to use
			TMP_FontAsset mainFont = Core.GlobalFontTMP;
			TMP_FontAsset museumFont = Core.MuseumFontTMP;
			TMP_FontAsset terminalFont = Core.TerminalFontTMP ?? Core.GlobalFontTMP;
			TMP_FontAsset secretTerminalFont = Core.SecretTerminalFontTMP ?? Core.GlobalFontTMP;
			Material overlayMat = Core.GlobalFontTMPOverlayMat;
			Material normalMat = mainFont != null ? ((TMP_Asset)mainFont).material : currentMaterial;

			// Determine materials for each font type
			Material museumOverlayMat = Core.GlobalFontTMPOverlayMat;
			Material museumNormalMat = museumFont != null ? ((TMP_Asset)museumFont).material : normalMat;

			Material terminalOverlayMat = Core.GlobalFontTMPOverlayMat;
			Material terminalNormalMat = terminalFont != null ? ((TMP_Asset)terminalFont).material : normalMat;

			Material secretTerminalOverlayMat = Core.GlobalFontTMPOverlayMat;
			Material secretTerminalNormalMat = secretTerminalFont != null ? ((TMP_Asset)secretTerminalFont).material : normalMat;

			if (mainFont == null)
				return;

			Material cjkNormalMat = Core.CJKFontTMP != null ? ((TMP_Asset)Core.CJKFontTMP).material : normalMat;
			Material jaNormalMat = Core.JaFontTMP != null ? ((TMP_Asset)Core.JaFontTMP).material : normalMat;
			Material hebrewNormalMat = Core.HebrewFontTMP != null ? ((TMP_Asset)Core.HebrewFontTMP).material : normalMat;

			// Special handling for Text converted to TMP
			if (isConvertedFromText && !string.IsNullOrEmpty(originalFontName))
			{
				Logging.Message($"Text converted to TMP: originalFontName='{originalFontName}', scene='{CommonFunctions.GetCurrentSceneName()}'");
				
				// If original font is museum font, use museum font (custom if available)
				// Museum font can be "GFS Garaldus", "EBGaramond", or any font containing "Garaldus" or "Garamond"
				if (originalFontName == "GFS Garaldus" || originalFontName.Contains("Garaldus") || originalFontName.Contains("EBGaramond") || originalFontName.Contains("Garamond"))
				{
					Logging.Message($"Detected museum font: originalFontName='{originalFontName}', museumFont={(museumFont != null ? museumFont.name : "NULL")}, custom={Core.MuseumFontTMP != Core.DefaultMuseumFontTMP}");
					if (museumFont != null)
					{
						Logging.Message($"Applying museum font: {museumFont.name} with materials (overlay={museumOverlayMat?.name}, normal={museumNormalMat?.name})");
						TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, museumFont, museumOverlayMat, museumNormalMat);
					}
					else
					{
						// Fallback to main font if museum font not available
						Logging.Message($"Museum font is null, falling back to main font: {mainFont?.name}");
						TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, mainFont, overlayMat, normalMat);
					}
					return;
				}
				// For other fonts (VCR OSD mono), use main font
				else
				{
					Logging.Message($"Original font is not museum font, using main font: {mainFont?.name}");
					TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, mainFont, overlayMat, normalMat);
					return;
				}
			}

			// Check original TMP font for tahoma or fs-tahoma-8px SDF (only for non-converted texts)
			if (!isConvertedFromText)
			{
				string currentFontName = __instance.font?.name;
				if (!string.IsNullOrEmpty(currentFontName))
				{
					string fontNameLower = currentFontName.ToLower();
					if (fontNameLower.Contains("tahoma") || fontNameLower.Contains("fs-tahoma-8px sdf"))
					{
						// Apply terminal font
						Logging.Message($"Detected Tahoma font: '{currentFontName}', applying terminal font: {terminalFont?.name}");
						TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, terminalFont, terminalOverlayMat, terminalNormalMat);
						return;
					}
					else if (fontNameLower.Contains("bittypix monospace ") && fontNameLower.Contains("bittypix"))
					{
						// Apply secret terminal font
						Logging.Message($"Detected Bittypix Monospace font: '{currentFontName}', applying secret terminal font: {secretTerminalFont?.name}");
						TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, secretTerminalFont, secretTerminalOverlayMat, secretTerminalNormalMat);
						return;
					}
				}
			}

			// Check if this is a terminal or secret terminal text
			bool isTerminal = ((Component)__instance).gameObject.name.ToLower().Contains("terminal") ||
							  (parent != null && ((Component)parent).gameObject.name.ToLower().Contains("terminal"));
			bool isSecretTerminal = ((Component)__instance).gameObject.name.ToLower().Contains("secret") ||
									(parent != null && ((Component)parent).gameObject.name.ToLower().Contains("secret"));

			// If terminal and custom terminal font exists, use it
			if (isTerminal && !isSecretTerminal && terminalFont != Core.GlobalFontTMP)
			{
				TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, terminalFont, terminalOverlayMat, terminalNormalMat);
				return;
			}

			// Original language-based logic
			switch (text2)
			{
			case "zh":
				TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, Core.CJKFontTMP ?? mainFont, Core.CJKFontTMPOverlayMat, cjkNormalMat);
				break;
			case "ja":
				TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, Core.JaFontTMP ?? mainFont, Core.jaFontTMPOverlayMat, jaNormalMat);
				break;
			case "ar":
			case "fa":
			case "ur":
			{
				TextAlignmentOptions alignment = ((TMP_Text)__instance).alignment;
				if ((int)alignment <= 513)
				{
					if ((int)alignment != 257)
					{
						if ((int)alignment == 513)
						{
							((TMP_Text)__instance).alignment = (TextAlignmentOptions)516;
						}
					}
					else
					{
						((TMP_Text)__instance).alignment = (TextAlignmentOptions)260;
					}
				}
				else if ((int)alignment != 1025)
				{
					if ((int)alignment == 2049)
					{
						((TMP_Text)__instance).alignment = (TextAlignmentOptions)2052;
					}
				}
				else
				{
					((TMP_Text)__instance).alignment = (TextAlignmentOptions)1028;
				}
				if (Core.ArabicFontTMP != null &&
					Core.GlobalFontTMP != null &&
					Core.GlobalFontTMP.fallbackFontAssetTable != null &&
					!Core.GlobalFontTMP.fallbackFontAssetTable.Contains(Core.ArabicFontTMP))
				{
					Core.GlobalFontTMP.fallbackFontAssetTable.Add(Core.ArabicFontTMP);
				}
				if (CommonFunctions.GetCurrentSceneName() == "CreditsMuseum2" && ((TMP_Text)__instance).font.name == "GFS Garaldus")
				{
					TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, museumFont, museumOverlayMat, museumNormalMat);
				}
				else
				{
					TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, mainFont, overlayMat, normalMat);
				}
				break;
			}
			case "jr":
			case "he":
			case "yi":
			case "la":
			case "ro":
				TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, Core.HebrewFontTMP ?? mainFont, Core.GlobalFontTMPOverlayMat, hebrewNormalMat);
				break;
			default:
				if (CommonFunctions.GetCurrentSceneName() == "CreditsMuseum2" && ((TMP_Text)__instance).font.name == "GFS Garaldus")
				{
					TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, museumFont, museumOverlayMat, museumNormalMat);
				}
				else
				{
					TMPFontUtils.ApplyUnderlayAndZTest(__instance, underlayColor, underlayOffset, underlaySoftness, underlayDilate, preserveExistingUnderlay, isUnderlaid, isOverlay, editOverlayStatus, mainFont, overlayMat, normalMat);
				}
				break;
			}
		}
	}
}
