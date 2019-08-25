using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    partial class BigInt
    {
        public static bool operator true(BigInt number)
        {
            return IsTrue(number);
        }

        public static bool operator false(BigInt number)
        {
            return IsFalse(number);
        }
    }
}
