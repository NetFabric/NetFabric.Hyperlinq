using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source)
        {
            var list = new List<TSource>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(source[index]);
            return list;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
            => new List<TSource>(ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
            => new List<TSource>(ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(selector(source[index])!);
            return list;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(selector(source[index], index)!);
            return list;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => new List<TResult>(ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared));
    }
}
