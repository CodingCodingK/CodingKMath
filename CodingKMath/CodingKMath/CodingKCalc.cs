using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKMath
{
    /// <summary>
    /// 常用定点数数学运算
    /// </summary>
    public static class CodingKCalc
    {
        /// <summary>
        /// 牛顿迭代法求平方根
        /// </summary>
        public static CodingKInt Sqrt(this CodingKInt val, int iteratorCount = 8)
        {
            if (val == CodingKInt.zero)
            {
                return 0;
            }

            if (val < CodingKInt.zero)
            {
                throw new Exception("CodingKInt Sqrt error: cannot sqrt a minus value!" + val);
            }

            CodingKInt result = val;
            CodingKInt history;
            int count = 0;

            do
            {
                history = result;
                result = (result + val / result) >> 1;
                ++count;
            } 
            while (result != history && count < iteratorCount);

            // for (int i = 0; i < iteratorCount;i ++)
            // {
            //     result = (result + val / result) >> 1;
            // }

            return result;
        }

        /// <summary>
        /// 求反余弦。val范围是[-1,1]
        /// </summary>
        public static CodingKArgs Acos(CodingKInt val)
        {
            CodingKInt rate = (val * AcosTable.HalfIndexCount) + AcosTable.HalfIndexCount;
            rate = Clamp(rate, CodingKInt.zero, AcosTable.IndexCount);
            int rad = AcosTable.table[rate.RawInt];

            return new CodingKArgs(rad, AcosTable.Multipler);
        }

        /// <summary>
        /// 限制区间
        /// </summary>
        public static CodingKInt Clamp(CodingKInt input, CodingKInt min, CodingKInt max)
        {
            if (input < min)
            {
                return min;
            }
            if (input > max)
            {
                return max;
            }

            return input;
        }
    }
}
