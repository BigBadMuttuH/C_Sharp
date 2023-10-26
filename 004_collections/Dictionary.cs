using System.Collections;

namespace _004_collections;

public static class Dictionary
{

    // Ex01
    public static void Ex01()
    {
        var o = new object();
        var i = o.GetHashCode();

        Console.WriteLine(o.GetHashCode());
        Console.WriteLine(i.GetHashCode());
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
    public static void Ex02()
    {
        var a = new SomeStruct { X = 10 };
        var b = new SomeStruct { X = 10 };
        Console.WriteLine(a.Equals(b)); // True

        var c = new SomeClass { X = 10 };
        var d = new SomeClass { X = 10 };
        Console.WriteLine(c.Equals(d)); // False
    }

    // Ex03
    static readonly int[] buckets = new int[10];
    static DictionaryEntry[] entries = new DictionaryEntry[10];
    static int c = 0;
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
        int bucketNum = key.GetHashCode() & (0x7fffffff % buckets.Length);
        buckets[bucketNum] = c;
        entries[c].Value = value;
        c++;
        // Когда добавляем элемент, мы сначала вычисляем номер корзины с помощью хеш-кода ключа.
        // Затем мы сохраняем текущий индекс c (который представляет следующую доступную позицию в массиве entries) в эту корзину.
        // После этого сохраняем значение элемента в массив entries по индексу c и увеличиваем c.
    }

    static object Get(object key)
    {
        // Чтобы получить значение по ключу, снова вычисляем номер корзины с помощью хеш-кода ключа.
        // Используем индекс из корзины, чтобы обратиться к массиву entries и получить значение.
        int bucketNum = key.GetHashCode() & (0x7fffffff % buckets.Length);
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
    } 
}