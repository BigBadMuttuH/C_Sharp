namespace _003_collections;

public static class HomeWork01
{
    public static void Hw01()
    {
        int[,] labyrinth1 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 2 },
            { 1, 1, 0, 0, 1, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 1 },
            { 1, 1, 1, 2, 1, 1, 1 }
        };
        var exits1 = FindExits(1, 3, labyrinth1);
        Console.WriteLine($"Количество выходов: {exits1.Count}");
        foreach (var exit in exits1) Console.WriteLine($"Выход находится на позиции ({exit.Item1}, {exit.Item2})");
        // Количество выходов: 2
        // Выход находится на позиции (3, 6)
        // Выход находится на позиции (6, 3)


        int[,] labyrinth2 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 0 },
            { 1, 1, 0, 0, 1, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 1 }
        };
        var exits2 = FindExits(1, 3, labyrinth2);
        Console.WriteLine($"Количество выходов: {exits2.Count}");
        foreach (var exit in exits2) Console.WriteLine($"Выход находится на позиции ({exit.Item1}, {exit.Item2})");
        // Количество выходов: 0
    }

    private static List<Tuple<int, int>> FindExits(int startI, int startJ, int[,] l)
    {
        if (l[startI, startJ] == 1) return new List<Tuple<int, int>>(); // Если старт в стене - возвращаем пустой список

        var stack = new Stack<Tuple<int, int>>();
        var exits = new List<Tuple<int, int>>(); // Список для хранения координат выходов

        stack.Push(new Tuple<int, int>(startI, startJ));

        while (stack.Count > 0)
        {
            var temp = stack.Pop();

            if (l[temp.Item1, temp.Item2] == 2)
            {
                exits.Add(temp); // Если нашли выход, добавляем его координаты в список
                continue; // и продолжаем поиск
            }

            // чтобы больше не возвращаться записываем 1 
            l[temp.Item1, temp.Item2] = 1;

            // Верх 
            if (temp.Item2 > 0 && l[temp.Item1, temp.Item2 - 1] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1, temp.Item2 - 1));

            // Низ 
            if (temp.Item2 + 1 < l.GetLength(1) && l[temp.Item1, temp.Item2 + 1] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1, temp.Item2 + 1));

            // Лево 
            if (temp.Item1 > 0 && l[temp.Item1 - 1, temp.Item2] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1 - 1, temp.Item2));

            // Право 
            if (temp.Item1 + 1 < l.GetLength(0) && l[temp.Item1 + 1, temp.Item2] != 1)
                stack.Push(new Tuple<int, int>(temp.Item1 + 1, temp.Item2));
        }

        return exits;
    }
}