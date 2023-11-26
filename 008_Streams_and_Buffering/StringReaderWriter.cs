namespace _008_Streams_and_Buffering;

public class StringReaderWriter
{
    public static void Ex01()
    {
        var input = """
                    Line0
                    Line1
                    Line2
                    Line3
                    Line4
                    Line5
                    """;
        using (var sout = new StringWriter())
        {
            using (var sin = new StringReader(input))
            {
                while (sin.Peek() >= 0) sout.WriteLine(sin.ReadLine());
            }

            Console.WriteLine(sout.ToString());
        }
    }
}