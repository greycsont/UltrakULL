using TMPro;
using UnityEngine;
using static UltrakULL.SceneObjects;


namespace UltrakULL;

public static class UILayoutOverride
{
	public static void AdjustOptionTextPosition()
	{
        var canvas = GetInactiveRootObject("Canvas");
        var optionsMenu = FindDescendant(canvas, "OptionsMenu");
        var optionTitle = FindDescendant(optionsMenu, "Text")?.GetComponent<RectTransform>();

        if (!optionTitle)
            return;

        optionTitle.sizeDelta -= new Vector2(0f, 20f);
	}

    public static void AdjustTitlePositionInStatWindow()
    {
        
    }

    public static void RemoveTitleWrapInResultScreen()
    {
        var player = GetInactiveRootObject("Player");
        var title = FindComponent<TextMeshProUGUI>(
            player,
            "Main Camera", "HUD Camera", "HUD", "FinishCanvas", "Panel", "Title", "Text");

        if (!title)
            return;

        title.enableWordWrapping = false;
        title.overflowMode = TextOverflowModes.Overflow;
    }

}
