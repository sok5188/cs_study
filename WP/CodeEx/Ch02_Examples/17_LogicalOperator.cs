using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalOperatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3, y = 5, z = 7;
            bool b;
            b = x < y && y < z;
            Console.WriteLine("Result = " + b);
            b = x == y || x < y && y > z;
            Console.WriteLine("Result = " + b);
        }
    }
}
