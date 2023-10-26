using _001_CSharp_OOP;

namespace _002_Interface;

public class BabySitter : IBabySitter
{
    public void TakeCare()
    {
        Console.WriteLine("Сидит с детьми, пока родители на работе!");
    }
}