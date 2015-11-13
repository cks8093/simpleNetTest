using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class actionDelegate
    {
        //delegate(대리자)
        public delegate int testDeleGate(int a, int b, int result);


        public int Plus(int a, int b, int result)
        {
            result = a + b;
            Console.WriteLine("델리게이트 result : " + result);
            return result;
        }

        public actionDelegate()
        {
         /*
         Action은 반환값과 인자값이 없는 함수 포인터 ( 델리게이트 )
         반환 형식이 없음
         */
            int result = 0;
            Action<int, int> act1 = (a, b) =>
            {
                result = a + b;
                Console.WriteLine("Action 델리게이트 result : " + result);
            };

            testDeleGate Callback = new testDeleGate(Plus);
            Console.WriteLine("delegate 실행");
            Callback(2, 3, result);
            Console.WriteLine("result 값 : " + result);
            Console.WriteLine();
            Console.WriteLine("action delegate 실행");
            act1(2, 3);
            Console.WriteLine("result 값 : " + result);
            Console.WriteLine();

            //callBack
            act2(2, 3, act1);
            Console.WriteLine("result 값 : " + result);
            act2(2, 3, (a, b) =>
            {
                result = a - b;
                Console.WriteLine("{0} = {1} - {2}", result, a, b);
            });
            Console.WriteLine("result 값 : " + result);
            act2(2, 3, (a, b) =>
            {
                result = a * b;
                Console.WriteLine("{0} = {1} * {2}" , result, a, b);
            });
            Console.WriteLine("result 값 : " + result);
            act2(2, 3, (a, b) =>
            {
                result = a + b;
                Console.WriteLine("{0} = {1} + {2}", result, a, b);
            });
            Console.WriteLine("result 값 : " + result);
        }

        //callBack
        private void act2(int a, int b, Action<int, int> act1)
        {
            Console.WriteLine();
            Console.WriteLine("act2 실행, 인자값: a={0}, b={1}", a, b);
            Console.WriteLine("callBack 실행");
            act1(a, b);
            Console.WriteLine();
        }
    }
}
