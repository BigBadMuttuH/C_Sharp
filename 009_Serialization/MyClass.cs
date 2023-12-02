namespace _009_Serialization;

public class MyClass
{
    private readonly int _field1 = 10;
    private readonly int _field2 = 20;
    public int Field3 = 10;
    public int Field4 = 20;

    public MyClass()
    {
    }

    public MyClass(int x, char y)
    {
        Console.WriteLine($"x={x}, y={y}");
    }

    public override string ToString()
    {
        return $"_f1={_field1}, _f2={_field2}, f3={Field3}, f4={Field4}";
    }
}