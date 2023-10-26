namespace _003_collections;

public class LinkedLists
{
    public static void Ex01()
    {
        var ints = new LinkedList<int>(new[] { 8, 2, 4, 5, 0, -1, 2 - 3, 1, 6 });

        Console.WriteLine(ints.First?.Value);
        Console.WriteLine(ints.Last?.Value);

        ints.AddAfter(ints.First, 99);
        ints.AddFirst(100);

        var node = ints.Last;
        while (node != null)
        {
            Console.Write(node.Value + " ");
            node = node.Previous;
            // node = node.Next;
        }

        Console.WriteLine();

        ints.Remove(99);
        ints.RemoveFirst();
        ints.RemoveLast();

        foreach (var i in ints) Console.Write(i + " ");
    }
}