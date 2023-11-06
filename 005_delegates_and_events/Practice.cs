namespace _005_delegates_and_events;

public static class Practice
{
    public delegate void myDelegate(string message);
    // Action - ни чего не возвращает   - void
    // Func - возвращает значение       - T
    // Predicate - принимает параметр и возвращает булево значение - bool

    private static void Method1()
    {
        Console.WriteLine("Method1");
    }

    private static void Method2()
    {
        Console.WriteLine("Method2");
    }

    // Создайте метод, который принимает список действий (делегат Action) и выполняет их последовательно.
    public static void Pr01()
    {
        var list = new List<Action>();
        list.Add(Method1);
        list.Add(Method2);

        foreach (var action in list) action.Invoke();

        var act = () =>
        {
            Method1();
            Method2();
        };
        act.Invoke();
    }

    public static void Pr02()
    {
        var dl1 = new List<myDelegate>
        {
            message => Console.WriteLine($"1 delegate, message - {message}"),
            message => Console.WriteLine($"2 delegate, message - {message}")
        };

        foreach (var myDelegate in dl1) myDelegate("msg");
    }

    public static void Pr03()
    {
        // Спроектируем интерфейс калькулятора, поддерживающего простые арифметические действия,
        // хранящего результат и также способного выводить информацию о результате при помощи события
        var calc = new Calc();
        calc.MyEventHandler += Calc_MyEventHandler;
        calc.Sum(10);
        calc.Sub(10);
        calc.Multiply(10);
        calc.Divide(10);
    }

    private static void Calc_MyEventHandler(object? sender, EventArgs e)
    {
        if (sender is Calc)
            Console.WriteLine(((Calc)sender).Result);
    }

    public static void Pr04()
    {
        // Арифметические методы должны выполняться как обычно а метод CancelLast должен отменять последнее действие.
        // При этом метод может отменить последовательно все действия вплоть до самого последнего.
        // Спросите как студенты планируют реализовать отмену действия и если будут трудности с ответами то подскажите им про стек
        var calc = new Calc();
        calc.MyEventHandler += Calc_MyEventHandler;
        calc.Sum(5);
        calc.Sub(3);
        calc.Multiply(4);
        calc.Divide(2);
        calc.CancelLast();
        calc.CancelLast();
    }

    public static void Pr05()
    {
        // Описание: Создайте метод, который принимает список строк,
        // функцию (делегат Func) для преобразования строк в числа и действие (делегат Action) для выполнения какого-либо действия с числами.
        var list = new List<string> { "1", "2", "3", "4" };
        Parse(list, int.Parse, x => Console.WriteLine($"{x}, {x.GetType()}"));
    }

    private static void Parse(List<string> listStr, Func<string, int> func, Action<int> action)
    {
        foreach (var item in listStr)
        {
            var res = func(item);
            action(res);
        }
    }

    public static void Pr06()
    {
        // Описание: Создайте метод, который принимает список чисел и предикат (делегат Predicate),
        // который определяет, соответствует ли каждое число какому-либо условию.
        var list = new List<string> { "10", "12", "30", "14", "18" };
        IsAdult(list, int.Parse, x => x >= 18, x => Console.WriteLine($"Совершеннолетний, возраст={x}"));
    }

    public static void IsAdult(List<string> ages, Func<string, int> func, Predicate<int> predicate, Action<int> action)
    {
        foreach (var age in ages)
        {
            var res = func(age);
            if (predicate(res))
                action(res);
        }
    }
}

public interface ICalc
{
    double Result { get; set; }
    void Sum(int x);
    void Sub(int x);
    void Multiply(int x);
    void Divide(int x);
    event EventHandler<EventArgs> MyEventHandler;
    void CancelLast();
}

internal class Calc : ICalc
{
    private Stack<double> LastResult { get; } = new();
    public double Result { get; set; } = 0D;

    public void Sum(int x)
    {
        Result += x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Sub(int x)
    {
        Result -= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Multiply(int x)
    {
        Result *= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Divide(int x)
    {
        Result /= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public event EventHandler<EventArgs>? MyEventHandler;

    public void CancelLast()
    {
        if (LastResult.TryPop(out var res))
        {
            Result = res;
            Console.WriteLine("Последнее действие отменено. Результат равен:");
            PrintResult();
        }
        else
        {
            Console.WriteLine("Не возможно отменить последнее действие.");
        }
    }

    private void PrintResult()
    {
        MyEventHandler?.Invoke(this, new EventArgs());
    }
}