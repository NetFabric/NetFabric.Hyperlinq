using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, predicate, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource>(source, predicate, ArrayPool<TSource>.Shared);
            return new List<TSource>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var arrayBuilder = ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, ArrayPool<TResult>.Shared);
            return new List<TResult>(arrayBuilder);
        }

    }
}
