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

    [HarmonyPatch(nameof(FishEncyclopedia.SelectFish))] [HarmonyPrefix]
    public static bool SelectFish_Prefix(ref FishObject fish, FishEncyclopedia __instance)
    {
        if(LanguageManager.IsEnglish)
        {
            return true;
        }
        switch(fish.fishName)
        {
            case "Funny Stupid Fish (Friend)":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFishDescription1 + "\n\n"
                                    + LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFishDescription2;
                break;
            }
            case "PITR Fish":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_pitrFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_pitrFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_pitrFishDescription2;
                break;
            }
            case "Trout":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_trout;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_troutDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_troutDescription2;
                break;
            }
            case "Metal Fish":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_amidEvilFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_amidEvilFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_amidEvilFishDescription2;
                break;
            }
            case "Chomper":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_chomper;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_chomperDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_chomperDescription2;
                break;
            }
            case "Bomb Fish":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_bombFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_bombFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_bombFishDescription2;
                break;
            }
            case "Eyeball":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_gibeye;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_gibeyeDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_gibeyeDescription2;
                break;
            }
            case "Frog (?)":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_ironLungFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_ironLungFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_ironLungFishDescription2;
                break;
            }
            case "Dope Fish":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_dopeFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_dopeFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_dopeFishDescription2;
                break;
            }
            case "Stickfish":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_stickFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_stickFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_stickFishDescription2;
                break;
            }
            case "Cooked Fish":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_cookedFish;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_cookedFishDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_cookedFishDescription2;
                break;
            }
            case "Shark":
            {
                fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_shark;
                fish.description = LanguageManager.CurrentLanguage.fishing.fish_sharkDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.fishing.fish_sharkDescription2;
                break;
            }
        }
        return true;
    }
}