using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches;

// Attaches a TMPTwin to every non-English UnityEngine.UI.Text so it can render non-Latin
// glyphs through a TMP twin. This is the only hook: the twin's creation, syncing and
// teardown all live on the TMPTwin component itself (bound to the Text's own lifecycle).
public static class TextToTMPConverter
{
    [HarmonyPatch(typeof(Text), "OnEnable")]
    public static class TextOnEnablePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Text __instance)
        {
            if (__instance == null || isUsingEnglish()) return;
            if (IsUniverseLibCanvas(__instance)) return;   // don't touch UnityExplorer / UniverseLib debug UI
            if (__instance.GetComponent<TMPTwin>() == null)
                __instance.gameObject.AddComponent<TMPTwin>();
        }
    }

    // Lower-cased once; IsUniverseLibCanvas walks the whole transform chain on every Text.OnEnable.
    private static readonly string[] universeLibPatterns =
    {
        "universelibcanvas", "unityexplorer", "com.sinai", "universelib", "explorercanvas",
        "inspectorcanvas", "mouseinspectdropdown", "dropdown list", "viewport", "inspector", "panelholder"
    };

    private static bool IsUniverseLibCanvas(Text source)
    {
        if (source == null) return false;

        Transform current = source.transform;
        while (current != null)
        {
            string nameLower = current.gameObject.name.ToLowerInvariant();
            foreach (string pattern in universeLibPatterns)
                if (nameLower.Contains(pattern))
                    return true;
            current = current.parent;
        }
        return false;
    }
}
