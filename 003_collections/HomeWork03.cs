namespace _003_collections;

public class HomeWork03
{
    public static void Hw01()
    {
        int[,] labyrinth1 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 0 },
            { 1, 1, 0, 0, 1, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 1 }
        };

        var exitsCount1 = HasExit(3, 0, labyrinth1);
        if (exitsCount1 > 0)
            Console.WriteLine($"Найдено выходов: {exitsCount1}");
        else
            Console.WriteLine("Выходов не найдено!");
        // Найдено выходов: 3
    }

    private static int HasExit(int startI, int startJ, int[,] l)
    {
        if (l[startI, startJ] == 1) return 0;

        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new Tuple<int, int>(startI, startJ));

        var exitsCount = 0;

        while (stack.Count > 0)
        {
            var temp = stack.Pop();

            // если текущая позиция находится на границе массива и это 0, то увеличиваем счетчик выходов
            if ((temp.Item1 == 0 || // Проверяем, находиться ли текущая ячейка на верхней границе
                 temp.Item1 == l.GetLength(0) - 1 || // Проверяем не находиться ли на нижней границе
                 temp.Item2 == 0 || // левая граница лабиринта  
                 temp.Item2 == l.GetLength(1) - 1) && // правая граница лабиринта
                l[temp.Item1, temp.Item2] == 0) // Собственно 0
                exitsCount++;

            l[temp.Item1, temp.Item2] = 1; // помечаем посещенную позицию

            // Проверяем все направления
            // Верх 
            if (temp.Item2 > 0 && l[temp.Item1, temp.Item2 - 1] == 0)
                stack.Push(new Tuple<int, int>(temp.Item1, temp.Item2 - 1));

            // Низ 
            if (temp.Item2 + 1 < l.GetLength(1) && l[temp.Item1, temp.Item2 + 1] == 0)
                stack.Push(new Tuple<int, int>(temp.Item1, temp.Item2 + 1));

            // Лево 
            if (temp.Item1 > 0 && l[temp.Item1 - 1, temp.Item2] == 0)
                stack.Push(new Tuple<int, int>(temp.Item1 - 1, temp.Item2));

            // Право 
            if (temp.Item1 + 1 < l.GetLength(0) && l[temp.Item1 + 1, temp.Item2] == 0)
                stack.Push(new Tuple<int, int>(temp.Item1 + 1, temp.Item2));
        }

        return exitsCount;
    }
}