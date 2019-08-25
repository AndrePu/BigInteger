using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {
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
    }
}
