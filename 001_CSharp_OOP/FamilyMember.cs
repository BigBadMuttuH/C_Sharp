namespace _001_CSharp_OOP;

/// <summary>
///     Represents a family member in a genealogical tree.
/// </summary>
/// <remarks>
///     Each family member has a name, gender, and a list of children.
///     The class provides methods to output the family member's information as a string
///     and to recursively print the family tree starting from that member.
/// </remarks>
public class FamilyMember
{
    public FamilyMember(string name, Gender gender)
    {
        Name = name;
        Gender = gender;
        Children = new List<FamilyMember>();
    }

    public string Name { get; set; }
    public Gender Gender { get; set; }
    public List<FamilyMember> Children { get; set; }

    public override string ToString()
    {
        var childrenNames = string.Join(", ", Children.Select(c => c.Name));
        return $"{nameof(Name)}: {Name}, {nameof(Gender)}: {Gender.GetName()}, {nameof(Children)}: {childrenNames}";
    }

    public void PrintFamilyTree(string indent = "")
    {
        Console.WriteLine($"{indent}{Name} ({Gender.GetName()})");
        foreach (var child in Children) child.PrintFamilyTree(indent + "-");
    }
}