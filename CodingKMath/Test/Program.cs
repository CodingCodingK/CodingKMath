using System;
using CodingKMath;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
            Ex2();

            Console.ReadKey();
        }

        static void Ex2()
        {
            CodingKInt val1 = new CodingKInt(1);
            CodingKInt val2 = new CodingKInt(1.5f);
            Console.WriteLine((val1 * val2).ToString());
            CodingKInt val3 = new CodingKInt(4.5f);
            CodingKInt val4 = new CodingKInt(1.5f);
            Console.WriteLine((val3 / val4).ToString());
        }

        static void Ex1()
        {
            CodingKInt val1 = new CodingKInt(1);
            CodingKInt val2 = new CodingKInt(0.5f);
            Console.WriteLine(val1.ToString());
            val1 = val1 << 10;
            Console.WriteLine(val1.ToString());

            CodingKInt val5 = 1;
            CodingKInt val6 = (CodingKInt)1f;
        }
    }
}
