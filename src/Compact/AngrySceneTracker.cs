using System;

namespace UltrakULL;

public static class AngrySceneTracker
{
    public static bool InAngryLevel { get; private set; }

    public static Func<(string BundleGuid, string LevelId)?> ReadCurrentLevel;

    public static void ReadCurrentScene()
    {
        (string BundleGuid, string LevelId)? current = ReadCurrentLevel?.Invoke();

        InAngryLevel = current != null;
        AngryLevelText.SetCurrent(current?.BundleGuid, current?.LevelId);
    }
}
