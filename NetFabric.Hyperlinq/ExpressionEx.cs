using System;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    static class ExpressionEx
    {
        public static Expression Using(ParameterExpression variable, Expression body) 
        {
            if(!typeof(IDisposable).IsAssignableFrom(variable.Type))
                return body;

            return Expression.TryFinally(
                body,
                Expression.Call(variable, typeof(IDisposable).GetMethod("Dispose")));
        }

        public static LoopExpression While(Expression test, Expression body) 
        {
            var label = Expression.Label();
            return Expression.Loop(
                Expression.IfThenElse(
                    test,
                    body,
                    Expression.Break(label)),
                label);
        }
    }
}