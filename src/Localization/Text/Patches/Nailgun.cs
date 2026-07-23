using HarmonyLib;
using static UltrakULL.CommonFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using System.IO;
using System.Reflection;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(Nailgun))]
public static class NailgunPatch
{
    /// <summary>
    /// Update the Zap's RECHARING text
    /// The reason to not put it in the zap patch
    /// Since GetComponentInChildren() is a performance breaker
    /// </summary>
    /// <param name="__instance">Nailgun</param>
    [HarmonyPatch(nameof(Nailgun.Start))] [HarmonyPostfix]
    public static void StartPostfix(Nailgun __instance)
    {
        var rechargeText = __instance.rechargingOverlay?.GetComponentInChildren<TMP_Text>(true);

        if (rechargeText != null)
            rechargeText.text = LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperRecharging;
    }

    /// <summary>
    /// This one is for arabic-indic numbers
    /// </summary>
    /// <param name="__instance">Nailgun</param>
    [HarmonyPatch(nameof(Nailgun.Update))] [HarmonyPostfix]
    public static void UpdatePostfix(Nailgun __instance)
    {
        var nailgun = __instance;
        if(nailgun.variation == 1 && LanguageManager.CurrentLanguage.metadata.langHinduNumbers)
        {
            if (nailgun.altVersion) 
            {
                nailgun.ammoText.text = ArabicFixerTool.FixLine(Mathf.RoundToInt(nailgun.wc.naiSaws).ToString()).ToString();
            }
            else
            {
                __instance.ammoText.text = ArabicFixerTool.FixLine(Mathf.RoundToInt(nailgun.wc.naiAmmo).ToString()).ToString();
            }
        }
    }
    
    /// <summary>
    /// Modify the Zap's HUD text
    /// The Alt ver doesn't have the "DISTANCE:" in front of numbers
    /// Just take a salt of that
    /// </summary>
    /// <param name="__instance">Nailgun</param>
    [HarmonyPatch(nameof(Nailgun.UpdateZapHud))] [HarmonyPostfix]
    public static void Za(Nailgun __instance)
    {
        var nailgun = __instance;
        var language = LanguageManager.Current.Json.weapon;

        var hudText = nailgun.statusText.text;

        nailgun.statusText.text = hudText switch
        {
            "READY"        => language.weapon_nailgunZapperReady,
            "TOO FAR"      => language.weapon_nailgunZapperAlternateTooFar,
            "OUT OF RANGE" => language.weapon_nailgunZapperOutOfRange,
            "NULL"         => language.weapon_nailgunZapperAlternateNull,
            "NO TARGET"    => language.weapon_nailgunZapperNoTarget,
            "BLOCKED"      => language.weapon_nailgunZapperBlocked,
            _ when hudText.StartsWith("DISTANCE: ", StringComparison.Ordinal)
                => language.weapon_nailgunZapperDistance + hudText.Substring("DISTANCE: ".Length),
            _ => hudText,
        };
    }
}
