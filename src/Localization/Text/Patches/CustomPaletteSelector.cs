using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

using static UltrakULL.json.LanguageManager;


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
            "Gamebot Color" => CurrentLanguage.options.graphics_customColorPaletteGamebotColor,
            "Noir" => CurrentLanguage.options.graphics_customColorPaletteNoir,
            "Pink and Purple" => CurrentLanguage.options.graphics_customColorPalettePinkAndPurple,
            "Rustic" => CurrentLanguage.options.graphics_customColorPaletteRustic,
            "Shake" => CurrentLanguage.options.graphics_customColorPaletteShake,
            "Sin Shitty" => CurrentLanguage.options.graphics_customColorPaletteSinShitty,
            _ => fileName
        };
    }
}