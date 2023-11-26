namespace FileSearchUtility;

public static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: utility.exe 'directory' 'extension' 'text'.");
            return;
        }

        var directory = args[0];
        var extension = args[1];
        var searchText = args[2];

        var utility = new FileSearchUtility(extension, searchText);
        utility.SearchInDirectory(directory);
    }
}