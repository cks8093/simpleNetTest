using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingTest
{
    public class TaskTest
    {
        public TaskTest()
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
