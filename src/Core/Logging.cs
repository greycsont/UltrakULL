using System.IO;
using System.Runtime.CompilerServices;
using BepInEx.Logging;

namespace UltrakULL;

public static class Logging
{
    public static ManualLogSource UllLogger = Logger.CreateLogSource("ULL LOGGING");

    public static void Debug(string text, bool addCallerFilePath = false, [CallerFilePath] string callerFilePath = "") 
        => UllLogger.LogDebug(TryAddCallerName(text, addCallerFilePath, callerFilePath));

    public static void Message(string text, bool addCallerFilePath = false, [CallerFilePath] string callerFilePath = "") 
        => UllLogger.LogMessage(TryAddCallerName(text, addCallerFilePath, callerFilePath));

    public static void Warn(string text, bool addCallerFilePath = false, [CallerFilePath] string callerFilePath = "") 
        => UllLogger.LogWarning(TryAddCallerName(text, addCallerFilePath, callerFilePath));

    public static void Error(string text, bool addCallerFilePath = false, [CallerFilePath] string callerFilePath = "") 
        => UllLogger.LogError(TryAddCallerName(text, addCallerFilePath, callerFilePath));

    public static void Fatal(string text, bool addCallerFilePath = false, [CallerFilePath] string callerFilePath = "") 
        => UllLogger.LogFatal(TryAddCallerName(text, addCallerFilePath, callerFilePath));

    public static void Info(string text, bool addCallerFilePath = false, [CallerFilePath] string callerFilePath = "") 
        => UllLogger.LogInfo(TryAddCallerName(text, addCallerFilePath, callerFilePath));

    private static string TryAddCallerName(string text, bool addCallerFilePath, string callerFilePath) 
        => addCallerFilePath ? $"[{GetFileName(callerFilePath)}] {text}" : text;

    private static string GetFileName(string callerFilePath) 
        => Path.GetFileNameWithoutExtension(callerFilePath);
}
