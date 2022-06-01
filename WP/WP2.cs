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
    class mile {
        public double dis;
        public mile(double dis)
        {
            this.dis = dis;
        }
        public static implicit operator mile(double d)
        {
            mile m=new mile(d);
            return m;
        }
        public static explicit operator kilo(mile m)
        {
            return m.dis * 1.609;
        }
    }
    class kilo {
        public double dis;
        public kilo(double dis)
        {
            this.dis=dis;
        }
        public static implicit operator kilo(double d)
        {
            kilo m=new kilo(d);
            return m;
        }
        public static explicit operator mile(kilo k)
        {
            return k.dis / 1.609;
        }
    }


    class Program
    {
       
        static void Main(string[] args)
        {
            kilo k = new kilo(100.0);
            mile m;
            m = (mile)k; // kilo에서 명시적 형변환 mile 한놈을 찾아봄 > 있으니 double타입 리턴 > mile객체에 할당하는 값임 > implicit mile로 형변환 하려함 >
            // implicit mile이 정의되어있음 > implicit하게 m객체 생성 후 mile객체 반환 > m에 받은 마일객체 할당
            Console.WriteLine("{0} km = {1}mile",k.dis,m.dis);
            m = 65.0;
            k = (kilo)m; // mile클래스에서 명시적 kilo형변환 > double > kilo클래스에서 묵시적 형변환 > double값을 가진 kilo객체 생성 및 k에 할당
            Console.WriteLine("{0}mile = {1}km",m.dis,k.dis);
        }
    }
}
