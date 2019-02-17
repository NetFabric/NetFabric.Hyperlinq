using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
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

        static class FirstMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerableType = typeof(TEnumerable);
                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumerator.ReturnType;
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var returnTarget = Expression.Label(elementType);

                var body = Expression.Block(elementType, new[] { enumerator },
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                    ExpressionEx.Using(enumerator,
                        Expression.Block(new ParameterExpression[] { },
                            Expression.IfThen(
                                Expression.Not(Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext"))),
                                Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType })),
                            Expression.Return(returnTarget, Expression.Property(enumerator, "Current")))),
                    Expression.Label(returnTarget, Expression.Default(elementType)));

                return Expression.Lambda<Func<TEnumerable, TSource>>(body, enumerable).Compile();
            }
        }

        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
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
                var current = Expression.Variable(elementType, "current");
                var returnTarget = Expression.Label(elementType);

                var body = Expression.Block(elementType, new ParameterExpression[] { },
                    ExpressionEx.ForEach(enumerable, current,
                        Expression.IfThen(
                            Expression.Invoke(predicate, current),
                            Expression.Return(returnTarget, current))),
                    Expression.Label(returnTarget, Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType })));

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, TSource>>(body, enumerable, predicate).Compile();
            }
        }
    }
}
