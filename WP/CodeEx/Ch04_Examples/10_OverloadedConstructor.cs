using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedConstructorApp
{
    class Fraction
    {
        int numerator;                        // 분자 필드
        int denominator;                      // 분모 필드

        public Fraction()
        {                   // 디폴트 생성자
            numerator = 0;
            denominator = 1;
        }
        public Fraction(int n)
        {              // 생성자
            numerator = n;
            denominator = 1;
        }
        public Fraction(int n, int d)
        {      // 생성자
            numerator = n;
            denominator = d;
        }
        override public String ToString()
        {
            return (numerator + "/" + denominator);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(), f2 = new Fraction(2),
            f3 = new Fraction(1, 2);
            Console.WriteLine("f1 = {0}, f2 = {1}, f3 = {2}",
                f1, f2, f3);
        }
    }
}