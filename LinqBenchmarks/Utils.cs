using System.Runtime.CompilerServices;

namespace LinqBenchmarks
{
    static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEven(this int value)
            => (value & 0x01) == 0;
    }
}
