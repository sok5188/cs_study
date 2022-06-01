// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace Hello
{
    class structarr<T> where T : struct
    {
        public T[] array { get; set; }
        public structarr(int size)
        {
            array = new T[size];
        }
    }
    class refarr<T>where T : class
    {
        public T[] arr { get; set; }
        public refarr(int size)
        {
            arr= new T[size];  
        }
    }
    class Base { }
    class derived:Base { }
    class Basearr<U> where U : Base
    {
        public U[] arr { get; set; }
        public Basearr(int size)
        {
            arr = new U[size];
        }
        public void copyarr<T>(T[] Target)where T:U
        {
            Target.CopyTo(arr, 0);
        }
    }
   
   

    class Program
    {
        // 들어온 타입의 객체를 생성후 리턴
        public static T createinstance<T>() where T : new()
        {
            return new T();
        }
        static void Main(string[] args)
        {
            // struct 배열, 값형 배열
            structarr<int> a = new structarr<int>(3);
            a.array[0] = 1;
            a.array[1] = 2;
            a.array[2] = 3;
            //sturct array 객체들의 배열
            refarr<structarr<double>> b = new refarr<structarr<double>>(3);
            b.arr[0] = new structarr<double>(5);
            b.arr[1] = new structarr<double>(6);
            b.arr[2] = new structarr<double>(7);
            //base 객체들의 arr
            Basearr<Base> c = new Basearr<Base>(3);
            c.arr[0] = new Base();
            c.arr[1] = new derived();
            c.arr[2] = createinstance<Base>();

            Basearr<derived> d = new Basearr<derived>(3);
            d.arr[0] = new derived();
            d.arr[1] = createinstance<derived>();
            d.arr[2] = createinstance<derived>();

            Basearr<derived> e=new Basearr<derived>(3);
            e.copyarr<derived>(d.arr);
        }
    }
}
