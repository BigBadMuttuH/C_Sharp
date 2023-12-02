using System.Xml.Serialization;

namespace _009_Serialization;

public enum Hobby
{
    [XmlEnum("Art")]
    Painting,
    [XmlEnum("Hunt")]
    Fishing,
    Sport
}