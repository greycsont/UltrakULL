using System;
using System.Reflection;
using HarmonyLib;
using UltrakULL.API;

namespace UltrakULL.Angry;


public class AngryPatchModule : IPatchModule
{
    private Harmony harmony;

    public string Name => "UltrakULL.angry";

    public void PatchAll()
    {
        if (harmony != null)
            return;

        harmony = new Harmony("greycsont.ultrakull.angry");

        foreach (var type in typeof(AngryPatchModule).Assembly.GetTypes())
        {
            var mod = type.GetCustomAttribute<PatchForMod>();

            if (mod != null && !string.IsNullOrEmpty(mod.ClassName))
            {
                TriggerEngine.Bind(type, new MethodTrigger
                {
                    className = mod.ClassName,
                    methodName = mod.MethodName,
                    argTypes = mod.Args,
                });
                continue;
            }

            if (type.GetCustomAttribute<HarmonyPatch>() != null)
                harmony.PatchAll(type);
        }
    }
}
