using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

using static UltrakULL.json.LanguageManager;

namespace UltrakULL;

[HarmonyPatch(typeof(FishLeaderboard))]
public static class FishLeaderboardPatch
{
    public static MethodInfo LocalizeLeaderboardCategoryTitleMethodInfo = AccessTools.Method(
        typeof(FishLeaderboardPatch),
        nameof(FishLeaderboardPatch.LocalizeLeaderboardCategoryTitle),
        new[] { typeof(string) }
    );

    /// <summary>
    /// I really seen this in vibe coded mods a lot
    ///   and it's like the second time I'm using it
    /// </summary>
    /// <returns>MoveNext</returns>
    private static MethodBase TargetMethod()
    {
        var stateMachine = typeof(FishLeaderboard)
            .GetNestedTypes(BindingFlags.NonPublic)
            .FirstOrDefault(t => t.Name.StartsWith("<Fetch>d__"));

        return AccessTools.Method(stateMachine, "MoveNext");
    }

    [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> FetchTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        var matcher = new CodeMatcher(instructions);

        while (true)
        {
            matcher.MatchForward(false,
                new CodeMatch(i => i.opcode == OpCodes.Ldstr 
                          && ((string)i.operand == "<b>GLOBAL</b>" || (string)i.operand == "<b>FRIENDS</b>"))
            );

            if (matcher.IsInvalid)
                break;

            matcher.Advance(1);
            matcher.Insert(new CodeInstruction(OpCodes.Call, LocalizeLeaderboardCategoryTitleMethodInfo));
        }

        return matcher.InstructionEnumeration();
    }

    private static string LocalizeLeaderboardCategoryTitle(string input)
    {
        if (IsEnglish)
            return input;

        var localizedText = input switch
        {
            "<b>GLOBAL</b>" => CurrentLanguage.secretLevels.secretLevels_fifth_leaderboard_global,
            "<b>FRIENDS</b>" => CurrentLanguage.secretLevels.secretLevels_fifth_leaderboard_friend,
            _ => null,
        };

        return "<b>{0}</b>".FormatWith(localizedText.Or(input));
    }
}