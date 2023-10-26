namespace _003_collections;

public class Queue
{
    public static void Ex01()
    {
        var q = new Queue<int>(new[] { 9, 3, 5, -3, 4, 2, -1, 1 });
        Console.WriteLine(q.Count);

        // Enqueue -  добавляет элемент
        q.Enqueue(99);
        q.Enqueue(100);
        Console.WriteLine(q.Count);

        var elements = q.Dequeue();
        Console.WriteLine(elements);
        while (q.Count > 0)
        {
            var el = q.Dequeue();
            Console.Write(el + " ");
        }
    }

    public static void Ex02()
    {
        var q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);
        q.Enqueue(6);

        Console.WriteLine("c 1 по 4:");
        while (q.Count > 0 && q.Peek() < 4)
        {
            var el = q.Dequeue();
            Console.Write(el + " ");
        }

        Console.WriteLine("остальные");
        while (q.Count > 0)
        {
            var el = q.Dequeue();
            Console.Write(el + " ");
        }

        Console.WriteLine();
        while (q.TryDequeue(out var x)) Console.Write(x + " ");
    }

    public static void Ex03()
    {
        var q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);
        q.Enqueue(6);

        Console.WriteLine();
        while (q.TryDequeue(out var x)) Console.Write(x + " ");
    }

    public static void Ex04()
    {
        var q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);
        q.Enqueue(6);

        while (q.Count > 0)
            if (Process(q.Peek()))
                q.Dequeue();
            else
                AlternativeProcess(q.Dequeue());
    }

    private static bool Process(int x)
    {
        if (x % 2 == 0)
        {
            Console.WriteLine($"Обработан {x}");
            return true;
        }

        return false;
    }

    public static void AlternativeProcess(int x)
    {
        Console.WriteLine($"Не могу обработать элемент {x}");
    }

    public static void Ex05()
    {
        // выполняется одновременно с получением DataSource из-за оператора yield
        // foreach (var x in DataSource()) Console.WriteLine(x);

        var q = new Queue<int>();
        foreach (var x in DataSource())
        {
            q.Enqueue(x);
            if (q.Count > 5) Console.WriteLine(q.Dequeue());
        }
    }

    private static IEnumerable<int> DataSource()
    {
        for (var i = 0; i < 30; i++)
            if (i < 25)
                yield return i;
            else
                yield return i * i * i;

        Console.WriteLine("Завершен!");
    }
}