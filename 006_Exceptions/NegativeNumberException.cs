namespace _006_Exceptions;

public class NegativeNumberException : Exception
{
    //Создайте класс исключение,
    //который будет использоваться при попытке выполнения операции,
    //не поддерживающий отрицательные числа.

    public NegativeNumberException()
    {
    }

    public NegativeNumberException(string message) : base(message)
    {
    }

    public NegativeNumberException(string message, Exception e) : base(message, e)
    {
    }
}