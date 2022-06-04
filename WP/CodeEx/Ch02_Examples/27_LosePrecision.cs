using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosePrecisionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int big = 1234567890;
            float approx;
            approx = (float)big;
            Console.WriteLine("difference = " + (big - (int)approx));
        }
    }
}
