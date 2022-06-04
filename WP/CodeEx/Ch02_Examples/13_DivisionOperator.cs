using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionOperatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i; double x;
            i = 1 / 2;
            x = 1 / 2;
            Console.Write("i = " + i);
            Console.WriteLine(", x = " + x);
            i = (int)(1 / 2.0);
            x = 1 / 2.0;
            Console.Write("i = " + i);
            Console.WriteLine(", x = " + x);
        }
    }
}
