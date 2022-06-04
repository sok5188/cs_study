using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallByObjectReferenceApp
{
    class Integer
    {
        public int i;
        public Integer(int i)
        {
            this.i = i;
        }
    }
    class Program
    {
        static void Swap(Integer x, Integer y)
        {
            int temp = x.i; x.i = y.i; y.i = temp;
            Console.WriteLine("  Swap: x = {0}, y = {1}", x.i, y.i);
        }
        static void Main(string[] args)
        {
            Integer x = new Integer(1);
            Integer y = new Integer(2);
            Console.WriteLine("Before: x = {0}, y = {1}", x.i, y.i);
            Swap(x, y);
            Console.WriteLine(" After: x = {0}, y = {1}", x.i, y.i);
        }
    }
}
