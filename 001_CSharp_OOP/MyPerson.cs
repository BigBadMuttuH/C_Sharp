using System.Globalization;

namespace _001_CSharp_OOP;

public class MyPerson
{
    public readonly string Name;
    public readonly DateTime Birthday;
    public readonly int Height;
    public readonly bool Adult;

    public MyPerson(string name, string birthday, int height)
    {
        this.Name = name;
        this.Birthday = DateTime.Parse(birthday) <= DateTime.Now
            ? DateTime.Parse(birthday)
            : this.Birthday = DateTime.Now;
        this.Height = height;
        this.Adult = IsAdult();
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, " +
               $"BirthDay:{this.Birthday.ToString(CultureInfo.InvariantCulture)}, " +
               $"height: {this.Height}, " +
               $"IsAdult: {this.Adult}";
    }

    public bool IsAdult(int adultAge)
    {
        var delta = DateTime.Now.Year - this.Birthday.Year;
        if (delta > adultAge || (delta == adultAge && DateTime.Now.DayOfWeek <= Birthday.DayOfWeek))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsAdult()
    {
        return this.IsAdult(18);
    }
}