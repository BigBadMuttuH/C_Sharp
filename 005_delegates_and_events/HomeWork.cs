namespace _005_delegates_and_events;

public class HomeWork
{
    public static void Hw01()
    {
        var calculator = new Calculator();
        calculator.MyEventHandler += DisplayResult;
        
        static void DisplayResult(object? sender, ResultEventArgs e)
        {
            Console.WriteLine($"Результат равен: {e.Result}");
        }

        static void DisplayCancelMessage(object sender, ResultEventArgs e)
        {
            Console.WriteLine("Последнее действие отменено.");
        }

        Console.WriteLine("Введите начальное значение:");
        calculator.Result = int.Parse(Console.ReadLine()!);

        while (true)
        {
            Console.WriteLine("Укажите операцию (+, -, *, /) и нажмите Enter, Backspace для отмены последнего действия, End - выход.");
            var key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.End)
            {
                break;
            }

            if (key != ConsoleKey.Backspace)
            {
                Console.WriteLine("Введите число и нажмите Enter:");
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
                    continue;
                }
                switch (key)
                {
                    case ConsoleKey.OemPlus:
                    case ConsoleKey.Add:
                        calculator.Sum(number);
                        break;
                    case ConsoleKey.OemMinus:
                    case ConsoleKey.Subtract:
                        calculator.Sub(number);
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.Oem8:
                    case ConsoleKey.Multiply:
                        calculator.Multiply(number);
                        break;
                    case ConsoleKey.Oem2:
                    case ConsoleKey.Divide:
                        calculator.Divide(number);
                        break;
                }
            }
            else
            {
                calculator.MyEventHandler += DisplayCancelMessage!;
                calculator.CancelLast();
                calculator.MyEventHandler -= DisplayCancelMessage!;
            }
        }
    }
}

public interface ICalculate
{
    double Result { get; set; }
    void Sum(int x);
    void Sub(int x);
    void Multiply(int x);
    void Divide(int x);
    void CancelLast();
    
    event EventHandler<ResultEventArgs> MyEventHandler;
}
public class ResultEventArgs : EventArgs
{
    public double Result { get; }

    public ResultEventArgs(double result)
    {
        Result = result;
    }
}

internal class Calculator : ICalculate
{
    private Stack<double> LastResult { get; } = new();
    public double Result { get; set; } = 0D;
    public event EventHandler<ResultEventArgs>? MyEventHandler;

    public void Sum(int x)
    {
        Result += x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Sub(int x)
    {
        Result -= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Multiply(int x)
    {
        Result *= x;
        PrintResult();
        LastResult.Push(Result);
    }

    public void Divide(int x)
    {
        if (x == 0)
        {
            Console.WriteLine("Ошибка: Деление на ноль невозможно.");
            return;
        }
        Result /= x;
        PrintResult();
        LastResult.Push(Result);
    }
    
    public void CancelLast()
    {
        if (LastResult.Count > 1)
        {
            LastResult.Pop(); // Удаляем последний результат
            Result = LastResult.Peek(); // Посмотреть предыдущий результат без удаления
            PrintResult();
        }
        else
        {
            Console.WriteLine("Не возможно отменить последнее действие.");
        }
    }

    private void PrintResult()
    {
        MyEventHandler?.Invoke(this, new ResultEventArgs(Result));
    }
}
