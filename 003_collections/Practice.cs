namespace _003_collections;

public class Practice
{
    public static void Pr01()
    {
        // Дан список целых чисел (числа не последовательны),
        // в котором некоторые числа повторяются.
        // Выведите список чисел на экран, исключив из него повторы.
        var ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };

        var uniqueItems = new List<int>();

        foreach (var i in ints)
            if (!uniqueItems.Contains(i))
            {
                uniqueItems.Add(i);
                Console.Write(i + " ");
            }
        // uniqueItems.ForEach(Console.Write);
        // Используем Linq, чтобы исключить повторяющиеся числа
        // List<int> uniqueInts = ints.Distinct().ToList();
    }

    public static void Pr02()
    {
        // Дан список целых чисел (числа не последовательны),
        // в котором некоторые числа повторяются.
        // Выведите список чисел на экран, расположив их в порядке возрастания частоты повторения
        var ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };

        var frequency = new Dictionary<int, int>();

        foreach (var key in ints)
            if (frequency.ContainsKey(key))
                frequency[key]++;
            else
                frequency.Add(key, 1);

        // var dict = frequency.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        var dict = frequency.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        foreach (var i in dict) Console.WriteLine(i);
    }

    public static void Pr03()
    {
        var ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };

        // Подсчитываем частоту каждого числа
        var frequency = new Dictionary<int, int>();
        foreach (var number in ints)
            if (frequency.ContainsKey(number))
                frequency[number]++;
            else
                frequency[number] = 1;

        // Сортируем числа по частоте
        var sortedByFrequency = frequency.OrderBy(x => x.Value).ThenBy(x => x.Key).ToList();

        // Выводим результат
        foreach (var item in sortedByFrequency) Console.WriteLine($"{item.Key} - {item.Value} раз");
    }

    public static void Pr04()
    {
        // Модифицируйте код предыдущей задачи таким образом чтобы вывод элементов был в порядке убывания частоты их повторения
        var ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };

        // Подсчитываем частоту каждого числа
        var frequency = new Dictionary<int, int>();
        foreach (var number in ints)
            if (frequency.ContainsKey(number))
                frequency[number]++;
            else
                frequency[number] = 1;

        // Сортируем числа по частоте
        var sortedByFrequency = frequency.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

        // Выводим результат
        foreach (var item in sortedByFrequency) Console.WriteLine($"{item.Key} - {item.Value} раз");
    }

    public static void Pr05()
    {
        // Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
        // Пример лабиринта:
        // 1 1 1 1 1 1 1
        // 1 0 0 0 0 0 1
        // 1 0 1 1 1 0 1
        // 0 0 0 0 1 0 2
        // 1 1 0 0 1 1 1
        // 1 1 1 1 1 1 1
        // 1 1 1 1 1 1 1
        // Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран координаты точки выхода если таковые имеются.

        int[,] labyrinth1 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 2 },
            { 1, 1, 0, 0, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };
        // static bool HasExit(int startI, int startJ, int[,] l)
        // startI,startJ это точка начала пути-откуда мы начинаем проходить лабиринт.
        // l - массив описывающий лабиринт.
        Console.WriteLine(HasExit(1, 3, labyrinth1));
        Console.WriteLine();


        int[,] labyrinth2 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 1, 0, 0, 1, 0, 2 },
            { 1, 1, 0, 0, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };
        Console.WriteLine(HasExit(3, 2, labyrinth2));
        Console.WriteLine();


        int[,] labyrinth3 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 1, 0, 0, 1, 0, 2 },
            { 1, 1, 0, 0, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };
        Console.WriteLine(HasExit(3, 2, labyrinth3));
        Console.WriteLine();
    }


    private static bool HasExit(int startI, int startJ, int[,] l)
    {
        if (l[startI, startJ] == 1) return false;
        if (l[startI, startJ] == 2) return true;

        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new Tuple<int, int>(startI, startJ));

        while (stack.Count > 0)
        {
            var temp = stack.Pop();

            if (l[temp.Item1, temp.Item2] == 2) return true;
            // чтобы больше не возвращаться записываем 1 
            l[temp.Item1, temp.Item2] = 1;

            // Верх 
            if (temp.Item2 >= 0 && l[temp.Item1, temp.Item2 - 1] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1, temp.Item2 - 1));

            // Низ 
            if (temp.Item2 + 1 < l.GetLength(1) && l[temp.Item1, temp.Item2 + 1] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1, temp.Item2 + 1));

            // Лево 
            if (temp.Item1 >= 0 && l[temp.Item1 - 1, temp.Item2] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1 - 1, temp.Item2));

            // Право 
            if (temp.Item1 + 1 < l.GetLength(0) && l[temp.Item1 + 1, temp.Item2] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1 + 1, temp.Item2));

            // Для понимания, что на каждом шаге в стеке
            // foreach (var item in stack) Console.Write($"({item.Item1}, {item.Item2})");
            // Console.WriteLine();
        }

        return false;
    }
}