using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        internal static TSum Sum<TEnumerable, TEnumerator, TSource, TSum, TAddition>(this TEnumerable source, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                sum = add.Invoke(enumerator.Current, sum);
            return sum;
        }

        internal static TSum Sum<TEnumerable, TEnumerator, TSource, TSum, TPredicate, TAddition>(this TEnumerable source, TPredicate predicate, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        internal static TSum SumRef<TEnumerable, TEnumerator, TSource, TSum, TPredicate, TAddition>(this TEnumerable source, TPredicate predicate, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(in item))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        internal static TSum SumAt<TEnumerable, TEnumerator, TSource, TSum, TPredicate, TAddition>(this TEnumerable source, TPredicate predicate, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item, index))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        internal static TSum SumAtRef<TEnumerable, TEnumerator, TSource, TSum, TPredicate, TAddition>(this TEnumerable source, TPredicate predicate, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            where TAddition : IFunction<TSource, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate.Invoke(in item, index))
                    sum = add.Invoke(item, sum);
            }
            return sum;
        }

        internal static TSum Sum<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector, TAddition>(this TEnumerable source, TSelector selector, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                sum = add.Invoke(selector.Invoke(item), sum);
            }
            return sum;
        }

        internal static TSum SumRef<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector, TAddition>(this TEnumerable source, TSelector selector, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                sum = add.Invoke(selector.Invoke(in item), sum);
            }
            return sum;
        }

        static TSum SumAt<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector, TAddition>(this TEnumerable source, TSelector selector, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                sum = add.Invoke(selector.Invoke(item, index), sum);
            }
            return sum;
        }

        internal static TSum SumAtRef<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector, TAddition>(this TEnumerable source, TSelector selector, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                sum = add.Invoke(selector.Invoke(in item, index), sum);
            }
            return sum;
        }


        internal static TSum Sum<TEnumerable, TEnumerator, TSource, TResult, TSum, TPredicate, TSelector, TAddition>(this TEnumerable source, TPredicate predicate, TSelector selector, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    sum = add.Invoke(selector.Invoke(item), sum);
            }
            return sum;
        }

        internal static TSum SumRef<TEnumerable, TEnumerator, TSource, TResult, TSum, TPredicate, TSelector, TAddition>(this TEnumerable source, TPredicate predicate, TSelector selector, TAddition add = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            where TAddition : IFunction<TResult, TSum, TSum>
            where TSum : unmanaged
        {
            var sum = default(TSum);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(in item))
                    sum = add.Invoke(selector.Invoke(in item), sum);
            }
            return sum;
        }
    }
}

