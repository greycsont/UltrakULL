using HarmonyLib;
using AngryLevelLoader.Fields;
using AngryLevelLoader.Containers;
using UltrakULL.json;
using PluginConfig.API.Functionals;
using AngryLevelLoader.DataTypes;
using UnityEngine.UI;
using System.IO;

namespace UltrakULL;

[PatchForMod(DependencyGuid.ANGRY_LEVEL_LOADER)]
[HarmonyPatch(typeof(LevelField))]
public static class LevelFieldPatch
{
    [HarmonyPatch(nameof(LevelField.OnCreateUI))] [HarmonyPostfix]
    public static void LocalizeButtons(LevelField __instance)
    {
        if (LanguageManager.IsEnglish) return;
        if (!__instance.inited) return;
        
        var ui = __instance.currentUi;
        var T = LanguageManager.CurrentLanguage;

        foreach (var header in ui.headers)
        {
            if (header == null)
                continue;

            var translation = header.name switch
            {
                "TimeHeader"   => T?.misc?.levelstats_time,
                "KillHeader"   => T?.misc?.levelstats_kills,
                "StyleHeader"  => T?.misc?.levelstats_style,
                "SecretsHeader" => T?.misc?.levelstats_secrets,
                _ => null,
            };

            header.text = translation.Or(header.text);
        }

        __instance.currentUi.challengeContainer.gameObject.Localize<Text>(T?.misc?.levelstats_challenge, path: ["Header"]);
    
    }
}