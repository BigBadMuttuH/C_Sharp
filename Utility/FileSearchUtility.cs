namespace FileSearchUtility;


class FileSearchUtility
{
    private readonly string _extension;
    private readonly string _searchText;

    public FileSearchUtility(string extension, string searchText)
    {
        this._extension = extension;
        this._searchText = searchText;
    }

    public void SearchInDirectory(string directory)
    {
        try
        {
            var files = Directory.EnumerateFiles(directory, $"*.{this._extension}");
            foreach (var file in files)
            {
                SearchFile(file);
            }

            var directories = Directory.EnumerateDirectories(directory);
            foreach (var dir in directories)
            {
                SearchInDirectory(dir);
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"IO Error in directory {directory}: {ioEx.Message}");
        }
        catch (UnauthorizedAccessException uaEx)
        {
            Console.WriteLine($"Access denied to directory {directory}: {uaEx.Message}");
        }
    }

    private void SearchFile(string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BufferedStream bufferedStream = new BufferedStream(fileStream))
        using (StreamReader streamReader = new StreamReader(bufferedStream))
        {
            string? line;
            int lineNumber = 1;
            bool found = false;

            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(this._searchText))
                {
                    if (!found)
                    {
                        Console.WriteLine($"Found in file: {filePath}");
                        found = true;
                    }
                    Console.WriteLine($"Line {lineNumber}: {line}");
                }
                lineNumber++;
            }
        }
    }
}
