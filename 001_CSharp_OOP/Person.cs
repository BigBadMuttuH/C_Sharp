namespace _001_CSharp_OOP;

public abstract class Person
{
    public readonly string Name;
    public readonly DateTime Birthday;

    public Person Father = null;
    public Person Mother = null;
    public Person[] Children = null;

    protected abstract string HelloPhrase { get; }

    public Person(string name, DateTime birthday)
    {
        this.Name = name;

        if (birthday <= DateTime.Now)
        {
            this.Birthday = birthday;
        }
        else
        {
            Console.WriteLine($"Дата {birthday}, больше текущей.");
            this.Birthday = DateTime.Now;
        }
    }

    // перегрузка
    public Person(string name)
    {
        Name = name;
        Birthday = DateTime.Now;
    }

    public void Print()
    {
        Console.WriteLine($"Имя={Name}, ДР={Birthday}");
    }

    public bool IsAdult(int adultAge = 18)
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

    public void AddFamilyInfo(Person father, Person mother, params Person[] children)
    {
        Father = father;
        Mother = mother;
        Children = children;
    }

    public void PrintFamilyInfo()
    {
        if (Father != null)
        {
            Console.WriteLine("Отец:");
            Father.Print();
        }

        if (Mother != null)
        {
            Console.WriteLine("Мать:");
            Mother.Print();
        }

        if (Children != null)
        {
            Console.WriteLine("Дети:");
            foreach (var child in Children)
            {
                child.Print();
            }
        }
    }

    public bool GetChildren(out Person[] children)
    {
        if (Children != null && Children.Length != 0)
        {
            children = Children;
            return true;
        }
        else
        {
            children = null;
            return false;
        }
    }

    public virtual void SayHello()
    {
        Console.WriteLine("Привет, я - человек!");
    }

    public void SayHelloPhrase()
    {
        Console.WriteLine(this.HelloPhrase);
    }

    public static bool AreSiblings(Person p1, Person p2)
    {
        if (p1.Mother == null || p2.Mother == null) return false;
        if (p1.Father == null || p2.Father == null) return false;
        if (p1.Father != p2.Father) return false;
        if (p1.Mother != p2.Mother) return false;

        return true;
    }
}