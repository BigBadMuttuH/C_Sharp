namespace Calculator;

internal class Calculator : ICalculate
{
    private Stack<double> LastResult { get; } = new();
    private Stack<string> LastExpression { get; } = new();
    public string Expression { get; private set; } = "";
    public double Result { get; set; }

    public event EventHandler<EventArgs>? MyEventHandler;

    public void Sum(double x)
    {
        UpdateExpression("+", x);
        Result += x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Sub(double x)
    {
        UpdateExpression("-", x);
        Result -= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Multiply(double x)
    {
        UpdateExpression("*", x);
        Result *= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Divide(double x)
    {
        if (x == 0) throw new DivideByZeroCalculatorException();

        UpdateExpression("/", x);
        Result /= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void CancelLast()
    {
        if (LastResult.Count > 1)
        {
            LastResult.Pop();
            LastExpression.Pop();
            Result = LastResult.Peek();
            Expression = LastExpression.Peek();
            PrintExpression();
            PrintResult();
        }
        else
        {
            Console.WriteLine("Не возможно отменить последнее действие.");
        }
    }

    private void UpdateExpression(string operation, double value)
    {
        if (string.IsNullOrEmpty(Expression)) Expression = $"{Result}";

        Expression += $"{Result} {operation} {value}; ";
        LastExpression.Push(Expression);
    }

    private void PrintResult()
    {
        MyEventHandler?.Invoke(this, new EventArgs());
    }

    private void PrintExpression()
    {
        MyEventHandler?.Invoke(this, new EventArgs());
    }
}