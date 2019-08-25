using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {

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
                Number.numericalRank.Add((sbyte)(number % 10));

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
                Number.numericalRank.Add((sbyte)(number % 10));

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
                    Number.numericalRank.Insert(0, (sbyte)((sbyte)number[i] - 48));
                }
                else
                    return null;
            }

            return Number;
        }
    }
}
