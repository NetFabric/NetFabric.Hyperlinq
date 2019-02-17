using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return SingleMethod<TEnumerable, TSource>.Invoke(source);
#else
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    ThrowHelper.ThrowEmptySequence<TSource>();

                var first = enumerator.Current;

                if (enumerator.MoveNext())
                    ThrowHelper.ThrowNotSingleSequence<TSource>();

                return first;
            }
#endif
        }

        internal static class SingleMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");

                var body = ExpressionEx.Single<TEnumerable, TSource>(enumerable, 
                    Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType }));

                return Expression.Lambda<Func<TEnumerable, TSource>>(body, enumerable).Compile();
            }
        }

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return SinglePredicateMethod<TEnumerable, TSource>.Invoke(source, predicate);
#else
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var first = enumerator.Current;
                    if (predicate(first))
                    {
                        // found first, keep going until end or find second
                        while (enumerator.MoveNext())
                        {
                            if (predicate(enumerator.Current))
                                ThrowHelper.ThrowNotSingleSequence<TSource>();
                        }
                        return first;
                    }
                }
                return ThrowHelper.ThrowEmptySequence<TSource>();
            }
#endif
        }

        internal static class SinglePredicateMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, Func<TSource, bool>, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, Func<TSource, bool>, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");

                var body = ExpressionEx.Single<TEnumerable, TSource>(enumerable, predicate,
                    Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType }));

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, TSource>>(body, enumerable, predicate).Compile();
            }
        }
    }
}
