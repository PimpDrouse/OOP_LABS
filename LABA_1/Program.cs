using System;

namespace LABA_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(2);
            
            Console.WriteLine("Введите количество строк и столбцов через ' ' или  |: ");
            string[] data = Console.ReadLine().Split(new char[] {'|', ' '}, 2);
            int nRow = Convert.ToInt32(data[0]);
            int nColumn = Convert.ToInt32(data[1]);
            Console.WriteLine("\n");
            
            int[] singleArray = new int[nRow * nColumn];
            for (int i = 0; i < nColumn*nRow; i++)
            {
                singleArray[i] = rand.Next() % 10;
                Console.Write(singleArray[i]+" |");
            }
            Console.WriteLine("\n");
            
            int[,] dualArray = new int[nRow, nColumn];
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    dualArray[i, j] = rand.Next() % 10;
                    Console.Write(dualArray[i,j]+" |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            
            int[][] jaggedArray = new int[nRow][];
            for (int i = 0; i < nRow; i++)
            {
                jaggedArray[i] = new int[nColumn];
                for (int j = 0; j < nColumn; j++)
                {
                    jaggedArray[i][j] = rand.Next() % 10;
                    Console.Write(jaggedArray[i][j]+" |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            
        }
    }
}