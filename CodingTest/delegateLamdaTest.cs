using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{

    public class delegateLamdaTest
    {
        /*
          람다 식은 대리자 또는 식 트리 형식을 만드는 데 사용할 수 있는 익명 함수입니다.  
          람다 식을 사용하여 인수로 전달되거나 함수 호출 값으로 반환되는 로컬 함수를 쓸 수 있습니다. 
          람다 식은 LINQ 쿼리 식을 작성하는 데 특히 유용합니다. 
        */

        //delegate(대리자)
        public delegate int testDeleGate(int a, int b);

        //GenericDelegate(제네릭(Generic)은 클래스 내부에서 사용할 데이터 타입을 외부에서 지정하는 기법을 의미한다)
        public delegate T GenericDelegate<T>(int a, int b) where T : IComparable;

        //GenericDelegate(제네릭(Generic)은 클래스 내부에서 사용할 데이터 타입을 외부에서 지정하는 기법을 의미한다)
        public delegate T1 GenericTinputDelegate<T, T1>(T a, T1 b)
            where T : IComparable
            where T1 : IComparable;

        public delegateLamdaTest()
        {
            Console.WriteLine("1.델리게이트 람다");
            Console.WriteLine("2.제너릭 델리게이트 람다");
            Console.WriteLine("3.제너릭 입력매개변수 델리게이트 람다");
            Console.WriteLine("Press Key!!");

            switch (Console.ReadLine())
            {
                case "1": delegateMethod(); break;
                case "2": delegateGenericMethod(); break;
                case "3": delegateTinputGenericMethod(); break;
                default: return;
            }
        }
        private void delegateTinputGenericMethod()
        {
            Console.WriteLine("제너릭 입력매개변수 델리게이트 람다 생성하여 실행");
            GenericTinputDelegate<int, string> Callback = (a, b) => a + b;
            Console.WriteLine("제너릭 입력매개변수 델리게이트 Plus 값 : " + Callback(2, "입니다."));
            Callback = (a, b) => {
                int result = (a + 9);
                return string.Format("{0} : {1} + 9 = {2}", b, a, result);
            };
            Console.WriteLine(Callback(2, "산수식"));
        }

        private void delegateGenericMethod()
        {
            Console.WriteLine("제너릭delegate 람다 실행");
            GenericDelegate<int> Callback = (a, b) => a + b;
            Console.WriteLine("GenericDelegate Plus 값 : " + Callback(2, 3));
            GenericDelegate<string> Callback1 = (a, b) => string.Format("{0} + {1} = {2}", a, b, (a + b));
            Console.WriteLine("GenericDelegate Minus 값 : " + Callback1(2, 3));
            Console.WriteLine();
        }

        private void delegateMethod()
        {

            Console.WriteLine("1.델리게이트 람다");
            testDeleGate testdelegate = (a, b) => a + b;
            Console.WriteLine("더하기 값 : " + testdelegate(2, 3));
            testdelegate = (a, b) => a * b;
            Console.WriteLine("곱하기 값 : " + testdelegate(2, 3));
            Console.WriteLine();
        }
    }
}
