using TMPro;
using UnityEngine;
using UnityEngine.UI;


using static UltrakULL.SceneObjects;

namespace UltrakULL;

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
        FishingCaught,
        FishingSize,
        FishLocation,
        IntermissionChild,
        ShadowParent
    }

    private Text source;
    public TextMeshProUGUI twin;
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
        twin = TextMirror.CreateChild(source);
        if (twin == null) return;

        TextMirror.SetFont(source, twin);
        Sync();

        HideSource();
        twin.gameObject.SetActive(source.isActiveAndEnabled);
        lastText = source.text;
    }

    private void Sync()
    {
        TextMirror.CopyTextProperties(source, twin);
        twin.ForceMeshUpdate();
        MarkRebuild();

        if (kind == TwinKind.FishingCaught) 
            TextMirror.ApplyFishCaughtShadow(twin);

        if (kind == TwinKind.IntermissionChild)
            TextMirror.AddIntermissionShadow(twin);

        if (kind == TwinKind.FishingSize)
            TextMirror.Apply_Fish_Size_Outline(twin);

        if (kind == TwinKind.FishLocation)
            TextMirror.Apply_Fish_Location_Shadow(twin);
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
        if (!InSpecialScene()) return TwinKind.Normal;
        if (IsIntermissionShadowParent(source)) return TwinKind.ShadowParent;
        if (IsIntermissionShadowChild(source)) return TwinKind.IntermissionChild;
        if (IsFishingResultText(source)) return TwinKind.FishingCaught;
        if (IsFishingSizeText(source)) return TwinKind.FishingSize;
        if (IsFishingCircle(source)) return TwinKind.FishLocation;
        return TwinKind.Normal;
    }

    private static bool IsFishingResultText(Text source) =>
        source != null && (source.name == "Fish Caught Label");

    private static bool IsFishingSizeText(Text source) =>
        source != null && ( source.name == "Fish Size Text");

    private static bool IsFishingCircle(Text source) =>
        source != null &&
        AncestorNamesMatch(source.transform, "Text", "Canvas", "CanvasHolder", "Fish Target Circle(Clone)");

    // iirc these mf is because the intermission text's shadow is a separate Text child
    private static bool IsIntermissionShadowParent(Text source) =>
        source != null &&
        AncestorNamesMatch(source.transform, "Text", "Panel (1)", "Panel", "PowerUpVignette", "Canvas");

    private static bool IsIntermissionShadowChild(Text source) =>
        source != null &&
        AncestorNamesMatch(source.transform, "Text (1)", "Text", "Panel (1)", "Panel", "PowerUpVignette", "Canvas");

    private static bool InSpecialScene()
    {
        string scene = GetCurrentSceneName();
        return 
        scene == "Intermission1" 
        || scene == "Intermission2"
        || scene == "Level 5-S";
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
