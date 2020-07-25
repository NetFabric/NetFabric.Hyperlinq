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

            var index = 0;
            foreach (var item in source)
            {
                destination[index] = selector(source[index])!;
                index++;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(TSource[] source, Span<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Length);

            var index = 0;
            foreach (var item in source)
            {
                destination[index] = selector(source[index], index)!;
                index++;
            }
        }
    }
}
