using HarmonyLib;
using AngryLevelLoader.UserInterface;
using System.Linq;

using oll = AngryLevelLoader.UserInterface.OnlineLevelsList;
using AngryLevelLoader.Managers;
using UltrakULL;
using UltrakULL.json;


[HarmonyPatch(typeof(OnlineLevelsList))]
public static class OnlineLevelsListPatch
{
    [HarmonyPatch(nameof(OnlineLevelsList.Init))] [HarmonyPostfix]
    public static void LocalizeOnlineLevelListPanel()
    {
        OnlineLevelsListLocalizer.LocalizeOnlineLevelsList();
    }
}


public static class OnlineLevelsListLocalizer
{
    public static void LocalizeOnlineLevelsList()
    {
        oll.searchBar.onValueChange += (v) =>
        {
            if (oll.searchKeywords.Length > 0)
            {
                var angry = LanguageManager.Current.angry;
                string[] searchResult = {oll.onlineLevels.Values.Count(v => !v.hidden).ToString(), OnlineCatalogManager.Catalog.Levels.Count.ToString()};
                oll.searchInfo.text = string.Format(angry.onlineSearchInfo.Or("Showing {0} of {1} bundles"), searchResult);
            }
        };
    }
}