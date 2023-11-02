namespace _005_delegates_and_events;

public class SencorEventArgs : EventArgs
{
    public int Data { get; set; }
}
// Есть предопределенный обобщенный дженерик. См строку - 14
// public delegate void SensorEventHadler(object sender, SencorEventArgs args);

class Sensor
{
    public int Number { get; set; } = 0;

    public event EventHandler<SencorEventArgs> SomeEvent;
    
    // public event SensorEventHadler SomeEvent;

    protected void OnSomeEvent(SencorEventArgs args)
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
                OnSomeEvent(new SencorEventArgs {Data = x});
            }).Start();
    }
}

public class Events02
{
    public static void Ex01()
    {
        List<Sensor> list = new List<Sensor>();
        for (int i = 0; i <= 10; i++)
        {
            var sensor = new Sensor() {Number = i };
            sensor.SomeEvent += C_SomeEvent;
            list.Add(sensor);
            sensor.DoSomeWork();
        }

        Console.WriteLine("Запущено на выполнение");
        Console.ReadLine();
        
        foreach (var s in list)
        {
            s.SomeEvent -= C_SomeEvent;
        }
    }
    private static void C_SomeEvent(object sender, SencorEventArgs args)
    {
        Console.WriteLine("Событие от класса Sensor " + (sender as Sensor)?.Number + ", = " + args.Data); 
    }
}