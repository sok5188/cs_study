using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace TypeOfOperatorApp
{
    class Apple
    {
        public int nSeeds = 0;
        public void Ripen() { /* ... */ }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Apple);
            string className = t.ToString();
            MemberInfo[] allMembers = t.GetMembers();
            Console.WriteLine("All " + className + " Members:");
            foreach (MemberInfo member in allMembers)
            {
                Console.WriteLine(member.ToString());
            }
        }
    }
}
