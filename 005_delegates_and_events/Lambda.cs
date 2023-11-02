namespace _005_delegates_and_events;

public class Lambda
{
    private static bool IsEvent(int x)
    {
        return x % 2 == 0;
    }

    public static void Ex01()
    {
        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Вариант первый
        // через метод
        var res = ints.Where(IsEvent);
        res.ToList().ForEach(i => Console.Write($"{i}, "));
        Console.WriteLine("\n---");

        // Вариант через лямбду
        // Func<int, bool> f = x => x % 2 == 0;
        var f = delegate(int x) { return x % 2 == 0; };
        var r2 = ints.Where(f);
        r2.ToList().ForEach(i => Console.Write($"{i}, "));
        Console.WriteLine("\n---");

        // Вариант третий, еще короче
        var r3 = ints.Where(delegate(int x) { return x % 2 == 0; });
    }

    // "захват переменных" или "closure"
    private static void AnotherMethod(Action method)
    {
        method();
    }

    public static void Ex02()
    {
        var counter = 0;

        var method = delegate()
        {
            Console.WriteLine($"Значение counter = {counter}");
            counter++;
        };

        method();
        method();
        method();

        counter = -1;

        // Происходит копирование переменных
        AnotherMethod(method);
    }

    public static void Ex03()
    {
        var actions = new List<Action>();
        for (var i = 0; i <= 10; i++)
            actions.Add(
                delegate { Console.WriteLine($"Значение счетчика = {i}"); });

        foreach (var action in actions)
            action.Invoke();
    }
    // В выводе будет такая дичь 
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11
    // Значение счетчика = 11

    /*
    Цикл for: Когда ты запускаешь цикл for, переменная i создается один раз для всего цикла, а не для каждой итерации.
    
    Делегат: Внутри цикла ты создаешь анонимный метод (делегат), который выводит значение i.
    Но важно понимать, что этот анонимный метод не "копирует" текущее значение i в момент создания.
    Вместо этого он "захватывает" ссылку на переменную i.
    
    Добавление в список: Ты добавляешь этот анонимный метод в список actions.
    Но все делегаты в этом списке "смотрят" на одну и ту же переменную i.
    
    Завершение цикла: Когда цикл for завершается, значение i становится 11 (потому что это условие выхода из цикла: i<=10).
    
    Invoke: Позже, когда ты вызываешь action.Invoke(),
    все делегаты в списке actions выводят значение одной и той же переменной i, которая теперь равна 11.
    
    чтобы это исправить надо создать локальную переменную
    вот так:
    for (int i = 0; i <= 10; i++)
    {
        int localI = i;
        actions.Add(
            delegate
            {
                Console.WriteLine($"Значение счетчика = {localI}");
            });
    }
    */

    // Снова о захвате переменных в LINQ
    public static void Ex04()
    {
        int i = 10;
        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var filtred = ints.Where(delegate(int x) { return x < i; });

        i = 5;
        
        foreach (var x in filtred)
        {
            Console.Write(x + " ");
        }
        // 1 2 3 4
    }

    public static void Ex05()
    {
        var func = (int x) => x * 2;
        
        var action = () => Console.WriteLine("Привет!");
        action();
        
        
        List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        foreach (var i in ints.Where(x => x % 2 == 0))
            Console.Write($"{i} ");
    }

    static void SayHello(string name) => Console.WriteLine($"Привет, {name}!");

    public static void Ex06()
    {
        Action<string> action = SayHello;

        // Если не используем параметр, строчку ниже, лучше переписать с `_`. Это сэкономит немножко памяти
        // action += (string x) => { Console.WriteLine("Привет, у меня нет имени!"); };
        action += (_) => { Console.WriteLine("Привет, у меня нет имени!"); };
        
        action("Василий");
        
        // с 10 версии C# можно так
        var a = object () => { return "Строка"; };
        // тут a станет Func<object>
    }
}