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
                var enumerableType = typeof(TEnumerable);

                var getEnumeratorMethod = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var count = Expression.Variable(typeof(int), "count");

                var body = Expression.Block(new[] { enumerator, count },
                    Expression.Assign(count, Expression.Constant(0)),
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumeratorMethod)),
                    ExpressionEx.EnumerationLoop(enumerable, enumerator,
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

        static class CountPredicateMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, Func<TSource, bool>, int> Invoke { get; } = Create();

            public static Func<TEnumerable, Func<TSource, bool>, int> Create()
            {
                var elementType = typeof(TSource);
                var enumerableType = typeof(TEnumerable);

                var getEnumeratorMethod = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var count = Expression.Variable(typeof(int), "count");

                var body = Expression.Block(new[] { enumerator, count },
                    Expression.Assign(count, Expression.Constant(0)),
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumeratorMethod)),
                    ExpressionEx.EnumerationLoop(enumerable, enumerator,
                        Expression.IfThen(
                            Expression.Invoke(predicate, Expression.Property(enumerator, "Current")),
                            Expression.Assign(count, Expression.Increment(count)))),
                    count);

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, int>>(body, enumerable).Compile();        
            }
        }
    }
}
