using System;
using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem;

using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(ControlsOptions))]
public class LocalizeControlSections
{
    [HarmonyPatch(nameof(ControlsOptions.Rebuild))] [HarmonyPostfix]
    public static void controlSectionsPatch_Postfix(ControlsOptions __instance)
    {
        foreach(GameObject section in __instance.rebindUIObjects)
        {
            if (section.name != "Control Section Template(Clone)") continue;

            var sectionText = GetTextMeshProUGUI(section);

            sectionText.Localize(sectionText.text switch
            {
                "-- MOVEMENT --"
                    => "-- " + LanguageManager.CurrentLanguage.options.controls_movement + " --",
                "-- WEAPON --"
                    => sectionText.text = "-- " + LanguageManager.CurrentLanguage.options.controls_weapons + " --",
                "-- FIST --"
                    => sectionText.text = "-- " + LanguageManager.CurrentLanguage.options.controls_fist + " --",
                "-- HUD --"
                    => sectionText.text = "-- " + LanguageManager.CurrentLanguage.options.category_hud + " --",
                _ 
                    => sectionText.text
            });
        }
    }
}


[HarmonyPatch(typeof(ControlsOptionsKey))]
public class ControlBindNames
{
    [HarmonyPatch(nameof(ControlsOptionsKey.OnEnable))] [HarmonyPostfix]
    public static void controlBindNamesPatch_Postfix(ControlsOptionsKey __instance)
    {
        __instance.actionText.Localize(getActionName(__instance.actionText.text));
    }

    public static string getActionName(string originalText)
    {
        switch (originalText)
        {
            case "MOVE": { return LanguageManager.CurrentLanguage.options.controls_move; }
            case "DODGE": { return LanguageManager.CurrentLanguage.options.controls_dodge; }
            case "SLIDE": { return LanguageManager.CurrentLanguage.options.controls_slide; }
            case "JUMP": { return LanguageManager.CurrentLanguage.options.controls_jump; }
            case "PRIMARY FIRE": { return LanguageManager.CurrentLanguage.options.controls_primaryFire; }
            case "SECONDARY FIRE": { return LanguageManager.CurrentLanguage.options.controls_secondaryFire; }
            case "NEXT VARIATION": { return LanguageManager.CurrentLanguage.options.controls_nextVariation; }
            case "PREVIOUS VARIATION": { return LanguageManager.CurrentLanguage.options.controls_previousVariation; }
            case "REVOLVER": { return LanguageManager.CurrentLanguage.options.controls_revolver; }
            case "SHOTGUN": { return LanguageManager.CurrentLanguage.options.controls_shotgun; }
            case "NAILGUN": { return LanguageManager.CurrentLanguage.options.controls_nailgun; }
            case "RAILCANNON": { return LanguageManager.CurrentLanguage.options.controls_railcannon; }
            case "ROCKET LAUNCHER": { return LanguageManager.CurrentLanguage.options.controls_rocketLauncher; }
            case "SPAWNER ARM": { return LanguageManager.CurrentLanguage.options.controls_spawnerArm; }
            case "NEXT WEAPON": { return LanguageManager.CurrentLanguage.options.controls_nextWeapon; }
            case "PREVIOUS WEAPON": { return LanguageManager.CurrentLanguage.options.controls_previousWeapon; }
            case "LAST USED WEAPON": { return LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon; }
            case "VARIATION SLOT 1": { return LanguageManager.CurrentLanguage.options.controls_variationSlot1; }
            case "VARIATION SLOT 2": { return LanguageManager.CurrentLanguage.options.controls_variationSlot2; }
            case "VARIATION SLOT 3": { return LanguageManager.CurrentLanguage.options.controls_variationSlot3; }
            case "PUNCH": { return LanguageManager.CurrentLanguage.options.controls_punch; }
            case "CHANGE FIST": { return LanguageManager.CurrentLanguage.options.controls_changeFist; }
            case "PUNCH (FEEDBACKER)": { return LanguageManager.CurrentLanguage.options.controls_punchFeedbacker; }
            case "PUNCH (KNUCKLEBLASTER)": { return LanguageManager.CurrentLanguage.options.controls_punchKnuckleblaster; }
            case "HOOK": { return LanguageManager.CurrentLanguage.options.controls_whiplash; }
            case "STATS": { return LanguageManager.CurrentLanguage.sandbox.sandbox_shop_stats; }
            default: return originalText;
        }
    }
}

[HarmonyPatch(typeof(ControlsOptionsKey), "GenerateTooltip")]
public static class BoundMultipleTimes
{
    [HarmonyPostfix]
    public static string GenerateTooltip_Postfix(string __result, InputAction action, InputBinding binding, InputBinding[] conflicts)
    {
        string str = action.GetBindingDisplayStringWithoutOverride(binding, InputBinding.DisplayStringOptions.DontIncludeInteractions).ToUpper();
        string str2 = "<color=red>" + str + " " + LanguageManager.CurrentLanguage.options.controls_boundMultiple + ":";
        HashSet<string> hashSet = new HashSet<string>();
        foreach (InputBinding inputBinding in conflicts)
        {
            if (!hashSet.Contains(inputBinding.action))
            {
                str2 += "<br>";
                string actiontranslated = ControlBindNames.getActionName(inputBinding.action.ToUpper());
                str2 = str2 + "- " + actiontranslated;
                hashSet.Add(inputBinding.action);
            }
        }
        return str2 + "</color>";

    }
}
