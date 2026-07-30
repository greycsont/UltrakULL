using HarmonyLib;
using System.Collections;

namespace UltrakULL;


/// <summary>
/// so what we fucking do in here is basically
/// capture the named source textures before static batching
/// use them to locate their regions in the generated atlas
/// replace the region with language's own textures
/// </summary>
[HarmonyPatch(typeof(StaticSceneOptimizer))]
internal static class StaticSceneOptimizerPatch
{
    [HarmonyPatch(nameof(StaticSceneOptimizer.Start))] [HarmonyPrefix]
    private static void Prefix(StaticSceneOptimizer __instance)
    {
        StaticBatchAtlasSwapper.Capture(__instance);
    }

    [HarmonyPatch(nameof(StaticSceneOptimizer.Start))] [HarmonyPostfix]
    private static void Postfix(StaticSceneOptimizer __instance)
    {
        if (MainPatch.Instance != null)
            MainPatch.Instance.StartCoroutine(ApplyAfterOptimizer(__instance));
    }

    private static IEnumerator ApplyAfterOptimizer(StaticSceneOptimizer optimizer)
    {
        // SetupMeshes/SetupMaterial may publish their textures at the end of the frame.
        yield return null;
        yield return null;
        yield return StaticBatchAtlasSwapper.Resolve(optimizer);
    }
}
