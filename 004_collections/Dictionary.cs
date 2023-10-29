using System.Collections;
using System.Text;

namespace _004_collections;

public static class Dictionary
{
    // Ex03
    private static readonly int[] buckets = new int[10];
    private static readonly DictionaryEntry[] entries = new DictionaryEntry[10];
    private static int c;

    // Ex01
    public static void Ex01()
    {
        var o = new object();
        var i = o.GetHashCode();

        Console.WriteLine(o.GetHashCode());
        Console.WriteLine(i.GetHashCode());
    }

    public static void Ex02()
    {
        var a = new SomeStruct { X = 10 };
        var b = new SomeStruct { X = 10 };
        Console.WriteLine(a.Equals(b)); // True

        var c = new SomeClass { X = 10 };
        var d = new SomeClass { X = 10 };
        Console.WriteLine(c.Equals(d)); // False
    }
    // Словарь основан на такой структуре данных, как хеш-таблица.
    // Корзины (Buckets):
    // Словарь содержит массив корзин (buckets).
    // Каждая корзина представляет собой индекс элемента (или записи) в массиве entries.
    // Элементы (Entries):
    // entries — это массив элементов (или записей), где каждый элемент имеет ключ и значение.

    private static void Add(object key, object value)
    {
        // Для того чтобы определить, в какую корзину положить элемент, мы используем хеш-код ключа.
        // key.GetHashCode() возвращает хеш-код ключа.
        // & (0x7fffffff % buckets.Length) гарантирует, что индекс корзины будет в пределах размера массива buckets
        // и не будет отрицательным.
        // 0x7fffffff — это максимальное 32-битное положительное целое число.
        var bucketNum = key.GetHashCode() & (0x7fffffff % buckets.Length);
        buckets[bucketNum] = c;
        entries[c].Value = value;
        c++;
        // Когда добавляем элемент, мы сначала вычисляем номер корзины с помощью хеш-кода ключа.
        // Затем мы сохраняем текущий индекс c (который представляет следующую доступную позицию в массиве entries) в эту корзину.
        // После этого сохраняем значение элемента в массив entries по индексу c и увеличиваем c.
    }

    private static object Get(object key)
    {
        // Чтобы получить значение по ключу, снова вычисляем номер корзины с помощью хеш-кода ключа.
        // Используем индекс из корзины, чтобы обратиться к массиву entries и получить значение.
        var bucketNum = key.GetHashCode() & (0x7fffffff % buckets.Length);
        return entries[buckets[bucketNum]].Value;
    }

    public static void Ex03()
    {
        Add(5, "Element5");
        Add(6, "Element6");

        Console.WriteLine(Get(5));
        Console.WriteLine(Get(6));
    }

    // Ex04
    public static void Ex04()
    {
        var d = new Dictionary<string, string>();
        d["Россия"] = "Москва";
        d["Беларусь"] = "Минск";
        d["США"] = "Вашингтон";

        foreach (var key in d)
            Console.WriteLine(key);

        foreach (var v in d.Values)
            Console.WriteLine(v);

        Console.WriteLine(d["Россия"]);
        Console.WriteLine(d["Беларусь"]);

        // var err = d["Казахстан"]; // туту будет ошибка
        d.Add("Казахстан", "Астана");
        // System.ArgumentException An item with the same key has already been added. Key: Россия 
        // d.Add("Россия", "Санкт-Петербург");
        if (!d.TryAdd("Россия", "Санкт-Петербург"))
            Console.WriteLine("Такой ключ уже имеется");

        Console.WriteLine(d.ContainsKey("Россия"));
        Console.WriteLine(d.ContainsValue("Москва"));

        Console.WriteLine();
        if (d.Remove("Россия", out var val)) // может возвращать true/false
            Console.WriteLine(val);

        d.Add("Россия", "Москва");
    }

    public static void Ex05()
    {
        var d = new Dictionary<string, int>();
        var text = "Я текст текст текст, подсчитай сколько у меня одинаковых слов слов";
        var sb = new StringBuilder();

        foreach (var c in text)
            if (char.IsLetter(c))
            {
                sb.Append(c);
            }
            else
            {
                if (sb.Length > 0)
                {
                    var key = sb.ToString().ToLower();

                    if (d.ContainsKey(key))
                        d[key]++;
                    else
                        d[key] = 1;

                    sb.Clear();
                }
            }

        if (sb.Length > 0)
        {
            var key = sb.ToString().ToLower();

            if (d.ContainsKey(key))
                d[key]++;
            else
                d[key] = 0;

            sb.Clear();
        }

        foreach (var e in d) Console.WriteLine($"{e.Key} = {e.Value}");
    }

    // Ex02
    private struct SomeStruct
    {
        public int X;
    }

    private class SomeClass
    {
        public int X;
    }
}