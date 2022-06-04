using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalAndApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TRUE  AND TRUE  = " + (true && true));
            Console.WriteLine("TRUE  AND FALSE = " + (true && false));
            Console.WriteLine("FALSE AND TRUE  = " + (false && true));
            Console.WriteLine("FALSE AND FALSE = " + (false && false));
        }
    }
}
