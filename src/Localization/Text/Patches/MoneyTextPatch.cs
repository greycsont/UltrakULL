using HarmonyLib;
using UnityEngine;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(MoneyText))]
public static class MoneyTextPatch
{
    /// <summary>
    /// "LIKE, A LOT OF "
    /// </summary>
    /// <param name="dosh"></param>
    /// <param name="__result"></param>
    [HarmonyPatch(nameof(MoneyText.DivideMoney))] [HarmonyPostfix]
    public static void DivideMoneyPatch(int dosh, ref string __result)
    {
        if (dosh > 1000000000)
            __result = LanguageManager.CurrentLanguage.shop.shop_lotsOfMoney;
    }

    /// <summary>
    /// If you have any question of that single space
    /// Please check the source code of ULTRAKILL
    /// </summary>
    /// <param name="__instance"></param>
    [HarmonyPatch(nameof(MoneyText.UpdateMoney))] [HarmonyPostfix]
    public static void UpdateMoneyPostfix(MoneyText __instance)
    {
        __instance.text.text = 
            MoneyText.DivideMoney(GameProgressSaver.GetMoney()) 
            + " <color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_moneyCount + "</color>";
    }
}
