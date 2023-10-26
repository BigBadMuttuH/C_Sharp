namespace _002_Interface;

public class Bits1
{
    public Bits1(byte b)
    {
        Value = b;
    }

    public byte Value { get; }

    public static implicit operator byte(Bits1 b)
    {
        return b.Value;
    }

    public static explicit operator Bits1(byte b)
    {
        return new Bits1(b);
    }
}