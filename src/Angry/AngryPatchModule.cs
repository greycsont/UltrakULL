using System;
using System.Reflection;
using AngryLevelLoader.Managers;
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

        AngrySceneTracker.ReadCurrentLevel = () =>
        {
            if (ConfigManager.config == null)
                return null;

            if (!AngrySceneManager.isInCustomLevel)
                return null;

            var currentBundle = AngrySceneManager.currentBundleContainer;
            var currentLevel = AngrySceneManager.currentLevelContainer;

            return (currentBundle.bundleGuid, 
                    currentBundle.BundleAuthor,
                    currentBundle.BundleName,
                    currentLevel.levelId,
                    currentLevel.LevelName);
        };

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
