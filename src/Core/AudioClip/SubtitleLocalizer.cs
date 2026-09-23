using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL;

/// <summary>
/// An IL helper for localize the character's subtitle
/// e.g. Power, Mandalore, Minos, Sisyphus and Gabriel
/// </summary>
public static class SubtitleLocalizer
{
    private static readonly MethodInfo DisplaySubtitle = AccessTools.Method(
        typeof(SubtitleController), "DisplaySubtitle", new[] { typeof(string), typeof(AudioSource), typeof(bool) });

    private static readonly MethodInfo DisplaySubtitleOverride = AccessTools.Method(
        typeof(SubtitleController), "DisplaySubtitle", new[] { typeof(string), typeof(float), typeof(GameObject) });

    public static IEnumerable<CodeInstruction> InjectLocalize2(IEnumerable<CodeInstruction> instructions, MethodInfo localize, OpCode? anchorOpcode = null)
    {
        // new Pos = (callPos + 2 - m.Pos) - 1 = callPos + 1
        // Since function localize itself are count as a line
        return new CodeMatcher(instructions)
            .MatchForward(false, 
                new CodeMatch(i => i.Calls(DisplaySubtitle) || i.Calls(DisplaySubtitleOverride))
            )
            .Repeat(m =>
            {
                int callPos = m.Pos;

                m.SearchBack(i => i.opcode == (anchorOpcode ?? OpCodes.Ldstr));
                if (m.IsInvalid || callPos - m.Pos > 8)            // holy magic number
                {
                    Logging.Warn($"InjectLocalize: no nearby {anchorOpcode ?? OpCodes.Ldstr} before DisplaySubtitle, skipped.");
                    m.Start().Advance(callPos + 1);     // while (Invalid) {Pos += direction} => Pos = -1 
                    return;
                }

                m.Advance(1)
                .Insert(new CodeInstruction(OpCodes.Call, localize))
                .Advance(callPos + 2 - m.Pos);
            })
            .InstructionEnumeration();
    }

    public static IEnumerable<CodeInstruction> InjectLocalize3(IEnumerable<CodeInstruction> instructions, MethodInfo localize, int position = -2)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false,
                new CodeMatch(i => i.Calls(DisplaySubtitle) || i.Calls(DisplaySubtitleOverride))
            )
            .Repeat(m =>
            {
                int callPos = m.Pos;

                m.Advance(position)
                .Insert(new CodeInstruction(OpCodes.Call, localize))
                .Advance(callPos + 2 - m.Pos);
            })
            .InstructionEnumeration();
    }
}
