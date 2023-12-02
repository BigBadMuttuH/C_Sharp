using System.Xml;
using System.Xml.Serialization;

namespace _009_Serialization;

public static class XmlSerialize
{
    public static void Ex01()
    {
        var serializer = new XmlSerializer(typeof(MyClass));
        var obj = new MyClass(1, '1');

        serializer.Serialize(Console.Out, obj);

        var str = """
                    <MyClass xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                    <Field2>20</Field2>
                    <Field4>20</Field4>
                    </MyClass>
                  """;
        // Если добавить или удалить поле, то сериализатор/десериализатор проигнорирует это поле.
        // Но если класс отсутствует, то ни чего не получиться
        // Если есть конструктор с параметрами, то нужно делать конструктор без параметров

        var obj2 = (MyClass?)serializer.Deserialize(new StringReader(str));
        Console.WriteLine();
        Console.WriteLine(obj2);
    }

    public static void Ex02()
    {
        var obj = new XmlPerson
        {
            Name = "Василий",
            Surname = "Иванов",
            Age = 22,
            Details = new object[]
            {
                new Address { Street = "Строителей", BuildingNo = 1 },
                new Phone { Home = "+7555555555", Work = "8888888" },
                new Occupation { Company = "Школа", Position = "трудовик" },
                "что-то еще"
            }
        };

        // var serializer = new XmlSerializer(typeof(XmlPerson));  // если сделать так, то не получиться
        // нужен массив типов
        // Type[] types = new Type[] {typeof(Address), typeof(Phone), typeof(Occupation) }; // такое не всегда сработает. т.к Details рандомный массив

        // лучше так
        var lTypes = new List<Type>();
        foreach (var o in obj.Details) lTypes.Add(o.GetType());

        var types = lTypes.ToArray();
        var serializer = new XmlSerializer(typeof(XmlPerson), types);
        serializer.Serialize(Console.Out, obj);
    }

    public static void Ex03()
    {
        var obj = new XmlPerson
        {
            Name = "Василий",
            Surname = "Иванов",
            Age = 22
        };

        var xmlRoot = new XmlRootAttribute();
        xmlRoot.ElementName = "SomOne";
        xmlRoot.Namespace = "";
        var serializer = new XmlSerializer(typeof(XmlPerson), xmlRoot);
        serializer.Serialize(Console.Out, obj);
        Console.WriteLine();


        var xml = """
                    <MyClass xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                    <Field2>20</Field2>
                    <Field4>20</Field4>
                    </MyClass>
                  """;

        var xmlReader = XmlReader.Create(new StringReader(xml));

        Console.WriteLine(serializer.CanDeserialize(xmlReader)); // буде False - см. 14 строку
    }

    public static void Ex04()
    {
        var settings = LoadSettings();
        if (settings == null)
        {
            Console.WriteLine("Новые настройки..");
            settings = new Settings { Setting1 = "On", Setting2 = "Off", Setting3 = "1,5" };
        }
        else
        {
            Console.WriteLine("Старые настройки..");
        }

        Console.WriteLine(settings);
        settings.Setting1 = "Off";
        settings.Setting2 = "On";
        settings.Setting3 = "1.00";
        SaveSettings(settings);
    }

    private static void SaveSettings(Settings s)
    {
        var serializer = new XmlSerializer(s.GetType());
        using var writer = File.OpenWrite("mySettings.xml");
        serializer.Serialize(writer, s);
    }

    private static Settings? LoadSettings()
    {
        var path = "mySettings.xml";
        var serializer = new XmlSerializer(typeof(Settings));

        if (Path.Exists(path))
        {
            using var reader = XmlReader.Create(path);
            return (Settings?)serializer.Deserialize(reader);
        }

        return null;
    }

    public static void Ex05()
    {
        using (var reader = XmlReader.Create("mySettings.xml"))
        {
            while (reader.Read())
                if (reader.IsStartElement())
                {
                    Console.Write("<");
                    Console.Write(reader.Name);
                    Console.WriteLine("/>");
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    Console.Write("<");
                    Console.Write(reader.Name);
                    Console.WriteLine("/>");
                }
                else
                {
                    Console.WriteLine(reader.Value);
                }
        }
    }

    public static void Ex06()
    {
        int[] array = { 0, 1, 2, 3, 4, 5 };

        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t"
        };

        using (var writer = XmlWriter.Create("array.xml", settings))
        {
            writer.WriteStartElement("arr");
            foreach (var i in array)
            {
                writer.WriteStartElement("element");
                writer.WriteValue(i);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
    // TODO: XML атрибуты - 01:27:00

    public static void Ex07()
    {
        var person = new XmlPerson
        {
            Name = "Василий",
            Surname = "Иванов",
            Age = 22
        };
        var serializer = new XmlSerializer(typeof(XmlPerson));
        serializer.Serialize(Console.Out, person);
        Console.WriteLine();

        var xml = """
                  <XmlPerson xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                    <Age>22</Age>
                    <Surname>Иванов</Surname>
                  </XmlPerson>
                  """;

        var newPerson = serializer.Deserialize(new StringReader(xml));
        Console.WriteLine(newPerson);
    }

    public static void Ex08()
    {
        // так получиться, но вариант с атрибутами лучше
        // var serializer = new XmlSerializer(typeof(Group), new Type[]{typeof(XmlPerson), typeof(AnotherXmlPerson)});

        // так не получиться, но с атрибутами как ниже получится
        var serializer = new XmlSerializer(typeof(Group));
        // [XmlElement(typeof(XmlPerson))]
        // [XmlElement(typeof(AnotherXmlPerson))]

        var person = new XmlPerson { Name = "Василий", Surname = "Иванов", Age = 22 };
        var aPerson = new AnotherXmlPerson { Name = "Миша", Surname = "Сидоров", Age = 33 };

        var group = new Group { People = new[] { person, aPerson } };

        serializer.Serialize(Console.Out, group);
    }

    public static void Ex09()
    {
        var serializer = new XmlSerializer(typeof(XmlPerson));
        var person = new XmlPerson
        {
            Name = "Василий", Surname = "Иванов", Age = 22, Hobbies = new List<Hobby>
            {
                Hobby.Fishing, Hobby.Painting, Hobby.Sport
            }
        };

        serializer.Serialize(Console.Out, person);
    }
}