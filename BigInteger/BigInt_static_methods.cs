using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {
        static void Swap(ref List<sbyte> first, ref List<sbyte> second)
        {
            List<sbyte> temp = first;
            first = second;
            second = temp;
        }

        public static void Swap(ref BigInt First, ref BigInt Second)
        {
            BigInt temp = First;
            First = Second;
            Second = temp;
        }

        public static BigInt Parse(string line)
        {
            if (line == String.Empty)
                return null;

            BigInt number = new BigInt();

            int i = 0;
            if (line[0] == '-')
            {
                number.negative = true;
                i++;
            }

            for (; i < line.Length; i++)
            {
                if (line[i] >= '0' && line[i] <= '9')
                    number.numericalRank.Insert(0, (sbyte)((sbyte)line[i] - 48));
                else
                    return null; // THROW EXCEPTION HERE!!!!!!!!!!!!!!!!!!!!!1
            }

            return number;
        }

        /// <summary>
        ///  Makes full copy of object of BigInt type.
        /// </summary>
        /// <returns>Returns reference on a new object, that has the same values that copied object had.</returns>
        public static BigInt Copy(BigInt number)
        {
            BigInt copied_number = new BigInt();

            if (number.IsNegative())
                copied_number.negative = true;

            for (int i = 0; i < number.numericalRank.Count; i++)
            {
                copied_number.numericalRank.Add(number.numericalRank[i]);
            }

            return copied_number;
        }
        public static void QuickSort(ref BigInt[] numbers, int left, int right)
        {
            if (left < right)
            {
                int piv = Partition(ref numbers, left, right);

                QuickSort(ref numbers, left, piv - 1);
                QuickSort(ref numbers, piv + 1, right);
            }
        }

        private static int Partition(ref BigInt[] numbers, int left, int right)
        {
            BigInt pivot = numbers[right];

            int ind1 = left - 1;    // index whose left numbers values in numbers_array are less than pivot value

            for (int i = left; i < right; i++)
            {
                if (pivot > numbers[i])
                {
                    ind1++;
                    Swap(ref numbers[ind1], ref numbers[i]);
                }
            }

            Swap(ref numbers[right], ref numbers[++ind1]);
            return ind1;
        }

        public static BigInt Sum(params BigInt[] bigInt_arr)
        {
            BigInt result = new BigInt(0);
            for (int i = 0; i < bigInt_arr.Length; i++)
            {
                result += bigInt_arr[i];
            }

            return result;
        }

        public static BigInt Multiply(params BigInt[] bigInt_arr)
        {
            BigInt result = new BigInt(1);
            for (int i = 0; i < bigInt_arr.Length; i++)
            {
                result *= bigInt_arr[i];
            }

            return result;
        }

        /// <summary>
        /// Calculates factorial of given number. 
        /// </summary>
        /// <param name="number"></param>
        /// <returns>If number less than one functions returns 1.</returns>
        public static BigInt Factorial(int number)
        {
            BigInt result = new BigInt(1);          // the result of factorialization will be located in BigInt type object

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        public static BigInt Abs(BigInt number)
        {
            BigInt abs_number = new BigInt();
            abs_number.numericalRank.AddRange(number.numericalRank);
            return abs_number;
        }

        public static BigInt Pow(BigInt Number, int power)
        {
            BigInt Result = new BigInt(1);
            for (int i = 0; i < power; i++)
            {
                Result *= Number;
            }

            return Result;
        }

        public static BigInt Sqrt(BigInt Number) // ДОПИСАТЬ ЗДЕСЬ. НО СНАЧАЛА СДЕЛАТЬ ОПЕРАЦИЮ ДЕЛЕНИЯ ДЛЯ ЧИСЕЛ
        {
            throw new NotImplementedException();
        }
    }
}
