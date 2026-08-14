using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(GetMissionName))]
public static class Patch_GetMissionName
{
    [HarmonyPatch(nameof(GetMissionName.GetMissionNameOnly))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> TranspileGetMissionNameOnly(
        IEnumerable<CodeInstruction> instructions,
        ILGenerator generator)
    {
        var localizeMissionName = AccessTools.Method(
            typeof(Patch_GetMissionName),
            nameof(LocalizeMissionName));

        return new CodeMatcher(instructions, generator)
            .MatchForward(
                false,
                new CodeMatch(OpCodes.Ldstr),
                new CodeMatch(OpCodes.Ret))
            .ThrowIfNotMatch("Could not find a string return in GetMissionName.GetMissionNameOnly")
            .Repeat(match => match
                .Advance(1)
                .InsertAndAdvance(
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call, localizeMissionName)))
            .InstructionEnumeration();
    }

    private static string LocalizeMissionName(string original, int missionNum)
    {
        if (LanguageManager.IsEnglish || SceneHelper.IsPlayingCustom)
            return original;

        return LevelNames.GetMissionNameOnly(missionNum, original);
    }
}
