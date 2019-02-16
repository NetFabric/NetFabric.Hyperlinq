using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
        {
            if (source == null) ThrowSourceNull();

#if EXPRESSION_TREES
            return CountMethod<TEnumerable, TSource>.Invoke(source);
#else
            var count = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    count++;
            }
            return count;
#endif

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        static class CountMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, int> Invoke { get; } = Create();

            public static Func<TEnumerable, int> Create()
            {
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var count = Expression.Variable(typeof(int), "count");

                var body = Expression.Block(new[] { count },
                    Expression.Assign(count, Expression.Constant(0)),
                    ExpressionEx.ForEach(enumerable,
                        Expression.Assign(count, Expression.Increment(count))),
                    count);

                return Expression.Lambda<Func<TEnumerable, int>>(body, enumerable).Compile();        
            }
        }

        public static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
        {
            if (source == null) ThrowSourceNull();

#if EXPRESSION_TREES
            return CountPredicateMethod<TEnumerable, TSource>.Invoke(source, predicate);
#else
            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
#endif

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        internal static class CountPredicateMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, Func<TSource, bool>, int> Invoke { get; } = Create();

            public static Func<TEnumerable, Func<TSource, bool>, int> Create()
            {
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(typeof(TSource), typeof(bool)), "predicate");
                var count = Expression.Variable(typeof(int), "count");
                var current = Expression.Variable(typeof(TSource), "current");

                var body = Expression.Block(new ParameterExpression[] { count },
                    Expression.Assign(count, Expression.Constant(0)),
                    ExpressionEx.ForEach(enumerable, current,
                        Expression.IfThen(
                            Expression.Invoke(predicate, current),
                            Expression.Assign(count, Expression.Increment(count)))),
                    count);

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, int>>(body, enumerable, predicate).Compile();        
            }
        }
    }
}
