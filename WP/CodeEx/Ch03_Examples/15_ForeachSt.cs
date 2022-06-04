using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeachStApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] color = { "red", "green", "blue" };
            foreach (string s in color)
                Console.WriteLine(s);
        }
    }
}
