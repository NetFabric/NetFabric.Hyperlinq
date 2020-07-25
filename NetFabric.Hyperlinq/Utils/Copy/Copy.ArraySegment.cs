using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, TSource[] destination)
            => Array.Copy(source.Array, source.Offset, destination, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, Span<TSource> destination)
            => source.AsSpan().CopyTo(destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(in ArraySegment<TSource> source, Span<TResult> destination, NullableSelector<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Count);

            var array = source.Array;
            if (source.IsWhole())
            {
                var index = 0;
                foreach (var item in array)
                {
                    destination[index] = selector(item)!;
                    index++;
                }
            }
            else
            {
                if (source.Offset == 0)
                {
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                        destination[index] = selector(array[index])!;
                }
                else
                {
                    var offset = source.Offset;
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                        destination[index] = selector(array[index + offset])!;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(in ArraySegment<TSource> source, Span<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Count);

            var array = source.Array;
            if (source.IsWhole())
            {
                var index = 0;
                foreach (var item in array)
                {
                    destination[index] = selector(item, index)!;
                    index++;
                }
            }
            else
            {
                if (source.Offset == 0)
                {
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                        destination[index] = selector(array[index], index)!;
                }
                else
                {
                    var offset = source.Offset;
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                        destination[index] = selector(array[index + offset], index)!;
                }
            }
        }
    }
}
