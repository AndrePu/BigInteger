using System;
using System.Collections.Generic;


namespace Cryptography
{
    public sealed class BigInt : IComparable<BigInt>
    {
        private bool negative = false;
        private List<int> numericalRank = new List<int>();                 // big number will be presented as list of integers presenting one digit of number (старшие разряды числа будут дальше идти по списку)

        #region Constructors
        public BigInt() { }

        public BigInt(string number)
        {
            if (number[0] == '-')
            {
                negative = true;
            }

            for (int i = number.Length - 1; i != -1 + ((negative) ? 1 : 0) ; i--)
            {
                this.numericalRank.Add(int.Parse(number[i].ToString()));
            }
        }

        public BigInt(int number)
        {
            if (number == 0)
                this.numericalRank.Add(number);


            if (number < 0)
            {
                negative = true;
                number *= -1;
            }

            while (number != 0)
            {
                this.numericalRank.Add(number % 10);
                number /= 10;
            }
        }

        public BigInt(long number)
        {
            if (number == 0)
                this.numericalRank.Add((int)number);

            if (number < 0)
            {
                negative = true;
                number *= -1;
            }
            
            while (number != 0)
            {
                this.numericalRank.Add((int)(number % 10));
                number /= 10;
            }
        }

        #endregion

        #region Instance methods
        
        public bool IsNegative()
        {
            return negative;
        }

        public int CompareTo(BigInt other)
        {
            if (this == other)
            {
                return 0;
            }
            else if (this > other)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        
        public override string ToString()
        {
            string number = String.Empty;

            if (negative)
            {
                number += '-';
            }

            for (int i = this.numericalRank.Count - 1; i != -1; i--)
            {
                number += this.numericalRank[i];
            }

            return number;
        }
        #endregion

        #region Static methods
        static void Swap(ref List<int> first, ref List<int> second)
        {
            List<int> temp = first;
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
                    number.numericalRank.Insert(0, (int)line[i] - 48);
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

        

        #endregion
        
        #region Unary operators overloading
        public static bool operator true(BigInt number)
        {
            return number.numericalRank.Count != 1 || number.numericalRank[0] != 0;
        }

        public static bool operator false(BigInt number)
        {
            return number.numericalRank.Count == 1 && number.numericalRank[0] == 0;
        }

        #endregion

        #region Binary operators overloading
        public static BigInt operator +(BigInt First, BigInt Second)
        {
            BigInt Result = new BigInt(0);

            if (First.IsNegative() && !Second.IsNegative())
            {
                if ((Abs(First)) > (Abs(Second)))
                {
                    Result.numericalRank = Minus(First.numericalRank,Second.numericalRank);
                    Result.negative = true;
                }
                else if (Abs(First) < Abs(Second))
                {
                    Result.numericalRank = Minus(Second.numericalRank, First.numericalRank);
                }
            }
            else if (!First.IsNegative() && Second.IsNegative())
            {
                if (Abs(First) > Abs(Second))
                {
                    Result.numericalRank = Minus(First.numericalRank, Second.numericalRank);

                }
                else if (Abs(First) < Abs(Second))
                {
                    Result.numericalRank = Minus(Second.numericalRank, First.numericalRank);
                    Result.negative = true;
                }
            }
            else if (First.IsNegative() && Second.IsNegative())
            {
                Result.numericalRank = Add(First.numericalRank, Second.numericalRank);
                Result.negative = true;
            }
            else
            {
                Result.numericalRank = Add(First.numericalRank, Second.numericalRank);
            }

            return Result;
        }
        
        public static BigInt operator -(BigInt First, BigInt Second)
        {
            BigInt Result = new BigInt(0);
            
            if (First.IsNegative() && !Second.IsNegative())
            {
                Result.numericalRank = Add(First.numericalRank, Second.numericalRank);
                Result.negative = true;
            }
            else if (!First.IsNegative() && Second.IsNegative())
            {
                Result.numericalRank = Add(First.numericalRank, Second.numericalRank);
            }
            else if (First.IsNegative() && Second.IsNegative())
            {
                if (Abs(First) > Abs(Second))
                {
                    Result.numericalRank = Minus(First.numericalRank, Second.numericalRank);
                    Result.negative = true;
                }
                else if (Abs(First) < Abs(Second))
                {
                    Result.numericalRank = Minus(Second.numericalRank, First.numericalRank);
                }
            }
            else
            {
                if (First > Second)
                {
                    Result.numericalRank = Minus(First.numericalRank, Second.numericalRank);
                }
                else if (First < Second)
                {
                    Result.numericalRank = Minus(Second.numericalRank, First.numericalRank);

                    Result.negative = true;
                }
            }

            return Result;
        }

        public static BigInt operator *(BigInt First, BigInt Second)
        {
            BigInt Result = new BigInt(0);

            Result.numericalRank = Multiply(First.numericalRank, Second.numericalRank);

            if (First.IsNegative() && Second.IsNegative())
            {
                Result.negative = false;
            }
            else if (First.IsNegative() || Second.IsNegative())
            {
                Result.negative = true;
            }
            else
                Result.negative = false;
                
            return Result;
        }        
        
        public static bool operator <(BigInt First, BigInt Second)
        {
            int compare_result = CompareBigIntegers(First, Second);

            if (compare_result == -1)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(BigInt First, BigInt Second)
        {
            int compare_result = CompareBigIntegers(First, Second);

            if (compare_result == 1)
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(BigInt First, BigInt Second)
        {
            int compare_result = CompareBigIntegers(First, Second);

            if (compare_result != 1)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(BigInt First, BigInt Second)
        {
            int compare_result = CompareBigIntegers(First, Second);

            if (compare_result != -1)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(BigInt First, BigInt Second)
        {
            int compare_result = CompareBigIntegers(First, Second);

            if (compare_result == 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(BigInt First, BigInt Second)
        {
            int compare_result = CompareBigIntegers(First, Second);

            if (compare_result == 0)
            {
                return false;
            }

            return true;
        }

        #region Helping methods

        private static List<int> Add(List<int> first, List<int> second)
        {
            List<int> result = new List<int>();

            if (first.Count < second.Count)
            {
                Swap(ref first, ref second);
            }

            bool older_unit = false;


            // Adding common existing part
            for (int i = 0; i < second.Count; i++)
            {
                int unit_result = first[i] + second[i] + ((older_unit) ? 1 : 0);

                older_unit = false;

                if (unit_result > 9)
                {
                    older_unit = true;
                    unit_result %= 10;
                }

                result.Add(unit_result);
            }

            // Adding left part from first number
            for (int i = second.Count; i != first.Count; i++)
            {
                int unit_result = first[i] + ((older_unit) ? 1 : 0); // adding extra one if we got it from previous unit adding operation

                older_unit = false;

                if (unit_result > 9)
                {
                    older_unit = true;
                    unit_result %= 10;
                }

                result.Add(unit_result);
            }

            // Taking in attention if we got extra unit
            if (older_unit)
                result.Add(1);

            return result;
        }

        private static List<int> Multiply(List<int> First_Init, List<int> Second_Init)
        {
            /*Copying initial lists so they won't be changed*/
            List<int> First = new List<int>();
            First.AddRange(First_Init);

            List<int> Second = new List<int>();
            Second.AddRange(Second_Init);

            List<int> Result = new List<int>() { 0 };

            if (First.Count < Second.Count)
                Swap(ref First, ref Second);

            for (int i = 0; i < Second.Count; i++)
            {
                #region Unit multiplying
                List<int> cur_part = new List<int>();
                int extra_units = 0;

                if (i > 0)              // increase number for multiplying on higher units
                {
                    First.Insert(0, 0);
                }

                for (int j = 0; j < First.Count; j++)
                {
                    int unit_result = First[j] * Second[i] + extra_units;

                    extra_units = unit_result / 10;

                    unit_result %= 10;

                    cur_part.Add(unit_result);
                }

                if (extra_units != 0)
                {
                    cur_part.Add(extra_units);
                }


                Result = Add(Result, cur_part);
                #endregion


            }

            for (int i = Result.Count - 1; Result[i] == 0 && i != 0; i--)  // remove zero prefix in our result number
            {
                Result.RemoveAt(i);
            }

            if (Result.Count == 0)                  // include case when we have zero when we minused
                Result.Add(0);

            return Result;
        }

        private static List<int> Minus(List<int> First_Init, List<int> Second_Init)
        {
            List<int> First = new List<int>();
            First.AddRange(First_Init);

            List<int> Second = new List<int>();
            Second.AddRange(Second_Init);

            List<int> Result = new List<int>();

            for (int i = 0; i < Second.Count; i++)
            {
                int unit_result = First[i] - Second[i];

                if (unit_result < 0)
                {
                    First[i + 1]--;
                    unit_result += 10;
                }

                Result.Add(unit_result);
            }
            for (int i = Second.Count; i < First.Count; i++)
            {
                if (First[i] < 0)
                {
                    First[i + 1]--;
                    First[i] += 10;
                }

                Result.Add(First[i]);
            }

            for (int i = Result.Count - 1; Result[i] == 0 && i != 0; i--)  // remove zero prefix in our result number
            {
                Result.RemoveAt(i);
            }

            if (Result.Count == 0)                  // include case when we have zero when we minused
                Result.Add(0);

            return Result;
        }

        private static int CompareBigIntegers(BigInt First, BigInt Second)
        {
            int compare_result;

            if (First.IsNegative() && !Second.IsNegative())
            {
                compare_result = -1;
            }
            else if (!First.IsNegative() && Second.IsNegative())
            {
                compare_result = 1;
            }
            else if (First.IsNegative() && Second.IsNegative())
            {
                return CompareBigIntegersNeg(First, Second);
            }
            else
                return CompareBigIntegersPos(First, Second);


            return compare_result;
        }
        
        private static int CompareBigIntegersNeg(BigInt First, BigInt Second)
        {
            int compare_result;

            if (First.numericalRank.Count < Second.numericalRank.Count)
            {
                compare_result = 1;

                return compare_result;
            }
            else if (First.numericalRank.Count > Second.numericalRank.Count)
            {
                compare_result = -1;

                return compare_result;
            }
            else
            {
                for (int i = First.numericalRank.Count - 1; i != -1; i--)
                {
                    if (First.numericalRank[i] < Second.numericalRank[i])
                    {
                        compare_result = 1;

                        return compare_result;
                    }
                    else if (First.numericalRank[i] > Second.numericalRank[i])
                    {
                        compare_result = -1;

                        return compare_result;
                    }
                }
            }

            compare_result = 0;

            return compare_result;
        }
        
        private static int CompareBigIntegersPos(BigInt First, BigInt Second)
        {
            int compare_result;

            if (First.numericalRank.Count < Second.numericalRank.Count)
            {
                compare_result = -1;

                return compare_result;
            }
            else if (First.numericalRank.Count > Second.numericalRank.Count)
            {
                compare_result = 1;

                return compare_result;
            }
            else
            {
                for (int i = First.numericalRank.Count - 1; i != -1; i--)
                {
                    if (First.numericalRank[i] > Second.numericalRank[i])
                    {
                        compare_result = 1;

                        return compare_result;
                    }
                    else if (First.numericalRank[i] < Second.numericalRank[i])
                    {
                        compare_result = -1;

                        return compare_result;
                    }
                }
            }

            compare_result = 0;

            return compare_result;
        }


        #endregion

        #endregion

        #region Friendly to overloaded binary operators methods

        public static BigInt Add(BigInt b1, BigInt b2)
        {
            return (b1 + b2);
        }
               
        public static BigInt Minus(BigInt b1, BigInt b2)
        {
            return (b1 - b2);
        }

        public static BigInt Multiply(BigInt b1, BigInt b2)
        {
            return (b1 * b2);
        }

        public static int Compare(BigInt b1, BigInt b2)
        {
            if (b1 > b2)
            {
                return 1;
            }
            else if (b1 < b2)
            {
                return -1;
            }
            else
                return 0;
        }

        #endregion

        #region Convertation operators overloading
        public static implicit operator BigInt(int number)
        {
            BigInt Number = new BigInt(0);
            if (number == 0)
                return Number;

            Number.numericalRank.Clear();

            if (number < 0)
                Number.negative = true;
            
            while (number != 0)
            {
                Number.numericalRank.Add(number % 10);

                number /= 10;
            }

            return Number;
        }

        public static implicit operator BigInt(long number)
        {
            BigInt Number = new BigInt(0);
            if (number == 0)
                return Number;

            Number.numericalRank.Clear();

            if (number < 0)
                Number.negative = true;

            while (number != 0)
            {
                Number.numericalRank.Add((int)(number % 10));

                number /= 10;
            }

            return Number;
        }

        public static explicit operator string(BigInt Number)
        {
            string number = String.Empty;

            if (Number.IsNegative())
                number += '-';

            for (int i = Number.numericalRank.Count - 1; i != -1; i--)
            {
                number += Number.numericalRank[i].ToString();
            }

            return number;
        }

        public static explicit operator BigInt(string number)
        {
            if (number == String.Empty)
                return null;

            BigInt Number = new BigInt();
            
            int i = 0;
            if (number[i] == '-')
            {
                Number.negative = true;
                i++;
            }

            for (; i < number.Length; i++)
            {
                if (number[i] >= '0' && number[i] <= '9')
                {
                    Number.numericalRank.Insert(0,(int)number[i]-48);
                }
                else
                    return null;
            }

            return Number;
        }
        #endregion
    }



}
