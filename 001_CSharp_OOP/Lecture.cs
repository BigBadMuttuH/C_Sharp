namespace _001_CSharp_OOP;

public class Lecture
{
    public static void Ex01()
    {
        var person1 = new MyPerson("John", "01.01.2000", 123);
        Console.WriteLine(person1);
        var person2 = new MyPerson("Mark", "01.01.2040", 223);
        Console.WriteLine(person2);
        var person3 = new MyPerson("Merry", "01.01.2020", 150);
        Console.WriteLine(person3.IsAdult(1));
        Console.WriteLine(person3);
    }

    public static void Ex02()
    {
        // var person1 = new Person("Федор", DateTime.Parse("01.01.1978"));
        // var son = new Person("Николай", DateTime.Parse("01.01.2020"));
        // var daughter = new Person("Мария", DateTime.Parse("01.01.2021"));
        // var father = new Person("Алексей", DateTime.Parse("01.01.1950"));
        // var mother = new Person("Екатерина", DateTime.Parse("01.01.1950"));
        //
        // person1.AddFamilyInfo(father, mother, daughter, son);
        //
        // person1.Print();
        // person1.PrintFamilyInfo();
        //
        // // out parameters
        // var res = person1.GetChildren(out var children);
        //
        // if (res) Console.WriteLine("Дети есть.");
    }

    public static void Ex03()
    {
        var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Олег", DateTime.Parse("01.01.1990"));

        woman.Print();
        woman.PutMakeup();
        woman.RemoveMakeup();

        man.Print();
        man.Shave();
    }

    public static void Ex04()
    {
        var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Олег", DateTime.Parse("01.01.1990"));


        Person[] people = { woman, man };
        foreach (var p in people)
        {
            p.Print();

            // Кастование классов
            // Woman w = (Woman) p;
            // w.PutMakeup();
            // Woman w = p as Woman;
            (p as Woman)?.PutMakeup();
            (p as  Man)?.Shave();

            p.SayHello();
            p.SayHelloPhrase();
        }

        man.SayHelloLikeParent();
    }

    public static void Ex05()
    {
        var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Олег", DateTime.Parse("01.01.1990"));

        Console.WriteLine(Person.AreSiblings(woman, man));
    }

    public static void Ex06()
    {
        string s1 = StringUtils.Reverse("123");
        Console.WriteLine(s1);

        var s2 = "123";
        Console.WriteLine(s2.Reverse());
    }
}