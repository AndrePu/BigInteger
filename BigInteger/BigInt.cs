using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cryptography
{
    enum CompareBigInt
    {
        Less,
        Equal,
        Bigger
    }

    public class BigInt
    {
        private bool negative = false;                              // tells whether BigInteger is negative
        
        private List<int> number = new List<int>();                 // big number will be presented as list of integers presenting one digit of number (старшие разряды числа будут дальше идти по списку)

        #region Constructors for creating example of class
        public BigInt() : this(0)
        {
        }

        public BigInt(string number)
        {
            if (number[0] == '-')
            {
                negative = true;
            }

            for (int i = number.Length - 1; i != -1 + ((negative) ? 1 : 0) ; i--)
            {
                this.number.Add(int.Parse(number[i].ToString()));
            }
        }

        public BigInt(int number)
        {
            if (number == 0)
                this.number.Add(number);


            if (number < 0)
            {
                negative = true;
                number *= -1;
            }

            while (number != 0)
            {
                this.number.Add(number % 10);
                number /= 10;
            }
        }
        public BigInt(long number)
        {
            if (number == 0)
                this.number.Add((int)number);

            if (number < 0)
            {
                negative = true;
                number *= -1;
            }
            
            while (number != 0)
            {
                this.number.Add((int)(number % 10));
                number /= 10;
            }
        }

        #endregion
                
        public void ConsolePrint()
        {
            if (negative)
                Console.Write('-');
            for (int i = number.Count - 1; i != -1; i--)
            {
                Console.Write(number[i]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Converting BigInteger to String format.
        /// </summary>
        /// <returns>Returns a BigInteger in string format.</returns>
        public override string ToString()       // overriding main method object.ToString()
        {
            string number = String.Empty;

            if (negative)
            {
                number += '-';
            }
            
            for (int i = this.number.Count - 1; i != -1; i--)
            {
                number += this.number[i];
            }

            return number;
        }


        #region Operators overloading

        public static BigInt operator +(BigInt First, BigInt Second)
        {
            BigInt Result = new BigInt();
            Result.number = Add(First.number, Second.number);
            return Result;
        }

        public static BigInt operator *(BigInt First, BigInt Second)
        {
            BigInt Result = new BigInt();

            Result.number = Multiply(First.number, Second.number);

            return Result;
        }

        public static bool operator <(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result = CompareBigIntegers(First, Second);

            if (compare_result == CompareBigInt.Less)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result = CompareBigIntegers(First, Second);

            if (compare_result == CompareBigInt.Bigger)
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result = CompareBigIntegers(First, Second);

            if (compare_result == CompareBigInt.Less || compare_result == CompareBigInt.Equal)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result = CompareBigIntegers(First, Second);

            if (compare_result == CompareBigInt.Bigger || compare_result == CompareBigInt.Equal)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result = CompareBigIntegers(First, Second);

            if (compare_result == CompareBigInt.Equal)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result = CompareBigIntegers(First, Second);

            if (compare_result == CompareBigInt.Equal)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Arithmetic operations with numbers
        
        /// <summary>
        /// Adds two lists that present two BigIntegers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
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
            return Result;
        }

        #endregion

        #region Boolean operations with numbers

        private static CompareBigInt CompareBigIntegers(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result;

            if (First.IsNegative() && Second.IsNegative() == false)
            {
                compare_result = CompareBigInt.Less;

                return compare_result;
            }
            else if (First.IsNegative() == false && Second.IsNegative() == true)
            {
                compare_result = CompareBigInt.Bigger;

                return compare_result;
            }
            else if (First.IsNegative() && Second.IsNegative())
            {
                return CompareBigIntegersNeg(First, Second);
            }
            else
                return CompareBigIntegersPos(First, Second);
        }

        /// <summary>
        /// Compares negative BigIntegers.
        /// </summary>
        /// <returns></returns>
        private static CompareBigInt CompareBigIntegersNeg(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result;
            
            if (First.number.Count < Second.number.Count)
            {
                compare_result = CompareBigInt.Bigger;

                return compare_result;
            }
            else if (First.number.Count > Second.number.Count)
            {
                compare_result = CompareBigInt.Less;

                return compare_result;
            }
            else
            {
                for (int i = 0; i < First.number.Count; i++)
                {
                    if (First.number[i] < Second.number[i])
                    {
                        compare_result = CompareBigInt.Bigger;

                        return compare_result;
                    }
                    else if (First.number[i] > Second.number[i])
                    {
                        compare_result = CompareBigInt.Less;

                        return compare_result;
                    }
                }
            }

            compare_result = CompareBigInt.Equal;

            return compare_result;
        }

        /// <summary>
        /// Compares positive BigIntegers
        /// </summary>
        /// <param name="First"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        private static CompareBigInt CompareBigIntegersPos(BigInt First, BigInt Second)
        {
            CompareBigInt compare_result;

            if (First.number.Count < Second.number.Count)
            {
                compare_result = CompareBigInt.Less;

                return compare_result;
            }
            else if (First.number.Count > Second.number.Count)
            {
                compare_result = CompareBigInt.Bigger;

                return compare_result;
            }
            else
            {
                for (int i = 0; i < First.number.Count; i++)
                {
                    if (First.number[i] > Second.number[i])
                    {
                        compare_result = CompareBigInt.Bigger;

                        return compare_result;
                    }
                    else if (First.number[i] < Second.number[i])
                    {
                        compare_result = CompareBigInt.Less;

                        return compare_result;
                    }
                }
            }

            compare_result = CompareBigInt.Equal;

            return compare_result;
        }

        #endregion

        #region Extra operations for methods implemented arithmetic and boolean operations
        static void Swap(ref List<int> first, ref List<int> second)
        {
            List<int> temp = first;
            first = second;
            second = temp;
        }

        #endregion

        #region Methods for working with examples of current class

        /// <summary>
        /// Tells whether first and second BigIntegers have the same number of units.
        /// </summary>
        /// <param name="First"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        public static bool UnitLengthEqual(BigInt First, BigInt Second)
        {
            if (First.number.Count == Second.number.Count)
                return true;

            return false;
        }

        public static void Swap(ref BigInt First, ref BigInt Second)
        {
            BigInt temp = First;
            First = Second;
            Second = temp;
        }

        public bool IsNegative()
        {
            return negative;
        }
        #endregion
    }



}


