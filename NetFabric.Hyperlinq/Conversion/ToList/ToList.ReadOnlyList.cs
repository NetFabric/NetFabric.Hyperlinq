using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource>(this TList source, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray<TList, TSource>(offset, count).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray<TList, TSource, TPredicate>(predicate, offset, count).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayAt<TList, TSource, TPredicate>(predicate, offset, count).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TList, TSource, TResult, TSelector>(selector, offset, count).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayAt<TList, TSource, TResult, TSelector>(selector, offset, count).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TList, TSource, TResult, TPredicate, TSelector>(predicate, selector, offset, count).AsList()
            };
    }
}
