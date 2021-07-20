using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static TSum Sum<TSource, TSum>(this ReadOnlySpan<TSource> source)
            where TSum : struct
        {
            var sum0 = default(TSum);
            var sum1 = default(TSum);
            for (var index = 0; index < source.Length - 1; index += 2)
            {
                var item0 = source[index];
                var item1 = source[index + 1];
                sum0 = Scalar.Add(item0, sum0);
                sum1 = Scalar.Add(item1, sum1);
            }
            
            if (source.Length.IsOdd())
                sum0 = Scalar.Add(source[source.Length - 1], sum0);

            return Scalar.Add(sum0, sum1);
        }
        

        static TSum SumVector<TSource, TSum>(this ReadOnlySpan<TSource> source)
            where TSource : struct
            where TSum : struct
        {
            if (!Vector.IsHardwareAccelerated || source.Length <= Vector<TSource>.Count * 2) 
                return Sum<TSource, TSum>(source);
                
            var vectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
            var vectorSum = Vector<TSource>.Zero;

            foreach (var vector in vectors)
                vectorSum += vector;

            var count = source.Length % Vector<TSource>.Count;
            return Scalar.Add(vectorSum.Sum(), Sum<TSource, TSum>(source.Slice(source.Length - count, count)));
        }


        static TSum Sum<TSource, TSum, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSum : struct
        {
            var sum0 = default(TSum);
            var sum1 = default(TSum);
            for (var index = 0; index < source.Length - 1; index += 2)
            {
                var item0 = source[index];
                var item1 = source[index + 1];
                sum0 = Scalar.Add(Scalar.GetValueOrDefault(predicate, item0), sum0);
                sum1 = Scalar.Add(Scalar.GetValueOrDefault(predicate, item1), sum1);
            }
            if (source.Length.IsOdd())
            {
                var item = source[source.Length - 1];
                sum0 = Scalar.Add(Scalar.GetValueOrDefault(predicate, item), sum0);
            }
            return Scalar.Add(sum0, sum1);
        }


        static TSum SumAt<TSource, TSum, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            where TSum : struct
        {
            var sum0 = default(TSum);
            var sum1 = default(TSum);
            for (var index = 0; index < source.Length - 1; index += 2)
            {
                var item0 = source[index];
                var item1 = source[index + 1];
                sum0 = Scalar.Add(Scalar.GetValueOrDefault(predicate, item0, index), sum0);
                sum1 = Scalar.Add(Scalar.GetValueOrDefault(predicate, item1, index + 1), sum1);
            }
            if (source.Length.IsOdd())
            {
                var index = source.Length - 1;
                var item = source[index];
                sum0 = Scalar.Add(Scalar.GetValueOrDefault(predicate, item, index), sum0);
            }
            return Scalar.Add(sum0, sum1);
        }


        static TSum Sum<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum0 = default(TSum);
            var sum1 = default(TSum);
            for (var index = 0; index < source.Length - 1; index += 2)
            {
                var item0 = source[index];
                var item1 = source[index + 1];
                sum0 = Scalar.Add(selector.Invoke(item0), sum0);
                sum1 = Scalar.Add(selector.Invoke(item1), sum1);
            }
            
            if (source.Length.IsOdd())
                sum0 = Scalar.Add(selector.Invoke(source[source.Length - 1]), sum0);

            return Scalar.Add(sum0, sum1);
        }
        

        static TSum SumVector<TSource, TResult, TSum, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            where TSum : struct
        {
            if (!Vector.IsHardwareAccelerated || source.Length <= Vector<TSource>.Count * 2) 
                return Sum<TSource, TSum>(source);
                
            var vectors = MemoryMarshal.Cast<TSource, Vector<TSource>>(source);
            var vectorSum = Vector<TResult>.Zero;

            foreach (var vector in vectors)
                vectorSum += vectorSelector.Invoke(vector);

            var count = source.Length % Vector<TSource>.Count;
            return Scalar.Add(vectorSum.Sum(), Sum<TSource, TResult, TSum, TSelector>(source.Slice(source.Length - count, count), selector));
        }


        static TSum SumAt<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TSum : struct
        {
            var sum0 = default(TSum);
            var sum1 = default(TSum);
            for (var index = 0; index < source.Length - 1; index += 2)
            {
                var item0 = source[index];
                var item1 = source[index + 1];
                sum0 = Scalar.Add(selector.Invoke(item0, index), sum0);
                sum1 = Scalar.Add(selector.Invoke(item1, index + 1), sum1);
            }
            if (source.Length.IsOdd())
            {
                var index = source.Length - 1;
                sum0 = Scalar.Add(selector.Invoke(source[index], index), sum0);
            }
            return Scalar.Add(sum0, sum1);
        }
        

        static TSum Sum<TSource, TResult, TSum, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum0 = default(TSum);
            var sum1 = default(TSum);
            for (var index = 0; index < source.Length - 1; index += 2)
            {
                var item0 = source[index];
                var item1 = source[index + 1];
                if (predicate.Invoke(item0))
                    sum0 = Scalar.Add(selector.Invoke(item0), sum0);
                if (predicate.Invoke(item1))
                    sum1 = Scalar.Add(selector.Invoke(item1), sum1);
            }
            if (source.Length.IsOdd())
            {
                var item = source[source.Length - 1];
                if (predicate.Invoke(item))
                    sum0 = Scalar.Add(selector.Invoke(item), sum0);
            }
            return Scalar.Add(sum0, sum1);
        }
    }
}

