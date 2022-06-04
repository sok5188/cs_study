using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForbiddenApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool f = false, b;
            b = f;
            Console.WriteLine("f = " + f + ", b = " + b);
            // int i;
            // i = f;           // 에러 : 묵시적 형변환 금지
            // i = (short)f;    // 에러 : 명시적 형변환 금지
        }
    }
}
