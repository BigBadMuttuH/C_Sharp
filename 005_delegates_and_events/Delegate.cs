namespace _005_delegates_and_events;

public delegate void MyDelegate();

public delegate void MyDelegate1();

public delegate int IntDelegate();

public delegate void AnotherDelegate(string s);

internal class Example04
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Привет, {name}");
    }
}

public class Delegate
{
    private static void SayHello()
    {
        Console.WriteLine("Привет, я - делегат!");
    }

    private static void SayBy()
    {
        Console.WriteLine("Пока");
    }

    private static void SayName(string name)
    {
        Console.WriteLine($"Привет, {name}");
    }

    public static void Ex01()
    {
        MyDelegate myDelegate1 = SayHello;
        MyDelegate myDelegate2 = SayHello;

        myDelegate1();
        myDelegate2();
        Console.WriteLine();

        // добавим еще одни метод
        myDelegate1 += SayBy;
        myDelegate1();
        Console.WriteLine();

        MyDelegate myDelegate3 = SayBy;
        myDelegate1 += myDelegate3;
        myDelegate1 += myDelegate2;
        myDelegate1();
        Console.WriteLine("---------");

        // можно и вычитать
        myDelegate1 -= myDelegate2;
        myDelegate1 -= myDelegate3;
        myDelegate1();
        Console.WriteLine();

        AnotherDelegate anotherDelegate1 = SayName;
        anotherDelegate1("Антон");
        Console.WriteLine();

        // Так не получится, сигнатуры вызова метода разные
        // myDelegate1 += anotherDelegate1;

        // Так тоже не получиться
        // MyDelegate dl1 = new MyDelegate(SayHello);
        // MyDelegate1 dl2 = new MyDelegate1(SayBy);
        // dl1 += dl2;

        myDelegate1 -= SayHello;
        myDelegate1 -= SayBy;
        // Тут будет ошибка
        // myDelegate1();
        // Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
        if (myDelegate1 != null)
            myDelegate1();

        Console.WriteLine("-----");
        anotherDelegate1.Invoke("Имя");
        anotherDelegate1("Имя"); // это тоже, что и строка выше
        anotherDelegate1 -= SayName;
        // Теперь, в случае если нет методов, то ни чего не произойдет
        anotherDelegate1?.Invoke("Имя");
        Console.WriteLine("-----");
    }

    public static void Ex02()
    {
        MyDelegate? myDelegate1 = SayHello;
        myDelegate1 += SayBy;

        Console.WriteLine($"В списке вызовов делегата число методов = {myDelegate1.GetInvocationList().Length}");
        Console.WriteLine();

        // Важно, var method - так не прокатит. Нужно именно MyDelegate method 
        foreach (MyDelegate method in myDelegate1.GetInvocationList())
        {
            Console.WriteLine("Вызываем метод:");
            method();
        }
    }

    private static int ReturnHello()
    {
        Console.WriteLine("Привет!!!!!!!");
        return 0;
    }

    private static int ReturnBy()
    {
        Console.WriteLine("Пока!!!!!!!");
        return 1;
    }

    public static void Ex03()
    {
        IntDelegate? dl1 = ReturnHello;
        dl1 += ReturnBy;
        Console.WriteLine(dl1());
        Console.WriteLine();
        // Привет!!!!!!!
        // Пока!!!!!!!  
        // 1  

        dl1.Invoke();
        // Привет!!!!!!!
        // Пока!!!!!!!  

        // ? В современном C# не используются.
        // dl1.BeginInvoke();
        // dl1.EndInvoke();

        AnotherDelegate ad1 = SayName;
        //тут будет ошибка, даже если будет проверка на null. (?) DynamicInvoke - надо проверять самостоятельно
        // ad1?.DynamicInvoke();
        // Unhandled exception. System.Reflection.TargetParameterCountException: Parameter count mismatch. 
        //так можно
        ad1?.DynamicInvoke("Василий!!");
        // Обычно DynamicInvoke используется при рефлексии
    }

    public static void Ex04()
    {
        var ex = new Example04();
        AnotherDelegate? adl1 = ex.SayHello;
        Console.WriteLine(adl1.Target); //  _005_delegates_and_events.Example04
    }
}