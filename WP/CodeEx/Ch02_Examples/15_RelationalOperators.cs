using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalOperatorsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3, y = 5, z = 7;
            bool b1, b2;
            b1 = x > y;
            b2 = x < y && y < z;
            Console.WriteLine("b1 = " + b1 + ", b2 = " + b2);
            b1 = x <= y;
            b2 = x >= y == y >= x;
            Console.WriteLine("b1 = " + b1 + ", b2 = " + b2);
        }
    }
}
