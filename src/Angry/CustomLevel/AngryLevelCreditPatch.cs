using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL;

[HarmonyPatch(typeof(LevelNamePopup))]
public static class AngryLevelCreditPatch
{
    [HarmonyPatch(nameof(LevelNamePopup.NameAppear))] [HarmonyPostfix]
    public static void NameAppear_CreditText()
    {
        if (LanguageManager.IsEnglish) return;
        if (!AngrySceneTracker.InAngryLevel) return;

        string credit = BuildCredit();
        if (credit != null)
            CreditText.Show(credit, seconds: 6f);
    }

    [HarmonyPatch(nameof(LevelNamePopup.NameReset))] [HarmonyPostfix]
    public static void NameReset_CreditText()
    {
        CreditText.Hide();
    }

    private static string BuildCredit()
    {
        var translation = AngryLevelText.Current();
        if (translation == null)
            return null;

        return string.Format(LanguageManager.Current.angry.angryBundles.creditFormat, 
            new []{AngryLevelText.BundleAuthor, AngryLevelText.LevelName, AngryLevelText.BundleName, translation.translator});
    }
}
