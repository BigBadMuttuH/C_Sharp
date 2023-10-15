namespace _001_CSharp_OOP;

public class Man:Person
{
    protected override string HelloPhrase => "Привет, я - мужчина!";

    public Man(string name, DateTime birthday) : base(name, birthday)
    {
    }

    public Man(string name) : base(name)
    {
    }

    public bool HasBeard { get; private set; } = true;
    public void Shave()
    {
        Console.WriteLine("Бреется");
        this.HasBeard = false;
    }


    public override void SayHello()
    {
        Console.WriteLine("Привет, я - мужчина");
    }

    public void SayHelloLikeParent()
    {
        base.SayHello();
    }
}