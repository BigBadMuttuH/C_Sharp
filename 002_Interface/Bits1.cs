namespace _002_Interface;

public class Bits1
{
    public byte Value { get; private set; }
    public Bits1(byte b) { Value = b; }
    public static implicit operator byte(Bits1 b) => b.Value;
    public static explicit operator Bits1(byte b) => new Bits1(b);
}