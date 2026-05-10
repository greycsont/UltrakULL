using TMPro;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
	public static class TMPFontUtils
	{
		public static void ApplyUnderlayAndZTest(TextMeshProUGUI instance, Vector4 underlayColor, bool isUnderlaid, bool isOverlay, bool editOverlayStatus, TMP_FontAsset fontAsset, Material overlayMat, Material normalMat)
		{
			// Защита от null
			if (instance == null || fontAsset == null)
				return;

			((TMP_Text)instance).font = fontAsset;
			
			// Определяем исходный материал для копирования
			Material sourceMaterial = null;
			if (!editOverlayStatus)
			{
				sourceMaterial = ((TMP_Text)instance).fontSharedMaterial;
			}
			else
			{
				sourceMaterial = isOverlay ? overlayMat : normalMat;
			}
			
			// Если sourceMaterial null, используем материал из fontAsset
			if (sourceMaterial == null)
				sourceMaterial = fontAsset.material;
			
			// Создаем новый материал на основе sourceMaterial
			Material val = new Material(sourceMaterial);
			
			if (isUnderlaid)
			{
				val.SetVector("_UnderlayColor", underlayColor);
			}
			else
			{
				val.SetVector("_UnderlayColor", new Vector4(0f, 0f, 0f, 0f));
			}
			if (editOverlayStatus)
			{
				val.SetFloat("_ZTest", isOverlay ? 8f : 4f);
			}
			((TMP_Text)instance).fontSharedMaterial = val;
		}
	}
}
