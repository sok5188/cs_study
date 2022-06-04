using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTenItemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n = 25;
            for (i = 1; i <= n; ++i)
                Console.Write(i + ((i % 10 == 0 || i == n) ? "\n" : " "));
        }
    }
}
