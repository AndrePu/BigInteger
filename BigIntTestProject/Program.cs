using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography;

namespace BigIntTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -155;
            
            BigInt number1 = new BigInt(Console.ReadLine());
            BigInt number2 = new BigInt(Console.ReadLine());

            //BigInt number3 = number1 * number2;

            //Console.WriteLine($"{number1} * {number2} = {number3.ToString()}");

            Console.WriteLine($"{number1} < {number2} - {number1 < number2}");
            Console.WriteLine($"{number1} > {number2} - {number1 > number2}");
            Console.WriteLine($"{number1} == {number2} - {number1 == number2}");
            Console.WriteLine($"{number1} != {number2} - {number1 != number2}");
            Console.WriteLine($"{number1} >= {number2} - {number1 >= number2}");
            Console.WriteLine($"{number1} <= {number2} - {number1 <= number2}");

            Console.ReadKey();
        }
    }
}
