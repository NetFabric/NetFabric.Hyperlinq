using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    static partial class ExpressionEx
    {
        public static Expression First<TEnumerable, TSource>(ParameterExpression enumerable, Expression emptySequence)
            where TEnumerable : IEnumerable<TSource>
        {
            var elementType = typeof(TSource);
            var enumerableType = typeof(TEnumerable);
            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
            if (getEnumerator is null)
                getEnumerator = typeof(IEnumerable<>).MakeGenericType(elementType).GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");
            var returnTarget = Expression.Label(elementType);

            return Expression.Block(elementType, new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                ExpressionEx.Using(enumerator,
                    Expression.Block(new ParameterExpression[] { },
                        Expression.IfThen(
                            Expression.Not(Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext"))),
                            Expression.Return(returnTarget, emptySequence)),
                        Expression.Return(returnTarget, Expression.Property(enumerator, "Current")))),
                Expression.Label(returnTarget, Expression.Default(elementType)));
        }

        public static Expression First<TEnumerable, TSource>(ParameterExpression enumerable, ParameterExpression predicate, Expression emptySequence)
            where TEnumerable : IEnumerable<TSource>
        {
            var elementType = typeof(TSource);
            var current = Expression.Variable(elementType, "current");
            var returnTarget = Expression.Label(elementType);

            return Expression.Block(elementType, new ParameterExpression[] { },
                ExpressionEx.ForEach<TSource>(enumerable, current,
                    Expression.IfThen(
                        Expression.Invoke(predicate, current),
                        Expression.Return(returnTarget, current))),
                Expression.Label(returnTarget, emptySequence));
        }

        public static Expression Single<TEnumerable, TSource>(ParameterExpression enumerable, Expression emptySequence)
            where TEnumerable : IEnumerable<TSource>
        {
            var elementType = typeof(TSource);
            var enumerableType = typeof(TEnumerable);
            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
            if (getEnumerator is null)
                getEnumerator = typeof(IEnumerable<>).MakeGenericType(elementType).GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");
            var first = Expression.Variable(elementType, "first");
            var returnTarget = Expression.Label(elementType);

            return Expression.Block(elementType, new[] { enumerator, first },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                ExpressionEx.Using(enumerator,
                    Expression.Block(new ParameterExpression[] { },
                        Expression.IfThen(
                            Expression.Not(Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext"))),
                            Expression.Return(returnTarget, emptySequence)),
                        Expression.Assign(first, Expression.Property(enumerator, "Current")),
                        Expression.IfThen(
                            Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                            Expression.Return(returnTarget, Expression.Call(typeof(ThrowHelper), "ThrowNotSingleSequence", new[] { elementType }))),
                        Expression.Return(returnTarget, first))),
                Expression.Label(returnTarget, Expression.Default(elementType)));
        }

        public static Expression Single<TEnumerable, TSource>(ParameterExpression enumerable, ParameterExpression predicate, Expression emptySequence)
            where TEnumerable : IEnumerable<TSource>
        {
            var elementType = typeof(TSource);
            var enumerableType = typeof(TEnumerable);
            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
            if (getEnumerator is null)
                getEnumerator = typeof(IEnumerable<>).MakeGenericType(elementType).GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");
            var first = Expression.Variable(elementType, "first");
            var returnTarget = Expression.Label(elementType);

            return Expression.Block(elementType, new ParameterExpression[] { enumerator },
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
                                                Expression.Return(returnTarget, Expression.Call(typeof(ThrowHelper), "ThrowNotSingleSequence", new[] { elementType })))),
                                        Expression.Return(returnTarget, first))))),
                        Expression.Return(returnTarget, emptySequence))),
                Expression.Label(returnTarget, Expression.Default(elementType)));
        }

    }
}
