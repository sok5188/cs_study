using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompoundAssignmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y = 2;
            x = 10; x += y; Console.Write("\t1. x = " + x + ",");
            x = 10; x -= y; Console.Write("\t2. x = " + x + ",");
            x = 10; x *= y; Console.Write("\t3. x = " + x + ",");
            x = 10; x /= y; Console.Write("\t4. x = " + x + ",");
            x = 10; x %= y; Console.WriteLine("\t5. x = " + x);

            x = 10; x &= y; Console.Write("\t6. x = " + x + ",");
            x = 10; x |= y; Console.Write("\t7. x = " + x + ",");
            x = 10; x ^= y; Console.Write("\t8. x = " + x + ",");
            x = 10; x <<= y; Console.Write("\t9. x = " + x + ",");
            x = 10; x >>= y; Console.WriteLine("\t10. x = " + x);
        }
    }
}
