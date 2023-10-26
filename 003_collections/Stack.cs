namespace _003_collections;

public class Stack
{
    public static void Ex01()
    {
        var s = new Stack<int>(new[] { 1, 2, 3, 4, 5, 6 });
        var q = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 });

        Console.WriteLine(s.Peek());
        Console.WriteLine(q.Peek());
    }

    public static void Ex02()
    {
        var s = new Stack<int>();
        s.Push(1);
        s.Push(2);
        s.Push(3);

        while (s.TryPop(out var x)) Console.WriteLine(x);
    }

    public static void Ex03()
    {
        var brackets1 = "(){}[]((()))[[]{}]"; // True
        Console.WriteLine(ValidPersistent(brackets1));
        var brackets2 = "(){}[]((()))))[[]{}]"; // False
        Console.WriteLine(ValidPersistent(brackets2));
    }

    private static bool ValidPersistent(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '[') stack.Push(']');
            if (c == '(') stack.Push(')');
            if (c == '{') stack.Push('}');
            if ("])}".Contains(c))
            {
                if (stack.Count == 0) return false;
                if (stack.Pop() != c) return false;
            }
        }

        return stack.Count == 0;
    }
}