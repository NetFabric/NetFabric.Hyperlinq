using System.Collections.Generic;

namespace LinqBenchmarks
{
    readonly struct FatValueTypeEqualityComparer : IEqualityComparer<FatValueType>
    {
        public bool Equals(FatValueType x, FatValueType y)
            => x.Value0 == y.Value0
            && x.Value1 == y.Value1
            && x.Value2 == y.Value2
            && x.Value3 == y.Value3
            && x.Value4 == y.Value4
            && x.Value5 == y.Value5
            && x.Value6 == y.Value6
            && x.Value7 == y.Value7
            && x.Value8 == y.Value8
            && x.Value9 == y.Value9;

        public int GetHashCode(FatValueType obj) 
            => (obj.Value0, obj.Value1, obj.Value2, obj.Value3, obj.Value4, obj.Value5, obj.Value6, obj.Value7, obj.Value8, obj.Value9).GetHashCode();

    }
}
