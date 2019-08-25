using System;
using System.Collections.Generic;


namespace Cryptography
{
    public sealed partial class BigInt : IComparable<BigInt>
    {
        private bool negative = false;
        private List<sbyte> numericalRank = new List<sbyte>();                 // big number will be presented as list of integers presenting one digit of number (старшие разряды числа будут дальше идти по списку)       
    }
}
