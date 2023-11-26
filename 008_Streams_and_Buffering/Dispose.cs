namespace _008_Streams_and_Buffering;

public class Dispose
{
    public static void Ex01()
    {
        ClassWithResources obj = null;
        try
        {
            obj = new ClassWithResources();
        }
        finally
        {
            obj?.Dispose();
        }
    }

    public static void Ex02()
    {
        using (var obj = new ClassWithResources())
        {
            obj.DoSomeWork();
        }
    }
}

internal class ClassWithResources : IDisposable
{
    private ClassWithResources another;
    private bool disposedValue;

    private int handle;

    public ClassWithResources()
    {
        OpenRes();
        Console.WriteLine("Я создан!");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void OpenRes()
    {
        handle = 123;
    }

    private void CloseRes()
    {
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            if (disposing) another?.Dispose();

            another = null;
            CloseRes();
            disposedValue = true;

            Console.WriteLine("Я завершен корректно!");
        }
    }

    ~ClassWithResources()
    {
        Dispose(false);
    }

    public void DoSomeWork()
    {
        Console.WriteLine("Working");
    }
}