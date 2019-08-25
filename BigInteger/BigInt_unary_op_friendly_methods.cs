using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {
        public static bool IsTrue(BigInt number)
        {
            return number.numericalRank.Count > 1 || number.numericalRank.Count == 1 && number.numericalRank[0] != 0;
        }

        public static bool IsFalse(BigInt number)
        {
            return !IsTrue(number);
        }
    }
}
