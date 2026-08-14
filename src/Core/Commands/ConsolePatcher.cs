using GameConsole;
using HarmonyLib;

namespace UltrakULL;

[HarmonyPatch(typeof(Console))]
public class ConsolePatcher
{
    [HarmonyPatch(nameof(Console.Awake))] [HarmonyPrefix]
    public static void AddConsoleCommands(Console __instance)
    {
        var Command = new CommandToRegister(__instance);
        __instance.RegisterCommand(Command);
    }
}



