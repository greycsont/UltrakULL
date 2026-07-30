using HarmonyLib;
using UnityEngine;

namespace UltrakULL;

public static partial class TextureSwapper
{
    public static void ReplaceStyleHud()
    {
        var hud = MonoSingleton<StyleHUD>.Instance;
        if (hud == null)
            return;

        bool changed = false;
        foreach (var rank in hud.ranks)
        {
            if (rank == null)
                continue;

            Sprite desired = GetDesiredSprite(rank.sprite);
            if (desired == rank.sprite)
                continue;

            Logging.Info($"StyleHUD.ranks | '{rank.sprite?.name ?? "<null>"}' -> " +
                $"'{desired?.name ?? "<null>"}'{GetSourceSuffix(rank.sprite)}", true);
            rank.sprite = desired;
            changed = true;
            replacementCount["StyleHUD rank sprite(s)"]++;
        }

        if (changed)
            hud.rankIndex = hud.rankIndex;
    }
}

[HarmonyPatch(typeof(StyleHUD))]
public static class StyleHudTexturePatch
{
    [HarmonyPatch(nameof(StyleHUD.Start))] [HarmonyPostfix]
    public static void Postfix() 
        => TextureSwapper.ReplaceStyleHud();
}
