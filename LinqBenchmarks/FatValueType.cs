using System;
using System.Collections.Generic;

namespace LinqBenchmarks
{
    public struct FatValueType 
        : IEquatable<FatValueType>
        , IComparable<FatValueType>
    {
        public readonly int Value0 { get; }
        public readonly long Value1 { get; }
        public readonly long Value2 { get; }
        public readonly long Value3 { get; }
        public readonly long Value4 { get; }
        public readonly long Value5 { get; }
        public readonly long Value6 { get; }
        public readonly long Value7 { get; }

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
        }

        public readonly bool IsEven()
            => (Value0 & 0x01) == 0;

        public static bool operator ==(FatValueType left, FatValueType right) 
            => left.Equals(right);

        public static bool operator !=(FatValueType left, FatValueType right) 
            => !(left == right);

        public static FatValueType operator +(in FatValueType left, in FatValueType right)
            => new(left.Value0 + right.Value0);

        public static FatValueType operator *(in FatValueType left, int right)
            => new(left.Value0 * right);

        public int CompareTo(FatValueType other)
            => Value0 - other.Value0;

        public bool Equals(FatValueType other)
            => Value0 == other.Value0
            && Value1 == other.Value1
            && Value2 == other.Value2
            && Value3 == other.Value3
            && Value4 == other.Value4
            && Value5 == other.Value5
            && Value6 == other.Value6
            && Value7 == other.Value7;

        public override bool Equals(object obj)
            => obj is FatValueType value 
            && Equals(value);

        public override int GetHashCode()
            => HashCode.Combine(Value0, Value1, Value2, Value3, Value4, Value5, Value6, Value7);
    }

    public struct FatValueTypeComparer 
        : IEqualityComparer<FatValueType>
    {
        public bool Equals(FatValueType x, FatValueType y)
            => x.Equals(y);

        public int GetHashCode(FatValueType obj)
            => obj.GetHashCode();
    }
}
