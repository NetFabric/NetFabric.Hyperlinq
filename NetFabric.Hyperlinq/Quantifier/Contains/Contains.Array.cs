using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value)
            => ((ICollection<TSource>)source).Contains(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer)
            => comparer is null
                ? Contains(source, value)
                : new ArraySegment<TSource>(source).Contains(value, comparer);
    }
}

