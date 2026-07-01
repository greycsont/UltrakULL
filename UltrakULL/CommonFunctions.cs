using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltrakULL;

	public static class CommonFunctions
	{
		private static readonly Dictionary<string, string> LocalizedInputs = new Dictionary<string, string>()
		{
			{ "space", LanguageManager.CurrentLanguage.inputStrings.input_space },
			{ "enter", LanguageManager.CurrentLanguage.inputStrings.input_enter },
			{ "tab", LanguageManager.CurrentLanguage.inputStrings.input_tab },
			{ "escape", LanguageManager.CurrentLanguage.inputStrings.input_esc },
			{ "leftshift", LanguageManager.CurrentLanguage.inputStrings.input_leftShift },
			{ "rightshift", LanguageManager.CurrentLanguage.inputStrings.input_rightShift },
			{ "leftcontrol", LanguageManager.CurrentLanguage.inputStrings.input_leftControl },
			{ "leftctrl", LanguageManager.CurrentLanguage.inputStrings.input_leftCtrl },
			{ "rightcontrol", LanguageManager.CurrentLanguage.inputStrings.input_rightControl },
			{ "rightctrl", LanguageManager.CurrentLanguage.inputStrings.input_rightCtrl },
			{ "leftalt", LanguageManager.CurrentLanguage.inputStrings.input_leftAlt },
			{ "rightalt", LanguageManager.CurrentLanguage.inputStrings.input_rightAlt },
			{ "leftmeta", LanguageManager.CurrentLanguage.inputStrings.input_leftMeta },
			{ "rightmeta", LanguageManager.CurrentLanguage.inputStrings.input_rightMeta },
			{ "leftbracket", LanguageManager.CurrentLanguage.inputStrings.input_leftBracket },
			{ "rightbracket", LanguageManager.CurrentLanguage.inputStrings.input_rightBracket },
			{ "lmb", LanguageManager.CurrentLanguage.inputStrings.input_LMB },
			{ "rmb", LanguageManager.CurrentLanguage.inputStrings.input_RMB },
			{ "mmb", LanguageManager.CurrentLanguage.inputStrings.input_MMB },
			{ "uparrow", LanguageManager.CurrentLanguage.inputStrings.input_arrowUp },
			{ "downarrow", LanguageManager.CurrentLanguage.inputStrings.input_arrowDown },
			{ "leftarrow", LanguageManager.CurrentLanguage.inputStrings.input_arrowLeft },
			{ "rightarrow", LanguageManager.CurrentLanguage.inputStrings.input_arrowRight },
			{ "forward", LanguageManager.CurrentLanguage.inputStrings.input_forward },
			{ "back", LanguageManager.CurrentLanguage.inputStrings.input_back },
			{ "comma", LanguageManager.CurrentLanguage.inputStrings.input_comma },
			{ "capslock", LanguageManager.CurrentLanguage.inputStrings.input_capsLock },
			{ "slash", LanguageManager.CurrentLanguage.inputStrings.input_slash },
			{ "backslash", LanguageManager.CurrentLanguage.inputStrings.input_backslash },
			{ "backspace", LanguageManager.CurrentLanguage.inputStrings.input_backspace },
			{ "equals", LanguageManager.CurrentLanguage.inputStrings.input_equals },
			{ "minus", LanguageManager.CurrentLanguage.inputStrings.input_minus },
			{ "numlock", LanguageManager.CurrentLanguage.inputStrings.input_numLock },
			{ "delete", LanguageManager.CurrentLanguage.inputStrings.input_delete },
			{ "period", LanguageManager.CurrentLanguage.inputStrings.input_period },
			{ "semicolon", LanguageManager.CurrentLanguage.inputStrings.input_semicolon },
			{ "quote", LanguageManager.CurrentLanguage.inputStrings.input_quote },
			{ "insert", LanguageManager.CurrentLanguage.inputStrings.input_insert },
			{ "pageup", LanguageManager.CurrentLanguage.inputStrings.input_pageUp },
			{ "pagedown", LanguageManager.CurrentLanguage.inputStrings.input_pageDown },
			{ "start", LanguageManager.CurrentLanguage.inputStrings.input_start },
			{ "end", LanguageManager.CurrentLanguage.inputStrings.input_end },
			{ "scrolllock", LanguageManager.CurrentLanguage.inputStrings.input_scrollLock },
			{ "pause", LanguageManager.CurrentLanguage.inputStrings.input_pause },
			{ "nobinding", LanguageManager.CurrentLanguage.inputStrings.input_noBinding },
		};

		public static string GetLocalizedInput(string input)
		{
			if (string.IsNullOrEmpty(input))
				return input;

			if (input.Length == 1 && char.IsLetter(input[0]))
				return input;

			string key = input.Replace(" ", "").ToLowerInvariant();

			if (key == "numpadperiod")
				return LanguageManager.CurrentLanguage.inputStrings.input_numpadPeriod;
			if (key == "numpaddivide")
				return LanguageManager.CurrentLanguage.inputStrings.input_numpadDivide;
			if (key == "numpadmultiply")
				return LanguageManager.CurrentLanguage.inputStrings.input_numpadMultiply;
			if (key == "numpadminus")
				return LanguageManager.CurrentLanguage.inputStrings.input_numpadMinus;
			if (key == "numpadenter")
				return LanguageManager.CurrentLanguage.inputStrings.input_numpadEnter;
			if (key == "numpadplus")
				return LanguageManager.CurrentLanguage.inputStrings.input_numpadPlus;

			if (key.StartsWith("numpad"))
				return LanguageManager.CurrentLanguage.inputStrings.input_numpad + key.Substring(6);

			if (LocalizedInputs.TryGetValue(key, out string localized))
				return localized;

			return input;
		}

		public static bool isUsingEnglish()
		{
			return (LanguageManager.CurrentLanguage.metadata.langDisplayName == "English");
		}
		
		public static ColorBlock UkButtonColors = new ColorBlock()
		{
			normalColor = new Color(0, 0, 0, 0.512f),
			highlightedColor = new Color(1, 1, 1, 0.502f),
			pressedColor = new Color(1, 0, 0, 1),
			selectedColor = new Color(0, 0, 0, 0.512f),
			disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
			colorMultiplier = 1f,
			fadeDuration = 0.1f
		};
		
		public static string PreviousHudMessage;
		
		public static IEnumerator WaitforSeconds(float seconds)
		{
			yield return new WaitForSeconds(seconds);
		}

		public static void HandleError(Exception e, string missingID = "")
		{  
			Logging.Error(e.ToString());
		}

		private static readonly Dictionary<string, GameObject> rootObjectCache = new Dictionary<string, GameObject>();
		private static readonly Dictionary<(GameObject, string), GameObject> childCache = new Dictionary<(GameObject, string), GameObject>();

		public static void ClearObjectCaches(Scene scene, LoadSceneMode mode)
		{
			rootObjectCache.Clear();
			childCache.Clear();
		}

		public static GameObject GetInactiveRootObject(string objectName)
		{
			if (rootObjectCache.TryGetValue(objectName, out GameObject cached))
			{
				if (cached != null)
					return cached;
				rootObjectCache.Remove(objectName);
			}

			List<GameObject> rootList = new List<GameObject>();
			SceneManager.GetActiveScene().GetRootGameObjects(rootList);
			foreach (GameObject child in rootList)
			{
				if (child != null && child.name == objectName)
				{
					rootObjectCache[objectName] = child;
					return child;
				}
			}
			return null;
		}
		
		public static string GetCurrentSceneName()
		{
			return SceneHelper.CurrentScene;
		}
		
		//NOTE - below code was borrowed from ZedDev's UKUIHelper, but with some things modified/removed to prevent errors.
		
		public static GameObject CreateButton(string buttonText = "Text",string buttonName = "Button")
		{
		
			ColorBlock colors = new ColorBlock()
			{
				normalColor = new Color(0,0,0,0.512f),
				highlightedColor = new Color(1,1,1,0.502f),
				pressedColor = new Color(1,0,0,1),
				selectedColor = new Color(0,0,0,0.512f),
				disabledColor = new Color(0.7843f,0.7843f,0.7843f,0.502f),
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
		
		  GameObject button = new GameObject();
		  button.name = buttonName;
		  button.AddComponent<RectTransform>();
		  button.AddComponent<CanvasRenderer>();
		  button.AddComponent<Image>();
		  button.AddComponent<Button>();
		  button.GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 50f);
		  button.GetComponent<RectTransform>().anchorMax = new Vector2(1,1);
		  button.GetComponent<RectTransform>().anchorMin = new Vector2(0,0);
		  //button.GetComponent<RectTransform>().SetPivot(PivotPresets.MiddleCenter);
		  button.GetComponent<Image>().type = Image.Type.Sliced;
		  button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
		  GameObject text = CreateText();
		  button.GetComponent<Button>().colors = colors;

		  text.name = "Text";
		  text.GetComponent<RectTransform>().SetParent(button.GetComponent<RectTransform>());
		  text.GetComponent<RectTransform>().anchorMax = new Vector2(1,1);
		  text.GetComponent<RectTransform>().anchorMin = new Vector2(0,0);
		  text.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

		  text.GetComponent<Text>().text = buttonText;
		  text.GetComponent<Text>().fontSize = 32;
		  text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		  text.GetComponent<Text>().color = Color.white;
		  return button;
		}
		
		public static GameObject CreateText() //Obsolete
		{
			GameObject text = new GameObject();
			text.name = "Text";
			text.AddComponent<RectTransform>();
			text.AddComponent<CanvasRenderer>();
			text.GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 50f);
			text.GetComponent<RectTransform>().anchorMax = new Vector2(1,1);
			text.GetComponent<RectTransform>().anchorMin = new Vector2(0,0);
			//text.GetComponent<RectTransform>().SetPivot(PivotPresets.MiddleCenter);
			text.AddComponent<Text>();
			text.GetComponent<Text>().text = "Text";
			text.GetComponent<Text>().fontSize = 32;
			text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
			text.GetComponent<Text>().color = Color.black;
			return text;
		}

		public static void PatchResultsScreen(string name, string challenge)
		{
			string levelName = name;
			string levelChallenge = challenge;

			GameObject coreGame = GameObject.Find("Player");

			GameObject resultsPanel = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(coreGame, "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas"), "Panel"); 

			//Level title
			GameObject resultsTitle = GetGameObjectChild(resultsPanel, "Title");
			TextMeshProUGUI resultsTitleLevelName = GetTextMeshProUGUI(GetGameObjectChild(resultsTitle, "Text"));
			resultsTitleLevelName.text = levelName;

			//Disable the levelFinderComponent, so the level name doesn't get reverted when the results panel appears.
			LevelNameFinder finder = resultsTitleLevelName.GetComponent<LevelNameFinder>();
			if (finder != null)
			{
				finder.enabled = false;
			}

			//Time
			//For some bizzare reason, the timer is labelled as "ff". Hakita were you cutting corners? :D
			GameObject timeTitle = GetGameObjectChild(resultsPanel, "ff");
			TextMeshProUGUI timeTitleText = GetTextMeshProUGUI(GetGameObjectChild(timeTitle, "Text"));
			timeTitleText.text = LanguageManager.CurrentLanguage.misc.stats_time;

			//Kills
			GameObject killsTitle = GetGameObjectChild(resultsPanel, "Kills - Info");
			TextMeshProUGUI killsTitleText = GetTextMeshProUGUI(GetGameObjectChild(killsTitle, "Text"));
			killsTitleText.text = LanguageManager.CurrentLanguage.misc.stats_kills;

			//Style
			GameObject styleTitle = GetGameObjectChild(resultsPanel, "Style - Info");
			TextMeshProUGUI styleTitleText = GetTextMeshProUGUI(GetGameObjectChild(styleTitle, "Text"));
			styleTitleText.text = LanguageManager.CurrentLanguage.misc.stats_style;

			//Secrets
			GameObject secretsTitle = GetGameObjectChild(resultsPanel, "Secrets -  Title");
			TextMeshProUGUI secretsTitleText = GetTextMeshProUGUI(GetGameObjectChild(secretsTitle, "Text"));
			secretsTitleText.text = LanguageManager.CurrentLanguage.misc.stats_secrets;

			//Challenge title
			GameObject challengeTitle = GetGameObjectChild(resultsPanel, "Challenge - Title");
			TextMeshProUGUI challengeTitleText = GetTextMeshProUGUI(GetGameObjectChild(challengeTitle, "Text"));
			challengeTitleText.text = LanguageManager.CurrentLanguage.misc.stats_challenge;

			//Challenge description
			GameObject challengeDescription = GetGameObjectChild(resultsPanel, "Challenge");
			TextMeshProUGUI challengeDescriptionText = GetTextMeshProUGUI(GetGameObjectChild(challengeDescription, "ChallengeText"));
			challengeDescriptionText.text = levelChallenge;

			//Total points
			TextMeshProUGUI totalPointsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(resultsPanel, "Total Points"),"Text (1)"));
			totalPointsText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total + ":";
		}


		public static GameObject GetGameObjectChild(GameObject parentObject, string childToFind)
		{
			if (parentObject == null)
				return null;

			var key = (parentObject, childToFind);
			if (childCache.TryGetValue(key, out GameObject cached))
			{
				if (cached != null)
					return cached;
				childCache.Remove(key);
			}

			Transform transform = parentObject.transform.Find(childToFind);
			GameObject result = transform != null ? transform.gameObject : null;
			childCache[key] = result;
			return result;
		}
		public static Text GetTextfromGameObject(GameObject objectToUse)
		{
			return objectToUse == null ? null : objectToUse.GetComponent<Text>();
		}

		public static TextMeshProUGUI GetTextMeshProUGUI(GameObject objectToUse)
		{
			return objectToUse == null ? null : objectToUse.GetComponent<TextMeshProUGUI>();
		}
		
		public static IEnumerable<CodeInstruction> IL(params (OpCode, object)[] instructions)
		{
			return instructions.Select(i => new CodeInstruction(i.Item1, i.Item2)).ToList();
		}
		
		public static GameObject GetObject(string path)
		{
			string rootPath, restPath = null;

			if (!path.Contains('/'))
				rootPath = path;
			else
			{
				var pathParts = path.Split(new[] { '/' }, 2);
				rootPath = pathParts[0];
				restPath = pathParts[1];
			}

			var rootList = new List<GameObject>();
			GameObject rootPart = null;
			SceneManager.GetActiveScene().GetRootGameObjects(rootList);
			
			foreach (var child in rootList.Where(child => child.name == rootPath))
				rootPart = child;

			if (rootPart == null)
				return null;

			return restPath == null
				? rootPart
				: rootPart.transform.Find(restPath).gameObject;
		}
	}
