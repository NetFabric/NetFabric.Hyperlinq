using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Skip<TSource>(this Memory<TSource> source, int count)
        {
            var (skipCount, takeCount) = Utils.Skip(source.Length, count);
            return source.Slice(skipCount, takeCount);
        }
    }
}
