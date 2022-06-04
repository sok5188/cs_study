using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHandlerApp
{
    class Program
    {
        public static void Main()
        {
            int[] vector = { 1, 2, 3 };
            try
            {
                Console.WriteLine("Here: 1");
                vector[4] = 4;
                Console.WriteLine("Here: 2");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("System Exception is occurred!!!");
            }
            Console.WriteLine("Here: 3");
        }
    }
}
