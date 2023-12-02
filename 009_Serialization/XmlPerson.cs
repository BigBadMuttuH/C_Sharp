using System.Xml.Serialization;

namespace _009_Serialization;

[XmlType("XmlPerson")]
[XmlRoot("XmlPersonRoot")]
public class XmlPerson
{
    public int Age;
    public object[] Details;
    public List<Hobby> Hobbies;
    public string Name;
    public string Surname;

    public override string ToString()
    {
        return $"Name={Name}, Surname={Surname}, Age={Age}";
    }
}