using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMatrixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] m = { { 1, 2, 3},
						 { 4, 5, 6},
						 { 7, 8, 9} };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write("m[" + i + "," + j + "]=" + m[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
