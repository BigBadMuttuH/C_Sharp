namespace _004_collections;

public static class Linq
{
    // LINQ - Language-Integrated Query - встроенный язык запросов
    public static void Ex01()
    {
        string[] names = { "Анна", "Алина", "Елена", "Алёна", "Екатерина" };

        // IEnumerable<string> namesA = from name in names
        //     where name.StartsWith('А')
        //     select name;

        // это можно переписать вот так:
        // IEnumerable<string> namesA = names.Where(x => x.StartsWith('А'));
        var namesA = names.Where(x => x.StartsWith('А')).Where(x => x[1] == 'л');

        // Важно!!!!!!!!
        names[1] = "Калина";
        // после такой модификации останется только Алёна
        foreach (var s in namesA) Console.WriteLine(s);
    }

    // Ling
    public static void Ex02()
    {
        string[] names = { "Анна", "Алина", "Елена", "Алёна", "Екатерина" };
        // анонимный объект
        var namesA = from name in names
            select
                new { Name = name, StartWithA = name.StartsWith('А') };

        foreach (var s in namesA)
            Console.WriteLine($"{s.Name} start with A {s.StartWithA}");
        // Анна start with A True
        // Алина start with A True     
        // Елена start with A False    
        // Алёна start with A True     
        // Екатерина start with A False
    }

    public static void Ex03()
    {
        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 2, 4 };
        // сортировка 
        var res1 = ints.OrderBy(x => x);
        foreach (var x in res1)
            Console.Write(x + ", ");
        Console.WriteLine();

        // отсортирован в обратном порядке
        var res2 = ints.OrderByDescending(x => x);
        foreach (var x in res2)
            Console.Write(x + ", ");
        Console.WriteLine();

        // Просто развернуть без сортировки
        var res22 = ints.Reverse();
        foreach (var x in res22)
            Console.Write(x + ", ");
        Console.WriteLine();

        // 
        var res3 = ints.Aggregate((m, i) => m * i);
        Console.WriteLine(res3);

        var res4 = ints.Aggregate((x, i) => 2 * i);
        Console.WriteLine(res4);

        // Позволяет задать предикат 
        // Все элементы больше 0?
        var res5 = ints.All(x => x > 0);
        Console.WriteLine(res5); // True

        var res6 = ints.Any(x => x == 0);
        Console.WriteLine(res6); // False

        // Без дубликатов
        var res7 = ints.Distinct();
        foreach (var x in res7)
            Console.Write(x + ", ");
        Console.WriteLine();

        // Исключить последовательность + получаются только уникальные значения
        var res8 = ints.Except(new[] { 1, 2, 3 });
        foreach (var x in res8)
            Console.Write(x + ", ");
        Console.WriteLine();


        var res9 = ints.Union(new[] { 10, 11, 12, 13, 14 });
        foreach (var x in res9)
            Console.Write(x + ", ");
        Console.WriteLine();

        var res10 = ints.Intersect(new[] { 9, 10, 11, 12, 13, 14 });
        foreach (var x in res10)
            Console.Write(x + ", "); // 9
        Console.WriteLine();

        // Количество
        var res11 = ints.Count(x => x % 2 == 0);
        Console.WriteLine(res11); // Количество всех четных чисел

        //
        // var res12 = ints.Sum();
        var res12 = ints.Max();
        // var res12 = ints.Min();
        Console.WriteLine(res12);

        // Взять несколько первых элементов коллекции
        var res13 = ints.Take(5);
        foreach (var x in res13)
            Console.Write(x + ", ");
        Console.WriteLine();

        var res14 = ints.Skip(5);
        foreach (var x in res14)
            Console.Write(x + ", ");
        Console.WriteLine();

        // var res15 = ints.TakeWhile(x => x < 5);
        var res15 = ints.SkipWhile(x => x < 5);
        foreach (var x in res15)
            Console.Write(x + ", ");
        Console.WriteLine();

        var lints = new List<int> { 1, 2, 3, 4, 5 };
        var chars = new List<char> { 'A', 'B', 'C', 'D' };

        var res16 = lints.Zip(chars, (i, c) => $"{i}={c}");
        foreach (var x in res16)
            Console.Write(x + ", ");
        Console.WriteLine();

        // var res17 = ints.First(x => x > 100); // тут будет ошибка
        // var res17 = ints.FirstOrDefault(x => x > 100, -1); // а тут будет -1
        // var res17 = ints.LastOrDefault(x => x > 100, -1);
        // var res17 = ints.ElementAt(4);
        var res17 = ints.ElementAtOrDefault(33); // 0
        Console.WriteLine(res17);

        var res18 = ints.Select(x => "(" + x + ")");
        // (-100), (2), (3), (4), (5), (6), (7), (8), (9), (9), (2), (4),
        ints[0] = -100;
        // var res18 = ints.Select(x => "(" + x.ToString() + ")").ToList();
        // Если преобразовать к листу, то все ок
        // (2), (3), (4), (5), (6), (7), (8), (9), (9), (2), (4),
        foreach (var x in res18)
            Console.Write(x + ", ");
        Console.WriteLine();
    }
}