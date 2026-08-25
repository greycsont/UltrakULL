using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;


[HarmonyPatch(typeof(CustomPaletteSelector))]
public static class LocalizeCustomPaletteSelector
{
    public static MethodInfo PathWithoutExtensionMethodInfo = AccessTools.Method(
        typeof(Path),
        nameof(Path.GetFileNameWithoutExtension),
        new[] { typeof(string) }
    );

    public static MethodInfo LocalizePaletteNameMethodInfo = AccessTools.Method(
        typeof(LocalizeCustomPaletteSelector),
        nameof(LocalizeCustomPaletteSelector.LocalizePaletteName)
    );

    [HarmonyPatch(nameof(CustomPaletteSelector.BuildMenu))] [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> BuildPageTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        var codeMatcher = new CodeMatcher(instructions);
    
        return codeMatcher.MatchForward(false,
            new CodeMatch(i => i.Calls(PathWithoutExtensionMethodInfo)))
        .Advance(1)
        .Insert(new CodeInstruction(OpCodes.Call, LocalizePaletteNameMethodInfo))
        .InstructionEnumeration();
    }


    private static string LocalizePaletteName(string fileName)
    {
        return fileName switch
        {
            "Gamebot Color" => "bot",
            "Noir" => "or",
            "Pink and Purple" => "maimaiddx",
            "Rustic" => "Rust",
            "Shake" => "11111",
            "Sin Shitty" => "SLOP",
            _ => fileName
        };
    }
}