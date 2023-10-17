namespace _001_CSharp_OOP;

public abstract class Person : IComparable, IParent, IFamily
{
    public readonly DateTime Birthday;
    public readonly string Name;
    public Person[] Children;

    public Person[] Family;

    public Person Father;
    public Person Mother;

    public Person(string name, DateTime birthday)
    {
        Name = name;

        if (birthday <= DateTime.Now)
        {
            Birthday = birthday;
        }
        else
        {
            Console.WriteLine($"Дата {birthday}, больше текущей.");
            Birthday = DateTime.Now;
        }
    }

    // перегрузка
    public Person(string name)
    {
        Name = name;
        Birthday = DateTime.Now;
    }

    protected abstract string HelloPhrase { get; }

    public int CompareTo(object? obj)
    {
        if (obj == null) return -1;
        return Birthday.CompareTo((obj as Person).Birthday);
    }

    public int Count => 1 + (Family?.Length ?? 0);

    public Person this[int index]
    {
        get
        {
            if (index <= 0) return this;
            if (Family is null) return null;
            if (Family.Length >= index) return Family[index - 1];
            return null;
        }
    }

    public bool GetChildren(out Person[] children)
    {
        if (Children != null && Children.Length != 0)
        {
            children = Children;
            return true;
        }

        children = null;
        return false;
    }

    public void TakeCare()
    {
        if (Children != null) TakeCareImplementation();
    }


    public void Print()
    {
        Console.WriteLine($"Имя={Name}, ДР={Birthday}");
    }

    public bool IsAdult(int adultAge = 18)
    {
        var delta = DateTime.Now.Year - Birthday.Year;
        if (delta > adultAge || (delta == adultAge && DateTime.Now.DayOfWeek <= Birthday.DayOfWeek))
            return true;
        return false;
    }

    public void AddFamilyInfo(Person father, Person mother, params Person[] children)
    {
        Father = father;
        Mother = mother;
        Children = children;

        var familyCount = 0;
        familyCount += Father == null ? 0 : 1;
        familyCount += Mother == null ? 0 : 1;
        familyCount += Children.Length;

        if (familyCount > 0)
            Family = new Person[familyCount];
        else
            return;

        int counter = 0;

        if (Father != null)
        {
            Family[counter] = Father;
            counter++;
        }
        if (Mother != null)
        {
            Family[counter] = Mother;
            counter++;
        }

        foreach (var child in children)
        {
            Family[counter] = child;
            counter++;
        }
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
            foreach (var child in Children) child.Print();
        }
    }

    public virtual void SayHello()
    {
        Console.WriteLine("Привет, я - человек!");
    }

    public void SayHelloPhrase()
    {
        Console.WriteLine(HelloPhrase);
    }

    public static bool AreSiblings(Person p1, Person p2)
    {
        if (p1.Mother == null || p2.Mother == null) return false;
        if (p1.Father == null || p2.Father == null) return false;
        if (p1.Father != p2.Father) return false;
        if (p1.Mother != p2.Mother) return false;

        return true;
    }

    protected abstract void TakeCareImplementation();
}