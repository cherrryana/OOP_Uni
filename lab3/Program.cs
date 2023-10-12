using oop_lab3;

class Program
{
    public static void Main(String[] str)
    {
        Array3d<int> array3d = new Array3d<int>(2, 3, 4);
        int[][] matrix = new int[][] { new int[] { 1, 2, 3, 4}, 
            new int[] { 5, 6, 7 }, 
            new int[] { 8, 9 } };
        int[] array = new int[] { 11, 12 };
        
        array3d.SetValues0(0, matrix);
        array3d.SetValues01(1, 2, array);
        array3d[0, 0, 0] = -11;
        
        int[,] result1 = array3d.GetValues0(0);
        for (int j = 0; j < array3d.Dim1; j++)
        {
            for (int k = 0; k < array3d.Dim2; k++)
                Console.WriteLine(result1[j, k]);
        }

        Console.WriteLine("\n");
        int[] result2 = array3d.GetValues01(1, 2);
        for (int i = 0; i < result2.Length; i++)
            Console.WriteLine(result2[i]);
    }
}
