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
            BigInt number1 = BigInt.Parse(Console.ReadLine());
            BigInt number2 = (BigInt)"200"; // explicit casting string to BigInt type

            number1 += 100;

            #region Arithmetic operations Test
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

            #endregion


            #region Boolean operators Test
            Console.WriteLine($"{number1} < {number2} - {number1 < number2}");
            Console.WriteLine($"{number1} > {number2} - {number1 > number2}");
            Console.WriteLine($"{number1} == {number2} - {number1 == number2}");
            Console.WriteLine($"{number1} != {number2} - {number1 != number2}");
            Console.WriteLine($"{number1} >= {number2} - {number1 >= number2}");
            Console.WriteLine($"{number1} <= {number2} - {number1 <= number2}");
            #endregion

            #region Factorial func Test
            Console.Write("Enter number to find factorial: ");
            int number = int.Parse(Console.ReadLine());
            BigInt fact_result = BigInt.Factorial(number);

            Console.WriteLine($"Factorial of number {number} = {fact_result.ToString()}");
            #endregion

            #region Pow function Test
            Console.Write("Enter number to power: ");
            BigInt new_number = BigInt.Parse(Console.ReadLine());

            Console.Write("Enter power of number: ");
            int pow = int.Parse(Console.ReadLine());

            BigInt pow_result = BigInt.Pow(new_number, pow);

            Console.WriteLine($"Number {new_number} in power {pow} = {pow_result.ToString()}");
            #endregion

            #region Quick Sorting Test
            Console.Write("Please, enter amount of numbers in your array: ");

            int num_amount = int.Parse(Console.ReadLine());
            BigInt[] arr = new BigInt[num_amount];


            Console.WriteLine($"Now enter all your {num_amount} numbers:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = BigInt.Parse(Console.ReadLine());
            }

            BigInt.QuickSort(ref arr, 0, arr.Length - 1);

            Console.WriteLine($"Your sorted array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
