using System.Text;

namespace _000_introduction;

public class HomeWork_01
{
    public static void HomeWork(string[] args)
    {
        if (args.Length > 0)
        {
            var input = args[0]; // Получаем строку из 1 аргумента строки командной строки
            // вычисление можно предавать только как один аргумент.
            // например так "(22 - 12 * 4) / 12 - 10", по другому не получиться из-за того,
            // что консоль воспринимает некоторые аргументы как специальные команды.
            Console.WriteLine(input);
            var postfix = ConvertToPostfix(input.Replace(" ", "")); // Преобразуем в "Обратную Польскую запись" (ОПЗ)
            var result = CalculatePostfix(postfix); // Вычисляем значение
            Console.WriteLine(result); // Выводим результат
        }
        else
        {
            Console.WriteLine("Не хватает аргументов.");
        }

        // // исключительно для тестирования
        // string intfix = "(22 - 12 * 4) / 12 - 10";
        // string postfix = ConvertToPostfix(intfix.Replace(" ", ""));
        // Console.WriteLine(postfix);
        // double result = CalculatePostfix(postfix);
        // Console.WriteLine(result);
    }


    // Преобразование в ОПЗ
    public static string ConvertToPostfix(string infix)
    {
        var postfix = new StringBuilder();
        var operators = new Stack<char>();

        for (var i = 0; i < infix.Length; i++)
        {
            var ch = infix[i];

            if (char.IsDigit(ch))
            {
                // Читаем все последующие цифры, чтобы сформировать полное число
                while (i < infix.Length && char.IsDigit(infix[i]))
                {
                    postfix.Append(infix[i]);
                    i++;
                }

                i--; // Возвращаем i на последний символ числа
                postfix.Append(' '); // Добавляем пробел для разделения чисел
            }
            else if (ch == '(')
            {
                operators.Push(ch);
            }
            else if (ch == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    postfix.Append(operators.Pop());
                    postfix.Append(' ');
                }

                operators.Pop(); // Удаляем открывающуюся скобку '('
            }
            else // Operator
            {
                while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(ch))
                {
                    postfix.Append(operators.Pop());
                    postfix.Append(' ');
                }

                operators.Push(ch);
            }
        }

        while (operators.Count > 0)
        {
            postfix.Append(operators.Pop());
            postfix.Append(' ');
        }

        return postfix.ToString().Trim();
    }


    // Вычисление ОПЗ
    public static double CalculatePostfix(string postfix)
    {
        var stack = new Stack<double>();
        var tokens = postfix.Split(' ');

        foreach (var token in tokens)
            if (double.TryParse(token, out var num))
            {
                stack.Push(num);
            }
            else
            {
                var operand2 = stack.Pop();
                var operand1 = stack.Pop();
                double result = 0;

                switch (token)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 != 0.0)
                            result = operand1 / operand2;
                        else
                            throw new InvalidOperationException("Division by zero");
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator");
                }

                stack.Push(result);
            }

        return stack.Pop();
    }

    // Приоритет знаков
    private static int GetPrecedence(char ch)
    {
        switch (ch)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }
}