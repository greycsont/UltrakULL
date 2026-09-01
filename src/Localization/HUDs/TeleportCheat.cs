using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using TMPro;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

// You can find teleport menu by Press L by default in any level with cheats on
[HarmonyPatch(typeof(TeleportCheat))]
public static class LocalizeTeleportCheat
{
    [HarmonyPatch(nameof(TeleportCheat.GenerateList))] [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> GenerateListTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        var textSetter = AccessTools.PropertySetter(typeof(TMP_Text), nameof(TMP_Text.text));
        var localize = AccessTools.Method(typeof(LocalizeTeleportCheat), nameof(Localize));

        var matcher = new CodeMatcher(instructions)
            .MatchForward(false, new CodeMatch(instruction => instruction.Calls(textSetter)))
            .ThrowIfInvalid("Could not find TMP_Text.text assignment in TeleportCheat.GenerateList");

        var localizeCall = new CodeInstruction(OpCodes.Call, localize);
        matcher.Instruction.MoveLabelsTo(localizeCall); // Move IL_01d3 to Localize
        matcher.Insert(localizeCall);

        return matcher.InstructionEnumeration();
    }

    private static string Localize(string original)
    {
        if (LanguageManager.IsEnglish || string.IsNullOrEmpty(original))
            return original;

        var levels =
            LanguageManager.CurrentLanguage.misc.teleportLevels;

        string scene = GetCurrentSceneName();
        if (levels == null
            || string.IsNullOrEmpty(scene)
            || !levels.TryGetValue(scene, out Dictionary<string, string> checkpoints)
            || checkpoints == null
            || (!checkpoints.TryGetValue(original, out string localized)
                && !checkpoints.TryGetValue(" " + original, out localized))
            || string.IsNullOrEmpty(localized))
            return original;

        return localized;
    }
}
