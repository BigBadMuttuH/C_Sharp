namespace _007_Reflection;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class CustomNameAttribute : Attribute
{
    public CustomNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}