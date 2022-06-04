using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingInterfaceApp
{
    interface IRectangle
    {
        void Area(int width, int height);
    }
    interface ITriangle
    {
        void Area(int width, int height);
    }
    class Shape : IRectangle, ITriangle
    {
        void IRectangle.Area(int width, int height)
        {
            Console.WriteLine("Rectangle Area : " + width * height);
        }
        void ITriangle.Area(int width, int height)
        {
            Console.WriteLine("Triangle Area : " + width * height / 2);
        }
    }
    class Program
    {
        public static void Main()
        {
            Shape s = new Shape();
            // s.Area(10, 10);             // error - ambiguous !!!
            // s.IRectangle.Area(10, 10);  // error
            // s.ITriangle.Area(10, 10);   // error
            ((IRectangle)s).Area(20, 20);  // 캐스팅-업
            ((ITriangle)s).Area(20, 20);   // 캐스팅-업
            IRectangle r = s;              // 인터페이스로 캐스팅-업
            ITriangle t = s;               // 인터페이스로 캐스팅-업
            r.Area(30, 30);
            t.Area(30, 30);
        }
    }
}
