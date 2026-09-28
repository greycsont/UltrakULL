using System;

namespace UltrakULL;

public static class AngrySceneTracker
{
    public static bool InAngryLevel { get; private set; }

    public static Func<(string BundleGuid, string BundleAuthor, string BundleName, string LevelId)?> ReadCurrentLevel;

    public static void ReadCurrentScene()
    {
        var current = ReadCurrentLevel?.Invoke();

        InAngryLevel = current != null;
        AngryLevelText.SetCurrent(
            current?.BundleGuid, 
            current?.BundleAuthor,
            current?.BundleName,
            current?.LevelId);
    }
}
