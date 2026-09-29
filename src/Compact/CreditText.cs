using TMPro;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL;

public static class CreditText
{
    private const float MARGIN = 24f;
    private const float HEIGHT = 40f;

    private static TextMeshProUGUI label;
    private static FadeEffect fadeEffect;

    private static TextMeshProUGUI Label
    {
        get
        {
            if (label == null)
                Build();

            return label;
        }
    }

    public static void Show(string text, float seconds = 4f, float fadeSeconds = 0.6f)
    {
        if (string.IsNullOrEmpty(text))
            return;

        var target = Label;
        if (target == null)
            return;

        target.text = text;
        target.font = LanguageManager.Current.MainFontAsset;
        fadeEffect.Play(seconds, fadeSeconds);
    }

    public static void Hide()
    {
        if (fadeEffect != null)
            fadeEffect.HideNow();
    }

    private static void Build()
    {
        var canvas = SceneObjects.FindCanvas();
        if (canvas == null)
            return;

        var textGo = new GameObject("UltrakULL_CreditText");

        label = textGo.AddComponent<TextMeshProUGUI>();
        fadeEffect = textGo.AddComponent<FadeEffect>();

        var rect = (RectTransform)textGo.transform;
        rect.SetParent(canvas.transform, false);
        rect.anchorMin = new Vector2(0f, 0f);
        rect.anchorMax = new Vector2(1f, 0f);
        rect.pivot = new Vector2(1f, 0f);
        rect.offsetMin = new Vector2(MARGIN, MARGIN);
        rect.offsetMax = new Vector2(-MARGIN, MARGIN + HEIGHT);

        label.alignment = TextAlignmentOptions.BottomRight;
        label.fontSize = 20f;
        label.raycastTarget = false;
        label.alpha = 0f;

        fadeEffect.Init(label);
    }

    private class FadeEffect : MonoBehaviour
    {
        private TMP_Text target;
        private float alpha;
        private float targetAlpha;
        private float speed;
        private float hideAt = -1f;

        public void Init(TMP_Text owner)
        {
            target = owner;
            enabled = false;
        }

        public void Play(float seconds, float fadeSeconds)
        {
            speed = 1f / fadeSeconds;
            targetAlpha = 1f;
            hideAt = seconds > 0f ? Time.unscaledTime + seconds : -1f;
            enabled = true;
        }

        public void HideNow()
        {
            targetAlpha = 0f;
            hideAt = -1f;
            enabled = true;
        }

        private void Update()
        {
            if (OptionsManager.Instance.paused) return;

            if (hideAt > 0f && Time.unscaledTime >= hideAt)
            {
                targetAlpha = 0f;
                hideAt = -1f;
            }

            alpha = Mathf.MoveTowards(alpha, targetAlpha, speed * Time.unscaledDeltaTime);

            if (target != null)
                target.alpha = alpha;

            if (hideAt < 0f && Mathf.Approximately(alpha, 0f))
                enabled = false;
        }
    }
}
