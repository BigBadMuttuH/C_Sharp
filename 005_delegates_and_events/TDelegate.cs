namespace _005_delegates_and_events;

// Обобщенные делегаты
internal delegate TResult MyGenericDelegate<T, TResult>(T x);

// Ковариантность (out)
internal delegate TResult MyFunc<out TResult>();

// Контрвариантность (in)
internal delegate void MyAction<in T>(T x);

public class TDelegate
{
    private static string SayHello(string name)
    {
        return $"Привет, я - {name}";
    }

    private static void SayHelloVoid(string name)
    {
        Console.WriteLine($"Привет, я - {name}");
    }

    public static void Ex01()
    {
        MyGenericDelegate<string, string>? myGenericDelegate = SayHello;
        // Не получиться так:
        // MyGenericDelegate<string, void>? myGenericDelegate1 = SayHelloVoid;
        Console.WriteLine(myGenericDelegate("Делегат!"));
    }


    // Action Delegate
    public static void Ex02()
    {
        var dl1 = SayHelloVoid;
        dl1("Делегат");
        Console.WriteLine();

        var list = new List<string> { "Анна", "Александр" };
        // list.ForEach(SayHelloVoid); // синтаксический сахар
        // под капотом вот так
        var action = SayHelloVoid;
        list.ForEach(action);
        Console.WriteLine();
        // или так
        list.ForEach(SayHelloVoid);
    }

    // Func Delegate
    private static string DigitToRoman(int x)
    {
        switch (x)
        {
            case 1: return "I";
            case 2: return "II";
            case 3: return "III";
            case 4: return "IV";
            case 5: return "V";
            case 6: return "VI";
            case 7: return "VII";
            case 8: return "VIII";
            case 9: return "IX";
            case 10: return "X";
            default: return "";
        }
    }

    public static void Ex03()
    {
        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // var romans = ints.Select() смотрим какой тип на нужен и делаем так
        var romans = ints.Select(DigitToRoman);
        // romans.ToList().ForEach(x => Console.Write($"{x}, "));
    }

    // Предикат 
    private static bool IsEvent(int x)
    {
        return x % 2 == 0;
    }

    public static void Ex04()
    {
        // in T - контравариантный
        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ints.FindAll(IsEvent).ForEach(x => Console.Write($"чет:{x}; "));
    }

    // Контравариантность делегатов
    private static void SomeMethodObject(object o)
    {
        Console.WriteLine("Метод Объект");
        Console.WriteLine(o);
    }

    private static void SomeMethodString(string s)
    {
        Console.WriteLine("Метод Строка");
        Console.WriteLine(s);
    }

    public static void Ex05()
    {
        var predicateS = SomeMethodString;
        var predicateO = SomeMethodObject;

        predicateS = predicateO;

        predicateS("Строка");
    }


    // Ковариантность
    private static object SomeMethodObj()
    {
        Console.WriteLine("method - SomeMethodObj");
        return new object();
    }

    private static string SomeMethodStr()
    {
        Console.WriteLine("method - SomeMethodStr");
        return "";
    }

    public static void Ex06()
    {
        MyFunc<object> func = SomeMethodStr;
        var result = func();
        Console.WriteLine(result.GetType());
        // method - SomeMethodStr
        // System.String
    }

    // Контрвариантность (in)
    private static void SomeMethodO(object o)
    {
        Console.WriteLine("method - SomeMethodO");
        Console.WriteLine(o.GetType());
    }

    private static void SomeMethodS(string s)
    {
        Console.WriteLine("method - SomeMethodS");
        Console.WriteLine(s.GetType());
    }

    public static void Ex07()
    {
        MyAction<string> a1 = SomeMethodO;
        a1("Строка!");
        // method - SomeMethodO
        // System.String
    }
}