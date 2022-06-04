using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivByZeroExceptionApp
{
    class Program
    {
        public static void Main()
        {
            int i = 1, j = 0, k;
            k = i / j;
        }
    }
}
