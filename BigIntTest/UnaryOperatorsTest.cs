using NUnit.Framework;
using Cryptography;
using System.Numerics;
using System;


namespace Tests
{
    class UnaryOperatorsTests
    {
        [TestCase("-0", ExpectedResult = false)]
        [TestCase("-000", ExpectedResult = false)]
        [TestCase("-1", ExpectedResult = true)]
        [TestCase("0", ExpectedResult = false)]
        [TestCase("1", ExpectedResult = true)]
        public bool True_strings_operator(string num)
        {
            var b1 = new BigInt(num);
            
            return (b1) ? true : false;
        }

        [TestCase("-0", ExpectedResult = false)]
        [TestCase("-000", ExpectedResult = false)]
        [TestCase("-1", ExpectedResult = true)]
        [TestCase("0", ExpectedResult = false)]
        [TestCase("1", ExpectedResult = true)]
        public bool False_strings_operator(string num)
        {
            var b1 = new BigInt(num);

            return (b1) ? true : false;
        }

    }
}
