using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks
{
    static class Int32Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEven(this int value) 
            => (value & 0x01) == 0;
    }
}
