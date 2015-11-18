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

    1. 이미 만들어진 Thread에서 작동하기 때문에 Thread를 생성할 필요가 없습니다. Thread생성 비용을 줄일 수 있습니다.

    2. 프로그래밍의 복잡도가 낮아집니다. 익명함수를 만들어 Task 실행만 해주면 됩니다.

    3. 프로그래밍 복잡도가 낮아지므로써 병행 작업이 가능한 코딩이 쉽습니다. 

    4. ThreadPool의 모든 Thread가 작업중일 때는 추가 Thread가 생성이 됩니다. 이는 언덕등반오르기 알고리즘을 사용합니다.
    */

    public class TaskTest
    {
        public TaskTest()
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

        private void TaskRoofCheck()
        {
            Action DoSomething = () =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("DoSomething : {0}, ManagedThreadId : {1}, TaskID:{2}", i, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                    Thread.Sleep(10);
                }
            };

            Task t1 = new Task(DoSomething);
            Task t2 = new Task(DoSomething);

            Console.WriteLine("Starting thread... ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            t1.Start();
            t2.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main : {0}, ManagedThreadId : {1}, TaskID:{2}", i, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(10);
            }

            Console.WriteLine("Wating until thread stops... ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            t1.Wait();
            t2.Wait();

            Console.WriteLine("Finished ManagedThreadId : {0}, TaskID:{1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }
    }
}
