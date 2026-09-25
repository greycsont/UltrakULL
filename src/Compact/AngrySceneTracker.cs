using System.Reflection;
using HarmonyLib;

namespace UltrakULL;

public static class AngrySceneTracker
{
    public const string SceneManagerType = "AngryLevelLoader.Managers.AngrySceneManager";

    public static bool resolved;

    public static MemberInfo inCustomLevel;
    public static MemberInfo currentBundleContainer;
    public static MemberInfo currentLevelContainer;
    public static MemberInfo bundleGuid;
    public static MemberInfo levelId;

    public static bool InAngryLevel { get; private set; }

    public static void Init()
    {
        TriggerEngine.Bind(new MethodTrigger
        {
            className = SceneManagerType,
            methodName = "LoadLevel",
            argTypes = new[]
            {
                "AngryLevelLoader.Containers.LevelContainer",
                "System.Boolean"
            }
        }, ReadCurrentScene);
    }

    public static void ReadCurrentScene()
    {
        if (!Resolve() || !ReflectionUtils.Read<bool>(inCustomLevel, null))
        {
            InAngryLevel = false;
            AngryLevelText.SetCurrent(null, null);
            return;
        }

        InAngryLevel = true;

        AngryLevelText.SetCurrent(
            ReflectionUtils.Read<string>(bundleGuid, ReflectionUtils.Read<object>(currentBundleContainer, null)),
            ReflectionUtils.Read<string>(levelId, ReflectionUtils.Read<object>(currentLevelContainer, null)));
    }

    static bool Resolve()
    {
        if (resolved)
            return inCustomLevel != null;

        resolved = true;

        var manager = AccessTools.TypeByName(SceneManagerType);
        if (manager == null)
        {
            Logging.Message("AngryLevelLoader is not loaded; custom level translations are off.");
            return false;
        }

        inCustomLevel = ReflectionUtils.GetMember(manager, "isInCustomLevel");
        currentBundleContainer = ReflectionUtils.GetMember(manager, "currentBundleContainer");
        currentLevelContainer = ReflectionUtils.GetMember(manager, "currentLevelContainer");

        bundleGuid = ReflectionUtils.GetMember(currentBundleContainer, "bundleGuid");
        levelId = ReflectionUtils.GetMember(currentLevelContainer, "levelId");

        if (inCustomLevel == null || bundleGuid == null || levelId == null)
            Logging.Warn($"Could not read AngrySceneManager members: " +
                         $"isInCustomLevel={inCustomLevel != null}, " +
                         $"bundleGuid={bundleGuid != null}, levelId={levelId != null}");

        return inCustomLevel != null && bundleGuid != null && levelId != null;
    }
}
