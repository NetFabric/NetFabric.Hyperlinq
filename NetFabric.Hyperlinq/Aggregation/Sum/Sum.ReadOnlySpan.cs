using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlySpan<int> source)
            => Sum<int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlySpan<int?> source)
            => Sum<int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlySpan<long> source)
            => Sum<long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlySpan<long?> source)
            => Sum<long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlySpan<float> source)
            => Sum<float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlySpan<float?> source)
            => Sum<float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlySpan<double> source)
            => Sum<double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlySpan<double?> source)
            => Sum<double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlySpan<decimal> source)
            => Sum<decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlySpan<decimal?> source)
            => Sum<decimal?, decimal>(source);

        ///////////////////////////////////////////////////////////

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
                sum = GenericsOperator.Sum(item, sum);

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
                    sum = GenericsOperator.Sum(item, sum);
            }
            return sum;
        }

        static TSum SumRef<TSource, TSum, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                    sum = GenericsOperator.Sum(item, sum);
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
                    sum = GenericsOperator.Sum(item, sum);
            }
            return sum;
        }

        static TSum SumAtRef<TSource, TSum, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item, index))
                    sum = GenericsOperator.Sum(item, sum);
            }
            return sum;
        }

        static TSum Sum<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
                sum = GenericsOperator.Sum(selector.Invoke(item), sum);
            return sum;
        }

        static TSum SumRef<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
                sum = GenericsOperator.Sum(selector.Invoke(in item), sum);
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
                sum = GenericsOperator.Sum(selector.Invoke(item, index), sum);
            }
            return sum;
        }

        static TSum SumAtRef<TSource, TResult, TSum, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                sum = GenericsOperator.Sum(selector.Invoke(in item, index), sum);
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
                    sum = GenericsOperator.Sum(selector.Invoke(item), sum);
            }
            return sum;
        }

        static TSum SumRef<TSource, TResult, TSum, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                    sum = GenericsOperator.Sum(selector.Invoke(in item), sum);
            }
            return sum;
        }
    }
}

