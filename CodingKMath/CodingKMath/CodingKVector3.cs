using System;
using System.Collections.Generic;
using System.Text;

#if UNITY_ENV
using UnityEngine;
#endif

namespace CodingKMath
{
    public struct CodingKVector3
    {
        public CodingKInt x;
        public CodingKInt y;
        public CodingKInt z;

        public CodingKVector3(CodingKInt x, CodingKInt y, CodingKInt z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

#if UNITY_ENV
        public CodingKVector3(Vector3 vec)
        {
            this.x = (CodingKInt)vec.x;
            this.y = (CodingKInt)vec.y;
            this.z = (CodingKInt)vec.z;
        }

        /// <summary>
        /// 获取浮点型Vector3，表现层专用，不可再使用逻辑运算
        /// </summary>
        public Vector3 ConvertViewVector3()
        {
            return new Vector3(x.RawFloat,y.RawFloat,z.RawFloat);
        }
#endif

        public CodingKInt this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    case 2:
                        return this.z;
                }

                return 0;
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value; break;
                    case 1:
                        this.y = value; break;
                    case 2:
                        this.z = value; break;
                }
            }
        }

        public long[] ConvertLongArray()
        {
            return new long[] { x.ScaledValue, y.ScaledValue, z.ScaledValue };
        }

        public override bool Equals(object obj)
        {
            if (obj is CodingKVector3 cv)
            {
                return this.x == cv.x && this.y == cv.y && this.z == cv.z;
            }

            return false;
        }

        public override string ToString()
        {
            return $"x:{x} y:{y} z:{z}";
        }

        public override int GetHashCode()
        {
            return x.GetHashCode();
        }

        #region 定义常用向量

        public static CodingKVector3 zero
        {
            get { return new CodingKVector3(0, 0, 0); }
        }

        public static CodingKVector3 one
        {
            get { return new CodingKVector3(1, 1, 1); }
        }

        public static CodingKVector3 forward
        {
            get { return new CodingKVector3(0, 0, 1); }
        }

        public static CodingKVector3 back
        {
            get { return new CodingKVector3(0, 0, -1); }
        }

        public static CodingKVector3 left
        {
            get { return new CodingKVector3(-1, 0, 0); }
        }

        public static CodingKVector3 right
        {
            get { return new CodingKVector3(1, 0, 0); }
        }

        public static CodingKVector3 up
        {
            get { return new CodingKVector3(0, 1, 0); }
        }

        public static CodingKVector3 down
        {
            get { return new CodingKVector3(0, -1, 0); }
        }
        #endregion

        #region 运算符

        public static CodingKVector3 operator -(CodingKVector3 v1)
        {
            CodingKInt x = -v1.x;
            CodingKInt y = -v1.y;
            CodingKInt z = -v1.z;
            return new CodingKVector3(x, y, z);
        }

        public static bool operator ==(CodingKVector3 v1, CodingKVector3 v2)
        {
            return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        }

        public static bool operator !=(CodingKVector3 v1, CodingKVector3 v2)
        {
            return !(v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        public static CodingKVector3 operator +(CodingKVector3 v1, CodingKVector3 v2)
        {
            CodingKInt x = v1.x + v2.x;
            CodingKInt y = v1.y + v2.y;
            CodingKInt z = v1.z + v2.z;
            return new CodingKVector3(x,y,z);
        }

        public static CodingKVector3 operator -(CodingKVector3 v1, CodingKVector3 v2)
        {
            CodingKInt x = v1.x - v2.x;
            CodingKInt y = v1.y - v2.y;
            CodingKInt z = v1.z - v2.z;
            return new CodingKVector3(x, y, z);
        }

        public static CodingKVector3 operator *(CodingKVector3 v1,CodingKInt val)
        {
            CodingKInt x = v1.x * val;
            CodingKInt y = v1.y * val;
            CodingKInt z = v1.z * val;
            return new CodingKVector3(x, y, z);
        }

        public static CodingKVector3 operator *(CodingKInt val, CodingKVector3 v1)
        {
            CodingKInt x = v1.x * val;
            CodingKInt y = v1.y * val;
            CodingKInt z = v1.z * val;
            return new CodingKVector3(x, y, z);
        }

        public static CodingKVector3 operator /(CodingKVector3 v1, CodingKInt val)
        {
            CodingKInt x = v1.x / val;
            CodingKInt y = v1.y / val;
            CodingKInt z = v1.z / val;
            return new CodingKVector3(x, y, z);
        }

        public static CodingKVector3 operator /(CodingKInt val, CodingKVector3 v1)
        {
            CodingKInt x = v1.x / val;
            CodingKInt y = v1.y / val;
            CodingKInt z = v1.z / val;
            return new CodingKVector3(x, y, z);
        }



        #endregion

        /// <summary>
        /// 返回规格化向量
        /// </summary>
        public CodingKVector3 normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static CodingKVector3 Normalize(CodingKVector3 vec)
        {
            if (vec.magnitude > 0)
            {
                CodingKInt rate = CodingKInt.one / vec.magnitude;
                return new CodingKVector3(rate * vec.x, rate * vec.y, rate * vec.z);
            }
            else
            {
                return zero;
            }
        }

        /// <summary>
        /// 对自身进行规格化
        /// </summary>
        public void Normalize()
        {
            CodingKInt rate = CodingKInt.one / this.magnitude;
            this.x *= rate;
            this.y *= rate;
            this.z *= rate;
        }

        public CodingKInt magnitude
        {
            get
            {
                return this.sqrMagnitude.Sqrt();
            }
        }

        /// <summary>
        /// 当前向量长度平方
        /// </summary>
        public CodingKInt sqrMagnitude
        {
            get
            {
                return SqrMagnitude(this);
            }
        }

        public static CodingKInt SqrMagnitude(CodingKVector3 vec)
        {
            return vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;
        }

        #region 几何运算

        /// <summary>
        /// 点乘
        /// </summary>
        public static CodingKInt Dot(CodingKVector3 v1, CodingKVector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// 叉乘
        /// </summary>
        public static CodingKVector3 Cross(CodingKVector3 v1, CodingKVector3 v2)
        {
            return new CodingKVector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }

        /// <summary>
        /// 夹角
        /// </summary>
        public static CodingKArgs Angle(CodingKVector3 from, CodingKVector3 to)
        {
            CodingKInt dot = Dot(from, to);
            CodingKInt mod = from.magnitude * to.magnitude;
            if (mod == 0)
            {
                return CodingKArgs.zero;
            }
            CodingKInt val = dot / mod;

            // 反余弦函数
            return CodingKCalc.Acos(val);
        }

        #endregion

    }
}
