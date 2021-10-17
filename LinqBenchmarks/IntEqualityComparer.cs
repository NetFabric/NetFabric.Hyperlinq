using System.Runtime.CompilerServices;

namespace LinqBenchmarks;

readonly struct IntEqualityComparer : IEqualityComparer<int>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(int x, int y) 
        => x == y;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetHashCode(int obj) 
        => obj;

}