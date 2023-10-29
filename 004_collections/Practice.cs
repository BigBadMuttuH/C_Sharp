namespace _004_collections;

// как работает LINQ из под капота к Pr01
public static class EnumerableExtensions
{
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> values, Func<T, bool> predicate)
    {
        foreach (var value in values)
            if (predicate(value))
                yield return value;
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Faculty { get; set; }

    public override string ToString()
    {
        return $"Name={Name}, Age={Age}, Faculty={Faculty}";
    }
}

internal class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }

    public override string ToString()
    {
        return $"{OrderID}, {CustomerName}, {OrderDate}, {TotalAmount}";
    }
}

public static class Practice
{
    public static void Pr01()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        var numbers2 = numbers.MyWhere(x => x > 3);
        // Если не использовать this в 17 строке, то 8 строка выглядела бы так
        // var numbers2 = EnumerableExtensions.MyWhere(numbers, x => x > 3);
        foreach (var n in numbers2) Console.Write(n + " ");
    }

    public static void Pr02()
    {
        /*
        Задача 1: Фильтрация и проекция данных с использованием LINQ
        Предоставьте студентам некоторую коллекцию объектов (например, список студентов)
        и попросите их решить следующие задачи:

        Найти всех студентов, чей возраст меньше 25 лет.
        Вывести имена всех студентов в алфавитном порядке.
        Выбрать студентов, обучающихся на факультете инженерии.
        Посчитать средний возраст студентов.
        Попросите студентов использовать LINQ для решения этих задач.
        */
        var students = new List<Student>
        {
            new() { Name = "Alice", Age = 22, Faculty = "Engineering" },
            new() { Name = "Bob", Age = 25, Faculty = "Science" },
            new() { Name = "Charlie", Age = 19, Faculty = "Engineering" },
            new() { Name = "David", Age = 30, Faculty = "Arts" },
            new() { Name = "Eve", Age = 21, Faculty = "Science" }
            // Добавьте других студентов по вашему усмотрению
        };
        var s1 = students.Where(x => x.Age < 25);
        s1.ToList().ForEach(Console.WriteLine);
        var s2 = students.OrderBy(x => x.Name).Select(x => x.Name);
        s2.ToList().ForEach(Console.WriteLine);
        var s3 = students.Where(x => x.Faculty.Equals("Engineering"));
        s3.ToList().ForEach(x => Console.WriteLine($"Name:{x.Name}, {x.Faculty}"));
        var s4 = students.Average(x => x.Age);
        Console.WriteLine(s4);
    }

    public static void Pr03()
    {
        // Отсортировать заказы по сумме в убывающем порядке.
        // Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
        // Найти клиента с наибольшей суммой заказов.
        // Вывести список клиентов и общую сумму их заказов.
        // Попросите студентов использовать LINQ для сортировки и группировки данных.
        var orders = new List<Order>
        {
            new() { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
            new() { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
            new() { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
            new() { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
            new() { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 7, 3), TotalAmount = 140.0 },
            new() { OrderID = 5, CustomerName = "Eve", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 }
            // Добавьте другие заказы по вашему усмотрению
        };

        var o1 = orders.OrderByDescending(x => x.TotalAmount);
        o1.ToList().ForEach(Console.WriteLine);

        var o2 = orders.GroupBy(x => x.CustomerName)
            .Select(x => new { name = x.Key, count = x.Count() });
        o2.ToList().ForEach(x => Console.WriteLine($"{x.name}, - {x.count}"));

        var o3 = orders.GroupBy(x => x.CustomerName)
            .Select(x => new { name = x.Key, sum = x.Sum(m => m.TotalAmount) })
            .MaxBy(m => m.sum);
        Console.WriteLine(o3);

        var o4 = orders.GroupBy(x => x.CustomerName)
            .Select(x => new { name = x.Key, sum = x.Sum(m => m.TotalAmount) })
            .OrderByDescending(m => m.sum);
        o4.ToList().ForEach(Console.WriteLine);
    }
}