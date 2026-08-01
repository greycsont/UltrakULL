using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

// UI element creation helpers. Borrowed from ZedDev's UKUIHelper, with some things
public static class UIFactory
{
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

    public static GameObject CreateButton(string buttonText = "Text", string buttonName = "Button")
    {
        ColorBlock colors = new ColorBlock()
        {
            normalColor = new Color(0, 0, 0, 0.512f),
            highlightedColor = new Color(1, 1, 1, 0.502f),
            pressedColor = new Color(1, 0, 0, 1),
            selectedColor = new Color(0, 0, 0, 0.512f),
            disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
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
        button.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        button.GetComponent<Image>().type = Image.Type.Sliced;
        button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
        GameObject text = CreateText();
        button.GetComponent<Button>().colors = colors;

        text.name = "Text";
        text.GetComponent<RectTransform>().SetParent(button.GetComponent<RectTransform>());
        text.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        text.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
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
        text.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        text.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        text.AddComponent<Text>();
        text.GetComponent<Text>().text = "Text";
        text.GetComponent<Text>().fontSize = 32;
        text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        text.GetComponent<Text>().color = Color.black;
        return text;
    }
}
