using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanConstantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TRUE  OR TRUE  = " + (true || true));
            Console.WriteLine("TRUE  OR FALSE = " + (true || false));
            Console.WriteLine("FALSE OR TRUE  = " + (false || true));
            Console.WriteLine("FALSE OR FALSE = " + (false || false));
        }
    }
}
