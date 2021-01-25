using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this Span<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
            => ((ReadOnlySpan<TSource>)source).Contains(value, comparer);
    }
}

