using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp
{
    class Fraction
    {
        private int numerator;
        private int denominator;
        private int[] array;

        public Fraction(int size)
        {
            array = new int[size];
        }
        public int[] Array
        {
            get { return array; }
            set { array = value;  }
        }
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }
        override public string ToString()
        {
            return (numerator + "/" + denominator);
        }
    }
    class Program
    {
        public static void Main()
        {
            Fraction f = new Fraction(3); int i;
            f.Numerator = 1;   // invoke set-accessor in Numerator
            i = f.Numerator + 1; // invoke get-accessor in Numerator
            f.Denominator = i; // invoke set-accessor in Denominator
            Console.WriteLine(f.ToString());
            for (i = 0; i < f.Array.Length; i++)
            {
                f.Array[i] = i;
                Console.Write(f.Array[i] + " ");
            }
        }
    }
}
