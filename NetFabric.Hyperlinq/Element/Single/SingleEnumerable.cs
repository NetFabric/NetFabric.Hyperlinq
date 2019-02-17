using System;
using System.Collections;
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
                var enumerableType = typeof(TEnumerable);
                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                if (getEnumerator is null)
                    getEnumerator = typeof(IEnumerable<>).MakeGenericType(elementType).GetMethod("GetEnumerator");
                var enumeratorType = getEnumerator.ReturnType;
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var first = Expression.Variable(elementType, "first");
                var returnTarget = Expression.Label(elementType);

                var body = Expression.Block(elementType, new[] { enumerator, first },
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                    ExpressionEx.Using(enumerator,
                        Expression.Block(new ParameterExpression[] { },
                            Expression.IfThen(
                                Expression.Not(Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext"))),
                                Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType })),
                            Expression.Assign(first, Expression.Property(enumerator, "Current")),
                            Expression.IfThen(
                                Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                                Expression.Call(typeof(ThrowHelper), "ThrowNotSingleSequence", new[] { elementType })),
                            Expression.Return(returnTarget, first))),
                    Expression.Label(returnTarget, Expression.Default(elementType)));

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
                var enumerableType = typeof(TEnumerable);
                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");
                var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                if (getEnumerator is null)
                    getEnumerator = typeof(IEnumerable<>).MakeGenericType(elementType).GetMethod("GetEnumerator");
                var enumeratorType = getEnumerator.ReturnType;
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var first = Expression.Variable(elementType, "first");
                var returnTarget = Expression.Label(elementType);

                var body = Expression.Block(elementType, new ParameterExpression[] { enumerator },
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                    ExpressionEx.Using(enumerator, 
                        Expression.Block(new ParameterExpression[] { },
                            ExpressionEx.While(
                                Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                                Expression.Block(new ParameterExpression[] { first },
                                    Expression.Assign(first, Expression.Property(enumerator, "Current")),
                                    Expression.IfThen(
                                        Expression.Invoke(predicate, first),
                                        Expression.Block(new ParameterExpression[] { },
                                            ExpressionEx.While(
                                                Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                                                Expression.IfThen(
                                                    Expression.Invoke(predicate, Expression.Property(enumerator, "Current")),
                                                    Expression.Call(typeof(ThrowHelper), "ThrowNotSingleSequence", new[] { elementType }))),
                                            Expression.Return(returnTarget, first))))),
                            Expression.Return(returnTarget, Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", new[] { elementType })))),
                    Expression.Label(returnTarget, Expression.Default(elementType)));

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, TSource>>(body, enumerable, predicate).Compile();
            }
        }
    }
}
