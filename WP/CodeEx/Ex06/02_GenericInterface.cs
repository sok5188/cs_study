using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInterfaceApp
{
    interface IGenericInterface<T>
    {
        void setValue(T x);
        string getValueType();
    }

    class GenericClass<T> : IGenericInterface<T> {
        private T value;
        public void setValue(T x) {
            value = x;
        }

        public string getValueType() {
            return value.GetType().ToString();
        }
    }

    public class Program
    {
        public static void Main()
        {
            GenericClass<Int32> gInteger = new GenericClass<Int32>();
            GenericClass<String> gString = new GenericClass<String>();

            gInteger.setValue(10);
            gString.setValue("Text");

            Console.WriteLine(gInteger.getValueType());
            Console.WriteLine(gString.getValueType());
        }
    }
}