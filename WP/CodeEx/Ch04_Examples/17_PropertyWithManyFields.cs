using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWithManyFieldsApp
{
    class PropertyWithManyFields
    {
        private string text = "Dept. of Computer Engineering";
        private bool isModified = false;
        public string Text
        {
            get { return text; }
            set { text = value; isModified = true; }
        }
        public void PrintStatus()
        {
            Console.WriteLine("text is \"" + text + "\", and " +
                (isModified ? "is" : "not") + " modified.");
        }
    }
    class Program
    {
        public static void Main()
        {
            PropertyWithManyFields obj = new PropertyWithManyFields();
            obj.PrintStatus();
            obj.Text = "Programming Language Lab";
            obj.PrintStatus();
        }
    }
}
