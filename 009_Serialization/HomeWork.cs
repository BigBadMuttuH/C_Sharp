using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _009_Serialization;

public class HomeWork
{
    public static void Ex01()
    {
        var jsonPerson = """
                         {
                             "Name": "John",
                             "SurName": "Doe",
                             "Age": 30,
                             "Hobbies": ["Reading", "Gaming"]
                         }
                         """;


        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };
        var person = JsonSerializer.Deserialize<Person>(jsonPerson, options);

        var serializer = new XmlSerializer(typeof(Person));

        using (var stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, person);
            var xml = stringWriter.ToString();
            Console.WriteLine(xml);
        }
    }

    public static void Ex02()
    {
        var jsonString = """
                         {
                             "Name": "John",
                             "SurName": "Doe",
                             "Age": 30,
                             "Hobbies": ["Reading", "Gaming"]
                         }
                         """;

        var xml = JsonToXml(jsonString);

        Console.WriteLine(xml);
    }

    private static XElement JsonToXml(string json)
    {
        using (var doc = JsonDocument.Parse(json))
        {
            return ParseElement(doc.RootElement);
        }
    }

    private static XElement ParseElement(JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                var compound = new XElement("Object");
                foreach (var prop in element.EnumerateObject())
                    compound.Add(new XElement(prop.Name, ParseElement(prop.Value)));
                return compound;

            case JsonValueKind.Array:
                var sequence = new XElement("Array");
                foreach (var item in element.EnumerateArray()) sequence.Add(ParseElement(item));
                return sequence;

            case JsonValueKind.String:
                return new XElement("String", element.GetString());

            case JsonValueKind.Number:
                return new XElement("Number", element.GetDouble());

            case JsonValueKind.True:
            case JsonValueKind.False:
                return new XElement("Boolean", element.GetBoolean());

            case JsonValueKind.Null:
                return new XElement("Null");

            default:
                throw new InvalidOperationException("Неизвестный тип JSON.");
        }
    }
}