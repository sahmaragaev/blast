using System.Reflection;

namespace Utility;

public static class AssemblyExtensions
{
    public static IEnumerable<Type> GetTypesByAttribute<TAttribute>(this Assembly assembly,
        Predicate<Type>? predicate = null)
        where TAttribute : Attribute
    {
        IEnumerable<Type> types = assembly.GetTypes().Where(t => t.GetCustomAttribute<TAttribute>() is not null);

        if (predicate is not null)
        {
            types = types.Where(predicate.Invoke);
        }

        return types.ToList();
    }

    public static Delegate? CreateGenericDelegateFromMethod(this MethodInfo methodInfo, object[] parameters,
        params Type[] type)
    {
        MethodInfo? genericMethodInfo = methodInfo?.MakeGenericMethod(type);

        return (Delegate)genericMethodInfo?.Invoke(null, parameters)!;
    }

    public static Type[] GetGenericArgumentsFromImplementedInterfaces(this Type type, Type genericTypeToSearch)
    {
        return type.GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericTypeToSearch)!
            .GetGenericArguments();
    }
}