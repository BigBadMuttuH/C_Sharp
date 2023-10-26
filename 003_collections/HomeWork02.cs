namespace _003_collections;

public static class HomeWork02
{
    public static void Hw01()
    {
        // 1
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

        var exitsCount1 = HasExit(3, 0, labyrinth1);
        if (exitsCount1 > 0)
            Console.WriteLine($"Найдено выходов: {exitsCount1}");
        else
            Console.WriteLine("Выходов не найдено!");
        // Найдено выходов: 2


        // 2 
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

        var exitsCount2 = HasExit(3, 0, labyrinth2);
        if (exitsCount2 > 0)
            Console.WriteLine($"Найдено выходов: {exitsCount2}");
        else
            Console.WriteLine("Выходов не найдено!");
        // Выходов не найдено! Т.к. нет 2 в качестве маркеров выхода.
    }

    private static int HasExit(int startI, int startJ, int[,] l)
    {
        if (l[startI, startJ] == 1) return 0;

        var stack = new Stack<Tuple<int, int>>();
        var exitsCount = 0; // Счётчик для подсчета найденных выходов

        stack.Push(new Tuple<int, int>(startI, startJ));

        while (stack.Count > 0)
        {
            var temp = stack.Pop();

            if (l[temp.Item1, temp.Item2] == 2)
            {
                exitsCount++; // Если нашли выход, увеличиваем счётчик
                continue;
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

        return exitsCount;
    }
}