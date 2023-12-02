using System.Xml.Serialization;

namespace _009_Serialization;

public class MyClass
{
    private int Field1 = 10;
    private int Field2 = 20;
    private int Field3 = 10;
    private int Field4 = 20;
}
public static class XmlSerializ
{
    public static void Ex01()
    {
        var serializer = new XmlSerializer(typeof(MyClass));
        var obj = new MyClass();

        serializer.Serialize(Console.Out, obj);
    }
}
