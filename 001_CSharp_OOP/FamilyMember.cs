namespace _001_CSharp_OOP;

public class FamilyMember
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public List<FamilyMember> Children { get; set; }

    public FamilyMember(string name, Gender gender)
    {
        Name = name;
        Gender = gender;
        Children = new List<FamilyMember>();
    }

    public override string ToString()
    {
        string childrenNames = string.Join(", ", Children.Select(c => c.Name));
        return $"{nameof(Name)}: {Name}, {nameof(Gender)}: {Gender.GetName()}, {nameof(Children)}: {childrenNames}";
    }

    public void PrintFamilyTree(string indent = "")
    {
        Console.WriteLine($"{indent}{Name} ({Gender.GetName()})");
        foreach (var child in Children)
        {
            child.PrintFamilyTree(indent + "-");
        }
    }
}