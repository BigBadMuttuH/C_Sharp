namespace _008_Streams_and_Buffering;

public static class Practice
{
    public static void Ex01()
    {
        // Напишите консольную утилиту для копирования файлов
        // Пример запуска: utility.exe file1.txt file2.txt
        MyCopyFiles(@"F:\CSharp\GB\GB_CSharp\.gitignore", @"F:\CSharp\GB\GB_CSharp\.gitignore_copy");
    }

    private static void CopyFiles(string fileName1, string fileName2)
    {
        File.Copy(fileName1, fileName2);
    }

    private static void MyCopyFiles(string fileName1, string fileName2)
    {
        if (!Path.Exists(fileName1))
        {
            Console.WriteLine("Нет такого файла");
            return;
        }

        using var sr = new StreamReader(fileName1);
        using var sw = new StreamWriter(fileName2);
        sw.WriteLine(sr.ReadLine());
    }

    public static void Ex02(string arg1, string arg2)
    {
        // Напишите утилиту рекурсивного поиска файлов в заданном каталоге и подкаталогах
        var mainPath = arg1;
        var fileName = arg2;
        SomeMethod(mainPath, fileName);
    }

    private static void SomeMethod(string dir, string fileName)
    {
        var dirs = Directory.EnumerateDirectories(dir);
        var files = Directory.EnumerateFiles(dir);
        foreach (var f in files)
            if (f.Contains(fileName))
            {
                Console.WriteLine($"Искомый файл {fileName}, находится в {dir}");
                break;
            }
    }

    public static void Ex03(string path, string str)
    {
        // Напишите утилиту читающую тестовый файл и выводящую на экран строки содержащие искомое слово.
        if (!File.Exists(path)) Console.WriteLine("No file");

        using (var sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
                var value = sr.ReadLine();
                if (value.Contains(str)) Console.WriteLine(value);
            }
        }
    }
}