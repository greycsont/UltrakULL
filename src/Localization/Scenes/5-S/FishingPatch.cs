using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(FishingHUD))]
public class LocalizeFishingHUD
{
    [HarmonyPatch(nameof(FishingHUD.ShowHUD))] [HarmonyPostfix]
    public static void FishingHUDPatch_Postfix(ref GameObject ___outOfWaterMessage, ref GameObject ___hookedContainer)
    {
        if(!LanguageManager.IsEnglish)
        {
            Text outOfWaterText = GetTextfromGameObject(FindDescendant(___outOfWaterMessage,"Text"));
            outOfWaterText.text = LanguageManager.CurrentLanguage.fishing.fish_outOfWater;
        
            Text hookedText = GetTextfromGameObject(FindDescendant(___hookedContainer,"Text"));
            hookedText.text = LanguageManager.CurrentLanguage.fishing.fish_rodHooked;
        }
        
    }

    [HarmonyPatch(nameof(FishingHUD.ShowFishCaught))] [HarmonyPostfix]
    public static void ShowFish_Postfix(ref Text ___fishCaughtText,ref GameObject ___fishSizeContainer,bool show = true, FishObject fish = null)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }
        if(show && fish != null)
        {
            string fishName = fish.fishName;
            switch (fish.fishName)
            { 
                case "Funny Stupid Fish (Friend)":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFish;
                    break;
                }
                case "PITR Fish":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_pitrFish;
                    break;
                }
                case "Trout":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_trout;
                    break;
                }
                case "Metal Fish":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_amidEvilFish;
                    break;
                }
                case "Chomper":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_chomper;
                    break;
                }
                case "Bomb Fish":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_bombFish;
                    break;
                }
                case "Eyeball":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_gibeye;
                    break;
                }
                case "Frog (?)":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_ironLungFish;
                    break;
                }
                case "Dope Fish":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_dopeFish;
                    break;
                }
                case "Stickfish":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_stickFish;
                    break;
                }
                case "Cooked Fish":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_cookedFish;
                    break;
                }
                case "Shark":
                {
                    fishName = LanguageManager.CurrentLanguage.fishing.fish_shark;
                    break;
                }
            }
            ___fishCaughtText.text = "<size=56>" + LanguageManager.CurrentLanguage.fishing.fish_fishCaught + "</size> <color=orange><size=80>" + fishName + "</size></color>";
            ___fishCaughtText.resizeTextForBestFit = true;
            
            Text fishSizeText = GetTextfromGameObject(___fishSizeContainer);
            fishSizeText.text = LanguageManager.CurrentLanguage.fishing.fish_size;
            fishSizeText.resizeTextForBestFit = true;
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