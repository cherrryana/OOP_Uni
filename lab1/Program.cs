using ConsoleApp1;

class Program
{
    public static void Main(string[] Args)
    {
        var integral1 = new Simpson(100, 4);
        var integral2 = new Trapezium(100, 4); 
        
        Console.WriteLine($"Метод Симпсона: {integral1.Calc(Math.Cos, Math.PI/2, 0)}");
        Console.WriteLine($"Метод Трапеции: {integral2.Calc(Math.Cos, Math.PI/2, 0)}");
    }
}