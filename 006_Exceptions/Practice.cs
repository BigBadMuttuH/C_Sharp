namespace _006_Exceptions;

public static class Practice
{
    private static bool MyTryParse(string str, out int num)
    {
        num = 0;
        try
        {
            num = Convert.ToInt32(str);
            if (num < 0)
            {
                throw new NegativeNumberException("Число не должно быть отрицательным.");
            }
        }
        catch (NegativeNumberException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (FormatException)
        {
            Console.WriteLine("Введено не число.");
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Непредвиденная ошибка: {e.Message}");
            return false;
        }

        return true;
    }

    public static void Pr01()
    {
        if (MyTryParse("10", out var x)) Console.WriteLine(x);
        if (MyTryParse("XX", out var y)) Console.WriteLine(y);
        if (MyTryParse("-5", out var z)) Console.WriteLine(z);
    }

    private static void ProcessNumber(int number)
    {
        if (number < 0)
            throw new NegativeNumberException($"Число {number} отрицательное.", new Exception("Внутренне исключение."));

        Console.WriteLine(number);
    }

    public static void Pr02()
    {
        try
        {
            ProcessNumber(10);
        }
        catch (NegativeNumberException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception)
        {
            throw new Exception();
        }

        Console.WriteLine();

        try
        {
            ProcessNumber(-10);
        }
        catch (NegativeNumberException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.ToString());
        }
        catch (Exception)
        {
            throw new Exception();
        }

        Console.WriteLine();

        try
        {
            ProcessNumber(-5);
        }
        catch (NegativeNumberException e)
        {
            Console.WriteLine(e);
            if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
        }
    }

    public static void Pr03()
    {
    }
}