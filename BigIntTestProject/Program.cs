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
            BigInt number1 = 115;
            BigInt number2 = (BigInt)"200";

            BigInt mult_result = number1 * number2;
            Console.WriteLine($"{number1} * {number2} = {mult_result.ToString()}");

            BigInt add_result = number1 + number2;
            Console.WriteLine($"{number1} + {number2} = {add_result.ToString()}");

            BigInt minus_result = number1 - number2;
            Console.WriteLine($"{number1} - {number2} = {minus_result.ToString()}");

            /* Not working now
            BigInt divide_result = number1 / number2;
            Console.WriteLine($"{number1} / {number2} = {divide_result.ToString()}"); 
            */

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
