using System.Text;

namespace _008_Streams_and_Buffering;

public class Stream
{
    // чтение, запись, установка позиции
    // IO.Stream
    // FileStream Append, Create, CreateNew, Open, OpenOrCreate,
    // Truncate - открывает и усекает до 0 байт.

    // FileAccess(Flags) Read, ReadWrite, Write

    public static void Ex01()
    {
        var prjRoot = FileSystem.GetProjectRoot();
        Console.WriteLine(prjRoot);

        var filePath = Path.Combine(prjRoot.FullName, "Stream.cs");
        if (!File.Exists(filePath)) Console.WriteLine($"Файл {filePath} не найден");

        using (var fStream = new FileStream(filePath, FileMode.Open))
        {
            var bytes = new byte[fStream.Length - 50];
            fStream.Seek(50, SeekOrigin.Begin);
            fStream.Read(bytes, 0, bytes.Length);
            Console.WriteLine(Encoding.Default.GetString(bytes));
        }
    }
}