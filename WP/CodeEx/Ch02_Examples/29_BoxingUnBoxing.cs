using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnBoxingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int foo = 526;
            object bar = foo;          // foo is boxed to bar.
            Console.WriteLine(bar);
            try
            {
                double d = (short)bar;
                Console.WriteLine(d);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e + "Error");
            }
        }
    }
}
