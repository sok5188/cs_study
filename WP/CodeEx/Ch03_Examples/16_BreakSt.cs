using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakStApp
{
    class Program
    {   // h(n) = 1 + 1/2 + 1/3 + ... + 1/n
        static void Main(string[] args)
        {
		    int n, i;
		    double h = 0.0;
		    Console.Write("Enter a number = ");
		    n = Console.Read() - '0';
		    i = 1;
		    while (true) 
		    {
		    	h = h + 1/(double) i;
		    	if (++i > n) break;
		    }
		    Console.WriteLine(" n = " + n + ", h = " + h);
        }
    }
}
