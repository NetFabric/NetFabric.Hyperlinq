using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

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
            var disposeMethod = enumeratorType.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[] { });
            if (disposeMethod is null)
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
                loop = Expression.TryFinally(
                   loop,
                   Expression.Call(enumerator, disposeMethod));
            }
            return loop;
        }
    }
}
