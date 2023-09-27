namespace ConsoleApp1;

public abstract class Integral
{
    public int NumberOfPoints { get; protected set; } = 100;
    public int Accuracy { get; protected set; } = 4;    // 4 знака после запятой
    
    public abstract double Calc(Func<double, double> function, double up, double low);
}