using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingTest
{
    public class ThreadTest
    {
        Thread t1, t2;

        public void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("DoSomething : {0}, ManagedThreadId : {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }

        public ThreadTest()
        {
            t1 = new Thread(new ThreadStart(DoSomething));
            t2 = new Thread(new ThreadStart(DoSomething));

            Console.WriteLine("Starting thread... ManagedThreadId : {0}", Thread.CurrentThread.ManagedThreadId);
            t1.Start();
            t2.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main : {0}, ManagedThreadId : {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }

            Console.WriteLine("Wating until thread stops... ManagedThreadId : {0}", Thread.CurrentThread.ManagedThreadId);
            t1.Join();
            t2.Join();

            Console.WriteLine("Finished ManagedThreadId : {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }

}
