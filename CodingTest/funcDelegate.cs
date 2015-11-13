using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class funcDelegate
    {
        public funcDelegate()
        {
            Func<int> func1 = () => 10;
            int result = func1();
            Console.WriteLine("func1() : {0}", result);

            Func<int, int> func2 = (x) => x * 2;
            result = func2(4);
            Console.WriteLine("func2(4) : {0}", func2(4));

            Func<double, double, int> func3 = (x, y) => (int)(x / y);
            result = func3(22, 7);
            Console.WriteLine("func3(22/7) : {0}", func3(22, 7));

            func4("사과", 4, func2);
            func4("사과", 3, (x) => x * 3);
            func4("사과", 3, (x) => x -3);
        }

        private void func4(string target, int x, Func<int, int> func)
        {
            Console.WriteLine();
            Console.WriteLine("func4 실행, 인자값: target={0}, x={1}", target, x);
            Console.WriteLine("callBack 실행");
            int result = func(x);
            Console.WriteLine("result 값 : " + result);
            Console.WriteLine();
        }
    }
}
