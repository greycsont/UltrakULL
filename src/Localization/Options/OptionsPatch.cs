using HarmonyLib;
using System;
using SettingsMenu.Components;
using UnityEngine;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;


[HarmonyPatch(typeof(SettingsMenu.Components.SettingsPageBuilder))]
public static class OptionsPatch
{
    [HarmonyPatch("BuildPage"), HarmonyPostfix]
    public static void OptionsSetSelectedPostfix(SettingsPageBuilder __instance) 
    {
        try
        {
            Logging.Debug("Patching Option menu...");
            GameObject optionsObject = __instance.gameObject;
            switch (__instance.name.ToUpper())
            {
                case "GENERAL":
                {
                    Logging.Debug("GENERAL");
                    Options.PatchGeneralOptions(optionsObject);
                    break;
                }
                case "CONTROLS":
                {
                    Logging.Debug("CONTROLS");
                    Options.PatchControlOptions(optionsObject);
                    break;
                }
                case "GRAPHICS":
                {
                    Logging.Debug("GRAPHICS");
                    Options.PatchGraphicsOptions(optionsObject);
                    break;
                }
                case "AUDIO":
                {
                    Logging.Debug("AUDIO");
                    Options.PatchAudioOptions(optionsObject);
                    break;
                }
                case "ASSIST":
                {
                    Logging.Debug("ASSIST");
                    Options.PatchAssistOptions(optionsObject);
                    break;
                }
                case "HUD":
                {
                    Logging.Debug("HUD");
                    Options.PatchHUDOptions(optionsObject);
                    break;
                }
                default:
                {
                    Logging.Warn("Unknown Option page name: " + __instance.name);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Logging.Error("Something went wrong while patching options.");
            Logging.Error(e.ToString());
        }

    }
}
