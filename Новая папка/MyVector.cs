
namespace lab1_oop;

public class MyVector
{
    public double X {get; private set;}
    public double Y {get; private set;}
    public double Z {get; private set;}
    public double Lenght {get; private set;}
    
    public static MyVector NullVector = new MyVector(0, 0, 0);

    public static void PrintVector(MyVector v)
    {
        Console.WriteLine($"{v.X} {v.Y} {v.Z}");
    }
    
    public MyVector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;

        Lenght = Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public MyVector(Point p1, Point p2)
    {
        X = p2.X - p1.X;
        Y = p2.Y - p1.Y;
        Z = p2.Z - p1.Z;
        
        Lenght = Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public static MyVector operator +(MyVector v1, MyVector v2)
    {
        return new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }
    
    public static MyVector operator -(MyVector v1, MyVector v2)
    {
        return new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static MyVector operator *(MyVector v1, double num)
    {
        return new(v1.X * num, v1.Y * num, v1.Z * num);
    }

    public static MyVector operator -(MyVector v1)
    {
        return new(-v1.X, -v1.Y, -v1.Z);
    }

    public static bool operator ==(MyVector v1, MyVector v2)
    {
        return Math.Abs(v1.X - v2.X) < 0.000001 
               && Math.Abs(v1.Y - v2.Y) < 0.000001 
               && Math.Abs(v1.Z - v2.Y) < 0.000001;
    }
    
    public static bool operator !=(MyVector v1, MyVector v2)
    {
        return !(Math.Abs(v1.X - v2.X) < 0.000001 
               && Math.Abs(v1.Y - v2.Y) < 0.000001 
               && Math.Abs(v1.Z - v2.Y) < 0.000001);
    }

    public static double ScalarProduction(MyVector v1, MyVector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }
    
    public static MyVector VectorProduction(MyVector v1, MyVector v2)
    {
        double coord1 = v1.Y * v2.Z - v2.Y * v1.Z;
        double coord2 = v1.Z * v2.X - v1.X * v2.Z;
        double coord3 = v1.X * v2.Y - v2.X * v1.Y;
        
        return new(coord1, coord2, coord3);
    }
    
    public static double MixedProduction(MyVector v1, MyVector v2, MyVector v3)
    {
        return ScalarProduction(v1, VectorProduction(v2, v3));
    }
    
    public static bool Сollinearity(MyVector v1, MyVector v2)
    {
        return (VectorProduction(v1, v2) == NullVector);
    }
    
    public static bool Coplanarity(MyVector v1, MyVector v2, MyVector v3)
    {
        return MixedProduction(v1, v2, v3) == 0;
    }
    
    public static double Angle(MyVector v1, MyVector v2)
    {
        return Math.Acos(ScalarProduction(v1, v2) / (v1.Lenght * v2.Lenght)) * (180/Math.PI);
    }

    public static double Distance(MyVector v1, MyVector v2)
    {
        return (new MyVector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z)).Lenght;
    }
    
}