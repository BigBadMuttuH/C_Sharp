namespace Calculator;

public static class Program
{
    private static void Main(string[] args)
    {
        var calcInterface = new CalculatorConsoleInterface();
        calcInterface.Run();
    }
}