namespace _002_Interface;

public class Fibonacci
{
    public int Value { get; private set; } = 1;
    private int valuePrev = 0;

    public static Fibonacci operator ++(Fibonacci f)
    {
        var temp = f.Value;
        f.Value = f.Value + f.valuePrev;
        f.valuePrev = temp;

        return f;
    }

    public static Fibonacci operator +(Fibonacci f, int count)
    {
        for (int i = 0; i < count; i++)
        {
            f++;
        }
        return f;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}