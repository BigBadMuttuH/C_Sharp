namespace _002_Interface;

public class BitManipulator : IBits
{
    public int SetBit(int number, int position, bool value)
    {
        if (value)
        {
            // Устанавливаем бит в 1 на указанной позиции
            return number | (1 << position);
        }
        else
        {
            // Устанавливаем бит в 0 на указанной позиции
            return number & ~(1 << position);
        }
    }

    public bool GetBit(int number, int position)
    {
        // Проверяем, установлен ли бит в 1 на указанной позиции
        return (number & (1 << position)) != 0;
    }
}
