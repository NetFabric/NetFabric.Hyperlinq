using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, TSource[] destination)
        {
            if (source.Array is object)
                Array.Copy(source.Array, source.Offset, destination, 0, source.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, Span<TSource> destination)
            => source.AsSpan().CopyTo(destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(in ArraySegment<TSource> source, Span<TResult> destination, NullableSelector<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        destination[index] = selector(item)!;
                        index++;
                    }
                }
                else
                {
                    if (source.Offset == 0)
                    {
                        var array = source.Array;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector(array![index])!;
                    }
                    else
                    {
                        var array = source.Array;
                        var offset = source.Offset;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector(array![index + offset])!;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult>(in ArraySegment<TSource> source, Span<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        destination[index] = selector(item, index)!;
                        index++;
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        var array = source.Array;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector(array![index], index)!;
                    }
                    else
                    {
                        var array = source.Array;
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector(array![index + offset], index)!;
                    }
                }
            }
        }
    }
}
