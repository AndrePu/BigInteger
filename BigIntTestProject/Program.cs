using System;
using Cryptography;

namespace BigIntTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInt b1 = new BigInt("-9");
            BigInt b2 = new BigInt("4332");

            BigInt b3 = BigInt.Add(b1, b2);

            Console.WriteLine(b3);
            Console.ReadKey();
        }
    }
}
