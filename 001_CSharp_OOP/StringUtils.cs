namespace _001_CSharp_OOP;

public static class StringUtils
{
    static StringUtils()
    {
        Console.WriteLine("Конструктор создан!");
    }
    
    // public static string Reverse(string s)
    // {
    //     return new String(s.ToCharArray().Reverse().ToArray());
    // }

    // Расширение
    public static string Reverse(this string s)
    {
        return new String(s.ToCharArray().Reverse().ToArray());
    }
    
}