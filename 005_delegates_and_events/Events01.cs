namespace _005_delegates_and_events;

public class MyEventArgs : EventArgs
{
    public string? Message { get; set; }
}

public delegate void MyEventHandler(object sendler, MyEventArgs args);

internal class ClassWriteEvents
{
    public event MyEventHandler SomeEvent;

    public void OnSomeEvent(MyEventArgs args)
    {
        SomeEvent?.Invoke(this, args);
    }

    public void DoSomeWork()
    {
        new Thread(
            () =>
            {
                Thread.Sleep(10_000);
                OnSomeEvent(new MyEventArgs { Message = "Все!" });
            }
        ).Start();
    }
}

public class Events01
{
    public static void Ex01()
    {
        var c = new ClassWriteEvents();
        c.SomeEvent += C_SomeEvent;

        c.DoSomeWork();
        Console.WriteLine("Запущено на выполнение");
        Console.ReadLine();
        c.SomeEvent -= C_SomeEvent;
    }

    private static void C_SomeEvent(object sender, MyEventArgs args)
    {
        Console.WriteLine("Событие от класса " + sender + "Сообщающее " + args.Message);
    }
}