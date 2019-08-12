using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int SkipCount, int TakeCount) Skip(int sourceCount, int skipCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Max(0, sourceCount - skipCount));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Take(int sourceCount, int takeCount)
            => Math.Min(sourceCount, Math.Max(0, takeCount));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int SkipCount, int TakeCount) SkipTake(int sourceCount, int skipCount, int takeCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Min(sourceCount - skipCount, Math.Max(0, takeCount))); 
        }
    }
}
