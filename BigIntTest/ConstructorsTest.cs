using NUnit.Framework;
using Cryptography;
using System.Numerics;
using System;

namespace Tests
{
    public partial class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Description("Checking initialization and overriding ToString() method")]
        [TestCase("1213243234")]
        [TestCase("12345611111")]
        [TestCase("00000012345611111")]
        [TestCase("1213243234a", Ignore = "Code is not complete yet")]
        [TestCase("123^2", Ignore = "Code is not complete yet")]
        [MaxTime(2000)]
        public void Constructor_string(string text_number)
        {
            // Arrange
            BigInt bigInt = new BigInt(text_number);

            if (text_number.Length != 1)
            {
                text_number = text_number.TrimStart('0');
            }

            // Act

            bool equal = bigInt.ToString() == text_number;

            // Assert
            Assert.IsTrue(equal);
        }
    }
}