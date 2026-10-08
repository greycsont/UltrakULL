using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;
using TMPro;

namespace UltrakULL.Harmony_Patches;

//@Override
//Overrides the DisplayInfo method from the EnemyInfoPage class. This is to allow swapping out of monster bios in the shop.
[HarmonyPatch(typeof(EnemyInfoPage))]
public static class LocalizeEnemyInfo
{
    [HarmonyPatch(nameof(EnemyInfoPage.DisplayInfo), new Type[] { typeof(SpawnableObject) })] [HarmonyPostfix]
    public static void DisplayInfo_Postfix(SpawnableObject source, EnemyInfoPage __instance)
    {
        if (LanguageManager.IsEnglish)
        {
            return;
        }

        var enemyName = EnemyBios.GetShopName(source.objectName);

        Logging.Warn("Enemy Name in SHOP: " + enemyName);
        var enemyType = EnemyBios.GetType(source.type);
        var enemyDescription = EnemyBios.GetDescription(source.objectName);
        var enemyStrategy = EnemyBios.GetStrategy(source.objectName);
        
        __instance.enemyPageTitle.text = enemyName.Or(source.objectName);
        __instance.enemyEntryTitle.text = enemyName.Or(source.objectName);
        
        var enemyInfo = "</s><color=#FF4343>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_type.Or("TYPE:") + "</color> " 
                      + enemyType.Or(source.type) + "\n\n<color=#FF4343>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_data.Or("DATA:") + "</color>\n";

        __instance.enemyPageContent.text = 
            enemyInfo + (BestiaryData.Instance?.GetEnemy(source.enemyType) <= 1 ? "???" : enemyDescription.Or(source.description)) 
                      + "\n\n</s><color=#FF4343>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_strategy.Or("STRATEGY:") + "</color>\n" 
                      + enemyStrategy.Or(source.strategy);
    }
}
