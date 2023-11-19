namespace Calculator;

public interface ICalculate
{
    double Result { get; set; }
    string Expression { get; }
    void Sum(double x);
    void Sub(double x);
    void Multiply(double x);
    void Divide(double x);
    void CancelLast();

    event EventHandler<EventArgs> MyEventHandler;
}