using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(FishingHUD))]
public class FishingHUDPatch
{
    [HarmonyPatch(nameof(FishingHUD.ShowHUD))] [HarmonyPostfix]
    public static void FishingHUDPatch_Postfix(FishingHUD __instance)
    {
        if (LanguageManager.IsEnglish)
            return;

        __instance.outOfWaterMessage.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.fishing.fish_outOfWater,
            path: ["Text"]);

        __instance.hookedContainer.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.fishing.fish_rodHooked,
            path: ["Text"]);
    }

    [HarmonyPatch(nameof(FishingHUD.ShowFishCaught))] [HarmonyPostfix]
    public static void ShowFish_Postfix(ref bool show, ref FishObject fish, FishingHUD __instance)
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

[HarmonyPatch(typeof(FishingRodWeapon),"Update")]
public class DisplayWaterType
{
    [HarmonyPostfix]
    public static void DisplayWaterType_Postfix(ref FishingRodWeapon __instance, ref FishingRodTarget ___targetingCircle, ref FishDB ___currentFishPool, float ___selectedPower)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }
        if(___currentFishPool != null)
        {
            switch(___currentFishPool.fullName)
            {
                case "The Ocean": {___targetingCircle.waterNameText.text = LanguageManager.CurrentLanguage.fishing.fish_ocean; break;}
                case "Cave Pool": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_cavePool; break;}
                case "Stream": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_stream; break;}
                case "Lake Waters": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_lake; break;}
                case "Lower Bloods": {___targetingCircle.waterNameText.text = LanguageManager.CurrentLanguage.fishing.fish_lakeBloodLower; break;}
                case "Lake of Blood": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_lakeBlood; break;}
                case "Water Well": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_waterWell; break;}
                case "Pan Oil": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_panOil; break;}
                case "Holy Lake": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_lakeHoly; break;}
                case "Deeper Lake Waters": {___targetingCircle.waterNameText.text  = LanguageManager.CurrentLanguage.fishing.fish_lakeDeep; break;}
            }
        }
        
    }

}

/*[HarmonyPatch(typeof(FishDB),"SetupWater")]
public class DisplayWaterType
{
    [HarmonyPostfix]
    public static void DisplayWaterType_Postfix(ref FishDB __instance)
    {
        if(!LanguageManager.IsEnglish)
        {
            return;
        }
        switch(__instance.fullName)
        {
            case "The Ocean": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_ocean; break;}
            case "Cave Pool": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_cavePool; break;}
            case "Stream": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_stream; break;}
            case "Lake Waters": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lake; break;}
            case "Lower Bloods": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeBloodLower; break;}
            case "Lake of Blood": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeBlood; break;}
            case "Water Well": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_waterWell; break;}
            case "Pan Oil": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_panOil; break;}
            case "Holy Lake": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeHoly; break;}
            case "Deeper Lake Waters": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeDeep; break;}
        }
    }
}*/