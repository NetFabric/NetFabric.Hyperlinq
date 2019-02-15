using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    static class ExpressionEx
    {
        public static Expression EnumerationLoop(ParameterExpression enumerable, ParameterExpression enumerator, Expression body)
        {
            var enumeratorType = enumerator.Type;

            var breakLabel = Expression.Label("EnumerationBreak");
            Expression loop = Expression.Loop(
                    Expression.IfThenElse(
                        Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                        body,
                        Expression.Break(breakLabel)),
                    breakLabel);

            var disposeMethod = enumeratorType.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[] { });
            if (disposeMethod is null)
            {
                if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
                {
                    loop = Expression.TryFinally(
                       loop,
                       Expression.Call(Expression.TypeAs(enumerator, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose")));
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
