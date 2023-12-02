namespace _009_Serialization;

public class Settings
{
    public string Setting1 = "";
    public string Setting2 = "";
    public string Setting3 = "";

    public override string ToString()
    {
        return $"Settings: {Setting1}, {Setting2}, {Setting3}";
    }
}