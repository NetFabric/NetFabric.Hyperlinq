using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public static TSum Sum<TList, TSource, TSum>(this TList source)
            where TList : IReadOnlyList<TSource>
            where TSum : struct
            => source.Sum<TList, TSource, TSum>(0, source.Count);
        
        static TSum Sum<TList, TSource, TSum>(this TList source, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSum : struct
        {
            var sum = default(TSum);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                sum = GenericsOperator.AddNullable(item, sum);
            }
            return sum;
        }

        static TSum Sum<TList, TSource, TSum, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    sum = GenericsOperator.AddNullable(item, sum);
            }
            return sum;
        }

        static TSum SumAt<TList, TSource, TSum, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    sum = GenericsOperator.AddNullable(item, sum);
            }
            return sum;
        }

        static TSum Sum<TList, TSource, TResult, TSum, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                sum = GenericsOperator.AddNullable(selector.Invoke(item), sum);
            }
            return sum;
        }

        static TSum SumAt<TList, TSource, TResult, TSum, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                sum = GenericsOperator.AddNullable(selector.Invoke(item, index), sum);
            }
            return sum;
        }

        static TSum Sum<TList, TSource, TResult, TSum, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    sum = GenericsOperator.AddNullable(selector.Invoke(item), sum);
            }
            return sum;
        }
    }
}

