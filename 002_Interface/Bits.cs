namespace _002_Interface;

public class Bits
{
    public byte Value { get; private set; }

    public Bits(byte b)
    {
        this.Value = b;
    }

    public bool this[int index]
    {
        get
        {
            // Bits
            // 0000_0100
            // 0000_0001
            // 0000_0001
            if (index > 7 || index < 0)
            {
                return false;
            }
            return ((Value >> index) & 1) == 1;
        }
        // 0000_0000
        //        | 
        // 0000_0001
        // =
        // 0000_0001
        set
        {
            if (index > 7 || index < 0)
            {
                return;
                if (value = true)
                {
                    Value = (byte)(Value | (1 << index));
                }
                else
                {
                    var mask = (byte)(1 << index);
                    mask = (byte)(0xff ^ mask);
                    Value = (byte)(Value & mask);
                }
            }
        }
    }
}