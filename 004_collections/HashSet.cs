namespace _004_collections;

public class HashSet
{
    // Множества часто используют в базах данных
    public static void Ex01()
    {
        var s1 = new HashSet();
        var s2 = new HashSet<int>(new[] { 1, 2, 3, 4, 5 });
        var s3 = new HashSet<int>(s2);

        Console.WriteLine(s2.Count);
        s2.Add(1);
        s2.Remove(1);
        s3.Add(99);
        s3.Add(100);

        // bool
        Console.WriteLine(s3.Remove(1));

        // Общие элементы, имеющиеся в обоих множествах
        s2.IntersectWith(s3);
        foreach (var x in s2) Console.Write(x + " ");
        Console.WriteLine();

        // Пересечения
        s2.Overlaps(s3);
        foreach (var x in s2) Console.Write(x + " ");
        Console.WriteLine();


        // Нет общих
        s2.SymmetricExceptWith(s3);
        foreach (var x in s2) Console.Write(x + " ");
        Console.WriteLine();

        // 
        s2.SetEquals(s3);
        foreach (var x in s2) Console.Write(x + " ");
        Console.WriteLine();
    }

    // Дан массив целых чисел, и искомое число
    // найдите сумму чисел равных искомому
    public static void Ex02()
    {
        int[] arr = { 1, 2, 3, 43, 5, 6, 7, 8, 9, 10, 11 }; // 50
        var target = 50;

        for (var i = 0; i < arr.Length - 1; i++)
        for (var j = i + 1; j < arr.Length; j++)
            if (arr[i] + arr[j] == target)
                Console.WriteLine($"{target} = {arr[i]} + {arr[j]}");
    }

    // O(n)
    public static void Ex03()
    {
        int[] arr = { 1, 2, 3, 43, 5, 6, 7, 8, 9, 10, 11 }; // 50
        var target = 50;

        var s = new HashSet<int>();
        foreach (var i in arr)
        {
            var x = target - i;
            if (s.Contains(x))
                Console.WriteLine($"{target} = {x} + {i}");
            else
                s.Add(i);
        }
    }
}