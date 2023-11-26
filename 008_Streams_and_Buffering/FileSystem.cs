namespace _008_Streams_and_Buffering;

public static class FileSystem
{
    public static DirectoryInfo? GetProjectRoot()
    {
        var names = new Stack<string>(new[] { "bin", "Debug", "net7.0" });

        var current = Directory.GetCurrentDirectory();
        // var parent = Directory.GetParent(current);
        // Console.WriteLine(current);
        // Console.WriteLine(parent);
        var di = new DirectoryInfo(current);

        while (names.Count > 0)
        {
            var expected = names.Pop();
            if (di?.Name == expected)
                di = di.Parent;
            else
                return null;
        }

        return di;
    }

    private static bool ContainsExtension(DirectoryInfo dir, string[] extensions)
    {
        var set = new HashSet<string>(extensions);

        foreach (var f in dir.GetFiles())
            // Console.WriteLine(f.Extension);
            set.Remove(f.Extension);

        return set.Count == 0;
    }

    private static void DrawDirectoryInfo(DirectoryInfo dir)
    {
        foreach (var d in dir.GetDirectories())
        {
            var dirname = $"[{d.Name}]".PadRight(40);
            Console.WriteLine(dirname + $" <{CalculateDirSize(d)}>");
        }

        foreach (var f in dir.GetFiles())
            Console.WriteLine($"{f.Name.PadRight(40)}: {f.Length.ToString().PadRight(6)} byte");
    }

    private static long CalculateDirSize(DirectoryInfo dir)
    {
        long size = 0;

        foreach (var d in dir.GetDirectories()) size += CalculateDirSize(d);

        foreach (var f in dir.GetFiles()) size += f.Length;

        return size;
    }

    // static void ListDictionary(DirectoryInfo dir)
    private static void ListDictionary(string dir)
    {
        // foreach (var d in dir.GetDirectories())
        // foreach (var d in Directory.EnumerateDirectories(dir, "ob*"))
        foreach (var d in Directory.EnumerateFiles(dir, "*.cs")) Console.WriteLine(d);
    }

    public static void Ex03()
    {
        var res = GetProjectRoot();
        if (res == null)
        {
            Console.WriteLine("Не удалось найти каталог проекта");
            return;
        }
        // foreach (var f in res.EnumerateFiles()) Console.WriteLine(f);

        if (ContainsExtension(res, new[] { ".csproj", ".cs" }))
        {
            Console.WriteLine("Нашли!");
            DrawDirectoryInfo(res);
        }
    }

    public static void Ex04()
    {
        var current = Directory.GetCurrentDirectory();
        // Directory.CreateDirectory(current + "/1/2/3");
        // ListDictionary(new DirectoryInfo(current + "/1"));
        // Console.WriteLine(Path.DirectorySeparatorChar); // символ разделения каталога
        // Directory.Delete(current + "/1/2", true);
        // ListDictionary(new DirectoryInfo(current));
        ListDictionary(current + "/../../../");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Program.cs");
        Console.WriteLine(path);
        Console.WriteLine(Path.GetFullPath("Program.cs"));
    }

    public static void Ex05()
    {
        // File.AppendAllLines("demo.txt", new string[] { "1", "2", "3" }, Encoding.UTF8);
        // File.Create("demo1.txt");
        // var text = File.ReadAllLines("demo.txt", Encoding.UTF8);
        // text.ToList().ForEach(Console.WriteLine);
        // File.Delete("demo.txt");
        // File.Delete("demo1.txt");
    }
}