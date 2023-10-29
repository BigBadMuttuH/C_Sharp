namespace _004_collections;

public class PriorityQueue
{
    public static void Ex01()
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

        while (pq.Count > 0)
        {
            Console.WriteLine(pq.Dequeue());
        }
    }
}