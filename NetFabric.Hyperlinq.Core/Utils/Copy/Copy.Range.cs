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
        public static void CopyRange(int start, int count, Span<int> destination)
        {
            Debug.Assert(destination.Length >= count);

            destination = destination.Slice(0, count);

            if (Vector.IsHardwareAccelerated && count >= Vector<int>.Count)
            {
                var destinationVectors = MemoryMarshal.Cast<int, Vector<int>>(destination);

                if (start is 0)
                {
                    for (var index = 0; index < Vector<int>.Count; index++)
                        destination[index] = index;
                }
                else
                {
                    for (var index = 0; index < Vector<int>.Count; index++)
                        destination[index] = index + start;
                }

                var increment = new Vector<int>(Vector<int>.Count);
                var vector = destinationVectors[0];

                for (var index = 1; index < destinationVectors.Length; index++)
                {
                    vector += increment;
                    destinationVectors[index] = vector;
                }

                if (start is 0)
                {
                    for (var index = count - (count % Vector<int>.Count); index < destination.Length; index++)
                        destination[index] = index;
                }
                else
                {
                    for (var index = count - (count % Vector<int>.Count); index < destination.Length; index++)
                        destination[index] = index + start;
                }
            }
            else
            {
                if (start is 0)
                {
                    for (var index = 0; index < destination.Length; index++)
                        destination[index] = index;
                }
                else
                {
                    for (var index = 0; index < destination.Length; index++)
                        destination[index] = index + start;
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void CopyRange<TResult, TVectorSelector, TSelector>(int start, int count, Span<TResult> destination, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            Debug.Assert(destination.Length >= count);

            destination = destination.Slice(0, count);

            if (Vector.IsHardwareAccelerated && count > Vector<int>.Count * 2)
            {
                var seed = stackalloc int[Vector<int>.Count];
                if (start is 0)
                {
                    for (var spanIndex = 0; spanIndex < Vector<int>.Count; spanIndex++)
                        seed[spanIndex] = spanIndex;
                }
                else
                {
                    for (var spanIndex = 0; spanIndex < Vector<int>.Count; spanIndex++)
                        seed[spanIndex] = spanIndex + start;
                }

                var destinationVectors = MemoryMarshal.Cast<TResult, Vector<TResult>>(destination);
                var vector = Unsafe.AsRef<Vector<int>>(seed);
                var vectorIncrement = new Vector<int>(Vector<int>.Count);

                for (var index = 0; index < destinationVectors.Length; index++)
                {
                    destinationVectors[index] = vectorSelector.Invoke(vector);
                    vector += vectorIncrement;
                }

                if (start is 0)
                {
                    for (var index = count - (count % Vector<TResult>.Count); index < destination.Length; index++)
                        destination[index] = selector.Invoke(index);
                }
                else
                {
                    for (var index = count - (count % Vector<TResult>.Count); index < destination.Length; index++)
                        destination[index] = selector.Invoke(index + start);
                }
            }
            else
            {
                if (start is 0)
                {
                    for (var index = 0; index < destination.Length; index++)
                        destination[index] = selector.Invoke(index);
                }
                else
                {
                    for (var index = 0; index < destination.Length; index++)
                        destination[index] = selector.Invoke(index + start);
                }
            }
        }

    }
}
