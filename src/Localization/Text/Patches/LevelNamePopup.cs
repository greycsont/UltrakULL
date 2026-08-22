using System;
using HarmonyLib;
using UltrakULL.json;


namespace UltrakULL.Harmony_Patches;

//@Override
//Overrides the NameAppear function from LevelNamePopup. Used for showing layer and level names at the start of a level.
[HarmonyPatch(typeof(LevelNamePopup))]
public static class LocalizeLevelPopup
{
    [HarmonyPatch(nameof(LevelNamePopup.NameAppear))] [HarmonyPrefix]
    public static bool NameAppear_MyPatch(LevelNamePopup __instance, ref string ___layerString, ref string ___nameString)
    {
        if(LanguageManager.IsEnglish)
        {
            return true;
        }
        try
        {
            if (TitleManager.GetName(___nameString) == null)
            {
                Logging.Warn("There's no translated level name here!");
                Logging.Warn("Layer Name is:" + ___layerString);
                Logging.Warn("Level Name is:" + ___nameString);
                return true;
            }
            ___layerString = TitleManager.GetLayer(___layerString);
            ___nameString = TitleManager.GetName(___nameString);
        }
        catch (Exception e)
        {
            Logging.Warn("Failed to Patch Level Name Popup!");
            Logging.Warn(e.ToString());
        }
        return true;
    }
}
