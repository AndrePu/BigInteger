using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {
        public BigInt() { }

        public BigInt(string number)
        {
            if (number[0] == '-')
            {
                negative = true;
            }

            for (int i = number.Length - 1; i != -1 + ((negative) ? 1 : 0); i--)
            {
                this.numericalRank.Add(byte.Parse(number[i].ToString()));
            }
        }

        public BigInt(int number)
        {
            if (number == 0)
                this.numericalRank.Add((byte)number);


            if (number < 0)
            {
                negative = true;
                number *= -1;
            }

            while (number != 0)
            {
                this.numericalRank.Add((byte)(number % 10));
                number /= 10;
            }
        }

        public BigInt(long number)
        {
            if (number == 0)
                this.numericalRank.Add((byte)number);

            if (number < 0)
            {
                negative = true;
                number *= -1;
            }

            while (number != 0)
            {
                this.numericalRank.Add((byte)(number % 10));
                number /= 10;
            }
        }
    }
}
