using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeApp
{
    class DisposeClass : IDisposable
    {
        // ...
        public void Dispose()
        {
            Console.WriteLine("In the Dispose ...");
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Main");
            using (DisposeClass obj = new DisposeClass())
            {
                // ...
            }
            Console.WriteLine("End of Main");
        }
    }
}