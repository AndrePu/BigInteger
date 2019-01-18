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
            Console.Write("Your first number: ");
            BigInt number1 = BigInt.Parse(Console.ReadLine());

            Console.WriteLine("Your second number was set by default and equal to 200");
            BigInt number2 = (BigInt)"200"; // explicit casting string to BigInt type

            Console.WriteLine("Adding 100 to first number..\n");
            number1 += 100;

            #region Arithmetic operations Test
            Console.WriteLine("_______________________________");
            Console.WriteLine("Now arithmetic operations test..\n");

            BigInt mult_result = number1 * number2;
            Console.WriteLine($"{number1} * {number2} = {mult_result.ToString()}");

            BigInt add_result = number1 + number2;
            Console.WriteLine($"{number1} + {number2} = {add_result.ToString()}");

            BigInt minus_result = number1 - number2;
            Console.WriteLine($"{number1} - {number2} = {minus_result.ToString()}\n");

            /* Not working now
            BigInt divide_result = number1 / number2;
            Console.WriteLine($"{number1} / {number2} = {divide_result.ToString()}"); 
            */
            Console.Write("Please, enter amount of numbers you want to include in your adding_arr: ");
            BigInt[] adding_arr = new BigInt[int.Parse(Console.ReadLine())];

            Console.WriteLine("Now, please enter all the big integers:");
            for (int i = 0; i < adding_arr.Length; i++)
            {
                adding_arr[i] = BigInt.Parse(Console.ReadLine());
            }

            BigInt adding_result = BigInt.Sum(adding_arr);

            Console.WriteLine("The result of adding {0} numbers is {1}\n", adding_arr.Length, adding_result);
            #endregion

            #region Boolean operators Test
            Console.WriteLine("_______________________________");
            Console.WriteLine("Now boolean operations test..\n");

            Console.WriteLine($"{number1} < {number2} - {number1 < number2}");
            Console.WriteLine($"{number1} > {number2} - {number1 > number2}");
            Console.WriteLine($"{number1} == {number2} - {number1 == number2}");
            Console.WriteLine($"{number1} != {number2} - {number1 != number2}");
            Console.WriteLine($"{number1} >= {number2} - {number1 >= number2}");
            Console.WriteLine($"{number1} <= {number2} - {number1 <= number2}\n");
            #endregion

            #region Factorial func Test
            Console.WriteLine("_______________________________");
            Console.WriteLine("Let's try factorial operation test..\n");
            
            Console.Write("Enter number to find factorial: ");
            int number = int.Parse(Console.ReadLine());
            BigInt fact_result = BigInt.Factorial(number);

            Console.WriteLine($"Factorial of number {number} = {fact_result.ToString()}\n");
            #endregion

            #region Pow function Test
            Console.WriteLine("_______________________________");
            Console.WriteLine("What about Pow operation test..\n");
            
            Console.Write("Enter number to power: ");
            BigInt new_number = BigInt.Parse(Console.ReadLine());

            Console.Write("Enter power of number: ");
            int pow = int.Parse(Console.ReadLine());

            BigInt pow_result = BigInt.Pow(new_number, pow);

            Console.WriteLine($"Number {new_number} in power {pow} = {pow_result.ToString()}");
            #endregion

            #region Quick Sorting Test
            Console.WriteLine("_______________________________");
            Console.WriteLine("And finally Quick Sorting function test..\n");

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
