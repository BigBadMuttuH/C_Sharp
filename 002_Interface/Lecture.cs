using _001_CSharp_OOP;

namespace _002_Interface;

public class Lecture
{
    public static void Ex01()
    {
        Person[] peopls =
        {
            new Woman("Анна", DateTime.Parse("01.01.1990")),
            new Woman("Мария", DateTime.Parse("01.01.1991")),
            new Woman("Екатерина", DateTime.Parse("01.01.1992")),
            new Man("Петр", DateTime.Parse("01.01.1989")),
            new Man("Федор", DateTime.Parse("01.01.1997")),
            new Man("Руслан", DateTime.Parse("01.01.1995"))
        };

        // IComparable
        Array.Sort(peopls);
        foreach (var p in peopls) p.Print();
    }

    public static void Ex02()
    {
        var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Петр", DateTime.Parse("01.01.1989"));
        var kid = new Man("Федор", DateTime.Parse("01.01.1997"));

        man.AddFamilyInfo(null, null, kid);
        woman.AddFamilyInfo(null, null, kid);

        man.TakeCare();
        woman.TakeCare();

        TakeCare(man, woman);
    }

    private static void TakeCare(params IParent[] parents)
    {
        foreach (var p in parents) p.TakeCare();
    }

    public static void Ex03()
    {
        var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Петр", DateTime.Parse("01.01.1989"));
        var kid = new Man("Федор", DateTime.Parse("01.01.1997"));

        man.AddFamilyInfo(null, null, kid);
        woman.AddFamilyInfo(null, null, kid);

        IBabySitter babySitter = woman;
        IParent mom = woman;
        IParent dad = man;

        dad.TakeCare();
        mom.TakeCare();
        babySitter.TakeCare();
    }
    public static void Ex04()
    {
        var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Петр", DateTime.Parse("01.01.1989"));
        var kid = new Man("Федор", DateTime.Parse("01.01.1997"));

        man.AddFamilyInfo(null, null, kid);
        woman.AddFamilyInfo(null, null, kid);


        IBabySitter babySitter1 = new BabySitter();
        var babySitter2 = new BabySitter();
        IBabySitter babySitter3 = new BabySitter();

        TakeCare(babySitter1, babySitter2, babySitter3);
    }
    static void TakeCare(params IBabySitter[] sitters)
    {
        foreach (var s in sitters)
        {
            s.TakeCare();
        }
    }

    public static void Ex05()
    {
        var grandMa = new Woman("Анна", DateTime.Parse("01.01.1960"));
        var grandPa = new Man("Петр", DateTime.Parse("01.01.1959"));

        var parent = new Woman("Ирина", DateTime.Parse("01.01.1980"));
        var kid1 = new Man("Петр", DateTime.Parse("01.01.2000"));

        parent.AddFamilyInfo(grandPa, grandMa, kid1);


        for (int i = 0; i < parent.Count; i++)
        {
            parent[i].Print();
        }
    }

    public static void Ex06()
    {
        // 1111_1111
        // 0000_0100
        // 1111_1011
        var b = new Bits(122);
        for (int i = 0; i <= 7; i++)
        {
            Console.WriteLine(b[i]);
        }

        b[0] = true;
        Console.WriteLine(b.Value);
    }

}