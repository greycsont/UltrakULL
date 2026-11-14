using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL.Harmony_Patches;

//@Override
//Overrides ScanBook from the ScanningStuff class, for the "scanning" panel and book translations.
[HarmonyPatch(typeof(ScanningStuff))]
public static class LocalizeScanningText
{
    [HarmonyPatch(nameof(ScanningStuff.ScanBook))] [HarmonyPrefix]
    public static void ScanBook_MyPatch(ref string text, ScanningStuff __instance)
    {
        if(LanguageManager.IsEnglish)
        {
            return;
        }
        __instance.scanningPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.books.books_scanning, path: ["Text"]);
        text = Books.GetBookText(text).Or(text);

        //Close prompt when reading book
        var bookPanelBinds = FindComponent<TextBinds>(__instance.gameObject, "ReadingScanned", "Panel", "Text (1)");
        bookPanelBinds.text1 = LanguageManager.CurrentLanguage.books.books_pressToClose1 + " <color=orange>";
        bookPanelBinds.text2 = "</color> " + LanguageManager.CurrentLanguage.books.books_pressToClose2;
    }
}
