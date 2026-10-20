using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using static UltrakULL.json.LanguageManager;

namespace UltrakULL;

[HarmonyPatch(typeof(CustomMusicSoundtrackBrowser))]
public static class CustomMusicSoundtrackBrowserPatch
{
    public static MethodInfo LocalizeUnlockedMethodInfo = AccessTools.Method(
        typeof(CustomMusicSoundtrackBrowserPatch),
        nameof(CustomMusicSoundtrackBrowserPatch.LocalizeUnlocked),
        new[] { typeof(string) } 
    ); 
    [HarmonyPatch(nameof(CustomMusicSoundtrackBrowser.LoadSongButton), methodType: MethodType.Enumerator)] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> LoadSongButtonTranspilere(IEnumerable<CodeInstruction> instructions)
    {
        var matcher = new CodeMatcher(instructions);

        return matcher.MatchForward(false,
            new CodeMatch(i => i.opcode == OpCodes.Ldstr && (string)i.operand == "Unlocked"))
        .ThrowIfNotMatch("Fuck this mf patch doesn't find the operand")
        .Advance(1)
        .Insert(new CodeInstruction(OpCodes.Call, LocalizeUnlockedMethodInfo))
        .InstructionEnumeration();
    }

    public static string LocalizeUnlocked(string input)
    {
        return CurrentLanguage.cyberGrind.cybergrind_musicUnlocked.Or(input);
    }
}
