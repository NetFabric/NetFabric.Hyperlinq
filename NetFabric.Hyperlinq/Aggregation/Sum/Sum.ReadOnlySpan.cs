using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlySpan<int> source)
            => Sum<int, AddInt32>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlySpan<int?> source)
            => Sum<int?, int, AddNullableInt32>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlySpan<long> source)
            => Sum<long, AddInt64>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlySpan<long?> source)
            => Sum<long?, long, AddNullableInt64>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlySpan<float> source)
            => Sum<float, AddSingle>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlySpan<float?> source)
            => Sum<float?, float, AddNullableSingle>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlySpan<double> source)
            => Sum<double, AddDouble>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlySpan<double?> source)
            => Sum<double?, double, AddNullableDouble>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlySpan<decimal> source)
            => Sum<decimal, AddDecimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlySpan<decimal?> source)
            => Sum<decimal?, decimal, AddNullableDecimal>(source);

        ///////////////////////////////////////////////////////////

        static TSource Sum<TSource, TAddition>(this ReadOnlySpan<TSource> source, TAddition add = default)
            where TAddition : struct, IFunction<TSource, TSource, TSource>
            where TSource : struct
        {
            var sum = default(TSource);

#if NET5_0 

            if (source.Length >= Vector<TSource>.Count) // use SIMD
            {
                var state = Vector<TSource>.Zero;
                var count = Vector<TSource>.Count;

                var index = 0;
                for (; index <= source.Length - count; index += count)
                {
#pragma warning disable IDE0054 // Use compound assignment
                    state = state + new Vector<TSource>(source[index..]);
#pragma warning restore IDE0054 // Use compound assignment
                }

                for (; index < source.Length; index++)
                    sum = add.Invoke(source[index], sum);

                for (var vectorIndex = 0; vectorIndex < count; vectorIndex++)
                    sum = add.Invoke(state[vectorIndex], sum);
            }
            else
            {
                foreach (var item in source)
                    sum = add.Invoke(item, sum);
            }
#else

            foreach (var item in source)
                sum = add.Invoke(item, sum);

#endif

            return sum;
        }

        static TSum Sum<TSource, TSum, TAddition>(this ReadOnlySpan<TSource> source, TAddition add = default)
            where TAddition : struct, IFunction<TSource, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);

            foreach (var item in source)
                sum = add.Invoke(item, sum);

            return sum;
        }

        static TSum Sum<TSource, TSum, TPredicate, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TAddition add = default)
            where TPredicate : struct, IFunction<TSource, bool>
            where TAddition : struct, IFunction<TSource, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        static TSum SumRef<TSource, TSum, TPredicate, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TAddition add = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TAddition : struct, IFunction<TSource, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        static TSum SumAt<TSource, TSum, TPredicate, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TAddition add = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            where TAddition : struct, IFunction<TSource, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        static TSum SumAtRef<TSource, TSum, TPredicate, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TAddition add = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            where TAddition : struct, IFunction<TSource, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item, index))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        static TSum Sum<TSource, TResult, TSum, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TSelector selector, TAddition add = default)
            where TSelector : struct, IFunction<TSource, TResult>
            where TAddition : struct, IFunction<TResult, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
                sum = add.Invoke(selector.Invoke(item), sum);
            return sum;
        }

        static TSum SumRef<TSource, TResult, TSum, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TSelector selector, TAddition add = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TAddition : struct, IFunction<TResult, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
                sum = add.Invoke(selector.Invoke(in item), sum);
            return sum;
        }

        static TSum SumAt<TSource, TResult, TSum, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TSelector selector, TAddition add = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TAddition : struct, IFunction<TResult, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                sum = add.Invoke(selector.Invoke(item, index), sum);
            }
            return sum;
        }

        static TSum SumAtRef<TSource, TResult, TSum, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TSelector selector, TAddition add = default)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            where TAddition : struct, IFunction<TResult, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                sum = add.Invoke(selector.Invoke(in item, index), sum);
            }
            return sum;
        }


        static TSum Sum<TSource, TResult, TSum, TPredicate, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, TAddition add = default)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            where TAddition : struct, IFunction<TResult, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    sum = add.Invoke(selector.Invoke(item), sum);
            }
            return sum;
        }

        static TSum SumRef<TSource, TResult, TSum, TPredicate, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, TAddition add = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TAddition : struct, IFunction<TResult, TSum, TSum>
            where TSum : struct
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                    sum = add.Invoke(selector.Invoke(in item), sum);
            }
            return sum;
        }
    }
}

