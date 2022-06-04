using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntTypeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1000000;
            Console.WriteLine(i * i);
            long l = i;
            Console.WriteLine(l * l);
        }
    }
}
