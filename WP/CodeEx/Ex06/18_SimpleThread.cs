using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThreadApp
{
    class Program
    {
        static void ThreadBody()                            // --- 1
        {                       
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(DateTime.Now.Second + " : " + i);
                Thread.Sleep(1000);
            }
        }
        public static void Main()
        {
            ThreadStart ts = new ThreadStart(ThreadBody);   // --- 2
            Thread t = new Thread(ts);                      // --- 3
            Console.WriteLine("*** Start of Main");
            t.Start();                                      // --- 4
            Console.WriteLine("*** End of Main");
        }
    }
}
