using HarmonyLib;

using UltrakULL.json;

namespace UltrakULL;


[HarmonyPatch(typeof(FishingRodWeapon))]
public static class FishingRodWeaponPatch
{
    [HarmonyPatch(nameof(FishingRodWeapon.Update))] [HarmonyPostfix]
    public static void UpdatePostfix(FishingRodWeapon __instance)
    {
        if(LanguageManager.IsEnglish)
            return;

        if(__instance.currentFishPool != null)
        {
            var fishing = LanguageManager.CurrentLanguage.fishing;

            var waterName = __instance.currentFishPool.fullName switch
            {
                "The Ocean" => fishing.fish_ocean,
                "Cave Pool" => fishing.fish_cavePool,
                "Stream" => fishing.fish_stream,
                "Lake Waters" => fishing.fish_lake,
                "Lower Bloods" => fishing.fish_lakeBloodLower,
                "Lake of Blood" => fishing.fish_lakeBlood,
                "Water Well" => fishing.fish_waterWell,
                "Pan Oil" => fishing.fish_panOil,
                "Holy Lake" => fishing.fish_lakeHoly,
                "Deeper Lake Waters" => fishing.fish_lakeDeep,
                _ => null,
            };

            __instance.targetingCircle.waterNameText.Localize(waterName);
        }
        
    }

}