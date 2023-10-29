namespace _004_collections;

public static class Collections
{
    public static void PriorityQ()
    {
        var pq = new PriorityQueue<string, int>();
        pq.Enqueue("Элемент 1", 1);
        pq.Enqueue("Элемент 2", 2);
        pq.Enqueue("Элемент 3", 1);
        pq.Enqueue("Элемент 4", 4);
        pq.Enqueue("Элемент 5", 5);
        pq.Enqueue("Элемент 6", 6);
        pq.Enqueue("Элемент 7", 7);
        pq.Enqueue("Элемент 8", 0);
        pq.Enqueue("Элемент 9", 3);

        while (pq.Count > 0) Console.WriteLine(pq.Dequeue());
    }

    public static void SortedDictionary()
    {
        var sd = new SortedDictionary<string, int>();
        sd["2"] = 2;
        sd["1"] = 1;
        sd["0"] = 0;
        sd["3"] = 3;
        sd["9"] = 9;

        foreach (var i in sd) Console.Write(i + ";");

        Console.WriteLine();
    }

    public static void SortedSet()
    {
        var ss = new SortedSet<int>();
        ss.Add(9);
        ss.Add(0);
        ss.Add(1);
        ss.Add(5);
        ss.Add(3);

        foreach (var i in ss) Console.Write(i + ";");

        Console.WriteLine();
    }

    public static void ReadOnlyCollection()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var a = list;
        a[0] = 999;
        list.ForEach(Console.Write);

        Console.WriteLine();

        // ReadOnly
        var roList = new List<int> { 1, 2, 3, 4, 5 };
        var b = roList.AsReadOnly();
        // b[0] = 999; // так уже не получиться
        // И даже так, не испортить
        var bb = roList.ToList();
        bb[0] = 999;
        roList.ForEach(Console.Write);
    }
}