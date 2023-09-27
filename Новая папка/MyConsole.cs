namespace lab1_oop;

abstract class MyConsole
{
    private static bool points;
    
    public static void Dialog(string answerCommand)
    {
        if (answerCommand != "Стоп")
        {
            Console.WriteLine("\nВы зададите векторы по двум точкам? Да или нет");
            string answer = Console.ReadLine();
            points = answer == "Да";
            
            Input(answerCommand);
            Start();
        }
    }
    public static void Start()
    {
        Console.WriteLine("\nВведите команду (? - справка, Стоп - конец работы)");
        string answerCommand = Console.ReadLine();
        if (answerCommand == "?")
        {
            OpeartionsList();
            Start();
            return;
        }
        Dialog(answerCommand);
    }

    public static double[] MassiveRead()
    {
        return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
    }
    
    public static MyVector Read()
    {
        if (points)
        {
            Console.WriteLine("\nВведите две точки в отдельных строках, по которым задается вектор");
            double[] c1 = MassiveRead();
            double[] c2 = MassiveRead();

            Point p1 = new Point(c1[0], c1[1], c1[2]);
            Point p2 = new Point(c2[0], c2[1], c2[2]);

            return new MyVector(p1, p2);
        }
        
        Console.WriteLine("\nВведите три координаты, по которым задается вектор");
        double[] nums = MassiveRead();
        
        return new MyVector(nums[0], nums[1], nums[2]);
        
    }
    
    public static void Input(String str)
    {
        if (str == "Смешанное произведение" || str == "Компланарность")
        {
            MyVector v1 = Read();
            MyVector v2 = Read();
            MyVector v3 = Read();
            
            if (str == "Смешанное произведение")
                Console.WriteLine(MyVector.MixedProduction(v1, v2, v3));
            else Console.WriteLine(MyVector.Coplanarity(v1, v2, v3));
        }
        
        else if (str == "Длина вектора" || str == "Обратный вектор")
        {
            MyVector v = Read();
            
            if (str == "Длина вектора")
                Console.WriteLine(v.Lenght);
            else MyVector.PrintVector(-v);
        }
        
        else {
            MyVector v1 = Read();
            MyVector v2 = Read();
            
            switch (str)
            {
                case "Сложение":
                {
                    MyVector.PrintVector(v1 + v2);
                    break;
                }

                case "Вычитание":
                {
                    MyVector.PrintVector(v1 - v2);
                    break;
                }

                case "Скалярное произведение":
                {
                    Console.WriteLine(MyVector.ScalarProduction(v1, v2));
                    break;
                }
                
                case "Векторное произведение":
                {
                    MyVector.PrintVector(MyVector.VectorProduction(v1, v2));
                    break;
                }
                
                case "Коллинеарность":
                {
                    Console.WriteLine(MyVector.Сollinearity(v1, v2));
                    break;
                }
                
                case "Расстояние":
                {
                    Console.WriteLine(MyVector.Distance(v1, v2));
                    break;
                }
                
                case "Угол между векторами":
                {
                    Console.WriteLine(MyVector.Angle(v1, v2));
                    break;
                }
            }
        }
    }

    public static void OpeartionsList()
    {
        Console.WriteLine("Сложение\n" +
                          "Вычитание\n" +
                          "Скалярное произведение\n" +
                          "Векторное произведение\n" +
                          "Смешанное произведение\n" +
                          "Компланарность\n" +
                          "Коллинеарность\n" +
                          "Расстояние\n" +
                          "Угол между векторами\n" +
                          "Обратный вектор\n" +
                          "Длина вектора\n");
    }
}