using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfArrayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arrayOfArray = new int[3][];
            int i, j;

            for (i = 0; i < arrayOfArray.Length; i++)
                 arrayOfArray[i] = new int[i+3];
            for (i = 0; i < arrayOfArray.Length; i++)
                for (j = 0; j < arrayOfArray[i].Length; j++)
                     arrayOfArray[i][j] = i*arrayOfArray[i].Length+j;

            for (i = 0; i < arrayOfArray.Length; i++) {
                for (j = 0; j < arrayOfArray[i].Length; j++)
                     Console.Write(" "+arrayOfArray[i][j]);
                Console.WriteLine();
            }
        }
    }
}
