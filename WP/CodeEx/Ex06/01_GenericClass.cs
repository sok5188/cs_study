using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassApp
{
    class SimpleGeneric<T>
    {
        private T[] values;
        private int index;

        public SimpleGeneric(int len)
        { // Constructor
            values = new T[len];
            index = 0;
        }

        public void add(params T[] args)
        {
            foreach (T e in args)
                values[index++] = e;
        }

        public void print()
        {
            foreach (T e in values)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main()
        {
            SimpleGeneric<Int32> gInteger = new SimpleGeneric<Int32>(10);
            SimpleGeneric<Double> gDouble = new SimpleGeneric<Double>(10);

            gInteger.add(1, 2);
            gInteger.add(1, 2, 3, 4, 5, 6, 7);
            gInteger.add(0);
            gInteger.print();

            gDouble.add(10.0, 20.0, 30.0);
            gDouble.print();
        }
    }
}