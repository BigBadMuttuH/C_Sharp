using System.Globalization;

namespace Calculator;

public class CalculatorConsoleInterface
{
    private readonly Calculator _calculator;

    public CalculatorConsoleInterface()
    {
        _calculator = new Calculator();
        _calculator.MyEventHandler += CalculateEventHandler;
    }

    public void Run()
    {
        Console.WriteLine(
            "Добро пожаловать в калькулятор! Нажмите соответствующую клавишу для операции и введите число.");

        var running = true;
        while (running)
        {
            Console.Write("\n[+] Сложение [-] Вычитание [*] Умножение [/] Деление [Z] Отмена [Esc] Выход\n");

            var keyInfo = Console.ReadKey(true);
            var key = keyInfo.Key;
            Console.WriteLine($"Нажата клавиша: {keyInfo.KeyChar} (ConsoleKey.{key})");

            switch (key)
            {
                case ConsoleKey.Add:
                case ConsoleKey.OemPlus:
                    ExecuteOperation(_calculator.Sum);
                    break;
                case ConsoleKey.Subtract:
                case ConsoleKey.OemMinus:
                    ExecuteOperation(_calculator.Sub);
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.Oem8:
                case ConsoleKey.Multiply:
                    ExecuteOperation(_calculator.Multiply);
                    break;
                case ConsoleKey.Oem2:
                case ConsoleKey.Divide:
                    ExecuteOperation(_calculator.Divide);
                    break;
                case ConsoleKey.Z:
                    _calculator.CancelLast();
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
        }
    }

    private bool TryConvertToPositiveDouble(string input, out double result)
    {
        //поменяем току на запятую в дробных числа.
        input = input.Replace(',', '.');
        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
        {
            if (result < 0) throw new InvalidNumberException("Число не может быть отрицательным.");

            return true;
        }

        throw new InvalidNumberException("Введенное значение не является числом.");
    }

    private void ExecuteOperation(Action<double> operation)
    {
        Console.Write("\nВведите число: ");
        var input = Console.ReadLine();

        try
        {
            if (TryConvertToPositiveDouble(input, out var number))
                try
                {
                    operation(number);
                }
                catch (DivideByZeroCalculatorException e)
                {
                    Console.WriteLine(e);
                }
        }
        catch (InvalidNumberException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex);
        }
    }

    private static void CalculateEventHandler(object? sender, EventArgs e)
    {
        if (sender is Calculator calculator)
        {
            Console.Clear();
            Console.WriteLine($"\nИстория операций: {calculator.Expression}");
            Console.WriteLine($"Результат последней операции: {calculator.Result}");
        }
    }
}