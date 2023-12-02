using System.Xml.Serialization;

namespace _009_Serialization;

public class Group
{
    [XmlElement(typeof(XmlPerson))] [XmlElement(typeof(AnotherXmlPerson))]
    public object[] People;
}