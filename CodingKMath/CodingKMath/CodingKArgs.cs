using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKMath
{
    public struct CodingKArgs
    {
        public int value;
        public uint multiplier;

        // TODO 默认10000倍
        public static CodingKArgs zero = new CodingKArgs(0,10000);
        public static CodingKArgs halfPi = new CodingKArgs(15788,10000);
        public static CodingKArgs pi = new CodingKArgs(31416,10000);
        public static CodingKArgs twoPi = new CodingKArgs(62832,10000);

        public CodingKArgs(int val, uint multi)
        {
            this.value = val;
            this.multiplier = multi;
        }

        /// <summary>
        /// 转化为View角度，不可再参与逻辑运算
        /// </summary>
        public int ConvertViewAngle()
        {
            float radians = ConvertToFloat();

            return (int) Math.Round(radians/Math.PI * 180);
        }

        /// <summary>
        /// 转化为View弧度值，不可再参与逻辑运算
        /// </summary>
        public float ConvertToFloat()
        {
            return value * 1.0f / multiplier;
        }

        #region operator
        public static bool operator >(CodingKArgs a, CodingKArgs b)
        {
            if (a.multiplier == b.multiplier)
            {
                return a.value > b.value;
            }
            else
            {
                throw new System.Exception("CodingKArgs '>' error: multiplier is unequaled.");
            }
        }

        public static bool operator <(CodingKArgs a, CodingKArgs b)
        {
            if (a.multiplier == b.multiplier)
            {
                return a.value < b.value;
            }
            else
            {
                throw new System.Exception("CodingKArgs '<' error: multiplier is unequaled.");
            }
        }

        public static bool operator >=(CodingKArgs a, CodingKArgs b)
        {
            if (a.multiplier == b.multiplier)
            {
                return a.value >= b.value;
            }
            else
            {
                throw new System.Exception("CodingKArgs '>=' error: multiplier is unequaled.");
            }
        }

        public static bool operator <=(CodingKArgs a, CodingKArgs b)
        {
            if (a.multiplier == b.multiplier)
            {
                return a.value <= b.value;
            }
            else
            {
                throw new System.Exception("CodingKArgs '<=' error: multiplier is unequaled.");
            }
        }

        public static bool operator ==(CodingKArgs a, CodingKArgs b)
        {
            if (a.multiplier == b.multiplier)
            {
                return a.value == b.value;
            }
            else
            {
                throw new System.Exception("CodingKArgs '==' error: multiplier is unequaled.");
            }
        }

        public static bool operator !=(CodingKArgs a, CodingKArgs b)
        {
            if (a.multiplier == b.multiplier)
            {
                return a.value != b.value;
            }
            else
            {
                throw new System.Exception("CodingKArgs '!=' error: multiplier is unequaled.");
            }
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj is CodingKArgs args)
            {
                return args.value == this.value && args.multiplier == this.multiplier;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return $"value:{value}, multiplier:{multiplier}";
        }
    }
}
