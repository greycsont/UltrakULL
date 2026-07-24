using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;

namespace UltrakULL;

public static class HarmonyInstructions
{
    public static IEnumerable<CodeInstruction> IL(params (OpCode, object)[] instructions)
    {
        return instructions.Select(instruction =>
            new CodeInstruction(instruction.Item1, instruction.Item2)).ToList();
    }
}
