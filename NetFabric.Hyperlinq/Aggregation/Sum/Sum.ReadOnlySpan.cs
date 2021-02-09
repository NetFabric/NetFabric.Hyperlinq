using System;
using System.Numerics;
using System.Runtime.CompilerServices;

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

#if NET5_0 

            if (source.Length >= Vector<TSource>.Count) // use SIMD
            {
                var vectorSize = Vector<TSource>.Count;
                var vector = Vector<TSource>.Zero;

                var index = 0;
                for (; index <= source.Length - vectorSize; index += vectorSize)
                    vector = vector + new Vector<TSource>(source[index..]);

                for (; index < source.Length; index++)
                {
                    var item = source[index];
                    sum = GenericsOperator.Add(item, sum);
                }

                for (index = 0; index < vectorSize; index++)
                    sum = GenericsOperator.Add(vector[index], sum);
            }
            else
            {
                foreach (var item in source)
                    sum = GenericsOperator.Add(item, sum);
            }
#else

            foreach (var item in source)
                sum = GenericsOperator.Add(item, sum);

#endif

            return sum;
        }

#if NET5_0 
        static TResult Sum<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            var sum = default(TResult);

            if (source.Length >= Vector<TSource>.Count) // use SIMD
            {
                var vectorSize = Vector<TResult>.Count;
                var vector = Vector<TResult>.Zero;

                var index = 0;
                for (; index <= source.Length - vectorSize; index += vectorSize)
                    vector = vector + vectorSelector.Invoke(new Vector<TSource>(source[index..]));

                for (; index < source.Length; index++)
                {
                    var item = source[index];
                    sum = GenericsOperator.Add(selector.Invoke(item), sum);
                }

                for (index = 0; index < vectorSize; index++)
                    sum = GenericsOperator.Add(vector[index], sum);
            }
            else
            {
                foreach (var item in source)
                    sum = GenericsOperator.Add(selector.Invoke(item), sum);
            }
            return sum;
        }
#endif

            static TSum Sum<TSource, TSum>(this ReadOnlySpan<TSource> source)
            where TSum : struct
        {
            var sum = default(TSum);

            foreach (var item in source)
                sum = GenericsOperator.Sum(item, sum);

            return sum;
        }

        static TSum SumNullable<TSource, TSum>(this ReadOnlySpan<TSource> source)
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

