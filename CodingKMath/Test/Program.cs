using System;
using CodingKMath;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
            // Ex2();
            //Ex3();
            Ex4();

            Console.ReadKey();
        }

        static void Ex4()
        {
            CodingKVector3 v1 = new CodingKVector3(1, 0, 0);
            CodingKVector3 v2 = new CodingKVector3(1, 1, 0);
            CodingKArgs angle = CodingKVector3.Angle(v1, v2);
            Console.WriteLine($"angel view:{angle.ConvertViewAngle()}");
            Console.WriteLine($"angel float:{angle.ConvertToFloat()}");
            Console.WriteLine($"angel info:{angle}");

            CodingKVector3 v3 = new CodingKVector3(1, 0, 0);
            CodingKVector3 v4 = new CodingKVector3(1, (CodingKInt)1.732f, 0);
            CodingKArgs angle2 = CodingKVector3.Angle(v3, v4);
            Console.WriteLine($"angel view:{angle2.ConvertViewAngle()}");
            Console.WriteLine($"angel float:{angle2.ConvertToFloat()}");
            Console.WriteLine($"angel info:{angle2}");
        }
        static void Ex3()
        {
            CodingKVector3 v = new CodingKVector3(2, 2, 2);
            Console.WriteLine(v.normalized);
            Console.WriteLine(CodingKVector3.Normalize(v));
            v.Normalize();
            Console.WriteLine(v);
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
