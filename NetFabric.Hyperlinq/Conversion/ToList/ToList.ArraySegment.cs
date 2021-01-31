using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source)
            // ReSharper disable once HeapView.BoxingAllocation
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => new(collection: source)
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray<TSource, TPredicate>(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayRef<TSource, TPredicate>(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayAt<TSource, TPredicate>(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayAtRef<TSource, TPredicate>(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayAt<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListRef<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.Count switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayRef<TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList()
            };
    }
}