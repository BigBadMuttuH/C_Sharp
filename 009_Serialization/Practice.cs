using System.Text.Json;
using System.Xml.Serialization;

namespace _009_Serialization;

/*
<?xml version="1.0" encoding="utf-8"?>
    <Data.Root xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        <Data.Root.Names>
            <Name>Name1</Name>
            <Name>Name2</Name>
            <Name>Name3</Name>
        </Data.Root.Names>
        <Data.Entry LinkedEntry="Name1">
            <Data.Name>Name2</Data.Name>
        </Data.Entry>
        <Data_x0023_ExtendedEntry LinkedEntry="Name2">
            <Data.Name>Name1</Data.Name>
            <Data_x0023_Extended>NameOne</Data_x0023_Extended>
        </Data_x0023_ExtendedEntry>
    </Data.Root>
*/

[XmlRoot("Data.Root")]
public class DataRoot
{
    [XmlElement("Data.Entry")] public DataEntry Entry;

    [XmlElement("Data_\x0023_ExtendedEntry")]
    public DataExtendedEntry ExtendedEntry;

    [XmlArray("Data.Root.Names")] [XmlArrayItem("Name")]
    public List<string> Names;
}

public class DataEntry
{
    [XmlAttribute("LinkedEntry")] public string LinkedEntry;
    [XmlElement("Data.Name")] public string Name;
}

public class DataExtendedEntry
{
    [XmlElement("Data.Name")] public string Name;
    [XmlElement("Data_x0023_Extended")] public string ExtendedName;
    [XmlAttribute("LinkedEntry")] public string LinkedEntry;
}

public class Practice
{
    public static void Ex01()
    {
        var dataRoot = new DataRoot
        {
            Names = new List<string> { "Name1", "Name2", "Name3" },
            Entry = new DataEntry { LinkedEntry = "Name1", Name = "Name2" },
            ExtendedEntry = new DataExtendedEntry
            {
                Name = "Name1",
                LinkedEntry = "Name2",
                ExtendedName = "Name1"
            }
        };

        var serializer = new XmlSerializer(typeof(DataRoot));
        serializer.Serialize(Console.Out, dataRoot);
    }

    public static void Ex02()
    {
        var json = """
                   {"Current":
                   {"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},
                   "History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
                   {"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
                   {"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]}
                   """;
        var report = JsonSerializer.Deserialize<WeatherReport>(json);
        Console.WriteLine();
    }
}
/*
С сайта о погоде была получена информация о текущей и прошлой (за три дня) погоде в виде JSON.
Напишите класс способный хранить представленную информацию.
{"Current":
{"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},
"History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
{"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
{"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]}
*/

public class Weather
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public int Weathercode { get; set; }
    public double Windspeed { get; set; }
    public int Winddirection { get; set; }
}

public class WeatherReport
{
    public Weather Current { get; set; }
    public List<Weather> History { get; set; }
}