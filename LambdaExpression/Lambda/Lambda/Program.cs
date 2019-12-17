using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        delegate int Calculate(int a, int b);
        delegate string Concatenate(string[] args);
        static void Main(string[] args)
        {
            Calculate calc = (int a, int b) => a + b;
            Console.WriteLine($"3 + 4 = {calc(3, 4)}");

            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;

                return result;
            };
            Console.Write(concat(new string[] { "아버지가방에들어가신다.\n" }));

            Func<int> func1 = () => 10;
            Console.WriteLine($"func() : {func1()}");

            Func<int, int> func2 = (x) => x * 2;
            Console.WriteLine($"func2 : {func2(4)}");

            Func<double, double, double> func3 = (x, y) => x * y;
            Console.WriteLine($"func3 : {func3(4, 5)}");

            Action act1 = () => Console.Write("Action()");
            act1();

            int result2 = 0;
            Action<int> act2 = (x) => result2 = x * x;
            act2(3);
            Console.WriteLine($"result : {result2}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1,T2>({x},{y}) : {pi}");
            };
            act3(22.0, 7.0);

            Console.ReadLine();
        }
    }
}
