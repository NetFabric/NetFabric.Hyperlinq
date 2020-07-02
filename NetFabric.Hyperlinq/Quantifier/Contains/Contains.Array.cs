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
        public static bool Contains<TSource>(this TSource[] source, [AllowNull] TSource value)
            => ((ICollection<TSource>)source).Contains(value);

#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => comparer is null
                ? Contains(source, value)
                : ArrayExtensions.Contains((ReadOnlySpan<TSource>)source, value, comparer);

#else

        public static bool Contains<TSource>(this TSource[] source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => comparer is null
                ? Contains(source, value)
                : ArrayExtensions.Contains(new ArraySegment<TSource>(source), value, comparer);

#endif
    }
}

