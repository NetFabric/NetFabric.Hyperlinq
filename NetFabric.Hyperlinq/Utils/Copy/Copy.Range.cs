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

            var index = 0;

#if NET5_0

            var vectorSize = Vector<int>.Count;
            if (Vector.IsHardwareAccelerated && count >= vectorSize)
            {
                var copySpan = destination.Slice(index, vectorSize); // bounds check removal
                if (start is 0)
                {
                    for (; index < copySpan.Length; index++)
                        copySpan[index] = index;
                }
                else
                {
                    for (; index < copySpan.Length; index++)
                        copySpan[index] = index + start;
                }

                var vector = new Vector<int>(copySpan);
                var increment = new Vector<int>(vectorSize);
                vector = vector + increment;
                for (; index <= count - vectorSize; index += vectorSize)
                {
                    vector.CopyTo(destination.Slice(index, vectorSize));
                    vector = vector + increment;
                }
            }

#endif

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
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyRange<TResult, TVectorSelector, TSelector>(int start, int count, Span<TResult> destination, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            Debug.Assert(destination.Length >= count);

            var index = 0;

#if NET5_0
            
            var vectorSize = Vector<int>.Count;
            if (Vector.IsHardwareAccelerated && count >= vectorSize)
            {
                Span<int> seed = stackalloc int[vectorSize]; 
                if (start is 0)
                {
                    for (; index < seed.Length; index++)
                        seed[index] = index;
                }
                else
                {
                    for (; index < seed.Length; index++)
                        seed[index] = index + start;
                }

                var vector = new Vector<int>(seed);
                var vectorProjection = new Vector<TResult>();
                vectorProjection = vectorSelector.Invoke(vector);

                var increment = new Vector<int>(vectorSize);
                for (index = 0; index <= count - vectorSize; index += vectorSize)
                {
                    vectorProjection.CopyTo(destination.Slice(index, vectorSize));
                    vector = vector + increment;
                    vectorProjection = vectorSelector.Invoke(vector);
                }
            }
            
#endif

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
        }

    }
}
