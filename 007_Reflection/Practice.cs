using System.Text;

namespace _007_Reflection;

public static class Practice
{
    public static void Pr01()
    {
        var o1 = Activator.CreateInstance(typeof(TestClass));
        Console.WriteLine(o1);
        var o2 = Activator.CreateInstance(typeof(TestClass), 1);
        Console.WriteLine(o2);
        var o3 = Activator.CreateInstance(typeof(TestClass), 1, "AAAA", 1.5M, new[] { 'A', 'B' });
        Console.WriteLine(o3);
    }

    private static object? StringToObject(string className)
    {
        var type = Type.GetType(className);
        if (type != null)
            return Activator.CreateInstance(type);
        throw new AggregateException($"Class '{className}' not found.");
    }

    private static string ObjectToString(object? o)
    {
        if (o == null)
        {
            Console.WriteLine("Object is null");
            return "";
        }

        var type = o.GetType();

        var sb = new StringBuilder();
        sb.Append($"Type: {type.FullName}");
        // Свойства
        sb.Append("\nProperties:");
        foreach (var prop in type.GetProperties()) sb.Append($"\n - {prop.Name}, Type: {prop.PropertyType.Name}");

        // Конструкторы
        sb.Append("\nConstructors:");
        foreach (var constructorInfo in type.GetConstructors())
        {
            sb.Append($"\n - {constructorInfo.Name}: Parameters: ");
            foreach (var parameterInfo in constructorInfo.GetParameters())
                sb.Append($"{parameterInfo.ParameterType.Name} {parameterInfo.Name}, ");
        }

        // Методы
        sb.Append("\nMethods:");
        foreach (var method in type.GetMethods())
        {
            sb.Append($"\n - {method.Name}, Return Type: {method.ReturnType.Name}, Parameters: ");
            foreach (var param in method.GetParameters())
                sb.Append($"\n\t\t - {param.ParameterType.Name} {param.Name}");
        }

        return sb.ToString();
    }

    public static void Pr02()
    {
        Console.WriteLine(ObjectToString(new TestClass()));
        Console.WriteLine();
        Console.WriteLine(ObjectToString(new string("")));
    }

    public static void Pr03()
    {
        var o = StringToObject("_007_Reflection.TestClass");
        Console.WriteLine(o.GetType().Name);
    }
}