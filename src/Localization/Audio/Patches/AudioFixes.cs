using HarmonyLib;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps;

// Rebind scene audio after checkpoint restarts.
[HarmonyPatch(typeof(NewMovement), "Respawn")]
public class RespawnAudioFixer
{
    [HarmonyPostfix]
    public static async void Respawn_SwapperFix()
    {
        if (isUsingEnglish()) return;

        await System.Threading.Tasks.Task.Delay(500);
        SubtitledAudioSourcesReplacer.ReplaceSubsAndAudio();
    }
}
