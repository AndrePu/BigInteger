using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {
        public static BigInt operator +(BigInt First, BigInt Second)
        {
            BigInt Result = new BigInt(0);

            if (First.IsNegative() && !Second.IsNegative())
            {
                if ((Abs(First)) > (Abs(Second)))
                {
                    Result.numericalRank = Minus(First.numericalRank, Second.numericalRank);
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

        public static BigInt operator /(BigInt first, BigInt second)
        {
            throw new NotImplementedException();
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

        private static List<sbyte> Add(List<sbyte> first, List<sbyte> second)
        {
            List<sbyte> result = new List<sbyte>();

            if (first.Count < second.Count)
            {
                Swap(ref first, ref second);
            }

            bool older_unit = false;


            // Adding common existing part
            for (int i = 0; i < second.Count; i++)
            {
                sbyte unit_result = (sbyte)(first[i] + second[i]);
                unit_result += (sbyte)((older_unit) ? 1 : 0);

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
                sbyte unit_result = first[i];
                unit_result += (sbyte)((older_unit) ? 1 : 0);

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

        private static List<sbyte> Multiply(List<sbyte> First_Init, List<sbyte> Second_Init)
        {
            /*Copying initial lists so they won't be changed*/
            List<sbyte> First = new List<sbyte>();
            First.AddRange(First_Init);

            List<sbyte> Second = new List<sbyte>();
            Second.AddRange(Second_Init);

            List<sbyte> Result = new List<sbyte>() { 0 };

            if (First.Count < Second.Count)
                Swap(ref First, ref Second);

            for (int i = 0; i < Second.Count; i++)
            {
                #region Unit multiplying
                List<sbyte> cur_part = new List<sbyte>();
                sbyte extra_units = 0;

                if (i > 0)              // increase number for multiplying on higher units
                {
                    First.Insert(0, 0);
                }

                for (int j = 0; j < First.Count; j++)
                {
                    sbyte unit_result = (sbyte)(First[j] * Second[i]);
                    unit_result += extra_units;

                    extra_units = (sbyte)(unit_result / 10);

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

        private static List<sbyte> Minus(List<sbyte> First_Init, List<sbyte> Second_Init)
        {
            List<sbyte> First = new List<sbyte>();
            First.AddRange(First_Init);

            List<sbyte> Second = new List<sbyte>();
            Second.AddRange(Second_Init);

            List<sbyte> Result = new List<sbyte>();

            for (int i = 0; i < Second.Count; i++)
            {
                sbyte unit_result = (sbyte)(First[i] - Second[i]);

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
    }
}
