using System;

namespace LinqBenchmarks
{
    public struct FatValueType : IComparable<FatValueType>
    {
        public int Value0;
        public int Value1;
        public int Value2;
        public int Value3;
        public int Value4;
        public int Value5;
        public int Value6;
        public int Value7;
        public int Value8;
        public int Value9;

        public FatValueType(int value)
        {
            Value0 = value;
            Value1 = value;
            Value2 = value;
            Value3 = value;
            Value4 = value;
            Value5 = value;
            Value6 = value;
            Value7 = value;
            Value8 = value;
            Value9 = value;
        }

        public bool IsEven()
            => (Value0 & 0x01) == 0;

        public static FatValueType operator +(in FatValueType left, in FatValueType right)
            => new FatValueType(left.Value0 + right.Value0);

        public static FatValueType operator *(in FatValueType left, int right)
            => new FatValueType(left.Value0 * right);

        public int CompareTo(FatValueType other)
            => Value0 - other.Value0;
    }
}
