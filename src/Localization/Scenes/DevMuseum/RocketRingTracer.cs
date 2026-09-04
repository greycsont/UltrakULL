using System.Security.Cryptography;
using HarmonyLib;
using UltrakULL;
using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(RaceRingTracker))]
public static class RaceRingTrackerPatch
{
    [HarmonyPatch(nameof(RaceRingTracker.Victory))] [HarmonyPostfix]
    public static void LocalizeTime(RaceRingTracker __instance)
    {
        __instance.hm.message = ("{0}:" + __instance.hm.message.Split(':')[1]).FormatWith(LanguageManager.CurrentLanguage.misc.levelstats_time)
            .Or(__instance.hm.message);
    }
}