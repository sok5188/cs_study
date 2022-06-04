using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            /* Exmaple 1 */
            DirectoryInfo dir = new DirectoryInfo("a");
            dir.MoveTo("b");

            /* Example 2 */
            Directory.Move("a", "b");
            
            /* Example 3 */
            string[] files =
                Directory.GetFiles("a");

            foreach (string f in files)
                Console.WriteLine(f);
        }
    }
}
