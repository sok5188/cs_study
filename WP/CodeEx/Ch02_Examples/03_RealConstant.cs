using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealConstantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            float f1 = 1.414F, f2 = 0.1414e01f;
            double d = 0.1414E1;
            Console.WriteLine("f1 = " + f1 + ", f2 = " + f2 +
                ", d = " + d);
            if (f1 == f2) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
