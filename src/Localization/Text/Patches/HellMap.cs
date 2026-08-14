using HarmonyLib;
using UltrakULL.json;
using UnityEngine;


using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

	[HarmonyPatch(typeof(HellMap), "Start")]
	public static class HellMap_AwakePatch
	{
		private static void RtlFixLevel(GameObject root, string levelName)
		{
			char cAct = levelName[0];
			int iAct = 0;
			switch (cAct)
			{
				case '1':
				case '2':
				case '3':
					iAct = 1;
					break;
				case '4':
				case '5':
				case '6':
					iAct = 2;
					break;
				case '7':
				case '8':
				case '9':
					iAct = 3;
					break;
				default:
					iAct = 4;
					break;
			}

			GameObject actHellMap = FindDescendant(root, $"Hellmap Act {iAct}");
			if (actHellMap == null)
			{
				Logging.Message($"Hellmap RtlFixLevel is FUCKED!!");
				return;
			}

			GameObject levelObject = FindDescendant(actHellMap, levelName);
			if (levelObject == null)
			{
				Logging.Message($"Hellmap RtlFixLevel is FUCKED!!");
				return;
			}

			RectTransform rectTransform = levelObject.GetComponent<RectTransform>();
			if (rectTransform == null)
			{
				return;
			}

			rectTransform.anchorMax = new Vector2(0.50f, 1.00f);

		}

		[HarmonyPrefix]
		public static void Prefix(HellMap __instance)
		{
			bool isRTL = LanguageManager.IsRightToLeft;

			if (isRTL)
			{
				GameObject root = __instance.gameObject;

				for (int layer = 0; layer < 9; layer++)
				{
					for (int mission = 0; mission < 4; mission++)
					{
						int l = layer + 1;
						int m = mission + 1;

						if (m % 3 == 0)
						{
							if (mission > 2)
							{
								break;
							}
						}

						RtlFixLevel(root, $"{l}-{m}");
					}
				}
			}
		}
	}
