using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;


namespace UltrakULL;

/// <summary>
/// Harmony Variables for Harmony Patch
/// </summary>
public record struct MethodTrigger
{
    public string className;
    public string methodName;
    public string[]? argTypes;
}

public static class TriggerEngine
{
    private static Harmony? _harmony;
    private static readonly Dictionary<MethodBase, List<Type>> _types = new();
    private static readonly HashSet<MethodBase> _patched = new();

    public static void Init(Harmony harmony) => _harmony = harmony;

    
    /// <summary>
    /// Bind a type needs to patch to a method
    /// (One method only patch once cuz why you f need to patch twice waste process power)
    /// </summary>
    /// <param name="typeNeedsPatch">the type </param>
    public static void Bind(Type typeNeedsPatch, MethodTrigger trigger)
    {
        var method = Resolve(trigger);
        if (method == null) return; // Resolve already logged the why

        if (!_types.TryGetValue(method, out var list))
            _types[method] = list = new List<Type>();
        list.Add(typeNeedsPatch);

        // one patch per method, later rules just reuse the same postfix
        if (_patched.Add(method))
        {
            var postfix = new HarmonyMethod(typeof(TriggerEngine), nameof(Bridge));
            _harmony!.Patch(method, postfix: postfix);
        }
    }

    /// <summary>
    /// Gets the methodbase via
    ///   class's name
    ///   method's name
    ///   arg's types
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private static MethodBase? Resolve(MethodTrigger t)
    {
        if (string.IsNullOrEmpty(t.className) || string.IsNullOrEmpty(t.methodName))
        {
            Logging.Warn("className/methodName are null ");
            return null;
        }

        var type = AccessTools.TypeByName(t.className);
        if (type == null)
        { 
            Logging.Warn($"Could not find the type: {t.className}");
            return null;
        }

        MethodBase? method;
        if (t.argTypes is { Length: > 0 })
        {
            var paramTypes = t.argTypes.Select(AccessTools.TypeByName).ToArray();
            if (paramTypes.Any(p => p == null))
            {
                Logging.Warn($"{t.className}.{t.methodName}'s' argTypes have types that could not be parsed");
                return null;
            }
            method = AccessTools.Method(type, t.methodName, paramTypes!);
        }
        else
        {
            method = AccessTools.Method(type, t.methodName);
        }

        if (method == null)
            Logging.Warn($"Could not find the method: {t.className}.{t.methodName}");

        return method;
    }

    private static void Bridge(MethodBase __originalMethod)
    {
        if (!_types.TryGetValue(__originalMethod, out var rules)) return;
        foreach (var rule in rules)
        {
            try
            {
                _harmony.PatchAll(rule);
            }
            catch (Exception e)
            {
                Logging.Error($"Failed to patch {rule}: {e}");
            }
        }
        _types.Remove(__originalMethod);
    }
}
