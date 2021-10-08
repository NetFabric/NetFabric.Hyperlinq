using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int SumRange(int start, int count)
            => count * (start + start + count) / 2;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static unsafe TResult SumRange<TResult, TVectorSelector, TSelector>(int start, int count, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            var sum = default(TResult);

            var index = 0;
            if (Vector.IsHardwareAccelerated && count > Vector<TResult>.Count * 4) // use SIMD
            {
                var seed = stackalloc int[Vector<TResult>.Count]; 
                if (start is 0)
                {
                    for (index = 0; index < Vector<TResult>.Count; index++)
                        seed[index] = index;
                }
                else
                {
                    for (index = 0; index < Vector<TResult>.Count; index++)
                        seed[index] = index + start;
                }

                var vector = Unsafe.AsRef<Vector<int>>(seed);
                var vectorIncrement = new Vector<int>(Vector<TResult>.Count);
                var vectorSum = Vector<TResult>.Zero;
                for (index = 0; index <= count - Vector<TResult>.Count; index += Vector<TResult>.Count)
                {
                    vectorSum += vectorSelector.Invoke(vector);
                    vector += vectorIncrement;
                }

                for (index = 0; index < Vector<TResult>.Count; index++)
                    sum = Scalar.Add(vectorSum[index], sum);
            }

            if (start is 0)
            {
                for (; index < count; index++)
                    sum = Scalar.Add(selector.Invoke(index), sum);
            }
            else
            {
                for (; index < count; index++)
                    sum = Scalar.Add(selector.Invoke(index + start), sum);
            }

            return sum;
        }
    }
}

