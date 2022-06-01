// See https://aka.ms/new-console-template for more information
#define CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
/// <summary>
/// 
/// </summary>
namespace Hello
{
    public class myattr : Attribute
    {
        private string message;
        public myattr(string message)
        {
            this.message = message;
        }
        public string Message { get { return message; } }
    }

   class condattr
    {
        [Conditional("CSHARP")]
        public static void csharpmethod()
        {
            Console.WriteLine("in csharp");
        }
        [Conditional("JAVA")]
        public static void javamethod()
        {
            Console.WriteLine("in java");
        }
    }
    class obsoleteattr
    {
        [Obsolete("Obsolte Method !")]
        public static void oldmethod()
        {
            Console.WriteLine("in the old");
        }
        public static void normethod()
        {
            Console.WriteLine("in the normal");
        }
    }
    // 사용자 정의 애트리뷰트 사용
    [myattr("this is myattr test")]
    class Program
    {


        static void Main(string[] args)
        {
            condattr.csharpmethod();
            // #define으로 정의했기에 실행됨
            condattr.javamethod();
            // #define으로 정의하지 않았기에 실행되지 않음


            obsoleteattr.oldmethod();
            //obsolete로 설정했기에 실행되지않음
            obsoleteattr.normethod();

            Type type = typeof(Program);
            object[] arr = type.GetCustomAttributes(typeof(myattr), true);
            if (arr.Length == 0)
                Console.WriteLine("this has no custom");
            else
            {
                myattr ma = (myattr)arr[0];
                Console.WriteLine(ma.Message);
            }
                
        
        }
    }
}
