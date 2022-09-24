using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                destination[index] = selector.Invoke(item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyVector<TSource, TResult, TVectorSelector, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            Debug.Assert(destination.Length >= source.Length);
            Debug.Assert(Vector<TSource>.Count == Vector<TResult>.Count);
            
            if (Vector.IsHardwareAccelerated && source.Length > Vector<TSource>.Count * 2)
            {
                var sourceVectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
                var destinationVectors = MemoryMarshal.Cast<TResult, Vector<TResult>>(destination);

                for (var index = 0; index < sourceVectors.Length && index < destinationVectors.Length; index++)
                {
                    var sourceVector = sourceVectors[index];
                    destinationVectors[index] = vectorSelector.Invoke(sourceVector);
                }

                for (var index = source.Length - (source.Length % Vector<TSource>.Count); index < source.Length; index++)
                {
                    var item = source[index];
                    destination[index] = selector.Invoke(item);
                }
            }
            else
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    destination[index] = selector.Invoke(item);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAt<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, Span<TResult> destination, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                destination[index] = selector.Invoke(item, index);
            }
        }
    }
}
