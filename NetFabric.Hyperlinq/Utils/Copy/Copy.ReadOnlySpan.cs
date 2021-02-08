﻿using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(ReadOnlySpan<TSource> source, Span<TSource> destination)
        {
            Debug.Assert(destination.Length >= source.Length);

            source.CopyTo(destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length && index < destination.Length; index++)
            {
                var item = source[index];
                destination[index] = selector.Invoke(item);
            }
        }

#if NET5_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyVector<TSource, TResult, TVectorSelector, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            Debug.Assert(destination.Length >= source.Length);

            var index = 0;

            var count = Vector<TSource>.Count;
            if (count == Vector<TResult>.Count)
            {
                for (; index <= source.Length - count; index += count)
                    vectorSelector.Invoke(new Vector<TSource>(source[index..])).CopyTo(destination[index..]);
            }

            for (; index < source.Length && index < destination.Length; index++)
            {
                var item = source[index];
                destination[index] = selector.Invoke(item);
            }
        }
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyRef<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length && index < destination.Length; index++)
            {
                ref readonly var item = ref source[index];
                destination[index] = selector.Invoke(in item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAt<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length && index < destination.Length; index++)
            {
                var item = source[index];
                destination[index] = selector.Invoke(item, index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAtRef<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length && index < destination.Length; index++)
            {
                ref readonly var item = ref source[index];
                destination[index] = selector.Invoke(in item, index);
            }
        }
    }
}
