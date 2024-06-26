using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть зубчастий масив:");
        int[][] jaggedArray = InputJaggedArray();

        Console.WriteLine("\nПочатковий зубчастий масив:");
        PrintJaggedArray(jaggedArray);

        jaggedArray = RemoveRowsWithZeros(jaggedArray);

        Console.WriteLine("\nЗубчастий масив після видалення рядків з нулями:");
        PrintJaggedArray(jaggedArray);
    }

    public static int[][] RemoveRowsWithZeros(int[][] jaggedArray)
    {
        if (jaggedArray == null || jaggedArray.Length == 0)
            return jaggedArray;

        int newSize = 0;
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (!jaggedArray[i].Contains(0))
            {
                jaggedArray[newSize] = jaggedArray[i];
                newSize++;
            }
        }

        if (newSize < jaggedArray.Length)
        {
            Array.Resize(ref jaggedArray, newSize);
        }

        return jaggedArray;
    }

    static int[][] InputJaggedArray()
    {
        Console.WriteLine("Введіть кількість рядків:");
        int rows = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"Введіть елементи для рядка {i + 1} (розділені пробілами):");
            string[] input = Console.ReadLine().Split(' ');
            jaggedArray[i] = Array.ConvertAll(input, int.Parse);
        }

        return jaggedArray;
    }

    static void PrintJaggedArray(int[][] jaggedArray)
    {
        foreach (var row in jaggedArray)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }
}