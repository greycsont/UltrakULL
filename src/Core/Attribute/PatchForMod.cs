using System;

namespace UltrakULL;

[AttributeUsage(AttributeTargets.Class)]
public class PatchForMod : Attribute
{
    public string Guid;
    public string ClassName;
    public string MethodName;
    public string[] Args;

    public PatchForMod(string guid, string className = null, string methodName = null, string[] args = null)
    {
        Guid = guid;
        ClassName = className;
        MethodName = methodName;
        Args = args;
    }
}