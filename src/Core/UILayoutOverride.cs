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

        optionTitle.sizeDelta -= new Vector2(0f, 20f);
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

            if (adjustment.wordWrapping.HasValue)
                text.enableWordWrapping = adjustment.wordWrapping.Value;

            if (Enum.TryParse(adjustment.overflow, true, out TextOverflowModes overflow))
                text.overflowMode = overflow;

            if (adjustment.sizeDelta.HasValue)
                text.rectTransform.sizeDelta += adjustment.autoSizeByLineCount.HasValue && adjustment.autoSizeByLineCount.Value
                    ? new Vector2(adjustment.sizeDelta.Value.x, text.textInfo.lineCount * adjustment.sizeDelta.Value.y)
                    : adjustment.sizeDelta.Value;
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
}
