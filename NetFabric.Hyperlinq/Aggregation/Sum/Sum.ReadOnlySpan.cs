using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlySpan<int> source)
            => Sum<int, int, AddInt32>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlySpan<int?> source)
            => Sum<int?, int, AddNullableInt32>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlySpan<long> source)
            => Sum<long, long, AddInt64>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlySpan<long?> source)
            => Sum<long?, long, AddNullableInt64>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlySpan<float> source)
            => Sum<float, float, AddSingle>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlySpan<float?> source)
            => Sum<float?, float, AddNullableSingle>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlySpan<double> source)
            => Sum<double, double, AddDouble>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlySpan<double?> source)
            => Sum<double?, double, AddNullableDouble>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlySpan<decimal> source)
            => Sum<decimal, decimal, AddDecimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlySpan<decimal?> source)
            => Sum<decimal?, decimal, AddNullableDecimal>(source);

        ///////////////////////////////////////////////////////////

        static TSum Sum<TSource, TSum, TAddition>(this ReadOnlySpan<TSource> source, TAddition add = default)
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            foreach (var item in source)
                sum = add.Invoke(item, sum);
            return sum;
        }

        static TSum Sum<TSource, TSum, TPredicate, TAddition>(this ReadOnlySpan<TSource> source, TPredicate predicate, TAddition add = default)
            where TPredicate : struct, IFunction<TSource, bool>
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            foreach (var item in source)
                sum = add.Invoke(selector.Invoke(item), sum);
            return sum;
        }

        static TSum SumRef<TSource, TResult, TSum, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TSelector selector, TAddition add = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            foreach (ref readonly var item in source)
                sum = add.Invoke(selector.Invoke(in item), sum);
            return sum;
        }

        static TSum SumAt<TSource, TResult, TSum, TSelector, TAddition>(this ReadOnlySpan<TSource> source, TSelector selector, TAddition add = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
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
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
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

