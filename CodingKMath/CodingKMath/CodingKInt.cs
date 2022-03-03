using System;

namespace CodingKMath
{
    public struct CodingKInt
    {
        // 移位计数
        private const int BIT_MOVE_COUNT = 10;
        private const long MULTIPLIER_FACTOR = 1 << BIT_MOVE_COUNT;


        private long scaledValue;
        public long ScaledValue
        {
            get { return scaledValue; }
            set { scaledValue = value; }
        }


        public CodingKInt(int val)
        {
            scaledValue = val * MULTIPLIER_FACTOR;
        }

        public CodingKInt(float val)
        {
            // Math.Round舍入，虽然会有精度损失，但是是在允许误差内，且所有都会浮点都会遵循这个规则舍入所以相对公平
            scaledValue = (long)Math.Round(val * MULTIPLIER_FACTOR);
        }

        // 内部使用，传入已经缩放完成的数据
        private CodingKInt(long scaledVal)
        {
            scaledValue = scaledVal;
        }

        #region operator

        public static CodingKInt operator -(CodingKInt val)
        {
            return new CodingKInt(-val.scaledValue);
        }

        public static CodingKInt operator +(CodingKInt a, CodingKInt b)
        {
            return new CodingKInt(a.scaledValue + b.scaledValue);
        }

        public static CodingKInt operator -(CodingKInt a, CodingKInt b)
        {
            return new CodingKInt(a.scaledValue - b.scaledValue);
        }

        public static CodingKInt operator *(CodingKInt a, CodingKInt b)
        {
            long val = a.scaledValue * b.scaledValue;
            val >>= BIT_MOVE_COUNT;
            return new CodingKInt(val);
        }

        public static CodingKInt operator /(CodingKInt a, CodingKInt b)
        {
            if (b.scaledValue == 0)
            {
                throw new Exception("CodingKInt a/b error: b cannot be 0");
            }
            long val = a.scaledValue << BIT_MOVE_COUNT;
            val /= b.scaledValue;
            return new CodingKInt(val);
        }

        public static bool operator ==(CodingKInt a, CodingKInt b)
        {
            return a.scaledValue == b.scaledValue;
        }

        public static bool operator !=(CodingKInt a, CodingKInt b)
        {
            return a.scaledValue != b.scaledValue;
        }

        public static bool operator >(CodingKInt a, CodingKInt b)
        {
            return a.scaledValue > b.scaledValue;
        }

        public static bool operator <(CodingKInt a, CodingKInt b)
        {
            return a.scaledValue < b.scaledValue;
        }

        public static bool operator >=(CodingKInt a, CodingKInt b)
        {
            return a.scaledValue >= b.scaledValue;
        }

        public static bool operator <=(CodingKInt a, CodingKInt b)
        {
            return a.scaledValue <= b.scaledValue;
        }

        public static CodingKInt operator >>(CodingKInt val, int moveCount)
        {
            return new CodingKInt(val.scaledValue >> moveCount);
        }

        public static CodingKInt operator <<(CodingKInt val, int moveCount)
        {
            return new CodingKInt(val.scaledValue << moveCount);
        }
        #endregion

        #region output

        // 转换完成后，不再参与逻辑运算
        public float RawFloat
        {
            get
            {
                return scaledValue * 1.0f / MULTIPLIER_FACTOR;
            }
        }

        public int RawInt
        {
            get
            {
                return (int)(scaledValue / MULTIPLIER_FACTOR);
            }
        }

        #endregion

        #region convert

        // float 损失精度的构造，只提供显式转换
        public static explicit operator CodingKInt(float f)
        {
            return new CodingKInt(f);
        }

        // int 不损失精度的构造，提供隐式转换
        public static implicit operator CodingKInt(int i)
        {
            return new CodingKInt(i);
        }

        #endregion

        public override string ToString()
        {
            return RawFloat.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is CodingKInt vInt)
            {
                return scaledValue == vInt.scaledValue;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return scaledValue.GetHashCode();
        }
    }
}
