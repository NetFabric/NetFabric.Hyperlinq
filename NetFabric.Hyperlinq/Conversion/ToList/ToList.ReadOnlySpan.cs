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
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray().AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayRef(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayAt(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayAtRef(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayRef<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayAt<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAtRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayAtRef<TSource, TResult, TSelector>(selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListRef<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayRef<TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList()
            };
    }
}
