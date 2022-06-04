using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedIfApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int day;
            Console.Write("Enter the day number 1 ~ 7 : ");
            day = (int)Console.Read() - '0';
            if (day == 1) Console.WriteLine("Sunday");
            else if (day == 2) Console.WriteLine("Monday");
            else if (day == 3) Console.WriteLine("Tuesday");
            else if (day == 4) Console.WriteLine("Wednesday");
            else if (day == 5) Console.WriteLine("Thursday");
            else if (day == 6) Console.WriteLine("Friday");
            else if (day == 7) Console.WriteLine("Saturday");
            else Console.WriteLine("Illegal day");
        }
    }
}
