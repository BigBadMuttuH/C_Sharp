namespace _008_Streams_and_Buffering;

public class StreamReaders
{
    public static void Ex01()
    {
        var path1 = "F:\\CSharp\\GB\\GB_CSharp\\008_Streams_and_Buffering\\StreamReaders.cs";
        var path2 = "F:\\CSharp\\GB\\GB_CSharp\\008_Streams_and_Buffering\\_doc_\\StreamReaders.bak";

        using (var f = new FileStream(path1, FileMode.Open))
        {
            using (var sr = new StreamReader(f))
            {
                using (var sw = new StreamWriter(new FileStream(path2, FileMode.Create)))
                {
                    while (sr.Peek() >= 0) sw.WriteLine(sr.ReadLine());
                }
                // while (sr.Peek() >= 0) Console.WriteLine(sr.ReadLine());
            }
        }
    }
}