using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWithoutFieldApp
{
    class PropertyWithoutField
    {
        public string Message
        {
            get { return Console.ReadLine(); }
            set { Console.WriteLine(value); }
        }
    }
    class Program
    {
        public static void Main()
        {
            PropertyWithoutField obj = new PropertyWithoutField();
            obj.Message = obj.Message;
        }
    }
}
