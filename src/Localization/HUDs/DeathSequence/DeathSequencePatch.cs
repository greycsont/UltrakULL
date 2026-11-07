using HarmonyLib;

using static UltrakULL.SceneObjects;

using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(DeathSequence))]
public static class DeathSequencePatch
{
    [HarmonyPatch(nameof(DeathSequence.OnEnable))] [HarmonyPostfix]
    public static void LocalizeBlackScreenAndSequence(DeathSequence __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        __instance.tabl.fullText = LanguageManager.CurrentLanguage.misc.DeathSequence.Or(__instance.tabl.fullText);

        var textOverride = FindComponent<TextOverride>(__instance.deathScreen, "YouDiedText"); 

        var deathScreenText = LanguageManager.CurrentLanguage.misc.youDied1 + "\n\n\n\n\n" + LanguageManager.CurrentLanguage.misc.youDied2;

        textOverride.m_DualShockText = deathScreenText;
        textOverride.m_GenericText = deathScreenText;
        textOverride.m_KeyboardText = deathScreenText;
    }
}
