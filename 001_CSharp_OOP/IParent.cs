namespace _001_CSharp_OOP;

public interface IParent
{
    public bool GetChildren(out Person[] children);
    public void TakeCare();
}