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
        public static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source)
        {
            var list = new List<TSource>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(source[index]);
            return list;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TSource>(collection: arrayBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(selector.Invoke(source[index])!);
            return list;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(selector.Invoke(source[index], index)!);
            return list;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            // ReSharper disable once HeapView.BoxingAllocation
            return new List<TResult>(collection: arrayBuilder);
        }
    }
}
