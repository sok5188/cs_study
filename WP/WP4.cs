// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace Hello
{
    interface Irectangle
    {
        void area(int w, int h);
    }
    interface Itriangle
    {
        void area(int w, int h);
    }

    class shape : Irectangle, Itriangle
    {
        void Irectangle.area(int w, int h)
        {
            Console.WriteLine("rec area :" + w * h);
        }
        void Itriangle.area(int w, int h)
        {
            Console.WriteLine("tri area"+w*h/2);
        }
    }
   

    class Program
    {

        static void Main(string[] args)
        {
           shape s=new shape();
            // s.area이렇게는 호출 불가능, s.Irectangle.area이렇게도 X
            ((Irectangle)s).area(20,20);
            //이런식으로 부르거나
            Irectangle r = s;
            //이렇게 형변환후
            r.area(20,20);
            //호출해야 함
        }
    }
}
