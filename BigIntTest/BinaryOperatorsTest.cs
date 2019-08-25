using NUnit.Framework;
using Cryptography;
using System.Numerics;
using System;


namespace Tests
{
    partial class Tests
    {
        [TestCase("3", "9")]
        [TestCase("391", "609")]
        [TestCase("39190329032", "329012609")]
        [TestCase("1289832894318943289032489", "9240384329034318943289032489")]
        [TestCase("-9", "4332")]
        [TestCase("-438934", "89342432")]
        [TestCase("-438934", "-89342432")]
        [TestCase("438934", "-89342432")]
        public void Adding_strings_operator(string num1, string num2)
        {
            // Arrange
            BigInt b1 = new BigInt(num1);
            BigInt b2 = new BigInt(num2);

            BigInteger b1_2 = new BigInteger(Convert.ToDecimal(num1));
            BigInteger b2_2 = new BigInteger(Convert.ToDecimal(num2));

            // Act
            BigInt b3 = BigInt.Add(b1, b2);
            BigInteger b3_2 = b1_2 + b2_2;

            // Assert
            Assert.AreEqual(b3_2.ToString(), b3.ToString());
        }

        [TestCase("29", "9")]
        [TestCase("9", "29")]
        [TestCase("239023", "43234")]
        [TestCase("1289832894318943289032489", "9240384329034318943289032489")]
        [TestCase("-438934", "89342432")]
        [TestCase("-438934", "-89342432")]
        [TestCase("438934", "-89342432")]
        public void Minus_strings_operator(string num1, string num2)
        {
            // Arrange
            BigInt b1 = new BigInt(num1);
            BigInt b2 = new BigInt(num2);

            BigInteger b1_2 = new BigInteger(Convert.ToDecimal(num1));
            BigInteger b2_2 = new BigInteger(Convert.ToDecimal(num2));

            // Act
            BigInt b3 = BigInt.Minus(b1, b2);
            BigInteger b3_2 = b1_2 - b2_2;

            // Assert
            Assert.AreEqual(b3_2.ToString(), b3.ToString());
        }

        [TestCase("5", "10")]
        [TestCase("-5", "-123")]
        [TestCase("-23", "43")]
        [TestCase("43", "-51")]
        [TestCase("1289832894318943289032489", "9240384329034318943289032489")]
        [TestCase("-1289832894318943289032489", "9240384329034318943289032489")]
        [TestCase("-1289832894318943289032489", "-9240384329034318943289032489")]
        [TestCase("1289832894318943289032489", "-9240384329034318943289032489")]
        public void Multiply_strings_operator(string num1, string num2)
        {
            // Arrange
            BigInt b1 = new BigInt(num1);
            BigInt b2 = new BigInt(num2);

            BigInteger b1_2 = new BigInteger(Convert.ToDecimal(num1));
            BigInteger b2_2 = new BigInteger(Convert.ToDecimal(num2));

            // Act
            BigInt b3 = BigInt.Multiply(b1, b2);
            BigInteger b3_2 = b1_2 * b2_2;

            // Assert
            Assert.AreEqual(b3_2.ToString(), b3.ToString());
        }

        [TestCase("1", "1", ExpectedResult = true)]
        [TestCase("0", "0", ExpectedResult = true)]
        [TestCase("1202", "1202", ExpectedResult = true)]
        [TestCase("-10", "-10", ExpectedResult = true)]
        [TestCase("-10", "10", ExpectedResult = false)]
        [TestCase("10", "-10", ExpectedResult = false)]
        [TestCase("10", "000010", ExpectedResult = true)]
        public bool Equal_strings_operator(string num1, string num2)
        {
            var b1 = new BigInt(num1);
            var b2 = new BigInt(num2);

            return b1 == b2;
        }
    }
}
