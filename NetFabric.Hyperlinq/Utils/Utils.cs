using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int SkipCount, int TakeCount) Skip(int sourceCount, int skipCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Max(0, sourceCount - skipCount));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (long SkipCount, long TakeCount) Skip(long sourceCount, long skipCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Max(0, sourceCount - skipCount));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Take(int sourceCount, int takeCount)
            => Math.Min(sourceCount, Math.Max(0, takeCount)); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Take(long sourceCount, long takeCount)
            => Math.Min(sourceCount, Math.Max(0, takeCount)); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int SkipCount, int TakeCount) SkipTake(int sourceCount, int skipCount, int takeCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Min(sourceCount - skipCount, Math.Max(0, takeCount))); 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (long SkipCount, long TakeCount) SkipTake(long sourceCount, long skipCount, long takeCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Min(sourceCount - skipCount, Math.Max(0, takeCount))); 
        }
    }
}
