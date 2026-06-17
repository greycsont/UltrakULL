using HarmonyLib;
using System.Collections.Generic;
using System;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(HudController))]
public static class HudControllerPatch
{
    [HarmonyPatch("SetAlwaysOnTop"), HarmonyPrefix]
    public static bool SetAlwaysOnTop_Prefix(TMP_Text[] ___textElements)
    {
        if (___textElements == null)
        {
            return false;
        }
        TMP_Text[] array = ___textElements;
        for (int i = 0; i < array.Length; i++)
        {
            if(!array[i].font.name.Contains("VCR_OSD_MONO_EXTENDED") && array[i].font.name.Contains("VCR_OSD_MONO"))
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
