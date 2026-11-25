using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;


[HarmonyPatch(typeof(FishEncyclopedia))]
public class FishEncyclopediaPatch
{
    [HarmonyPatch(nameof(FishEncyclopedia.Start))] [HarmonyPostfix]
    public static void StartPostfix(FishEncyclopedia __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        __instance.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back,
            path: ["Canvas", "Background", "Main Window", "Fish Info", "Window", "Back Button", "Text"]);
    }

    [HarmonyPatch(nameof(FishEncyclopedia.SelectFish))] [HarmonyPostfix]
    public static void SelectFishPostfix(ref FishObject fish, FishEncyclopedia __instance)
    {
        if(LanguageManager.IsEnglish)
            return;

        var fishing = LanguageManager.CurrentLanguage.fishing;

        var (fishName, description) = fish.fishName switch
        {
            "Funny Stupid Fish (Friend)" => (fishing.fish_funnyStupidFish,
                fishing.fish_funnyStupidFishDescription1 + "\n\n" + fishing.fish_funnyStupidFishDescription2),
            "PITR Fish" => (fishing.fish_pitrFish,
                fishing.fish_pitrFishDescription1 + "\n\n" + fishing.fish_pitrFishDescription2),
            "Trout" => (fishing.fish_trout,
                fishing.fish_troutDescription1 + "\n\n" + fishing.fish_troutDescription2),
            "Metal Fish" => (fishing.fish_amidEvilFish,
                fishing.fish_amidEvilFishDescription1 + "\n\n" + fishing.fish_amidEvilFishDescription2),
            "Chomper" => (fishing.fish_chomper,
                fishing.fish_chomperDescription1 + "\n\n" + fishing.fish_chomperDescription2),
            "Bomb Fish" => (fishing.fish_bombFish,
                fishing.fish_bombFishDescription1 + "\n\n" + fishing.fish_bombFishDescription2),
            "Eyeball" => (fishing.fish_gibeye,
                fishing.fish_gibeyeDescription1 + "\n\n" + fishing.fish_gibeyeDescription2),
            "Frog (?)" => (fishing.fish_ironLungFish,
                fishing.fish_ironLungFishDescription1 + "\n\n" + fishing.fish_ironLungFishDescription2),
            "Dope Fish" => (fishing.fish_dopeFish,
                fishing.fish_dopeFishDescription1 + "\n\n" + fishing.fish_dopeFishDescription2),
            "Stickfish" => (fishing.fish_stickFish,
                fishing.fish_stickFishDescription1 + "\n\n" + fishing.fish_stickFishDescription2),
            "Cooked Fish" => (fishing.fish_cookedFish,
                fishing.fish_cookedFishDescription1 + "\n\n" + fishing.fish_cookedFishDescription2),
            "Shark" => (fishing.fish_shark,
                fishing.fish_sharkDescription1 + "\n\n" + fishing.fish_sharkDescription2),
            _ => (null, null),
        };

        __instance.fishName.Localize(fishName);
        __instance.fishDescription.Localize(description);
    }
}
