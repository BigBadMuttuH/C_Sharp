namespace _001_CSharp_OOP;

public class Woman : Person, IBabySitter
{
    public Woman(string name, DateTime birthday) : base(name, birthday)
    {
    }

    public Woman(string name) : base(name)
    {
    }

    protected override string HelloPhrase => "Привет, я - женщина!";

    public bool HasMakeup { get; private set; }

    void IBabySitter.TakeCare()
    {
        if (Children != null)
            Console.WriteLine("Сидит с детьми, пока родители в кино!");
    }


    public void PutMakeup()
    {
        Console.WriteLine("Наносит макияж");
        HasMakeup = true;
    }

    public void RemoveMakeup()
    {
        Console.WriteLine("Снимает макияж");
        HasMakeup = false;
    }


    public override void SayHello()
    {
        Console.WriteLine("Привет, я - женщина");
    }

    protected override void TakeCareImplementation()
    {
        if (Children != null) Console.WriteLine("Кормит ужином, а затем укладывает спать.");
    }
}