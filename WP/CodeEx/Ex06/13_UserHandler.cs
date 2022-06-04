using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHandlerApp
{
    class UserExceptionOne : ApplicationException { }
    class UserExceptionTwo : ApplicationException { }
    class Program
    {
        static void Method(int i)
        {
            if (i == 1) throw new UserExceptionOne();
            else throw new UserExceptionTwo();
        }
        public static void Main()
        {
            try
            {
                Console.WriteLine("Here: 1");
                Method(2);
                Console.WriteLine("Here: 2");
            }
            catch (UserExceptionOne)
            {
                Console.WriteLine("UserExceptionOne is occurred!!!");
            }
            catch (UserExceptionTwo)
            {
                Console.WriteLine("UserExceptionTwo is occurred!!!");
            }
            Console.WriteLine("Here: 3");
        }
    }
}
