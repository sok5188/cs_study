using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemainderOperatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, rem;
            rem = 10 % 3;
            n = 10 - (10 / 3) * 3;
            Console.WriteLine("10 % 3 = " + rem);
            Console.WriteLine("10-(10/3)*3 = " + n);
        }
    }
}
