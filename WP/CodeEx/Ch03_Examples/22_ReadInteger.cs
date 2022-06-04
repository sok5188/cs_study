using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIntegerApp
{
    class Program
    {
        static int ReadInt() 
	    {
		    char ch;
		    int n=0;
		    while (!char.IsDigit(ch = (char)Console.Read()));
		    do 
		    {
			    n = n*10 + (ch - '0');
			    ch = (char) Console.Read();
		    } while (char.IsDigit(ch));
		    return n;
	    }
        static void Main(string[] args)
        {
            Console.Write("*** input data : ");
			Console.WriteLine("*** read data : " +	ReadInt() + " " + ReadInt());
        }
    }
}