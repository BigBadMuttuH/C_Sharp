namespace _009_Serialization;

public class Person
{
    public List<Hobby> Hobbies { get; set; } = new();
    public int Age { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public override string ToString()
    {
        return $"Name={Name}, Surname={Surname}, Age={Age}";
    }
}