using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.델리게이트");
                Console.WriteLine("2.델리게이트 람다");
                Console.WriteLine("3.Action 델리게이트(반환값이 없음)");
                Console.WriteLine("4.Func 델리게이트(반환값이 있음)");
                Console.WriteLine("5.Linq");
                Console.WriteLine("6.Thread");
                Console.WriteLine("7.Task");

                Console.WriteLine("Press Key!!");
                string result = Console.ReadLine();
                Console.Clear();

                switch (result)
                {
                    case "1": new delegateTest(); break;
                    case "2": new delegateLamdaTest(); break;
                    case "3": new actionDelegate(); break;
                    case "4": new funcDelegate(); break;
                    case "5": new linqTest(); break;
                    case "6": new ThreadTest(); break;
                    case "7": new TaskTest(); break;

                    default: return;
                }
                Console.ReadLine();
                return;
                //Console.WriteLine();
                //Console.WriteLine("===============================================");
                //Console.WriteLine();
            }
        }
    }
}
