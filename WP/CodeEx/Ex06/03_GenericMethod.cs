using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodApp
{
    class Program
    {
        static void Swap<DataType>(ref DataType x, ref DataType y) 
        {
            DataType temp;
            temp = x; 
		    x = y; 
		    y = temp;
        }
        static void Main(string[] args)
        {
            int a = 1, b = 2; double c = 1.5, d = 2.5;
            Console.WriteLine("Before: a = {0}, b = {1}", a, b);
            Swap<int>(ref a, ref b);                                // 정수형 변수로 호출
            Console.WriteLine(" After: a = {0}, b = {1}", a, b);
            Console.WriteLine("Before: c = {0}, d = {1}", c, d);
            Swap<double>(ref c, ref d);                             // 실수형 변수로 호출
            Console.WriteLine(" After: c = {0}, d = {1}", c, d);
        }
    }
}
