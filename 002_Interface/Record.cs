namespace _002_Interface;

public record Record(int a)
{
    public int b { get; set; } = 0;
    public int c { get; init; }
}

public class ReferenceRecord
{
    public int b { get; set; } = 0;
}

public struct ValueRecord()
{
    public int b { get; set; } = 0;
}