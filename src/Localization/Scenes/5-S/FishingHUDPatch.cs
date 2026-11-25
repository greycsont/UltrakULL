using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(FishingHUD))]
public static class FishingHUDPatch
{
    [HarmonyPatch(nameof(FishingHUD.ShowHUD))] [HarmonyPostfix]
    public static void ShowHUDPostfix(FishingHUD __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        __instance.outOfWaterMessage.Localize<Text>(LanguageManager.CurrentLanguage.fishing.fish_outOfWater,
            path: ["Text"]);

        __instance.hookedContainer.Localize<Text>(LanguageManager.CurrentLanguage.fishing.fish_rodHooked,
            path: ["Text"]);
    }

    [HarmonyPatch(nameof(FishingHUD.ShowFishCaught))] [HarmonyPostfix]
    public static void ShowFishCaughtPostfix(ref bool show, ref FishObject fish, FishingHUD __instance)
    {
        if(LanguageManager.IsEnglish)
            return;

        if (show && fish != null)
        {
            var fishing = LanguageManager.CurrentLanguage.fishing;

            var fishName = fish.fishName switch
            {
                "Funny Stupid Fish (Friend)" => fishing.fish_funnyStupidFish,
                "PITR Fish" => fishing.fish_pitrFish,
                "Trout" => fishing.fish_trout,
                "Metal Fish" => fishing.fish_amidEvilFish,
                "Chomper" => fishing.fish_chomper,
                "Bomb Fish" => fishing.fish_bombFish,
                "Eyeball" => fishing.fish_gibeye,
                "Frog (?)" => fishing.fish_ironLungFish,
                "Dope Fish" => fishing.fish_dopeFish,
                "Stickfish" => fishing.fish_stickFish,
                "Cooked Fish" => fishing.fish_cookedFish,
                "Shark" => fishing.fish_shark,
                _ => fish.fishName,
            };

            __instance.fishCaughtText.Localize("<size=56>{0}</size> <color=orange><size=80>{1}</size></color>".FormatWith(fishing.fish_fishCaught, fishName))
                .resizeTextForBestFit = true;

            // Even though this should put in Start or whatever to indicate this does not change during gameplay
            //   but let us just keep this bs in here.
            __instance.fishSizeContainer.Localize<Text>(fishing.fish_size,
                path: [])
                .resizeTextForBestFit = true;
        }
    }
}