using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography;

namespace BigIntTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInt number1 = new BigInt(Console.ReadLine());
            BigInt number2 = new BigInt(Console.ReadLine());

            BigInt number3 = number1 + number2;

            number3.ConsolePrint();

            Console.ReadKey();
        }
    }
}
