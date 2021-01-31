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
            if (source.Any())
                Array.Copy(source.Array, source.Offset, destination, 0, source.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, Span<TSource> destination)
            => source.AsSpan().CopyTo(destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult, TSelector>(in ArraySegment<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        destination[index] = selector.Invoke(item);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        destination[index] = selector.Invoke(item);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyRef<TSource, TResult, TSelector>(in ArraySegment<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        destination[index] = selector.Invoke(item);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        destination[index] = selector.Invoke(item);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAt<TSource, TResult, TSelector>(in ArraySegment<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        destination[index] = selector.Invoke(item, index);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        destination[index] = selector.Invoke(item, index);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAtRef<TSource, TResult, TSelector>(in ArraySegment<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Count);

            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        destination[index] = selector.Invoke(in item, index);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        destination[index] = selector.Invoke(in item, index);
                    }
                }
            }
        }
    }
}
