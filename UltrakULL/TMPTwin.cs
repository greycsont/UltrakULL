using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL;

// Legacy UI.Text can't use TMP fallback fonts, so for non-English text we mirror each Text into
// a TextMeshProUGUI "twin" (its font carries FontManager's fallback), hide the original, and let
// the twin render. The twin's lifecycle is bound to this component; attached by TextToTMPConverter.
[DisallowMultipleComponent]
public class TMPTwin : MonoBehaviour
{
    /// <summary>
    /// For the IntermissionChild and ShadowParent
    /// Please check 3-2 and 6-2's cutscene
    /// </summary>
    private enum TwinKind
    {
        Normal,
        Fishing,
        IntermissionChild,
        ShadowParent
    }

    private Text source;
    private TextMeshProUGUI twin;
    private TwinKind kind;
    private string lastText;
    private bool detached;
    private float originalAlpha;

    private void Awake()
    {
        source = GetComponent<Text>();
        if (source == null) { Destroy(this); return; }
        
        originalAlpha = source.canvasRenderer != null ? source.canvasRenderer.GetAlpha() : 1f;

        kind = Classify(source);

        if (kind == TwinKind.ShadowParent)
        {
            HideSource();
            return;
        }

        BuildTwin();
    }

    private void OnEnable()
    {
        if (detached) return;
        if (kind == TwinKind.ShadowParent)
        {
            HideSource();
            return;
        }
        if (twin == null) return;

        HideSource();
        if (!twin.gameObject.activeSelf)
            twin.gameObject.SetActive(true);
        MarkRebuild();
    }

    private void OnDisable()
    {
        if (detached || twin == null) return;
        if (twin.gameObject.activeSelf)
            twin.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (twin != null)
            Destroy(twin.gameObject);
    }

    // for some text like the magnet nailgun's ammo counter
    // it's buggy so we just detach the twin and let the original render instead
    public void Detach()
    {
        detached = true;
        if (twin != null)
            Destroy(twin.gameObject);
        twin = null;
        ShowSource();
    }

    private void LateUpdate()
    {
        if (detached || twin == null || source == null) return;
        if (source.text != lastText)
        {
            Sync();
            lastText = source.text;
        }
    }

    private void BuildTwin()
    {
        // Every twin is a stretch-filled child of its source, so it inherits the source's transform
        // (position/scale/rotation animations carry for free) and needs no rect copying.
        twin = TextMirror.CreateChild(source);
        if (twin == null) return;

        Sync();

        HideSource();
        twin.gameObject.SetActive(source.isActiveAndEnabled);
        lastText = source.text;
    }

    private void Sync()
    {
        if (kind == TwinKind.Fishing)
        {
            TextMirror.ApplyFishingTMP(source, twin);
        }
        else
        {
            TextMirror.CopyTextProperties(source, twin);
            twin.ForceMeshUpdate();
            MarkRebuild();
        }

        TextMirror.SyncEffects(source, twin);

        // Intermission's drop shadow (the game's separate shadow Text is our hidden ShadowParent).
        // Re-applied every sync because CopyTextProperties resets the material.
        if (kind == TwinKind.IntermissionChild)
            TextMirror.AddIntermissionShadow(twin);
    }

    private void HideSource()
    {
        if (source != null && source.canvasRenderer != null)
            source.canvasRenderer.SetAlpha(0f);
    }

    private void ShowSource()
    {
        if (source != null && source.canvasRenderer != null)
            source.canvasRenderer.SetAlpha(originalAlpha);
    }

    private void MarkRebuild()
    {
        if (twin != null && twin.rectTransform != null)
            LayoutRebuilder.MarkLayoutForRebuild(twin.rectTransform);
    }

    // --- Classification (These mf only run once at Awake()) -------------------------------

    private static TwinKind Classify(Text source)
    {
        if (IsIntermissionShadowParent(source)) return TwinKind.ShadowParent;
        if (IsIntermissionShadowChild(source)) return TwinKind.IntermissionChild;
        if (IsFishingResultText(source)) return TwinKind.Fishing;
        return TwinKind.Normal;
    }

    private static bool IsFishingResultText(Text source) =>
        source != null && (source.name == "Fish Caught Label" || source.name == "Fish Size Text");

    // iirc these mf is because the intermission text's shadow is a separate Text child
    private static bool IsIntermissionShadowParent(Text source) =>
        source != null && InIntermission() &&
        AncestorNamesMatch(source.transform, "Text", "Panel (1)", "Panel", "PowerUpVignette", "Canvas");

    private static bool IsIntermissionShadowChild(Text source) =>
        source != null && InIntermission() &&
        AncestorNamesMatch(source.transform, "Text (1)", "Text", "Panel (1)", "Panel", "PowerUpVignette", "Canvas");

    private static bool InIntermission()
    {
        string scene = GetCurrentSceneName();
        return scene == "Intermission1" || scene == "Intermission2";
    }

    // Walks up from t, matching each transform's name against names in order (names[0] is t itself).
    private static bool AncestorNamesMatch(Transform t, params string[] names)
    {
        foreach (string name in names)
        {
            if (t == null || t.name != name) return false;
            t = t.parent;
        }
        return true;
    }
}
