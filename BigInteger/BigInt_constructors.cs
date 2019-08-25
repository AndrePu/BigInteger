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
                number = number.Remove(0, 1);
            }

            if (number.Length != 1)
            {
                number = number.TrimStart('0');

                if (number == "")
                {
                    number = "0";
                }
            }            
            

            for (int i = number.Length - 1; i != -1; i--)
            {
                this.numericalRank.Add(sbyte.Parse(number[i].ToString()));
            }
        }

        public BigInt(int number)
        {
            if (number == 0)
                this.numericalRank.Add((sbyte)number);


            if (number < 0)
            {
                negative = true;
                number *= -1;
            }

            while (number != 0)
            {
                this.numericalRank.Add((sbyte)(number % 10));
                number /= 10;
            }
        }

        public BigInt(long number)
        {
            if (number == 0)
                this.numericalRank.Add((sbyte)number);

            if (number < 0)
            {
                negative = true;
                number *= -1;
            }

            while (number != 0)
            {
                this.numericalRank.Add((sbyte)(number % 10));
                number /= 10;
            }
        }
    }
}
