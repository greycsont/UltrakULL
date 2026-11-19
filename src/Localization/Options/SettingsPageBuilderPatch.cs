using HarmonyLib;
using System;
using UnityEngine;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;


[HarmonyPatch(typeof(SettingsMenu.Components.SettingsPageBuilder))]
public static class SettingsPageBuilderPatch
{
    [HarmonyPatch(nameof(SettingsMenu.Components.SettingsPageBuilder.BuildPage)), HarmonyPostfix]
    public static void BuildPagePostfix(SettingsMenu.Components.SettingsPageBuilder __instance) 
    {
        if (LanguageManager.IsEnglish)
            return;

        try
        {
            Logging.Debug($"Patching Page: {__instance.name}");
            var pageObj = __instance.gameObject;

            Action<GameObject> action = __instance.name.ToUpper() switch
            {
                "GENERAL" => Options.PatchGeneralOptions,
                "CONTROLS" => Options.PatchControlOptions,
                "GRAPHICS" => Options.PatchGraphicsOptions,
                "AUDIO" => Options.PatchAudioOptions,
                "ASSIST" => Options.PatchAssistOptions,
                "HUD" => Options.PatchHUDOptions,
                _ => null,
            };

            action?.Invoke(pageObj);

        }
        catch (Exception e)
        {
            Logging.Error("Something went wrong while patching options.");
            Logging.Error(e.ToString());
        }

    }
}
