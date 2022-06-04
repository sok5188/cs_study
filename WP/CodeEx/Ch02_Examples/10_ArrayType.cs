using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTypeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ia = new int[3];
            int[] ib = { 1, 2, 3 };
            // int[] ib = new int[] {1, 2, 3} °°Àº ÀÇ¹ÌÀÌ´Ù
            int i;
            for (i = 0; i < ia.Length; i++)
                ia[i] = ib[i];
            for (i = 0; i < ia.Length; i++)
                Console.Write(ia[i] + " ");
            Console.WriteLine();
        }
    }
}
