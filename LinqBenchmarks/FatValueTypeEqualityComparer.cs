using System.Collections.Generic;
using StructLinq;

namespace LinqBenchmarks
{

    readonly struct FatValueTypeEqualityComparer : IEqualityComparer<FatValueType>, IInEqualityComparer<FatValueType>
    {
        // Coherent with IComparable implementation of FatValueType
        public bool Equals(FatValueType x, FatValueType y)
        {
            return x.Value0 == y.Value0;
        }

        public int GetHashCode(FatValueType obj) 
        {
            return obj.Value0.GetHashCode();
        }
        public bool Equals(in FatValueType x, in FatValueType y)
        {
            return x.Value0 == y.Value0;
        }

        public int GetHashCode(in FatValueType obj)
        {
            return obj.Value0.GetHashCode();
        }
    }
}
