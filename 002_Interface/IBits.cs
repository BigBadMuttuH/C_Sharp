namespace _002_Interface;

public interface IBits
{
    // Установить бит на определенной позиции (position) в заданное значение (value) в числе (number)
    int SetBit(int number, int position, bool value);

    // Получить значение бита на определенной позиции (position) в числе (number)
    bool GetBit(int number, int position);
}