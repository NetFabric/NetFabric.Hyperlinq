using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return FirstMethod<TEnumerable, TSource>.Invoke(source);
#else
            using (var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    ThrowEmptySequence<TSource>();

                return enumerator.Current;
            }
#endif
        }

        internal static class FirstMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");

                var body = ExpressionEx.First<TEnumerable, TSource>(enumerable, 
                    Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType }));

                return Expression.Lambda<Func<TEnumerable, TSource>>(body, enumerable).Compile();
            }
        }

        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return FirstPredicateMethod<TEnumerable, TSource>.Invoke(source, predicate);
#else
            using (var enumerator = source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (predicate(current))
                        return current;
                }
                return ThrowHelper.ThrowEmptySequence();
            }
#endif
        }

        static class FirstPredicateMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, Func<TSource, bool>, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, Func<TSource, bool>, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");

                var body = ExpressionEx.First<TEnumerable, TSource>(enumerable, predicate, 
                    Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType }));

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, TSource>>(body, enumerable, predicate).Compile();
            }
        }
    }
}
