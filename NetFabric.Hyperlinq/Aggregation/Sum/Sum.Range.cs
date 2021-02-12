using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumRange(int start, int count)
            => count * (start + start + count) / 2;
        
#if NET5_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult SumRange<TResult, TVectorSelector, TSelector>(int start, int count, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            var sum = default(TResult);

            var end = start + count;
            var index = 0;

            var vectorSize = Vector<TResult>.Count;
            if (Vector.IsHardwareAccelerated && count >= vectorSize) // use SIMD
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
                var vectorIncrement = new Vector<int>(vectorSize);
                var vectorSum = Vector<TResult>.Zero;
                for (; index <= count - vectorSize; index += vectorSize)
                {
                    vectorSum = vectorSum + vectorSelector.Invoke(vector);
                    vector = vector + vectorIncrement;
                }

                for (index = 0; index < vectorSize; index++)
                    sum = GenericsOperator.Add(vectorSum[index], sum);
            }
            
            for (; index < count; index++)
            {
                var item = index + start;
                sum = GenericsOperator.Add(selector.Invoke(item), sum);
            }
            
            return sum;
        }
#endif
    }
}

