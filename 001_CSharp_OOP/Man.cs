namespace _001_CSharp_OOP;

public class Man : Person
{
    public Man(string name, DateTime birthday) : base(name, birthday)
    {
    }

    public Man(string name) : base(name)
    {
    }

    protected override string HelloPhrase => "Привет, я - мужчина!";

    public bool HasBeard { get; private set; } = true;

    public void Shave()
    {
        Console.WriteLine("Бреется");
        HasBeard = false;
    }


    public override void SayHello()
    {
        Console.WriteLine("Привет, я - мужчина");
    }

    public void SayHelloLikeParent()
    {
        base.SayHello();
    }

    protected override void TakeCareImplementation()
    {
        Console.WriteLine("Проверяет уроки и идёт с детьми на прогулку!");
    }
}