using NUnit.Framework;
using Cryptography;
using System.Numerics;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Description("Checking initialization and overriding ToString() method")]
        [TestCase("1213243234")]
        [TestCase("12345611111")]
        [TestCase("1213243234a", Ignore = "Code is not complete yet")]
        [TestCase("123^2", Ignore = "Code is not complete yet")]
        [MaxTime(2000)]
        public void Test1(string text_number)
        {
            // Arrange
            BigInt bigInt = new BigInt(text_number);

            // Act
            bool equal = bigInt.ToString() == text_number;

            // Assert
            Assert.IsTrue(equal);
        }
        
        [TestCase("1289832894318943289032489", "9240384329034318943289032489")]
        public void Test2(string num1, string num2)
        {
            // Arrange
            BigInt b1 = new BigInt(num1);
            BigInt b2 = new BigInt(num2);

            BigInteger b1_2 = new BigInteger(Convert.ToDecimal(num1));
            BigInteger b2_2 = new BigInteger(Convert.ToDecimal(num2));
            
            // Act
            BigInt b3 = b1 + b2;            
            BigInteger b3_2 = b1_2 + b2_2;
            
            // Assert
            Assert.AreEqual(b3_2.ToString(), b3.ToString());
        }
    }
}