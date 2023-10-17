namespace _001_CSharp_OOP;

public interface IFamily
{
    Person this[int index] { get; }

    int Count { get; }
}