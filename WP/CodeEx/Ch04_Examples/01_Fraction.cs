using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionApp
{
    class Fraction
    {
        int numerator;                              // 분자 필드
        int denominator;                            // 분모 필드
        public Fraction(int num, int denom) {       // 생성자
            numerator = num;
            denominator = denom;
        }
        public void PrintFraction() {               // 출력 메소드
            Console.WriteLine(numerator + "/" + denominator);
        }
    }
    class Program {
        static void Main(string[] args) {
            Fraction f = new Fraction(1, 2);
            f.PrintFraction();
        }
    }
}
