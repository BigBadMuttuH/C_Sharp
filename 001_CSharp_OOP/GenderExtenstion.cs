namespace _001_CSharp_OOP;

public static class GenderExtenstion
{
    private static readonly Dictionary<Gender, string> GenderNames = new()
    {
        { Gender.Male, "Мужчина" },
        { Gender.Female, "Женщина" }
    };

    public static string GetName(this Gender gender)
    {
        return GenderNames[gender];
    }
}