using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBoolApp
{
    class XBool
    {
        public bool b;
        // XBool 형을 bool 형으로 명시적으로 변환하는 연산자 중복
        public static explicit operator bool(XBool x)
        {
            Console.WriteLine("In the explicit operator bool ...");
            return x.b;
        }
        // XBool 형에 대한 true 연산자의 중복
        public static bool operator true(XBool x)
        {
            Console.WriteLine("In the operator true ...");
            return x.b ? true : false;
        }
        // XBool  형에 대한 false 연산자의 중복
        public static bool operator false(XBool x)
        {
            Console.WriteLine("In the operator false ...");
            return x.b ? false : true;
        }
    }
    class Program
    {
        public static void Main()
        {
            XBool xb = new XBool();
            xb.b = false;
            if (xb)                      // invoke operator true
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            Console.WriteLine((bool)xb); // invoke conversion-operator bool
        }
    }
}
