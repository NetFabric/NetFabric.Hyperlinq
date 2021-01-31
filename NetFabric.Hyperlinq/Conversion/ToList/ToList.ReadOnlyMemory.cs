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
        public static List<TSource> ToList<TSource>(this ReadOnlyMemory<TSource> source)
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray().AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToList<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArray(predicate).AsList()
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TSource> ToListAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Length switch
            {
                0 => new List<TSource>(),
                _ => source.ToArrayAt<TSource, TPredicate>(predicate).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TSelector>(this ReadOnlyMemory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TSelector>(selector).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToListAt<TSource, TResult, TSelector>(this ReadOnlyMemory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArrayAt<TSource, TResult, TSelector>(selector).AsList()
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static List<TResult> ToList<TSource, TResult, TPredicate, TSelector>(this ReadOnlyMemory<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Length switch
            {
                0 => new List<TResult>(),
                _ => source.ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector).AsList()
            };
    }
}