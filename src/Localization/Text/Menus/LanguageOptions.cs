using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UltrakULL.json;
using static UltrakULL.UIFactory;
using System.Linq;
using UnityEngine.EventSystems;

using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
public static class InjectLanguageButton
{
    public static TextMeshProUGUI languageButtonText;
    public static TextMeshProUGUI languagePageTitleText;
    
    private static List<GameObject> languageButtons = new List<GameObject>();
    
    private static GameObject langLocalPage;
    private static GameObject referenceButtonTemplate;

    private static void EnsureReferenceButtonTemplate()
    {
        if (referenceButtonTemplate != null)
            return;

        var optionsParent = FindDescendant(GetInactiveRootObject("Canvas"), "OptionsMenu").transform;
        var navigationRail = optionsParent.Find("Navigation Rail").gameObject;
        var buttonPrefab = FindDescendant(navigationRail, "Back");

        referenceButtonTemplate = GameObject.Instantiate(buttonPrefab);
        referenceButtonTemplate.name = "ReferenceButtonTemplate";
        referenceButtonTemplate.SetActive(false);
    }
    /// <summary>
    /// Refactored utility method for creating consistent TMP buttons based on a reference button.
    /// </summary>
    public static class ButtonUtils
    {
        private static readonly ColorBlock defaultColorBlock = new ColorBlock
        {
            normalColor = new Color(1f, 1f, 1f, 1f),
            highlightedColor = new Color(0.5094f, 0.5094f, 0.5094f, 1f),
            pressedColor = new Color(1f, 0f, 0f, 1f),
            selectedColor = new Color(0.5094f, 0.5094f, 0.5094f, 1f),
            disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
            colorMultiplier = 1f,
            fadeDuration = 0.1f
        };

        public static GameObject CreateTMPButton(
            Transform parent,
            string name,
            string labelText,
            Action onClick,
            Color? buttonColor = null,
            Vector2? size = null,
            bool richText = true,
            bool changeSize = true,
            bool addHighlightSupport = false)
        {
            EnsureReferenceButtonTemplate();
            GameObject buttonObj = GameObject.Instantiate(referenceButtonTemplate, parent);
            if (buttonObj.GetComponent<HudOpenEffect>() == null)
            {
                buttonObj.AddComponent<HudOpenEffect>();
            }
            buttonObj.name = name;

            // Reset position/rotation/scale
            RectTransform rect = buttonObj.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.localRotation = Quaternion.identity;
            rect.localScale = Vector3.one;

            if (buttonColor.HasValue)
            {
                Image img = buttonObj.GetComponent<Image>();
                if (img != null)
                    img.color = buttonColor.Value;
            }

            Button button = buttonObj.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            if (onClick != null)
                button.onClick.AddListener(() => onClick());

            button.interactable = true;
            button.transition = Selectable.Transition.ColorTint;
            button.colors = defaultColorBlock;
            button.navigation = new Navigation { mode = Navigation.Mode.None };

            TextMeshProUGUI text = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = labelText;
                text.richText = richText;
                text.alignment = TextAlignmentOptions.Center;

                if (changeSize)
                {
                    text.enableAutoSizing = true;
                    text.fontSizeMin = 10f;
                    text.fontSizeMax = 36f;
                }
            }

            if (changeSize && size.HasValue)
            {
                rect.sizeDelta = size.Value;
            }

            buttonObj.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            if (addHighlightSupport)
            {
                var buttonImage = buttonObj.GetComponent<Image>();
                var highlightParent = buttonObj.GetComponentInParent<ButtonHighlightParent>();
                if (highlightParent != null && buttonImage != null)
                {
                    // Add click reaction to this button
                    button.onClick.AddListener(() => highlightParent.ChangeButton(buttonImage));
                }
            }

            return buttonObj;
        }
    }



    public static void updateLanguageButtonText()
    {
        // I LOVE MINESWEEPER
        if (languageButtonText == null || languagePageTitleText == null)
            return;
        languageButtonText.text = LanguageManager.CurrentLanguage.options.language_languages;
        languagePageTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_languages + "--";
    }
    


    

    public static bool Prefix(OptionsMenuToManager __instance)
    {
        
        languageButtons.Clear();

        if (GetCurrentSceneName() == "Main Menu")
        {
            Logging.Message("In main menu");
        }

        Logging.Message("Adding language option to options menu...");

        Transform optionsParent = __instance.optionsMenu.transform;
        Transform navigationRail = optionsParent.Find("Navigation Rail");
        Transform pagesParent = optionsParent.Find("Pages");
        Transform generalPage = pagesParent.Find("General");
        Transform generalScrollRect = generalPage.Find("Scroll Rect");
        Transform generalContents = generalScrollRect.Find("Contents");
        RectTransform generalScrollRectTransform = generalScrollRect.GetComponent<RectTransform>();
        RectTransform generalContentsTransform = generalContents.GetComponent<RectTransform>();


        Logging.Message("Creating language settings page...");
        langLocalPage = new GameObject("Language Page", typeof(RectTransform), typeof(CanvasRenderer));
        langLocalPage.transform.SetParent(pagesParent, false);
        langLocalPage.SetActive(false);
        RectTransform pageRect = langLocalPage.GetComponent<RectTransform>();
        pageRect.sizeDelta = new Vector2(600, 800);

        // ScrollView
        GameObject scrollView = new GameObject("Scroll Rect", typeof(RectTransform), typeof(ScrollRect), typeof(Image), typeof(Mask));
        scrollView.transform.SetParent(langLocalPage.transform, false);
        RectTransform scrollRect = scrollView.GetComponent<RectTransform>();
        scrollRect.anchorMin = generalScrollRectTransform.anchorMin;
        scrollRect.anchorMax = generalScrollRectTransform.anchorMax;
        scrollRect.pivot = generalScrollRectTransform.pivot;
        scrollRect.anchoredPosition = generalScrollRectTransform.anchoredPosition;
        scrollRect.sizeDelta = generalScrollRectTransform.sizeDelta;
        scrollView.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        scrollView.GetComponent<Mask>().showMaskGraphic = false;

        // ScrollRect settings to limit side-to-side scrolling
        ScrollRect scrollRectComponent = scrollView.GetComponent<ScrollRect>();
        scrollRectComponent.horizontal = false; // Disable horizontal scrolling
        scrollRectComponent.vertical = true; // Enable vertical scrolling
        scrollRectComponent.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;

        // Adding a scrollbar
        Transform referencePage = pagesParent.transform.Find("General");
        Scrollbar referenceScrollbar = referencePage.GetComponentsInChildren<Scrollbar>().FirstOrDefault();
        GameObject scrollbar = GameObject.Instantiate(referenceScrollbar.gameObject, langLocalPage.transform);
        scrollbar.transform.SetParent(langLocalPage.transform, false);
        RectTransform scrollbarRect = scrollbar.GetComponent<RectTransform>();

        Scrollbar scrollbarComponent = scrollbar.GetComponent<Scrollbar>();
        scrollbarComponent.direction = Scrollbar.Direction.BottomToTop;
        scrollRectComponent.verticalScrollbar = scrollbarComponent;
        scrollRectComponent.scrollSensitivity = 20f;

        // Content Container
        GameObject content = new GameObject("Contents", typeof(RectTransform), typeof(VerticalLayoutGroup), typeof(ContentSizeFitter));
        content.transform.SetParent(scrollView.transform, false);
        RectTransform contentRect = content.GetComponent<RectTransform>();
        contentRect.anchorMin = generalContentsTransform.anchorMin;
        contentRect.anchorMax = generalContentsTransform.anchorMax;
        contentRect.pivot = generalContentsTransform.pivot;
        contentRect.anchoredPosition = generalContentsTransform.anchoredPosition;
        contentRect.sizeDelta = generalContentsTransform.sizeDelta;

        VerticalLayoutGroup vGroup = content.GetComponent<VerticalLayoutGroup>();
        vGroup.spacing = 10;
        vGroup.childAlignment = TextAnchor.UpperCenter;
        vGroup.childForceExpandWidth = true;
        vGroup.childForceExpandHeight = false;
        vGroup.childControlWidth = true;
        vGroup.childControlHeight = true;

        ContentSizeFitter fitter = content.GetComponent<ContentSizeFitter>();
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        scrollView.GetComponent<ScrollRect>().content = contentRect;

        GameObject titleObject = GameObject.Instantiate(optionsParent.Find("Text").gameObject, content.transform);
        titleObject.name = "Title";
        languagePageTitleText = titleObject.GetComponent<TextMeshProUGUI>();
        languagePageTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_languages + "--";
        languagePageTitleText.alignment = TextAlignmentOptions.Center;
        languagePageTitleText.fontSize = 24;

        RectTransform titleRect = languagePageTitleText.rectTransform;
        titleRect.anchorMin = new Vector2(0.5f, 1);
        titleRect.anchorMax = new Vector2(0.5f, 1);
        titleRect.pivot = new Vector2(0.5f, 1);
        titleRect.anchoredPosition = new Vector2(0, -50);
        titleRect.sizeDelta = new Vector2(400, 50);

        Logging.Message("Creating language menu button...");
        GameObject languageButton = ButtonUtils.CreateTMPButton(navigationRail, "Language", LanguageManager.CurrentLanguage.options.language_title, () => ShowLanguagePage(), changeSize: false);
        languageButtonText = GetTextMeshProUGUI(FindDescendant(languageButton, "Text"));
        RectTransform sourceRect = FindDescendant(navigationRail.gameObject, "General").GetComponent<RectTransform>();
        RectTransform targetRect = languageButton.GetComponent<RectTransform>();
        targetRect.sizeDelta = sourceRect.sizeDelta;
        //targetRect.anchorMin = sourceRect.anchorMin;
        //targetRect.anchorMax = sourceRect.anchorMax;
        //targetRect.pivot = sourceRect.pivot;


        languageButton.transform.SetSiblingIndex(7);
        Logging.Message("Adding language selection buttons...");
        foreach (string language in LanguageManager.allLanguages.Keys)
        {
            GameObject langButton = ButtonUtils.CreateTMPButton(content.transform, language, LanguageManager.allLanguages[language].DisplayName, delegate
            {
                SelectLanguage(language);
                foreach (Transform child in content.transform)
                {
                    // In the before, Clearwater trying to make UltrakULL as a mod similar to package manager
                    // But now We are just made is as a lib, i keep the LangBrower check for some1 will check document in future
                    if (child.name != "Title" && child.name != "LangBrowser" && child.name.Contains("-"))
                    {
                        TextMeshProUGUI tC = child.GetComponentInChildren<TextMeshProUGUI>();
                        if (tC != null && LanguageManager.allLanguages.ContainsKey(child.name))
                        {
                            tC.text = LanguageManager.allLanguages[child.name].DisplayName;
                            if (LanguageManager.CurrentLanguage.metadata.langName == child.name) { tC.text += "\n<size=22>(<color=green>Selected</color>)</size>"; }
                            else if (tC.text.Contains("<color=green>Selected</color>"))
                            {
                                tC.text = LanguageManager.allLanguages[child.name].DisplayName;
                            }
                        }
                    }
                }
            });

            TextMeshProUGUI textComponent = langButton.GetComponentInChildren<TextMeshProUGUI>();
            if (LanguageManager.CurrentLanguage.metadata.langName == language) { textComponent.text += "\n<size=22>(<color=green>Selected</color>)</size>"; }
        }

        Logging.Message("Creating Open Language Folder button...");

        GameObject openLangFolder = ButtonUtils.CreateTMPButton(content.transform, "openLangFolder", "<color=#03fc07>" + LanguageManager.CurrentLanguage.options.language_openLanguageFolder + "</color>", () => Application.OpenURL(Path.Combine(BepInEx.Paths.ConfigPath, "ultrakull")));

        void ShowLanguagePage()
        {
            Logging.Message("Opening Language Settings Page...");
            EventSystem.current.SetSelectedGameObject(null);
            foreach (Transform page in pagesParent)
            {
                if (page != null)
                {
                    page.gameObject.SetActive(false);
                }
            }
            if (langLocalPage != null)
            {
                langLocalPage.SetActive(true);
                foreach (Transform child in navigationRail)
                {
                    if (child.TryGetComponent(out Button b))
                    {
                        ColorBlock cb = b.colors;
                        b.colors = cb; // Force update colors (sometimes helps)
                    }
                }
                Transform navRail = FindDescendant(GetInactiveRootObject("Canvas"), "OptionsMenu").transform.Find("Navigation Rail");
                GameObject langBtn = FindDescendant(navRail.gameObject, "Language");
                EventSystem.current.SetSelectedGameObject(langBtn);
            }
        }

        void SelectLanguage(string language)
        {
            Logging.Message("Selected language: " + language);
            LanguageManager.TrySwitchLanguage(language);
        }

        Logging.Message("Setting up navigation buttons to hide language page...");
        foreach (Transform child in navigationRail)
        {
            if (child.name != "Language" && child.name != "Saves")
            {
                Button navButton = child.GetComponent<Button>();
                if (navButton != null)
                {
                    navButton.onClick.AddListener(() =>
                    {
                        if (langLocalPage.activeSelf)
                        {
                            Logging.Message("Hiding Language Page as another button was clicked: " + child.name);
                            langLocalPage.SetActive(false);
                        }
                    });
                }
            }
        }

        return true;
    }

}
