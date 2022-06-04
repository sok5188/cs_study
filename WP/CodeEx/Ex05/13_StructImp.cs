using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructImpApp
{
    interface IVector
    {
        void Insert(int n);    // 배열에 원소를 삽입한다.
        void ScalarSum(int n); // 배열에 각 원소에 스칼라 값을 더한다.
        void PrintVector();    // 배열에 있는 모든 원소를 출력한다.
    }
    struct Vector : IVector
    {
        private int[] v;
        private int index, size;
        public Vector(int size)
        {  // »ý¼ºÀÚ
            v = new int[size];
            this.size = size;
            index = 0;
        }
        public void Insert(int n)
        {
            if (index >= size)
                Console.WriteLine("Error : array overflow");
            else v[index++] = n;
        }
        public void ScalarSum(int n)
        {
            for (int i = 0; i < index; i++) v[i] += n;
        }
        public void PrintVector()
        {
            Console.Write("Contents:");
            for (int i = 0; i < index; i++)
                Console.Write(" " + v[i]);
            Console.WriteLine();
        }
    }
    class Program
    {
        public static void Main()
        {
            Vector a = new Vector(100);
            int n;
            while (true)
            {         // 0이 입력될 때까지 반복한다.
                n = Console.Read() - '0';
                if (n == 0) break;
                a.Insert(n);
            }
            a.PrintVector();
            a.ScalarSum(10);
            a.PrintVector();
        }
    }
}
