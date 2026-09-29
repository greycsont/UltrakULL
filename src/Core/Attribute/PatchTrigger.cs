using System;

namespace UltrakULL;

[AttributeUsage(AttributeTargets.Class)]
public class PatchTrigger : Attribute
{
    public string ClassName;
    public string MethodName;
    public string[] Args;

    public PatchTrigger(string className = null, string methodName = null, string[] args = null)
    {
        ClassName = className;
        MethodName = methodName;
        Args = args;
    }
}