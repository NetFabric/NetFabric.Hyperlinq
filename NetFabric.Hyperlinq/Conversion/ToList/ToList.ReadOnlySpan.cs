﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source)
            => source switch
            {
                { Length: 0 } => new List<TSource>(),
                _ => source.ToArray().AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => source switch
            {
                { Length: 0 } => new List<TSource>(),
                _ => source.ToArray(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source switch
            {
                { Length: 0 } => new List<TSource>(),
                _ => source.ToArrayAt(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Length: 0 } => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source switch
            {
                { Length: 0 } => new List<TResult>(),
                _ => source.ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                { Length: 0 } => new List<TResult>(),
                _ => source.ToArrayAt<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Length: 0 } => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList()
            };
    }
}
