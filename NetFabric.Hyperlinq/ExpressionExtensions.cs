using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    static class ExpressionEx
    {
        public static Expression ForEach(Expression enumerable, Expression loopContent)
        {
            var enumerableType = enumerable.Type;
            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");

            return Expression.Block(new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                EnumerationLoop(enumerator, loopContent));
        }

        public static Expression ForEach(Expression enumerable, ParameterExpression loopVar, Expression loopContent)
        {
            var enumerableType = enumerable.Type;
            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");

            return Expression.Block(new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                EnumerationLoop(enumerator,
                    Expression.Block(new[] { loopVar },
                        Expression.Assign(loopVar, Expression.Property(enumerator, "Current")),
                        loopContent)));
        }

        static Expression EnumerationLoop(ParameterExpression enumerator, Expression loopContent)
        {
            var breakLabel = Expression.Label("EnumerationBreak");
            Expression loop = Expression.Loop(
                    Expression.IfThenElse(
                        Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                        loopContent,
                        Expression.Break(breakLabel)),
                    breakLabel);

            var enumeratorType = enumerator.Type;
            if (enumeratorType.IsGenericType && enumeratorType.GetGenericTypeDefinition() == typeof(IEnumerator<>))
            {
                loop = Expression.TryFinally(
                    loop,
                    Expression.IfThen(
                        Expression.NotEqual(enumerator, Expression.Constant(null)),
                        Expression.Call(enumerator, typeof(IDisposable).GetMethod("Dispose"))));
            }
            else if (enumeratorType.IsValueType)
            {
                if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
                {
                    loop = Expression.TryFinally(
                        loop,
                        Expression.Call(Expression.Convert(enumerator, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose")));
                }
            }
            else
            {
                if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
                {
                    loop = Expression.TryFinally(
                        loop,
                        Expression.IfThen(
                            Expression.NotEqual(enumerator, Expression.Constant(null)),
                            Expression.Call(Expression.Convert(enumerator, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose"))));
                }
                else
                {
                    var disposable = Expression.Variable(typeof(IDisposable), "disposable");
                    loop = Expression.TryFinally(
                        loop,
                        Expression.Block(new[] { disposable },
                            Expression.Assign(disposable, Expression.TypeAs(enumerator, typeof(IDisposable))),
                            Expression.IfThen(
                                Expression.NotEqual(disposable, Expression.Constant(null)),
                                Expression.Call(disposable, typeof(IDisposable).GetMethod("Dispose")))));
                }
            }
            return loop;
        }
    }
}
