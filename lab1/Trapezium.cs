namespace ConsoleApp1;

public class Trapezium : Integral
{
    public Trapezium(int numberOfPoints, int accuracy)
    {
        if (accuracy <= 0 || numberOfPoints <= 0)
            throw new Exception("Некорректные данные");
        
        NumberOfPoints = numberOfPoints;
        Accuracy = accuracy;
    }

    public override double Calc(Func<double, double> function, double up, double low)
    {
        double width = (up - low) / NumberOfPoints;
        double result = 0;

        for (int step = 0; step < NumberOfPoints; step++)
        {
            double odd = low + step * width;
            double even = low + (step + 1) * width;

            result += 0.5 * (even - odd) * (function(odd) + function(even));
        }
        
        return Math.Round(result, Accuracy);
    }
}