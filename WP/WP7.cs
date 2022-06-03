// See https://aka.ms/new-console-template for more information
#define CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
/// <summary>
/// 
/// </summary>
namespace Hello
{
   
    class Program
    {
        
            static bool isprime(long num)
            {
                if(num<2)
                    return false;
                if (num % 2 == 0 && num != 2)
                    return false;
                for(long i=2;i<num;i++)
                {
                    if(num%i== 0)
                        return false;
                }
                return true;
            }
        
        static void Main(string[] args)
        {
            long from = 2; // 입력하기 싫엉 Convert.ToInt64(args[0]); // 부터
            long to = 10;//입력하기 싫엉 Convert.ToInt64(args[1]);  //~까지
            int taskcnt = 2; // Convert.ToInt32(args[2]);   // task숫자 설정
            List<long> result = new List<long>();
            /*
                        Func<object, List<long>> findprime = (objrange) =>
                         {
                             long[] range = (long[])objrange;
                             List<long> found = new List<long>();
                             for (long i = range[0]; i <= range[1]; i++)
                             {
                                 if (isprime(i))
                                     found.Add(i);
                             }
                             return found;
                         };
                        Task<List<long>>[] tasks = new Task<List<long>>[taskcnt];
                        long currentfrom = from;
                        long currentto = to/tasks.Length;
                        for (int i = 0; i < tasks.Length; i++)
                        {
                            Console.WriteLine("Taks[{0}]: {1} ~ {2}", i, currentfrom, currentto);
                            tasks[i] = new Task<List<long>>(findprime, new long[] { currentfrom, currentto });
                            currentfrom = currentto + 1;
                            if (i == tasks.Length - 2)
                                currentto = to;
                            else
                                currentto = currentto + (to / tasks.Length);

                        }
                        foreach(Task<List<long>> task in tasks)
                            task.Start();

                        foreach(Task<List<long>> task in tasks)
                        {
                            task.Wait();
                            result.AddRange(task.Result.ToArray());
                        }*/
            //이 줫내게 긴식을 parallel.for을 이용하면
            Parallel.For(2,100, (long i) =>
            {
                if (isprime(i))
                    result.Add(i);
                Console.WriteLine("parallel executed");
            });
            //이거 병렬스레드가 끝나기전에 메인이 끝나버려서 제대로 실행이 안된다
            Console.WriteLine("Prime number between {0}and {1}: {2}",from,to,result.Count);
            foreach (long i in result)
                Console.WriteLine("{0} is prime", i);
        
        }
    }
}