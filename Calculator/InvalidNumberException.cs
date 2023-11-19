namespace Calculator;

public class InvalidNumberException : CalculatorException
{
    public InvalidNumberException()
    {
    }

    public InvalidNumberException(string message)
        : base(message)
    {
    }

    public InvalidNumberException(string message, Exception inner)
        : base(message, inner)
    {
    }
}