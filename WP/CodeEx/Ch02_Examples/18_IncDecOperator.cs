using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncDecOperatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3, y = 5;
            int a, b;
            ++x; --y;
            Console.WriteLine("x = " + x + " , y = " + y);
            a = (++x) + 1;
            Console.WriteLine("x = " + x + " , a = " + a);
            b = (y++) + 1;
            Console.WriteLine("y = " + y + " , b = " + b);
        }
    }
}
