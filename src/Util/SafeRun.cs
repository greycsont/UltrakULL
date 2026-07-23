using System;

namespace UltrakULL;

public static class SafeRun
{
    public static void Run(string name, Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            Logging.Error($"Failed to run '{name}': {e}");
        }
    }
}
