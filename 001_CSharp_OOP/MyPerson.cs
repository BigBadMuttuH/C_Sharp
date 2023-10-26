using System.Globalization;

namespace _001_CSharp_OOP;

public class MyPerson
{
    public readonly bool Adult;
    public readonly DateTime Birthday;
    public readonly int Height;
    public readonly string Name;

    public MyPerson(string name, string birthday, int height)
    {
        Name = name;
        Birthday = DateTime.Parse(birthday) <= DateTime.Now
            ? DateTime.Parse(birthday)
            : Birthday = DateTime.Now;
        Height = height;
        Adult = IsAdult();
    }

    public override string ToString()
    {
        return $"Name: {Name}, " +
               $"BirthDay:{Birthday.ToString(CultureInfo.InvariantCulture)}, " +
               $"height: {Height}, " +
               $"IsAdult: {Adult}";
    }

    public bool IsAdult(int adultAge)
    {
        var delta = DateTime.Now.Year - Birthday.Year;
        if (delta > adultAge || (delta == adultAge && DateTime.Now.DayOfWeek <= Birthday.DayOfWeek))
            return true;
        return false;
    }

    public bool IsAdult()
    {
        return IsAdult(18);
    }
}