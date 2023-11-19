namespace Calculator;

public class DivideByZeroCalculatorException : CalculatorException
{
    public DivideByZeroCalculatorException()
        : base("Деление на ноль не возможно.")
    {
    }
}