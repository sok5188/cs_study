using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlingApp
{
    public delegate void MyEventHandler();                      // 1. 이벤트를 위한 델리게이트 정의
    class Button
    {
        public event MyEventHandler Push;                       // 2. 이벤트 선언
        public void OnPush()
        {
            if (Push != null)
                Push();                                         // 5. 이벤트 발생
        }
    }
    class EventHandlerClass
    {
        public void MyMethod()                                  // 3. 이벤트 처리기 작성
        {            
            Console.WriteLine("In the EventHandlerClass.MyMethod ...");
        }
    }
    class Program
    {
        public static void Main()
        {
            Button button = new Button();
            EventHandlerClass obj = new EventHandlerClass();
            button.Push += new MyEventHandler(obj.MyMethod);    // 4. 등록
            button.OnPush();
        }
    }
}
