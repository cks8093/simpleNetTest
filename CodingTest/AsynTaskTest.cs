using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingTest
{
    /*
    Task는 C#에서 비동기 작업을 작성하기 위한 코드를 단순화 시켜줍니다. Task는 닷넷프레임워크에서 제공하는 ThreadPool에서 작동합니다. 아쉽지만 Task를 사용할 때는 순서나 시작 시점을 사용자가 지정할 수 없습니다. 즉, Task는 어떠한 비동기 작업을 수행한다라고만 지정해 줄 뿐 수행에 대한 컨트롤을 하기 어렵습니다. 그런데 Task를 왜 쓰냐면 아래와 같습니다. 
    */

    public class AsynTaskTest
    {
        public AsynTaskTest()
        {
            Console.WriteLine("Starting 호출자... ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            TaskRoofCheck();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Wating 호출자... : {0}, ManagedThreadId : {1}, TaskID:{2}", i, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(10);
            }
            Console.WriteLine("Finished 호출자... ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        private async void TaskRoofCheck()
        {
            Func<string, string> DoSomething = (T) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("InputValue : {3}, DoSomething : {0}, ManagedThreadId : {1}, TaskID:{2}", i, Thread.CurrentThread.ManagedThreadId, Task.CurrentId, T);
                    Thread.Sleep(50);
                }
                return "async TaskRoofCheck 성공";
            };

            Console.WriteLine("Starting thread... ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Task<string> t1 = Task<string>.Run(() => DoSomething("t1"));
            Task<string> t2 = Task<string>.Run(() => DoSomething("t2"));
            string result1 = await t1;
            Console.WriteLine("result1 : {0}", result1);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main : {0}, ManagedThreadId : {1}, TaskID:{2}", i, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(10);
            }
            string result2 = await t2;
            Console.WriteLine("result2 : {0}", result2);

            Console.WriteLine("Wating until thread stops... ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Console.WriteLine("Finished ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }
    }
}
