using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyClauseApp
{
    class Program
    {
        static int count = 0;
        public static void Main()
        {
            while (true)
            {
                try
                {
                    if (++count == 1) throw new Exception();
                    if (count == 3) break;
                    Console.WriteLine(count + ") No exception");
                }
                catch (Exception)
                {
                    Console.WriteLine(count + ") Exception thrown");
                }
                finally
                {
                    Console.WriteLine(count + ") in finally clause");
                }
            } // end while
            Console.WriteLine("Main program ends");
        }
    }
}
