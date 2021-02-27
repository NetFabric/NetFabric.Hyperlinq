using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        static TSource Sum<TSource>(this ReadOnlySpan<TSource> source)
            where TSource : struct
        {
            var sum = default(TSource);

            if (Vector.IsHardwareAccelerated && source.Length > Vector<TSource>.Count * 2) // use SIMD
            {
                var vectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
                var vectorSum = Vector<TSource>.Zero;

                foreach (var vector in vectors)
                    vectorSum += vector;

                for (var index = 0; index < Vector<TSource>.Count; index++)
                    sum = GenericsOperator.Add(vectorSum[index], sum);

                for (var index = source.Length - (source.Length % Vector<TSource>.Count); index < source.Length; index++)
                {
                    var item = source[index];
                    sum = GenericsOperator.Add(item, sum);
                }
            }
            else
            { 
                foreach (var item in source)
                    sum = GenericsOperator.Add(item, sum);
            }

            return sum;
        }

        static TResult Sum<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            var sum = default(TResult);

            if (Vector.IsHardwareAccelerated && source.Length > Vector<TResult>.Count * 2) // use SIMD
            {
                var vectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
                var vectorSum = Vector<TResult>.Zero;

                foreach (var vector in vectors)
                    vectorSum += vectorSelector.Invoke(vector);

                for (var index = 0; index < Vector<TResult>.Count; index++)
                    sum = GenericsOperator.Add(vectorSum[index], sum);

                for (var index = source.Length - (source.Length % Vector<TSource>.Count); index < source.Length; index++)
                {
                    var item = source[index];
                    sum = GenericsOperator.Add(selector.Invoke(item), sum);
                }
            }
            else
            {
                foreach (var item in source)
                    sum = GenericsOperator.Add(selector.Invoke(item), sum);
            }
            return sum;
        }
        
        static TSum Sum<TSource, TSum>(this ReadOnlySpan<TSource> source)
            where TSum : struct
        {
            var sum = default(TSum);

            foreach (var item in source)
                sum = GenericsOperator.AddNullable(item, sum);

            return sum;
        }

        static TSum Sum<TSource, TSum, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    sum = GenericsOperator.AddNullable(item, sum);
            }
            return sum;
        }

        static TSum SumAt<TSource, TSum, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    sum = GenericsOperator.AddNullable(item, sum);
            }
            return sum;
        }

        static TSum Sum<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
                sum = GenericsOperator.AddNullable(selector.Invoke(item), sum);
            return sum;
        }

        static TSum SumAt<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                sum = GenericsOperator.AddNullable(selector.Invoke(item, index), sum);
            }
            return sum;
        }
        
        static TSum Sum<TSource, TResult, TSum, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    sum = GenericsOperator.AddNullable(selector.Invoke(item), sum);
            }
            return sum;
        }
    }
}

