using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UltrakULL.json;
using static UltrakULL.SceneObjects;


namespace UltrakULL;

public static class UILayoutOverride
{
    public static void Initialize()
    {
        //LanguageManager.OnLanguageChanged += _ => Apply(GetCurrentSceneName());
    }

    public static void AdjustOptionTextPosition()
	{
        var canvas = GetInactiveRootObject("Canvas");
        var optionsMenu = FindDescendant(canvas, "OptionsMenu");
        var optionTitle = FindDescendant(optionsMenu, "Text")?.GetComponent<RectTransform>();

        if (!optionTitle)
            return;

        optionTitle.localPosition = new Vector3(optionTitle.localPosition.x, 360f, optionTitle.localPosition.z);
	}

    public static void Apply(string sceneName)
    {
        var adjustments = LanguageManager.Current?.Layout?.adjustments;
        if (adjustments == null)
            return;

        foreach (var adjustment in adjustments)
        {
            if (!AppliesToScene(adjustment, sceneName))
                continue;

            var text = GetObject(adjustment.path)?.GetComponent<TMP_Text>();
            if (!text)
                continue;

            if (adjustment.localPosition.HasValue)
                text.rectTransform.localPosition += adjustment.localPosition.Value;
        }
    }

    private static bool AppliesToScene(UILayoutAdjustment adjustment, string sceneName)
    {
        if (adjustment == null || string.IsNullOrWhiteSpace(adjustment.path))
            return false;

        return !IsSceneListed(adjustment.exclude)
            && (adjustment.include == null || adjustment.include.Length == 0 || IsSceneListed(adjustment.include));

        bool IsSceneListed(string[] scenes) => scenes?.Contains(sceneName) == true;
    }

    public static void RemoveWordWrap(this TMP_Text text)
    {
        text.overflowMode = TextOverflowModes.Overflow;
        text.enableWordWrapping = false;
    }
}
