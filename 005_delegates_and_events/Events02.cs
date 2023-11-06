namespace _005_delegates_and_events;

public class SensorEventArgs : EventArgs
{
    public int Data { get; set; }
}
// Есть предопределенный обобщенный дженерик. См строку - 14
// public delegate void SensorEventHandler(object sender, SensorEventArgs args);

internal class Sensor
{
    public int Number { get; set; }

    public event EventHandler<SensorEventArgs> SomeEvent;

    // public event SensorEventHandler SomeEvent;

    protected void OnSomeEvent(SensorEventArgs args)
    {
        SomeEvent?.Invoke(this, args);
    }

    public void DoSomeWork()
    {
        new Thread(
            () =>
            {
                var x = new Random().Next(5_000);
                Thread.Sleep(x);
                OnSomeEvent(new SensorEventArgs { Data = x });
            }).Start();
    }
}

public class Events02
{
    public static void Ex01()
    {
        var list = new List<Sensor>();
        for (var i = 0; i <= 10; i++)
        {
            var sensor = new Sensor { Number = i };
            sensor.SomeEvent += C_SomeEvent;
            list.Add(sensor);
            sensor.DoSomeWork();
        }

        Console.WriteLine("Запущено на выполнение");
        Console.ReadLine();

        foreach (var s in list) s.SomeEvent -= C_SomeEvent;
    }

    private static void C_SomeEvent(object sender, SensorEventArgs args)
    {
        Console.WriteLine("Событие от класса Sensor " + (sender as Sensor)?.Number + ", = " + args.Data);
    }
}