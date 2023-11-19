using System.Runtime.ExceptionServices;

namespace _006_Exceptions;

public class Lecture
{
    private static int DivideTowNumbers(int n1, int n2)
    {
        // return n1 / n2; //Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
        try
        {
            return n1 / n2;
        }
        catch
        {
            // Не надо перехватывать исключения, если не собираетесь обрабатывать их должным образом
            Console.WriteLine("Произошла ошибка");
            return default;
        }
    }

    private static bool TryDivideTowNumbers(int n1, int n2, out int res)
    {
        try
        {
            res = n1 / n2;
            return true;
        }
        catch
        {
            Console.WriteLine("Произошла ошибка!");
            res = default;
            return false;
        }
    }

    public static void Ex01()
    {
        var res = DivideTowNumbers(1, 0);
        Console.WriteLine(res);
    }

    public static void Ex02()
    {
        if (TryDivideTowNumbers(1, 0, out var res))
            Console.WriteLine(res);
        else
            Console.WriteLine("Произошла ошибка выполнения метода");
    }

    private static int[] DivideTwoArrays(int[] arr1, int[] arr2)
    {
        var res = new int [arr1.Length];
        for (var i = 0; i < arr1.Length; i++) res[i] = arr1[i] / arr2[i];

        return res;
    }

    private static void RunDivideTwoArrays(int[] arr1, int[] arr2)
    {
        try
        {
            Console.Write("RunDivideTwoArrays: ");
            var arr3 = DivideTwoArrays(arr1, arr2);
            arr3.ToList().ForEach(x => Console.Write($"{x}; "));
            Console.WriteLine();
        }
        // catch (Exception e)
        // {
        //     // Console.WriteLine("При работе произошла ошибка:" + e.Message);
        //     // Так можно, но не очень правильно, не нужно замалчивать ошибки
        //     if (e is ArithmeticException)
        //     {
        //         Console.WriteLine("Возникла арифметическая ошибка");
        //     }
        //     
        //     if (e is DivideByZeroException)
        //     {
        //         Console.WriteLine("Ошибка деления на 0");
        //     }
        //     
        //     if (e is IndexOutOfRangeException)
        //     {
        //         Console.WriteLine("Ошибка выхода индекса за границы массива");
        //     }
        //     
        //     if (e is NullReferenceException)
        //     {
        //         Console.WriteLine("Один из массивов переданных в метод = null");
        //     }
        // }

        // Уже лучше, но теперь попробуем через when 
        // catch (DivideByZeroException)
        // {
        //     Console.WriteLine("Деление на 0");
        // }
        // catch (ArithmeticException)
        // {
        //     Console.WriteLine("Возникла арифметическая ошибка");
        // }
        // catch (IndexOutOfRangeException)
        // {
        //     Console.WriteLine("Ошибка выхода индекса за границы массива");
        // }
        // catch (NullReferenceException)
        // {
        //     Console.WriteLine("Один из массивов переданных в метод = null");
        // }
        catch (Exception e) when (1 == 2)
        {
            Console.WriteLine("Деление на ноль, или возникла ошибка выхода индекса за границу диапазона.");
        }
    }

    public static void Ex03()
    {
        // int[] a1 = new int[] { 2, 6, 8 };
        // int[] a2 = new int[] { 1, 3, 4 };

        // тут могут быть несколько исключений: 
        // var a3 = DivideTwoArrays(a1, a2);
        // a3.ToList().ForEach(x => Console.Write($"{x}; "));

        AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        RunDivideTwoArrays(new[] { 2, 4, 8 }, new[] { 1, 2, 4 });
        RunDivideTwoArrays(new[] { 2, 4, 8 }, null);
        RunDivideTwoArrays(new[] { 2, 4, 8 }, new[] { 0, 2, 4 });
        RunDivideTwoArrays(new[] { 2, 4, 8 }, new int[] { });


        Console.WriteLine("Завершено!");
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine("Это нас убьет!");
        Console.WriteLine(e.ExceptionObject);
    }

    private static void CurrentDomain_FirstChanceException(object? sender, FirstChanceExceptionEventArgs e)
    {
        // Console.WriteLine(e.Exception);
    }
}