using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastOperatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0Xffff;
            short s;
            s = (short)i;
            Console.WriteLine("i = " + i);
            Console.WriteLine("s = " + s);
        }
    }
}
