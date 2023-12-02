namespace _009_Serialization;

public class JsonPerson
{
    public List<Hobby> Hobbies;
    public int Age { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public override string ToString()
    {
        return $"Name={Name}, Surname={Surname}, Age={Age}";
    }
}