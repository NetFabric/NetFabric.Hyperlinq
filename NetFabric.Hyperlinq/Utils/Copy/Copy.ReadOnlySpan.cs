using System;
using System.Diagnostics;
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
        public static void Copy<TSource, TResult>(ReadOnlySpan<TSource> source, Span<TResult> destination, NullableSelector<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length; index++)
                destination[index] = selector(source[index])!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(ReadOnlySpan<TSource> source, Span<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length; index++)
                destination[index] = selector(source[index], index)!;
        }
    }
}
