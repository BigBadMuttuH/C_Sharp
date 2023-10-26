using System.Collections;

namespace _003_collections;

public class Lists
{
    public static void Ex01()
    {
        var list = new ArrayList();
        list.Add("One");
        list.Add(2);
        list.Add(3.8);
        var element = (int)list[1];
        Console.WriteLine(element);
        element = (int)list[0];
        Console.WriteLine(element);

        /* Получим:
        2
        Unhandled exception. System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Int32'.

        2 - это мы смогли получить первый элемент
        а вот с нулевым элементом не получилось.
        тут у нас не строгая типизация элементов.
        */
    }

    public static void PrintBitArray(BitArray bits)
    {
        foreach (bool b in bits) Console.Write($"{b}\t");

        Console.WriteLine();
    }

    public static void Ex02()
    {
        var bits = new BitArray(8, false);
        PrintBitArray(bits);

        bits.Or(new BitArray(new[] { true, false, false, false, true, false, false, false }));
        PrintBitArray(bits);

        bits.Xor(new BitArray(new[] { true, false, false, false, false, false, false, false }));
        PrintBitArray(bits);

        bits.And(new BitArray(new[] { true, false, false, true, false, true, false, false }));
        PrintBitArray(bits);
    }

    public static void Ex03()
    {
        var list = new ArrayList { 1, 2, 3, 4, 5, 6 };
        var enumerator = list.GetEnumerator();
        // чтобы получить хотя бы один элемент коллекции нужно вызвать хоть один раз MoveNext
        while (enumerator.MoveNext()) Console.Write(enumerator.Current);
    }

    public static void Ex04()
    {
        IComparer<int> comparer = new CustomIntComparer();
        var arr = new[] { 0, 9, 9, 7, 1, 2, 3, 4, 5, 3, 6, 7, 1 };
        Array.Sort(arr, comparer);
        foreach (var i in arr) Console.Write($"{i} ");

        Console.WriteLine("\nБез компаратора:");
        // без нашего компаратора
        Array.Sort(arr);
        foreach (var i in arr) Console.Write($"{i} ");
    }

    public static void Ex05()
    {
        var l1 = new List<int>();
        var l2 = new List<int>(new[] { 1, 2, 3, 4 });
        // лучше создавать сразу нужной длины
        var l3 = new List<int>(10);

        Console.WriteLine(l1.Capacity); // 0
        Console.WriteLine(l2.Capacity); // 4
        Console.WriteLine(l3.Capacity); // 10

        for (var i = 0; i < 20; i++)
        {
            Console.WriteLine($"Capacity={l1.Capacity}");
            Console.WriteLine($"Count={l1.Count}");
            l1.Add(i);
        }

        // добавить сразу несколько элементов
        l3.AddRange(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });

        // Важно!!! массив должен быть отсортирован
        Console.WriteLine(l3.BinarySearch(7));

        // очищает список не изменяя его Capacity
        l1.Clear();
        Console.WriteLine(l1.Capacity + ", " + l1.Count);

        // содержит => bool
        Console.WriteLine(l3.Contains(2));
        Console.WriteLine(l3.Contains(9));

        // cконвертировали список из int в string
        var strings = l3.ConvertAll(Convert.ToString);

        // CopyTo
        // массив должен быть создан заранее
        var arr = new int[l3.Count + 2];
        // скопируем элементы одно массива в другой
        l3.CopyTo(3, arr, 2, 4);
        foreach (var i in arr) Console.Write(i + " ");

        // EnsureCapacity
        var ints = new List<int>
            { 1, 2, 3, 4, 5, 6, 7, 9, 1, 2, 3, 4, 5, 6, 7, 9, 1, 2, 3, 4, 5, 6, 7, 9, 1, 2, 3, 4, 5, 6, 7, 9 };

        var x = new List<int>();
        Console.WriteLine("\n" + x.Capacity);
        x.EnsureCapacity(ints.Count);
        Console.WriteLine(x.Capacity);

        // 
        var sx = new List<string> { "AaAaA", "AAAAA", "aaaa", "BBBB" };
        var x1 = sx.Find(IsCapital);
        Console.WriteLine(x1);

        var x2 = sx.FindLast(IsCapital);
        Console.WriteLine(x2);

        var x3 = sx.FindAll(IsCapital);
        foreach (var el in x3)
            Console.Write(el + " ");

        var x4 = sx.FindIndex(2, IsCapital);
        Console.WriteLine("\n" + x4);

        // все индексы
        Console.WriteLine();
        var x5 = sx.FindIndex(IsCapital); // находим первый индекс
        if (x5 >= 0)
        {
            Console.WriteLine(x5);
            x5++;
        }

        while (x5 >= 0 && x5 < sx.Count)
        {
            x5 = sx.FindIndex(x5, IsCapital);
            if (x5 >= 0)
            {
                Console.WriteLine(x5);
                x5++;
            }
        }

        Console.WriteLine(x5);

        // Foreach для списка
        sx.ForEach(Console.WriteLine);

        // IndexOF
        Console.WriteLine(sx.IndexOf("BBBB"));

        // Insert
        sx.Insert(1, "XXXXX");
        sx.ForEach(Console.Write);
        Console.WriteLine();

        // InsertRange
        sx.InsertRange(2, new[] { "111", "222", "333" });
        sx.ForEach(Console.Write);
        Console.WriteLine();

        // Remove
        Console.WriteLine(sx.Remove("111"));
        sx.ForEach(Console.Write);

        // RemoveAt
        // RemoveRange

        // RemoveAll может принимать предикат
        Console.WriteLine();
        sx.RemoveAll(IsCapital);
        sx.ForEach(Console.Write);

        // Revers
        Console.WriteLine();
        sx.Reverse(0, 2);
        sx.ForEach(Console.Write);

        // Sort TODO: 1:25:41
        Console.WriteLine();
        ints.Sort(CompareInt);
        // ints.Revers - можно и так, но будет не эффективно
        ints.ForEach(Console.Write);

        // TrueForAll - 
        var res1 = ints.TrueForAll(Positive);
        Console.WriteLine("\n" + res1);
        ints.InsertRange(3, new[] { -1, -2, -3, -4 });
        var res2 = ints.TrueForAll(Positive);
        Console.WriteLine(res2);

        // при создании списка _version = 0
        // при несовпадении версий, будет исключение.
        // foreach (var i in ints)
        // {
        //     Console.WriteLine(i);
        //     ints.Clear();
        // }
    }

    // Предикат
    private static bool IsCapital(string s)
    {
        foreach (var c in s)
            if (!char.IsUpper(c))
                return false;

        return true;
    }

    // Делегат компаратор
    public static int CompareInt(int x, int y)
    {
        return x.CompareTo(y) * -1; // поменяем порядок сортировки
    }

    private static bool Positive(int y)
    {
        return y >= 0;
    }
}

public class CustomIntComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if ((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 0)) return x.CompareTo(y);

        if (x % 2 == 1)
            return 1;
        return -1;
    }
}