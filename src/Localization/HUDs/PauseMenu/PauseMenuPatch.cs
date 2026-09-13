using HarmonyLib;
using TMPro;
using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(PauseMenu))]
public static class PauseMenuPatch
{
    [HarmonyPatch(nameof(PauseMenu.OnEnable))] [HarmonyPostfix]
    public static void LocalizeSkipButton(PauseMenu __instance)
    {
        // Please check this localize only, the rest of the stuff are fallback to OnEnable() f
        __instance.gameObject.Localize<TMP_Text>(LanguageManager.CurrentLanguage.pauseMenu.pause_skip, path: ["Restart Checkpoint (1)", "Text"]);

        var mapInfo = MapInfoBase.Instance;
        if (mapInfo == null || !mapInfo.replaceCheckpointButtonWithSkip)
            return;

        if (__instance.nonStandardCheckpointButton)
            return;

        if (StockMapInfo.Instance != null && !SceneHelper.IsPlayingCustom)
        {
            __instance.checkpointText.Localize(LanguageManager.CurrentLanguage.pauseMenu.pause_skip);
        }
    }
}