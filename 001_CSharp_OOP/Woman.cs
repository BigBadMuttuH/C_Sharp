namespace _001_CSharp_OOP;

public class Woman:Person
{
    protected override string HelloPhrase => "Привет, я - женщина!";

    public Woman(string name, DateTime birthday) : base(name, birthday)
    {
    }

    public Woman(string name) : base(name)
    {
    }

    public bool HasMakeup { get; private set; } = false;
    public void PutMakeup()
    {
        Console.WriteLine("Наносит макияж");
        this.HasMakeup = true;
    }
    public void RemoveMakeup()
    {
        Console.WriteLine("Снимает макияж");
        this.HasMakeup = false;
    }



    public override void SayHello()
    {
        Console.WriteLine("Привет, я - женщина");
    }
}