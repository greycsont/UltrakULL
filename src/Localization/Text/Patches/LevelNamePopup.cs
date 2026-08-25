using System;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;


namespace UltrakULL.Harmony_Patches;

//@Override
//Overrides the NameAppear function from LevelNamePopup. Used for showing layer and level names at the start of a level.
[HarmonyPatch(typeof(LevelNamePopup))]
public static class LocalizeLevelPopup
{
    [HarmonyPatch(nameof(LevelNamePopup.NameAppear))] [HarmonyPrefix]
    public static void NameAppear_MyPatch(LevelNamePopup __instance)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }

        if (TitleManager.GetName(__instance.nameString) == null)
        {
            Logging.Warn("There's no translated level name here!");
            Logging.Warn("Layer Name is:" + __instance.layerString);
            Logging.Warn("Level Name is:" + __instance.nameString);
            return;
        }

        __instance.layerString = TitleManager.GetLayer(__instance.layerString);
        __instance.nameString = TitleManager.GetName(__instance.nameString);

        __instance.nameText.ApplyLayout(UILayoutKeys.LevelNamePopupText);
    }
}
