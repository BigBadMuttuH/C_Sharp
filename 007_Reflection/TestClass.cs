namespace _007_Reflection;

internal class TestClass
{
    public TestClass() { }

    public TestClass(int i) { I = i; }

    public TestClass(int i, string s, decimal d, char[] c) : this(i)
    {
        S = s;
        D = d;
        C = c;
    }

    [CustomName("CustomFieldNameI")] public int I { get; set; }
    [CustomName("CustomFieldNameS")] private string? S { get; set; }
    [CustomName("CustomFieldNameD")] public decimal D { get; set; }
    [CustomName("CustomFieldNameC")] public char[]? C { get; set; }
}