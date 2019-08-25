using System;
using System.Collections.Generic;


namespace Cryptography
{
    public sealed partial class BigInt : IComparable<BigInt>
    {
        private bool negative = false;
        private List<byte> numericalRank = new List<byte>();                 // big number will be presented as list of integers presenting one digit of number (старшие разряды числа будут дальше идти по списку)       
    }
}
