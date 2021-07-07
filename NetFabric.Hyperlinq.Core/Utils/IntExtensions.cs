using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class IntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEven(this int value)
            => (value & 1) is 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOdd(this int value)
            => (value & 1) is not 0;
    }
}