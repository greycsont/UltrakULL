using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

// Rebind scene audio after checkpoint restarts.
[HarmonyPatch(typeof(NewMovement), "Respawn")]
public class RespawnAudioFixer
{
    [HarmonyPostfix]
    public static async void Respawn_SwapperFix()
    {
        if (LanguageManager.IsEnglish) return;

        await System.Threading.Tasks.Task.Delay(500);
        SubtitledAudioSourcesReplacer.ReplaceSubsAndAudio();
    }
}
