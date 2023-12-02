using System.Text.Json;

namespace _009_Serialization;

public class JsonSerialize
{
    public static void Ex01()
    {
        var person = new Person
        {
            Name = "Vasiliy", Surname = "Ivanov", Age = 22, Hobbies = new List<Hobby>
            {
                Hobby.Fishing, Hobby.Painting, Hobby.Sport
            }
        };
        var json = JsonSerializer.Serialize(person);
        Console.WriteLine(json);
        Console.WriteLine();

        var jp = JsonSerializer.Deserialize<Person>(json);
        Console.WriteLine(jp);
    }
}