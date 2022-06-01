// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace Hello {
    class xbool
    {
        public bool b;
        public static implicit operator bool(xbool x)
        {
            Console.WriteLine("in the implicit operator bool");
            return x.b;

        }
        public static bool operator true(xbool x)
        {
            Console.WriteLine("in the oprator true");
            return x.b ? true : false;
        }
        public static bool operator false(xbool x)
        {
            Console.WriteLine("in the oprator false");
            return x.b ? false : true;
        }
    }
    class Program
    {
       //1순위로 implicit하게 정의된 bool이 있는지 확인
       //2순위로 true
       // implicit 하게 bool을 정의하면 (bool)xb를 할 수 없는데 이상하게 된다..
        static void Main(string[] args)
        {
            xbool xb = new xbool();
            xb.b = false;
            if (xb)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            Console.WriteLine(xb);
        }
    }
}
