namespace _008_Streams_and_Buffering;

public class MemoryStreams
{
    public static void Ex01()
    {
        var bytes = new byte[180];
        for (var i = 0; i < 100; i++) bytes[i] = (byte)i;

        using (var stream = new MemoryStream(bytes))
        {
            using (var ms = new MemoryStream())
            {
                var b = 0;
                while ((b = stream.ReadByte()) >= 0) ms.WriteByte((byte)b);

                var bytest = ms.ToArray();

                foreach (var b1 in bytest) Console.Write(b1 + " ");
            }
        }
    }
}