using System.Xml.Serialization;

namespace _009_Serialization;

public class Group
{
    [XmlElement(typeof(Person))]
    [XmlElement(typeof(AnotherPerson))]
    public object[] People;
}