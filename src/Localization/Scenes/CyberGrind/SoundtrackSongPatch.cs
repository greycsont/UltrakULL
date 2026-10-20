using HarmonyLib;

using static UltrakULL.json.LanguageManager;


namespace UltrakULL;

[HarmonyPatch(typeof(SoundtrackSong))]
public static class SoundtrackSongPatch
{
    [HarmonyPatch(nameof(SoundtrackSong.extraLevelBit), methodType: MethodType.Getter)] [HarmonyPostfix]
    public static void ExtraLevelInfoGetterPostfix(ref string __result)
    {
        var translatedName = __result switch
        {
            "(MAIN THEME)" => CurrentLanguage.cyberGrind.cybergrind_musicSuffixMainTheme,
            "(SHOP)" => CurrentLanguage.cyberGrind.cybergrind_musicSuffixShop,
            "(HALL OF SHAME)" => CurrentLanguage.cyberGrind.cybergrind_musicSuffixMuseum,
            _ => null,
        };

        __result = translatedName.Or(__result);
    }
}
