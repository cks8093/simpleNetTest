using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class delegateTest
    {
        //delegate(대리자)
        public delegate int testDeleGate(int a, int b);

        //GenericDelegate(제네릭(Generic)은 클래스 내부에서 사용할 데이터 타입을 외부에서 지정하는 기법을 의미한다)
        public delegate T GenericDelegate<T>(int a, int b);

        //GenericDelegate(제네릭(Generic)은 클래스 내부에서 사용할 데이터 타입을 외부에서 지정하는 기법을 의미한다)
        public delegate T1 GenericTinputDelegate<T, T1>(T a, T1 b);


        public int Plus(int a, int b)
        {
            return a + b;
        }
        public float Plus(int a, float b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }

        public float Minus(int a, float b)
        {
            return a - b;
        }

        public int dynamicTest(int a, int b, testDeleGate testdelegate)
        {
            return testdelegate(a, b);
        }

        public T dynamicGenericTest<T>(int a, int b, GenericDelegate<T> genericdelegate) where T : IComparable
        {
            return genericdelegate(a, b);
        }

        public T1 dynamicGenericTinputTest<T, T1>(T a, T1 b, GenericTinputDelegate<T, T1> generictinputdelegate)
            where T : IComparable
            where T1 : IComparable
        {
            return generictinputdelegate(a, b);
        }

        public delegateTest()
        {
            Console.WriteLine("1.델리게이트");
            Console.WriteLine("2.제너릭 델리게이트");
            Console.WriteLine("3.제너릭 입력매개변수 델리게이트");
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
            Console.WriteLine("제너릭 입력매개변수 델리게이트 생성하여 실행");
            GenericTinputDelegate<int, float> Callback = new GenericTinputDelegate<int, float>(Plus);
            Console.WriteLine("제너릭 입력매개변수 델리게이트 Plus 값 : " + Callback(2, 3));
            Callback = new GenericTinputDelegate<int, float>(Minus);
            Console.WriteLine("제너릭 입력매개변수 델리게이트 Minus 값 : " + Callback(2, 3));
            Console.WriteLine();

            Console.WriteLine("제너릭 입력매개변수 delegate 동적으로 실행");
            Console.WriteLine("곱하기 값 : " + dynamicGenericTinputTest("안녕", "하세요", delegate(string a, string b) { return string.Format("{0}_{1}", a, b); }));
            Console.WriteLine("나누기 값 : " + dynamicGenericTinputTest(2, 3, delegate(int a, float b) { return (a / b); }));
        }

        private void delegateGenericMethod()
        {
            Console.WriteLine("제너릭delegate 생성하여 실행");
            GenericDelegate<int> Callback = new GenericDelegate<int>(Plus);
            Console.WriteLine("GenericDelegate Plus 값 : " + Callback(2, 3));
            Callback = new GenericDelegate<int>(Minus);
            Console.WriteLine("GenericDelegate Minus 값 : " + Callback(2, 3));
            Console.WriteLine();

            Console.WriteLine("제너릭delegate 동적으로 실행");
            Console.WriteLine("곱하기 값 : " + dynamicGenericTest(2, 3, delegate(int a, int b) { return (a * b).ToString(); }));
            Console.WriteLine("나누기 값 : " + dynamicGenericTest(2, 3, delegate(int a, int b) { return (a / b); }));
        }

        private void delegateMethod()
        {
            testDeleGate Callback;
            Console.WriteLine("delegate 생성하여 실행");
            Callback = new testDeleGate(Plus);
            Console.WriteLine("testDeleGate 값 : " + Callback(2, 3));

            Callback = new testDeleGate(Minus);
            Console.WriteLine("testDeleGate 값 : " + Callback(2, 3));
            Console.WriteLine();

            Console.WriteLine("delegate 동적으로 실행");
            Console.WriteLine("곱하기 값 : " + dynamicTest(2, 3, delegate(int a, int b) { return a * b; }));
            Console.WriteLine("나누기 값 : " + dynamicTest(2, 3, delegate(int a, int b) { return a / b; }));
            Console.WriteLine();
        }
    }
}
