using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            int m;
            Console.Write("Enter three numbers : ");
            a = Console.Read() - '0';
            b = Console.Read() - '0';
            c = Console.Read() - '0';
            m = (a > b) ? a : b;
            m = (m > c) ? m : c;
            Console.WriteLine("The largest number = " + m);
        }
    }
}
