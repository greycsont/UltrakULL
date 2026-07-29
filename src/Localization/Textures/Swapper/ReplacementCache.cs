using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UltrakULL;

/// <summary>
/// Indexes each replacement by both its original and generated asset.
/// Keeps old replacement entries until scene references are updated.
/// </summary>
internal sealed class ReplacementCache<T> where T : Object
{
    private readonly struct Replacement(T original, T current)
    {
        public readonly T Original = original;
        public readonly T Current = current;
    }

    /// <summary>
    /// this will store two index of Replacement
    /// One is for original, one is current
    /// That's fucked up, maybe create a new data type in future
    /// </summary>
    private readonly Dictionary<T, Replacement> replacements = new();
    private readonly HashSet<T> active = new();
    private readonly List<T> stale = new();

    public T GetOriginal(T value) =>
        value != null && replacements.TryGetValue(value, out Replacement replacement)
            ? replacement.Original : value;

    public bool TryGetCurrent(T original, out T current)
    {
        bool found = replacements.TryGetValue(original, out Replacement replacement);
        current = found ? replacement.Current : null;
        return current != null;
    }

    public bool IsReplacement(T value) =>
        value != null
        && replacements.TryGetValue(value, out Replacement replacement)
        && replacement.Current == value;

    public void Add(T original, T replacement, bool cache = true)
    {
        var entry = new Replacement(original, replacement);
        if (cache)
            replacements[original] = entry;
        replacements[replacement] = entry;
        active.Add(replacement);
    }

    public void QueueCleanup()
    {
        foreach (T replacement in active)
        {
            Replacement entry = replacements[replacement];
            if (replacements.TryGetValue(entry.Original, out Replacement current)
                && current.Current == replacement)
                replacements.Remove(entry.Original);
        }
        stale.AddRange(active);
        active.Clear();
    }

    public void Cleanup(Action<T> destroy)
    {
        foreach (T replacement in stale)
        {
            replacements.Remove(replacement);
            if (replacement == null)
                continue;
            destroy(replacement);
        }
        stale.Clear();
    }
}
