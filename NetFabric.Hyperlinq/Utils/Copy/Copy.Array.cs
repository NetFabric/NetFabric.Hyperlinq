using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(TSource[] source, Span<TSource> destination)
        {
            Debug.Assert(destination.Length >= source.Length);

            source.CopyTo(destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(TSource[] source, Span<TResult> destination, NullableSelector<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Length);

            var array = source;
            for (var index = 0; index < array.Length; index++)
                destination[index] = selector(array[index])!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(TSource[] source, Span<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Length);

            var array = source;
            for (var index = 0; index < array.Length; index++)
                destination[index] = selector(array[index], index)!;
        }
    }
}
