using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadStateApp
{
    class ThreadState
    {
        public void ThreadBody()
        {
            while (true)
            {
                // ... infinite loop ...
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            ThreadState obj = new ThreadState();
            ThreadStart ts = new ThreadStart(obj.ThreadBody);
            Thread t = new Thread(ts);
            Console.WriteLine("Step 1: " + t.ThreadState);
            t.Start();
            Thread.Sleep(100);
            Console.WriteLine("Step 2: " + t.ThreadState);
            t.Suspend();
            Thread.Sleep(100);
            Console.WriteLine("Step 3: " + t.ThreadState);
            t.Resume();
            Thread.Sleep(100);
            Console.WriteLine("Step 4: " + t.ThreadState);
            t.Abort();
            Thread.Sleep(100);
            Console.WriteLine("Step 5: " + t.ThreadState);
        }
    }
}
