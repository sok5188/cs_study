using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructApp
{
    struct Point
    {
        public int x, y;                      // x, y 좌표
        public Point(int x, int y)
        {          // 생성자
            this.x = x;
            this.y = y;
        }
        override public string ToString()
        {   // 메소드
            return "(" + x + ", " + y + ")";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point[] pts = new Point[3];
            pts[0] = new Point(100, 100);
            pts[1] = new Point(100, 200);
            pts[2] = new Point(200, 100);
            foreach (Point pt in pts)
                Console.WriteLine(pt.ToString());
        }
    }
}
