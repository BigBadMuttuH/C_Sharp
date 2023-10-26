namespace _002_Interface;

public class Fibonacci
{
    private int valuePrev;
    public int Value { get; private set; } = 1;

    public static Fibonacci operator ++(Fibonacci f)
    {
        var temp = f.Value;
        f.Value = f.Value + f.valuePrev;
        f.valuePrev = temp;

        return f;
    }

    public static Fibonacci operator +(Fibonacci f, int count)
    {
        for (var i = 0; i < count; i++) f++;
        return f;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}