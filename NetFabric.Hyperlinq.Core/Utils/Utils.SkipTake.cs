using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int Offset, int Count) Skip(int sourceCount, int offset)
        {
            offset = Math.Min(sourceCount, Math.Max(0, offset));
            return (offset, Math.Max(0, sourceCount - offset));
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Take(int sourceCount, int count)
            => Math.Min(sourceCount, Math.Max(0, count));

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int Offset, int Count) SkipTake(int sourceCount, int offset, int count)
        {
            offset = Math.Min(sourceCount, Math.Max(0, offset));
            return (offset, Math.Min(sourceCount - offset, Math.Max(0, count))); 
        }
    }
}
