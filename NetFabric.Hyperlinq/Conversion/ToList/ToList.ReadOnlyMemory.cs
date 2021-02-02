using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => source.Span.ToList();
    }
}