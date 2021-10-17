using System.Runtime.CompilerServices;

namespace LinqBenchmarks;

readonly struct FatValueTypeEqualityComparer 
    : IEqualityComparer<FatValueType>
        , StructLinq.IInEqualityComparer<FatValueType>
{
    // Coherent with IComparable implementation of FatValueType
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FatValueType x, FatValueType y)
        => x.Value0 == y.Value0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetHashCode(FatValueType obj) 
        => obj.Value0.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(in FatValueType x, in FatValueType y)
        => x.Value0 == y.Value0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetHashCode(in FatValueType obj)
        => obj.Value0.GetHashCode();
}