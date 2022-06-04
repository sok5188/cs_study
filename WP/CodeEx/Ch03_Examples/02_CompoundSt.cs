using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompoundStApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter one digit = ");
            n = Console.Read() - '0';
            if (n < 0)
                Console.WriteLine("Negative number !");
            else
            {
                Console.WriteLine(n + " squared is " + (n * n));
                Console.WriteLine(n + " cubed is " + (n * n * n));
            }
        }
    }
}
