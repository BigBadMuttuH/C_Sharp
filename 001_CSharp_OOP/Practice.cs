namespace _001_CSharp_OOP;

public class Practice
{
    public static void Family()
    {
        var grandpa = new FamilyMember("Дедушка", Gender.Male);
        var grandma = new FamilyMember("Бабушка", Gender.Female);
        var dad = new FamilyMember("Папа", Gender.Male);
        var mom = new FamilyMember("Мама", Gender.Female);
        var children1 = new FamilyMember("Ребенок1", Gender.Male);
        var children2 = new FamilyMember("Ребенок2", Gender.Female);


        grandpa.Children.Add(dad);
        grandma.Children.Add(dad);

        dad.Children.Add(children1);
        dad.Children.Add(children2);

        mom.Children.Add(children1);
        mom.Children.Add(children2);

        Console.WriteLine(grandma);
        Console.WriteLine(grandpa);
        Console.WriteLine(mom);
        Console.WriteLine(dad);
        Console.WriteLine(children2);
        Console.WriteLine(children1);
        grandma.PrintFamilyTree();
        mom.PrintFamilyTree();
        children2.PrintFamilyTree();
    }
}