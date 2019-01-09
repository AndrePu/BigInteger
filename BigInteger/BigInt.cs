using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cryptography
{
    public class BigInt
    {
        List<int> number = new List<int>();                 // big number will be presented as list of integers presenting one digit of number (старшие разряды числа будут дальше идти по списку)

        #region Constructors for creating example of class
        public BigInt() : this(0)
        {
        }

        public BigInt(string number)
        {
            for (int i = number.Length-1; i != -1; i--)
            {
                this.number.Add(int.Parse(number[i].ToString()));
            }
        }

        public BigInt(int number)
        {
            if (number == 0)
                this.number.Add(number);

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

            while (number != 0)
            {
                this.number.Add((int)(number % 10));
                number /= 10;
            }
        }

        #endregion
        
        
        public void ConsolePrint()
        {
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
            for (int i = this.number.Count; i != -1; i--)
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
        #endregion

        #region Arithmetic operations with numbers

        #region Extra operations for methods implemented arithmetic operations
        static void Swap(ref List<int> first, ref List<int> second)
        {
            List<int> temp = first;
            first = second;
            second = temp;
        }

        #endregion

        /// <summary>
        /// Adds two lists that present two BigIntegers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static List<int> Add(List<int> first, List<int> second)
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


        #endregion
    }



}


