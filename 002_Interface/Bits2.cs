namespace _002_Interface;

public class Bits2
{
    private readonly long _value;

    public Bits2(long value)
    {
        _value = value;
    }

    public static implicit operator Bits2(long value)
    {
        return new Bits2(value);
    }

    public static implicit operator Bits2(int value)
    {
        return new Bits2(value);
    }

    public static implicit operator Bits2(byte value)
    {
        return new Bits2(value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}