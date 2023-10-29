namespace _004_collections;

public static class HomeWork
{
    public static void Hw01()
    {
        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        var tripleSum = 10;

        for (int i = 0; i < ints.Length - 2; i++)
        {
            int dupleSum = tripleSum - ints[i];
            var hash = new HashSet<int>();
            
            for(int j = i + 1; j < ints.Length; j++)
            {
                int x = dupleSum - ints[j];
                if (hash.Contains(x))
                    Console.WriteLine($"{tripleSum} = {ints[i]} + {ints[j]} + {x}");
                else
                    hash.Add(ints[j]);
            }
        }
    }
}