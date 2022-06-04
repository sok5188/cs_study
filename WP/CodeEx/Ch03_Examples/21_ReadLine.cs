using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int time, hour, minute, second;
		    Console.Write("*** Enter an integral time : ");
		    time = int.Parse(Console.ReadLine());
		    hour = time / 10000;
		    minute = time / 100 % 100;
		    second = time % 100;
		    Console.WriteLine("*** Time is " + hour + ":" +	minute + ":" + second);
        }
    }
}
