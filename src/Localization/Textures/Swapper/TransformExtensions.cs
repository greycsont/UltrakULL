using System.Collections.Generic;
using UnityEngine;

namespace UltrakULL;

public static class TransformExtensions
{
    extension(Transform value)
    {
        public string GetPath()
        {
            var names = new List<string>();
            for (var current = value; current != null; current = current.parent)
                names.Add(current.name);
            names.Reverse();
            return string.Join("/", names);
        }
    }
}
