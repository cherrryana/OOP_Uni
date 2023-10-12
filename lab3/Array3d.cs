namespace oop_lab3;

public class Array3d <T>
{
    public int Dim0 { get; }
    public int Dim1 { get; }
    public int Dim2 { get; }
    
    private T[] array3d;

    public Array3d(int dim0, int dim1, int dim2)
    {
        Dim0 = dim0;
        Dim1 = dim1;
        Dim2 = dim2;

        array3d = new T[dim0 * dim1 * dim2];
    }

    public T this[int i, int j, int k]
    {
         get =>
            (checkIndex(i, j, Dim0, Dim1) && checkIndex(k, Dim2)) ?      // в индексаторе не всегда учитывается провекра на неотрицательность индекса и на то,
                                                                          // что он меньше своего Dim, поэтому дальше везде стоят доп. проверки
                array3d[k * Dim0 * Dim1 + j * Dim0 + i] : throw new Exception("Index is out of range");
        set =>
            array3d[k * Dim0 * Dim1 + j * Dim0 + i] = (checkIndex(i, j, Dim0, Dim1) && checkIndex(k, Dim2)) ? 
                value : throw new Exception("Index is out of range");
    }

    public void SetValues0(int i, T[][] matrix)
    {
        if (checkIndex(i, Dim0))
        {
            for (int j = 0; j < matrix.Length; j++)
            {
                for (int k = 0; k < matrix[j].Length; k++)
                    this[i, j, k] = matrix[j][k];
            }
        }
    }
    
    public void SetValues1(int j, T[][] matrix)
    {
        if (checkIndex(j, Dim1))
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int k = 0; k < matrix[i].Length; k++)
                    this[i, j, k] = matrix[i][k];
            }
        }
    }
    
    public void SetValues2(int k, T[][] matrix)
    {
        if (checkIndex(k, Dim2))
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    this[i, j, k] = matrix[i][j];
            }
        }
    }

    public void SetValues01(int i, int j, T[] array)
    {
        if (checkIndex(i, j, Dim0, Dim1))
        {
            for (int k = 0; k < array.Length; k++)
                this[i, j, k] = array[k];
        }
    }
    
    public void SetValues02(int i, int k, T[] array)
    {
        if (checkIndex(i, k, Dim0, Dim2))
        {
            for (int j = 0; j < array.Length; j++)
                this[i, j, k] = array[j];
        }
    }
    
    public void SetValues12(int j, int k, T[] array)
    {
        if (checkIndex(j, k, Dim1, Dim2))
        {
            for (int i = 0; i < array.Length; i++)
                this[i, j, k] = array[i];
        }
    }

    public T[,] GetValues0(int i)
    {
        T[,] result = new T[Dim1, Dim2];

        if (checkIndex(i, Dim0))
        {
            for (int j = 0; j < Dim1; j++)
            {
                for (int k = 0; k < Dim2; k++)
                    result[j, k] = this[i, j, k];
            }
        }

        return result;
    }
    
    public T[,] GetValues1(int j)
    {
        T[,] result = new T[Dim0, Dim2];

        if (checkIndex(j, Dim1))
        {
            for (int i = 0; i < Dim0; i++)
            {
                for (int k = 0; k < Dim2; k++)
                    result[i, k] = this[i, j, k];
            }
        }

        return result;
    }
    
    public T[,] GetValues2(int k)
    {
        T[,] result = new T[Dim0, Dim1];
        
        if (checkIndex(k, Dim2))
        {
            for (int i = 0; i < Dim0; i++)
            {
                for (int j = 0; j < Dim1; j++)
                    result[i, j] = this[i, j, k];
            }
        }

        return result;
    }
    
    public T[] GetValues01(int i, int j)
    {
        T[] result = new T[Dim2];

        if (checkIndex(i, j, Dim0, Dim1))
        {
            for (int k = 0; k < Dim2; k++)
                result[k] = this[i, j, k];
        }

        return result;
    }
    
    public T[] GetValues02(int i, int k)
    {
        T[] result = new T[Dim1];

        if (checkIndex(i, k, Dim0, Dim2))
        {
            for (int j = 0; j < Dim1; j++)
                result[j] = this[i, j, k];
        }

        return result;
    }
    
    public T[] GetValues12(int j, int k)
    {
        T[] result = new T[Dim0];

        if (checkIndex(j, k, Dim1, Dim2))
        {
            for (int i = 0; i < Dim0; i++)
                result[i] = this[i, j, k];
        }

        return result;
    }

    public void npFill(T value)        // я оставила только метод npFill, т.к. в силу произвольности типа данных не думаю, что есть смысл
                                        // делать отдельные функции для заполнения массива определенным типом данных - интовым (нулями и единицами),
                                        // удобнее будет написать npFill(0) или npFill(1)
    {
        for (int i = 0; i < array3d.Length; i++)
            array3d[i] = value;
    }

    private bool checkIndex(int i, int dim)
    {
        if (i >= 0 && i < dim)
            return true;
        throw new Exception("Index is out of range");
    }

    private bool checkIndex(int i, int j, int dim0, int dim1)
    {
        if (i < dim0 && j < dim1 && i >= 0 && j >= 0)
            return true;
        throw new Exception("Index is out of range");
    }
}
