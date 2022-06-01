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
    class baseclass
    {
        protected int a;
        protected int b;
        public baseclass()
        {
            Console.WriteLine("base construct1");
            a = 1;
            b= 2;
        }
        public baseclass(int a, int b)
        {
            Console.WriteLine("base construct2");
            this.a = a;
            this.b = b;

        }
        public void methodA()
        {
            Console.WriteLine("in the base");
        }
        //virtual 사용 = 파생클래스에서 오버라이드 할것임을 의미
        virtual public void methodB()
        {
            Console.WriteLine("base method B");
        }
    }
    class derivedclass:baseclass
    {
        new int a = 3;
        new double b = 4.5;
        public int c;
        public derivedclass()
        {
            Console.WriteLine("derived construct1");
            c = 1;
        }
        public derivedclass(int a,int b,int c):base(a,b)
        {
            Console.WriteLine("derived construct2");
            this.c = c;
        }
        public void output()
        {
            Console.WriteLine("baseclass : a={0}, derived class a={1}, c ={2}", base.a, a,c);
            Console.WriteLine("base class b={0}, derived class b={1}",base.b, b);
        }
        //new 를 붙여도 되고 안붙여도 된다. new를 붙이면 그냥 redefine했다는 뜻
        //베이스의 메소드a가 하이딩 된다.
        new public void methodA() 
        {
            Console.WriteLine("in the derived"); 
            // 여기서 base.methodA(); 호출가능
        }
        public void methodA(int i)
        {
            Console.WriteLine("int the derived");
        }
        public override void methodB()
        {
            Console.WriteLine("derived method B");
            base.methodB();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            derivedclass obj1 = new derivedclass();
            derivedclass obj2 = new derivedclass(9,7,3);
            obj1.output();
            obj2.output();

            baseclass obj3 = new baseclass();
            derivedclass obj4 = new derivedclass();
            obj3.methodA();
            obj4.methodA();
            obj4.methodA(1);
            baseclass obj5;
            obj5=(baseclass)obj4;
            obj5.methodA();

            baseclass obj6=new derivedclass();
            obj6.methodB();
        }
    }
}
