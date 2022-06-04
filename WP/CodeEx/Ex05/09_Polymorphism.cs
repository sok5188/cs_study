using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismApp
{
    class BaseClass
    {
        public virtual void Output()
        {
            Console.WriteLine("In the Base class ...");
        }
    }
    class DerivedClass : BaseClass
    {
        public override void Output()
        {
            Console.WriteLine("In the Derived class ...");
        }
    }
    class Program
    {
        static void Print(BaseClass obj)
        {
            obj.Output();
        }
        static void Main(string[] args)
        {
            BaseClass obj1 = new BaseClass();
            DerivedClass obj2 = new DerivedClass();
            Print(obj1);
            Print(obj2);
        }
    }
}


