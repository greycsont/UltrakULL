using System;
using System.Linq;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using GameSettingsMenu = SettingsMenu.Components.SettingsMenu;

namespace UltrakULL;

public static class LanguageOptions
{
    private const string PageName = "Language Page";

    private static TextMeshProUGUI navigationLabel;
    private static TextMeshProUGUI pageTitle;
    private static TextMeshProUGUI openFolderLabel;

    public static void Initialize(GameSettingsMenu settingsMenu)
    {
        Transform pages = settingsMenu.pageContainer;
        if (pages.Find(PageName) != null)
            return;

        Logging.Message("Adding language option to options menu...");

        Transform navigationRail = settingsMenu.navigationRail;
        GameObject buttonTemplate = navigationRail.Find("General").gameObject;
        GameObject languagePage = BuildLanguagePage(settingsMenu.transform, pages, buttonTemplate);
        GameObject navigationButton = BuildButton(
            buttonTemplate,
            navigationRail,
            "Language",
            LanguageManager.CurrentLanguage.options.language_title,
            resizeText: false);

        navigationButton.transform.SetSiblingIndex(7);
        navigationLabel = navigationButton.GetComponentInChildren<TextMeshProUGUI>();

        ConfigureNavigationButton(settingsMenu, languagePage, navigationButton);

        RefreshText();
    }

    public static void RefreshText()
    {
        var options = LanguageManager.CurrentLanguage.options;

        if (navigationLabel != null)
            navigationLabel.text = options.language_title;
        if (pageTitle != null)
            pageTitle.text = $"--{options.language_languages}--";
        if (openFolderLabel != null)
            openFolderLabel.text = $"<color=#03fc07>{options.language_openLanguageFolder}</color>";
    }

    private static GameObject BuildLanguagePage(Transform optionsMenu, Transform pages,
        GameObject buttonTemplate)
    {
        Transform generalPage = pages.Find("General");
        Transform referenceScroll = generalPage.Find("Scroll Rect");
        Transform referenceContents = referenceScroll.Find("Contents");

        GameObject page = new(PageName, typeof(RectTransform), typeof(CanvasRenderer));
        page.transform.SetParent(pages, false);
        page.GetComponent<RectTransform>().sizeDelta = new Vector2(600f, 800f);
        page.SetActive(false);

        GameObject scrollObject = new(
            "Scroll Rect",
            typeof(RectTransform),
            typeof(ScrollRect),
            typeof(Image),
            typeof(Mask));
        scrollObject.transform.SetParent(page.transform, false);
        CopyRect(referenceScroll.GetComponent<RectTransform>(), scrollObject.GetComponent<RectTransform>());
        scrollObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
        scrollObject.GetComponent<Mask>().showMaskGraphic = false;

        ScrollRect scroll = scrollObject.GetComponent<ScrollRect>();
        scroll.horizontal = false;
        scroll.vertical = true;
        scroll.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
        scroll.scrollSensitivity = 20f;

        GameObject contentObject = new(
            "Contents",
            typeof(RectTransform),
            typeof(VerticalLayoutGroup),
            typeof(ContentSizeFitter));
        contentObject.transform.SetParent(scrollObject.transform, false);
        RectTransform contentRect = contentObject.GetComponent<RectTransform>();
        CopyRect(referenceContents.GetComponent<RectTransform>(), contentRect);

        VerticalLayoutGroup layout = contentObject.GetComponent<VerticalLayoutGroup>();
        layout.spacing = 10f;
        layout.childAlignment = TextAnchor.UpperCenter;
        layout.childForceExpandWidth = true;
        layout.childForceExpandHeight = false;
        layout.childControlWidth = true;
        layout.childControlHeight = true;
        contentObject.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        scroll.content = contentRect;
        Transform content = contentObject.transform;

        Scrollbar scrollbar = UnityEngine.Object.Instantiate(
            generalPage.GetComponentsInChildren<Scrollbar>().First(),
            page.transform);
        scrollbar.direction = Scrollbar.Direction.BottomToTop;
        scroll.verticalScrollbar = scrollbar;

        GameObject titleObject = UnityEngine.Object.Instantiate(optionsMenu.Find("Text").gameObject, content);
        titleObject.name = "Title";
        pageTitle = titleObject.GetComponent<TextMeshProUGUI>();
        pageTitle.alignment = TextAlignmentOptions.Center;
        pageTitle.fontSize = 24f;
        pageTitle.rectTransform.sizeDelta = new Vector2(400f, 50f);

        foreach (var language in LanguageManager.allLanguages)
        {
            var languageId = language.Key;
            BuildButton(
                buttonTemplate,
                content,
                languageId,
                language.Value.DisplayName,
                () => SelectLanguage(languageId),
                size: new Vector2(160f, 40f));
        }

        openFolderLabel = BuildButton(
                buttonTemplate,
                content,
                "openLangFolder",
                string.Empty,
                () => Application.OpenURL(ConfigPaths.LanguagesDirectory))
            .GetComponentInChildren<TextMeshProUGUI>();

        return page;
    }

    private static GameObject BuildButton(GameObject template, Transform parent,
        string name, string label, UnityAction onClick = null, bool resizeText = true,
        Vector2? size = null)
    {
        GameObject instance = UnityEngine.Object.Instantiate(template, parent);
        instance.name = name;

        RectTransform rect = instance.GetComponent<RectTransform>();
        rect.localPosition = Vector3.zero;
        rect.localRotation = Quaternion.identity;
        rect.localScale = Vector3.one;
        if (size.HasValue)
            rect.sizeDelta = size.Value;

        Button button = instance.GetComponent<Button>();
        // The cloned template includes the original button's callbacks.
        button.onClick = new Button.ButtonClickedEvent();
        if (onClick != null)
            button.onClick.AddListener(onClick);
        button.interactable = true;
        button.navigation = new Navigation { mode = Navigation.Mode.None };

        TextMeshProUGUI text = instance.GetComponentInChildren<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = label;
            text.richText = true;
            text.alignment = TextAlignmentOptions.Center;
            text.enableAutoSizing = resizeText;
            if (resizeText)
            {
                text.fontSizeMin = 10f;
                text.fontSizeMax = 36f;
            }
        }

        instance.SetActive(true);
        return instance;
    }

    private static void SelectLanguage(string languageId)
    {
        Logging.Message($"Selected language: {languageId}");
        LanguageManager.TrySwitchLanguage(languageId);
    }

    private static void ConfigureNavigationButton(
        GameSettingsMenu settingsMenu,
        GameObject languagePage,
        GameObject navigationButton)
    {
        ButtonHighlightParent highlight = settingsMenu.navigationRail.GetComponent<ButtonHighlightParent>();
        Button button = navigationButton.GetComponent<Button>();
        Image image = navigationButton.GetComponent<Image>();

        button.onClick.AddListener(() =>
        {
            highlight?.ChangeButton(image);
            settingsMenu.SetActivePage(languagePage);
        });

        // If Start already ran, append the new button now. Otherwise Start will discover it itself.
        RegisterNavigationButton(highlight, image);
    }

    private static void RegisterNavigationButton(ButtonHighlightParent highlight, Image image)
    {
        if (highlight?.buttons == null || highlight.buttons.Contains(image))
            return;

        TMP_Text text = image.GetComponentInChildren<TMP_Text>();
        int index = highlight.buttons.Length;

        Array.Resize(ref highlight.buttons, index + 1);
        Array.Resize(ref highlight.buttonTexts, index + 1);
        Array.Resize(ref highlight.buttonSprites, index + 1);
        highlight.buttons[index] = image;
        highlight.buttonTexts[index] = text;
        highlight.buttonSprites[index] = image.sprite;
    }

    private static void CopyRect(RectTransform source, RectTransform target)
    {
        target.anchorMin = source.anchorMin;
        target.anchorMax = source.anchorMax;
        target.pivot = source.pivot;
        target.anchoredPosition = source.anchoredPosition;
        target.sizeDelta = source.sizeDelta;
    }
}
