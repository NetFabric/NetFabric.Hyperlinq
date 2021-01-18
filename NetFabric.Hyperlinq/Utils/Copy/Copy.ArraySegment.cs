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
            if (source.Array is not null)
                Array.Copy(source.Array, source.Offset, destination, 0, source.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, Span<TSource> destination)
            => source.AsSpan().CopyTo(destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult, TSelector>(in ArraySegment<TSource> source, Span<TResult> destination, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array!)
                    {
                        destination[index] = selector.Invoke(item);
                        index++;
                    }
                }
                else
                {
                    var array = source.Array!;
                    if (source.Offset is 0)
                    {
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector.Invoke(array[index]);
                    }
                    else
                    {
                        var offset = source.Offset;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector.Invoke(array[index + offset]);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAt<TSource, TResult, TSelector>(in ArraySegment<TSource> source, Span<TResult> destination, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array!)
                    {
                        destination[index] = selector.Invoke(item, index);
                        index++;
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Count - 1;
                    if (source.Offset is 0)
                    {
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector.Invoke(array[index], index);
                    }
                    else
                    {
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                            destination[index] = selector.Invoke(array[index + offset], index);
                    }
                }
            }
        }
    }
}
