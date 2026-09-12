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
        var angry = LanguageManager.Current.angry;

        foreach (var header in ui.headers)
        {
            if (header == null)
                continue;

            var translation = header.name switch
            {
                "TimeHeader"   => angry.levelPanel.time,
                "KillHeader"   => angry.levelPanel.kills,
                "StyleHeader"  => angry.levelPanel.style,
                "SecretsHeader" => angry.levelPanel.secrets,
                _ => null,
            };

            header.text = translation.Or(header.text);
        }

        __instance.currentUi.challengeContainer.gameObject.Localize<Text>(angry.levelPanel.challenge, path: ["Header"]);
    
    }
}