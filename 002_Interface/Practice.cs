namespace _002_Interface;

public class Practice
{
    public static void Pr01()
    {
        IBits manipulator = new BitManipulator();

        int number = 5;  // 101 в двоичном представлении
        Console.WriteLine($"Исходное число: {number} (в двоичном: {Convert.ToString(number, 2)})");

        // Устанавливаем бит на позиции 1 в 1
        number = manipulator.SetBit(number, 1, true);
        Console.WriteLine($"После установки бита на позиции 1 в 1: {number} (в двоичном: {Convert.ToString(number, 2)})");

        // Получаем значение бита на позиции 1
        bool bitValue = manipulator.GetBit(number, 1);
        Console.WriteLine($"Значение бита на позиции 1: {bitValue}");


        int number1 = 10;  // 1010 в двоичном представлении
        Console.WriteLine($"Исходное число: {number1} (в двоичном: {Convert.ToString(number1, 2)})");

        // Устанавливаем бит на позиции 2 в 1
        number1 = manipulator.SetBit(number1, 2, true);
        Console.WriteLine($"После установки бита на позиции 2 в 1: {number1} (в двоичном: {Convert.ToString(number1, 2)})");

        // Получаем значение бита на позиции 2
        bool bitValue1 = manipulator.GetBit(number1, 1);
        Console.WriteLine($"Значение бита на позиции 2: {bitValue1}");
    }

    public static void Pr02()
    {
        long n1 = 42;
        int n2 = 42;
        byte n3 = 42;

        Console.WriteLine($"n1.Type={n1.GetType()}, n2.Type={n2.GetType()}, n3.Type={n3.GetType()}");

        Bits2 fromLong = n1;
        Bits2 fromInt = n2;
        Bits2 fromByte = n3;

        Console.WriteLine($"fromLong: {fromLong}");  
        Console.WriteLine($"fromInt: {fromInt}");    
        Console.WriteLine($"fromByte: {fromByte}");  
    }
}