using TMPro;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
	public static class TMPFontUtils
	{
		private static bool HasProperty(Material material, string propertyName)
		{
			return material != null && material.HasProperty(propertyName);
		}

		private static Material CreateMigratedMaterial(Material sourceMaterial, Material targetMaterial)
		{
			if (targetMaterial == null)
			{
				return sourceMaterial != null ? new Material(sourceMaterial) : null;
			}

			if (sourceMaterial == null)
			{
				return new Material(targetMaterial);
			}

			try
			{
				Material fallbackMaterial = TMP_MaterialManager.GetFallbackMaterial(sourceMaterial, targetMaterial);
				if (fallbackMaterial != null)
				{
					return new Material(fallbackMaterial);
				}
			}
			catch
			{
			}

			Material migratedMaterial = new Material(targetMaterial);

			try
			{
				TMP_MaterialManager.CopyMaterialPresetProperties(sourceMaterial, migratedMaterial);
			}
			catch
			{
				foreach (string propertyName in sourceMaterial.GetTexturePropertyNames())
				{
					if (HasProperty(migratedMaterial, propertyName))
					{
						migratedMaterial.SetTexture(propertyName, sourceMaterial.GetTexture(propertyName));
					}
				}
			}

			return migratedMaterial;
		}

		public static void ApplyUnderlayAndZTest(
			TextMeshProUGUI instance,
			Vector4 underlayColor,
			Vector4 underlayOffset,
			float underlaySoftness,
			float underlayDilate,
			bool preserveExistingUnderlay,
			bool isUnderlaid,
			bool isOverlay,
			bool editOverlayStatus,
			TMP_FontAsset fontAsset,
			Material overlayMat,
			Material normalMat)
		{
			if (instance == null || fontAsset == null)
			{
				Logging.Warn("ApplyUnderlayAndZTest: instance or fontAsset is null");
				return;
			}

			string instanceName = instance.gameObject.name;
			// Use fontMaterial (instance material) if available, otherwise fallback to fontSharedMaterial
			Material currentSharedMaterial = ((TMP_Text)instance).fontSharedMaterial;
			Material currentInstanceMaterial = ((TMP_Text)instance).fontMaterial;
			Material currentMaterial = currentInstanceMaterial ?? currentSharedMaterial;
			Material baseMaterial = editOverlayStatus ? (isOverlay ? overlayMat : normalMat) : (((TMP_Asset)fontAsset)?.material ?? normalMat);

			Logging.Message($"ApplyUnderlayAndZTest: Starting for {instanceName}");
			Logging.Message($"ApplyUnderlayAndZTest: currentSharedMaterial = {currentSharedMaterial?.name ?? "NULL"}, currentInstanceMaterial = {currentInstanceMaterial?.name ?? "NULL"}, using currentMaterial = {currentMaterial?.name ?? "NULL"}");
			Logging.Message($"ApplyUnderlayAndZTest: baseMaterial = {baseMaterial?.name ?? "NULL"}");
			Logging.Message($"ApplyUnderlayAndZTest: fontAsset = {fontAsset.name}, isUnderlaid = {isUnderlaid}, preserveExistingUnderlay = {preserveExistingUnderlay}");
			Logging.Message($"ApplyUnderlayAndZTest: underlayColor = ({underlayColor.x}, {underlayColor.y}, {underlayColor.z}, {underlayColor.w}), offset = ({underlayOffset.x}, {underlayOffset.y})");

			((TMP_Text)instance).font = fontAsset;

			if (baseMaterial == null && currentMaterial == null)
			{
				Logging.Warn("ApplyUnderlayAndZTest: Both baseMaterial and currentMaterial are null");
				return;
			}

			Material val = CreateMigratedMaterial(currentMaterial, baseMaterial);
			if (val == null)
			{
				Material materialToClone = baseMaterial ?? currentMaterial;
				if (materialToClone == null)
				{
					Logging.Warn("ApplyUnderlayAndZTest: materialToClone is null");
					return;
				}

				val = new Material(materialToClone);
				Logging.Message($"ApplyUnderlayAndZTest: Created new material from {materialToClone.name}");
			}
			else
			{
				Logging.Message($"ApplyUnderlayAndZTest: Using migrated material {val.name}");
			}

			// Log shader and properties
			if (val != null)
			{
				Logging.Message($"ApplyUnderlayAndZTest: Material {val.name} uses shader {val.shader?.name ?? "NULL"}");
				Logging.Message($"ApplyUnderlayAndZTest: HasProperty _UnderlayColor = {HasProperty(val, "_UnderlayColor")}");
				Logging.Message($"ApplyUnderlayAndZTest: HasProperty _UnderlayOffset = {HasProperty(val, "_UnderlayOffset")}");
				Logging.Message($"ApplyUnderlayAndZTest: HasProperty _UnderlaySoftness = {HasProperty(val, "_UnderlaySoftness")}");
				Logging.Message($"ApplyUnderlayAndZTest: HasProperty _UnderlayDilate = {HasProperty(val, "_UnderlayDilate")}");
			}

			bool shouldKeepUnderlay = preserveExistingUnderlay || isUnderlaid;
			Logging.Message($"ApplyUnderlayAndZTest: shouldKeepUnderlay = {shouldKeepUnderlay}");

			if (shouldKeepUnderlay)
			{
				Logging.Message($"ApplyUnderlayAndZTest: Applying underlay properties");
				if (HasProperty(val, "_UnderlayColor"))
				{
					Vector4 oldColor = val.GetVector("_UnderlayColor");
					val.SetVector("_UnderlayColor", underlayColor);
					Logging.Message($"ApplyUnderlayAndZTest: _UnderlayColor changed from ({oldColor.x}, {oldColor.y}, {oldColor.z}, {oldColor.w}) to ({underlayColor.x}, {underlayColor.y}, {underlayColor.z}, {underlayColor.w})");
				}
				else
				{
					Logging.Warn("ApplyUnderlayAndZTest: Material does not have _UnderlayColor property");
				}
				if (HasProperty(val, "_UnderlayOffset"))
				{
					Vector4 oldOffset = val.GetVector("_UnderlayOffset");
					val.SetVector("_UnderlayOffset", underlayOffset);
					Logging.Message($"ApplyUnderlayAndZTest: _UnderlayOffset changed from ({oldOffset.x}, {oldOffset.y}) to ({underlayOffset.x}, {underlayOffset.y})");
				}
				else
				{
					Logging.Warn("ApplyUnderlayAndZTest: Material does not have _UnderlayOffset property");
				}
				if (HasProperty(val, "_UnderlaySoftness"))
				{
					float oldSoftness = val.GetFloat("_UnderlaySoftness");
					val.SetFloat("_UnderlaySoftness", underlaySoftness);
					Logging.Message($"ApplyUnderlayAndZTest: _UnderlaySoftness changed from {oldSoftness} to {underlaySoftness}");
				}
				else
				{
					Logging.Warn("ApplyUnderlayAndZTest: Material does not have _UnderlaySoftness property");
				}
				if (HasProperty(val, "_UnderlayDilate"))
				{
					float oldDilate = val.GetFloat("_UnderlayDilate");
					val.SetFloat("_UnderlayDilate", underlayDilate);
					Logging.Message($"ApplyUnderlayAndZTest: _UnderlayDilate changed from {oldDilate} to {underlayDilate}");
				}
				else
				{
					Logging.Warn("ApplyUnderlayAndZTest: Material does not have _UnderlayDilate property");
				}
			}
			else
			{
				Logging.Message($"ApplyUnderlayAndZTest: Clearing underlay properties");
				if (HasProperty(val, "_UnderlayColor"))
				{
					val.SetVector("_UnderlayColor", new Vector4(0f, 0f, 0f, 0f));
				}
				if (HasProperty(val, "_UnderlayOffset"))
				{
					val.SetVector("_UnderlayOffset", Vector4.zero);
				}
				if (HasProperty(val, "_UnderlaySoftness"))
				{
					val.SetFloat("_UnderlaySoftness", 0f);
				}
				if (HasProperty(val, "_UnderlayDilate"))
				{
					val.SetFloat("_UnderlayDilate", 0f);
				}
			}
			if (editOverlayStatus)
			{
				if (HasProperty(val, "_ZTest"))
				{
					val.SetFloat("_ZTest", isOverlay ? 8f : 4f);
				}
			}
			// Set the material as instance material (fontMaterial) to ensure each text has its own copy
			((TMP_Text)instance).fontMaterial = val;
			// Verify that the material was set correctly
			Material afterSetShared = ((TMP_Text)instance).fontSharedMaterial;
			Material afterSetInstance = ((TMP_Text)instance).fontMaterial;
			Logging.Message($"ApplyUnderlayAndZTest: Completed for {instanceName}, material set to {val?.name ?? "NULL"}");
			Logging.Message($"ApplyUnderlayAndZTest: After set - fontSharedMaterial = {afterSetShared?.name ?? "NULL"}, fontMaterial = {afterSetInstance?.name ?? "NULL"}");
			Logging.Message($"ApplyUnderlayAndZTest: Materials are same reference: {object.ReferenceEquals(afterSetShared, afterSetInstance)}");
		}
	}
}
