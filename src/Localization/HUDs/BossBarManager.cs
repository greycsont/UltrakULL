using System.Collections.Generic;
using HarmonyLib;
using UltrakULL.json;


namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(BossBarManager))]
public static class LocalizeBossBar
{
    // Patch for CreateBossBar
    [HarmonyPatch(nameof(BossBarManager.CreateBossBar))] [HarmonyPrefix]
    public static void CreateBossBar_Prefix(BossHealthBar bossBar)
    {
        LocalizeName(bossBar);
    }

    // Patch for UpdateBossBar
    [HarmonyPatch(nameof(BossBarManager.UpdateBossBar))] [HarmonyPrefix]
    public static void UpdateBossBar_Prefix(BossHealthBar bossBar)
    {
        LocalizeName(bossBar);
    }

    private static void LocalizeName(BossHealthBar bossBar)
    {
        bossBar.bossName = EnemyBios.GetName(bossBar.bossName).Or(bossBar.bossName);
    }
}
