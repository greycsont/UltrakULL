using System;
using System.Reflection;
using HarmonyLib;

namespace UltrakULL;

public partial class ReflectionUtils
{
    private static readonly BindingFlags BindingFlagsFields =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    public static void SetPrivate<T, V>(T instance, Type classType, string field, V value)
    {
        FieldInfo privateField = classType.GetField(field, BindingFlagsFields);
        privateField.SetValue(instance, value);
    }

    public static MemberInfo GetMember(Type owner, string name)
    {
        if (owner == null)
            return null;

        return (MemberInfo)AccessTools.Property(owner, name) ?? AccessTools.Field(owner, name);
    }

    public static MemberInfo GetMember(MemberInfo owner, string name)
        => owner switch
        {
            PropertyInfo property => GetMember(property.PropertyType, name),
            FieldInfo field => GetMember(field.FieldType, name),
            _ => null
        };

    public static T Read<T>(MemberInfo member, object instance)
    {
        if (member == null)
            return default;

        try
        {
            object value = member switch
            {
                PropertyInfo property => property.GetValue(instance),
                FieldInfo field => field.GetValue(instance),
                _ => null
            };

            return value is T typed ? typed : default;
        }
        catch (Exception e)
        {
            Logging.Warn($"Failed to read {member.DeclaringType?.Name}.{member.Name}: {e.Message}");
            return default;
        }
    }
}
