using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyRange(int start, int count, Span<int> destination)
        {
            Debug.Assert(destination.Length >= count);
            
#if NET5_0

            if (Vector.IsHardwareAccelerated && count >= Vector<int>.Count)
            {
                var copySpan = destination.Slice(0, Vector<int>.Count); // bounds check removal
                if (start is 0)
                {
                    for (var spanIndex = 0; spanIndex < copySpan.Length; spanIndex++)
                        copySpan[spanIndex] = spanIndex;
                }
                else
                {
                    for (var spanIndex = 0; spanIndex < copySpan.Length; spanIndex++)
                        copySpan[spanIndex] = spanIndex + start;
                }

                var vector = new Vector<int>(copySpan);
                var increment = new Vector<int>(Vector<int>.Count);
                vector += increment;
                
                var index = Vector<int>.Count;
                for (; index <= count - Vector<int>.Count; index += Vector<int>.Count)
                {
                    vector.CopyTo(destination.Slice(index, Vector<int>.Count));
                    vector += increment;
                }

                if (start is 0)
                {
                    for (; index < destination.Length; index++)
                        destination[index] = index;
                }
                else
                {
                    for (; index < destination.Length; index++)
                        destination[index] = index + start;
                }
                
                return;
            }
            
#endif
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyRange<TResult, TVectorSelector, TSelector>(int start, int count, Span<TResult> destination, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            Debug.Assert(destination.Length >= count);
            
#if NET5_0
            
            if (Vector.IsHardwareAccelerated && count >= Vector<int>.Count)
            {
                Span<int> seed = stackalloc int[Vector<int>.Count]; 
                if (start is 0)
                {
                    for (var spanIndex = 0; spanIndex < seed.Length; spanIndex++)
                        seed[spanIndex] = spanIndex;
                }
                else
                {
                    for (var spanIndex = 0; spanIndex < seed.Length; spanIndex++)
                        seed[spanIndex] = spanIndex + start;
                }

                var vector = new Vector<int>(seed);
                var vectorProjection = vectorSelector.Invoke(vector);

                var increment = new Vector<int>(Vector<int>.Count);
                var index = 0;
                for (; index <= count - Vector<int>.Count; index += Vector<int>.Count)
                {
                    vectorProjection.CopyTo(destination.Slice(index, Vector<int>.Count));
                    vector += increment;
                    vectorProjection = vectorSelector.Invoke(vector);
                }

                if (start is 0)
                {
                    for (; index < destination.Length; index++)
                        destination[index] = selector.Invoke(index);
                }
                else
                {
                    for (; index < destination.Length; index++)
                        destination[index] = selector.Invoke(index + start);
                }

                return;
            }
            
#endif
            
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
