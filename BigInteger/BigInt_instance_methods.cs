using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {

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
    }
}
