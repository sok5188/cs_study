using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
            char ch;
            Console.Write("Enter a super digit : "); // prompt message
            ch = (char)Console.Read();
            switch (ch)
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    value = ch - 'A' + 10; // code value => binary value
                    break;
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    value = ch - 'a' + 10; // code value => binary value
                    break;
                default: Console.WriteLine(ch + " is not a hexadigit");
                    break;
            }  // end of switch
            Console.WriteLine(value);
        }
    }
}
