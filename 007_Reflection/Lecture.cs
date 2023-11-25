using System.Reflection;

namespace _007_Reflection;

public class Lecture
{
    public static void Ex01()
    {
        var i = 1;
        int? j = 1;
        int? k = null;
        Console.WriteLine(i.GetType());
        Console.WriteLine(j.GetType());
        //Console.WriteLine(k.GetType()); // NullReferenceException

        var t1 = typeof(int);
        Console.WriteLine(t1);

        var t2 = typeof(Console);
        Console.WriteLine(t2);

        var t3 = typeof(Type);
        Console.WriteLine(t3.GetType());
    }

    public static void Ex02()
    {
        // Type t1 = new Type(); // Так не получиться
        var t1 = typeof(object);
        Console.WriteLine(t1.AssemblyQualifiedName);
        Console.WriteLine(t1.BaseType == null); // Не базового класса
        Console.WriteLine();

        var t2 = typeof(string);
        Console.WriteLine(t2.AssemblyQualifiedName);
        Console.WriteLine(t2.BaseType == null); // базовый класс object
        Console.WriteLine(t2.BaseType);
        Console.WriteLine();

        var t3 = typeof(DivideByZeroException);
        Console.WriteLine(t3?.BaseType);

        Console.WriteLine(t3?.BaseType?.BaseType);
        Console.WriteLine(t3?.BaseType?.BaseType?.BaseType);
        Console.WriteLine(t3?.BaseType?.BaseType?.BaseType?.BaseType);
        Console.WriteLine();

        var t4 = typeof(List<>);
        Console.WriteLine(t4.ContainsGenericParameters);
        // Console.WriteLine(t4.DeclaringMethod);
        // Console.WriteLine(t4.DeclaringType);
        Console.WriteLine(t4.FullName);
        Console.WriteLine(t4.GUID);
        Console.WriteLine(t4.IsAbstract);

        var t = typeof(Colors);
        Console.WriteLine(t.IsAbstract);
        Console.WriteLine(t.IsNested); // Вложен
    }

    public static void Ex03()
    {
        var tt = typeof(List<>);
        var mb = tt.FindMembers(MemberTypes.All, BindingFlags.Public | BindingFlags.Instance, (_, _) => true, "");
        foreach (var i in mb) Console.WriteLine(i);
    }

    public static void Ex04()
    {
        var tt = typeof(string);
        var constructors = tt.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        foreach (var i in constructors) Console.WriteLine(i);
        // Void .ctor(Char, Int32)
        Console.WriteLine(new string('A', 5));
        var c = tt.GetConstructor(new[] { typeof(char), typeof(int) });
        Console.WriteLine(c);
    }

    public static void Ex05()
    {
        var ti = typeof(int);
        var tb = typeof(byte);

        Console.WriteLine(ti.IsAssignableTo(tb));
    }

    public static void Ex06()
    {
        // var ob = Activator.CreateInstance("_007_Reflection", "MyClass");
        var ob = Activator.CreateInstance(typeof(MyClass), "Hello", 1);
        Console.WriteLine(ob);
    }

    // Атрибуты
    private static T Create<T>()
    {
        var obj = Activator.CreateInstance<T>();
        if (obj == null)
            throw new Exception("Не удалось создать объект");

        var t = obj.GetType();
        var methods = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var m in methods)
        {
            var attr = m.GetCustomAttributes(false);
            foreach (var a in attr)
                if (a is InvokeAfterCreationAttribute)
                    m.Invoke(obj, new object[] { ((InvokeAfterCreationAttribute)a).X });
        }

        return obj;
    }

    public static void Ex07()
    {
        var obj = Create<MyClass>();
        Console.WriteLine(obj);
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class InvokeAfterCreationAttribute : Attribute
{
    public string X;

    public InvokeAfterCreationAttribute(string x)
    {
        X = x;
    }
}

internal class MyClass
{
    private static readonly int MyField = 3;
    public int MyProperty => MyField * -1;

    [InvokeAfterCreation("Я создан с помощью рефлексии.")]
    public void SomeMethod(string msg)
    {
        Console.WriteLine(msg);
    }

    // public MyClass(string hello, int i)
    // {
    //     Console.WriteLine(hello);
    // }
}

internal enum Colors
{
    Red,
    Green,
    White,
    Blue
}