using NUnit.Framework;
using Cryptography;
using System.Numerics;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string expectedResult = "12345";

            BigInt bigInt = new BigInt(12345);

            Assert.AreEqual(true, bigInt.ToString() == expectedResult);
        }
    }
}